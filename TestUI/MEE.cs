using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Controls;
using System.IO;

namespace TestUI
{
    public partial class MEE : Form
    {

        private string pathsource;
        private string basePath;
        private string[] files;
        private List<string> monNames;

        public MEE()            //All the initial settings
        {
            InitializeComponent();
            numericUpDown1.Maximum = 10;
            numericUpDown1.Minimum = 0;
            numericUpDown2.Maximum = 775;
            numericUpDown2.Minimum = 0;
            numericUpDown3.Maximum = 775;
            numericUpDown3.Minimum = 0;
            numericUpDown4.Maximum = 10;
            numericUpDown4.Minimum = 0;

            button2.Enabled = false;
            comboBox1.Enabled = false;
            checkBox1.Enabled = false;
            checkBox1.Checked = false;
            checkBox2.Enabled = false;
            checkBox2.Checked = false;
            groupBox1.Enabled = false;
            label2.Enabled = false;
            numericUpDown1.Enabled = false;
            label3.Enabled = false;
            numericUpDown2.Enabled = false;
            groupBox2.Enabled = false;
            label4.Enabled = false;
            numericUpDown3.Enabled = false;
            label1.Enabled = false;
            numericUpDown4.Enabled = false;

            ToolTip toolTip1 = new ToolTip();
            toolTip1.AutoPopDelay = 5000;
            toolTip1.InitialDelay = 100;
            toolTip1.ReshowDelay = 500;
            toolTip1.ShowAlways = false;
            toolTip1.SetToolTip(button1, "The Mega Evolutions Garc is at a/1/9/3");
        }

        public void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();            //Open a folder browser

            if (fbd.ShowDialog() == DialogResult.OK)
            {
                basePath = fbd.SelectedPath;
                files = System.IO.Directory.GetFiles(fbd.SelectedPath);

                if (files.Length != 826)            //Yell at the user if a file is larger or smaller than it should be
                {
                    MessageBox.Show("The decrypted garc must contain 826 files!");
                    goto end;
                }

                string[] lines = Properties.Resources.mons.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None);           //Code rei did that I need to keep in mind for the future
                monNames = new List<string>(lines);         //^ Splits the mons file into a huge array based on every "return key" and new line

                comboBox1.Items.AddRange(monNames.ToArray());
                comboBox1.SelectedIndex = 0;
            
                checkBox1.Enabled = true;          //Re-enabled the first check box, dropdown, and save button so that the program isn't worthless
                comboBox1.Enabled = true;
                button2.Enabled = true;

            end:

                Console.Write("lol");           //I'm like fucking Macgyver
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            var Evoitem1 = Convert.ToInt16(numericUpDown2.Value);           //Convert "Numericupdown" stuff to int16
            var Evoitem2 = Convert.ToInt16(numericUpDown3.Value);
            var Form1 = Convert.ToInt16(numericUpDown1.Value);
            var Form2 = Convert.ToInt16(numericUpDown4.Value);

            var Evoitem1b = BitConverter.GetBytes(Evoitem1);            //Convert int16 to Byte arrays
            var Evoitem2b = BitConverter.GetBytes(Evoitem2);
            var Form1b = BitConverter.GetBytes(Form1);
            var Form2b = BitConverter.GetBytes(Form2);

            BinaryWriter bw = new BinaryWriter(new FileStream(pathsource, FileMode.Open));          //Write Bytes to file

            if (checkBox1.Checked == true && checkBox2.Checked == true)         //Set checkbox values to write
            {
                bw.Seek(2, 0);
                bw.Write(1);

                bw.Seek(10, 0);
                bw.Write(1);
            }

            if (checkBox1.Checked == true && checkBox2.Checked == false)
            {
                bw.Seek(2, 0);
                bw.Write(1);

                bw.Seek(10, 0);
                bw.Write(0);
            }

            if (checkBox1.Checked == false && checkBox2.Checked == false)
            {
                bw.Seek(2, 0);
                bw.Write(0);

                bw.Seek(10, 0);
                bw.Write(0);
            }

            bw.Seek(4, 0);
            bw.Write(Evoitem1b);

            bw.Seek(12, 0);
            bw.Write(Evoitem2b);

            bw.Seek(0, 0);
            bw.Write(Form1b);

