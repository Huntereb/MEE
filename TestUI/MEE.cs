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
        private string[] lines3;

        public MEE()            //All the initial settings
        {
            InitializeComponent();

            FormBorderStyle = FormBorderStyle.FixedSingle;

            label7.Enabled = false;

            itembox1.Enabled = false;
            itembox2.Enabled = false;
            itembox3.Enabled = false;

            numericUpDown1.Maximum = 10;
            numericUpDown4.Maximum = 10;
            numericUpDown6.Maximum = 10;
            numericUpDown1.Minimum = 0;
            numericUpDown4.Minimum = 0;
            numericUpDown6.Minimum = 0;

            label8.AutoSize = false;
            label8.Height = 2;
            label8.BorderStyle = BorderStyle.Fixed3D;

            button2.Enabled = false;
            comboBox1.Enabled = false;
            checkBox1.Enabled = false;
            checkBox1.Checked = false;
            checkBox2.Enabled = false;
            checkBox2.Checked = false;
            checkBox3.Enabled = false;
            checkBox3.Checked = false;
            groupBox1.Enabled = false;
            groupBox2.Enabled = false;
            groupBox3.Enabled = false;
            label1.Enabled = false;
            label2.Enabled = false;
            label3.Enabled = false;
            label4.Enabled = false;
            label5.Enabled = false;
            label6.Enabled = false;
        }

        public void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();            //Open a folder browser

            if (fbd.ShowDialog() == DialogResult.OK)
            {
                basePath = fbd.SelectedPath;
                files = System.IO.Directory.GetFiles(fbd.SelectedPath);

                if (files.Length != 799 && files.Length != 826)         //Not using goto! :D
                {
                    MessageBox.Show("The decrypted garc must contain 826 files (For OR/AS) or 799 files (For X/Y)!");
                    return;
                }

                string[] lines2 = Properties.Resources.items.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None);         //Called same if statement twice because bullshit

                if (files.Length == 826)            //List only items from the respective game
                {
                    lines3 = lines2.Take(776).ToArray();
                }

                if (files.Length == 799)
                {

                    lines3 = lines2.Take(718).ToArray();
                }

                itembox1.Items.AddRange(lines3);            //Populate item list
                itembox1.SelectedIndex = 0;
                itembox2.Items.AddRange(lines3);
                itembox2.SelectedIndex = 0;
                itembox3.Items.AddRange(lines3);
                itembox3.SelectedIndex = 0;

                string[] lines = Properties.Resources.mons.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None);

                if (files.Length == 826)            //List only guys from their respective game
                {
                    label7.Text = "Game mode: OR/AS";
                    label7.Enabled = true;
                    string[] loras = lines.Take(826).ToArray();
                    monNames = new List<string>(loras);
                }

                if (files.Length == 799)
                {
                    label7.Text = "Game mode: X/Y";
                    label7.Enabled = true;
                    string[] lxy = lines.Take(799).ToArray();
                    monNames = new List<string>(lxy);
                }

                comboBox1.Items.AddRange(monNames.ToArray());           //Populate Pokemon list
                comboBox1.SelectedIndex = 0;
            
                checkBox1.Enabled = true;          //Re-enabled the first check box, dropdown, and save button so that the program isn't worthless
                comboBox1.Enabled = true;
                button2.Enabled = true;
            }

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)           //Checkbox1 setup
        {
            if (checkBox1.Checked == false)
            {
                checkBox2.Enabled = false;
                checkBox2.Checked = false;
                checkBox3.Enabled = false;
                checkBox3.Checked = false;

                label1.Enabled = false;
                label2.Enabled = false;
                label3.Enabled = false;
                label4.Enabled = false;
                label5.Enabled = false;
                label6.Enabled = false;
                groupBox1.Enabled = false;
                groupBox2.Enabled = false;
                groupBox3.Enabled = false;

                numericUpDown1.Value = 0;           //Set number/item boxes to 0
                numericUpDown4.Value = 0;
                numericUpDown6.Value = 0;
                itembox1.Enabled = false;
                itembox2.Enabled = false;
                itembox3.Enabled = false;
                itembox1.SelectedIndex = 0;
                itembox2.SelectedIndex = 0;
                itembox3.SelectedIndex = 0;
            }

            if (checkBox1.Checked == true)
            {
                checkBox2.Enabled = true;

                groupBox1.Enabled = true;
                label2.Enabled = true;
                label3.Enabled = true;
                numericUpDown1.Enabled = true;

                groupBox2.Enabled = false;
                label4.Enabled = false;
                label1.Enabled = false;
                numericUpDown4.Enabled = false;

                groupBox3.Enabled = false;
                label5.Enabled = false;
                label6.Enabled = false;
                numericUpDown6.Enabled = false;
                itembox1.Enabled = true;
            }

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)            //Checkbox2 setup
        {
            if (checkBox2.Checked == false)
            {
                groupBox2.Enabled = false;
                label4.Enabled = false;
                label1.Enabled = false;
                numericUpDown4.Enabled = false;

                numericUpDown4.Value = 0;
                numericUpDown6.Value = 0;
                itembox2.SelectedIndex = 0;
                itembox3.SelectedIndex = 0;
                itembox2.Enabled = false;
                itembox3.Enabled = false;

                checkBox3.Enabled = false;
                checkBox3.Checked = false;
            }

            if (checkBox2.Checked == true)
            {
                groupBox2.Enabled = true;
                label4.Enabled = true;
                label1.Enabled = true;
                numericUpDown4.Enabled = true;

                checkBox3.Enabled = true;
                checkBox3.Checked = false;
                itembox2.Enabled = true;
            }

        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)           //Checkbox 3 setup
        {
            if (checkBox3.Checked == false)
            {
                label5.Enabled = false;
                label6.Enabled = false;
                groupBox3.Enabled = false;
                numericUpDown6.Enabled = false;
                numericUpDown6.Value = 0;
                itembox3.SelectedIndex = 0;
                itembox3.Enabled = false;
            }

            if (checkBox3.Checked == true)
            {
                label5.Enabled = true;
                label6.Enabled = true;
                groupBox3.Enabled = true;
                numericUpDown6.Enabled = true;
                itembox3.Enabled = true;
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

            if (boxitem == "384 - Rayquaza" && files.Length == 826)         //Yell at the user about Rayquaza if they're editing him in OR/AS mode
            {
                MessageBox.Show("Rayquaza is special and uses a different activator for his evolution. If he knows Dragon Accent, he can Mega Evolve. Don't edit this evolution table if you want to keep that functionality.");
            }

            byte[] Evoitem1 = File.ReadAllBytes(pathsource).Skip(4).Take(2).ToArray();            //Get byte arrays
            byte[] Evoitem2 = File.ReadAllBytes(pathsource).Skip(12).Take(2).ToArray();
            byte[] Evoitem3 = File.ReadAllBytes(pathsource).Skip(20).Take(2).ToArray();
            byte[] Form1 = File.ReadAllBytes(pathsource).Skip(0).Take(2).ToArray();
            byte[] Form2 = File.ReadAllBytes(pathsource).Skip(8).Take(2).ToArray();
            byte[] Form3 = File.ReadAllBytes(pathsource).Skip(16).Take(2).ToArray();
            byte[] Enabled1 = File.ReadAllBytes(pathsource).Skip(2).Take(2).ToArray();
            byte[] Enabled2 = File.ReadAllBytes(pathsource).Skip(10).Take(2).ToArray();
            byte[] Enabled3 = File.ReadAllBytes(pathsource).Skip(18).Take(2).ToArray();

            var Evoitem1c = BitConverter.ToInt16(Evoitem1, 0);          //Convert bytes to integer
            var Evoitem2c = BitConverter.ToInt16(Evoitem2, 0);
            var Evoitem3c = BitConverter.ToInt16(Evoitem3, 0);
            var Form1c = BitConverter.ToInt16(Form1, 0);
            var Form2c = BitConverter.ToInt16(Form2, 0);
            var Form3c = BitConverter.ToInt16(Form3, 0);
            var Enabled1c = BitConverter.ToInt16(Enabled1, 0);
            var Enabled2c = BitConverter.ToInt16(Enabled2, 0);
            var Enabled3c = BitConverter.ToInt16(Enabled3, 0);

            numericUpDown1.Value = Form1c;            //Populate number boxes
            numericUpDown4.Value = Form2c;
            numericUpDown6.Value = Form3c;
            itembox1.SelectedIndex = Evoitem1c;
            itembox2.SelectedIndex = Evoitem2c;
            itembox3.SelectedIndex = Evoitem3c;

            if (Enabled1c == 1 && Enabled2c == 1 && Enabled3c == 1)           //Enable or disable checkboxes depending on the byte set
            {
                checkBox1.Checked = true;
                checkBox2.Checked = true;
                checkBox3.Checked = true;
            }

            if (Enabled1c == 1 && Enabled2c == 1 && Enabled3c == 0)
            {
                checkBox1.Checked = true;
                checkBox2.Checked = true;
                checkBox3.Checked = false;
            }

            if (Enabled1c == 1 && Enabled2c == 0)
            {
                checkBox1.Checked = true;
                checkBox2.Checked = false;
                checkBox3.Checked = false;
            }

            if (Enabled1c == 0)
            {
                checkBox1.Checked = false;
                checkBox2.Checked = false;
                checkBox3.Checked = false;
            }

            if (Enabled1c == 2)           //Rayquaza shit
            {
                checkBox1.Checked = false;
                checkBox2.Checked = false;
                checkBox3.Checked = false;
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            var Form1 = Convert.ToInt16(numericUpDown1.Value);          //Convert box contents to int16
            var Form2 = Convert.ToInt16(numericUpDown4.Value);
            var Form3 = Convert.ToInt16(numericUpDown6.Value);
            string itembox1n = ((itembox1.SelectedItem.ToString()).Split(new string[] { " - " }, StringSplitOptions.None))[1];          //Special extra step for this
            string itembox2n = ((itembox2.SelectedItem.ToString()).Split(new string[] { " - " }, StringSplitOptions.None))[1];
            string itembox3n = ((itembox3.SelectedItem.ToString()).Split(new string[] { " - " }, StringSplitOptions.None))[1];
            var itembox1d = Convert.ToInt16(itembox1n);
            var itembox2d = Convert.ToInt16(itembox2n);
            var itembox3d = Convert.ToInt16(itembox3n);

            var Form1b = BitConverter.GetBytes(Form1);          //Convert int16 to bytes for writing
            var Form2b = BitConverter.GetBytes(Form2);
            var Form3b = BitConverter.GetBytes(Form3);
            var evoitem1 = BitConverter.GetBytes(itembox1d);
            var evoitem2 = BitConverter.GetBytes(itembox2d);
            var evoitem3 = BitConverter.GetBytes(itembox3d);

            BinaryWriter bw = new BinaryWriter(new FileStream(pathsource, FileMode.Open));          //Write Bytes to file

            if (checkBox1.Checked == true)         //Set checkbox values to write
            {
                bw.Seek(2, 0);
                bw.Write(1);
            }

            if (checkBox1.Checked == false)
            {
                bw.Seek(2, 0);
                bw.Write(0);
            }

            if (checkBox2.Checked == true)
            {
                bw.Seek(10, 0);
                bw.Write(1);
            }

            if (checkBox2.Checked == false)
            {
                bw.Seek(10, 0);
                bw.Write(0);
            }

            if (checkBox3.Checked == true)
            {
                bw.Seek(18, 0);
                bw.Write(1);
            }

            if (checkBox3.Checked == false)
            {
                bw.Seek(18, 0);
                bw.Write(0);
            }

            bw.Seek(4, 0);
            bw.Write(evoitem1);

            bw.Seek(12, 0);
            bw.Write(evoitem2);

            bw.Seek(20, 0);
            bw.Write(evoitem3);

            bw.Seek(0, 0);
            bw.Write(Form1b);

            bw.Seek(8, 0);
            bw.Write(Form2b);

            bw.Seek(16, 0);
            bw.Write(Form3b);

            bw.Close();

        }
    }
}