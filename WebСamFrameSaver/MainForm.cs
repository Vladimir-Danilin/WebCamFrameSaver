using AForge.Controls;
using AForge.Imaging.Filters;
using AForge.Video.DirectShow;
using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;


namespace WebСamFrameSaver
{
    public partial class MainForm : Form
    {
        private VideoCaptureDevice videoCaptureSource = null;
        private FilterInfoCollection videoDevices;

        private int saveFrameCounter;
        private double currentFps;
        private string currentResolution;
        private DateTime lastFrameTime;
        private readonly Timer uiUpdateTimer;
        private string savePath;

        public MainForm()
        {
            InitializeComponent();
            videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            comboboxCameraDevices.Items.Clear();
            foreach (FilterInfo i in videoDevices) comboboxCameraDevices.Items.Add(i.Name);
            comboboxCameraDevices.SelectedIndex = 0;

            uiUpdateTimer = new Timer { Interval = 100 };
            uiUpdateTimer.Tick += (s, e) => { labelFps.Text = $"FPS: {Math.Round(currentFps)}"; };
            uiUpdateTimer.Start();
        }

        private void buttonPlay_Click(object sender, EventArgs e)
        {
            videoCaptureSource = null;
            videoSourcePlayer.SignalToStop();
            videoSourcePlayer.WaitForStop();

            videoCaptureSource = new VideoCaptureDevice(videoDevices[comboboxCameraDevices.SelectedIndex].MonikerString);
            videoSourcePlayer.VideoSource = videoCaptureSource;
            videoSourcePlayer.Start();

            var resolution = videoCaptureSource.VideoCapabilities
            .OrderByDescending(vc => vc.FrameSize.Width * vc.FrameSize.Height)
            .First();
            currentResolution = $"{resolution.FrameSize.Width}x{resolution.FrameSize.Height}";
            labelResolution.Text = $"Resolution: {currentResolution}";

            FormBorderStyle = FormBorderStyle.Sizable;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (savePath != null)
                for (int i = saveFrameCounter; ; i++)
                {
                    string fullPath = Path.Combine(savePath, $"SaveFrame{i}.bmp");

                    if (!File.Exists(fullPath))
                    {
                        if (videoSourcePlayer.IsRunning)
                            videoSourcePlayer.GetCurrentVideoFrame().Save(fullPath);
                        else
                            MessageBox.Show($"Failed to save {fullPath}");
                        saveFrameCounter = i;
                        return;
                    }
                }
            else
                MessageBox.Show("Select directory");
        }

        private void buttonChangeDirectory_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            if (folderBrowserDialog.ShowDialog() == DialogResult.Cancel | File.Exists(folderBrowserDialog.SelectedPath))
                MessageBox.Show("Unacceptable path");
            else
            {
                saveFrameCounter = 1;
                savePath = folderBrowserDialog.SelectedPath;
            }
        }

        private void videoSourcePlayer_NewFrame(object sender, ref Bitmap image)
        {
            using (Bitmap frame = image.Clone() as Bitmap)
            {
                if (frame == null) return;

                Grayscale grayscaleFilter = new Grayscale(0.2126, 0.7152, 0.0722);
                var grayFrame = grayscaleFilter.Apply(frame);
                image = grayFrame;

                DateTime currentTime = DateTime.Now;
                if (lastFrameTime != DateTime.MinValue) 
                    currentFps = 1000f / (currentTime - lastFrameTime).TotalMilliseconds;

                lastFrameTime = currentTime;
            }
        }

        private void comboboxCameraDevices_SelectedIndexChanged(object sender, EventArgs e)
        {
            videoSourcePlayer.SignalToStop();
            videoSourcePlayer.WaitForStop();
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            if (FormBorderStyle == FormBorderStyle.Sizable)
            {
                int resizeableWidth = Width - (videoSourcePlayer.Location.X + buttonPlay.Width + buttonPlay.Margin.Horizontal + 40);
                int resizeableHeight = Height - videoSourcePlayer.Location.Y - 45;

                var resolution = videoCaptureSource.VideoCapabilities
                .OrderByDescending(vc => vc.FrameSize.Width * vc.FrameSize.Height)
                .First();
                float resolutionScale = (float)resolution.FrameSize.Width / resolution.FrameSize.Height;

                float formContainerResolution = (float)resizeableWidth / resizeableHeight;

                if (formContainerResolution > resolutionScale)
                {
                    videoSourcePlayer.Height = resizeableHeight;
                    videoSourcePlayer.Width = (int)(resizeableHeight * resolutionScale);
                }
                else
                {
                    videoSourcePlayer.Height = (int)(resizeableWidth / resolutionScale);
                    videoSourcePlayer.Width = resizeableWidth;
                }
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            videoSourcePlayer.SignalToStop();
            videoSourcePlayer.WaitForStop();
        }
    }
}
