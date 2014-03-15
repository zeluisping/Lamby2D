//www.freetype.org/freetype2/docs/tutorial/step1.html
#include "font.h"

FT_Library library;

int font_init()
{
	return FT_Init_FreeType(&library);
}

font font_fromfile(const char * file)
{
	FT_Face face;

	int error = 0;
	error = FT_New_Face(library, file, 0, &face);

	if (error == FT_Err_Unknown_File_Format) {
		return nullptr;
	} else if (error) {
		// separate because error handling later
		return nullptr;
	}

	font f = font();
	f->face = face;

	return f;
}

font font_from_memory(const unsigned char * data, int size)
{
	FT_Face face;

	int error = FT_New_Memory_Face(library, data, size, 0, &face);

	if (error) {
		return nullptr;
	}

	font f = font();
	f->face = face;

	return f;
}

int font_set_char_size(font font, int width, int height, unsigned int hres, unsigned int vres)
{
	return FT_Set_Char_Size(font->face, width, height, hres, vres);
}

int font_set_pixel_sizes(font font, unsigned int width, unsigned int height)
{
	return FT_Set_Pixel_Sizes(font->face, width, height);
}

glyphdata font_load_glyph(font font, FT_ULong charcode)
{
	FT_Error error = FT_Load_Char(font->face, charcode, FT_LOAD_RENDER);
	if (error != FT_Err_Ok) {
		return nullptr;
	}

	FT_GlyphSlot gs = font->face->glyph;
	
	glyphdata g = glyphdata();
	g->charcode = charcode;
	g->left = gs->bitmap_left;
	g->top = gs->bitmap_top;
	g->advance = gs->advance.x;
	g->width = gs->bitmap.width;
	g->height = gs->bitmap.rows;
	g->buffer = new unsigned char[g->width * g->height * 2];

	for (int i = 0; i < g->width * g->height; i++) {
		g->buffer[i * 2] = 255;
		g->buffer[i * 2 + 1] = gs->bitmap.buffer[i];
	}

	return g;
}

int font_delete(font font)
{
	return FT_Done_Face(font->face);
}