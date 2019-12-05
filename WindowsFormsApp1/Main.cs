using System;
using System.Drawing;
using System.Windows.Forms;
using OpenCvSharp;
using OpenCvSharp.Extensions;
using System.Threading;

namespace WindowsFormsApp1
{
    public partial class Main : Form
    {
        // Create class-level accesible variables
        VideoCapture capture;
        Mat frame;
        Bitmap image;
        private Thread camera;
        bool isCameraRunning = false;
        int CameraDevice = 0;

        // Declare required methods
        private void CaptureCamera()
        {
            camera = new Thread(new ThreadStart(CaptureCameraCallback));
            camera.Start();
        }

        private void CaptureCameraCallback()
        {
            try
            {
                frame = new Mat();
                capture = new VideoCapture();
                capture.Open(CameraDevice);
                while (isCameraRunning)
                {
                    capture.Read(frame);
                    image = BitmapConverter.ToBitmap(frame);
                    captureFrame.Image = image;
                    image = null;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("No camera found on device", "Start Stream",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (streamBtn.InvokeRequired)
                {
                    streamBtn.Invoke(new MethodInvoker(delegate { streamBtn.Text = "Start"; }));
                }
            }
        }

        public Main()
        {
            InitializeComponent();
        }

        private void streamBtn_Click(object sender, EventArgs e)
        {
            if (streamBtn.Text.Equals("Start"))
            {
                CaptureCamera();
                streamBtn.Text = "Stop";
                isCameraRunning = true;
            }
            else
            {
                capture.Release();
                streamBtn.Text = "Start";
                isCameraRunning = false;
            }
        }

        private void snapshotBtn_Click(object sender, EventArgs e)
        {
            if (isCameraRunning)
            {
                try
                {
                    // Take snapshot of the current image generate by OpenCV in the Picture Box
                    Bitmap snapshot = new Bitmap(captureFrame.Image);
                    captureFrame.Image.Dispose();

                    saveSnapshot();
                }
                catch (Exception)
                {
                    MessageBox.Show("Device must be streaming to take a snapshot", "Take Snapshot",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Device must be streaming to take a snapshot", "Take Snapshot",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void saveSnapshot()
        {
            try
            {
                var saveFileDialog = new SaveFileDialog();
                saveFileDialog.Title = @"Save Your Photo";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    captureFrame.Image.Save(saveFileDialog.FileName + ".jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
                    MessageBox.Show(@"Saved!");
                }
            }catch(Exception)
            {
                MessageBox.Show("Device must be streaming to take a snapshot", "Take Snapshot",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Sets up the _capture variable with the selected camera index
        /// </summary>
        /// <param name="Camera_Identifier"></param>
        private void SetupCapture(int Camera_Identifier)
        {
            //update the selected device
            CameraDevice = Camera_Identifier;

            //Dispose of Capture if it was created before
            if (capture != null) capture.Dispose();
            try
            {
                //Set up capture device
                capture = new VideoCapture(CameraDevice);
                CaptureCamera();
            }

            catch (NullReferenceException excpt)
            {
                MessageBox.Show(excpt.Message);
            }
        }
    }
}
