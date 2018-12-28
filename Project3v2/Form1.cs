using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Project3v2
{
    public partial class Project3v2: Form
    {
        public static string directory = null;
        public static int weight, height;

        public Project3v2()
        {
            InitializeComponent();
        }

        private void Project3v2_Load(object sender, EventArgs e)
        {
            startBttn.Enabled = false;
        }

        private void chooseBttn_Click(object sender, EventArgs e)
        {
            var fileContent = string.Empty;
            var filePath = string.Empty;
            using(OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = @"C:\Users\Gökhan\Source\Repos\Project3\Project3";
                openFileDialog.Filter = "yuv files (*.yuv)|*.yuv|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;

                if(openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Belirtilen dosyanın yolunu alır
                    filePath = openFileDialog.FileName;
                    directory = filePath;
                    //Dosyanın içeriğini bir akışa okur
                    var fileStream = openFileDialog.OpenFile();


                    using(StreamReader reader = new StreamReader(fileStream))
                    {
                        fileContent = reader.ReadToEnd();
                    }
                }
            }
            MessageBox.Show("", "File Content at path: " + filePath, MessageBoxButtons.OK);
            if(filePath != "" && weightText.Text != "" && heightText.Text != "")
            {
                startBttn.Enabled = true;
            }
        }

        private void startBttn_Click(object sender, EventArgs e)
        {
            try
            {
                if(chooseFormat.SelectedIndex == -1)
                {
                    MessageBox.Show("Format Seçiniz.");
                    return;
                }
                else if(chooseFormat.Items[chooseFormat.SelectedIndex].ToString() == "4:2:0")
                {
                    fourtwozerosolver();
                    return;
                }
                else if(chooseFormat.Items[chooseFormat.SelectedIndex].ToString() == "4:2:2")
                {
                    fourtwotwosolver();
                    return;
                }
                else if(chooseFormat.Items[chooseFormat.SelectedIndex].ToString() == "4:4:4")
                {
                    fourfourfoursolver();
                    return;
                }
            }
            catch(Exception ex)
            {
                //MessageBox.Show("Seçim hatası.Comboboxtan doğru seçeneği seçiniz.");
            }

            chooseFormat.SelectedIndex = -1;

        }

        public void fourtwozerosolver()
        {
            byteReader(1.5);
        }
        public void fourtwotwosolver()
        {
            byteReader(2);
        }
        public void fourfourfoursolver()
        {
            byteReader(3);
        }

        public void pushPhoto(string picLoc)
        {
            Bitmap image, resizeimage;

            image = new Bitmap(picLoc);

            int a = Convert.ToInt32(textBox1.Text);
            int b = Convert.ToInt32(textBox2.Text);
            double scale;
            //scale değeri manual alınacaktır.
            if(((double)a / (double)weight) >= ((double)b / (double)height))
            {
                scale = (double)((double)b / (double)height);
            }
            else
            {
                scale = (double)((double)a / (double)weight);
            }



            Size newSize = new Size((int)(image.Width * scale), (int)(image.Height * scale));
            Bitmap bmp = new Bitmap(image, newSize);
            //float scale = Math.Min(weight / image.Width, height / image.Height);
            //var brush = new SolidBrush(Color.Black);
            //var graph = Graphics.FromImage(image);

            //var scaleWidth = (int)(image.Width * scale);
            //var scaleHeight = (int)(image.Height * scale);

            //graph.FillRectangle(brush, new RectangleF(0, 0, weight, height));
            //graph.DrawImage(image, ((int)weight - scaleWidth) / 2, ((int)height - scaleHeight) / 2, scaleWidth, scaleHeight);

            ////////////////////////////
            pictureBox1.ClientSize = new Size(weight, height);
            pictureBox1.Image = (Image)bmp;

        }

        public void byteReader(double kat)
        {
            FileStream fs = File.OpenRead(directory);
            BinaryReader br = new BinaryReader(fs);
            weight = Convert.ToInt32(weightText.Text);
            height = Convert.ToInt32(heightText.Text);

            int imgSize = weight * height;
            int frameSize = Convert.ToInt32(imgSize * kat);

            int index = 0;

            Encoding utf16 = Encoding.Unicode;

            byte[] yuv = new byte[frameSize];
            byte[] rgb = new byte[3 * imgSize];

            int frame = (int)fs.Length / frameSize;

            while(br.PeekChar() != -1)
            {
                // Her bir çerçeveyi bir döngüde okuyun
                br.Read(yuv, 0, frameSize);
                //Dönüştür RGB
                ConvertYUV2RGB(yuv, rgb, weight, height);

                //// BMP dosyasını yazın. @"C:\Users\Gökhan\Source\Repos\Project3\Project3
                WriteBMP(rgb, weight, height, string.Format(@"C:\Users\Gökhan\Source\Repos\Project3\Project3\yuv2bmp_{0}.bmp", index++));


                pushPhoto(string.Format(@"C:\Users\Gökhan\Source\Repos\Project3\Project3\yuv2bmp_{0}.bmp", index - 1));
                pictureBox1.Refresh();
                System.Threading.Thread.Sleep(50);
            }
        }

        static void ConvertYUV2RGB(byte[] yuvFrame, byte[] rgbFrame, int width, int height)
        {
            int gIndex = width * height;
            int bIndex = gIndex * 2;

            int temp = 0;

            for(int y = 0; y < height; y++)
            {
                for(int x = 0; x < width; x++)
                {
                    //R
                    //  byte r = (byte)(yuv.Y + 1.4075);
                    //   MessageBox.Show("" + y * width + x);
                    temp = (int)(yuvFrame[y * width + x] + 1.4075);
                    if(temp < 0)
                        rgbFrame[y * width + x] = (byte)0;
                    else if(temp > 255)
                        rgbFrame[y * width + x] = (byte)255;
                    else
                        rgbFrame[y * width + x] = (byte)temp;

                    //G
                    //  byte g = (byte)(yuv.Y - 0.3455);
                    //   MessageBox.Show("" + gIndex + y * width + x);
                    temp = (int)(yuvFrame[y * width + x] - 0.3455);
                    if(temp < 0)
                        rgbFrame[gIndex + y * width + x] = (byte)0;
                    else if(temp > 255)
                        rgbFrame[gIndex + y * width + x] = (byte)255;
                    else
                        rgbFrame[gIndex + y * width + x] = (byte)temp;

                    //B
                    //  byte b = (byte)(yuv.Y + 1.7790);
                    //   MessageBox.Show("" + bIndex + y * width + x);
                    temp = (int)(yuvFrame[y * width + x] + 1.7790);
                    if(temp < 0)
                        rgbFrame[bIndex + y * width + x] = (byte)0;
                    else if(temp > 255)
                        rgbFrame[bIndex + y * width + x] = (byte)255;
                    else
                        rgbFrame[bIndex + y * width + x] = (byte)temp;
                }
            }
        }

        private void weightText_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void heightText_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }



        //static void ConvertYUV2RGB(byte[] yuvFrame, byte[] rgbFrame, int width, int height)
        //{
        //    int gIndex = width * height;
        //    int bIndex = gIndex * 2;

        //    int temp = 0;

        //    for(int y = 0; y < height; y++)
        //    {
        //        for(int x = 0; x < width; x++)
        //        {
        //            //R
        //            //  byte r = (byte)(yuv.Y + 1.4075);
        //            MessageBox.Show(""+ y * width + x);
        //            temp = (int)(yuvFrame[y * width + x]+1.4075);
        //            if(temp < 0)
        //                rgbFrame[y * width + x] = (byte)0;
        //            else if(temp > 255)
        //                rgbFrame[y * width + x] = (byte)255;
        //            else
        //                rgbFrame[y * width + x] = (byte)temp;

        //            //G
        //            //  byte g = (byte)(yuv.Y - 0.3455);
        //            MessageBox.Show("" + gIndex + y * width + x);
        //            temp = (int)(yuvFrame[y * width + x]-0.3455 );
        //            if(temp < 0)
        //                rgbFrame[gIndex+y * width + x] = (byte)0;
        //            else if(temp > 255)
        //                rgbFrame[gIndex+y * width + x] = (byte)255;
        //            else
        //                rgbFrame[gIndex+y * width + x] = (byte)temp;

        //            //B
        //            //  byte b = (byte)(yuv.Y + 1.7790);
        //            MessageBox.Show("" + bIndex + y * width + x);
        //            temp = (int)(yuvFrame[y * width + x]+1.7790 );
        //            if(temp < 0)
        //                rgbFrame[bIndex+ y * width + x] = (byte)0;
        //            else if(temp > 255)
        //                rgbFrame[bIndex+ y * width + x] = (byte)255;
        //            else
        //                rgbFrame[bIndex+ y * width + x] = (byte)temp;
        //        }
        //    }
        //}




        static void WriteBMP(byte[] rgbFrame, int width, int height, string bmpFile)
        {
            // BMP Görüntü dosyaları yazma。
            int yu = width * 3 % 4;
            int bytePerLine = 0;
            // yu = yu != 0 ? 4 - yu : yu;
            if(yu != 0)
                yu = 4 - yu;

            bytePerLine = width * 3 + yu;

            using(FileStream fs = File.Open(bmpFile, FileMode.Create))
            {
                using(BinaryWriter bw = new BinaryWriter(fs))
                {
                    bw.Write('B');
                    bw.Write('M');
                    bw.Write(bytePerLine * height + 54);
                    bw.Write(0);
                    bw.Write(54);
                    bw.Write(40);
                    bw.Write(width);
                    bw.Write(height);
                    bw.Write((ushort)1);
                    bw.Write((ushort)24);
                    bw.Write(0);
                    bw.Write(bytePerLine * height);
                    bw.Write(0);
                    bw.Write(0);
                    bw.Write(0);
                    bw.Write(0);

                    byte[] data = new byte[bytePerLine * height];
                    int gIndex = width * height;
                    int bIndex = gIndex * 2;

                    for(int y = height - 1, j = 0; y >= 0; y--, j++)
                    {
                        for(int x = 0, i = 0; x < width; x++)
                        {
                            data[y * bytePerLine + i++] = rgbFrame[j * width + x];  // R
                            data[y * bytePerLine + i++] = rgbFrame[gIndex + j * width + x];    // G
                            data[y * bytePerLine + i++] = rgbFrame[bIndex + j * width + x];    // B
                        }
                    }

                    bw.Write(data, 0, data.Length);
                    bw.Flush();
                }
            }
        }





    }
}
