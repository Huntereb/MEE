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
        private string mode = "";
        private List<cbItem> monNames;

        private Control[] groupbox_spec = { };
        private Control[] forme_spec = { };
        private Control[] item_spec = { };
        private Control[] checkbox_spec = { };
        private Control[] label_spec = { };
        private Control[][] all_spec;
        private bool loaded = false;

        public MEE()            //All the initial settings
        {
            InitializeComponent();
            #region Intializations

            groupbox_spec = new Control[] {GB_MEvo1,GB_MEvo2,GB_MEvo3};
            item_spec = new Control[] { NUP_Item1, NUP_Item2, NUP_Item3 };
            forme_spec = new Control[] { NUP_Forme1, NUP_Forme2, NUP_Forme3 };
            checkbox_spec = new Control[] { CHK_MEvo1, CHK_MEvo2, CHK_MEvo3 };
            label_spec = new Control[] { LBL_Forme1, LBL_Item1, LBL_Item2, LBL_Item3, LBL_Forme2, LBL_Forme3, LBL_GameMode };
            all_spec = new Control[][] { groupbox_spec, item_spec, forme_spec, checkbox_spec, label_spec};

            ToolTip TT_Open = new ToolTip();
            TT_Open.AutoPopDelay = 5000;
            TT_Open.InitialDelay = 100;
            TT_Open.ReshowDelay = 500;
            TT_Open.ShowAlways = false;
            TT_Open.SetToolTip(B_Open, "The Mega Evolutions Garc is at \"a/1/9/3\" for OR/AS, and \"a/2/1/6\" for X/Y");
            #endregion          
        }

        private void B_Save_Click(object sender, EventArgs e)
        {
            string path = files[(int)CB_Species.SelectedValue];
            byte[] data = File.ReadAllBytes(path);
            for (int i = 0; i < 3; i++)
            {
                bool isChecked = ((CheckBox)checkbox_spec[i]).Checked;
                Array.Copy(BitConverter.GetBytes( isChecked ? (ushort)1 : (ushort)0), 0, data, 2 + i * 8, 2);
                if (isChecked)
                {
                    Array.Copy(BitConverter.GetBytes((ushort)((NumericUpDown)item_spec[i]).Value), 0, data, 4 + i * 8, 2);
                    Array.Copy(BitConverter.GetBytes((ushort)((NumericUpDown)forme_spec[i]).Value), 0, data, i * 8, 2);
                }
            }
            File.WriteAllBytes(path, data);
        }

        private void CHK_MEvo1_CheckedChanged(object sender, EventArgs e)          
        {
            groupbox_spec[0].Enabled = CHK_MEvo1.Checked;
        }

        private void CHK_MEvo2_CheckedChanged(object sender, EventArgs e)          
        {
            groupbox_spec[1].Enabled = CHK_MEvo2.Checked;
        }

        private void CHK_MEvo3_CheckedChanged(object sender, EventArgs e)
        {
            groupbox_spec[2].Enabled = CHK_MEvo3.Checked;
        }

        private void CB_Species_SelectedValueChanged(object sender, EventArgs e)
        {
            if (loaded)
            {
                if ((int)CB_Species.SelectedValue == 384) //Current Mon is Rayquaza
                {
                    MessageBox.Show("Rayquaza is special and uses a different activator for his evolution. If he knows Dragon Accent, he can Mega Evolve. Don't edit his evolution table if you want to keep this functionality.");
                }
                byte[] data = File.ReadAllBytes(files[(int)CB_Species.SelectedValue]);
                for (int i = 0; i < 3; i++)
                {
                    ((NumericUpDown)forme_spec[i]).Value = BitConverter.ToUInt16(data, i * 8);
                    ((NumericUpDown)item_spec[i]).Value = BitConverter.ToUInt16(data, 4 + i * 8);
                    ((CheckBox)checkbox_spec[i]).Checked = (BitConverter.ToUInt16(data, 2 + (i * 8)) == 1);
                }
            }
        }

        private void B_Open_Click(object sender, EventArgs e)
        {
            //Gotos were removed because goto is fucking terrible.
            FolderBrowserDialog fbd = new FolderBrowserDialog();            //Open a folder browser

            if (fbd.ShowDialog() == DialogResult.OK)
            {
                basePath = fbd.SelectedPath;
                files = System.IO.Directory.GetFiles(fbd.SelectedPath);
                if (files.Length == 799)            //Yell at the user if a file is larger or smaller than it should be
                {
                    this.mode = "X/Y";
                }
                else if (files.Length == 826)
                {
                    this.mode = "OR/AS";
                }
                else
                {
                    MessageBox.Show("The decrypted garc must contain 826 files (For OR/AS) or 799 files (For X/Y)!");
                    return;
                }
                for (int i = 0; i < files.Length; i++)
                {
                    FileInfo fi = new FileInfo(files[i]);
                    if (fi.Length != 0x18)
                    {
                        MessageBox.Show("File #"+i.ToString("000")+" is not the right length.");
                        return;
                    }
                }
                LBL_GameMode.Text += this.mode;

                string[] lines = Properties.Resources.mons.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None);
                monNames = new List<cbItem>();
                List<string> temp_list = new List<string>();
                for (int i = 0; i < files.Length; i++)
                {
                    temp_list.Add(lines[i]);
                }
                temp_list.Sort();
                foreach (string mon in temp_list)
                {
                    cbItem ncbi = new cbItem();
                    ncbi.Text = mon;
                    ncbi.Value = Array.IndexOf(lines, mon);
                    monNames.Add(ncbi);
                }         
                foreach(Control[] control_spec in all_spec)
                {
                    foreach (Control ctrl in control_spec)
                    {
                        ctrl.Enabled = true;
                    }
                }

                foreach (CheckBox CHK in checkbox_spec)
                {
                    CHK.Checked = true;
                    CHK.Checked = false;
                }

                CB_Species.DataSource = monNames;
                CB_Species.DisplayMember = "Text";
                CB_Species.ValueMember = "Value";
                CB_Species.SelectedValue = 0;

                B_Save.Enabled = true;
                CB_Species.Enabled = true;
                loaded = true;
            }
        }

        public class cbItem
        {
            public string Text { get; set; }
            public int Value { get; set; }

            public override string ToString()
            {
                return Text;
            }
        }

        private void CB_Species_SelectedIndexChanged(object sender, EventArgs e)
        {
            //This is no longer necessary.
        }
 
    }
}