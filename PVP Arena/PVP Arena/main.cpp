#include "Window.h"
#include "MediaLoader.h"
#include "GameObject.h"

int main(int argc, char* args[]) {
	//init
	Window::setWindowSize(640, 480);
	Window::init();
	MediaLoader::init();

	//ucitavanje resursa
	SDL_Texture* txtrTest = MediaLoader::loadTexture("Tile (1).png");
	
	//testiranje game objecta
	GameObject* gameObject = new GameObject(txtrTest);
	gameObject->rectScreen = { 20,20,128,128 };

	//main loop
	while (!Window::quit) {
		//obrada eventa
		while (SDL_WaitEvent(&Window::event)) {
			if (Window::event.type == SDL_EventType::SDL_QUIT)
			{
				Window::quit = true;
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
				default:
					break;
				}
			}
		}

		if (gameObject->needToDraw) {
			Window::clear();
			gameObject->draw();
			Window::update();
		}
	}

	Window::free();
	MediaLoader::free();
	SDL_DestroyTexture(txtrTest);

	return 0;
}