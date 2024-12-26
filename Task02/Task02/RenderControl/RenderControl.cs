
using System;
using System.Drawing;

namespace Task_2
{
    public partial class RenderControl : OpenGL
    {
        // Renamed variables for clarity
        public bool FillMode { get; set; } = false;
        public bool PointMode { get; set; } = false;
        public bool LineMode { get; set; } = false;
        public int HexagonCount { get; set; } = 1;
        public int RowCount { get; set; } = 1;
        private readonly double hexagonSize = 100;

        public RenderControl()
        {
            InitializeComponent();
        }

        private void OnRender(object sender, EventArgs e)
        {
            glClear(GL_COLOR_BUFFER_BIT);
            glLoadIdentity();

            if (Width > Height)
                glViewport((Width - Height) / 2, 0, Height, Height);
            else
                glViewport(0, (Height - Width) / 2, Width, Width);

            // Adjusted viewport size calculation
            double viewportSize = Math.Max(HexagonCount, RowCount) * hexagonSize * 3.5;
            glOrtho(-viewportSize, viewportSize, -viewportSize, viewportSize, -1, +1);

            if (FillMode)
                DrawPrimitives(GL_FILL);
            if (PointMode)
            {
                glPointSize(7);
                DrawPrimitives(GL_POINT);
            }
            if (LineMode)
                DrawPrimitives(GL_LINE);
        }

        private void DrawPrimitives(uint mode)
        {
            double hexagonX;
            double hexagonY;

            for (int j = 0; j < RowCount; j++)
            {
                hexagonX = -hexagonSize * 1.5 * j;
                hexagonY = -hexagonSize * 0.85 * j;
                glPolygonMode(GL_FRONT_AND_BACK, mode);

                for (int i = 0; i < HexagonCount; i++)
                {
                    glBegin(GL_TRIANGLES);

                    // Calculate the vertices for the hexagon
                    double[][] vertices = new double[6][];
                    for (int k = 0; k < 6; k++)
                    {
                        double angle = 2 * Math.PI * k / 6;
                        vertices[k] = new double[] { hexagonX + hexagonSize * Math.Cos(angle), hexagonY + hexagonSize * Math.Sin(angle) };
                    }

                    // Define colors in the specified order
                    float[][] colors = new float[][]
                    {
                        new float[] {1.0f, 1.0f, 0.0f}, // Green
                        new float[] {0.0f, 0.0f, 1.0f}, // Purple
                        new float[] {1.0f, 1.0f, 0.0f}, // Red
                        new float[] {0.0f, 1.0f, 0.0f}, // Yellow
                        new float[] {1.0f, 1.0f, 0.0f}, // Black
                        new float[] {1.0f, 0.0f, 0.0f}  // White
                    };

                    // Draw the hexagon using triangles with specified colors
                    for (int k = 0; k < 6; k++)
                    {
                        glColor3fv(colors[k]); // Apply color to each triangle

                        glVertex2d(hexagonX, hexagonY);
                        glVertex2d(vertices[k][0], vertices[k][1]);
                        glVertex2d(vertices[(k + 1) % 6][0], vertices[(k + 1) % 6][1]);
                    }

                    glEnd();

                    // Adjust positions for new hexagons
                    hexagonX += hexagonSize * 1.5;
                    hexagonY -= hexagonSize * Math.Sqrt(3) * 0.5;
                }
            }
        }
    }
}
