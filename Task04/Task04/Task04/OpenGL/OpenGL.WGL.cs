using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;

namespace Task04
{
    partial class OpenGL
    {
        public const int CS_VREDRAW = 0x01;
        public const int CS_HREDRAW = 0x02;
        public const int CS_OWNDC = 0x20;

        public const int WS_CLIPCHILDREN = 0x02000000;
        public const int WS_CLIPSIBLINGS = 0x04000000;
        public const int WS_CHILD = 0x40000000;
        public const int WS_VISIBLE = 0x10000000;

        [StructLayout(LayoutKind.Sequential)]
        public struct PIXELFORMATDESCRIPTOR
        {
            public ushort nSize;
            public ushort nVersion;
            public uint dwFlags;
            public byte iPixelType;
            public byte cColorBits;
            public byte cRedBits;
            public byte cRedShift;
            public byte cGreenBits;
            public byte cGreenShift;
            public byte cBlueBits;
            public byte cBlueShift;
            public byte cAlphaBits;
            public byte cAlphaShift;
            public byte cAccumBits;
            public byte cAccumRedBits;
            public byte cAccumGreenBits;
            public byte cAccumBlueBits;
            public byte cAccumAlphaBits;
            public byte cDepthBits;
            public byte cStencilBits;
            public byte cAuxBuffers;
            public byte iLayerType;
            public byte bReserved;
            public uint dwLayerMask;
            public uint dwVisibleMask;
            public uint dwDamageMask;
            // 40 bytes total
        }

        public static void ClearPixelDescriptor(ref PIXELFORMATDESCRIPTOR pfd)
        {
            pfd.nSize = (ushort)Marshal.SizeOf(pfd); // 40 bytes total
            pfd.nVersion = 0;
            pfd.dwFlags = 0; pfd.iPixelType = 0; pfd.cColorBits = 0;
            pfd.cRedBits = 0; pfd.cRedShift = 0; pfd.cGreenBits = 0;
            pfd.cGreenShift = 0; pfd.cBlueBits = 0; pfd.cBlueShift = 0;
            pfd.cAlphaBits = 0; pfd.cAlphaShift = 0; pfd.cAccumBits = 0;
            pfd.cAccumRedBits = 0; pfd.cAccumGreenBits = 0; pfd.cAccumBlueBits = 0;
            pfd.cAccumAlphaBits = 0; pfd.cDepthBits = 0; pfd.cStencilBits = 0;
            pfd.cAuxBuffers = 0; pfd.iLayerType = 0; pfd.bReserved = 0;
            pfd.dwLayerMask = 0; pfd.dwVisibleMask = 0; pfd.dwDamageMask = 0;
        }

        public static readonly PIXELFORMATDESCRIPTOR pfdDefault = new PIXELFORMATDESCRIPTOR
        {
            nSize = (ushort)Marshal.SizeOf(pfdDefault),
            nVersion = 1,
            dwFlags = (PFD_DRAW_TO_WINDOW | PFD_SUPPORT_OPENGL | PFD_DOUBLEBUFFER),
            iPixelType = (byte)(PFD_TYPE_RGBA),
            iLayerType = (byte)(PFD_MAIN_PLANE),
            cColorBits = 32,
            cDepthBits = 24,
            cStencilBits = 8,

            cRedBits = 0,
            cRedShift = 0,
            cGreenBits = 0,
            cGreenShift = 0,
            cBlueBits = 0,
            cBlueShift = 0,
            cAlphaBits = 0,
            cAlphaShift = 0,
            cAccumBits = 0,
            cAccumRedBits = 0,
            cAccumGreenBits = 0,
            cAccumBlueBits = 0,
            cAccumAlphaBits = 0,
            cAuxBuffers = 0,
            bReserved = 0,
            dwLayerMask = 0,
            dwVisibleMask = 0,
            dwDamageMask = 0
        };

        /* pixel types */
        public const uint PFD_TYPE_RGBA = 0;
        public const uint PFD_TYPE_COLORINDEX = 1;

        /* layer types */
        public const uint PFD_MAIN_PLANE = 0;
        public const uint PFD_OVERLAY_PLANE = 1;
        public const uint PFD_UNDERLAY_PLANE = 0xff; // (-1)

