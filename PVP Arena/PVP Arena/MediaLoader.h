#pragma once
#include <SDL.h>
#include <SDL_image.h>
#include<string>
#include <stdio.h>
#include "Window.h"

class MediaLoader {

public:

	static bool init();

	static void free();

	static SDL_Texture* loadTexture(std::string path);

};