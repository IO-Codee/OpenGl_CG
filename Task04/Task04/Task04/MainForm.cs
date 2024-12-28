//MainForm.cs
using System;
using System.Windows.Forms;
using static Task04.OpenGL;


namespace Task04
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }
   
        private void ChosedCircle(object sender, System.EventArgs e)
        {
            renderControl1.figur = false; // Select parametric circle
            Coordinat2.Visible = false;  // Hide second parameter input
            renderControl1.Invalidate();
        }

        private void ChoseHyperbola(object sender, EventArgs e)
        {
            renderControl1.figur = true; // Select explicit hyperbola
            Coordinat2.Visible = true;  // Show second parameter input
            renderControl1.Invalidate();
        }

        private void Mouse_Click(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                double difference = Math.Max(renderControl1.ClientRectangle.Width, renderControl1.ClientRectangle.Height) - Math.Min(renderControl1.ClientRectangle.Width, renderControl1.ClientRectangle.Height);
                if (difference != 0)
                {
                    renderControl1.LineExist = renderControl1.ClientRectangle.Width > renderControl1.ClientRectangle.Height ?
                        difference / 2 < e.X && e.X < Math.Min(renderControl1.ClientRectangle.Width, renderControl1.ClientRectangle.Height) + difference / 2 :
                        difference / 2 < renderControl1.ClientRectangle.Height - e.Y && renderControl1.ClientRectangle.Height - e.Y < Math.Min(renderControl1.ClientRectangle.Width, renderControl1.ClientRectangle.Height) + difference / 2;
                    if (renderControl1.LineExist)
                    {
                        renderControl1.IsUp = false;
                        double xLength = renderControl1.ClientRectangle.Width > renderControl1.ClientRectangle.Height ?
                            renderControl1.ClientRectangle.Width / (double)renderControl1.ClientRectangle.Height :
                            1;
                        double yLength = renderControl1.ClientRectangle.Height > renderControl1.ClientRectangle.Width ?
                            renderControl1.ClientRectangle.Height / (double)renderControl1.ClientRectangle.Width :
                            1;
                        renderControl1.StartX = renderControl1.EndX = (renderControl1.Length * xLength) * ((e.X - (renderControl1.ClientRectangle.Width / 2.0)) / (double)(renderControl1.ClientRectangle.Width / 2.0));
                        renderControl1.StartY = renderControl1.EndY = (renderControl1.Length * yLength) * (((renderControl1.ClientRectangle.Height / 2.0) - e.Y) / (double)(renderControl1.ClientRectangle.Height / 2.0));
                    }
                    else
                    {
                        
                    }
                }
                else
                {
                    renderControl1.IsUp = false;
                    renderControl1.LineExist = true;
                    double xLength = renderControl1.ClientRectangle.Width > renderControl1.ClientRectangle.Height ?
                            renderControl1.ClientRectangle.Width / (double)renderControl1.ClientRectangle.Height :
                            1;
                    double yLength = renderControl1.ClientRectangle.Height > renderControl1.ClientRectangle.Width ?
                        renderControl1.ClientRectangle.Height / (double)renderControl1.ClientRectangle.Width :
                        1;
                    renderControl1.StartX = renderControl1.EndX = (renderControl1.Length * xLength) * ((e.X - (renderControl1.ClientRectangle.Width / 2.0)) / (double)(renderControl1.ClientRectangle.Width / 2.0));
                    renderControl1.StartY = renderControl1.EndY = (renderControl1.Length * yLength) * (((renderControl1.ClientRectangle.Height / 2.0) - e.Y) / (double)(renderControl1.ClientRectangle.Height / 2.0));
                }
            }
            renderControl1.Invalidate();
        }
        private void oCoordinat1(object sender, EventArgs e)
        {
            renderControl1.A = (double)Coordinat1.Value; 
            renderControl1.Invalidate();
        }

        private void oCoordinat2(object sender, EventArgs e)
        {
            renderControl1.B = (double)Coordinat2.Value; 
            renderControl1.Invalidate();
        }
        private void ReleaseTheMouse(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && renderControl1.LineExist)
            {
                double xLength = renderControl1.ClientRectangle.Width > renderControl1.ClientRectangle.Height ?
                            renderControl1.ClientRectangle.Width / (double)renderControl1.ClientRectangle.Height :
                            1;
                double yLength = renderControl1.ClientRectangle.Height > renderControl1.ClientRectangle.Width ?
                    renderControl1.ClientRectangle.Height / (double)renderControl1.ClientRectangle.Width :
                    1;
                renderControl1.EndX = (renderControl1.Length * xLength) * ((e.X - (renderControl1.ClientRectangle.Width / 2.0)) / (double)(renderControl1.ClientRectangle.Width / 2.0));
                renderControl1.EndY = (renderControl1.Length * yLength) * (((renderControl1.ClientRectangle.Height / 2.0) - e.Y) / (double)(renderControl1.ClientRectangle.Height / 2.0));
                renderControl1.IsUp = true;
                if (renderControl1.EndX == renderControl1.StartX && renderControl1.EndY == renderControl1.StartY)
                {
                    renderControl1.LineExist = false;
                  
                }
                else
                {
                    
                }
            }
            renderControl1.Invalidate();
        }
        private void Mouse_Movement(object sender, MouseEventArgs e)
        {
            if (renderControl1.LineExist)
            {
                if (!renderControl1.IsUp)
                {
                    double xLength = renderControl1.ClientRectangle.Width > renderControl1.ClientRectangle.Height ?
                            renderControl1.ClientRectangle.Width / (double)renderControl1.ClientRectangle.Height :
                            1;
                    double yLength = renderControl1.ClientRectangle.Height > renderControl1.ClientRectangle.Width ?
                        renderControl1.ClientRectangle.Height / (double)renderControl1.ClientRectangle.Width :
                        1;
                    renderControl1.EndX = (renderControl1.Length * xLength) * ((e.X - (renderControl1.ClientRectangle.Width / 2.0)) / (double)(renderControl1.ClientRectangle.Width / 2.0));
                    renderControl1.EndY = (renderControl1.Length * yLength) * (((renderControl1.ClientRectangle.Height / 2.0) - e.Y) / (double)(renderControl1.ClientRectangle.Height / 2.0));
                    renderControl1.Invalidate();
                }
            }
        }
    }
}