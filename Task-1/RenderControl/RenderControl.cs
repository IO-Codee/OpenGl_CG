using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Design;
using System.Linq;
using System.Runtime.InteropServices;
using static Task_1.OpenGL;

namespace Task_1
{
    public partial class RenderControl : OpenGL
    {
        public RenderControl()
        {
            InitializeComponent();
            Render += OnRender; // Підключаємо метод рендерингу до події Render


        }

        private void OnRender(object sender, EventArgs e)
        {
            float x1 = -4f;
            float x2 = 1.5f;
            float y1 = -1f;
            float y2 = 2f;
            // Очищення екрану
            glClear(GL_COLOR_BUFFER_BIT);
            glClearColor(0f, 0f, 0f, 1.0f); // Midnight Blue background


            // Встановлення системи координат
            glLoadIdentity();
            glViewport(0, 0, Width, Height);
            glOrtho(x1, x2, y1, y2, -10, 10); // Межі системи координат згідно із завданням (+0.5 щоб було видно координати)



            // Малювання елементів
            DrawAxes();
            DrawGrid();
            DrawFigure();
            DrawPoints();


        }

        private void DrawFigure()
        {
            glLineWidth(5); // Товщина ліній

            glBegin(GL_LINE_LOOP);
            glColor(Color.LimeGreen); // Синій контур

            // Вершини фігури
/*
            glVertex2d(-3.5, 0);
            glVertex2d(-3.5, 1);
            glVertex2d(-2.5, 1.5);
            glVertex2d(-2, 0.5);
            glVertex2d(-2, -0.5);
*/
            double[][] points = new double[][] {
                new double[] { -3.5, 0 },
                new double[] { -3.5, 1 },
                new double[] { -2.5, 1.5 },
                new double[] { -2, 0.5 },
                new double[] { -2, -0.5 },
                };
            foreach (var vertex in points) {
                glVertex2d(vertex[0], vertex[1]); 
            }

            glEnd(); // Завершуємо малювання
        }

        private void DrawPoints()
        {
            glPointSize(8); // Розмір точок
            glBegin(GL_POINTS);
            glColor(Color.GreenYellow);

            // Координати точок
            double[][] points = new double[][]
            {
                new double[] {-3.5, 0},
                new double[] {-3.5, 1 },
                new double[] { -2.5, 1.5 },
                new double[] {-2, 0.5 },
                new double[] { -2, -0.5 },
            };

            // Малюємо точки
            foreach (var point in points)
            {
                glVertex2d(point[0] + 3, point[1]);
            }
            glEnd();

            // Підписуємо координати
            foreach (var point in points)
            {
                string label = $"({point[0]}, {point[1]})";
                DrawText(label, point[0] + 0.1, point[1] + 0.1);
                string label2 = $"({point[0] + 3}, {point[1]})";
                DrawText(label2, point[0] + 3 + 0.1, point[1] + 0.1);
            }
        }

        private void DrawAxes()
        {
            float x1 = -3.5f;
            float x2 = 1f;
            float y1 = -0.5f;
            float y2 = 1.5f;
            glLineWidth(3);
            glBegin(GL_LINES);
            glColor(Color.WhiteSmoke);

            // Вісь X
            glVertex2d(x1, 0.0);
            glVertex2d(x2, 0.0);

            // Вісь Y
            glVertex2d(0.0, y1);
            glVertex2d(0.0, y2);

            glEnd();
        }

        private void DrawGrid()
        {
            float x1 = -3.5f;
            float x2 = 1f;
            float y1 = -0.5f;
            float y2 = 1.5f;
            glLineWidth(1);
            glEnable(GL_LINE_STIPPLE);
            glLineStipple(1, 0xAAAA);

            glBegin(GL_LINES);
            glColor(Color.White);

            // Горизонтальні лінії
            for (double y = y1; y <= y2; y += 0.5)
            {
                glVertex2d(x1, y);
                glVertex2d(x2, y);
            }

            // Вертикальні лінії
            for (double x = x1; x <= x2; x += 0.5)
            {
                glVertex2d(x, y1);
                glVertex2d(x, y2);
            }

            glEnd();
            glDisable(GL_LINE_STIPPLE);
        }


    }
}
