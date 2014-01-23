using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Lamby2D.Core;
using Lamby2D.Native;
using Lamby2D.OpenGL;

namespace Lamby2D.Drawing
{
    public class Graphics : IDisposable
    {
        // Variables
        Color _backgroundcolor;
        float[,] _vertices = new float[4, 2]
        {
             { 0, 0 },
             { 1, 0 },
             { 1, 1 },
             { 0, 1 },
        };
        float[,] _texcoords = new float[4, 2]
        {
            { 0, 0 },
            { 1, 0 },
            { 1, 1 },
            { 0, 1 },
        };
        uint[] _indices = new uint[6]
        {
            0, 1, 3,
            1, 2, 3,
        };

        // Properties
        public GraphicsContext GraphicsContext { get; private set; }
        public Color BackgroundColor
        {
            get { return _backgroundcolor; }
            set
            {
                if (_backgroundcolor != value) {
                    _backgroundcolor = value;
                    OpenGL11.glClearColor(value.R, value.G, value.B, value.A);
                }
            }
        }

        // Public
        public void Clear()
        {
            OpenGL11.glClear(OpenGL11.GL_COLOR_BUFFER_BIT);
        }
        public void Flush()
        {
            GDI32.SwapBuffers(this.GraphicsContext.DrawingContext);
        }
        public Texture2D CreateTexture(uint width, uint height, TextureFormat format, byte[] pixels)
        {
            uint[] textures = new uint[] { 0 };

            OpenGL11.glGenTextures(1, Marshal.UnsafeAddrOfPinnedArrayElement(textures, 0));
            OpenGL11.glBindTexture(OpenGL11.GL_TEXTURE_2D, textures[0]);
            OpenGL11.glTexParameteri(OpenGL11.GL_TEXTURE_2D, OpenGL11.GL_TEXTURE_WRAP_S, (int) OpenGL11.GL_REPEAT);
            OpenGL11.glTexParameteri(OpenGL11.GL_TEXTURE_2D, OpenGL11.GL_TEXTURE_WRAP_T, (int) OpenGL11.GL_REPEAT);
            OpenGL11.glTexParameteri(OpenGL11.GL_TEXTURE_2D, OpenGL11.GL_TEXTURE_MAG_FILTER, (int) OpenGL11.GL_LINEAR);
            OpenGL11.glTexParameteri(OpenGL11.GL_TEXTURE_2D, OpenGL11.GL_TEXTURE_MIN_FILTER, (int) OpenGL11.GL_LINEAR);
            OpenGL11.glTexImage2D(OpenGL11.GL_TEXTURE_2D, 0, (int) format, (int) width, (int) height, 0, (uint) format, OpenGL11.GL_UNSIGNED_BYTE, Marshal.UnsafeAddrOfPinnedArrayElement(pixels, 0));
            OpenGL11.glBindTexture(OpenGL11.GL_TEXTURE_2D, 0);

            return new Texture2D(textures[0]);
        }
        public Texture2D CreateTexture(string filename)
        {
            uint id = DevIL.ilGenImage();
            DevIL.ilBindImage(id);

            if (DevIL.ilLoadImage(filename) == 0) {
                DevIL.ilBindImage(0);
                DevIL.ilDeleteImage(id);
                return null;
            }

            TextureFormat format = (TextureFormat) DevIL.ilGetInteger(DevIL.IL_IMAGE_FORMAT);
            int width = DevIL.ilGetInteger(DevIL.IL_IMAGE_WIDTH);
            int height = DevIL.ilGetInteger(DevIL.IL_IMAGE_HEIGHT);
            byte[] pixels = new byte[DevIL.ilGetInteger(DevIL.IL_IMAGE_SIZE_OF_DATA)];

            DevIL.ilCopyPixels(0, 0, 0, (uint) width, (uint) height, 1, (uint) format, DevIL.IL_UNSIGNED_BYTE, Marshal.UnsafeAddrOfPinnedArrayElement(pixels, 0));
            DevIL.ilBindImage(0);
            DevIL.ilDeleteImage(id);

            return CreateTexture((uint) width, (uint) height, format, pixels);
        }
        public void Dispose()
        {
            this.GraphicsContext.Dispose();
            this.GraphicsContext = null;
        }
        public void Draw(Texture2D texture)
        {
            OpenGL11.glBindTexture(OpenGL11.GL_TEXTURE_2D, (texture == null ? 0 : texture.ID));
            OpenGL11.glDrawElements(OpenGL11.GL_TRIANGLES, 6, OpenGL11.GL_UNSIGNED_INT, Marshal.UnsafeAddrOfPinnedArrayElement(_indices, 0));
        }
        public void Draw(IStaticDrawable drawable)
        {
            OpenGL11.glPushMatrix();
            OpenGL11.glTranslatef(drawable.Position.X, drawable.Position.Y, 0);
            OpenGL11.glRotatef(drawable.Rotation, 0, 0, 1);
            OpenGL11.glTranslatef(-drawable.Center.X, -drawable.Center.Y, 0);
            Draw(drawable.Texture);
            OpenGL11.glPopMatrix();
        }

        // Constructors
        public Graphics()
        {
            DevIL.ilInit();

            this.GraphicsContext = new GraphicsContext();
            this.BackgroundColor = Colors.Black;
            this.GraphicsContext.Window.Show();

            OpenGL11.glMatrixMode(OpenGL11.GL_PROJECTION);
            OpenGL11.glLoadIdentity();
            OpenGL11.glOrtho(-1, 1, 1, -1, Int32.MaxValue, Int32.MinValue);
            OpenGL11.glMatrixMode(OpenGL11.GL_MODELVIEW);
            OpenGL11.glLoadIdentity();
            OpenGL11.glDisable(OpenGL11.GL_DEPTH_TEST);
            OpenGL11.glDisable(OpenGL11.GL_STENCIL_TEST);
            OpenGL11.glEnable(OpenGL11.GL_CULL_FACE);
            OpenGL11.glEnable(OpenGL11.GL_BLEND);
            OpenGL11.glEnable(OpenGL11.GL_TEXTURE_2D);
            OpenGL11.glCullFace(OpenGL11.GL_BACK);
            OpenGL11.glFrontFace(OpenGL11.GL_CCW);
            OpenGL11.glBlendFunc(OpenGL11.GL_SRC_ALPHA, OpenGL11.GL_ONE_MINUS_SRC_ALPHA);
            OpenGL11.glEnableClientState(OpenGL11.GL_VERTEX_ARRAY);
            OpenGL11.glEnableClientState(OpenGL11.GL_TEXTURE_COORD_ARRAY);
            OpenGL11.glVertexPointer(2, OpenGL11.GL_FLOAT, 0, Marshal.UnsafeAddrOfPinnedArrayElement(_vertices, 0));
            OpenGL11.glTexCoordPointer(2, OpenGL11.GL_FLOAT, 0, Marshal.UnsafeAddrOfPinnedArrayElement(_texcoords, 0));
            OpenGL11.glDisable(OpenGL11.GL_CULL_FACE);
        }
    }
}
