using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Threading;
namespace Prewitt
{
    public partial class Form1 : Form
    {
        Model model;
        Thread MainThread;
        int NThreads=8;
        Filter filter1;
        public Form1()
        {
            InitializeComponent();
            this.MinimumSize = this.Size;
        }
        public void SetOutputImage(Bitmap image)
        {
            this.Invoke((MethodInvoker)delegate
            {
                OutputImage.Image = image;
            }
            );
        }
        public void Thread_T()
        {
            Filter filter = new Filter(model);
            if(ASMradioButton.Checked==true)
            {
                SetOutputImage(filter.PutOnTheFilterASM());
            }
            else if(CPPradioButton.Checked==true)
            {
                SetOutputImage(filter.PutOnTheFilterCPP());
            }
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void SelectPictureButton_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
               // openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    model = new Model(openFileDialog.FileName);
                    PathTextBox.Text = openFileDialog.FileName;
                    InputImage.Image = model.ReturnLoadedImage();
                }
            }
        }

        private void PutOnTheFilterButton_Click(object sender, EventArgs e)
        {
            if (model != null)
            {
                model.SetNumberOfThreads(NThreads);
                MainThread = new Thread(Thread_T);
                MainThread.IsBackground = true;
                MainThread.Start();
            }
            filter1 = new Filter(model);
            Bitmap img = model.ReturnLoadedImage();
            OutputImage.Image = filter1.PutOnTheFilterCSharp(img);
        }

        private void ThreadsTrackBar_ValueChanged(object sender, EventArgs e)
        {
            var trackbar = sender as TrackBar;
            NThreads = trackbar.Value;
        }
    }
}
