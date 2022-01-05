using System;
using System.Diagnostics;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
namespace Prewitt
{
    public partial class Form1 : Form
    {
        private Model model;
        private Thread MainThread;
        private int NThreads = 8;
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
                OutputImage.SizeMode = PictureBoxSizeMode.CenterImage;
            }
            );
        }
        public void SetElapsedTime(long t)
        {
            this.Invoke((MethodInvoker)delegate
            {
                ElapsedTimeLabel.Text = t.ToString() + " ms";
            }
           );
        }
        public void Thread_T()
        {
            Filter filter = new Filter(model);
            var stopwatch = new Stopwatch();

            if (ASMradioButton.Checked == true)
            {
                stopwatch.Start();
                SetOutputImage(filter.PutOnTheFilterASM(model.ReturnLoadedImage()));
                stopwatch.Stop();
                SetElapsedTime(stopwatch.ElapsedMilliseconds);
            }
            else if (CPPradioButton.Checked == true)
            {
                stopwatch.Start();
                SetOutputImage(filter.PutOnTheFilterCSharp(model.ReturnLoadedImage()));
                stopwatch.Stop();
                SetElapsedTime(stopwatch.ElapsedMilliseconds);
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
                    InputImage.SizeMode = PictureBoxSizeMode.CenterImage;
                }
            }
        }

        private void PutOnTheFilterButton_Click(object sender, EventArgs e)
        {
            if (model != null)
            {
                model.SetNumberOfThreads(NThreads);
                MainThread = new Thread(Thread_T)
                {
                    IsBackground = true
                };
                MainThread.Start();
            }
        }

        private void ThreadsTrackBar_ValueChanged(object sender, EventArgs e)
        {
            var trackbar = sender as TrackBar;
            NThreads = trackbar.Value;
            NThreadsLabel.Text = trackbar.Value.ToString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
