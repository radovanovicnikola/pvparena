#pragma once
#include <SDL.h>
#include <stdio.h>

#define WINDOW_TITLE "PVP Arena test"
#define WINDOW_STYLE SDL_WINDOW_SHOWN
#define clearScreen() SDL_RenderClear(Window::renderer)
#define updateScreen() SDL_RenderPresent(Window::renderer)

class Window {
public:
	static int width;
	static int height;
	static SDL_Window* window;
	static SDL_Renderer* renderer;
	static SDL_Event event;
	static bool quit;

	static void setWindowSize(int width, int height);

	/**
	*  \mora se pozvati setScreenResolution(width,height) pre same
	*  \inicijalizacije
	*/
	static bool init();

	static void free();

	_inline static void  clear() {
		SDL_RenderClear(Window::renderer);
	}

	_inline static void  update() {
		SDL_RenderPresent(Window::renderer);
	}

};