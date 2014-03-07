using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Lamby2D.Core;
using Lamby2D.Native;
using Lamby2D.Native.FreeType;
using Lamby2D.Typography;
using Lamby2D.Native.OpenGL;

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
        float[] _texcoords = new float[6 * 2]
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
        Viewport _viewport;

        // Properties
        public GraphicsContext GraphicsContext { get; private set; }
        public Color BackgroundColor
        {
            get { return _backgroundcolor; }
            set
            {
                if (_backgroundcolor != value) {
                    _backgroundcolor = value;
                    OpenGL.glClearColor(value.R, value.G, value.B, value.A);
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
                    OpenGL.glPolygonMode(OpenGL.GL_FRONT_AND_BACK, (uint) value);
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
                    OpenGL.glColor4f(value.R, value.G, value.B, value.A);
                }
            }
        }
        public ICamera Camera { get; set; }
        public Viewport Viewport
        {
            get { return _viewport; }
            set
            {
                if (_viewport != value) {
                    _viewport = value;
                    OpenGL.glViewport(value.X, value.Y, value.Width, value.Height);
                }
            }
        }

        // Public
        public void Clear()
        {
            OpenGL.glClear(OpenGL.GL_COLOR_BUFFER_BIT);
            OpenGL.glLoadIdentity();
            if (this.Camera != null && this.Camera.Position.IsNaN() == false) {
                OpenGL.glTranslatef(-this.Camera.Position.X, -this.Camera.Position.Y, 0);
            }
        }
        public void Flush()
        {
            OpenGL.glFlush();
            GDI32.SwapBuffers(this.GraphicsContext.DrawingContext);
        }
        public Texture2D CreateTexture(uint width, uint height, TextureFormat format, byte[] pixels)
        {
            uint[] textures = new uint[] { 0 };

            OpenGL.glGenTextures(1, Marshal.UnsafeAddrOfPinnedArrayElement(textures, 0));
            OpenGL.glBindTexture(OpenGL.GL_TEXTURE_2D, textures[0]);
            OpenGL.glTexParameteri(OpenGL.GL_TEXTURE_2D, OpenGL.GL_TEXTURE_WRAP_S, (int) OpenGL.GL_REPEAT);
            OpenGL.glTexParameteri(OpenGL.GL_TEXTURE_2D, OpenGL.GL_TEXTURE_WRAP_T, (int) OpenGL.GL_REPEAT);
            OpenGL.glTexParameteri(OpenGL.GL_TEXTURE_2D, OpenGL.GL_TEXTURE_MAG_FILTER, (int) OpenGL.GL_LINEAR);
            OpenGL.glTexParameteri(OpenGL.GL_TEXTURE_2D, OpenGL.GL_TEXTURE_MIN_FILTER, (int) OpenGL.GL_LINEAR);
            OpenGL.glTexImage2D(OpenGL.GL_TEXTURE_2D, 0, (int) format, (int) width, (int) height, 0, (uint) format, OpenGL.GL_UNSIGNED_BYTE, Marshal.UnsafeAddrOfPinnedArrayElement(pixels, 0));
            OpenGL.glBindTexture(OpenGL.GL_TEXTURE_2D, 0);

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
        public void Draw(IDrawable drawable)
        {
            if (drawable == null ||
                drawable.DrawableKind == DrawableKind.None ||
                (drawable.DrawableKind == DrawableKind.Texture && drawable.Texture == null) ||
                (drawable.DrawableKind == DrawableKind.Sprite && drawable.Sprite == null) ||
                drawable.Scale.IsNaN() ||
                drawable.Center.IsNaN() ||
                drawable.Position.IsNaN() ||
                drawable.Height == 0 ||
                drawable.Width == 0) {
                return;
            }

            OpenGL.glPushMatrix();
            {
                OpenGL.glTranslatef(drawable.Position.X, drawable.Position.Y, 0);
                OpenGL.glScalef(drawable.Scale.X * drawable.Width, drawable.Scale.Y * drawable.Height, 1);
                OpenGL.glRotatef(drawable.Rotation, 0, 0, 1);
                OpenGL.glTranslatef(-drawable.Center.X, -drawable.Center.Y, 0);
                OpenGL.glColor4f(drawable.Color.R, drawable.Color.G, drawable.Color.B, drawable.Color.A);
                if (drawable.DrawableKind == DrawableKind.Texture) {
                    draw(drawable.Texture);
                } else {
                    draw(drawable.Sprite);
                }
            }
            OpenGL.glPopMatrix();
        }
        public Vector2 ScreenToWorld(Point screen)
        {
            if (this.Camera != null) {
                return new Vector2(screen.X + this.Camera.Position.X, screen.Y + this.Camera.Position.Y);
            }
            return new Vector2(screen.X, screen.Y);
        }
        public Point? WorldToScreen(Vector2 world)
        {
            if (this.Camera != null) {
                if (world.X < this.Camera.Position.X || world.X >= this.Camera.Position.X + this.GraphicsContext.Width || world.Y < this.Camera.Position.Y || world.Y >= this.Camera.Position.Y + this.GraphicsContext.Height) {
                    return null;
                }
                return new Point((int) (world.X + this.Camera.Position.X), (int) (world.Y + this.Camera.Position.Y));
            }

            if (world.X < 0 || world.X >= this.GraphicsContext.Width || world.Y < 0 || world.Y >= this.GraphicsContext.Height) {
                return null;
            }
            return new Point((int) world.X, (int) world.Y);
        }
        public void DrawCircle(Vector2 position, float radius)
        {
            OpenGL.glDisable(OpenGL.GL_TEXTURE_2D);
            OpenGL.glPushMatrix();
            {
                OpenGL.glTranslatef(position.X, position.Y, 0);
                OpenGL.glBegin(OpenGL.GL_TRIANGLE_FAN);
                {
                    int steps = (int) (radius * 2 / 3);
                    double angle = 0;
                    double anglestep = Math.PI * 2 / steps;
                    OpenGL.glVertex2f(0, 0);
                    for (int step = 0; step <= steps; step++) {
                        OpenGL.glVertex2f((float) Math.Cos(angle) * radius, (float) Math.Sin(angle) * radius);
                        angle += anglestep;
                    }
                }
                OpenGL.glEnd();
            }
            OpenGL.glPopMatrix();
            OpenGL.glEnable(OpenGL.GL_TEXTURE_2D);
        }
        public void DrawRectangle(Vector2 position, float rotation, float width, float height)
        {
            OpenGL.glDisable(OpenGL.GL_TEXTURE_2D);
            OpenGL.glPushMatrix();
            {
                OpenGL.glTranslatef(position.X, position.Y, 0);
                OpenGL.glScalef(width, height, 1);
                OpenGL.glRotatef(rotation, 0, 0, 1);
                OpenGL.glDrawArrays(OpenGL.GL_TRIANGLES, 0, 6);
            }
            OpenGL.glPopMatrix();
            OpenGL.glEnable(OpenGL.GL_TEXTURE_2D);
        }
        public void DrawLine(Vector2 start, Vector2 end)
        {
            OpenGL.glDisable(OpenGL.GL_TEXTURE_2D);
            OpenGL.glBegin(OpenGL.GL_LINES);
            {
                OpenGL.glVertex2f(start.X, start.Y);
                OpenGL.glVertex2f(start.X, start.Y);
            }
            OpenGL.glEnd();
            OpenGL.glEnable(OpenGL.GL_TEXTURE_2D);
        }
        public void DrawLine(Vector2 start, Vector2 end, float linewidth)
        {
            if (linewidth == 1) {
                this.DrawLine(start, end);
            } else {
                OpenGL.glDisable(OpenGL.GL_TEXTURE_2D);
                OpenGL.glLineWidth(linewidth);
                OpenGL.glBegin(OpenGL.GL_LINES);
                {
                    OpenGL.glVertex2f(start.X, start.Y);
                    OpenGL.glVertex2f(start.X, start.Y);
                }
                OpenGL.glEnd();
                OpenGL.glLineWidth(1);
                OpenGL.glEnable(OpenGL.GL_TEXTURE_2D);
            }
        }
        public void DrawRectangleBorder(Vector2 position, float rotation, float width, float height, float linewidth)
        {
            OpenGL.glDisable(OpenGL.GL_TEXTURE_2D);
            OpenGL.glLineWidth(linewidth);
            OpenGL.glPushMatrix();
            {
                OpenGL.glRotatef(rotation, 0, 0, 1);
                OpenGL.glBegin(OpenGL.GL_LINE_LOOP);
                {
                    OpenGL.glVertex2f(position.X, position.Y);
                    OpenGL.glVertex2f(position.X + width, position.Y);
                    OpenGL.glVertex2f(position.X + width, position.Y + height);
                    OpenGL.glVertex2f(position.X, position.Y + height);
                }
                OpenGL.glEnd();
            }
            OpenGL.glPopMatrix();
            OpenGL.glLineWidth(1);
            OpenGL.glEnable(OpenGL.GL_TEXTURE_2D);
        }
        public void PushMatrix()
        {
            OpenGL.glPushMatrix();
        }
        public void PopMatrix()
        {
            OpenGL.glPopMatrix();
        }
        public void Translate(Vector2 value)
        {
            OpenGL.glTranslatef(value.X, value.Y, 0);
        }
        public void Translate(Point value)
        {
            OpenGL.glTranslatef(value.X, value.Y, 0);
        }
        public void Translate(float x, float y)
        {
            OpenGL.glTranslatef(x, y, 0);
        }
        public void Rotate(float rotation)
        {
            OpenGL.glRotatef(rotation, 0, 0, 1);
        }
        public void Scale(Vector2 value)
        {
            OpenGL.glScalef(value.X, value.Y, 1);
        }
        public void Scale(float x, float y)
        {
            OpenGL.glScalef(x, y, 1);
        }
        public void Scale(float xy)
        {
            OpenGL.glScalef(xy, xy, 1);
        }
        public void IdentityMatrix()
        {
            OpenGL.glLoadIdentity();
        }
        public void Scissor(int x, int y, int w, int h)
        {
            OpenGL.glScissor(x, y, w, h);
        }
        [Obsolete("not implemented", true)]
        public void Print(string text, Font font, Vector2 position) { }
        [Obsolete("not implemented", true)]
        public void Print(string text, Font font, Point position) { }
        [Obsolete("not implemented", true)]
        public void Print(string text, Font font) { }
        [Obsolete("not implemented", true)]
        public void Print(string text, Vector2 position) { }
        [Obsolete("not implemented", true)]
        public void Print(string text, Point position) { }
        [Obsolete("not implemented", true)]
        public void Print(string text) { }

        // Private
        void draw(Texture2D texture)
        {
            OpenGL.glBindTexture(OpenGL.GL_TEXTURE_2D, (texture == null ? 0 : texture.ID));
            OpenGL.glDrawArrays(OpenGL.GL_TRIANGLES, 0, 6);
        }
        void draw(Sprite sprite)
        {
            OpenGL.glBindTexture(OpenGL.GL_TEXTURE_2D, (sprite.Texture == null ? 0 : sprite.Texture.ID));

            float fu = (sprite.FrameWidth / (float) sprite.Texture.Width);
            float fv = (sprite.FrameHeight / (float) sprite.Texture.Height);
            int x = 0;
            int y = 0;

            if (sprite.CurrentAnimation != null) {
                y = (int) Math.Floor(sprite._animations[sprite.CurrentAnimation].Frames[sprite.Frame] / (float) sprite.Columns);
                x = sprite._animations[sprite.CurrentAnimation].Frames[sprite.Frame] - (y * sprite.Columns);
            }


            // 0,0
            _texcoords[0] = x * fu;
            _texcoords[1] = y * fv;
            // 1,0
            _texcoords[2] = _texcoords[0] + fu;
            _texcoords[3] = _texcoords[1];
            // 1,1
            _texcoords[4] = _texcoords[0] + fu;
            _texcoords[5] = _texcoords[1] + fv;
            // 1,1
            _texcoords[6] = _texcoords[0] + fu;
            _texcoords[7] = _texcoords[1] + fv;
            // 0,1
            _texcoords[8] = _texcoords[0];
            _texcoords[9] = _texcoords[1] + fv;
            // 0,0
            _texcoords[10] = _texcoords[0];
            _texcoords[11] = _texcoords[1];
            OpenGL.glTexCoordPointer(2, OpenGL.GL_FLOAT, 0, _texcoords);
            OpenGL.glDrawArrays(OpenGL.GL_TRIANGLES, 0, 6);
            OpenGL.glTexCoordPointer(2, OpenGL.GL_FLOAT, 0, _vertexdata);
            OpenGL.glVertexPointer(2, OpenGL.GL_FLOAT, 0, _vertexdata);
        }

        // Constructors
        public Graphics()
        {
            DevIL.ilInit();
            DevIL.ilEnable(DevIL.IL_ORIGIN_SET);
            DevIL.ilOriginFunc(DevIL.IL_ORIGIN_UPPER_LEFT);

            this.GraphicsContext = new GraphicsContext();
            this.BackgroundColor = Colors.Black;
            this.PolygonMode = PolygonMode.Fill;
            this.DrawColor = Colors.White;
            this.GraphicsContext.Window.Show();
            this.Camera = new Camera();
            this.Viewport = new Viewport(0, 0, this.GraphicsContext.Width, this.GraphicsContext.Height);

            OpenGL.glMatrixMode(OpenGL.GL_PROJECTION);
            OpenGL.glLoadIdentity();
            OpenGL.glOrtho(0, this.GraphicsContext.Width, this.GraphicsContext.Height, 0, 1, -1);
            OpenGL.glMatrixMode(OpenGL.GL_MODELVIEW);
            OpenGL.glLoadIdentity();

            OpenGL.glEnable(OpenGL.GL_BLEND);
            OpenGL.glEnable(OpenGL.GL_TEXTURE_2D);
            OpenGL.glBlendFunc(OpenGL.GL_SRC_ALPHA, OpenGL.GL_ONE_MINUS_SRC_ALPHA);
            OpenGL.glEnableClientState(OpenGL.GL_VERTEX_ARRAY);
            OpenGL.glEnableClientState(OpenGL.GL_TEXTURE_COORD_ARRAY);

            OpenGL.glClear(OpenGL.GL_COLOR_BUFFER_BIT);
            OpenGL.glFlush();
            GDI32.SwapBuffers(this.GraphicsContext.DrawingContext);

            OpenGL.glVertexPointer(2, OpenGL.GL_FLOAT, 0, _vertexdata);
            OpenGL.glTexCoordPointer(2, OpenGL.GL_FLOAT, 0, _vertexdata);
        }
    }
}
