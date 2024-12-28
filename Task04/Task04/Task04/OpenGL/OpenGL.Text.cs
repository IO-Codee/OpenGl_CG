using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace Task04
{
    partial class OpenGL
    {
        const int n = 4;
        double[,] projection = new double[n, n];
        double[,] modelview = new double[n, n];
        int[,] viewport = new int[2, 2];

        private Encoding ascii = Encoding.Default;
        protected uint idFont { get; set; } = 0;

        [Category("OpenGL")]
        public int TextCodePage
        {
            get { return ascii.CodePage; }
            set
            {
                ascii = null;
                ascii = Encoding.GetEncoding(value);
                Invalidate();
                //  OnFontChange(this, EventArgs.Empty);
            }
        }

        public enum Vertical { Baseline = 0, Top, Middle, Bottom };
        public enum Horizontal { Left = 0, Centered, Right };

        private Vertical alignment = Vertical.Baseline;
        private Horizontal justification = Horizontal.Left;

        [Category("OpenGL"), DefaultValue(Vertical.Baseline)]
        public Vertical TextAlignment
        {
            get { return alignment; }
            set { alignment = value; Invalidate(); }
        }

        [Category("OpenGL"), DefaultValue(Horizontal.Left)]
        public Horizontal TextJustification
        {
            get { return justification; }
            set { justification = value; Invalidate(); }
        }

        protected void LoadCurrentFont()
        {
            DeleteFont();

            SelectObject(hDC, Font.ToHfont());
            idFont = glGenLists(256);
            wglUseFontBitmaps(hDC, 0, 256, idFont);
        }

        private void DeleteFont()
        {
            if (glIsList(idFont) == GL_TRUE)
                glDeleteLists(idFont, 256);
        }

        public void DrawText(string s, double x, double y, double z = 0)
        {
            Byte[] encodedBytes = ascii.GetBytes(s);

            if ((alignment != Vertical.Baseline) || (justification != Horizontal.Left))
                OriginPointCorrection(s, ref x, ref y, ref z);

            glRasterPos3d(x, y, z);
            glListBase(idFont);
            glCallLists(s.Length, GL_UNSIGNED_BYTE, encodedBytes);
        }

        private void OriginPointCorrection(string s, ref double x, ref double y, ref double z)
        {
            var r = TextRectange(s);

            GetGLMatrix();

            double xx, yy;
            (xx, yy) = WorldToScreen(x, y, z);

            if (justification == Horizontal.Centered) xx -= ((r.Width + r.X * 2) >> 1);
            if (justification == Horizontal.Right) xx -= ((r.Width + r.X * 2) >> 0);

            if (alignment == Vertical.Middle) yy += ((r.Height + r.Y * 2) >> 1);
            if (alignment == Vertical.Top) yy += ((r.Height + r.Y * 2) >> 0);
            if (alignment == Vertical.Bottom) yy += ((0 + r.Y * 2) >> 0);

            (x, y, z) = ScreenToWorld((int)xx, (int)yy);
        }

        protected Rectangle TextRectange(string s)
        {
            Font f = this.Font;
            FontFamily ff = f.FontFamily;

            Size sz = TextRenderer.MeasureText(s, f);

            int dc = ff.GetCellDescent(f.Style);
            int descentPixel = (int)Math.Round((f.Size * dc) / ff.GetEmHeight(f.Style));

            int dx1 = TextRenderer.MeasureText("G", f).Width;
            int dx2 = TextRenderer.MeasureText("GG", f).Width;
            int bearingX = (dx1 * 2 - dx2) >> 1;

            Rectangle rc = new Rectangle(new Point(-bearingX - 0, -descentPixel - 0), sz);
            return rc;
        }

        // https://stackoverflow.com/questions/8491247/c-opengl-convert-world-coords-to-screen2d-coords
        // vec4 clipSpacePos = projectionMatrix * (viewMatrix * vec4(point3D, 1.0));
        // vec3 ndcSpacePos = clipSpacePos.xyz / clipSpacePos.w;
        // vec2 windowSpacePos = ((ndcSpacePos.xy + 1.0) / 2.0) * viewSize + viewOffset;
        // if the window-space if relative to the top-left of the window, then windowSpacePos should be vec2(((ndcSpacePos.x + 1.0) / 2.0) * viewSize.x + viewOffset.x, ((1.0 - ndcSpacePos.y) / 2.0) * viewSize.y + viewOffset.y )
        (double, double) WorldToScreen(double x, double y, double z)
        {
            double[] P = new double[n] { x, y, z, 1 };

            // GetGLMatrix();

            var Pos = MultMV(projection, MultMV(modelview, P));
            for (int i = 0; i < n; i++)
                Pos[i] /= Pos[n - 1];

            double xx = ((Pos[0] + 1.0) / 2.0) * viewport[1, 0] + viewport[0, 0];
            double yy = ((1.0 - Pos[1]) / 2.0) * viewport[1, 1] - viewport[0, 1];

            return (xx, yy);
        }

        (double, double, double) ScreenToWorld(int x, int y)
        {
            double posX, posY, posZ, z;

            // GetGLMatrix();

            y = viewport[1, 1] - y;

            z = 1.0 - 1.0 / 100.0;
            //glReadPixels(x, y, 1, 1, GL_DEPTH_COMPONENT, GL_DOUBLE, out winZ);
            //gluUnProject(x, y, winZ, modelview, projection, viewport, out posX, out posY, out posZ);

            gluUnProject(x, y, z, modelview, projection, viewport, out posX, out posY, out posZ);

            return (posX, posY, posZ);
        }

        private void GetGLMatrix()
        {
            glGetDoublev(GL_MODELVIEW_MATRIX, modelview);
            glGetDoublev(GL_PROJECTION_MATRIX, projection);
            glGetIntegerv(GL_VIEWPORT, viewport);
        }

        double[] MultMV(double[,] M, double[] V)
        {
            int n = V.Length;
            double[] result = new double[n];
            for (int i = 0; i < n; i++)
            {
                result[i] = 0;
                for (int j = 0; j < n; j++)
                    result[i] += (M[j, i] * V[j]);
            }
            return result;
        }
    }
}