            bw.Seek(8, 0);
            bw.Write(Form2b);

            bw.Close();
            
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)           //Checkbox1 setup
        {
            if (checkBox1.Checked == false)
            {
                checkBox2.Enabled = false;
                checkBox2.Checked = false;

                groupBox1.Enabled = false;
                label2.Enabled = false;
                numericUpDown1.Enabled = false;
                label3.Enabled = false;
                numericUpDown2.Enabled = false;

                groupBox2.Enabled = false;
                label4.Enabled = false;
                numericUpDown3.Enabled = false;
                label1.Enabled = false;
                numericUpDown4.Enabled = false;

                numericUpDown2.Value = 0;            //Set number boxes to 0
                numericUpDown3.Value = 0;
                numericUpDown1.Value = 0;
                numericUpDown4.Value = 0;
            }

            if (checkBox1.Checked == true && checkBox2.Checked == false)
            {
                checkBox2.Enabled = true;

                groupBox2.Enabled = false;
                label4.Enabled = false;
                numericUpDown3.Enabled = false;
                label1.Enabled = false;
                numericUpDown4.Enabled = false;

                groupBox1.Enabled = true;
                label2.Enabled = true;
                numericUpDown1.Enabled = true;
                label3.Enabled = true;
                numericUpDown2.Enabled = true;
            }

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)            //Checkbox2 setup
        {
            if (checkBox2.Checked == false)
            {
                groupBox2.Enabled = false;
                label4.Enabled = false;
                numericUpDown3.Enabled = false;
                label1.Enabled = false;
                numericUpDown4.Enabled = false;

                numericUpDown3.Value = 0;           //Set evolution2's checkboxes to 0
                numericUpDown4.Value = 0;
            }

            if (checkBox2.Checked == true)
            {
                groupBox2.Enabled = true;
                label4.Enabled = true;
                numericUpDown3.Enabled = true;
                label1.Enabled = true;
                numericUpDown4.Enabled = true;
            }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var boxitem = comboBox1.SelectedItem.ToString();

            pathsource = basePath + "\\" + (boxitem.Split(new string[] { " - " }, StringSplitOptions.None))[0] + ".bin";          //More rei code, but I fixed it mahself to reflect my own text file

            var fi = new FileInfo(pathsource);

            if (fi.Length != 24)
            {
                MessageBox.Show("This file is not a valid evolution table! Make sure you didn't edit it with a hex editor or anything.");
            }

            byte[] Evoitem1 = File.ReadAllBytes(pathsource).Skip(4).Take(2).ToArray();            //Get byte arrays
            byte[] Evoitem2 = File.ReadAllBytes(pathsource).Skip(12).Take(2).ToArray();
            byte[] Form1 = File.ReadAllBytes(pathsource).Skip(0).Take(2).ToArray();
            byte[] Form2 = File.ReadAllBytes(pathsource).Skip(8).Take(2).ToArray();
            byte[] Enabled1 = File.ReadAllBytes(pathsource).Skip(2).Take(2).ToArray();
            byte[] Enabled2 = File.ReadAllBytes(pathsource).Skip(10).Take(2).ToArray();

            var Evoitem1c = BitConverter.ToInt16(Evoitem1, 0);          //Convert bytes to integer
            var Evoitem2c = BitConverter.ToInt16(Evoitem2, 0);
            var Form1c = BitConverter.ToInt16(Form1, 0);
            var Form2c = BitConverter.ToInt16(Form2, 0);
            var Enabled1c = BitConverter.ToInt16(Enabled1, 0);
            var Enabled2c = BitConverter.ToInt16(Enabled2, 0);

            numericUpDown2.Value = Evoitem1c;            //Populate number boxes
            numericUpDown3.Value = Evoitem2c;
            numericUpDown1.Value = Form1c;
            numericUpDown4.Value = Form2c;

            if (Enabled1c == 1 && Enabled2c == 1)           //Enable or disable checkboxes depending on the byte set
            {
                checkBox1.Checked = true;
                checkBox2.Checked = true;
            }

            if (Enabled1c == 1 && Enabled2c == 0)
            {
                checkBox1.Checked = true;
                checkBox2.Checked = false;
            }

            if (Enabled1c == 0)
            {
                checkBox1.Checked = false;
                checkBox2.Checked = false;
            }

        }
    }
}