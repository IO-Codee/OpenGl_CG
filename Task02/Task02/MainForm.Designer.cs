
namespace Task_2
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
            fillButton = new System.Windows.Forms.RadioButton();
            lineButton = new System.Windows.Forms.RadioButton();
            pointButton = new System.Windows.Forms.RadioButton();
            numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            renderControl1 = new RenderControl();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).BeginInit();
            SuspendLayout();
            // 
            // fillButton
            // 
            fillButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            fillButton.AutoSize = true;
            fillButton.Location = new System.Drawing.Point(583, 328);
            fillButton.Name = "fillButton";
            fillButton.Size = new System.Drawing.Size(92, 24);
            fillButton.TabIndex = 1;
            fillButton.TabStop = true;
            fillButton.Text = "Fill mode";
            fillButton.UseVisualStyleBackColor = true;
            fillButton.CheckedChanged += fillButton_CheckedChanged;
            // 
            // lineButton
            // 
            lineButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            lineButton.AutoSize = true;
            lineButton.Location = new System.Drawing.Point(583, 358);
            lineButton.Name = "lineButton";
            lineButton.Size = new System.Drawing.Size(100, 24);
            lineButton.TabIndex = 2;
            lineButton.TabStop = true;
            lineButton.Text = "Line mode";
            lineButton.UseVisualStyleBackColor = true;
            lineButton.CheckedChanged += lineButton_CheckedChanged;
            // 
            // pointButton
            // 
            pointButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            pointButton.AutoSize = true;
            pointButton.Location = new System.Drawing.Point(583, 388);
            pointButton.Name = "pointButton";
            pointButton.Size = new System.Drawing.Size(106, 24);
            pointButton.TabIndex = 3;
            pointButton.TabStop = true;
            pointButton.Text = "Point mode";
            pointButton.UseVisualStyleBackColor = true;
            pointButton.CheckedChanged += pointButton_CheckedChanged;
            // 
            // numericUpDown1
            // 
            numericUpDown1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            numericUpDown1.Location = new System.Drawing.Point(649, 57);
            numericUpDown1.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new System.Drawing.Size(52, 27);
            numericUpDown1.TabIndex = 4;
            numericUpDown1.Value = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDown1.ValueChanged += numericUpDown1_ValueChanged;
            // 
            // numericUpDown2
            // 
            numericUpDown2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            numericUpDown2.Location = new System.Drawing.Point(649, 90);
            numericUpDown2.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDown2.Name = "numericUpDown2";
            numericUpDown2.Size = new System.Drawing.Size(52, 27);
            numericUpDown2.TabIndex = 4;
            numericUpDown2.Value = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDown2.ValueChanged += numericUpDown2_ValueChanged;
            // 
            // label1
            // 
            label1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(598, 20);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(77, 20);
            label1.TabIndex = 5;
            label1.Text = "Tile count:";
            // 
            // label2
            // 
            label2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(566, 59);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(76, 20);
            label2.TabIndex = 5;
            label2.Text = "horizontal";
            // 
            // label3
            // 
            label3.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(566, 92);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(57, 20);
            label3.TabIndex = 5;
            label3.Text = "vertical";
            // 
            // renderControl1
            // 
            renderControl1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            renderControl1.BackColor = System.Drawing.Color.SlateGray;
            renderControl1.ForeColor = System.Drawing.Color.White;
            renderControl1.Location = new System.Drawing.Point(12, 13);
            renderControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            renderControl1.Name = "renderControl1";
            renderControl1.Size = new System.Drawing.Size(540, 400);
            renderControl1.TabIndex = 0;
            renderControl1.TextCodePage = 65001;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(713, 432);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(numericUpDown2);
            Controls.Add(numericUpDown1);
            Controls.Add(pointButton);
            Controls.Add(lineButton);
            Controls.Add(fillButton);
            Controls.Add(renderControl1);
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            Name = "MainForm";
            Text = "Main Form";
            Load += MainForm_Load;
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.RadioButton fillButton;
        private System.Windows.Forms.RadioButton lineButton;
        private System.Windows.Forms.RadioButton pointButton;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.NumericUpDown numericUpDown2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private RenderControl renderControl1;
    }
}


