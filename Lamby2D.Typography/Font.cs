using Lamby2D.Native.FreeType;
using Lamby2D.OpenGL;
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

            OpenGL11.glBindTexture(OpenGL11.GL_TEXTURE_2D, texbase[character]);
            OpenGL11.glTexParameteri(OpenGL11.GL_TEXTURE_2D, OpenGL11.GL_TEXTURE_MAG_FILTER, (int) OpenGL11.GL_LINEAR);
            OpenGL11.glTexParameteri(OpenGL11.GL_TEXTURE_2D, OpenGL11.GL_TEXTURE_MIN_FILTER, (int) OpenGL11.GL_LINEAR);
            OpenGL11.glTexImage2D(OpenGL11.GL_TEXTURE_2D, 0, (int) OpenGL11.GL_RGBA, width, height, 0, OpenGL11.GL_LUMINANCE_ALPHA, OpenGL11.GL_UNSIGNED_BYTE, Marshal.UnsafeAddrOfPinnedArrayElement(expanded_data, 0));

            OpenGL11.glNewList(listbase + character, OpenGL11.GL_COMPILE);
            {
                OpenGL11.glBindTexture(OpenGL11.GL_TEXTURE_2D, texbase[character]);
                OpenGL11.glPushMatrix();
                {
                    OpenGL11.glTranslatef(face.glyph.bitmap_left, face.glyph.bitmap_top - bitmap.rows, 0);

                    float x = (float) bitmap.width / (float) width;
                    float y = (float) bitmap.rows / (float) height;

                    OpenGL11.glBegin(OpenGL11.GL_QUADS);
                    {
                        OpenGL11.glTexCoord2f(0, 0);
                        OpenGL11.glVertex2f(0, bitmap.rows);

                        OpenGL11.glTexCoord2f(0, y);
                        OpenGL11.glTexCoord2f(0, 0);

                        OpenGL11.glTexCoord2f(x, y);
                        OpenGL11.glVertex2f(bitmap.width, 0);

                        OpenGL11.glTexCoord2f(x, 0);
                        OpenGL11.glVertex2f(bitmap.width, bitmap.rows);
                    }
                    OpenGL11.glEnd();
                }
                OpenGL11.glPopMatrix();

                OpenGL11.glTranslatef(face.glyph.advance.x >> 6, 0, 0);
            }
            OpenGL11.glEndList();
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
