using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Viewer
{
    public partial class Form1 : Form
    {
        const int IMG_SIZE = 256;
        const int CHANNEL = 6;
        bool imageRead;
        private Bitmap resized;
        System.Diagnostics.Stopwatch sw;

        public Form1()
        {
            InitializeComponent();

            int ret = WrapInferenceDLL.initializeDll();
            imageRead = false;
            resized = new Bitmap(IMG_SIZE, IMG_SIZE); // width, height
            sw = new System.Diagnostics.Stopwatch();

            btnLoadModel.Enabled = true;
            btnPrepClass1.Enabled = false;
            btnPrepClass2.Enabled = false;
            btnPrepClass3.Enabled = false;
            btnPrepClass4.Enabled = false;
            btnPrepClass5.Enabled = false;
            btnPrepClass6.Enabled = false;
            btnPrepareAll.Enabled = false;
            btnInfer1.Enabled = false;
            btnInfer2.Enabled = false;
            btnInfer3.Enabled = false;
            btnInfer4.Enabled = false;
            btnInfer5.Enabled = false;
            btnInfer6.Enabled = false;
            btnInferAll.Enabled = false;
        }

        private void OnFromClosed(object objSender, FormClosedEventArgs objArguments)
        {
            WrapInferenceDLL.finalizeDll();
            resized.Dispose();
        }

        private void panel_DragEnter(object sender, DragEventArgs e)
        {
            this.toggleEffectsToDragEvent(e);
        }

        private void panel_DragDrop(object sender, DragEventArgs e)
        {
            string fileName = this.getFileNameToDragEvent(e);
            this.showPicture(fileName);
        }

        private void toggleEffectsToDragEvent(DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.All;
            }    
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private string getFileNameToDragEvent(DragEventArgs e)
        {
            string[] fileName = (string[])e.Data.GetData(DataFormats.FileDrop);
            if (System.IO.File.Exists(fileName[0]) == true)
            {
                return fileName[0];
            }
            else
            {
                return null;
            }
        }

        private void showPicture(string filename)
        {
            Graphics g = Graphics.FromImage(resized);
            Bitmap image = new Bitmap(filename);
            g.InterpolationMode =
                System.Drawing.Drawing2D.InterpolationMode.Bicubic;
            g.DrawImage(image, 0, 0, IMG_SIZE, IMG_SIZE);
            image.Dispose();
            g.Dispose();

            pictureBox1.Image = resized;

            imageRead = true;
        }

        private void btnLoadModel_Click(object sender, EventArgs e)
        {
            string[] model_name = {"frozen_graph_0.pb",
                                   "frozen_graph_1.pb",
                                   "frozen_graph_2.pb",
                                   "frozen_graph_3.pb",
                                   "frozen_graph_4.pb",
                                   "frozen_graph_5.pb",
                                   "frozen_graph_100.pb"};
            for(int i = 0; i < 7; i++)
            {
                sw.Restart();
                int ret = WrapInferenceDLL.loadModel(model_name[i], i);
                sw.Stop();
                TimeSpan ts = sw.Elapsed;
                string msg = model_name[i] + " was loaded, time = " + ts.TotalMilliseconds + " ms";
                listBox1.Items.Add(msg);
                listBox1.Refresh();
                if (ret != 0)
                {
                    // error
                    MessageBox.Show("cannot read model0");
                    return;
                }
            }

            btnLoadModel.Enabled = false;
            btnPrepClass1.Enabled = true;
            btnPrepClass2.Enabled = true;
            btnPrepClass3.Enabled = true;
            btnPrepClass4.Enabled = true;
            btnPrepClass5.Enabled = true;
            btnPrepClass6.Enabled = true;
            btnPrepareAll.Enabled = true;
            btnInfer1.Enabled = false;
            btnInfer2.Enabled = false;
            btnInfer3.Enabled = false;
            btnInfer4.Enabled = false;
            btnInfer5.Enabled = false;
            btnInfer6.Enabled = false;
            btnInferAll.Enabled = false;
        }

        private void btnPrepareOne_Click(object sender, EventArgs e)
        {
            sw.Restart();
            int ret = WrapInferenceDLL.prepareSession(0, 1);
            sw.Stop();
            TimeSpan ts = sw.Elapsed;
            string msg = "prepared session, time = " + ts.TotalMilliseconds + " ms";
            listBox1.Items.Add(msg);
            listBox1.Refresh();
            if (ret != 0)
            {
                // error
                MessageBox.Show("cannot prepare session");
                return;
            }
            btnPrepClass1.Enabled = false;
            btnInfer1.Enabled = true;
        }


        private void btnPrepClass2_Click(object sender, EventArgs e)
        {
            sw.Restart();
            int ret = WrapInferenceDLL.prepareSession(1, 1);
            sw.Stop();
            TimeSpan ts = sw.Elapsed;
            string msg = "prepared session, time = " + ts.TotalMilliseconds + " ms";
            listBox1.Items.Add(msg);
            listBox1.Refresh();
            if (ret != 0)
            {
                // error
                MessageBox.Show("cannot prepare session");
                return;
            }

            btnPrepClass2.Enabled = false;
            btnInfer2.Enabled = true;
        }

        private void btnPrepClass3_Click(object sender, EventArgs e)
        {
            sw.Restart();
            int ret = WrapInferenceDLL.prepareSession(2, 1);
            sw.Stop();
            TimeSpan ts = sw.Elapsed;
            string msg = "prepared session, time = " + ts.TotalMilliseconds + " ms";
            listBox1.Items.Add(msg);
            listBox1.Refresh();
            if (ret != 0)
            {
                // error
                MessageBox.Show("cannot prepare session");
                return;
            }

            btnPrepClass3.Enabled = false;
            btnInfer3.Enabled = true;
        }

        private void btnPrepClass4_Click(object sender, EventArgs e)
        {
            sw.Restart();
            int ret = WrapInferenceDLL.prepareSession(3, 1);
            sw.Stop();
            TimeSpan ts = sw.Elapsed;
            string msg = "prepared session, time = " + ts.TotalMilliseconds + " ms";
            listBox1.Items.Add(msg);
            listBox1.Refresh();
            if (ret != 0)
            {
                // error
                MessageBox.Show("cannot prepare session");
                return;
            }

            btnPrepClass4.Enabled = false;
            btnInfer4.Enabled = true;
        }

        private void btnPrepClass5_Click(object sender, EventArgs e)
        {
            sw.Restart();
            int ret = WrapInferenceDLL.prepareSession(4, 1);
            sw.Stop();
            TimeSpan ts = sw.Elapsed;
            string msg = "prepared session, time = " + ts.TotalMilliseconds + " ms";
            listBox1.Items.Add(msg);
            listBox1.Refresh();
            if (ret != 0)
            {
                // error
                MessageBox.Show("cannot prepare session");
                return;
            }

            btnPrepClass5.Enabled = false;
            btnInfer5.Enabled = true;
        }


        private void btnPrepClass6_Click(object sender, EventArgs e)
        {
            sw.Restart();
            int ret = WrapInferenceDLL.prepareSession(5, 1);
            sw.Stop();
            TimeSpan ts = sw.Elapsed;
            string msg = "prepared session, time = " + ts.TotalMilliseconds + " ms";
            listBox1.Items.Add(msg);
            listBox1.Refresh();
            if (ret != 0)
            {
                // error
                MessageBox.Show("cannot prepare session");
                return;
            }

            btnPrepClass6.Enabled = false;
            btnInfer6.Enabled = true;
        }

        private void btnPrepareAll_Click(object sender, EventArgs e)
        {
            sw.Restart();
            int ret = WrapInferenceDLL.prepareSession(6, 6);
            sw.Stop();
            TimeSpan ts = sw.Elapsed;
            string msg = "prepared session, time = " + ts.TotalMilliseconds + " ms";
            listBox1.Items.Add(msg);
            listBox1.Refresh();
            if (ret != 0)
            {
                // error
                MessageBox.Show("cannot prepare session");
                return;
            }

            btnLoadModel.Enabled = false;
            btnPrepareAll.Enabled = false;
            btnPrepClass1.Enabled = false;
            btnInferAll.Enabled = true;
        }

        private void btnInferAll_Click(object sender, EventArgs e)
        {
            if (!imageRead)
            {
                MessageBox.Show("No image was read");
                return;
            }

            sw.Stop();

            float[] arrIn = new float[IMG_SIZE * IMG_SIZE * CHANNEL];
            for (int i = 0; i < IMG_SIZE; i++) // row
            {
                for (int j = 0; j < IMG_SIZE; j++) // column
                {
                    for(int n = 0; n < CHANNEL; n++)
                    {
                        arrIn[CHANNEL*(i * IMG_SIZE + j) + n] = (resized.GetPixel(j, i).R + resized.GetPixel(j, i).G + resized.GetPixel(j, i).B) / 3.0f;
                        arrIn[CHANNEL * (i * IMG_SIZE + j) + n] /= 127.5f;
                        arrIn[CHANNEL * (i * IMG_SIZE + j) + n] -= 1.0f;
                    }
                }
            }
            System.IntPtr ptrIn = Marshal.AllocCoTaskMem(Marshal.SizeOf(typeof(float)) * IMG_SIZE * IMG_SIZE * CHANNEL);
            Marshal.Copy(arrIn, 0, ptrIn, IMG_SIZE * IMG_SIZE * CHANNEL);

            sw.Restart();
            IntPtr ptrOut;
            int ret = WrapInferenceDLL.infer(ptrIn, 6, 6, out ptrOut);
            sw.Stop();
            TimeSpan ts = sw.Elapsed;
            string msg = "inferred using frozen_graph_100.pb, time = " + ts.TotalMilliseconds + " ms";
            listBox1.Items.Add(msg);
            listBox1.Refresh();
            if (ret != 0)
            {
                MessageBox.Show("cannot infer, code = " + ret);
                WrapInferenceDLL.releaseBuffer();
                Marshal.FreeCoTaskMem(ptrIn);
                return;
            }
            float[] arrOut = new float[IMG_SIZE * IMG_SIZE * CHANNEL];
            Marshal.Copy(ptrOut, arrOut, 0, IMG_SIZE * IMG_SIZE * CHANNEL);
            WrapInferenceDLL.releaseBuffer();
            Marshal.FreeCoTaskMem(ptrIn);

            showInferenceAll(arrOut);
        }

        private void btnInfer1_Click(object sender, EventArgs e)
        {
            if(!imageRead)
            {
                MessageBox.Show("No image was read");
                return;
            }

            sw.Stop();

            float[] arrIn = new float[IMG_SIZE * IMG_SIZE];
            for (int i = 0; i < IMG_SIZE; i++) // row
            {
                for (int j = 0; j < IMG_SIZE; j++) // column
                {
                    arrIn[i * IMG_SIZE + j] = (resized.GetPixel(j, i).R + resized.GetPixel(j, i).G + resized.GetPixel(j, i).B) / 3.0f;
                    arrIn[i * IMG_SIZE + j] = arrIn[i * IMG_SIZE + j] / 127.5f - 1.0f;
                }
            }
            System.IntPtr ptrIn = Marshal.AllocCoTaskMem(Marshal.SizeOf(typeof(float)) * IMG_SIZE * IMG_SIZE);
            Marshal.Copy(arrIn, 0, ptrIn, IMG_SIZE * IMG_SIZE);

            sw.Restart();
            IntPtr ptrOut;
            int ret = WrapInferenceDLL.infer(ptrIn, 0, 1, out ptrOut);
            sw.Stop();
            TimeSpan ts = sw.Elapsed;
            string msg = "inferred using frozen_graph_0.pb, time = " + ts.TotalMilliseconds + " ms";
            listBox1.Items.Add(msg);
            listBox1.Refresh();
            if (ret != 0)
            {
                MessageBox.Show("cannot infer, code = " + ret);
                WrapInferenceDLL.releaseBuffer();
                Marshal.FreeCoTaskMem(ptrIn);
                return;
            }
            float[] arrOut = new float[IMG_SIZE * IMG_SIZE];
            Marshal.Copy(ptrOut, arrOut, 0, IMG_SIZE * IMG_SIZE);
            WrapInferenceDLL.releaseBuffer();
            Marshal.FreeCoTaskMem(ptrIn);

            showInference(arrOut, Color.Red);
        }

        private void btnInfer2_Click(object sender, EventArgs e)
        {
            if (!imageRead)
            {
                MessageBox.Show("No image was read");
                return;
            }

            sw.Stop();

            float[] arrIn = new float[IMG_SIZE * IMG_SIZE];
            for (int i = 0; i < IMG_SIZE; i++) // row
            {
                for (int j = 0; j < IMG_SIZE; j++) // column
                {
                    arrIn[i * IMG_SIZE + j] = (resized.GetPixel(j, i).R + resized.GetPixel(j, i).G + resized.GetPixel(j, i).B) / 3.0f;
                    arrIn[i * IMG_SIZE + j] = arrIn[i * IMG_SIZE + j] / 127.5f - 1.0f;
                }
            }
            System.IntPtr ptrIn = Marshal.AllocCoTaskMem(Marshal.SizeOf(typeof(float)) * IMG_SIZE * IMG_SIZE);
            Marshal.Copy(arrIn, 0, ptrIn, IMG_SIZE * IMG_SIZE);

            sw.Restart();
            IntPtr ptrOut;
            int ret = WrapInferenceDLL.infer(ptrIn, 1, 1, out ptrOut);
            if (ret != 0)
            {
                MessageBox.Show("cannot infer, code = " + ret);
            }
            float[] arrOut = new float[IMG_SIZE * IMG_SIZE];
            Marshal.Copy(ptrOut, arrOut, 0, IMG_SIZE * IMG_SIZE);
            sw.Stop();
            TimeSpan ts = sw.Elapsed;
            string msg = "inferred using frozen_graph_1.pb, time = " + ts.TotalMilliseconds + " ms";
            listBox1.Items.Add(msg);

            Marshal.FreeCoTaskMem(ptrIn);

            showInference(arrOut, Color.Yellow);
        }

        private void btnInfer3_Click(object sender, EventArgs e)
        {
            if (!imageRead)
            {
                MessageBox.Show("No image was read");
                return;
            }

            sw.Stop();

            float[] arrIn = new float[IMG_SIZE * IMG_SIZE];
            for (int i = 0; i < IMG_SIZE; i++) // row
            {
                for (int j = 0; j < IMG_SIZE; j++) // column
                {
                    arrIn[i * IMG_SIZE + j] = (resized.GetPixel(j, i).R + resized.GetPixel(j, i).G + resized.GetPixel(j, i).B) / 3.0f;
                    arrIn[i * IMG_SIZE + j] = arrIn[i * IMG_SIZE + j] / 127.5f - 1.0f;
                }
            }
            System.IntPtr ptrIn = Marshal.AllocCoTaskMem(Marshal.SizeOf(typeof(float)) * IMG_SIZE * IMG_SIZE);
            Marshal.Copy(arrIn, 0, ptrIn, IMG_SIZE * IMG_SIZE);

            sw.Restart();
            IntPtr ptrOut;
            int ret = WrapInferenceDLL.infer(ptrIn, 2, 1, out ptrOut);
            if (ret != 0)
            {
                MessageBox.Show("cannot infer, code = " + ret);
            }
            float[] arrOut = new float[IMG_SIZE * IMG_SIZE];
            Marshal.Copy(ptrOut, arrOut, 0, IMG_SIZE * IMG_SIZE);
            sw.Stop();
            TimeSpan ts = sw.Elapsed;
            string msg = "inferred using frozen_graph_2.pb, time = " + ts.TotalMilliseconds + " ms";
            listBox1.Items.Add(msg);

            Marshal.FreeCoTaskMem(ptrIn);

            showInference(arrOut, Color.Blue);
        }

        private void btnInfer4_Click(object sender, EventArgs e)
        {
            if (!imageRead)
            {
                MessageBox.Show("No image was read");
                return;
            }

            sw.Stop();

            float[] arrIn = new float[IMG_SIZE * IMG_SIZE];
            for (int i = 0; i < IMG_SIZE; i++) // row
            {
                for (int j = 0; j < IMG_SIZE; j++) // column
                {
                    arrIn[i * IMG_SIZE + j] = (resized.GetPixel(j, i).R + resized.GetPixel(j, i).G + resized.GetPixel(j, i).B) / 3.0f;
                    arrIn[i * IMG_SIZE + j] = arrIn[i * IMG_SIZE + j] / 127.5f - 1.0f;
                }
            }
            System.IntPtr ptrIn = Marshal.AllocCoTaskMem(Marshal.SizeOf(typeof(float)) * IMG_SIZE * IMG_SIZE);
            Marshal.Copy(arrIn, 0, ptrIn, IMG_SIZE * IMG_SIZE);

            sw.Restart();
            IntPtr ptrOut;
            int ret = WrapInferenceDLL.infer(ptrIn, 3, 1, out ptrOut);
            if (ret != 0)
            {
                MessageBox.Show("cannot infer, code = " + ret);
            }
            float[] arrOut = new float[IMG_SIZE * IMG_SIZE];
            Marshal.Copy(ptrOut, arrOut, 0, IMG_SIZE * IMG_SIZE);
            sw.Stop();
            TimeSpan ts = sw.Elapsed;
            string msg = "inferred using frozen_graph_3.pb, time = " + ts.TotalMilliseconds + " ms";
            listBox1.Items.Add(msg);

            Marshal.FreeCoTaskMem(ptrIn);

            showInference(arrOut, Color.Green);
        }

        private void btnInfer5_Click(object sender, EventArgs e)
        {
            if (!imageRead)
            {
                MessageBox.Show("No image was read");
                return;
            }

            sw.Stop();

            float[] arrIn = new float[IMG_SIZE * IMG_SIZE];
            for (int i = 0; i < IMG_SIZE; i++) // row
            {
                for (int j = 0; j < IMG_SIZE; j++) // column
                {
                    arrIn[i * IMG_SIZE + j] = (resized.GetPixel(j, i).R + resized.GetPixel(j, i).G + resized.GetPixel(j, i).B) / 3.0f;
                    arrIn[i * IMG_SIZE + j] = arrIn[i * IMG_SIZE + j] / 127.5f - 1.0f;
                }
            }
            System.IntPtr ptrIn = Marshal.AllocCoTaskMem(Marshal.SizeOf(typeof(float)) * IMG_SIZE * IMG_SIZE);
            Marshal.Copy(arrIn, 0, ptrIn, IMG_SIZE * IMG_SIZE);

            sw.Restart();
            IntPtr ptrOut;
            int ret = WrapInferenceDLL.infer(ptrIn, 4, 1, out ptrOut);
            if (ret != 0)
            {
                MessageBox.Show("cannot infer, code = " + ret);
            }
            float[] arrOut = new float[IMG_SIZE * IMG_SIZE];
            Marshal.Copy(ptrOut, arrOut, 0, IMG_SIZE * IMG_SIZE);
            sw.Stop();
            TimeSpan ts = sw.Elapsed;
            string msg = "inferred using frozen_graph_4.pb, time = " + ts.TotalMilliseconds + " ms";
            listBox1.Items.Add(msg);

            Marshal.FreeCoTaskMem(ptrIn);

            showInference(arrOut, Color.Pink);
        }

        private void btnInfer6_Click(object sender, EventArgs e)
        {
            if (!imageRead)
            {
                MessageBox.Show("No image was read");
                return;
            }

            sw.Stop();

            float[] arrIn = new float[IMG_SIZE * IMG_SIZE];
            for (int i = 0; i < IMG_SIZE; i++) // row
            {
                for (int j = 0; j < IMG_SIZE; j++) // column
                {
                    arrIn[i * IMG_SIZE + j] = (resized.GetPixel(j, i).R + resized.GetPixel(j, i).G + resized.GetPixel(j, i).B) / 3.0f;
                    arrIn[i * IMG_SIZE + j] = arrIn[i * IMG_SIZE + j] / 127.5f - 1.0f;
                }
            }
            System.IntPtr ptrIn = Marshal.AllocCoTaskMem(Marshal.SizeOf(typeof(float)) * IMG_SIZE * IMG_SIZE);
            Marshal.Copy(arrIn, 0, ptrIn, IMG_SIZE * IMG_SIZE);

            sw.Restart();
            IntPtr ptrOut;
            int ret = WrapInferenceDLL.infer(ptrIn, 5, 1, out ptrOut);
            if (ret != 0)
            {
                MessageBox.Show("cannot infer, code = " + ret);
            }
            float[] arrOut = new float[IMG_SIZE * IMG_SIZE];
            Marshal.Copy(ptrOut, arrOut, 0, IMG_SIZE * IMG_SIZE);
            sw.Stop();
            TimeSpan ts = sw.Elapsed;
            string msg = "inferred using frozen_graph_5.pb, time = " + ts.TotalMilliseconds + " ms";
            listBox1.Items.Add(msg);

            Marshal.FreeCoTaskMem(ptrIn);

            showInference(arrOut, Color.Purple);
        }

        private void showInference(float[] arrOut, System.Drawing.Color color)
        {
            Bitmap detected = (Bitmap)resized.Clone();
            for (int i = 0; i < IMG_SIZE; i++)
            {
                for(int j = 0; j < IMG_SIZE; j++)
                {
                    if(arrOut[i*IMG_SIZE + j] > 0.9)
                    {
                        detected.SetPixel(j, i, color);
                    }
                }
            }
            pictureBox1.Image = detected;
        }

        private void showInferenceAll(float[] arrOut)
        {
            Bitmap detected = (Bitmap)resized.Clone();
            for (int i = 0; i < IMG_SIZE; i++)
            {
                for (int j = 0; j < IMG_SIZE; j++)
                {
                    // class 1
                    if (arrOut[CHANNEL * (i * IMG_SIZE + j) + 0] > 0.8)
                    {
                        detected.SetPixel(j, i, Color.Red);
                    }
                    // class 2
                    if (arrOut[CHANNEL * (i * IMG_SIZE + j) + 1] > 0.9)
                    {
                        detected.SetPixel(j, i, Color.Yellow);
                    }
                    // class 3
                    if (arrOut[CHANNEL * (i * IMG_SIZE + j) + 2] > 0.8)
                    {
                        detected.SetPixel(j, i, Color.Blue);
                    }
                    // class 4
                    if (arrOut[CHANNEL * (i * IMG_SIZE + j) + 3] > 0.8)
                    {
                        detected.SetPixel(j, i, Color.Green);
                    }
                    // class 5
                    if (arrOut[CHANNEL * (i * IMG_SIZE + j) + 4] > 0.8)
                    {
                        detected.SetPixel(j, i, Color.Pink);
                    }
                    // class 6
                    if (arrOut[CHANNEL * (i * IMG_SIZE + j) + 5] > 0.7)
                    {
                        detected.SetPixel(j, i, Color.Purple);
                    }
                }
            }
            pictureBox1.Image = detected;
        }
    }
}
