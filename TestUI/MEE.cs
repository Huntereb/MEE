using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
        private byte[] personal = (byte[])Properties.Resources.ResourceManager.GetObject("personal");
        private string basePath;
        private string[] files;
        private string mode = "";
        private string[] forms;
        private string[] types = {"Normal",
"Fighting",
"Flying",
"Poison",
"Ground",
"Rock",
"Bug",
"Ghost",
"Steel",
"Fire",
"Water",
"Grass",
"Electric",
"Psychic",
"Ice",
"Dragon",
"Dark",
"Fairy"};
        private List<cbItem> monNames;

        private Control[] groupbox_spec = { };
        private Control[] forme_spec = { };
        private Control[] item_spec = { };
        private Control[] checkbox_spec = { };
        private Control[] label_spec = { };
        private Control[][] all_spec = { };
        private PictureBox[][] picturebox_spec = { };
        private bool loaded = false;
        private int basespecies = 0;

        public MEE()            //All the initial settings
        {
            InitializeComponent();
            #region Intializations

            groupbox_spec = new Control[] {GB_MEvo1,GB_MEvo2,GB_MEvo3};
            item_spec = new Control[] { CB_Item1, CB_Item2, CB_Item3 };
            forme_spec = new Control[] { CB_Forme1, CB_Forme2, CB_Forme3 };
            checkbox_spec = new Control[] { CHK_MEvo1, CHK_MEvo2, CHK_MEvo3 };
            label_spec = new Control[] { LBL_Forme1, LBL_Item1, LBL_Item2, LBL_Item3, LBL_Forme2, LBL_Forme3, LBL_GameMode };
            all_spec = new Control[][] { groupbox_spec, item_spec, forme_spec, checkbox_spec, label_spec };
            picturebox_spec = new PictureBox[][] { new PictureBox[] { PB_S1, PB_S2, PB_S3 }, new PictureBox[] { PB_M1, PB_M2, PB_M3 } };

            forms = Properties.Resources.forms.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None);

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
                    Array.Copy(BitConverter.GetBytes((ushort)((int)(((ComboBox)item_spec[i]).SelectedValue))), 0, data, 4 + i * 8, 2);
                    Array.Copy(BitConverter.GetBytes((ushort)((int)(((ComboBox)forme_spec[i]).SelectedIndex))), 0, data, i * 8, 2);
                }
                else
                {
                    Array.Copy(BitConverter.GetBytes((ushort)0), 0, data, i * 8, 2);
                    Array.Copy(BitConverter.GetBytes((ushort)0), 0, data, 4 + i * 8, 2);
                }
            }
            File.WriteAllBytes(path, data);
        }

        private void Prepare_Form_Boxes(object sender, EventArgs e)
        {
            foreach (ComboBox CB in forme_spec)
            {
                setForms((int)CB_Species.SelectedValue, CB);
            }
        }

        public void setForms(int species, ComboBox cb)
        {
            // Form Tables
            // 
            var form_unown = new[] {
                    new { Text = "A", Value = 0 },
                    new { Text = "B", Value = 1 },
                    new { Text = "C", Value = 2 },
                    new { Text = "D", Value = 3 },
                    new { Text = "E", Value = 4 },
                    new { Text = "F", Value = 5 },
                    new { Text = "G", Value = 6 },
                    new { Text = "H", Value = 7 },
                    new { Text = "I", Value = 8 },
                    new { Text = "J", Value = 9 },
                    new { Text = "K", Value = 10 },
                    new { Text = "L", Value = 11 },
                    new { Text = "M", Value = 12 },
                    new { Text = "N", Value = 13 },
                    new { Text = "O", Value = 14 },
                    new { Text = "P", Value = 15 },
                    new { Text = "Q", Value = 16 },
                    new { Text = "R", Value = 17 },
                    new { Text = "S", Value = 18 },
                    new { Text = "T", Value = 19 },
                    new { Text = "U", Value = 20 },
                    new { Text = "V", Value = 21 },
                    new { Text = "W", Value = 22 },
                    new { Text = "X", Value = 23 },
                    new { Text = "Y", Value = 24 },
                    new { Text = "Z", Value = 25 },
                    new { Text = "!", Value = 26 },
                    new { Text = "?", Value = 27 },
                };
            var form_castform = new[] {
                    new { Text = types[0], Value = 0 }, // Normal
                    new { Text = forms[789], Value = 1 }, // Sunny
                    new { Text = forms[790], Value = 2 }, // Rainy
                    new { Text = forms[791], Value = 3 }, // Snowy
                };
            var form_shellos = new[] {
                    new { Text = forms[422], Value = 0 }, // West
                    new { Text = forms[811], Value = 1 }, // East
                };
            var form_deoxys = new[] {
                    new { Text = types[0], Value = 0 }, // Normal
                    new { Text = forms[802], Value = 1 }, // Attack
                    new { Text = forms[803], Value = 2 }, // Defense
                    new { Text = forms[804], Value = 3 }, // Speed
                };
            var form_burmy = new[] {
                    new { Text = forms[412], Value = 0 }, // Plant
                    new { Text = forms[805], Value = 1 }, // Sandy
                    new { Text = forms[806], Value = 2 }, // Trash
                };
            var form_cherrim = new[] {
                    new { Text = forms[421], Value = 0 }, // Overcast
                    new { Text = forms[809], Value = 1 }, // Sunshine
                };
            var form_rotom = new[] {
                    new { Text = types[0], Value = 0 }, // Normal
                    new { Text = forms[817], Value = 1 }, // Heat
                    new { Text = forms[818], Value = 2 }, // Wash
                    new { Text = forms[819], Value = 3 }, // Frost
                    new { Text = forms[820], Value = 4 }, // Fan
                    new { Text = forms[821], Value = 5 }, // Mow
                };
            var form_giratina = new[] {
                    new { Text = forms[487], Value = 0 }, // Altered
                    new { Text = forms[822], Value = 1 }, // Origin
                };
            var form_shaymin = new[] {
                    new { Text = forms[492], Value = 0 }, // Land
                    new { Text = forms[823], Value = 1 }, // Sky
                };
            var form_arceus = new[] {
                    new { Text = types[0], Value = 0 }, // Normal
                    new { Text = types[1], Value = 1 }, // Fighting
                    new { Text = types[2], Value = 2 }, // Flying
                    new { Text = types[3], Value = 3 }, // Poison
                    new { Text = types[4], Value = 4 }, // etc
                    new { Text = types[5], Value = 5 },
                    new { Text = types[6], Value = 6 },
                    new { Text = types[7], Value = 7 },
                    new { Text = types[8], Value = 8 },
                    new { Text = types[9], Value = 9 },
                    new { Text = types[10], Value = 10 },
                    new { Text = types[11], Value = 11 },
                    new { Text = types[12], Value = 12 },
                    new { Text = types[13], Value = 13 },
                    new { Text = types[14], Value = 14 },
                    new { Text = types[15], Value = 15 },
                    new { Text = types[16], Value = 16 },
                    new { Text = types[17], Value = 17 },
                };
            var form_basculin = new[] {
                    new { Text = forms[550], Value = 0 }, // Red
                    new { Text = forms[842], Value = 1 }, // Blue
                };
            var form_darmanitan = new[] {
                    new { Text = forms[555], Value = 0 }, // Standard
                    new { Text = forms[843], Value = 1 }, // Zen
                };
            var form_deerling = new[] {
                    new { Text = forms[585], Value = 0 }, // Spring
                    new { Text = forms[844], Value = 1 }, // Summer
                    new { Text = forms[845], Value = 2 }, // Autumn
                    new { Text = forms[846], Value = 3 }, // Winter
                };
            var form_gender = new[] {
                    new { Text = "Male", Value = 0 }, // Male
                    new { Text = "Female", Value = 1 }, // Female
                };
            var form_therian = new[] {
                    new { Text = forms[641], Value = 0 }, // Incarnate
                    new { Text = forms[852], Value = 1 }, // Therian
                };
            var form_kyurem = new[] {
                    new { Text = types[0], Value = 0 }, // Normal
                    new { Text = forms[853], Value = 1 }, // White
                    new { Text = forms[854], Value = 2 }, // Black
                };
            var form_keldeo = new[] {
                    new { Text = forms[647], Value = 0 }, // Ordinary
                    new { Text = forms[855], Value = 1 }, // Resolute
                };
            var form_meloetta = new[] {
                    new { Text = forms[648], Value = 0 }, // Aria
                    new { Text = forms[856], Value = 1 }, // Pirouette
                };
            var form_genesect = new[] {
                    new { Text = types[0], Value = 0 }, // Normal
                    new { Text = types[10], Value = 1 }, // Douse
                    new { Text = types[12], Value = 2 }, // Shock
                    new { Text = types[9], Value = 3 }, // Burn
                    new { Text = types[14], Value = 4 }, // Chill
                };
            var form_flabebe = new[] {
                    new { Text = forms[669], Value = 0 }, // Red
                    new { Text = forms[884], Value = 1 }, // Yellow
                    new { Text = forms[885], Value = 2 }, // Orange
                    new { Text = forms[886], Value = 3 }, // Blue
                    new { Text = forms[887], Value = 4 }, // White
                };
            var form_floette = new[] {
                    new { Text = forms[669], Value = 0 }, // Red
                    new { Text = forms[884], Value = 1 }, // Yellow
                    new { Text = forms[885], Value = 2 }, // Orange
                    new { Text = forms[886], Value = 3 }, // Blue
                    new { Text = forms[887], Value = 4 }, // White
                    new { Text = forms[888], Value = 5 }, // Eternal
                };
            var form_furfrou = new[] {
                    new { Text = forms[676], Value = 0 }, // Natural
                    new { Text = forms[893], Value = 1 }, // Heart
                    new { Text = forms[894], Value = 2 }, // Star
                    new { Text = forms[895], Value = 3 }, // Diamond
                    new { Text = forms[896], Value = 4 }, // Deputante
                    new { Text = forms[897], Value = 5 }, // Matron
                    new { Text = forms[898], Value = 6 }, // Dandy
                    new { Text = forms[899], Value = 7 }, // La Reine
                    new { Text = forms[900], Value = 8 }, // Kabuki 
                    new { Text = forms[901], Value = 9 }, // Pharaoh
                };
            var form_aegislash = new[] {
                    new { Text = forms[681], Value = 0 }, // Shield
                    new { Text = forms[903], Value = 1 }, // Blade
                };
            var form_butterfly = new[] {
                    new { Text = forms[666], Value = 0 }, // Icy Snow
                    new { Text = forms[861], Value = 1 }, // Polar
                    new { Text = forms[862], Value = 2 }, // Tundra
                    new { Text = forms[863], Value = 3 }, // Continental 
                    new { Text = forms[864], Value = 4 }, // Garden
                    new { Text = forms[865], Value = 5 }, // Elegant
                    new { Text = forms[866], Value = 6 }, // Meadow
                    new { Text = forms[867], Value = 7 }, // Modern 
                    new { Text = forms[868], Value = 8 }, // Marine
                    new { Text = forms[869], Value = 9 }, // Archipelago
                    new { Text = forms[870], Value = 10 }, // High-Plains
                    new { Text = forms[871], Value = 11 }, // Sandstorm
                    new { Text = forms[872], Value = 12 }, // River
                    new { Text = forms[873], Value = 13 }, // Monsoon
                    new { Text = forms[874], Value = 14 }, // Savannah 
                    new { Text = forms[875], Value = 15 }, // Sun
                    new { Text = forms[876], Value = 16 }, // Ocean
                    new { Text = forms[877], Value = 17 }, // Jungle
                    new { Text = forms[878], Value = 18 }, // Fancy
                    new { Text = forms[879], Value = 19 }, // Poké Ball
                };
            var form_list = new[] {
                    new { Text = "", Value = 0}, // None
                };
            var form_pump = new[] {
                    new { Text = forms[904], Value = 0 }, // Small
                    new { Text = forms[710], Value = 1 }, // Average
                    new { Text = forms[905], Value = 2 }, // Large
                    new { Text = forms[907], Value = 3 }, // Super
                };
            var form_mega = new[] {
                    new { Text = types[0], Value = 0}, // Normal
                    new { Text = forms[723], Value = 1}, // Mega
                };
            var form_megaxy = new[] {
                    new { Text = types[0], Value = 0}, // Normal
                    new { Text = forms[724], Value = 1}, // Mega X
                    new { Text = forms[725], Value = 2}, // Mega Y
                };
            int[] mspec = { };
            var form_hoopa = new[] {
                new { Text = types[0], Value = 0}
            };
            var form_pikachu = new[] {
                new { Text = types[0], Value = 0}
            };
            var form_primal = new[] {
                new { Text = types[0], Value = 0}
            };

            if (this.mode == "OR/AS")
            {
                form_primal = new[] {
                    new { Text = types[0], Value = 0},
                    new { Text = forms[800], Value = 1},
                };
                form_hoopa = new[] {
                    new { Text = types[0], Value = 0},
                    new { Text = forms[912], Value = 1},
                };
                form_pikachu = new[] {
                    new { Text = types[0], Value = 0}, // Normal
                    new { Text = forms[729], Value = 1}, // Rockstar
                    new { Text = forms[730], Value = 2}, // Belle
                    new { Text = forms[731], Value = 3}, // Pop
                    new { Text = forms[732], Value = 4}, // PhD
                    new { Text = forms[733], Value = 5}, // Libre
                    new { Text = forms[734], Value = 6}, // Cosplay
                };
                
                mspec = new int[] {     // XY
                                   003, 009, 065, 094, 115, 127, 130, 142, 181, 212, 214, 229, 248, 257, 282, 303, 306, 308, 310, 354, 359, 380, 381, 445, 448, 460, 
                                // ORAS
                                015, 018, 080, 208, 254, 260, 302, 319, 323, 334, 362, 373, 376, 384, 428, 475, 531, 719,
                        };
            }
            else
            {
                mspec = new int[] {     // XY
                                   003, 009, 065, 094, 115, 127, 130, 142, 181, 212, 214, 229, 248, 257, 282, 303, 306, 308, 310, 354, 359, 380, 381, 445, 448, 460, 
                                // ORAS
                              //  015, 018, 080, 208, 254, 260, 302, 319, 323, 334, 362, 373, 376, 384, 428, 475, 531, 719,
               };
            }
            cb.DataSource = form_list;
            cb.DisplayMember = "Text";
            cb.ValueMember = "Value";

            // Mega List
            for (int i = 0; i < mspec.Length; i++)
            {
                if (mspec[i] == species)
                {
                    cb.DataSource = form_mega;
                    cb.Enabled = true; // Mega Form Selection
                    return;
                }
            }

            // MegaXY List
            if ((((species == 6) || isAltForm(6, species))) || (((species == 150) || isAltForm(150, species))))
            {
                cb.DataSource = form_megaxy;
                cb.Enabled = true; // Mega Form Selection
                return;
            }

            // Regular Form List
            if (this.mode == "OR/AS" && ((species == 025) || isAltForm(025, species))) { form_list = form_pikachu; }
            else if (((species == 550) || isAltForm(550, species))) { form_list = form_basculin; }
            else if (((species == 201) || isAltForm(201, species))) { form_list = form_unown; }
            else if (((species == 351) || isAltForm(351, species))) { form_list = form_castform; }
            else if (((species == 386) || isAltForm(386, species))) { form_list = form_deoxys; }
            else if (((species == 421) || isAltForm(421, species))) { form_list = form_cherrim; }
            else if (((species == 479) || isAltForm(479, species))) { form_list = form_rotom; }
            else if (((species == 487) || isAltForm(487, species))) { form_list = form_giratina; }
            else if (((species == 492) || isAltForm(492, species))) { form_list = form_shaymin; }
            else if (((species == 493) || isAltForm(493, species))) { form_list = form_arceus; }
            else if (((species == 555) || isAltForm(555, species))) { form_list = form_darmanitan; }
            else if (((species == 646) || isAltForm(646, species))) { form_list = form_kyurem; }
            else if (((species == 647) || isAltForm(647, species))) { form_list = form_keldeo; }
            else if (((species == 648) || isAltForm(648, species))) { form_list = form_meloetta; }
            else if (((species == 649) || isAltForm(649, species))) { form_list = form_genesect; }
            else if (((species == 676) || isAltForm(676, species))) { form_list = form_furfrou; }
            else if (((species == 681) || isAltForm(681, species))) { form_list = form_aegislash; }
            else if (((species == 670) || isAltForm(670, species))) { form_list = form_floette; }

            else if ((((species == 669) || isAltForm(669, species))) || (((species == 671) || isAltForm(671, species)))) { form_list = form_flabebe; }
            else if ((((species == 412) || isAltForm(412, species))) || (((species == 413) || isAltForm(413, species)))) { form_list = form_burmy; }
            else if ((((species == 422) || isAltForm(422, species))) || (((species == 423) || isAltForm(423, species)))) { form_list = form_shellos; }
            else if ((((species == 585) || isAltForm(585, species))) || (((species == 586) || isAltForm(586, species)))) { form_list = form_deerling; }
            else if ((((species == 710) || isAltForm(710, species))) || (((species == 711) || isAltForm(711, species)))) { form_list = form_pump; }

            else if ((((species == 666) || isAltForm(666, species))) || (((species == 665) || isAltForm(665, species))) || (((species == 664) || isAltForm(664, species)))) { form_list = form_butterfly; }
            else if ((((species == 592) || isAltForm(592, species))) || (((species == 593) || isAltForm(593, species))) || (((species == 678) || isAltForm(678, species)))) { form_list = form_gender; }
            else if ((((species == 641) || isAltForm(641, species))) || (((species == 642) || isAltForm(642, species))) || (((species == 645) || isAltForm(645, species)))) { form_list = form_therian; }

            // ORAS
            else if (this.mode == "OR/AS" && (((species == 382) || isAltForm(382, species)) || ((species == 383) || isAltForm(383, species)))) { form_list = form_primal; }
            else if (this.mode == "OR/AS" && ((species == 720) || isAltForm(720, species))) { form_list = form_hoopa; }

            else
            {
                cb.Enabled = false;
                return;
            };

            cb.DataSource = form_list;
            cb.Enabled = true;
        }

        private bool isAltForm(int species, int altspecies)
        {
            bool isAltForm = false;
            int dataOfs = species * 0xE;
            int AltFormCount = personal[dataOfs + 0xC];
            int AltformPointer = personal[dataOfs + 0xD];
            if (AltFormCount > 0 && AltformPointer>0)
            {
                int FormStart = 721 + AltformPointer;
                for (int i = 0; i < AltFormCount; i++)
                {
                    if (altspecies == FormStart + i)
                    {
                        isAltForm = true;
                        basespecies = species;
                    }
                }
            }
            return isAltForm;
        }

        private void CHK_Changed(object sender, EventArgs e)
        {
            for (int i = 0; i < groupbox_spec.Length;i++ )
            {
                groupbox_spec[i].Enabled = ((CheckBox)(checkbox_spec[i])).Checked;
                Update_PBs(i);
            }
        }

        private void CB_Species_SelectedValueChanged(object sender, EventArgs e)
        {
            if (loaded)
            {
                if (this.mode == "OR/AS" && (int)CB_Species.SelectedValue == 384) //Current Mon is Rayquaza
                {
                    MessageBox.Show("Rayquaza is special and uses a different activator for its evolution. If it knows Dragon Ascent, it can Mega Evolve. Don't edit its evolution table if you want to keep this functionality.");
                }
                byte[] data = File.ReadAllBytes(files[(int)CB_Species.SelectedValue]);
                basespecies = (int)CB_Species.SelectedValue;
                Prepare_Form_Boxes(sender, e);
                for (int i = 0; i < 3; i++)
                {
                    ((ComboBox)forme_spec[i]).SelectedIndex = BitConverter.ToUInt16(data, i * 8);
                    ((ComboBox)item_spec[i]).SelectedValue = (int)(BitConverter.ToUInt16(data, 4 + i * 8));
                    ((CheckBox)checkbox_spec[i]).Checked = (BitConverter.ToUInt16(data, 2 + (i * 8)) == 1);
                }
                Update_PBs();           
            }
        }

        private void Update_PBs(object sender, EventArgs e)
        {
            if (loaded)
            {
                for (int i = 0; i < checkbox_spec.Length; i++)
                {
                    CheckBox CB = (CheckBox)checkbox_spec[i];
                    if (CB.Checked)
                    {
                        UpdateImage(picturebox_spec[0][i], basespecies, 0, (int)((ComboBox)item_spec[i]).SelectedValue, 0, false);
                        UpdateImage(picturebox_spec[1][i], basespecies, (int)((ComboBox)forme_spec[i]).SelectedIndex, (int)((ComboBox)item_spec[i]).SelectedValue, 0, false);
                    }
                    else
                    {
                        UpdateImage(picturebox_spec[0][i], 0, 0, (int)((ComboBox)item_spec[i]).SelectedValue, 0, false);
                        UpdateImage(picturebox_spec[1][i], 0, 0, (int)((ComboBox)item_spec[i]).SelectedValue, 0, false);
                    }
                }
            }
        }

        private void Update_PBs(int i)
        {
            if (loaded)
            {
                 CheckBox CB = (CheckBox)checkbox_spec[i];
                 if (CB.Checked)
                 {
                     UpdateImage(picturebox_spec[0][i], basespecies, 0, (int)((ComboBox)item_spec[i]).SelectedValue, 0, false);
                     UpdateImage(picturebox_spec[1][i], basespecies, (int)((ComboBox)forme_spec[i]).SelectedIndex, (int)((ComboBox)item_spec[i]).SelectedValue, 0, false);
                 }
                 else
                 {
                     UpdateImage(picturebox_spec[0][i], 0, 0, (int)((ComboBox)item_spec[i]).SelectedValue, 0, false);
                     UpdateImage(picturebox_spec[1][i], 0, 0, (int)((ComboBox)item_spec[i]).SelectedValue, 0, false);
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
                LBL_GameMode.Text = "Game Mode: ";
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

                List<string> items = new List<string>(Properties.Resources.items.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None));
                List<string> sorted_items = new List<string>(Properties.Resources.items.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None));
                List<cbItem>[] item_lists = new List<cbItem>[item_spec.Length];
                for (int i = 0; i < item_lists.Length; i++)
                {
                    item_lists[i] = new List<cbItem>();
                }
                sorted_items.Sort();
                int limit = (this.mode == "X/Y" ? 718 : items.Count);
                for (int i = 0; i <items.Count; i++)
                {
                    
                    int index = items.IndexOf(sorted_items[i]);
                    if (index < limit)
                    {
                        cbItem ncbi = new cbItem();
                        ncbi.Text = sorted_items[i] + " - " + index.ToString("000");
                        ncbi.Value = index;
                        foreach (List<cbItem> l in item_lists)
                        {
                            l.Add(ncbi);
                        }
                    }
                    items[index] = "";
                }
                for (int i = 0; i < item_spec.Length; i++)
                {
                    ((ComboBox)item_spec[i]).DataSource = item_lists[i];
                    ((ComboBox)item_spec[i]).ValueMember = "Value";
                    ((ComboBox)item_spec[i]).DisplayMember = "Text";
                    ((ComboBox)item_spec[i]).SelectedValue = 0;
                }

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

        private void UpdateImage(PictureBox bpkx, int species, int form, int item, int gender, bool shiny)
        {
            string file = "";

            if (!bpkx.Enabled)
            {
                bpkx.Image = (Image)Properties.Resources.ResourceManager.GetObject("unknown");
                return;
            }

            if (species == 0)
            { bpkx.Image = (Image)Properties.Resources.ResourceManager.GetObject("_0"); }
            else
            {
                file = "_" + species.ToString();
                if (form > 0) // Alt Form Handling
                    file = file + "_" + form.ToString();
                else if ((gender == 1) && (species == 521 || species == 668))   // Unfezant & Pyroar
                    file = file = "_" + species.ToString() + "f";
            }

            Image baseImage = (Image)Properties.Resources.ResourceManager.GetObject(file);
            if (shiny)
            {   // Is Shiny
                // Redraw our image
                baseImage = LayerImage(baseImage, Properties.Resources.rare_icon, 0, 0, 0.7);
            }
            if (item > 0)
            {
                // Has Item
                Image itemimg = (Image)Properties.Resources.ResourceManager.GetObject("item_" + item.ToString());
                if (itemimg == null) itemimg = Properties.Resources.helditem;
                // Redraw
                baseImage = LayerImage(baseImage, itemimg, 22 + (15 - itemimg.Width) / 2, 15 + (15 - itemimg.Height), 1);
            }
            bpkx.Image = baseImage;
        }

        internal static Bitmap LayerImage(Image baseLayer, Image overLayer, int x, int y, double trans)
        {
            Bitmap overlayImage = (Bitmap)overLayer;
            Bitmap newImage = (Bitmap)baseLayer;
            if (baseLayer == null) return overlayImage;
            for (int i = 0; i < (overlayImage.Width * overlayImage.Height); i++)
            {
                Color newColor = overlayImage.GetPixel(i % (overlayImage.Width), i / (overlayImage.Width));
                Color oldColor = newImage.GetPixel(i % (overlayImage.Width) + x, i / (overlayImage.Width) + y);
                newColor = Color.FromArgb((int)((double)(newColor.A) * trans), newColor.R, newColor.G, newColor.B); // Apply transparency change
                // if (newColor.A != 0) // If Pixel isn't transparent, we'll overwrite the color.
                {
                    // if (newColor.A < 100) 
                    newColor = AlphaBlend(newColor, oldColor);
                    newImage.SetPixel(
                        i % (overlayImage.Width) + x,
                        i / (overlayImage.Width) + y,
                        newColor);
                }
            }
            return newImage;
        }

        internal static Color AlphaBlend(Color ForeGround, Color BackGround)
        {
            if (ForeGround.A == 0)
                return BackGround;
            if (BackGround.A == 0)
                return ForeGround;
            if (ForeGround.A == 255)
                return ForeGround;
            int Alpha = Convert.ToInt32(ForeGround.A) + 1;
            int B = Alpha * ForeGround.B + (255 - Alpha) * BackGround.B >> 8;
            int G = Alpha * ForeGround.G + (255 - Alpha) * BackGround.G >> 8;
            int R = Alpha * ForeGround.R + (255 - Alpha) * BackGround.R >> 8;
            int A = ForeGround.A;
            if (BackGround.A == 255)
                A = 255;
            if (A > 255)
                A = 255;
            if (R > 255)
                R = 255;
            if (G > 255)
                G = 255;
            if (B > 255)
                B = 255;
            return Color.FromArgb(Math.Abs(A), Math.Abs(R), Math.Abs(G), Math.Abs(B));
        }

        private void Update_PBs()
        {

        }
 
    }
}
