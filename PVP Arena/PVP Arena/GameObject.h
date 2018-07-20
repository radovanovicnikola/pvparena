#pragma once
#include <SDL.h>
#include "Window.h"

class GameObject {
public:
	//treba dodati i texture rect ako se ne koristi citava tekstura
	SDL_Rect rectTexture;
	SDL_Rect* _rectTextureP;//zbog draw()
	SDL_Rect rectScreen;
	SDL_Texture* texture;
	bool needToDraw;	//za variabilni fps ; govori da li se kod objekta vizuelno nesto promenilo

	GameObject(SDL_Texture* texture) {
		_rectTextureP=NULL; //citava tekstura je za prikaz, nije samo njen deo
		this->texture = texture;
		needToDraw = true;
	};

	/**
	*  \rectTexture se kopira u GameObject (nije referenca!)
	*/
	GameObject(SDL_Texture* texture,SDL_Rect *rectTexture) {
		_rectTextureP = rectTexture;
		rectTexture = new SDL_Rect(*rectTexture);//pravi se kopija
		this->texture = texture;
		needToDraw = true;
	};

	void draw() {
		SDL_RenderCopy(Window::renderer,texture, _rectTextureP, &rectScreen);
		needToDraw = false;
	}

	/**
	*  \also set needToDraw = true
	*/
	_inline void moveHorizontalS(int dX) {
		rectScreen.x += dX;
		needToDraw = true;
	}

	_inline void moveVerticalS(int dY) {
		rectScreen.y += dY;
		needToDraw = true;
	}
};
