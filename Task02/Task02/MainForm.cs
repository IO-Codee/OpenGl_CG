using System;
using System.Windows.Forms;

namespace Task_2
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            fillButton.Checked = true;
        }

        private void fillButton_CheckedChanged(object sender, EventArgs e)
        {
            if (fillButton.Checked)
            {
                // Changed variable names for better clarity
                renderControl1.FillMode = true;
                renderControl1.LineMode = false;
                renderControl1.PointMode = false;
                renderControl1.Invalidate();
            }
        }

        private void lineButton_CheckedChanged(object sender, EventArgs e)
        {
            if (lineButton.Checked)
            {
                renderControl1.FillMode = false;
                renderControl1.LineMode = true;
                renderControl1.PointMode = false;
                renderControl1.Invalidate();
            }
        }

        private void pointButton_CheckedChanged(object sender, EventArgs e)
        {
            if (pointButton.Checked)
            {
                renderControl1.FillMode = false;
                renderControl1.LineMode = false;
                renderControl1.PointMode = true;
                renderControl1.Invalidate();
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            // Improved variable names for readability
            renderControl1.HexagonCount = Convert.ToInt32(((NumericUpDown)sender).Value);
            renderControl1.Invalidate();
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            renderControl1.RowCount = Convert.ToInt32(((NumericUpDown)sender).Value);
            renderControl1.Invalidate();
        }
    }
}
