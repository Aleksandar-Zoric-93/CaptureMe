using System;
using System.Drawing;
using System.Windows.Forms;
using OpenCvSharp;
using OpenCvSharp.Extensions;
using System.Drawing.Imaging;
using System.Threading;
using DirectShowLib;

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
        int runningCamera;
        Video_Device[] WebCams;


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

            //-> Find systems cameras with DirectShow.Net dll
            DsDevice[] _SystemCamereas = DsDevice.GetDevicesOfCat(FilterCategory.VideoInputDevice);
            WebCams = new Video_Device[_SystemCamereas.Length];
            for (int i = 0; i < _SystemCamereas.Length; i++)
            {
                WebCams[i] = new Video_Device(i, _SystemCamereas[i].Name, _SystemCamereas[i].ClassID); //fill web cam array
                Camera_Selection.Items.Add(WebCams[i].ToString()[1]);
            }
            if (Camera_Selection.Items.Count > 0)
            {
                Camera_Selection.SelectedIndex = CameraDevice; //Set the selected device the default  

            }

        }

        private void button1_Click_1(object sender, EventArgs e)
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

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (isCameraRunning)
            {
                try
                {
                    // Take snapshot of the current image generate by OpenCV in the Picture Box
                    Bitmap snapshot = new Bitmap(captureFrame.Image);
                    captureFrame.Image.Dispose();
                    // Save in some directory
                    // in this example, we'll generate a random filename e.g 47059681-95ed-4e95-9b50-320092a3d652.png
                    // snapshot.Save(@"C:\Users\sdkca\Desktop\mysnapshot.png", ImageFormat.Png);
                    //snapshot.Save(string.Format(@"C:\Users\Diomac\Desktop\testSnapshot.png", Guid.NewGuid()), ImageFormat.Png);

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
