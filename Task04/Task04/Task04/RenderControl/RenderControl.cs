//RenderContol.cs

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Design;
using System.Linq;
using System.Security.Policy;

namespace Task04
{
    public partial class RenderControl : OpenGL
    {
        Figures draw;
        public double StartX { get; set; }
        public double EndX { get; set; }
        public double StartY { get; set; }
        public double EndY { get; set; }
        public double Length { get; set; } = 1.5;
        public bool figur { get; set; } = false;
        public bool IsUp { get; set; } = true;
        public bool LineExist { get; set; } = false;
        public double A { get; set; } = 2.0;
        public double B { get; set; } = 1.0;
        public RenderControl()
        {
            InitializeComponent();
        }
        private void OnRender(object sender, EventArgs e)
        {
            glClearColor(1.0f, 1.0f, 1.0f, 1.0f);
            glClear(GL_COLOR_BUFFER_BIT);
            glLoadIdentity();

            int size = Math.Min(Width, Height);
            glViewport((Width - size) / 2, (Height - size) / 2, size, size);
            Length = draw.FindMax(A, B, figur);
            gluOrtho2D(-Length, Length, -Length, Length);
            draw.DrawGrid(-Length, Length, -Length, Length);
            draw.DrawCoordinateGrid(-Length, Length, -Length, Length);

            if (!figur)
                draw.ParametricCircle(A); 
            else
                draw.ExplicitHyperbola(A, B); 

            if (LineExist)
            {
                CreateLine();
                draw.SearchPoint(A, B, StartX, StartY, EndX, EndY, figur);
            }
        }
        private void CreateLine()
        {
            if (!IsUp)
            {
                draw.DrawLineWait(StartX, EndX, StartY, EndY);
            }
            else
            {
                draw.DrawLine(StartX, EndX, StartY, EndY);
            }
        }
        private void Created(object sender, EventArgs e)
        {
            draw = new Figures();
        }
    }

    
}

