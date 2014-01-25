using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Lamby2D.Native;

namespace Lamby2D.OpenGL
{
    public static class OpenGL11
    {
        /* Constants */
        // glClear
        public const uint GL_COLOR_BUFFER_BIT = 0x00004000;
        public const uint GL_DEPTH_BUFFER_BIT = 0x00000100;
        public const uint GL_STENCIL_BUFFER_BIT = 0x00000400;
        // glBlendFunc
        public const uint GL_ZERO = 0;
        public const uint GL_ONE = 1;
        public const uint GL_SRC_ALPHA = 0x0302;
        public const uint GL_ONE_MINUS_SRC_ALPHA = 0x0303;
        public const uint GL_DST_ALPHA = 0x0304;
        public const uint GL_ONE_MINUS_DST_ALPHA = 0x0305;
        public const uint GL_DST_COLOR = 0x0306;
        public const uint GL_ONE_MINUS_DST_COLOR = 0x0307;
        public const uint GL_SRC_ALPHA_SATURATE = 0x0308;
        public const uint GL_SRC_COLOR = 0x0300;
        public const uint GL_ONE_MINUS_SRC_COLOR = 0x0301;
        // glBindTexture
        public const uint GL_TEXTURE_1D = 0x0DE0;
        public const uint GL_TEXTURE_2D = 0x0DE1;
        // glCullFace
        public const uint GL_FRONT = 0x0404;
        public const uint GL_BACK = 0x0405;
        public const uint GL_FRONT_AND_BACK = 0x0408;
        // glEnable/glDisable
        public const uint GL_ALPHA_TEST = 0x0BC0;
        public const uint GL_BLEND = 0x0BE2;
        public const uint GL_COLOR_MATERIAL = 0x0B57;
        public const uint GL_CULL_FACE = 0x0B44;
        public const uint GL_DEPTH_TEST = 0x0B71;
        public const uint GL_SCISSOR_TEST = 0x0C11;
        public const uint GL_STENCIL_TEST = 0x0B90;
        // glFrontFace
        public const uint GL_CW = 0x0900;
        public const uint GL_CCW = 0x0901;
        // glPolygonMode
        public const uint GL_POINT = 0x1B00;
        public const uint GL_LINE = 0x1B01;
        public const uint GL_FILL = 0x1B02;
        // glTexParameteri
        public const uint GL_TEXTURE_MAG_FILTER = 0x2800;
        public const uint GL_TEXTURE_MIN_FILTER = 0x2801;
        public const uint GL_TEXTURE_WRAP_S = 0x2802;
        public const uint GL_TEXTURE_WRAP_T = 0x2803;
        public const uint GL_NEAREST = 0x2600;
        public const uint GL_LINEAR = 0x2601;
        public const uint GL_NEAREST_MIPMAP_NEAREST = 0x2700;
        public const uint GL_LINEAR_MIPMAP_NEAREST = 0x2701;
        public const uint GL_NEAREST_MIPMAP_LINEAR = 0x2702;
        public const uint GL_LINEAR_MIPMAP_LINEAR = 0x2703;
        public const uint GL_CLAMP = 0x2900;
        public const uint GL_REPEAT = 0x2901;
        // glTexImage2D
        public const uint GL_PROXY_TEXTURE_2D = 0x8064;
        public const uint GL_ALPHA = 0x1906;
        public const uint GL_ALPHA4 = 0x803B;
        public const uint GL_ALPHA8 = 0x803C;
        public const uint GL_ALPHA12 = 0x803D;
        public const uint GL_ALPHA16 = 0x803E;
        public const uint GL_LUMINANCE = 0x1909;
        public const uint GL_LUMINANCE4 = 0x803F;
        public const uint GL_LUMINANCE8 = 0x8040;
        public const uint GL_LUMINANCE12 = 0x8041;
        public const uint GL_LUMINANCE16 = 0x8042;
        public const uint GL_LUMINANCE_ALPHA = 0x190A;
        public const uint GL_LUMINANCE4_ALPHA4 = 0x8043;
        public const uint GL_LUMINANCE6_ALPHA2 = 0x8044;
        public const uint GL_LUMINANCE8_ALPHA8 = 0x8045;
        public const uint GL_LUMINANCE12_ALPHA4 = 0x8046;
        public const uint GL_LUMINANCE12_ALPHA12 = 0x8047;
        public const uint GL_LUMINANCE16_ALPHA16 = 0x8048;
        public const uint GL_INTENSITY = 0x8049;
        public const uint GL_INTENSITY4 = 0x804A;
        public const uint GL_INTENSITY8 = 0x804B;
        public const uint GL_INTENSITY12 = 0x804C;
        public const uint GL_INTENSITY16 = 0x804D;
        public const uint GL_R3_G3_B2 = 0x2A10;
        public const uint GL_RGB = 0x1907;
        public const uint GL_RGB4 = 0x804F;
        public const uint GL_RGB5 = 0x8050;
        public const uint GL_RGB8 = 0x8051;
        public const uint GL_RGB10 = 0x8052;
        public const uint GL_RGB12 = 0x8053;
        public const uint GL_RGB16 = 0x8054;
        public const uint GL_RGBA = 0x1908;
        public const uint GL_RGBA2 = 0x8055;
        public const uint GL_RGBA4 = 0x8056;
        public const uint GL_RGB5_A1 = 0x8057;
        public const uint GL_RGBA8 = 0x8058;
        public const uint GL_RGB10_A2 = 0x8059;
        public const uint GL_RGBA12 = 0x805A;
        public const uint GL_RGBA16 = 0x805B;
        public const uint GL_COLOR_INDEX = 0x1900;
        public const uint GL_RED = 0x1903;
        public const uint GL_GREEN = 0x1904;
        public const uint GL_BLUE = 0x1905;
        public const uint GL_BYTE = 0x1400;
        public const uint GL_UNSIGNED_BYTE = 0x1401;
        public const uint GL_SHORT = 0x1402;
        public const uint GL_UNSIGNED_SHORT = 0x1403;
        public const uint GL_INT = 0x1404;
        public const uint GL_UNSIGNED_INT = 0x1405;
        public const uint GL_FLOAT = 0x1406;
        // glEnableClientState/glDisableClientState
        public const uint GL_VERTEX_ARRAY = 0x8074;
        public const uint GL_NORMAL_ARRAY = 0x8075;
        public const uint GL_COLOR_ARRAY = 0x8076;
        public const uint GL_INDEX_ARRAY = 0x8077;
        public const uint GL_TEXTURE_COORD_ARRAY = 0x8078;
        public const uint GL_EDGE_FLAG_ARRAY = 0x8079;
        // glDrawElements
        public const uint GL_POINTS = 0x0000;
        public const uint GL_LINES = 0x0001;
        public const uint GL_LINE_LOOP = 0x0002;
        public const uint GL_LINE_STRIP = 0x0003;
        public const uint GL_TRIANGLES = 0x0004;
        public const uint GL_TRIANGLE_STRIP = 0x0005;
        public const uint GL_TRIANGLE_FAN = 0x0006;
        public const uint GL_QUADS = 0x0007;
        public const uint GL_QUAD_STRIP = 0x0008;
        public const uint GL_POLYGON = 0x0009;
        // glMatrixMode
        public const uint GL_MODELVIEW = 0x1700;
        public const uint GL_PROJECTION = 0x1701;
        public const uint GL_TEXTURE = 0x1702;
        // glDepthFunc
        public const int GL_NEVER = 0x0200;
        public const int GL_LESS = 0x0201;
        public const int GL_EQUAL = 0x0202;
        public const int GL_LEQUAL = 0x0203;
        public const int GL_GREATER = 0x0204;
        public const int GL_NOTEQUAL = 0x0205;
        public const int GL_GEQUAL = 0x0206;
        public const int GL_ALWAYS = 0x0207;

