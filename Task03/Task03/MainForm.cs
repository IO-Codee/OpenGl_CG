
using System;
using System.Windows.Forms;

namespace Task_3
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e) // for xmin
        {
            NumericUpDown numericUpDown = (NumericUpDown)sender;
            renderControl1.SetXMin(Convert.ToSingle(numericUpDown.Value));
            renderControl1.Invalidate();
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e) // for xmax
        {
            NumericUpDown numericUpDown = (NumericUpDown)sender;
            renderControl1.SetXMax(Convert.ToSingle(numericUpDown.Value));
            renderControl1.Invalidate();
        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e) // for points
        {
            NumericUpDown numericUpDown = (NumericUpDown)sender;
            renderControl1.SetPointCount(Convert.ToInt32(numericUpDown.Value));
            renderControl1.Invalidate();
        }

        private void numericUpDown5_ValueChanged(object sender, EventArgs e) // for ymin
        {
            NumericUpDown numericUpDown = (NumericUpDown)sender;
            renderControl1.SetYMin(Convert.ToSingle(numericUpDown.Value));
            renderControl1.Invalidate();
        }

        private void numericUpDown4_ValueChanged(object sender, EventArgs e) // for ymax
        {
            NumericUpDown numericUpDown = (NumericUpDown)sender;
            renderControl1.SetYMax(Convert.ToSingle(numericUpDown.Value));
            renderControl1.Invalidate();
        }
    }
}
