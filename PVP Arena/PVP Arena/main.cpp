#include "Window.h"
#include "MediaLoader.h"
#include "GameObject.h"
#include <thread>
#include <mutex>
#include <condition_variable>
#include<Windows.h>
#include "SDL_syswm.h"

enum class ThreadMsg {
	NoMsg = -1,
	Draw,
	Quit
};

GameObject* gameObject;
std::mutex m;
std::condition_variable cv;
ThreadMsg threadMsg;


void drawingThreadF();

int main(int argc, char* args[]) {
	//init
	Window::setWindowSize(640, 480);
	Window::init();
	MediaLoader::init();

	//ucitavanje resursa
	SDL_Texture* txtrTest = MediaLoader::loadTexture("Tile (1).png");
	
	//testiranje game objecta
	gameObject = new GameObject(txtrTest);
	gameObject->rectScreen = { 20,20,128,128 };

	//inicijalizovanje pomocnjih niti
	std::thread drawingThread(drawingThreadF);

	//radi samo za Windows
	SDL_SysWMinfo wmInfo;
	SDL_VERSION(&wmInfo.version);
	SDL_GetWindowWMInfo(Window::window, &wmInfo);
	HWND hwnd = wmInfo.info.win.window;
	HINSTANCE hInst= wmInfo.info.win.hinstance;

	HWND editctl = CreateWindow(L"EDIT", L"", WS_CHILD | WS_VISIBLE | WS_BORDER | ES_LEFT | ES_AUTOHSCROLL | ES_WANTRETURN, 400,50, 100, 50,hwnd, (HMENU)NULL, hInst, 0);
	char edtText[2000];
	//main loop
	while (!Window::quit) {
		//obrada eventa
		while (SDL_WaitEvent(&Window::event)) { //sleep if no event
			
			if (Window::event.type == SDL_EventType::SDL_QUIT)
			{
				Window::quit = true;
				break; //break while wait loop
			}
			else if (Window::event.type == SDL_EventType::SDL_KEYDOWN) {
				switch (Window::event.key.keysym.sym)
				{
				case SDLK_LEFT:
					gameObject->moveHorizontalS(-5);
					break;
				case SDLK_RIGHT:
					gameObject->moveHorizontalS(5);
					break;
				case SDLK_UP:
					gameObject->moveVerticalS(-5);
					break;
				case SDLK_DOWN:
					gameObject->moveVerticalS(5);
					break;
				case SDLK_SPACE://test; preuzimanje unetog teksta
					GetWindowTextA(editctl, edtText, 2000);
					MessageBoxA(hwnd, edtText, "Test", MB_OK);
					break;
				default:
					break;
				}
			}
			else if (Window::event.type == SDL_EventType::SDL_MOUSEBUTTONDOWN) {
				SetFocus(hwnd);			//vracanje focusa sa edit boxa na glavni prozor	
			}
			if (gameObject->needToDraw) { //if need to draw send msg to slave thread
				threadMsg = ThreadMsg::Draw;
				cv.notify_one();
			}
		}

	}

	//send Quit msg to slave thread
	threadMsg = ThreadMsg::Quit;
	cv.notify_one();
	if(drawingThread.joinable())
		drawingThread.join();

	Window::free();
	MediaLoader::free();
	SDL_DestroyTexture(txtrTest);

	return 0;
}

void drawingThreadF() {
	bool quit = false;

	while (!quit) {
		printf("Ceka se...\n");
		{
			std::unique_lock<std::mutex > lk(m);
			cv.wait(lk, [] {return threadMsg != ThreadMsg::NoMsg; }); //wait for threadMgs (event)
			//if no event sleep
		}
		printf("Primljena poruka.\n");
		switch (threadMsg)
		{
		case ThreadMsg::Draw:
			Window::clear();
			gameObject->draw();
			Window::update();
			break;
		case ThreadMsg::Quit:
			quit = true;
			break;
		default:
			break;
		}
		threadMsg = ThreadMsg::NoMsg; //event handled
	}
}