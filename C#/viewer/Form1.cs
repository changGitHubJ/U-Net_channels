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
        private Bitmap resized;
        System.Diagnostics.Stopwatch sw;

        public Form1()
        {
            InitializeComponent();

            int ret = WrapInferenceDLL.initializeDll();
            resized = new Bitmap(IMG_SIZE, IMG_SIZE); // width, height

            sw = new System.Diagnostics.Stopwatch();
            sw.Start();
            ret = WrapInferenceDLL.loadModel_0();
            if (ret != 0)
            {
                // error
                MessageBox.Show("cannot read model0");
            }
            sw.Stop();
            TimeSpan ts = sw.Elapsed;
            string msg = "frozen_graph_0.pb was loaded, time = " + ts.TotalMilliseconds + " ms";
            listBox1.Items.Add(msg);

            sw.Restart();
            ret = WrapInferenceDLL.loadModel_1();
            if (ret != 0)
            {
                // error
                MessageBox.Show("cannot read model1");
            }
            sw.Stop();
            ts = sw.Elapsed;
            msg = "frozen_graph_1.pb was loaded, time = " + ts.TotalMilliseconds + " ms";
            listBox1.Items.Add(msg);

            sw.Restart();
            ret = WrapInferenceDLL.loadModel_2();
            if (ret != 0)
            {
                // error
                MessageBox.Show("cannot read model2");
            }
            sw.Stop();
            ts = sw.Elapsed;
            msg = "frozen_graph_2.pb was loaded, time = " + ts.TotalMilliseconds + " ms";
            listBox1.Items.Add(msg);

            sw.Restart();
            ret = WrapInferenceDLL.loadModel_3();
            if (ret != 0)
            {
                // error
                MessageBox.Show("cannot read model3");
            }
            sw.Stop();
            ts = sw.Elapsed;
            msg = "frozen_graph_3.pb was loaded, time = " + ts.TotalMilliseconds + " ms";
            listBox1.Items.Add(msg);

            sw.Restart();
            ret = WrapInferenceDLL.loadModel_4();
            if (ret != 0)
            {
                // error
                MessageBox.Show("cannot read model4");
            }
            sw.Stop();
            ts = sw.Elapsed;
            msg = "frozen_graph_4.pb was loaded, time = " + ts.TotalMilliseconds + " ms";
            listBox1.Items.Add(msg);

            sw.Restart();
            ret = WrapInferenceDLL.loadModel_5();
            if (ret != 0)
            {
                // error
                MessageBox.Show("cannot read model5");
            }
            sw.Stop();
            ts = sw.Elapsed;
            msg = "frozen_graph_5.pb was loaded, time = " + ts.TotalMilliseconds + " ms";
            listBox1.Items.Add(msg);

            sw.Restart();
            ret = WrapInferenceDLL.loadModel_100();
            if (ret != 0)
            {
                // error
                MessageBox.Show("cannot read model100");
            }
            sw.Stop();
            ts = sw.Elapsed;
            msg = "frozen_graph_100.pb was loaded, time = " + ts.TotalMilliseconds + " ms";
            listBox1.Items.Add(msg);

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

            btnInfer1.Enabled = true;
            btnInfer2.Enabled = true;
            btnInfer3.Enabled = true;
            btnInfer4.Enabled = true;
            btnInfer5.Enabled = true;
            btnInfer6.Enabled = true;
            btnInferAll.Enabled = true;
        }

        private void btnInferAll_Click(object sender, EventArgs e)
        {
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
            int ret = WrapInferenceDLL.infer_All(ptrIn, out ptrOut);
            if (ret != 0)
            {
                MessageBox.Show("cannot infer, code = " + ret);
            }
            float[] arrOut = new float[IMG_SIZE * IMG_SIZE * CHANNEL];
            Marshal.Copy(ptrOut, arrOut, 0, IMG_SIZE * IMG_SIZE * CHANNEL);
            sw.Stop();
            TimeSpan ts = sw.Elapsed;
            string msg = "inferred using frozen_graph_100.pb, time = " + ts.TotalMilliseconds + " ms";
            listBox1.Items.Add(msg);

            Marshal.FreeCoTaskMem(ptrIn);

            showInferenceAll(arrOut);
        }

        private void btnInfer1_Click(object sender, EventArgs e)
        {
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
            int ret = WrapInferenceDLL.infer_0(ptrIn, out ptrOut);
            if (ret != 0)
            {
                MessageBox.Show("cannot infer, code = " + ret);
            }
            float[] arrOut = new float[IMG_SIZE * IMG_SIZE];
            Marshal.Copy(ptrOut, arrOut, 0, IMG_SIZE * IMG_SIZE);
            sw.Stop();
            TimeSpan ts = sw.Elapsed;
            string msg = "inferred using frozen_graph_0.pb, time = " + ts.TotalMilliseconds + " ms";
            listBox1.Items.Add(msg);

            Marshal.FreeCoTaskMem(ptrIn);

            showInference(arrOut, Color.Red);
        }

        private void btnInfer2_Click(object sender, EventArgs e)
        {
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
            int ret = WrapInferenceDLL.infer_1(ptrIn, out ptrOut);
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
            int ret = WrapInferenceDLL.infer_2(ptrIn, out ptrOut);
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
            int ret = WrapInferenceDLL.infer_3(ptrIn, out ptrOut);
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
            int ret = WrapInferenceDLL.infer_4(ptrIn, out ptrOut);
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
            int ret = WrapInferenceDLL.infer_5(ptrIn, out ptrOut);
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
