
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace Task04
{
    [ToolboxItem(false), DefaultEvent("Render")]
    public partial class OpenGL : UserControl
    {
        private IntPtr hdc = IntPtr.Zero;
        private IntPtr hrc = IntPtr.Zero;
        protected IntPtr hDC
        {
            get
            {
                return (hdc == IntPtr.Zero) ? hdc = GetDC(Handle) : hdc;
            }
            private set
            {
                if ((value != IntPtr.Zero) || (hdc == IntPtr.Zero))
                    return;

                ReleaseDC(Handle, hdc);
                hdc = IntPtr.Zero;
            }
        }

        protected IntPtr hRC
        {
            get
            {
                if (hrc != IntPtr.Zero) return hrc;

                PIXELFORMATDESCRIPTOR pfd = pfdDefault;
                int pixelFormat = ChoosePixelFormat(hDC, ref pfd);
                int result = SetPixelFormat(hDC, pixelFormat, ref pfd);
                hrc = wglCreateContext(hDC);

                return hrc;
            }
            private set
            {
                if ((value != IntPtr.Zero) || (hrc == IntPtr.Zero))
                    return;

                wglDeleteContext(hrc);
                hrc = IntPtr.Zero;
            }
        }

        [Category("OpenGL")] public event EventHandler Render;
        [Category("OpenGL")] public event EventHandler ContextCreated;
        [Category("OpenGL")] public event EventHandler ContextDeleting;

        public OpenGL()
        {
            InitializeComponent();

            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            HandleCreated += SetOpenGLWindowStyle; ;
            HandleCreated += InitializeOpenGL;
            HandleDestroyed += FinalizeOpenGL;

            if (Program.DesignMode)
                FontChanged += OnFontChange;
        }

        private void OnFontChange(object sender, EventArgs e)
        {
            wglMakeCurrent(hDC, hRC);

            if (hDC != IntPtr.Zero)
            {
                LoadCurrentFont();
                Invalidate(false);
            }

            wglMakeCurrent(hDC, IntPtr.Zero);
        }

        private void SetOpenGLWindowStyle(object sender, EventArgs e)
        {
            SetStyle(ControlStyles.Opaque, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.ResizeRedraw, true);
            UpdateStyles();
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ClassStyle = CS_VREDRAW | CS_HREDRAW | CS_OWNDC; //cp.ClassStyle | 
                cp.Style = WS_VISIBLE | WS_CHILD | WS_CLIPCHILDREN | WS_CLIPSIBLINGS; // cp.Style | 
                cp.ExStyle = 0;
                return cp;
            }
        }
        private void InitializeOpenGL(object sender, EventArgs e)
        {
            wglMakeCurrent(hDC, hRC);

            if (glIsList(idFont) == GL_FALSE)
                LoadCurrentFont();

            glClearColor(BackColor.R / 255.0f, BackColor.G / 255.0f, BackColor.B / 255.0f, 1);
            glClear(GL_COLOR_BUFFER_BIT);

            if (DesignMode || Render == null)
                Render += DummyRender;

            ContextCreated?.Invoke(this, EventArgs.Empty);

            wglMakeCurrent(hDC, IntPtr.Zero);
        }

        private void FinalizeOpenGL(object sender, EventArgs e)
        {
            wglMakeCurrent(hDC, hRC);

            ContextDeleting?.Invoke(this, EventArgs.Empty);
            DeleteFont();

            wglMakeCurrent(IntPtr.Zero, IntPtr.Zero);
            hRC = IntPtr.Zero;
            hDC = IntPtr.Zero;
        }

        private void DummyRender(object sender, EventArgs e)
        {
            glClearColor(BackColor.R / 255.0f, BackColor.G / 255.0f, BackColor.B / 255.0f, 1);
            glClear(glClearBits);

            glLoadIdentity();
            glViewport(0, 0, Width, Height);
            glOrtho(0, Width, Height, 0, -1, 1);

            glColor(Color.White);
            DrawText("OpenGL Control. Design mode", 10, Font.Height);
            DrawText("Code page test : Єє Іі Її Ёё Ээ Ъъ", 10, Font.Height * 2);

            glBegin(GL_POLYGON);
            glColor(Color.WhiteSmoke);
            glVertex2d(10, Font.Height * 2.7);
            glVertex2d(Width - 10, Font.Height * 2.7);
            glColor(Color.DarkSlateGray);
            glVertex2d(Width - 10, Font.Height * 3);
            glVertex2d(10, Font.Height * 3);
            glEnd();

            glColor(Color.WhiteSmoke);
            DrawText($"{glGetString(GL_VENDOR)}, {glGetString(GL_VERSION)}", 10, Font.Height * 4);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (Render == null) return;

            wglMakeCurrent(hDC, hRC);

            Render?.Invoke(this, EventArgs.Empty);

            wglSwapBuffers(wglGetCurrentDC());

            wglMakeCurrent(hDC, IntPtr.Zero);
        }

    }
}