        /* PIXELFORMATDESCRIPTOR flags */
        public const uint PFD_DOUBLEBUFFER = 0x00000001;
        public const uint PFD_STEREO = 0x00000002;
        public const uint PFD_DRAW_TO_WINDOW = 0x00000004;
        public const uint PFD_DRAW_TO_BITMAP = 0x00000008;
        public const uint PFD_SUPPORT_GDI = 0x00000010;
        public const uint PFD_SUPPORT_OPENGL = 0x00000020;
        public const uint PFD_GENERIC_FORMAT = 0x00000040;
        public const uint PFD_NEED_PALETTE = 0x00000080;
        public const uint PFD_NEED_SYSTEM_PALETTE = 0x00000100;
        public const uint PFD_SWAP_EXCHANGE = 0x00000200;
        public const uint PFD_SWAP_COPY = 0x00000400;
        public const uint PFD_SWAP_LAYER_BUFFERS = 0x00000800;
        public const uint PFD_GENERIC_ACCELERATED = 0x00001000;
        public const uint PFD_SUPPORT_DIRECTDRAW = 0x00002000;

        /* PIXELFORMATDESCRIPTOR flags for use in ChoosePixelFormat only */
        public const uint PFD_DEPTH_DONTCARE = 0x20000000;
        public const uint PFD_DOUBLEBUFFER_DONTCARE = 0x40000000;
        public const uint PFD_STEREO_DONTCARE = 0x80000000;

        [DllImport(KERNEL_DLL, EntryPoint = "LoadLibrary")]
        public static extern IntPtr LoadLibrary(string dllName);

        [DllImport(USER_DLL, EntryPoint = "GetDC")]
        public static extern IntPtr GetDC(IntPtr hwnd);

        [DllImport(USER_DLL, EntryPoint = "ReleaseDC")]
        public static extern IntPtr ReleaseDC(IntPtr hwnd, IntPtr dc);

        [DllImport(USER_DLL)]
        private static extern uint SetClassLong(IntPtr hwnd, int nIndex, uint dwNewLong);

        [DllImport(GDI_DLL, EntryPoint = "SelectObject")]
        public static extern IntPtr SelectObject(IntPtr dc, IntPtr obj);

        [DllImport(GL_DLL, EntryPoint = "wglUseFontBitmaps")]
        public static extern int wglUseFontBitmaps(IntPtr dc, uint first, uint count, uint ListBase);

        [DllImport(GL_DLL, EntryPoint = "wglUseFontBitmapsW")]
        public static extern int wglUseFontBitmapsW(IntPtr dc, uint first, uint count, uint ListBase);

        /// <summary>
        /// Retrieves an index for a pixel format closest to what is passed
        /// </summary>
        /// <param name="hdc">Device context</param>
        /// <param name="pfd">Pixel Format Descriptor struct</param>
        /// <returns></returns>
        public static int ChoosePixelFormat(IntPtr hdc, ref PIXELFORMATDESCRIPTOR pfd)
        {
            // If the function fails, the return value is zero
            int pixelFormat = Choose_PixelFormat(hdc, ref pfd);

            if (pixelFormat == 0)
            {
                string errorMessage = new Win32Exception(Marshal.GetLastWin32Error()).Message;
                throw new Exception($"Initialize OpenGL. ChoosePixelFormat failed: {errorMessage}.");
            }

            return pixelFormat;
        }
        [DllImport(GDI_DLL, EntryPoint = "ChoosePixelFormat")]
        private static extern int Choose_PixelFormat(IntPtr hdc, ref PIXELFORMATDESCRIPTOR p_pfd);

