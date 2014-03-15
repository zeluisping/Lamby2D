#pragma once

// includes
#include "freetype-2.5.3\include\ft2build.h"
#include FT_FREETYPE_H

// defines
#define dllexport __declspec(dllexport)

// extern c
#ifdef __cplusplus
extern "C" {
#endif

	// TODO: 64bit bla bla?

	// structs
	typedef struct s_font
	{
		FT_Face face;
	} *font;
	typedef struct s_glyphdata
	{
		unsigned int charcode;
		int left;
		int top;
		int advance;
		int width;
		int height;
		unsigned char * buffer;
	} *glyphdata;

	// functions
	dllexport int font_init();
	dllexport font font_fromfile(const char * file);
	dllexport font font_frommemory(const unsigned char * data);
	dllexport int font_set_char_size(font font, int width, int height, unsigned int hres, unsigned int vres);
	dllexport int font_set_pixel_sizes(font font, unsigned int width, unsigned int height);
	dllexport glyphdata font_load_glyph(font font, unsigned int charcode);
	dllexport int font_delete(font font);
	
	// END extern c
#ifdef __cplusplus
}
#endif