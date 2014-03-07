using Lamby2D.Native.FreeType;
using Lamby2D.Native.OpenGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Lamby2D.Typography
{
    [Obsolete("not implemented", true)]
    public class Font
    {
        // Public static
        public static Font FromFile(string file)
        {
            FT_Face face;

            int error = FreeType.FT_New_Face(TypographyManager.LibraryHandle, file, 0, out face);
            if (error == FreeType.FT_Err_Unknown_File_Format) {
                throw new Exception("Unknown file format when trying to load font from file '" + file + "'.");
            } else if (error != 0) {
                throw new Exception("An error occurred while trying to load font from file '" + file + "'.");
            }

            FreeType.FT_Set_Pixel_Sizes(face, 0, 16);

            return new Font() { face = face };
        }

        // Static
        int NextPower2(int x)
        {
            int result = 1;
            while (result < x) {
                result <<= 1;
            }
            return result;
        }
        void MakeCharacterList(FT_Face face, char character, uint listbase, uint[] texbase)
        {
            // Load glyph
            if (FreeType.FT_Load_Char(face, character, FreeType.FT_LOAD_DEFAULT) != 0) {
                throw new Exception("FreeType.FT_Load_Char failed on character '" + character + "'.");
            }

            if (FreeType.FT_Render_Glyph(face.glyph, FT_Render_Mode.Normal) != 0) {
                throw new Exception("FreeType.FT_Render_Glyph failed on character '" + character + "'.");
            }

            FT_Bitmap bitmap = face.glyph.bitmap;

            int width = NextPower2(bitmap.width);
            int height = NextPower2(bitmap.rows);

            byte[] expanded_data = new byte[width * height * 2];

            for (int y = 0; y < height; y++) {
                for (int x = 0; x < width; x++) {
                    expanded_data[2 * (x + y * width)] =
                        expanded_data[2 * (x + y * width) + 1] =
                        (x >= bitmap.width || y >= bitmap.rows)
                            ? (byte) 0
                            : bitmap.buffer[x + bitmap.width * y];
                }
            }

            OpenGL.glBindTexture(OpenGL.GL_TEXTURE_2D, texbase[character]);
            OpenGL.glTexParameteri(OpenGL.GL_TEXTURE_2D, OpenGL.GL_TEXTURE_MAG_FILTER, (int) OpenGL.GL_LINEAR);
            OpenGL.glTexParameteri(OpenGL.GL_TEXTURE_2D, OpenGL.GL_TEXTURE_MIN_FILTER, (int) OpenGL.GL_LINEAR);
            OpenGL.glTexImage2D(OpenGL.GL_TEXTURE_2D, 0, (int) OpenGL.GL_RGBA, width, height, 0, OpenGL.GL_LUMINANCE_ALPHA, OpenGL.GL_UNSIGNED_BYTE, Marshal.UnsafeAddrOfPinnedArrayElement(expanded_data, 0));

            OpenGL.glNewList(listbase + character, OpenGL.GL_COMPILE);
            {
                OpenGL.glBindTexture(OpenGL.GL_TEXTURE_2D, texbase[character]);
                OpenGL.glPushMatrix();
                {
                    OpenGL.glTranslatef(face.glyph.bitmap_left, face.glyph.bitmap_top - bitmap.rows, 0);

                    float x = (float) bitmap.width / (float) width;
                    float y = (float) bitmap.rows / (float) height;

                    OpenGL.glBegin(OpenGL.GL_QUADS);
                    {
                        OpenGL.glTexCoord2f(0, 0);
                        OpenGL.glVertex2f(0, bitmap.rows);

                        OpenGL.glTexCoord2f(0, y);
                        OpenGL.glTexCoord2f(0, 0);

                        OpenGL.glTexCoord2f(x, y);
                        OpenGL.glVertex2f(bitmap.width, 0);

                        OpenGL.glTexCoord2f(x, 0);
                        OpenGL.glVertex2f(bitmap.width, bitmap.rows);
                    }
                    OpenGL.glEnd();
                }
                OpenGL.glPopMatrix();

                OpenGL.glTranslatef(face.glyph.advance.x >> 6, 0, 0);
            }
            OpenGL.glEndList();
        }

        // Variables
        FT_Face face;
        float _height;

        // Properties
        public float Height
        {
            get { return _height; }
            set { _height = value; }
        }

        // Constructors
        private Font()
        {
        }
    }
}
