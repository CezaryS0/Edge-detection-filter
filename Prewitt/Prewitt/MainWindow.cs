using System;
using System.Diagnostics;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
namespace Prewitt
{
    public partial class MainWindow : Form
    {
        private readonly Model model;
        private Thread MainThread;
        private int NThreads;
        private bool imageLoaded = false;
        public MainWindow()
        {
            InitializeComponent();
            model = new Model();
            this.CenterToScreen();
        }
        private void changeCursor(Control controls)
        {
            foreach (Control c in controls.Controls)
            {
                changeCursor(c);
                c.Cursor = Cursors.Default;

            }
        }
        private void SetOutputImage(Bitmap image)
        {
            this.Invoke((MethodInvoker)delegate
            {
                OutputImage.Image = image;
                OutputImage.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            );
        }
        private void SetElapsedTime(long t)
        {
            this.Invoke((MethodInvoker)delegate
            {
                ElapsedTimeLabel.Text = t.ToString() + " ms";
            });
        }
        public void Thread_T()
        {
            Prewitt prewitt = new Prewitt();
            var stopwatch = new Stopwatch();

            model.setUseASM(ASMradioButton.Checked);
            stopwatch.Start();
            SetOutputImage(prewitt.PrewittFilter(model));
            stopwatch.Stop();
            SetElapsedTime(stopwatch.ElapsedMilliseconds);
        }

        private void SelectPictureButton_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    imageLoaded = false;
                    try
                    {
                        model.setPath(openFileDialog.FileName);
                        PathTextBox.Text = openFileDialog.FileName;
                        InputImage.Image = model.ReturnLoadedImage();
                        InputImage.SizeMode = PictureBoxSizeMode.StretchImage;
                        imageLoaded = true;
                    }
                    catch
                    {
                        MessageBox.Show(this, "Could not open supplied image!", "Error!");
                    }
                }
            }
        }

        private void PutOnTheFilterButton_Click(object sender, EventArgs e)
        {
            if (imageLoaded)
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

        private void GrayScaleCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            model.setGrayScale(GrayScaleCheckBox.Checked);
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            //Ustawienie wątków na ilość dostępnych wątków w procesore
            this.MinimumSize = this.Size;
            ThreadsTrackBar.Minimum = 1;
            ThreadsTrackBar.Maximum = 64;
            if (Environment.ProcessorCount > 64)
            {
                NThreads = 64;
            }
            else
                NThreads = Environment.ProcessorCount;
            NThreadsLabel.Text = NThreads.ToString();
            ThreadsTrackBar.Value = NThreads;
            changeCursor(this);
        }
    }
}
