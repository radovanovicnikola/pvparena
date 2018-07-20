#include "Window.h"

//staticka inicijalizacija
int Window::height;
int Window::width;
SDL_Window*  Window::window;
SDL_Renderer*  Window::renderer;
SDL_Event  Window::event;
bool  Window::quit;

	void Window::setWindowSize(int width, int height) {
		Window::width = width;
		Window::height = height;
	}

	/**
	*  \mora se pozvati setWindowSize(width,height) pre same
	*  \inicijalizacije
	*/
	bool Window::init()
	{
		quit = false;
		//Initialization flag
		bool success = true;

		//Initialize SDL
		if (SDL_Init(SDL_INIT_VIDEO) < 0)
		{
			printf("SDL could not initialize! SDL Error: %s\n", SDL_GetError());
			success = false;
		}
		else
		{
			//Set texture filtering to linear
			if (!SDL_SetHint(SDL_HINT_RENDER_SCALE_QUALITY, "1"))
			{
				printf("Warning: Linear texture filtering not enabled!");
			}

			//Create window
			window = SDL_CreateWindow(WINDOW_TITLE, SDL_WINDOWPOS_UNDEFINED, SDL_WINDOWPOS_UNDEFINED, width, height, WINDOW_STYLE);
			if (window == NULL)
			{
				printf("Window could not be created! SDL Error: %s\n", SDL_GetError());
				success = false;
			}
			else
			{
				//Create renderer for window
				renderer = SDL_CreateRenderer(window, -1, SDL_RENDERER_ACCELERATED);
				if (renderer == NULL)
				{
					printf("Renderer could not be created! SDL Error: %s\n", SDL_GetError());
					success = false;
				}
				else
				{
					//Initialize renderer color
					SDL_SetRenderDrawColor(renderer, 0xFF, 0xFF, 0xFF, 0xFF);
				}
			}
		}
		return success;
	}

	void Window::free() {
		//Destroy window	
		SDL_DestroyRenderer(renderer);
		SDL_DestroyWindow(window);

		SDL_Quit();
	}