        // Private constants
        const string DllName = "opengl32.dll";

        // Static variables
        static IntPtr lib = IntPtr.Zero;

        // Dll imports
        #region opengl32.dll
        [DllImport(DllName)]
        public static extern int wglDescribePixelFormat(IntPtr hdc, int ipfd, uint cjpfd, [In, MarshalAs(UnmanagedType.LPStruct)] PixelFormatDescriptor ppfd);
        [DllImport(DllName)]
        public static extern IntPtr wglCreateContext(IntPtr hDc);
        [DllImport(DllName)]
        public static extern bool wglDeleteContext(IntPtr oldContext);
        [DllImport(DllName)]
        public static extern bool wglMakeCurrent(IntPtr hDc, IntPtr newContext);

        [DllImport(DllName)]
        public static extern void glClear(uint mask);
        [DllImport(DllName)]
        public static extern void glClearColor(float red, float green, float blue, float alpha);
        [DllImport(DllName)]
        public static extern void glBlendFunc(uint sfactor, uint dfactor);
        [DllImport(DllName)]
        public static extern void glBindTexture(uint target, uint texture);
        [DllImport(DllName)]
        public static extern void glCullFace(uint mode);
        [DllImport(DllName)]
        public static extern void glEnable(uint cap);
        [DllImport(DllName)]
        public static extern void glDisable(uint cap);
        [DllImport(DllName)]
        public static extern void glFinish();
        [DllImport(DllName)]
        public static extern void glFlush();
        [DllImport(DllName)]
        public static extern void glFrontFace(uint mode);
        [DllImport(DllName)]
        public static extern void glDeleteTextures(int n, IntPtr textures);
        [DllImport(DllName)]
        public static extern void glGenTextures(int n, IntPtr textures);
        [DllImport(DllName)]
        public static extern void glLoadMatrixf(IntPtr m);
        [DllImport(DllName)]
        public static extern void glPolygonMode(uint face, uint mode);
        [DllImport(DllName)]
        public static extern void glScissor(int x, int y, int width, int height);
        [DllImport(DllName)]
        public static extern void glTexParameteri(uint target, uint pname, int param);
        [DllImport(DllName)]
        public static extern void glTexImage2D(uint target, int level, int internalformat, int width, int height, int border, uint format, uint type, IntPtr pixels);
        [DllImport(DllName)]
        public static extern void glEnableClientState(uint cap);
        [DllImport(DllName)]
        public static extern void glDisableClientState(uint cap);
        [DllImport(DllName)]
        public static extern void glColorPointer(int size, uint type, int stride, IntPtr pointer);
        [DllImport(DllName)]
        public static extern void glVertexPointer(int size, uint type, int stride, float[] pointer);
        [DllImport(DllName)]
        public static extern void glTexCoordPointer(int size, uint type, int stride, float[] pointer);
        [DllImport(DllName)]
        public static extern void glDrawElements(uint mode, int count, uint type, IntPtr pointer);
        [DllImport(DllName)]
        public static extern void glOrtho(double left, double right, double bottom, double top, double zNear, double zFar);
        [DllImport(DllName)]
        public static extern void glMatrixMode(uint mode);
        [DllImport(DllName)]
        public static extern void glLoadIdentity();
        [DllImport(DllName)]
        public static extern void glDrawArrays(uint mode, int stride, int count);
        [DllImport(DllName)]
        public static extern void glPushMatrix();
        [DllImport(DllName)]
        public static extern void glPopMatrix();
        [DllImport(DllName)]
        public static extern void glTranslatef(float x, float y, float z);
        [DllImport(DllName)]
        public static extern void glRotatef(float angle, float x, float y, float z);
        [DllImport(DllName)]
        public static extern void glScalef(float x, float y, float z);
        [DllImport(DllName)]
        public static extern void glViewport(int x, int y, int width, int height);
        [DllImport(DllName)]
        public static extern void glIndexPointer(uint type, int stride, IntPtr pointer);
        [DllImport(DllName)]
        public static extern void glDepthFunc(uint func);
        [DllImport(DllName)]
        public static extern void glClearDepth(double depth);
        [DllImport(DllName)]
        public static extern void glDepthRange(double nearVal, double farVal);
        [DllImport(DllName)]
        public static extern void glAlphaFunc(uint func, float _ref);
        #endregion

        // Public static
        public static void LoadLibrary()
        {
            lib = Kernel32.LoadLibrary(DllName);
        }
    }
}
