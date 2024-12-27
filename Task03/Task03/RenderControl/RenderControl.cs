using System;
using System.Collections.Generic;
using static System.Math;

namespace Task_3
{
    public partial class RenderControl : OpenGL
    {
        private float x_min, x_max;
        private float y_min = -2, y_max = 2.5f;
        private int point;
        private List<float> point_zeros = new List<float>();
        private float increment = 0;
        private bool manualYRange = false; // New flag for manual Y range

        public RenderControl()
        {
            this.x_min = -0.2f;
            this.x_max = 0.8f;
            this.point = 480; // Number of points
            this.increment = (Abs(x_min) + Abs(x_max)) / Convert.ToSingle(point);
            InitializeComponent();
        }

        public void SetXMin(float x_min)
        {
            this.x_min = x_min;
        }

        public void SetXMax(float x_max)
        {
            this.x_max = x_max;
        }

        public void SetPointCount(int point)
        {
            this.point = point;
            this.increment = (Abs(x_min) + Abs(x_max)) / Convert.ToSingle(point);
        }

        public void SetYMin(float y_min)
        {
            this.y_min = y_min;
            manualYRange = true; // Enable manual Y range
        }

        public void SetYMax(float y_max)
        {
            this.y_max = y_max;
            manualYRange = true; // Enable manual Y range
        }

        // Calculate Y range and zeros of f(x)
        private void CalculateFunctionInfo(Func<float, float> func)
        {
            if (!manualYRange)
            {
                y_min = float.MaxValue;
                y_max = float.MinValue;
            }
            point_zeros.Clear();
            float prev_y = float.MaxValue;

            for (float x = x_min; x < x_max; x += increment)
            {
                float y = func(x);

                // Update Ymin and Ymax (Automatic scaling for Y-axis if not manual)
                if (!manualYRange)
                {
                    if (y < y_min) y_min = y - 0.1f;
                    if (y > y_max) y_max = y + 0.1f;
                }

                // Find roots of the function (f(x) = 0)
                if (prev_y * y <= 0)
                {
                    point_zeros.Add(x - increment / 2); // Midpoint of interval
                }
                prev_y = y;
            }
        }

        // Function f1(x) = (cos(pi*x)) / ((sin((5*pi*x)/3) + 1.5)^3)
        private float FunctionF1(float x)
        {
            return (float)(Cos(PI * x) / Pow(Sin((5 * PI * x) / 3) + 1.5, 3));
        }

        // Function f2(x) = tg(2*sin(x))
        private float FunctionF2(float x)
        {
            if (Cos(2 * Sin(x)) == 0) return float.NaN; // Handle discontinuity
            return (float)Tan(2 * Sin(x));
        }

        // Draw coordinate axes
        private void DrawMainAxes()
        {
            glLineWidth(1);
            glColor3ub(200, 200, 200);
            glBegin(GL_LINES);
            glVertex2d(x_min, 0);
            glVertex2d(x_max, 0);
            glVertex2d(0, y_min);
            glVertex2d(0, y_max);
            glEnd();
        }

        // Draw function graph
        private void DrawFunction(Func<float, float> func, byte r, byte g, byte b)
        {
            glLineWidth(2);
            glColor3ub(r, g, b); // Color for the graph
            glBegin(GL_LINE_STRIP);
            for (float x = x_min; x < x_max; x += increment)
            {
                float y = func(x);
                if (!float.IsNaN(y) && !float.IsInfinity(y)) // Skip invalid values
                    glVertex2f(x, y);
            }
            glEnd();
        }

        // Highlight zero points
        private void DrawZeroPoints()
        {
            glPointSize(8);
            glColor3ub(255, 165, 0); // Orange color for zeros
            glBegin(GL_POINTS);
            foreach (var zero in point_zeros)
            {
                glVertex2f(zero, 0);
            }
            glEnd();
        }

        private void OnRender(object sender, EventArgs e)
        {
            glClearColor(0.1f, 0.1f, 0.1f, 1.0f); // Dark grey background
            glClear(GL_COLOR_BUFFER_BIT);
            glLoadIdentity();
            glViewport(0, 0, Width, Height);

            // Compute graph data for f1(x)
            CalculateFunctionInfo(FunctionF1);
            glOrtho(x_min, x_max, y_min, y_max, -1, 1);

            DrawMainAxes(); // Draw coordinate axes
            DrawFunction(FunctionF1, 0, 0, 255); // Blue for f1(x)
            DrawZeroPoints(); // Highlight zeros of f1(x)

            // Advanced: Draw f2(x) with proper handling of discontinuities
            DrawFunction(FunctionF2, 50, 205, 50); // Lime green for f2(x)
        }
    }
}
