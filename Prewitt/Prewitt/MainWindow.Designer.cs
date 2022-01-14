
namespace Prewitt
{
    partial class MainWindow
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
            this.PathTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.splitContainer4 = new System.Windows.Forms.SplitContainer();
            this.panel3 = new System.Windows.Forms.Panel();
            this.ElapsedTimeLabel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.splitContainer5 = new System.Windows.Forms.SplitContainer();
            this.CPPradioButton = new System.Windows.Forms.RadioButton();
            this.ASMradioButton = new System.Windows.Forms.RadioButton();
            this.GrayScaleCheckBox = new System.Windows.Forms.CheckBox();
            this.ThreadsTrackBar = new System.Windows.Forms.TrackBar();
            this.NThreadsLabel = new System.Windows.Forms.Label();
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
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer5)).BeginInit();
            this.splitContainer5.Panel1.SuspendLayout();
            this.splitContainer5.Panel2.SuspendLayout();
            this.splitContainer5.SuspendLayout();
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
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.splitContainer2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 497);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1011, 153);
            this.panel1.TabIndex = 0;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Cursor = System.Windows.Forms.Cursors.VSplit;
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.IsSplitterFixed = true;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.SelectPictureButton);
            this.splitContainer2.Panel1.Controls.Add(this.PathTextBox);
            this.splitContainer2.Panel1.Controls.Add(this.label1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.splitContainer3);
            this.splitContainer2.Size = new System.Drawing.Size(1007, 149);
            this.splitContainer2.SplitterDistance = 477;
            this.splitContainer2.TabIndex = 0;
            // 
            // SelectPictureButton
            // 
            this.SelectPictureButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SelectPictureButton.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.SelectPictureButton.Location = new System.Drawing.Point(0, 38);
            this.SelectPictureButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.SelectPictureButton.Name = "SelectPictureButton";
            this.SelectPictureButton.Size = new System.Drawing.Size(477, 111);
            this.SelectPictureButton.TabIndex = 2;
            this.SelectPictureButton.Text = "Select Picture";
            this.SelectPictureButton.UseVisualStyleBackColor = true;
            this.SelectPictureButton.Click += new System.EventHandler(this.SelectPictureButton_Click);
            // 
            // PathTextBox
            // 
            this.PathTextBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.PathTextBox.Location = new System.Drawing.Point(0, 15);
            this.PathTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.PathTextBox.Name = "PathTextBox";
            this.PathTextBox.ReadOnly = true;
            this.PathTextBox.Size = new System.Drawing.Size(477, 23);
            this.PathTextBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(477, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Selected Path";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Cursor = System.Windows.Forms.Cursors.HSplit;
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.IsSplitterFixed = true;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
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
            this.splitContainer3.Size = new System.Drawing.Size(526, 149);
            this.splitContainer3.SplitterDistance = 85;
            this.splitContainer3.SplitterWidth = 3;
            this.splitContainer3.TabIndex = 0;
            // 
            // splitContainer4
            // 
            this.splitContainer4.Cursor = System.Windows.Forms.Cursors.VSplit;
            this.splitContainer4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer4.IsSplitterFixed = true;
            this.splitContainer4.Location = new System.Drawing.Point(0, 0);
            this.splitContainer4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.splitContainer4.Name = "splitContainer4";
            // 
            // splitContainer4.Panel1
            // 
            this.splitContainer4.Panel1.Controls.Add(this.panel3);
            this.splitContainer4.Panel1.Controls.Add(this.panel2);
            this.splitContainer4.Panel1.Controls.Add(this.ThreadsTrackBar);
            // 
            // splitContainer4.Panel2
            // 
            this.splitContainer4.Panel2.Controls.Add(this.NThreadsLabel);
            this.splitContainer4.Panel2.Controls.Add(this.label2);
            this.splitContainer4.Size = new System.Drawing.Size(526, 85);
            this.splitContainer4.SplitterDistance = 411;
            this.splitContainer4.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.Add(this.ElapsedTimeLabel);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(281, 45);
            this.panel3.Margin = new System.Windows.Forms.Padding(2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(130, 40);
            this.panel3.TabIndex = 4;
            // 
            // ElapsedTimeLabel
            // 
            this.ElapsedTimeLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ElapsedTimeLabel.Location = new System.Drawing.Point(0, 15);
            this.ElapsedTimeLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.ElapsedTimeLabel.Name = "ElapsedTimeLabel";
            this.ElapsedTimeLabel.Size = new System.Drawing.Size(126, 21);
            this.ElapsedTimeLabel.TabIndex = 1;
            this.ElapsedTimeLabel.Text = "0";
            // 
            // label4
            // 
            this.label4.Dock = System.Windows.Forms.DockStyle.Top;
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(126, 15);
            this.label4.TabIndex = 0;
            this.label4.Text = "Elapsed Time";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.splitContainer5);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 45);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(281, 40);
            this.panel2.TabIndex = 3;
            // 
            // splitContainer5
            // 
            this.splitContainer5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer5.Cursor = System.Windows.Forms.Cursors.VSplit;
            this.splitContainer5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer5.IsSplitterFixed = true;
            this.splitContainer5.Location = new System.Drawing.Point(0, 0);
            this.splitContainer5.Name = "splitContainer5";
            // 
            // splitContainer5.Panel1
            // 
            this.splitContainer5.Panel1.Controls.Add(this.CPPradioButton);
            this.splitContainer5.Panel1.Controls.Add(this.ASMradioButton);
            // 
            // splitContainer5.Panel2
            // 
            this.splitContainer5.Panel2.Controls.Add(this.GrayScaleCheckBox);
            this.splitContainer5.Size = new System.Drawing.Size(281, 40);
            this.splitContainer5.SplitterDistance = 137;
            this.splitContainer5.TabIndex = 3;
            // 
            // CPPradioButton
            // 
            this.CPPradioButton.AutoSize = true;
            this.CPPradioButton.Location = new System.Drawing.Point(84, 14);
            this.CPPradioButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CPPradioButton.Name = "CPPradioButton";
            this.CPPradioButton.Size = new System.Drawing.Size(40, 19);
            this.CPPradioButton.TabIndex = 2;
            this.CPPradioButton.TabStop = true;
            this.CPPradioButton.Text = "C#";
            this.CPPradioButton.UseVisualStyleBackColor = true;
            // 
            // ASMradioButton
            // 
            this.ASMradioButton.AutoSize = true;
            this.ASMradioButton.Location = new System.Drawing.Point(16, 13);
            this.ASMradioButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ASMradioButton.Name = "ASMradioButton";
            this.ASMradioButton.Size = new System.Drawing.Size(50, 19);
            this.ASMradioButton.TabIndex = 1;
            this.ASMradioButton.TabStop = true;
            this.ASMradioButton.Text = "ASM";
            this.ASMradioButton.UseVisualStyleBackColor = true;
            // 
            // GrayScaleCheckBox
            // 
            this.GrayScaleCheckBox.AutoSize = true;
            this.GrayScaleCheckBox.Location = new System.Drawing.Point(12, 14);
            this.GrayScaleCheckBox.Name = "GrayScaleCheckBox";
            this.GrayScaleCheckBox.Size = new System.Drawing.Size(111, 19);
            this.GrayScaleCheckBox.TabIndex = 0;
            this.GrayScaleCheckBox.Text = "Apply GrayScale";
            this.GrayScaleCheckBox.UseVisualStyleBackColor = true;
            this.GrayScaleCheckBox.CheckedChanged += new System.EventHandler(this.GrayScaleCheckBox_CheckedChanged);
            // 
            // ThreadsTrackBar
            // 
            this.ThreadsTrackBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.ThreadsTrackBar.LargeChange = 1;
            this.ThreadsTrackBar.Location = new System.Drawing.Point(0, 0);
            this.ThreadsTrackBar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ThreadsTrackBar.Maximum = 64;
            this.ThreadsTrackBar.Minimum = 8;
            this.ThreadsTrackBar.Name = "ThreadsTrackBar";
            this.ThreadsTrackBar.Size = new System.Drawing.Size(411, 45);
            this.ThreadsTrackBar.TabIndex = 0;
            this.ThreadsTrackBar.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.ThreadsTrackBar.Value = 8;
            this.ThreadsTrackBar.ValueChanged += new System.EventHandler(this.ThreadsTrackBar_ValueChanged);
            // 
            // NThreadsLabel
            // 
            this.NThreadsLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.NThreadsLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.NThreadsLabel.Location = new System.Drawing.Point(0, 19);
            this.NThreadsLabel.Name = "NThreadsLabel";
            this.NThreadsLabel.Size = new System.Drawing.Size(111, 66);
            this.NThreadsLabel.TabIndex = 1;
            this.NThreadsLabel.Text = "0";
            this.NThreadsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 19);
            this.label2.TabIndex = 0;
            this.label2.Text = "Selected Threads:";
            // 
            // PutOnTheFilterButton
            // 
            this.PutOnTheFilterButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PutOnTheFilterButton.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.PutOnTheFilterButton.Location = new System.Drawing.Point(0, 0);
            this.PutOnTheFilterButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.PutOnTheFilterButton.Name = "PutOnTheFilterButton";
            this.PutOnTheFilterButton.Size = new System.Drawing.Size(526, 61);
            this.PutOnTheFilterButton.TabIndex = 0;
            this.PutOnTheFilterButton.Text = "Put on the filter";
            this.PutOnTheFilterButton.UseVisualStyleBackColor = true;
            this.PutOnTheFilterButton.Click += new System.EventHandler(this.PutOnTheFilterButton_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer1.Cursor = System.Windows.Forms.Cursors.NoMove2D;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.InputImage);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.OutputImage);
            this.splitContainer1.Size = new System.Drawing.Size(1011, 497);
            this.splitContainer1.SplitterDistance = 479;
            this.splitContainer1.TabIndex = 1;
            // 
            // InputImage
            // 
            this.InputImage.BackColor = System.Drawing.SystemColors.Window;
            this.InputImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.InputImage.Location = new System.Drawing.Point(0, 0);
            this.InputImage.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.InputImage.Name = "InputImage";
            this.InputImage.Padding = new System.Windows.Forms.Padding(5);
            this.InputImage.Size = new System.Drawing.Size(475, 493);
            this.InputImage.TabIndex = 0;
            this.InputImage.TabStop = false;
            // 
            // OutputImage
            // 
            this.OutputImage.BackColor = System.Drawing.SystemColors.Window;
            this.OutputImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OutputImage.Location = new System.Drawing.Point(0, 0);
            this.OutputImage.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.OutputImage.Name = "OutputImage";
            this.OutputImage.Padding = new System.Windows.Forms.Padding(5);
            this.OutputImage.Size = new System.Drawing.Size(524, 493);
            this.OutputImage.TabIndex = 0;
            this.OutputImage.TabStop = false;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1011, 650);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "MainWindow";
            this.Text = "Prewitt Filter";
            this.Load += new System.EventHandler(this.MainWindow_Load);
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
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.splitContainer5.Panel1.ResumeLayout(false);
            this.splitContainer5.Panel1.PerformLayout();
            this.splitContainer5.Panel2.ResumeLayout(false);
            this.splitContainer5.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer5)).EndInit();
            this.splitContainer5.ResumeLayout(false);
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
        private System.Windows.Forms.TextBox PathTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button SelectPictureButton;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.SplitContainer splitContainer4;
        private System.Windows.Forms.TrackBar ThreadsTrackBar;
        private System.Windows.Forms.Label NThreadsLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button PutOnTheFilterButton;
        private System.Windows.Forms.RadioButton CPPradioButton;
        private System.Windows.Forms.RadioButton ASMradioButton;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label ElapsedTimeLabel;
        private System.Windows.Forms.SplitContainer splitContainer5;
        private System.Windows.Forms.CheckBox GrayScaleCheckBox;
    }
}

