
namespace Prewitt
{
    partial class Form1
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.SelectPictureButton = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.splitContainer4 = new System.Windows.Forms.SplitContainer();
            this.CPPradioButton = new System.Windows.Forms.RadioButton();
            this.ASMradioButton = new System.Windows.Forms.RadioButton();
            this.ThreadsTrackBar = new System.Windows.Forms.TrackBar();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.PutOnTheFilterButton = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.InputImage = new System.Windows.Forms.PictureBox();
            this.OutputImage = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).BeginInit();
            this.splitContainer4.Panel1.SuspendLayout();
            this.splitContainer4.Panel2.SuspendLayout();
            this.splitContainer4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ThreadsTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.InputImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OutputImage)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.splitContainer2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 508);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1167, 153);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // splitContainer2
            // 
            this.splitContainer2.Cursor = System.Windows.Forms.Cursors.VSplit;
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.IsSplitterFixed = true;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.SelectPictureButton);
            this.splitContainer2.Panel1.Controls.Add(this.textBox1);
            this.splitContainer2.Panel1.Controls.Add(this.label1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.splitContainer3);
            this.splitContainer2.Size = new System.Drawing.Size(1167, 153);
            this.splitContainer2.SplitterDistance = 556;
            this.splitContainer2.TabIndex = 0;
            // 
            // SelectPictureButton
            // 
            this.SelectPictureButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SelectPictureButton.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.SelectPictureButton.Location = new System.Drawing.Point(0, 47);
            this.SelectPictureButton.Name = "SelectPictureButton";
            this.SelectPictureButton.Size = new System.Drawing.Size(556, 106);
            this.SelectPictureButton.TabIndex = 2;
            this.SelectPictureButton.Text = "Select Picture";
            this.SelectPictureButton.UseVisualStyleBackColor = true;
            this.SelectPictureButton.Click += new System.EventHandler(this.SelectPictureButton_Click);
            // 
            // textBox1
            // 
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.textBox1.Location = new System.Drawing.Point(0, 20);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(556, 27);
            this.textBox1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(556, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Selected Path";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Cursor = System.Windows.Forms.Cursors.HSplit;
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.splitContainer4);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.PutOnTheFilterButton);
            this.splitContainer3.Size = new System.Drawing.Size(607, 153);
            this.splitContainer3.SplitterDistance = 103;
            this.splitContainer3.TabIndex = 0;
            // 
            // splitContainer4
            // 
            this.splitContainer4.Cursor = System.Windows.Forms.Cursors.VSplit;
            this.splitContainer4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer4.Location = new System.Drawing.Point(0, 0);
            this.splitContainer4.Name = "splitContainer4";
            // 
            // splitContainer4.Panel1
            // 
            this.splitContainer4.Panel1.Controls.Add(this.CPPradioButton);
            this.splitContainer4.Panel1.Controls.Add(this.ASMradioButton);
            this.splitContainer4.Panel1.Controls.Add(this.ThreadsTrackBar);
            // 
            // splitContainer4.Panel2
            // 
            this.splitContainer4.Panel2.Controls.Add(this.label3);
            this.splitContainer4.Panel2.Controls.Add(this.label2);
            this.splitContainer4.Size = new System.Drawing.Size(607, 103);
            this.splitContainer4.SplitterDistance = 478;
            this.splitContainer4.TabIndex = 0;
            // 
            // CPPradioButton
            // 
            this.CPPradioButton.AutoSize = true;
            this.CPPradioButton.Location = new System.Drawing.Point(216, 62);
            this.CPPradioButton.Name = "CPPradioButton";
            this.CPPradioButton.Size = new System.Drawing.Size(59, 24);
            this.CPPradioButton.TabIndex = 2;
            this.CPPradioButton.TabStop = true;
            this.CPPradioButton.Text = "C++";
            this.CPPradioButton.UseVisualStyleBackColor = true;
            // 
            // ASMradioButton
            // 
            this.ASMradioButton.AutoSize = true;
            this.ASMradioButton.Location = new System.Drawing.Point(35, 62);
            this.ASMradioButton.Name = "ASMradioButton";
            this.ASMradioButton.Size = new System.Drawing.Size(61, 24);
            this.ASMradioButton.TabIndex = 1;
            this.ASMradioButton.TabStop = true;
            this.ASMradioButton.Text = "ASM";
            this.ASMradioButton.UseVisualStyleBackColor = true;
            // 
            // ThreadsTrackBar
            // 
            this.ThreadsTrackBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.ThreadsTrackBar.LargeChange = 1;
            this.ThreadsTrackBar.Location = new System.Drawing.Point(0, 0);
            this.ThreadsTrackBar.Maximum = 64;
            this.ThreadsTrackBar.Minimum = 8;
            this.ThreadsTrackBar.Name = "ThreadsTrackBar";
            this.ThreadsTrackBar.Size = new System.Drawing.Size(478, 56);
            this.ThreadsTrackBar.TabIndex = 0;
            this.ThreadsTrackBar.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.ThreadsTrackBar.Value = 8;
            this.ThreadsTrackBar.ValueChanged += new System.EventHandler(this.ThreadsTrackBar_ValueChanged);
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(0, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(125, 78);
            this.label3.TabIndex = 1;
            this.label3.Text = "8";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(125, 25);
            this.label2.TabIndex = 0;
            this.label2.Text = "Selected Threads:";
            // 
            // PutOnTheFilterButton
            // 
            this.PutOnTheFilterButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PutOnTheFilterButton.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.PutOnTheFilterButton.Location = new System.Drawing.Point(0, 0);
            this.PutOnTheFilterButton.Name = "PutOnTheFilterButton";
            this.PutOnTheFilterButton.Size = new System.Drawing.Size(607, 46);
            this.PutOnTheFilterButton.TabIndex = 0;
            this.PutOnTheFilterButton.Text = "Put on the filter";
            this.PutOnTheFilterButton.UseVisualStyleBackColor = true;
            this.PutOnTheFilterButton.Click += new System.EventHandler(this.PutOnTheFilterButton_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Cursor = System.Windows.Forms.Cursors.VSplit;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.InputImage);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.OutputImage);
            this.splitContainer1.Size = new System.Drawing.Size(1167, 508);
            this.splitContainer1.SplitterDistance = 558;
            this.splitContainer1.TabIndex = 1;
            // 
            // InputImage
            // 
            this.InputImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.InputImage.Location = new System.Drawing.Point(0, 0);
            this.InputImage.Name = "InputImage";
            this.InputImage.Size = new System.Drawing.Size(558, 508);
            this.InputImage.TabIndex = 0;
            this.InputImage.TabStop = false;
            // 
            // OutputImage
            // 
            this.OutputImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OutputImage.Location = new System.Drawing.Point(0, 0);
            this.OutputImage.Name = "OutputImage";
            this.OutputImage.Size = new System.Drawing.Size(605, 508);
            this.OutputImage.TabIndex = 0;
            this.OutputImage.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1167, 661);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.Text = "Prewitt Filter";
            this.panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.splitContainer4.Panel1.ResumeLayout(false);
            this.splitContainer4.Panel1.PerformLayout();
            this.splitContainer4.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).EndInit();
            this.splitContainer4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ThreadsTrackBar)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.InputImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OutputImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.PictureBox InputImage;
        private System.Windows.Forms.PictureBox OutputImage;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button SelectPictureButton;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.SplitContainer splitContainer4;
        private System.Windows.Forms.TrackBar ThreadsTrackBar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button PutOnTheFilterButton;
        private System.Windows.Forms.RadioButton CPPradioButton;
        private System.Windows.Forms.RadioButton ASMradioButton;
    }
}

