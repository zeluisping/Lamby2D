using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Lamby2D.Core;
using Lamby2D.Native;
using Lamby2D.Native.FreeType;
using Lamby2D.OpenGL;

namespace Lamby2D.Drawing
{
    public class Graphics : IDisposable
    {
        // Variables
        readonly float[] _vertexdata = new float[6 * 2]
        {
            0, 0,
            1, 0,
            1, 1,
            1, 1,
            0, 1,
            0, 0,
        };
        Color _backgroundcolor;
        PolygonMode _polygonmode;
        Color _drawcolor;

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
        public PolygonMode PolygonMode
        {
            get { return _polygonmode; }
            set
            {
                if (_polygonmode != value) {
                    _polygonmode = value;
                    OpenGL11.glPolygonMode(OpenGL11.GL_FRONT_AND_BACK, (uint) value);
                }
            }
        }
        public Color DrawColor
        {
            get { return _drawcolor; }
            set
            {
                if (_drawcolor != value) {
                    _drawcolor = value;
                    OpenGL11.glColor4f(value.R, value.G, value.B, value.A);
                }
            }
        }

        // Public
        public void Clear()
        {
            OpenGL11.glClear(OpenGL11.GL_COLOR_BUFFER_BIT | OpenGL11.GL_DEPTH_BUFFER_BIT);
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

            Texture2D result = new Texture2D(textures[0]) { Width = (int) width, Height = (int) height };
            return result;
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
        public void Draw(IStaticDrawable drawable)
        {
            OpenGL11.glPushMatrix();
            if (drawable.Position != drawable.Position) {
                OpenGL11.glTranslatef(this.GraphicsContext.Width / 2.0f, this.GraphicsContext.Height / 2.0f, 0);
            } else {
                OpenGL11.glTranslatef(drawable.Position.X, drawable.Position.Y, 0);
            }

            if (drawable.Scale != drawable.Scale) {
                OpenGL11.glScalef(this.GraphicsContext.Width, this.GraphicsContext.Height, 1);
            } else {
                OpenGL11.glScalef(drawable.Scale.X * drawable.Texture.Width, drawable.Scale.Y * drawable.Texture.Height, 1);
            }

            OpenGL11.glRotatef(drawable.Rotation, 0, 0, 1);
            OpenGL11.glTranslatef(-drawable.Center.X, -drawable.Center.Y, 0);
            OpenGL11.glColor4f(drawable.Color.R, drawable.Color.G, drawable.Color.B, drawable.Color.A);
            draw(drawable.Texture);
            OpenGL11.glColor4f(this.DrawColor.R, this.DrawColor.G, this.DrawColor.B, this.DrawColor.A);
            OpenGL11.glPopMatrix();
        }
        public Vector2 ScreenToWorld(Point screen)
        {
            return new Vector2(screen.X, screen.Y);
        }
        public Point? WorldToScreen(Vector2 world)
        {
            if (world.X < 0 || world.X >= this.GraphicsContext.Width || world.X < 0 || world.Y >= this.GraphicsContext.Height) {
                return null;
            }
            return new Point((int) world.X, (int) world.Y);
        }
        public void DrawCircle(Vector2 position, float radius)
        {
            OpenGL11.glDisable(OpenGL11.GL_TEXTURE_2D);
            OpenGL11.glPushMatrix();
            OpenGL11.glTranslatef(position.X, position.Y, 0);
            OpenGL11.glBegin(OpenGL11.GL_TRIANGLE_FAN);
            int steps = (int) (radius * 2 / 3);
            double angle = 0;
            double anglestep = Math.PI * 2 / steps;
            OpenGL11.glVertex2f(0, 0);
            for (int step = 0; step <= steps; step++) {
                OpenGL11.glVertex2f((float) Math.Cos(angle) * radius, (float) Math.Sin(angle) * radius);
                angle += anglestep;
            }
            OpenGL11.glEnd();
            OpenGL11.glPopMatrix();
            OpenGL11.glEnable(OpenGL11.GL_TEXTURE_2D);
        }
        public void DrawRectangle(Vector2 position, float rotation, float width, float height)
        {
            OpenGL11.glDisable(OpenGL11.GL_TEXTURE_2D);
            OpenGL11.glPushMatrix();
            OpenGL11.glTranslatef(position.X, position.Y, 0);
            OpenGL11.glScalef(width, height, 1);
            OpenGL11.glRotatef(rotation, 0, 0, 1);
            OpenGL11.glDrawArrays(OpenGL11.GL_TRIANGLES, 0, 6);
            OpenGL11.glPopMatrix();
            OpenGL11.glEnable(OpenGL11.GL_TEXTURE_2D);
        }

        // Private
        void draw(Texture2D texture)
        {
            OpenGL11.glBindTexture(OpenGL11.GL_TEXTURE_2D, (texture == null ? 0 : texture.ID));
            OpenGL11.glDrawArrays(OpenGL11.GL_TRIANGLES, 0, 6);
        }

        // Constructors
        public Graphics()
        {
            DevIL.ilInit();

            this.GraphicsContext = new GraphicsContext();
            this.BackgroundColor = Colors.Black;
            this.PolygonMode = PolygonMode.Fill;
            this.DrawColor = Colors.White;
            this.GraphicsContext.Window.Show();

            OpenGL11.glMatrixMode(OpenGL11.GL_PROJECTION);
            OpenGL11.glLoadIdentity();
            OpenGL11.glOrtho(0, this.GraphicsContext.Width, this.GraphicsContext.Height, 0, 1, -1);
            OpenGL11.glMatrixMode(OpenGL11.GL_MODELVIEW);
            OpenGL11.glLoadIdentity();
            OpenGL11.glEnable(OpenGL11.GL_CULL_FACE);
            OpenGL11.glEnable(OpenGL11.GL_BLEND);
            OpenGL11.glEnable(OpenGL11.GL_TEXTURE_2D);
            //OpenGL11.glEnable(OpenGL11.GL_DEPTH_TEST);
            //OpenGL11.glEnable(OpenGL11.GL_ALPHA_TEST);
            OpenGL11.glCullFace(OpenGL11.GL_FRONT);
            OpenGL11.glBlendFunc(OpenGL11.GL_SRC_ALPHA, OpenGL11.GL_ONE_MINUS_SRC_ALPHA);
            //OpenGL11.glDepthFunc(OpenGL11.GL_GEQUAL);
            //OpenGL11.glAlphaFunc(OpenGL11.GL_GREATER, 0.5f);
            //OpenGL11.glClearDepth(int.MinValue);
            //OpenGL11.glDepthRange(int.MaxValue, int.MinValue);
            OpenGL11.glEnableClientState(OpenGL11.GL_VERTEX_ARRAY);
            OpenGL11.glEnableClientState(OpenGL11.GL_TEXTURE_COORD_ARRAY);
            OpenGL11.glVertexPointer(2, OpenGL11.GL_FLOAT, 0, _vertexdata);
            OpenGL11.glTexCoordPointer(2, OpenGL11.GL_FLOAT, 0, _vertexdata);
            //OpenGL11.glDisable(OpenGL11.GL_TEXTURE_2D);
        }
    }
}
