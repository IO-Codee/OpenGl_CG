using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Task04
{
    public partial class RenderControl
    {
        public class Figures
        {
            public void ParametricCircle(double radius)
            {
                glColor3f(255f, 0, 0);
                glBegin(GL_LINE_LOOP);

                int segments = 100; // Number of segments
                for (int i = 0; i <= segments; i++)
                {
                    double t = 2.0 * Math.PI * i / segments; // Angle in radians
                    double x = radius * Math.Cos(t);
                    double y = radius * Math.Sin(t);
                    glVertex2d(x, y);
                }

                glEnd();
            }

            // Draw Explicit Hyperbola
            public void ExplicitHyperbola(double a, double b)
            {
                glColor3f(255f, 0, 0);
                glBegin(GL_LINE_STRIP);

                double range = 2.0; // Range for x-values
                int segments = 100;
                for (int i = 0; i <= segments; i++)
                {
                    double x = range * (i - segments / 2.0) / (segments / 2.0);
                    double y = b * Math.Sqrt((x * x) / (a * a) - 1);
                    glVertex2d(x, y);
                }

                glEnd();
            }
            public void SearchPoint(double a, double b, double StartX, double EndX, double StartY, double EndY, bool isChoosed)
            {
                glPointSize(5.0f);
                glColor3f(0.0f, 1.0f, 1.0f);
                glBegin(GL_POINTS);
                double dx = EndX - StartX;
                double dy = EndY - StartY;
                if (!isChoosed)
                {
                    double A = dx * dx + dy * dy;
                    double B = 2 * (StartX * dx + StartY * dy);
                    double C = StartX * StartX + StartY * StartY - a * a;

                    double discriminant = B * B - 4 * A * C;

                    if (discriminant >= 0)
                    {
                        double sqrtD = Math.Sqrt(discriminant);
                        double t1 = (-B + sqrtD) / (2 * A);
                        double t2 = (-B - sqrtD) / (2 * A);
                        if (t1 >= 0 && t1 <= 1)
                        {
                            double x1 = StartX + t1 * dx;
                            double y1 = StartY + t1 * dy;
                            glVertex2d(x1, y1);
                        }
                        if (t2 >= 0 && t2 <= 1)
                        {
                            double x2 = StartX + t2 * dx;
                            double y2 = StartY + t2 * dy;
                            glVertex2d(x2, y2);
                        }
                    }
                }
                else
                {
                    double A = a * dx * dx;
                    double B = 2 * a * dx * StartX - dy;
                    double C = a * StartX * StartX - StartY;

                    double discriminant = B * B - 4 * A * C;

                    if (discriminant >= 0)
                    {
                        double sqrtD = Math.Sqrt(discriminant);
                        double t1 = (-B + sqrtD) / (2 * A);
                        double t2 = (-B - sqrtD) / (2 * A);

                        if (t1 >= 0 && t1 <= 1)
                        {
                            double x1 = StartX + t1 * dx;
                            double y1 = StartY + t1 * dy;
                            glVertex2d(x1, y1);
                        }

                        if (t2 >= 0 && t2 <= 1)
                        {
                            double x2 = StartX + t2 * dx;
                            double y2 = StartY + t2 * dy;
                            glVertex2d(x2, y2);
                        }
                    }
                }
                glEnd();
            }
            public void Circle(double radius)
            {
                glColor3f(1.0f, 0.5f, 1.0f);
                glBegin(GL_LINE_LOOP);

                int segments = 100; 
                for (int i = 0; i <= segments; i++)
                {
                    double theta = 2.0 * Math.PI * i / segments; // Кут в радіанах
                    double x = radius * Math.Cos(theta);
                    double y = radius * Math.Sin(theta);
                    glVertex2d(x, y);
                }

                glEnd();
            }
            public void ParametricPorabola(double a)
            {
                glColor3f(1.0f, 0.0f, 0.0f);
                glBegin(GL_LINE_STRIP);

                int segments = 100;
                double range = 2.0; // Діапазон значень для параметру t
                for (int i = -segments; i <= segments; i++)
                {
                    double t = i * range / segments; // Параметр t
                    double x = t;
                    double y = a * t * t;
                    glVertex2d(x, y);
                }

                glEnd();
            }
            public double FindMax(double a, double b, bool isChoosed)
            {
                double maxX, maxY;

                if (!isChoosed)
                {
                    maxX = Math.Abs(a);
                    maxY = Math.Abs(b);
                }
                else
                {
                    double range = 2.0;
                    maxX = range;
                    maxY = a * range * range;
                    maxY = maxY < 0 ? -maxY : maxY;

                }
                return Math.Max(maxX, maxY) + 0.2;
            }
            public void DrawGrid(double minX, double maxX, double minY, double maxY)
            {
                glLineWidth(1.0f);
                glColor3ub(200, 200, 200);
                glBegin(GL_LINES);
                for (double i = minX; i <= maxX; i += maxX / 10)
                {
                    glVertex2d(i, minY);
                    glVertex2d(i, maxY);
                }
                for (double j = minY; j <= maxY; j += maxY / 10)
                {
                    glVertex2d(minX, j);
                    glVertex2d(maxX, j);
                }
                glEnd();
            }
            public void DrawCoordinateGrid(double minX, double maxX, double YMin, double YMax)
            {
                glLineWidth(2.0f);
                glBegin(GL_LINES);
                glColor3ub(0, 0, 0);
                glVertex2d(minX, 0);
                glVertex2d(maxX, 0);
                glVertex2d(0, YMin);
                glVertex2d(0, YMax);
                glEnd();
                glLineWidth(1.0f);
            }
            public void DrawLineWait(double minX, double maxX, double YMin, double YMax)
            {
                glColor3f(0.5f, 0.5f, 0.5f);
                glLineWidth(1.4f);
                glPointSize(3.0f);
                glBegin(GL_POINTS);
                glVertex2d(minX, YMin);
                glVertex2d(maxX, YMax);
                glEnd();
                glBegin(GL_LINES);
                glVertex2d(minX, YMin);
                glVertex2d(maxX, YMax);
                glEnd();
            }
            public void DrawLine(double minX, double maxX, double YMin, double YMax)
            {
                glColor3f(0.0f, 0.0f, 0.0f);
                glLineWidth(1.7f);
                glBegin(GL_LINES);
                glVertex2d(minX, YMin);
                glVertex2d(maxX, YMax);
                glEnd();
            }
        }
    }
}
