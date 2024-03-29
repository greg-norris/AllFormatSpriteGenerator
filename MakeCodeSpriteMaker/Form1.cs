﻿using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace MakeCodeSpriteMaker{
    public partial class Form1 : Form{
        public Form1(){
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e){
        }

        private void button1_Click(object sender, EventArgs e){

            // Show the dialog and get result.
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK) {
                string file = openFileDialog1.FileName;

                FileInfo fi = new FileInfo(openFileDialog1.FileName);

                label1.Text = fi.Name;
            }
            Console.WriteLine(result); // <-- For debugging use.
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e){
            Bitmap img = new Bitmap(openFileDialog1.FileName);

            Image thumb = img.GetThumbnailImage(120, 120, () => false, IntPtr.Zero);

            pictureBox1.Image = new Bitmap(thumb);
        }

        //PIXEL PONG
        private void button2_Click(object sender, EventArgs e){
            Bitmap img = new Bitmap(openFileDialog1.FileName);

            int[] index = { 0, 1, 2, 3, 4, 5, 6, 13, 12, 11, 10, 9, 8, 7, 14, 15, 16, 17, 18, 19, 20, 27, 26, 25, 24, 23, 22, 21, 28, 29, 30, 31, 32, 33, 34, 41, 40, 39, 38, 37, 36, 35, 42, 43, 44, 45, 46, 47, 48 };

            var sb = new System.Text.StringBuilder();

            sb.Append("NeoClear()");
            sb.AppendLine();
            sb.Append("NeoShow(0,50)");
            sb.AppendLine();

            char[] myImage = new char[img.Height];
            var x = 0;
            for (int j = 0; j < img.Height; j++){
                for (int i = 0; i < img.Width; i++){
                    Color pixel = img.GetPixel(i, j);
                    // Console.WriteLine(pixel.ToString());
                    var rValue = pixel.R.ToString();
                    var gValue = pixel.G.ToString();
                    var bValue = pixel.B.ToString();
                    sb.Append("NeoSet(" + index[x] + "," + gValue + "," + rValue + "," + bValue + ")");
                    x++;
                    sb.AppendLine();
                }
                sb.AppendLine();
            }
            sb.Append("NeoShow(0,50)");
            sb.AppendLine();
            textBox1.Text = sb.ToString();
            Console.WriteLine(sb);
        }

        //32x8 NeoPixel Panel
        private void button3_Click(object sender, EventArgs e){
            
            Bitmap img = new Bitmap(openFileDialog1.FileName);

            int[] index = {
                0, 15,16,31,32,47,48,63,64,79,80,95,96,111,112,127,128,143,144,159,160,175,176,191,192,207,208,223,224,239,240,255,
                1,14,17,30,33,46,49,62,65,78,81,94,97,110,113,126,129,142,145,158,161,174,177,190,193,206,209,222,225,238,241,254,
                2,13,18,29,34,45,50,61,66,77,82,93,98,109,114,125,130,141,146,157,162,173,178,189,194,205,210,221,226,237,242,253,
                3,12,19,28,35,44,51,60,67,76,83,92,99,108,115,124,131,140,147,156,163,172,179,188,195,204,211,220,227,236,243,252,
                4,11,20,27,36,43,52,59,68,75,84,91,100,107,116,123,132,139,148,155,164,171,180,187,196,203,212,219,228,235,244,251,
                5,10,21,26,37,42,53,58,69,74,85,90,101,106,117,122,133,138,149,154,165,170,181,186,197,202,213,218,229,234,245,250,
                6,9,22,25,38,41,54,57,70,73,86,89,102,105,118,121,134,137,150,153,166,169,182,185,198,201,214,217,230,233,246,249,
                7,8,23,24,39,40,55,56,71,72,87,88,103,104,119,120,135,136,151,152,167,168,183,184,199,200,215,216,231,232,247,248

             };

            var sb = new System.Text.StringBuilder();

            sb.Append("NeoClear()");
            sb.AppendLine();
            sb.Append("NeoShow(0,256)");
            sb.AppendLine();

            char[] myImage = new char[img.Height];
            var x = 0;
            for (int j = 0; j < img.Height; j++){
                for (int i = 0; i < img.Width; i++){
                    Color pixel = img.GetPixel(i, j);

                    var rValue = pixel.R.ToString();
                    var gValue = pixel.G.ToString();
                    var bValue = pixel.B.ToString();

                    sb.Append("NeoSet(" + index[x] + "," + rValue + "," + gValue + "," + bValue + ")");
                    x++;
                    sb.AppendLine();
                }
                sb.AppendLine();
            }
            sb.Append("NeoShow(0,256)");
            sb.AppendLine();

            textBox1.Text = sb.ToString();
            Console.WriteLine(sb);
        }

        private void button4_Click(object sender, EventArgs e){
            Bitmap img = new Bitmap(openFileDialog1.FileName);

            int[] index = {
                0,31,32,63,64,95,96,127,128,159,160,191,192,223,224,255,
                1,30,33,62,65,94,97,126,129,158,161,190,193,222,225,254,
                2,29,34,61,66,93,98,125,130,157,162,189,194,221,226,253,
                3,28,35,60,67,92,99,124,131,156,163,188,195,220,227,252,
                4,27,36,59,68,91,100,123,132,155,164,187,196,219,228,251,
                5,26,37,58,69,90,101,122,133,154,165,186,197,218,229,250,
                6,25,38,57,70,89,102,121,134,153,166,185,198,217,230,249,
                7,24,39,56,71,88,103,120,135,152,167,184,199,216,231,248,
                8,23,40,55,72,87,104,119,136,151,168,183,200,215,232,247,
                9,22,41,54,73,86,105,118,137,150,169,182,201,214,233,246,
                10,21,42,53,74,85,106,117,138,149,170,181,202,213,234,245,
                11,20,43,52,75,84,107,116,139,148,171,180,203,212,235,244,
                12,19,44,51,76,83,108,115,140,147,172,179,204,211,236,243,
                13,18,45,50,77,82,109,114,141,146,173,178,205,210,237,242,
                14,17,46,49,78,81,110,113,142,145,174,177,206,209,238,241,
                15,16,47,48,79,80,111,112,143,144,175,176,207,208,239,240
             };

            var sb = new System.Text.StringBuilder();

            sb.Append("NeoClear()");
            sb.AppendLine();
            sb.Append("NeoShow(0,256)");
            sb.AppendLine();

            char[] myImage = new char[img.Height];
            var x = 0;
            for (int j = 0; j < img.Height; j++)
            {
                for (int i = 0; i < img.Width; i++)
                {
                    Color pixel = img.GetPixel(i, j);
                    // Console.WriteLine(pixel.ToString());
                    var rValue = pixel.R.ToString();
                    var gValue = pixel.G.ToString();
                    var bValue = pixel.B.ToString();
                    sb.Append("NeoSet(" + index[x] + "," + rValue + "," + gValue + "," + bValue + ")");
                    x++;
                    sb.AppendLine();
                }
                sb.AppendLine();
            }
            sb.Append("NeoShow(0,256)");
            sb.AppendLine();

            textBox1.Text = sb.ToString();
            Console.WriteLine(sb);
        }

        //Copy Code to Clipboard
        private void button5_Click(object sender, EventArgs e){
            textBox1.SelectAll();
            textBox1.Copy();
        }

        
        private void button11_Click(object sender, EventArgs e)
        {
            Bitmap img = new Bitmap(openFileDialog1.FileName);
            var sb = new System.Text.StringBuilder();

            sb.Append("Dim i[2+(" + img.Width + "*" + img.Height + ")] = [" + img.Width + "," + img.Height + ",");
            sb.AppendLine();
            var x = 0;

            for (int j = 0; j < img.Height; j++)
            {

                for (int i = 0; i < img.Width; i++)
                {
                    Color pixel = img.GetPixel(i, j);

                    var rValue = pixel.R.ToString();
                    var gValue = pixel.G.ToString();
                    var bValue = pixel.B.ToString();

                    sb.Append(getHexColor(rValue, gValue, bValue));

                    if (x < img.Height * img.Width - 1)
                    {
                        sb.Append(",");
                        Console.WriteLine(x);
                    }
                    else
                    {
                        sb.Append("]");
                        Console.WriteLine(x);
                    }
                    x++;
                }
                sb.AppendLine();

            }
            sb.Append("");
            sb.AppendLine();
            sb.Append("LcdClear(0)");
            sb.AppendLine();

            sb.Append("LcdImgS(i,0,0,"+ scaleSelect.GetItemText(scaleSelect.SelectedItem)+","+ scaleSelect.GetItemText(scaleSelect.SelectedItem) + ",0)");

            sb.AppendLine();
            sb.Append("LcdShow()");

            textBox1.Text = sb.ToString();
            Console.WriteLine(sb);
        }
       
        private string getHexColor(string rValue, string gValue, string bValue){
            var hexColor = "";

            //White
            if (rValue == "255" && gValue == "255" && bValue == "255")
                return "1";
            //Black
            if (rValue == "0" && gValue == "0" && bValue == "0")
                return "0";
            //Gray
            if (rValue == "70" && gValue == "70" && bValue == "70")
                return "0x464646";
            //Red
            if (rValue == "255" && gValue == "0" && bValue == "0")
                return "0xFF0000";
            //Yellow
            if (rValue == "255" && gValue == "255" && bValue == "0")
                return "0x00FF00";
            //Green
            if (rValue == "0" && gValue == "255" && bValue == "0")
                return "0xFFFF00";
            //Blue
            if (rValue == "0" && gValue == "0" && bValue == "255")
                return "0x0000FF";
            //Green
            if (rValue == "0" && gValue == "255" && bValue == "0")
                return "0xFFFF00";
            //Magenta
            if (rValue == "255" && gValue == "0" && bValue == "255")
                return "0xFF0FF";
            //Light Skin
            if (rValue == "253" && gValue == "198" && bValue == "137")
                return "0xFDC669";
            //Brown
            if (rValue == "117" && gValue == "76" && bValue == "36")
                return "0x754C24";

            return hexColor;
        }
    }
}