        /// <summary>
        /// Sets the pixel format for the device context to the format specified by the index
        /// </summary>
        /// <param name="hdc">Device Context</param>
        /// <param name="iPixelFormat">Index to a pixel format returned ChoosePixelFormat</param>
        /// <param name="pfd">Pixel Format Descriptor</param>
        /// <returns></returns>
        public static int SetPixelFormat(IntPtr hdc, int pixelFormat, ref PIXELFORMATDESCRIPTOR pfd)
        {
            LoadLibrary(GL_DLL);

            // If the function fails, the return value is FALSE.
            int result = Set_PixelFormat(hdc, pixelFormat, ref pfd);

            if (result == 0)
            {
                string errorMessage = new Win32Exception(Marshal.GetLastWin32Error()).Message;
                throw new Exception($"Initialize OpenGL. SetPixelFormat failed: {errorMessage}.");
            }

            return result;
        }
        [DllImport(GDI_DLL, EntryPoint = "SetPixelFormat")]
        private static extern int Set_PixelFormat(IntPtr hdc, int iPixelFormat, ref PIXELFORMATDESCRIPTOR p_pfd);

        /// <summary>
        /// Creates a rendering context for the window's Device context.
        /// </summary>
        /// <param name="hdc">Device Context</param>
        /// <returns></returns>
        public static IntPtr wglCreateContext(IntPtr hdc)
        {
            // If the function fails, the return value is NULL
            IntPtr hRC = wgl_CreateContext(hdc);

            if (hRC == IntPtr.Zero)
            {
                string errorMessage = new Win32Exception(Marshal.GetLastWin32Error()).Message;
                throw new Exception($"Initialize OpenGL. wglCreateContext failed: {errorMessage}.");
            }

            return hRC;
        }
        [DllImport(GL_DLL, EntryPoint = "wglCreateContext")]
        private static extern IntPtr wgl_CreateContext(IntPtr hdc);

        /// <summary>
        /// Sets the current rendering context
        /// </summary>
        /// <param name="hdc">Device Context</param>
        /// <param name="hglrc">Rendering Context</param>
        /// <returns></returns>
        [DllImport(GL_DLL, EntryPoint = "wglMakeCurrent")]
        public static extern int wglMakeCurrent(IntPtr hdc, IntPtr hglrc);

        /// <summary>
        /// Deletes the rendering context
        /// </summary>
        /// <param name="hglrc">Rendering context to delet</param>
        /// <returns></returns>
        [DllImport(GL_DLL, EntryPoint = "wglDeleteContext")]
        public static extern int wglDeleteContext(IntPtr hglrc);

        /// <summary>
        /// Swaps the display buffers in a double buffer context
        /// </summary>
        /// <param name="hdc">Device context</param>
        /// <returns></returns>
        [DllImport(GL_DLL, EntryPoint = "wglSwapBuffers")]
        public static extern uint wglSwapBuffers(IntPtr hdc);

        [DllImport(GL_DLL, EntryPoint = "wglGetCurrentContext")]
        public static extern IntPtr wglGetCurrentContext();

        [DllImport(GL_DLL, EntryPoint = "wglGetCurrentDC")]
        public static extern IntPtr wglGetCurrentDC();

        public void glColor(Color c)
        {
            glColor4d(c.R / 255.0, c.G / 255.0, c.B / 255.0, c.A / 255.0);
        }
        public void glClearColor(Color c)
        {
            glClearColor(
                (float)(c.R / 255.0), (float)(c.G / 255.0),
                (float)(c.B / 255.0), (float)(c.A / 255.0)
                );
        }

        [DefaultValue(true), Category("OpenGL")]
        public bool glColorBufferBit { get; set; } = true;

        [DefaultValue(false), Category("OpenGL")]
        public bool glDepthBufferBit { get; set; } = false;

        [DefaultValue(false), Category("OpenGL")]
        public bool glAccumBufferBit { get; set; } = false;

        [DefaultValue(false), Category("OpenGL")]
        public bool glStencilBufferBit { get; set; } = false;
        internal uint glClearBits
        {
            get
            {
                uint result = 0;
                result |= (glColorBufferBit ? GL_COLOR_BUFFER_BIT : 0);
                result |= (glDepthBufferBit ? GL_DEPTH_BUFFER_BIT : 0);
                result |= (glAccumBufferBit ? GL_ACCUM_BUFFER_BIT : 0);
                result |= (glStencilBufferBit ? GL_STENCIL_BUFFER_BIT : 0);
                return result;
            }
        }

    }
}
