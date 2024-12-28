
namespace Task04
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            renderControl1 = new RenderControl();
            Figures = new System.Windows.Forms.GroupBox();
            FigurePorabola = new System.Windows.Forms.RadioButton();
            FigureCircle = new System.Windows.Forms.RadioButton();
            Coordinat1 = new System.Windows.Forms.NumericUpDown();
            CoordinatsGroup = new System.Windows.Forms.GroupBox();
            Coordinat2 = new System.Windows.Forms.NumericUpDown();
            Figures.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)Coordinat1).BeginInit();
            CoordinatsGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)Coordinat2).BeginInit();
            SuspendLayout();
            // 
            // renderControl1
            // 
            renderControl1.A = 1D;
            renderControl1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            renderControl1.B = 0.7D;
            renderControl1.BackColor = System.Drawing.Color.LightSteelBlue;
            renderControl1.EndX = 0D;
            renderControl1.EndY = 0D;
            renderControl1.figur = false;
            renderControl1.ForeColor = System.Drawing.Color.White;
            renderControl1.IsUp = true;
            renderControl1.Length = 1.2D;
            renderControl1.LineExist = false;
            renderControl1.Location = new System.Drawing.Point(12, 12);
            renderControl1.Name = "renderControl1";
            renderControl1.Size = new System.Drawing.Size(469, 376);
            renderControl1.StartX = 0D;
            renderControl1.StartY = 0D;
            renderControl1.TabIndex = 0;
            renderControl1.TextCodePage = 1251;
            renderControl1.MouseDown += Mouse_Click;
            renderControl1.MouseMove += Mouse_Movement;
            renderControl1.MouseUp += ReleaseTheMouse;
            // 
            // Figures
            // 
            Figures.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            Figures.Controls.Add(FigurePorabola);
            Figures.Controls.Add(FigureCircle);
            Figures.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            Figures.Location = new System.Drawing.Point(487, 12);
            Figures.Name = "Figures";
            Figures.Size = new System.Drawing.Size(242, 91);
            Figures.TabIndex = 2;
            Figures.TabStop = false;
            Figures.Text = "Вибір фігури";
            // 
            // FigurePorabola
            // 
            FigurePorabola.AutoSize = true;
            FigurePorabola.Location = new System.Drawing.Point(11, 48);
            FigurePorabola.Name = "FigurePorabola";
            FigurePorabola.Size = new System.Drawing.Size(109, 19);
            FigurePorabola.TabIndex = 1;
            FigurePorabola.Text = "Гіпербола явне";
            FigurePorabola.UseVisualStyleBackColor = true;
            FigurePorabola.CheckedChanged += ChoseHyperbola;
            // 
            // FigureCircle
            // 
            FigureCircle.AutoSize = true;
            FigureCircle.Checked = true;
            FigureCircle.Location = new System.Drawing.Point(11, 23);
            FigureCircle.Name = "FigureCircle";
            FigureCircle.Size = new System.Drawing.Size(172, 19);
            FigureCircle.TabIndex = 0;
            FigureCircle.TabStop = true;
            FigureCircle.Text = "Окружність параметричне";
            FigureCircle.UseVisualStyleBackColor = true;
            FigureCircle.CheckedChanged += ChosedCircle;
            // 
            // Coordinat1
            // 
            Coordinat1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            Coordinat1.DecimalPlaces = 2;
            Coordinat1.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
            Coordinat1.Location = new System.Drawing.Point(11, 33);
            Coordinat1.Minimum = new decimal(new int[] { 100, 0, 0, int.MinValue });
            Coordinat1.Name = "Coordinat1";
            Coordinat1.Size = new System.Drawing.Size(78, 25);
            Coordinat1.TabIndex = 3;
            Coordinat1.Value = new decimal(new int[] { 2, 0, 0, 0 });
            Coordinat1.ValueChanged += oCoordinat1;
            // 
            // CoordinatsGroup
            // 
            CoordinatsGroup.Controls.Add(Coordinat2);
            CoordinatsGroup.Controls.Add(Coordinat1);
            CoordinatsGroup.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            CoordinatsGroup.Location = new System.Drawing.Point(487, 113);
            CoordinatsGroup.Name = "CoordinatsGroup";
            CoordinatsGroup.Size = new System.Drawing.Size(242, 104);
            CoordinatsGroup.TabIndex = 5;
            CoordinatsGroup.TabStop = false;
            CoordinatsGroup.Text = "Задання координат";
            // 
            // Coordinat2
            // 
            Coordinat2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            Coordinat2.DecimalPlaces = 2;
            Coordinat2.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
            Coordinat2.Location = new System.Drawing.Point(150, 33);
            Coordinat2.Minimum = new decimal(new int[] { 100, 0, 0, int.MinValue });
            Coordinat2.Name = "Coordinat2";
            Coordinat2.Size = new System.Drawing.Size(74, 25);
            Coordinat2.TabIndex = 4;
            Coordinat2.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // MainForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(742, 400);
            Controls.Add(CoordinatsGroup);
            Controls.Add(Figures);
            Controls.Add(renderControl1);
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Name = "MainForm";
            Text = "Main Form";
            Figures.ResumeLayout(false);
            Figures.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)Coordinat1).EndInit();
            CoordinatsGroup.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)Coordinat2).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private RenderControl renderControl1;
        private System.Windows.Forms.GroupBox Figures;
        private System.Windows.Forms.RadioButton FigureCircle;
        private System.Windows.Forms.RadioButton FigurePorabola;
        private System.Windows.Forms.NumericUpDown Coordinat1;
        private System.Windows.Forms.GroupBox CoordinatsGroup;
        private System.Windows.Forms.NumericUpDown Coordinat2;
    }
}

