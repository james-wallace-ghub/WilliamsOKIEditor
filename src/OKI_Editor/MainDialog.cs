using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OKI_Editor
{
    public partial class MainDialog : Form
    {
        public MainDialog()
        {
            InitializeComponent();
        }

        public byte[] WPCROM { get; private set; }

        public byte[] U12 { get; private set; }
        public int U12Totalsize { get; private set; }

        public byte[] U13 { get; private set; }
        public int U13Totalsize { get; private set; }
        public bool U12Mirror { get; private set; }
        public bool U13Mirror { get; private set; }

        public Bank[] Banks { get; private set; }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void ImportLoad(object sender, EventArgs e)
        {
            ROMLoader rl = new ROMLoader();
            rl.ShowDialog();
            if (rl.DialogResult == DialogResult.OK)
            {

                Banks = new Bank[8];
                U12 = new byte[0x80000];
                U13 = new byte[0x80000];
                WPCROM = new byte[0x160000];
                U12Totalsize = 0;
                U13Totalsize = 0;

                foreach (TreeNode U12Node in rl.U12List.Nodes)
                {
                    String U12Name = U12Node.Text;
                    byte[] bytes = File.ReadAllBytes(U12Name);
                    Array.Copy(bytes, 0, U12, U12Totalsize, bytes.Length);

                    U12Totalsize += bytes.Length;
                }
                if (U12Totalsize < 0x80000)
                {
                    U12Mirror = true;
                    int tempsize = U12Totalsize;
                    int i = 0;
                    do
                    {
                        U12[tempsize + i] = U12[i];
                        U12Totalsize++;
                        i++;
                    }
                    while (U12Totalsize < 0x80000);
                }
                foreach (TreeNode U13Node in rl.U13List.Nodes)
                {
                    String U13Name = U13Node.Text;
                    byte[] bytes = File.ReadAllBytes(U13Name);
                    Array.Copy(bytes, 0, U13, U13Totalsize, bytes.Length);

                    U13Totalsize += bytes.Length;
                }
                if (U13Totalsize < 0x80000)
                {
                    U13Mirror = true;
                    int tempsize = U13Totalsize;
                    int i = 0;
                    do
                    {
                        U13[tempsize + i] = U13[i];
                        U13Totalsize++;
                        i++;
                    }
                    while (U13Totalsize < 0x80000);
                }
                Array.Copy(U12, WPCROM, U12.Length);
                Array.Copy(U13, 0, WPCROM, U12.Length, U13.Length);

                U12 = null;
                U13 = null;

                Banks[0] = new Bank(0, WPCROM, 0x40000);
                setCtrl0();

                if (U12Mirror == false)
                {
                    Banks[2] = new Bank(2, WPCROM, 0x20000);
                    //setCtrl2();
                    Banks[3] = new Bank(3, WPCROM, 0x00000);
                   // setCtrl3();
                }
                if (U13Mirror == false)
                {
                    Banks[4] = new Bank(4, WPCROM, 0xe0000);
                    //setCtrl4();
                    Banks[5] = new Bank(5, WPCROM, 0xc0000);
                   // setCtrl5();
                }
                Banks[6] = new Bank(6, WPCROM, 0xa0000);
                //setCtrl6();
                Banks[7] = new Bank(7, WPCROM, 0x80000);
                //setCtrl7();
            }
        }

        private void setCtrl0()
        {
            if (Banks[0].samples[0] != null)
            {
                this.B0_S1_Enable.Enabled = true;
                this.B0_S1_Enable.Checked = true;
                this.B0_S1_Export.Enabled = true;
                this.B0_S1_Import.Enabled = true;
                this.B0_S1_ID.Text = Banks[0].samples[0].id.ToString();
                int start = Banks[0].samples[0].start;
                int id = Banks[0].samples[0].id;
                this.B0_S1_ID.ReadOnly = true;
                foreach (Sample smp in Banks[0].samples)
                {
                    if (smp != null)
                    {
                        if (IsBetween(start, smp.start, smp.end))
                        {
                            if (Banks[0].samples[0].id > smp.id)
                            {
                                Banks[0].samples[smp.id].parents.Add(id);
                                Banks[0].samples[0].depends.Add(smp.id);
                                this.B0_S1_Export.Enabled = false;
                                this.B0_S1_Import.Enabled = false;
                                if (Banks[0].samples[0].depends.Count == 1)
                                {
                                    //find offset
                                    Banks[0].samples[0].offset =start - smp.start;
                                }
                            }
                        }
                    }
                }
                string deps = "";
                if (Banks[0].samples[0].depends != null)
                {
                    foreach (int dep in Banks[0].samples[0].depends)
                    {
                        deps += dep + ",";
                    }

                }
                this.B0_S1_Dep.Text = deps;
                this.B0_S1_Dep.ReadOnly = true;
                this.B0_S1_Off.Text = Banks[0].samples[0].offset.ToString("X");
                this.B0_S1_Off.ReadOnly = true;
                this.B0_S1_Len.Text = Banks[0].samples[0].length.ToString("X");
                if (Banks[0].samples[0].common == true)
                {
                    this.B0_S1_Len.Enabled = false;
                    this.B0_S1_Import.Enabled = false;
                }
                else
                {
                    this.B0_S1_Len.ReadOnly = true;
                }
            }
            if (Banks[0].samples[1] != null)
            {
                this.B0_S2_Enable.Enabled = true;
                this.B0_S2_Enable.Checked = true;
                this.B0_S2_Export.Enabled = true;
                this.B0_S2_Import.Enabled = true;
                this.B0_S2_ID.Text = Banks[0].samples[1].id.ToString();
                int start = Banks[0].samples[1].start;
                int id = Banks[0].samples[1].id;
                this.B0_S2_ID.ReadOnly = true;
                foreach (Sample smp in Banks[0].samples)
                {
                    if (smp != null)
                    {
                        if (IsBetween(start, smp.start, smp.end))
                        {
                            if (Banks[0].samples[1].id > smp.id)
                            {
                                Banks[0].samples[smp.id].parents.Add(id);
                                Banks[0].samples[1].depends.Add(smp.id);
                                this.B0_S2_Export.Enabled = false;
                                this.B0_S2_Import.Enabled = false;
                                if (Banks[0].samples[1].depends.Count == 1)
                                {
                                    //find offset
                                    Banks[0].samples[1].offset =start - smp.start;
                                }
                            }
                        }
                    }
                }
                string deps = "";
                if (Banks[0].samples[1].depends != null)
                {
                    foreach (int dep in Banks[0].samples[1].depends)
                    {
                        deps += dep + ",";
                    }

                }
                this.B0_S2_Dep.Text = deps;
                this.B0_S2_Dep.ReadOnly = true;
                this.B0_S2_Off.Text = Banks[0].samples[1].offset.ToString("X");
                this.B0_S2_Off.ReadOnly = true;
                this.B0_S2_Len.Text = Banks[0].samples[1].length.ToString("X");
                if (Banks[0].samples[1].common == true)
                {
                    this.B0_S2_Len.Enabled = false;
                    this.B0_S2_Import.Enabled = false;
                }
                else
                {
                    this.B0_S2_Len.ReadOnly = true;
                }
            }
            if (Banks[0].samples[2] != null)
            {
                this.B0_S3_Enable.Enabled = true;
                this.B0_S3_Enable.Checked = true;
                this.B0_S3_Export.Enabled = true;
                this.B0_S3_Import.Enabled = true;
                this.B0_S3_ID.Text = Banks[0].samples[2].id.ToString();
                int start = Banks[0].samples[2].start;
                int id = Banks[0].samples[2].id;
                this.B0_S3_ID.ReadOnly = true;
                foreach (Sample smp in Banks[0].samples)
                {
                    if (smp != null)
                    {
                        if (IsBetween(start, smp.start, smp.end))
                        {
                            if (Banks[0].samples[2].id > smp.id)
                            {
                                Banks[0].samples[smp.id].parents.Add(id);
                                Banks[0].samples[2].depends.Add(smp.id);
                                this.B0_S3_Export.Enabled = false;
                                this.B0_S3_Import.Enabled = false;
                                if (Banks[0].samples[2].depends.Count == 1)
                                {
                                    //find offset
                                    Banks[0].samples[2].offset =start - smp.start;
                                }
                            }
                        }
                    }
                }
                string deps = "";
                if (Banks[0].samples[2].depends != null)
                {
                    foreach (int dep in Banks[0].samples[2].depends)
                    {
                        deps += dep + ",";
                    }

                }
                this.B0_S3_Dep.Text = deps;
                this.B0_S3_Dep.ReadOnly = true;
                this.B0_S3_Off.Text = Banks[0].samples[2].offset.ToString("X");
                this.B0_S3_Off.ReadOnly = true;
                this.B0_S3_Len.Text = Banks[0].samples[2].length.ToString("X");
                if (Banks[0].samples[2].common == true)
                {
                    this.B0_S3_Len.Enabled = false;
                    this.B0_S3_Import.Enabled = false;
                }
                else
                {
                    this.B0_S3_Len.ReadOnly = true;
                }

            }
            if (Banks[0].samples[3] != null)
            {
                this.B0_S4_Enable.Enabled = true;
                this.B0_S4_Enable.Checked = true;
                this.B0_S4_Export.Enabled = true;
                this.B0_S4_Import.Enabled = true;
                this.B0_S4_ID.Text = Banks[0].samples[3].id.ToString();
                int start = Banks[0].samples[3].start;
                int id = Banks[0].samples[3].id;
                this.B0_S4_ID.ReadOnly = true;
                foreach (Sample smp in Banks[0].samples)
                {
                    if (smp != null)
                    {
                        if (IsBetween(start, smp.start, smp.end))
                        {
                            if (Banks[0].samples[3].id > smp.id)
                            {
                                Banks[0].samples[smp.id].parents.Add(id);
                                Banks[0].samples[3].depends.Add(smp.id);
                                this.B0_S4_Export.Enabled = false;
                                this.B0_S4_Import.Enabled = false;
                                if (Banks[0].samples[3].depends.Count == 1)
                                {
                                    //find offset
                                    Banks[0].samples[3].offset =start - smp.start;
                                }
                            }
                        }
                    }
                }
                string deps = "";
                if (Banks[0].samples[3].depends != null)
                {
                    foreach (int dep in Banks[0].samples[3].depends)
                    {
                        deps += dep + ",";
                    }

                }
                this.B0_S4_Dep.Text = deps;
                this.B0_S4_Dep.ReadOnly = true;
                this.B0_S4_Off.Text = Banks[0].samples[3].offset.ToString("X");
                this.B0_S4_Off.ReadOnly = true;
                this.B0_S4_Len.Text = Banks[0].samples[3].length.ToString("X");
                if (Banks[0].samples[3].common == true)
                {
                    this.B0_S4_Len.Enabled = false;
                    this.B0_S4_Import.Enabled = false;
                }
                else
                {
                    this.B0_S4_Len.ReadOnly = true;
                }
            }
            if (Banks[0].samples[4] != null)
            {
                this.B0_S5_Enable.Enabled = true;
                this.B0_S5_Enable.Checked = true;
                this.B0_S5_Export.Enabled = true;
                this.B0_S5_Import.Enabled = true;
                this.B0_S5_ID.Text = Banks[0].samples[4].id.ToString();
                int start = Banks[0].samples[4].start;
                int id = Banks[0].samples[4].id;
                this.B0_S5_ID.ReadOnly = true;
                foreach (Sample smp in Banks[0].samples)
                {
                    if (smp != null)
                    {
                        if (IsBetween(start, smp.start, smp.end))
                        {
                            if (Banks[0].samples[4].id > smp.id)
                            {
                                Banks[0].samples[smp.id].parents.Add(id);
                                Banks[0].samples[4].depends.Add(smp.id);
                                this.B0_S5_Export.Enabled = false;
                                this.B0_S5_Import.Enabled = false;
                                if (Banks[0].samples[4].depends.Count == 1)
                                {
                                    //find offset
                                    Banks[0].samples[4].offset =start - smp.start;
                                }
                            }
                        }
                    }
                }
                string deps = "";
                if (Banks[0].samples[4].depends != null)
                {
                    foreach (int dep in Banks[0].samples[4].depends)
                    {
                        deps += dep + ",";
                    }

                }
                this.B0_S5_Dep.Text = deps;
                this.B0_S5_Dep.ReadOnly = true;
                this.B0_S5_Off.Text = Banks[0].samples[4].offset.ToString("X");
                this.B0_S5_Off.ReadOnly = true;
                this.B0_S5_Len.Text = Banks[0].samples[4].length.ToString("X");
                if (Banks[0].samples[4].common == true)
                {
                    this.B0_S5_Len.Enabled = false;
                    this.B0_S5_Import.Enabled = false;
                }
                else
                {
                    this.B0_S5_Len.ReadOnly = true;
                }
            }
            if (Banks[0].samples[5] != null)
            {
                this.B0_S6_Enable.Enabled = true;
                this.B0_S6_Enable.Checked = true;
                this.B0_S6_Export.Enabled = true;
                this.B0_S6_Import.Enabled = true;
                this.B0_S6_ID.Text = Banks[0].samples[5].id.ToString();
                int start = Banks[0].samples[5].start;
                int id = Banks[0].samples[5].id;
                this.B0_S6_ID.ReadOnly = true;
                foreach (Sample smp in Banks[0].samples)
                {
                    if (smp != null)
                    {
                        if (IsBetween(start, smp.start, smp.end))
                        {
                            if (Banks[0].samples[5].id > smp.id)
                            {
                                Banks[0].samples[smp.id].parents.Add(id);
                                Banks[0].samples[5].depends.Add(smp.id);
                                this.B0_S6_Export.Enabled = false;
                                this.B0_S6_Import.Enabled = false;
                                if (Banks[0].samples[5].depends.Count == 1)
                                {
                                    //find offset
                                    Banks[0].samples[5].offset =start - smp.start;
                                }
                            }
                        }
                    }
                }
                string deps = "";
                if (Banks[0].samples[5].depends != null)
                {
                    foreach (int dep in Banks[0].samples[5].depends)
                    {
                        deps += dep + ",";
                    }

                }
                this.B0_S6_Dep.Text = deps;
                this.B0_S6_Dep.ReadOnly = true;
                this.B0_S6_Off.Text = Banks[0].samples[5].offset.ToString("X");
                this.B0_S6_Off.ReadOnly = true;
                this.B0_S6_Len.Text = Banks[0].samples[5].length.ToString("X");
                if (Banks[0].samples[5].common == true)
                {
                    this.B0_S6_Len.Enabled = false;
                    this.B0_S6_Import.Enabled = false;
                }
                else
                {
                    this.B0_S6_Len.ReadOnly = true;
                }
            }
            if (Banks[0].samples[6] != null)
            {
                this.B0_S7_Enable.Enabled = true;
                this.B0_S7_Enable.Checked = true;
                this.B0_S7_Export.Enabled = true;
                this.B0_S7_Import.Enabled = true;
                this.B0_S7_ID.Text = Banks[0].samples[6].id.ToString();
                int start = Banks[0].samples[6].start;
                int id = Banks[0].samples[6].id;
                this.B0_S7_ID.ReadOnly = true;
                foreach (Sample smp in Banks[0].samples)
                {
                    if (smp != null)
                    {
                        if (IsBetween(start, smp.start, smp.end))
                        {
                            if (Banks[0].samples[6].id > smp.id)
                            {
                                Banks[0].samples[smp.id].parents.Add(id);
                                Banks[0].samples[6].depends.Add(smp.id);
                                this.B0_S7_Export.Enabled = false;
                                this.B0_S7_Import.Enabled = false;
                                if (Banks[0].samples[6].depends.Count == 1)
                                {
                                    //find offset
                                    Banks[0].samples[6].offset =start - smp.start;
                                }
                            }
                        }
                    }
                }
                string deps = "";
                if (Banks[0].samples[6].depends != null)
                {
                    foreach (int dep in Banks[0].samples[6].depends)
                    {
                        deps += dep + ",";
                    }

                }
                this.B0_S7_Dep.Text = deps;
                this.B0_S7_Dep.ReadOnly = true;
                this.B0_S7_Off.Text = Banks[0].samples[6].offset.ToString("X");
                this.B0_S7_Off.ReadOnly = true;
                this.B0_S7_Len.Text = Banks[0].samples[6].length.ToString("X");
                if (Banks[0].samples[6].common == true)
                {
                    this.B0_S7_Len.Enabled = false;
                    this.B0_S7_Import.Enabled = false;
                }
                else
                {
                    this.B0_S7_Len.ReadOnly = true;
                }
            }
            if (Banks[0].samples[7] != null)
            {
                this.B0_S8_Enable.Enabled = true;
                this.B0_S8_Enable.Checked = true;
                this.B0_S8_Export.Enabled = true;
                this.B0_S8_Import.Enabled = true;
                this.B0_S8_ID.Text = Banks[0].samples[7].id.ToString();
                int start = Banks[0].samples[7].start;
                int id = Banks[0].samples[7].id;
                this.B0_S8_ID.ReadOnly = true;
                foreach (Sample smp in Banks[0].samples)
                {
                    if (smp != null)
                    {
                        if (IsBetween(start, smp.start, smp.end))
                        {
                            if (Banks[0].samples[7].id > smp.id)
                            {
                                Banks[0].samples[smp.id].parents.Add(id);
                                Banks[0].samples[7].depends.Add(smp.id);
                                this.B0_S8_Export.Enabled = false;
                                this.B0_S8_Import.Enabled = false;
                                if (Banks[0].samples[7].depends.Count == 1)
                                {
                                    //find offset
                                    Banks[0].samples[7].offset =start - smp.start;
                                }
                            }
                        }
                    }
                }
                string deps = "";
                if (Banks[0].samples[7].depends != null)
                {
                    foreach (int dep in Banks[0].samples[7].depends)
                    {
                        deps += dep + ",";
                    }

                }
                this.B0_S8_Dep.Text = deps;
                this.B0_S8_Dep.ReadOnly = true;
                this.B0_S8_Off.Text = Banks[0].samples[7].offset.ToString("X");
                this.B0_S8_Off.ReadOnly = true;
                this.B0_S8_Len.Text = Banks[0].samples[7].length.ToString("X");
                if (Banks[0].samples[7].common == true)
                {
                    this.B0_S8_Len.Enabled = false;
                    this.B0_S8_Import.Enabled = false;
                }
                else
                {
                    this.B0_S8_Len.ReadOnly = true;
                }
            }
            if (Banks[0].samples[8] != null)
            {
                this.B0_S9_Enable.Enabled = true;
                this.B0_S9_Enable.Checked = true;
                this.B0_S9_Export.Enabled = true;
                this.B0_S9_Import.Enabled = true;
                this.B0_S9_ID.Text = Banks[0].samples[8].id.ToString();
                int start = Banks[0].samples[8].start;
                int id = Banks[0].samples[8].id;
                this.B0_S9_ID.ReadOnly = true;
                foreach (Sample smp in Banks[0].samples)
                {
                    if (smp != null)
                    {
                        if (IsBetween(start, smp.start, smp.end))
                        {
                            if (Banks[0].samples[8].id > smp.id)
                            {
                                Banks[0].samples[smp.id].parents.Add(id);
                                Banks[0].samples[8].depends.Add(smp.id);
                                this.B0_S9_Export.Enabled = false;
                                this.B0_S9_Import.Enabled = false;
                                if (Banks[0].samples[8].depends.Count == 1)
                                {
                                    //find offset
                                    Banks[0].samples[8].offset =start - smp.start;
                                }
                            }
                        }
                    }
                }
                string deps = "";
                if (Banks[0].samples[8].depends != null)
                {
                    foreach (int dep in Banks[0].samples[8].depends)
                    {
                        deps += dep + ",";
                    }

                }
                this.B0_S9_Dep.Text = deps;
                this.B0_S9_Dep.ReadOnly = true;
                this.B0_S9_Off.Text = Banks[0].samples[8].offset.ToString("X");
                this.B0_S9_Off.ReadOnly = true;
                this.B0_S9_Len.Text = Banks[0].samples[8].length.ToString("X");
                if (Banks[0].samples[8].common == true)
                {
                    this.B0_S9_Len.Enabled = false;
                    this.B0_S9_Import.Enabled = false;
                }
                else
                {
                    this.B0_S9_Len.ReadOnly = true;
                }
            }
            if (Banks[0].samples[9] != null)
            {
                this.B0_S10_Enable.Enabled = true;
                this.B0_S10_Enable.Checked = true;
                this.B0_S10_Export.Enabled = true;
                this.B0_S10_Import.Enabled = true;
                this.B0_S10_ID.Text = Banks[0].samples[9].id.ToString();
                int start = Banks[0].samples[9].start;
                int id = Banks[0].samples[9].id;
                this.B0_S10_ID.ReadOnly = true;
                foreach (Sample smp in Banks[0].samples)
                {
                    if (smp != null)
                    {
                        if (IsBetween(start, smp.start, smp.end))
                        {
                            if (Banks[0].samples[9].id > smp.id)
                            {
                                Banks[0].samples[smp.id].parents.Add(id);
                                Banks[0].samples[9].depends.Add(smp.id);
                                this.B0_S10_Export.Enabled = false;
                                this.B0_S10_Import.Enabled = false;
                                if (Banks[0].samples[9].depends.Count == 1)
                                {
                                    //find offset
                                    Banks[0].samples[9].offset =start - smp.start;
                                }
                            }
                        }
                    }
                }
                string deps = "";
                if (Banks[0].samples[9].depends != null)
                {
                    foreach (int dep in Banks[0].samples[9].depends)
                    {
                        deps += dep + ",";
                    }

                }
                this.B0_S10_Dep.Text = deps;
                this.B0_S10_Dep.ReadOnly = true;
                this.B0_S10_Off.Text = Banks[0].samples[9].offset.ToString("X");
                this.B0_S10_Off.ReadOnly = true;
                this.B0_S10_Len.Text = Banks[0].samples[9].length.ToString("X");
                if (Banks[0].samples[9].common == true)
                {
                    this.B0_S10_Len.Enabled = false;
                    this.B0_S10_Import.Enabled = false;
                }
                else
                {
                    this.B0_S10_Len.ReadOnly = true;
                }
            }
            if (Banks[0].samples[10] != null)
            {
                this.B0_S11_Enable.Enabled = true;
                this.B0_S11_Enable.Checked = true;
                this.B0_S11_Export.Enabled = true;
                this.B0_S11_Import.Enabled = true;
                this.B0_S11_ID.Text = Banks[0].samples[10].id.ToString();
                int start = Banks[0].samples[10].start;
                int id = Banks[0].samples[10].id;
                this.B0_S11_ID.ReadOnly = true;
                foreach (Sample smp in Banks[0].samples)
                {
                    if (smp != null)
                    {
                        if (IsBetween(start, smp.start, smp.end))
                        {
                            if (Banks[0].samples[10].id > smp.id)
                            {
                                Banks[0].samples[smp.id].parents.Add(id);
                                Banks[0].samples[10].depends.Add(smp.id);
                                this.B0_S11_Export.Enabled = false;
                                this.B0_S11_Import.Enabled = false;
                                if (Banks[0].samples[10].depends.Count == 1)
                                {
                                    //find offset
                                    Banks[0].samples[10].offset =start - smp.start;
                                }
                            }
                        }
                    }
                }
                string deps = "";
                if (Banks[0].samples[10].depends != null)
                {
                    foreach (int dep in Banks[0].samples[10].depends)
                    {
                        deps += dep + ",";
                    }

                }
                this.B0_S11_Dep.Text = deps;
                this.B0_S11_Dep.ReadOnly = true;
                this.B0_S11_Off.Text = Banks[0].samples[10].offset.ToString("X");
                this.B0_S11_Off.ReadOnly = true;
                this.B0_S11_Len.Text = Banks[0].samples[10].length.ToString("X");
                if (Banks[0].samples[10].common == true)
                {
                    this.B0_S11_Len.Enabled = false;
                    this.B0_S11_Import.Enabled = false;
                }
                else
                {
                    this.B0_S11_Len.ReadOnly = true;
                }
            }
            if (Banks[0].samples[11] != null)
            {
                this.B0_S12_Enable.Enabled = true;
                this.B0_S12_Enable.Checked = true;
                this.B0_S12_Export.Enabled = true;
                this.B0_S12_Import.Enabled = true;
                this.B0_S12_ID.Text = Banks[0].samples[11].id.ToString();
                int start = Banks[0].samples[11].start;
                int id = Banks[0].samples[11].id;
                this.B0_S12_ID.ReadOnly = true;
                foreach (Sample smp in Banks[0].samples)
                {
                    if (smp != null)
                    {
                        if (IsBetween(start, smp.start, smp.end))
                        {
                            if (Banks[0].samples[11].id > smp.id)
                            {
                                Banks[0].samples[smp.id].parents.Add(id);
                                Banks[0].samples[11].depends.Add(smp.id);
                                this.B0_S12_Export.Enabled = false;
                                this.B0_S12_Import.Enabled = false;
                                if (Banks[0].samples[11].depends.Count == 1)
                                {
                                    //find offset
                                    Banks[0].samples[11].offset =start - smp.start;
                                }
                            }
                        }
                    }
                }
                string deps = "";
                if (Banks[0].samples[11].depends != null)
                {
                    foreach (int dep in Banks[0].samples[11].depends)
                    {
                        deps += dep + ",";
                    }

                }
                this.B0_S12_Dep.Text = deps;
                this.B0_S12_Dep.ReadOnly = true;
                this.B0_S12_Off.Text = Banks[0].samples[11].offset.ToString("X");
                this.B0_S12_Off.ReadOnly = true;
                this.B0_S12_Len.Text = Banks[0].samples[11].length.ToString("X");
                if (Banks[0].samples[11].common == true)
                {
                    this.B0_S12_Len.Enabled = false;
                    this.B0_S12_Import.Enabled = false;
                }
                else
                {
                    this.B0_S12_Len.ReadOnly = true;
                }
            }
            if (Banks[0].samples[12] != null)
            {
                this.B0_S13_Enable.Enabled = true;
                this.B0_S13_Enable.Checked = true;
                this.B0_S13_Export.Enabled = true;
                this.B0_S13_Import.Enabled = true;
                this.B0_S13_ID.Text = Banks[0].samples[12].id.ToString();
                int start = Banks[0].samples[12].start;
                int id = Banks[0].samples[12].id;
                this.B0_S13_ID.ReadOnly = true;
                foreach (Sample smp in Banks[0].samples)
                {
                    if (smp != null)
                    {
                        if (IsBetween(start, smp.start, smp.end))
                        {
                            if (Banks[0].samples[12].id > smp.id)
                            {
                                Banks[0].samples[smp.id].parents.Add(id);
                                Banks[0].samples[12].depends.Add(smp.id);
                                this.B0_S13_Export.Enabled = false;
                                this.B0_S13_Import.Enabled = false;
                                if (Banks[0].samples[12].depends.Count == 1)
                                {
                                    //find offset
                                    Banks[0].samples[12].offset =start - smp.start;
                                }
                            }
                        }
                    }
                }
                string deps = "";
                if (Banks[0].samples[12].depends != null)
                {
                    foreach (int dep in Banks[0].samples[12].depends)
                    {
                        deps += dep + ",";
                    }

                }
                this.B0_S13_Dep.Text = deps;
                this.B0_S13_Dep.ReadOnly = true;
                this.B0_S13_Off.Text = Banks[0].samples[12].offset.ToString("X");
                this.B0_S13_Off.ReadOnly = true;
                this.B0_S13_Len.Text = Banks[0].samples[12].length.ToString("X");
                if (Banks[0].samples[12].common == true)
                {
                    this.B0_S13_Len.Enabled = false;
                    this.B0_S13_Import.Enabled = false;
                }
                else
                {
                    this.B0_S13_Len.ReadOnly = true;
                }

            }
            if (Banks[0].samples[13] != null)
            {
                this.B0_S14_Enable.Enabled = true;
                this.B0_S14_Enable.Checked = true;
                this.B0_S14_Export.Enabled = true;
                this.B0_S14_Import.Enabled = true;
                this.B0_S14_ID.Text = Banks[0].samples[13].id.ToString();
                int start = Banks[0].samples[13].start;
                int id = Banks[0].samples[13].id;
                this.B0_S14_ID.ReadOnly = true;
                foreach (Sample smp in Banks[0].samples)
                {
                    if (smp != null)
                    {
                        if (IsBetween(start, smp.start, smp.end))
                        {
                            if (Banks[0].samples[13].id > smp.id)
                            {
                                Banks[0].samples[smp.id].parents.Add(id);
                                Banks[0].samples[13].depends.Add(smp.id);
                                this.B0_S14_Export.Enabled = false;
                                this.B0_S14_Import.Enabled = false;
                                if (Banks[0].samples[13].depends.Count == 1)
                                {
                                    //find offset
                                    Banks[0].samples[13].offset =start - smp.start;
                                }
                            }
                        }
                    }
                }
                string deps = "";
                if (Banks[0].samples[13].depends != null)
                {
                    foreach (int dep in Banks[0].samples[13].depends)
                    {
                        deps += dep + ",";
                    }

                }
                this.B0_S14_Dep.Text = deps;
                this.B0_S14_Dep.ReadOnly = true;
                this.B0_S14_Off.Text = Banks[0].samples[13].offset.ToString("X");
                this.B0_S14_Off.ReadOnly = true;
                this.B0_S14_Len.Text = Banks[0].samples[13].length.ToString("X");
                if (Banks[0].samples[13].common == true)
                {
                    this.B0_S14_Len.Enabled = false;
                    this.B0_S14_Import.Enabled = false;
                }
                else
                {
                    this.B0_S14_Len.ReadOnly = true;
                }
            }
            if (Banks[0].samples[14] != null)
            {
                this.B0_S15_Enable.Enabled = true;
                this.B0_S15_Enable.Checked = true;
                this.B0_S15_Export.Enabled = true;
                this.B0_S15_Import.Enabled = true;
                this.B0_S15_ID.Text = Banks[0].samples[14].id.ToString();
                int start = Banks[0].samples[14].start;
                int id = Banks[0].samples[14].id;
                this.B0_S15_ID.ReadOnly = true;
                foreach (Sample smp in Banks[0].samples)
                {
                    if (smp != null)
                    {
                        if (IsBetween(start, smp.start, smp.end))
                        {
                            if (Banks[0].samples[14].id > smp.id)
                            {
                                Banks[0].samples[smp.id].parents.Add(id);
                                Banks[0].samples[14].depends.Add(smp.id);
                                this.B0_S15_Export.Enabled = false;
                                this.B0_S15_Import.Enabled = false;
                                if (Banks[0].samples[14].depends.Count == 1)
                                {
                                    //find offset
                                    Banks[0].samples[14].offset =start - smp.start;
                                }
                            }
                        }
                    }
                }
                string deps = "";
                if (Banks[0].samples[14].depends != null)
                {
                    foreach (int dep in Banks[0].samples[14].depends)
                    {
                        deps += dep + ",";
                    }

                }
                this.B0_S15_Dep.Text = deps;
                this.B0_S15_Dep.ReadOnly = true;
                this.B0_S15_Off.Text = Banks[0].samples[14].offset.ToString("X");
                this.B0_S15_Off.ReadOnly = true;
                this.B0_S15_Len.Text = Banks[0].samples[14].length.ToString("X");
                if (Banks[0].samples[14].common == true)
                {
                    this.B0_S15_Len.Enabled = false;
                    this.B0_S15_Import.Enabled = false;
                }
                else
                {
                    this.B0_S15_Len.ReadOnly = true;
                }
            }
            if (Banks[0].samples[15] != null)
            {
                this.B0_S16_Enable.Enabled = true;
                this.B0_S16_Enable.Checked = true;
                this.B0_S16_Export.Enabled = true;
                this.B0_S16_Import.Enabled = true;
                this.B0_S16_ID.Text = Banks[0].samples[15].id.ToString();
                int start = Banks[0].samples[15].start;
                int id = Banks[0].samples[15].id;
                this.B0_S16_ID.ReadOnly = true;
                foreach (Sample smp in Banks[0].samples)
                {
                    if (smp != null)
                    {
                        if (IsBetween(start, smp.start, smp.end))
                        {
                            if (Banks[0].samples[15].id > smp.id)
                            {
                                Banks[0].samples[smp.id].parents.Add(id);
                                Banks[0].samples[15].depends.Add(smp.id);
                                this.B0_S16_Export.Enabled = false;
                                this.B0_S16_Import.Enabled = false;
                                if (Banks[0].samples[15].depends.Count == 1)
                                {
                                    //find offset
                                    Banks[0].samples[15].offset =start - smp.start;
                                }
                            }
                        }
                    }
                }
                string deps = "";
                if (Banks[0].samples[15].depends != null)
                {
                    foreach (int dep in Banks[0].samples[15].depends)
                    {
                        deps += dep + ",";
                    }

                }
                this.B0_S16_Dep.Text = deps;
                this.B0_S16_Dep.ReadOnly = true;
                this.B0_S16_Off.Text = Banks[0].samples[15].offset.ToString("X");
                this.B0_S16_Off.ReadOnly = true;
                this.B0_S16_Len.Text = Banks[0].samples[15].length.ToString("X");
                if (Banks[0].samples[15].common == true)
                {
                    this.B0_S16_Len.Enabled = false;
                    this.B0_S16_Import.Enabled = false;
                }
                else
                {
                    this.B0_S16_Len.ReadOnly = true;
                }
            }
            if (Banks[0].samples[16] != null)
            {
                this.B0_S17_Enable.Enabled = true;
                this.B0_S17_Enable.Checked = true;
                this.B0_S17_Export.Enabled = true;
                this.B0_S17_Import.Enabled = true;
                this.B0_S17_ID.Text = Banks[0].samples[16].id.ToString();
                int start = Banks[0].samples[16].start;
                int id = Banks[0].samples[16].id;
                this.B0_S17_ID.ReadOnly = true;
                foreach (Sample smp in Banks[0].samples)
                {
                    if (smp != null)
                    {
                        if (IsBetween(start, smp.start, smp.end))
                        {
                            if (Banks[0].samples[16].id > smp.id)
                            {
                                Banks[0].samples[smp.id].parents.Add(id);
                                Banks[0].samples[16].depends.Add(smp.id);
                                this.B0_S17_Export.Enabled = false;
                                this.B0_S17_Import.Enabled = false;
                                if (Banks[0].samples[16].depends.Count == 1)
                                {
                                    //find offset
                                    Banks[0].samples[16].offset =start - smp.start;
                                }
                            }
                        }
                    }
                }
                string deps = "";
                if (Banks[0].samples[16].depends != null)
                {
                    foreach (int dep in Banks[0].samples[16].depends)
                    {
                        deps += dep + ",";
                    }

                }
                this.B0_S17_Dep.Text = deps;
                this.B0_S17_Dep.ReadOnly = true;
                this.B0_S17_Off.Text = Banks[0].samples[16].offset.ToString("X");
                this.B0_S17_Off.ReadOnly = true;
                this.B0_S17_Len.Text = Banks[0].samples[16].length.ToString("X");
                if (Banks[0].samples[16].common == true)
                {
                    this.B0_S17_Len.Enabled = false;
                    this.B0_S17_Import.Enabled = false;
                }
                else
                {
                    this.B0_S17_Len.ReadOnly = true;
                }
            }
            if (Banks[0].samples[17] != null)
            {
                this.B0_S18_Enable.Enabled = true;
                this.B0_S18_Enable.Checked = true;
                this.B0_S18_Export.Enabled = true;
                this.B0_S18_Import.Enabled = true;
                this.B0_S18_ID.Text = Banks[0].samples[17].id.ToString();
                int start = Banks[0].samples[17].start;
                int id = Banks[0].samples[17].id;
                this.B0_S18_ID.ReadOnly = true;
                foreach (Sample smp in Banks[0].samples)
                {
                    if (smp != null)
                    {
                        if (IsBetween(start, smp.start, smp.end))
                        {
                            if (Banks[0].samples[17].id > smp.id)
                            {
                                Banks[0].samples[smp.id].parents.Add(id);
                                Banks[0].samples[17].depends.Add(smp.id);
                                this.B0_S18_Export.Enabled = false;
                                this.B0_S18_Import.Enabled = false;
                                if (Banks[0].samples[17].depends.Count == 1)
                                {
                                    //find offset
                                    Banks[0].samples[17].offset =start - smp.start;
                                }
                            }
                        }
                    }
                }
                string deps = "";
                if (Banks[0].samples[17].depends != null)
                {
                    foreach (int dep in Banks[0].samples[17].depends)
                    {
                        deps += dep + ",";
                    }

                }
                this.B0_S18_Dep.Text = deps;
                this.B0_S18_Dep.ReadOnly = true;
                this.B0_S18_Off.Text = Banks[0].samples[17].offset.ToString("X");
                this.B0_S18_Off.ReadOnly = true;
                this.B0_S18_Len.Text = Banks[0].samples[17].length.ToString("X");
                if (Banks[0].samples[17].common == true)
                {
                    this.B0_S18_Len.Enabled = false;
                    this.B0_S18_Import.Enabled = false;
                }
                else
                {
                    this.B0_S18_Len.ReadOnly = true;
                }
            }
            if (Banks[0].samples[18] != null)
            {
                this.B0_S19_Enable.Enabled = true;
                this.B0_S19_Enable.Checked = true;
                this.B0_S19_Export.Enabled = true;
                this.B0_S19_Import.Enabled = true;
                this.B0_S19_ID.Text = Banks[0].samples[18].id.ToString();
                int start = Banks[0].samples[18].start;
                int id = Banks[0].samples[18].id;
                this.B0_S19_ID.ReadOnly = true;
                foreach (Sample smp in Banks[0].samples)
                {
                    if (smp != null)
                    {
                        if (IsBetween(start, smp.start, smp.end))
                        {
                            if (Banks[0].samples[18].id > smp.id)
                            {
                                Banks[0].samples[smp.id].parents.Add(id);
                                Banks[0].samples[18].depends.Add(smp.id);
                                this.B0_S19_Export.Enabled = false;
                                this.B0_S19_Import.Enabled = false;
                                if (Banks[0].samples[18].depends.Count == 1)
                                {
                                    //find offset
                                    Banks[0].samples[18].offset =start - smp.start;
                                }
                            }
                        }
                    }
                }
                string deps = "";
                if (Banks[0].samples[18].depends != null)
                {
                    foreach (int dep in Banks[0].samples[18].depends)
                    {
                        deps += dep + ",";
                    }

                }
                this.B0_S19_Dep.Text = deps;
                this.B0_S19_Dep.ReadOnly = true;
                this.B0_S19_Off.Text = Banks[0].samples[18].offset.ToString("X");
                this.B0_S19_Off.ReadOnly = true;
                this.B0_S19_Len.Text = Banks[0].samples[18].length.ToString("X");
                if (Banks[0].samples[18].common == true)
                {
                    this.B0_S19_Len.Enabled = false;
                    this.B0_S19_Import.Enabled = false;
                }
                else
                {
                    this.B0_S19_Len.ReadOnly = true;
                }
            }
            if (Banks[0].samples[19] != null)
            {
                this.B0_S20_Enable.Enabled = true;
                this.B0_S20_Enable.Checked = true;
                this.B0_S20_Export.Enabled = true;
                this.B0_S20_Import.Enabled = true;
                this.B0_S20_ID.Text = Banks[0].samples[19].id.ToString();
                int start = Banks[0].samples[19].start;
                int id = Banks[0].samples[19].id;
                this.B0_S20_ID.ReadOnly = true;
                foreach (Sample smp in Banks[0].samples)
                {
                    if (smp != null)
                    {
                        if (IsBetween(start, smp.start, smp.end))
                        {
                            if (Banks[0].samples[19].id > smp.id)
                            {
                                Banks[0].samples[smp.id].parents.Add(id);
                                Banks[0].samples[19].depends.Add(smp.id);
                                this.B0_S20_Export.Enabled = false;
                                this.B0_S20_Import.Enabled = false;
                                if (Banks[0].samples[19].depends.Count == 1)
                                {
                                    //find offset
                                    Banks[0].samples[19].offset =start - smp.start;
                                }
                            }
                        }
                    }
                }
                string deps = "";
                if (Banks[0].samples[19].depends != null)
                {
                    foreach (int dep in Banks[0].samples[19].depends)
                    {
                        deps += dep + ",";
                    }

                }
                this.B0_S20_Dep.Text = deps;
                this.B0_S20_Dep.ReadOnly = true;
                this.B0_S20_Off.Text = Banks[0].samples[19].offset.ToString("X");
                this.B0_S20_Off.ReadOnly = true;
                this.B0_S20_Len.Text = Banks[0].samples[19].length.ToString("X");
                if (Banks[0].samples[19].common == true)
                {
                    this.B0_S20_Len.Enabled = false;
                    this.B0_S20_Import.Enabled = false;
                }
                else
                {
                    this.B0_S20_Len.ReadOnly = true;
                }
            }
            if (Banks[0].samples[20] != null)
            {
                this.B0_S21_Enable.Enabled = true;
                this.B0_S21_Enable.Checked = true;
                this.B0_S21_Export.Enabled = true;
                this.B0_S21_Import.Enabled = true;
                this.B0_S21_ID.Text = Banks[0].samples[20].id.ToString();
                int start = Banks[0].samples[20].start;
                int id = Banks[0].samples[20].id;
                this.B0_S21_ID.ReadOnly = true;
                foreach (Sample smp in Banks[0].samples)
                {
                    if (smp != null)
                    {
                        if (IsBetween(start, smp.start, smp.end))
                        {
                            if (Banks[0].samples[20].id > smp.id)
                            {
                                Banks[0].samples[smp.id].parents.Add(id);
                                Banks[0].samples[20].depends.Add(smp.id);
                                this.B0_S21_Export.Enabled = false;
                                this.B0_S21_Import.Enabled = false;
                                if (Banks[0].samples[20].depends.Count == 1)
                                {
                                    //find offset
                                    Banks[0].samples[20].offset =start - smp.start;
                                }
                            }
                        }
                    }
                }
                string deps = "";
                if (Banks[0].samples[20].depends != null)
                {
                    foreach (int dep in Banks[0].samples[20].depends)
                    {
                        deps += dep + ",";
                    }

                }
                this.B0_S21_Dep.Text = deps;
                this.B0_S21_Dep.ReadOnly = true;
                this.B0_S21_Off.Text = Banks[0].samples[20].offset.ToString("X");
                this.B0_S21_Off.ReadOnly = true;
                this.B0_S21_Len.Text = Banks[0].samples[20].length.ToString("X");
                if (Banks[0].samples[20].common == true)
                {
                    this.B0_S21_Len.Enabled = false;
                    this.B0_S21_Import.Enabled = false;
                }
                else
                {
                    this.B0_S21_Len.ReadOnly = true;
                }
            }
            if (Banks[0].samples[21] != null)
            {
                this.B0_S22_Enable.Enabled = true;
                this.B0_S22_Enable.Checked = true;
                this.B0_S22_Export.Enabled = true;
                this.B0_S22_Import.Enabled = true;
                this.B0_S22_ID.Text = Banks[0].samples[21].id.ToString();
                int start = Banks[0].samples[21].start;
                int id = Banks[0].samples[21].id;
                this.B0_S22_ID.ReadOnly = true;
                foreach (Sample smp in Banks[0].samples)
                {
                    if (smp != null)
                    {
                        if (IsBetween(start, smp.start, smp.end))
                        {
                            if (Banks[0].samples[21].id > smp.id)
                            {
                                Banks[0].samples[smp.id].parents.Add(id);
                                Banks[0].samples[21].depends.Add(smp.id);
                                this.B0_S22_Export.Enabled = false;
                                this.B0_S22_Import.Enabled = false;
                                if (Banks[0].samples[21].depends.Count == 1)
                                {
                                    //find offset
                                    Banks[0].samples[21].offset =start - smp.start;
                                }
                            }
                        }
                    }
                }
                string deps = "";
                if (Banks[0].samples[21].depends != null)
                {
                    foreach (int dep in Banks[0].samples[21].depends)
                    {
                        deps += dep + ",";
                    }

                }
                this.B0_S22_Dep.Text = deps;
                this.B0_S22_Dep.ReadOnly = true;
                this.B0_S22_Off.Text = Banks[0].samples[21].offset.ToString("X");
                this.B0_S22_Off.ReadOnly = true;
                this.B0_S22_Len.Text = Banks[0].samples[21].length.ToString("X");
                if (Banks[0].samples[21].common == true)
                {
                    this.B0_S22_Len.Enabled = false;
                    this.B0_S22_Import.Enabled = false;
                }
                else
                {
                    this.B0_S22_Len.ReadOnly = true;
                }
            }
            if (Banks[0].samples[22] != null)
            {
                this.B0_S23_Enable.Enabled = true;
                this.B0_S23_Enable.Checked = true;
                this.B0_S23_Export.Enabled = true;
                this.B0_S23_Import.Enabled = true;
                this.B0_S23_ID.Text = Banks[0].samples[22].id.ToString();
                int start = Banks[0].samples[22].start;
                int id = Banks[0].samples[22].id;
                this.B0_S23_ID.ReadOnly = true;
                foreach (Sample smp in Banks[0].samples)
                {
                    if (smp != null)
                    {
                        if (IsBetween(start, smp.start, smp.end))
                        {
                            if (Banks[0].samples[22].id > smp.id)
                            {
                                Banks[0].samples[smp.id].parents.Add(id);
                                Banks[0].samples[22].depends.Add(smp.id);
                                this.B0_S23_Export.Enabled = false;
                                this.B0_S23_Import.Enabled = false;
                                if (Banks[0].samples[22].depends.Count == 1)
                                {
                                    //find offset
                                    Banks[0].samples[22].offset =start - smp.start;
                                }
                            }
                        }
                    }
                }
                string deps = "";
                if (Banks[0].samples[22].depends != null)
                {
                    foreach (int dep in Banks[0].samples[22].depends)
                    {
                        deps += dep + ",";
                    }

                }
                this.B0_S23_Dep.Text = deps;
                this.B0_S23_Dep.ReadOnly = true;
                this.B0_S23_Off.Text = Banks[0].samples[22].offset.ToString("X");
                this.B0_S23_Off.ReadOnly = true;
                this.B0_S23_Len.Text = Banks[0].samples[22].length.ToString("X");
                if (Banks[0].samples[22].common == true)
                {
                    this.B0_S23_Len.Enabled = false;
                    this.B0_S23_Import.Enabled = false;
                }
                else
                {
                    this.B0_S23_Len.ReadOnly = true;
                }

            }
            if (Banks[0].samples[23] != null)
            {
                this.B0_S24_Enable.Enabled = true;
                this.B0_S24_Enable.Checked = true;
                this.B0_S24_Export.Enabled = true;
                this.B0_S24_Import.Enabled = true;
                this.B0_S24_ID.Text = Banks[0].samples[23].id.ToString();
                int start = Banks[0].samples[23].start;
                int id = Banks[0].samples[23].id;
                this.B0_S24_ID.ReadOnly = true;
                foreach (Sample smp in Banks[0].samples)
                {
                    if (smp != null)
                    {
                        if (IsBetween(start, smp.start, smp.end))
                        {
                            if (Banks[0].samples[23].id > smp.id)
                            {
                                Banks[0].samples[smp.id].parents.Add(id);
                                Banks[0].samples[23].depends.Add(smp.id);
                                this.B0_S24_Export.Enabled = false;
                                this.B0_S24_Import.Enabled = false;
                                if (Banks[0].samples[23].depends.Count == 1)
                                {
                                    //find offset
                                    Banks[0].samples[23].offset =start - smp.start;
                                }
                            }
                        }
                    }
                }
                string deps = "";
                if (Banks[0].samples[23].depends != null)
                {
                    foreach (int dep in Banks[0].samples[23].depends)
                    {
                        deps += dep + ",";
                    }

                }
                this.B0_S24_Dep.Text = deps;
                this.B0_S24_Dep.ReadOnly = true;
                this.B0_S24_Off.Text = Banks[0].samples[23].offset.ToString("X");
                this.B0_S24_Off.ReadOnly = true;
                this.B0_S24_Len.Text = Banks[0].samples[23].length.ToString("X");
                if (Banks[0].samples[23].common == true)
                {
                    this.B0_S24_Len.Enabled = false;
                    this.B0_S24_Import.Enabled = false;
                }
                else
                {
                    this.B0_S24_Len.ReadOnly = true;
                }
            }
            if (Banks[0].samples[24] != null)
            {
                this.B0_S25_Enable.Enabled = true;
                this.B0_S25_Enable.Checked = true;
                this.B0_S25_Export.Enabled = true;
                this.B0_S25_Import.Enabled = true;
                this.B0_S25_ID.Text = Banks[0].samples[24].id.ToString();
                int start = Banks[0].samples[24].start;
                int id = Banks[0].samples[24].id;
                this.B0_S25_ID.ReadOnly = true;
                foreach (Sample smp in Banks[0].samples)
                {
                    if (smp != null)
                    {
                        if (IsBetween(start, smp.start, smp.end))
                        {
                            if (Banks[0].samples[24].id > smp.id)
                            {
                                Banks[0].samples[smp.id].parents.Add(id);
                                Banks[0].samples[24].depends.Add(smp.id);
                                this.B0_S25_Export.Enabled = false;
                                this.B0_S25_Import.Enabled = false;
                                if (Banks[0].samples[24].depends.Count == 1)
                                {
                                    //find offset
                                    Banks[0].samples[24].offset =start - smp.start;
                                }
                            }
                        }
                    }
                }
                string deps = "";
                if (Banks[0].samples[24].depends != null)
                {
                    foreach (int dep in Banks[0].samples[24].depends)
                    {
                        deps += dep + ",";
                    }

                }
                this.B0_S25_Dep.Text = deps;
                this.B0_S25_Dep.ReadOnly = true;
                this.B0_S25_Off.Text = Banks[0].samples[24].offset.ToString("X");
                this.B0_S25_Off.ReadOnly = true;
                this.B0_S25_Len.Text = Banks[0].samples[24].length.ToString("X");
                if (Banks[0].samples[24].common == true)
                {
                    this.B0_S25_Len.Enabled = false;
                    this.B0_S25_Import.Enabled = false;
                }
                else
                {
                    this.B0_S25_Len.ReadOnly = true;
                }
            }
            if (Banks[0].samples[25] != null)
            {
                this.B0_S26_Enable.Enabled = true;
                this.B0_S26_Enable.Checked = true;
                this.B0_S26_Export.Enabled = true;
                this.B0_S26_Import.Enabled = true;
                this.B0_S26_ID.Text = Banks[0].samples[25].id.ToString();
                int start = Banks[0].samples[25].start;
                int id = Banks[0].samples[25].id;
                this.B0_S26_ID.ReadOnly = true;
                foreach (Sample smp in Banks[0].samples)
                {
                    if (smp != null)
                    {
                        if (IsBetween(start, smp.start, smp.end))
                        {
                            if (Banks[0].samples[25].id > smp.id)
                            {
                                Banks[0].samples[smp.id].parents.Add(id);
                                Banks[0].samples[25].depends.Add(smp.id);
                                this.B0_S26_Export.Enabled = false;
                                this.B0_S26_Import.Enabled = false;
                                if (Banks[0].samples[25].depends.Count == 1)
                                {
                                    //find offset
                                    Banks[0].samples[25].offset =start - smp.start;
                                }
                            }
                        }
                    }
                }
                string deps = "";
                if (Banks[0].samples[25].depends != null)
                {
                    foreach (int dep in Banks[0].samples[25].depends)
                    {
                        deps += dep + ",";
                    }

                }
                this.B0_S26_Dep.Text = deps;
                this.B0_S26_Dep.ReadOnly = true;
                this.B0_S26_Off.Text = Banks[0].samples[25].offset.ToString("X");
                this.B0_S26_Off.ReadOnly = true;
                this.B0_S26_Len.Text = Banks[0].samples[25].length.ToString("X");
                if (Banks[0].samples[25].common == true)
                {
                    this.B0_S26_Len.Enabled = false;
                    this.B0_S26_Import.Enabled = false;
                }
                else
                {
                    this.B0_S26_Len.ReadOnly = true;
                }
            }
            if (Banks[0].samples[26] != null)
            {
                this.B0_S27_Enable.Enabled = true;
                this.B0_S27_Enable.Checked = true;
                this.B0_S27_Export.Enabled = true;
                this.B0_S27_Import.Enabled = true;
                this.B0_S27_ID.Text = Banks[0].samples[26].id.ToString();
                int start = Banks[0].samples[26].start;
                int id = Banks[0].samples[26].id;
                this.B0_S27_ID.ReadOnly = true;
                foreach (Sample smp in Banks[0].samples)
                {
                    if (smp != null)
                    {
                        if (IsBetween(start, smp.start, smp.end))
                        {
                            if (Banks[0].samples[26].id > smp.id)
                            {
                                Banks[0].samples[smp.id].parents.Add(id);
                                Banks[0].samples[26].depends.Add(smp.id);
                                this.B0_S27_Export.Enabled = false;
                                this.B0_S27_Import.Enabled = false;
                                if (Banks[0].samples[26].depends.Count == 1)
                                {
                                    //find offset
                                    Banks[0].samples[26].offset =start - smp.start;
                                }
                            }
                        }
                    }
                }
                string deps = "";
                if (Banks[0].samples[26].depends != null)
                {
                    foreach (int dep in Banks[0].samples[26].depends)
                    {
                        deps += dep + ",";
                    }

                }
                this.B0_S27_Dep.Text = deps;
                this.B0_S27_Dep.ReadOnly = true;
                this.B0_S27_Off.Text = Banks[0].samples[26].offset.ToString("X");
                this.B0_S27_Off.ReadOnly = true;
                this.B0_S27_Len.Text = Banks[0].samples[26].length.ToString("X");
                if (Banks[0].samples[26].common == true)
                {
                    this.B0_S27_Len.Enabled = false;
                    this.B0_S27_Import.Enabled = false;
                }
                else
                {
                    this.B0_S27_Len.ReadOnly = true;
                }
            }
            if (Banks[0].samples[27] != null)
            {
                this.B0_S28_Enable.Enabled = true;
                this.B0_S28_Enable.Checked = true;
                this.B0_S28_Export.Enabled = true;
                this.B0_S28_Import.Enabled = true;
                this.B0_S28_ID.Text = Banks[0].samples[27].id.ToString();
                int start = Banks[0].samples[27].start;
                int id = Banks[0].samples[27].id;
                this.B0_S28_ID.ReadOnly = true;
                foreach (Sample smp in Banks[0].samples)
                {
                    if (smp != null)
                    {
                        if (IsBetween(start, smp.start, smp.end))
                        {
                            if (Banks[0].samples[27].id > smp.id)
                            {
                                Banks[0].samples[smp.id].parents.Add(id);
                                Banks[0].samples[27].depends.Add(smp.id);
                                this.B0_S28_Export.Enabled = false;
                                this.B0_S28_Import.Enabled = false;
                                if (Banks[0].samples[27].depends.Count == 1)
                                {
                                    //find offset
                                    Banks[0].samples[27].offset =start - smp.start;
                                }
                            }
                        }
                    }
                }
                string deps = "";
                if (Banks[0].samples[27].depends != null)
                {
                    foreach (int dep in Banks[0].samples[27].depends)
                    {
                        deps += dep + ",";
                    }

                }
                this.B0_S28_Dep.Text = deps;
                this.B0_S28_Dep.ReadOnly = true;
                this.B0_S28_Off.Text = Banks[0].samples[27].offset.ToString("X");
                this.B0_S28_Off.ReadOnly = true;
                this.B0_S28_Len.Text = Banks[0].samples[27].length.ToString("X");
                if (Banks[0].samples[27].common == true)
                {
                    this.B0_S28_Len.Enabled = false;
                    this.B0_S28_Import.Enabled = false;
                }
                else
                {
                    this.B0_S28_Len.ReadOnly = true;
                }
            }
            if (Banks[0].samples[28] != null)
            {
                this.B0_S29_Enable.Enabled = true;
                this.B0_S29_Enable.Checked = true;
                this.B0_S29_Export.Enabled = true;
                this.B0_S29_Import.Enabled = true;
                this.B0_S29_ID.Text = Banks[0].samples[28].id.ToString();
                int start = Banks[0].samples[28].start;
                int id = Banks[0].samples[28].id;
                this.B0_S29_ID.ReadOnly = true;
                foreach (Sample smp in Banks[0].samples)
                {
                    if (smp != null)
                    {
                        if (IsBetween(start, smp.start, smp.end))
                        {
                            if (Banks[0].samples[28].id > smp.id)
                            {
                                Banks[0].samples[smp.id].parents.Add(id);
                                Banks[0].samples[28].depends.Add(smp.id);
                                this.B0_S29_Export.Enabled = false;
                                this.B0_S29_Import.Enabled = false;
                                if (Banks[0].samples[28].depends.Count == 1)
                                {
                                    //find offset
                                    Banks[0].samples[28].offset =start - smp.start;
                                }
                            }
                        }
                    }
                }
                string deps = "";
                if (Banks[0].samples[28].depends != null)
                {
                    foreach (int dep in Banks[0].samples[28].depends)
                    {
                        deps += dep + ",";
                    }

                }
                this.B0_S29_Dep.Text = deps;
                this.B0_S29_Dep.ReadOnly = true;
                this.B0_S29_Off.Text = Banks[0].samples[28].offset.ToString("X");
                this.B0_S29_Off.ReadOnly = true;
                this.B0_S29_Len.Text = Banks[0].samples[28].length.ToString("X");
                if (Banks[0].samples[28].common == true)
                {
                    this.B0_S29_Len.Enabled = false;
                    this.B0_S29_Import.Enabled = false;
                }
                else
                {
                    this.B0_S29_Len.ReadOnly = true;
                }
            }
            if (Banks[0].samples[29] != null)
            {
                this.B0_S30_Enable.Enabled = true;
                this.B0_S30_Enable.Checked = true;
                this.B0_S30_Export.Enabled = true;
                this.B0_S30_Import.Enabled = true;
                this.B0_S30_ID.Text = Banks[0].samples[29].id.ToString();
                int start = Banks[0].samples[29].start;
                int id = Banks[0].samples[29].id;
                this.B0_S30_ID.ReadOnly = true;
                foreach (Sample smp in Banks[0].samples)
                {
                    if (smp != null)
                    {
                        if (IsBetween(start, smp.start, smp.end))
                        {
                            if (Banks[0].samples[29].id > smp.id)
                            {
                                Banks[0].samples[smp.id].parents.Add(id);
                                Banks[0].samples[29].depends.Add(smp.id);
                                this.B0_S30_Export.Enabled = false;
                                this.B0_S30_Import.Enabled = false;
                                if (Banks[0].samples[29].depends.Count == 1)
                                {
                                    //find offset
                                    Banks[0].samples[29].offset =start - smp.start;
                                }
                            }
                        }
                    }
                }
                string deps = "";
                if (Banks[0].samples[29].depends != null)
                {
                    foreach (int dep in Banks[0].samples[29].depends)
                    {
                        deps += dep + ",";
                    }

                }
                this.B0_S30_Dep.Text = deps;
                this.B0_S30_Dep.ReadOnly = true;
                this.B0_S30_Off.Text = Banks[0].samples[29].offset.ToString("X");
                this.B0_S30_Off.ReadOnly = true;
                this.B0_S30_Len.Text = Banks[0].samples[29].length.ToString("X");
                if (Banks[0].samples[29].common == true)
                {
                    this.B0_S30_Len.Enabled = false;
                    this.B0_S30_Import.Enabled = false;
                }
                else
                {
                    this.B0_S30_Len.ReadOnly = true;
                }
            }
            if (Banks[0].samples[30] != null)
            {
                this.B0_S31_Enable.Enabled = true;
                this.B0_S31_Enable.Checked = true;
                this.B0_S31_Export.Enabled = true;
                this.B0_S31_Import.Enabled = true;
                this.B0_S31_ID.Text = Banks[0].samples[30].id.ToString();
                int start = Banks[0].samples[30].start;
                int id = Banks[0].samples[30].id;
                this.B0_S31_ID.ReadOnly = true;
                foreach (Sample smp in Banks[0].samples)
                {
                    if (smp != null)
                    {
                        if (IsBetween(start, smp.start, smp.end))
                        {
                            if (Banks[0].samples[30].id > smp.id)
                            {
                                Banks[0].samples[smp.id].parents.Add(id);
                                Banks[0].samples[30].depends.Add(smp.id);
                                this.B0_S31_Export.Enabled = false;
                                this.B0_S31_Import.Enabled = false;
                                if (Banks[0].samples[30].depends.Count == 1)
                                {
                                    //find offset
                                    Banks[0].samples[30].offset =start - smp.start;
                                }
                            }
                        }
                    }
                }
                string deps = "";
                if (Banks[0].samples[30].depends != null)
                {
                    foreach (int dep in Banks[0].samples[30].depends)
                    {
                        deps += dep + ",";
                    }

                }
                this.B0_S31_Dep.Text = deps;
                this.B0_S31_Dep.ReadOnly = true;
                this.B0_S31_Off.Text = Banks[0].samples[30].offset.ToString("X");
                this.B0_S31_Off.ReadOnly = true;
                this.B0_S31_Len.Text = Banks[0].samples[30].length.ToString("X");
                if (Banks[0].samples[30].common == true)
                {
                    this.B0_S31_Len.Enabled = false;
                    this.B0_S31_Import.Enabled = false;
                }
                else
                {
                    this.B0_S31_Len.ReadOnly = true;
                }
            }
            if (Banks[0].samples[31] != null)
            {
                this.B0_S32_Enable.Enabled = true;
                this.B0_S32_Enable.Checked = true;
                this.B0_S32_Export.Enabled = true;
                this.B0_S32_Import.Enabled = true;
                this.B0_S32_ID.Text = Banks[0].samples[31].id.ToString();
                int start = Banks[0].samples[31].start;
                int id = Banks[0].samples[31].id;
                this.B0_S32_ID.ReadOnly = true;
                foreach (Sample smp in Banks[0].samples)
                {
                    if (smp != null)
                    {
                        if (IsBetween(start, smp.start, smp.end))
                        {
                            if (Banks[0].samples[31].id > smp.id)
                            {
                                Banks[0].samples[smp.id].parents.Add(id);
                                Banks[0].samples[31].depends.Add(smp.id);
                                this.B0_S32_Export.Enabled = false;
                                this.B0_S32_Import.Enabled = false;
                                if (Banks[0].samples[31].depends.Count == 1)
                                {
                                    //find offset
                                    Banks[0].samples[31].offset =start - smp.start;
                                }
                            }
                        }
                    }
                }
                string deps = "";
                if (Banks[0].samples[31].depends != null)
                {
                    foreach (int dep in Banks[0].samples[31].depends)
                    {
                        deps += dep + ",";
                    }

                }
                this.B0_S32_Dep.Text = deps;
                this.B0_S32_Dep.ReadOnly = true;
                this.B0_S32_Off.Text = Banks[0].samples[31].offset.ToString("X");
                this.B0_S32_Off.ReadOnly = true;
                this.B0_S32_Len.Text = Banks[0].samples[31].length.ToString("X");
                if (Banks[0].samples[31].common == true)
                {
                    this.B0_S32_Len.Enabled = false;
                    this.B0_S32_Import.Enabled = false;
                }
                else
                {
                    this.B0_S32_Len.ReadOnly = true;
                }
            }
            if (Banks[0].samples[32] != null)
            {
                this.B0_S33_Enable.Enabled = true;
                this.B0_S33_Enable.Checked = true;
                this.B0_S33_Export.Enabled = true;
                this.B0_S33_Import.Enabled = true;
                this.B0_S33_ID.Text = Banks[0].samples[32].id.ToString();
                int start = Banks[0].samples[32].start;
                int id = Banks[0].samples[32].id;
                this.B0_S33_ID.ReadOnly = true;
                foreach (Sample smp in Banks[0].samples)
                {
                    if (smp != null)
                    {
                        if (IsBetween(start, smp.start, smp.end))
                        {
                            if (Banks[0].samples[32].id > smp.id)
                            {
                                Banks[0].samples[smp.id].parents.Add(id);
                                Banks[0].samples[32].depends.Add(smp.id);
                                this.B0_S33_Export.Enabled = false;
                                this.B0_S33_Import.Enabled = false;
                                if (Banks[0].samples[32].depends.Count == 1)
                                {
                                    //find offset
                                    Banks[0].samples[32].offset =start - smp.start;
                                }
                            }
                        }
                    }
                }
                string deps = "";
                if (Banks[0].samples[32].depends != null)
                {
                    foreach (int dep in Banks[0].samples[32].depends)
                    {
                        deps += dep + ",";
                    }

                }
                this.B0_S33_Dep.Text = deps;
                this.B0_S33_Dep.ReadOnly = true;
                this.B0_S33_Off.Text = Banks[0].samples[32].offset.ToString("X");
                this.B0_S33_Off.ReadOnly = true;
                this.B0_S33_Len.Text = Banks[0].samples[32].length.ToString("X");
                if (Banks[0].samples[32].common == true)
                {
                    this.B0_S33_Len.Enabled = false;
                    this.B0_S33_Import.Enabled = false;
                }
                else
                {
                    this.B0_S33_Len.ReadOnly = true;
                }

            }
            if (Banks[0].samples[33] != null)
            {
                this.B0_S34_Enable.Enabled = true;
                this.B0_S34_Enable.Checked = true;
                this.B0_S34_Export.Enabled = true;
                this.B0_S34_Import.Enabled = true;
                this.B0_S34_ID.Text = Banks[0].samples[33].id.ToString();
                int start = Banks[0].samples[33].start;
                int id = Banks[0].samples[33].id;
                this.B0_S34_ID.ReadOnly = true;
                foreach (Sample smp in Banks[0].samples)
                {
                    if (smp != null)
                    {
                        if (IsBetween(start, smp.start, smp.end))
                        {
                            if (Banks[0].samples[33].id > smp.id)
                            {
                                Banks[0].samples[smp.id].parents.Add(id);
                                Banks[0].samples[33].depends.Add(smp.id);
                                this.B0_S34_Export.Enabled = false;
                                this.B0_S34_Import.Enabled = false;
                                if (Banks[0].samples[33].depends.Count == 1)
                                {
                                    //find offset
                                    Banks[0].samples[33].offset =start - smp.start;
                                }
                            }
                        }
                    }
                }
                string deps = "";
                if (Banks[0].samples[33].depends != null)
                {
                    foreach (int dep in Banks[0].samples[33].depends)
                    {
                        deps += dep + ",";
                    }

                }
                this.B0_S34_Dep.Text = deps;
                this.B0_S34_Dep.ReadOnly = true;
                this.B0_S34_Off.Text = Banks[0].samples[33].offset.ToString("X");
                this.B0_S34_Off.ReadOnly = true;
                this.B0_S34_Len.Text = Banks[0].samples[33].length.ToString("X");
                if (Banks[0].samples[33].common == true)
                {
                    this.B0_S34_Len.Enabled = false;
                    this.B0_S34_Import.Enabled = false;
                }
                else
                {
                    this.B0_S34_Len.ReadOnly = true;
                }
            }
            if (Banks[0].samples[34] != null)
            {
                this.B0_S35_Enable.Enabled = true;
                this.B0_S35_Enable.Checked = true;
                this.B0_S35_Export.Enabled = true;
                this.B0_S35_Import.Enabled = true;
                this.B0_S35_ID.Text = Banks[0].samples[34].id.ToString();
                int start = Banks[0].samples[34].start;
                int id = Banks[0].samples[34].id;
                this.B0_S35_ID.ReadOnly = true;
                foreach (Sample smp in Banks[0].samples)
                {
                    if (smp != null)
                    {
                        if (IsBetween(start, smp.start, smp.end))
                        {
                            if (Banks[0].samples[34].id > smp.id)
                            {
                                Banks[0].samples[smp.id].parents.Add(id);
                                Banks[0].samples[34].depends.Add(smp.id);
                                this.B0_S35_Export.Enabled = false;
                                this.B0_S35_Import.Enabled = false;
                                if (Banks[0].samples[34].depends.Count == 1)
                                {
                                    //find offset
                                    Banks[0].samples[34].offset =start - smp.start;
                                }
                            }
                        }
                    }
                }
                string deps = "";
                if (Banks[0].samples[34].depends != null)
                {
                    foreach (int dep in Banks[0].samples[34].depends)
                    {
                        deps += dep + ",";
                    }

                }
                this.B0_S35_Dep.Text = deps;
                this.B0_S35_Dep.ReadOnly = true;
                this.B0_S35_Off.Text = Banks[0].samples[34].offset.ToString("X");
                this.B0_S35_Off.ReadOnly = true;
                this.B0_S35_Len.Text = Banks[0].samples[34].length.ToString("X");
                if (Banks[0].samples[34].common == true)
                {
                    this.B0_S35_Len.Enabled = false;
                    this.B0_S35_Import.Enabled = false;
                }
                else
                {
                    this.B0_S35_Len.ReadOnly = true;
                }
            }
            if (Banks[0].samples[35] != null)
            {
                this.B0_S36_Enable.Enabled = true;
                this.B0_S36_Enable.Checked = true;
                this.B0_S36_Export.Enabled = true;
                this.B0_S36_Import.Enabled = true;
                this.B0_S36_ID.Text = Banks[0].samples[35].id.ToString();
                int start = Banks[0].samples[35].start;
                int id = Banks[0].samples[35].id;
                this.B0_S36_ID.ReadOnly = true;
                foreach (Sample smp in Banks[0].samples)
                {
                    if (smp != null)
                    {
                        if (IsBetween(start, smp.start, smp.end))
                        {
                            if (Banks[0].samples[35].id > smp.id)
                            {
                                Banks[0].samples[smp.id].parents.Add(id);
                                Banks[0].samples[35].depends.Add(smp.id);
                                this.B0_S36_Export.Enabled = false;
                                this.B0_S36_Import.Enabled = false;
                                if (Banks[0].samples[35].depends.Count == 1)
                                {
                                    //find offset
                                    Banks[0].samples[35].offset =start - smp.start;
                                }
                            }
                        }
                    }
                }
                string deps = "";
                if (Banks[0].samples[35].depends != null)
                {
                    foreach (int dep in Banks[0].samples[35].depends)
                    {
                        deps += dep + ",";
                    }

                }
                this.B0_S36_Dep.Text = deps;
                this.B0_S36_Dep.ReadOnly = true;
                this.B0_S36_Off.Text = Banks[0].samples[35].offset.ToString("X");
                this.B0_S36_Off.ReadOnly = true;
                this.B0_S36_Len.Text = Banks[0].samples[35].length.ToString("X");
                if (Banks[0].samples[35].common == true)
                {
                    this.B0_S36_Len.Enabled = false;
                    this.B0_S36_Import.Enabled = false;
                }
                else
                {
                    this.B0_S36_Len.ReadOnly = true;
                }
            }
            if (Banks[0].samples[36] != null)
            {
                this.B0_S37_Enable.Enabled = true;
                this.B0_S37_Enable.Checked = true;
                this.B0_S37_Export.Enabled = true;
                this.B0_S37_Import.Enabled = true;
                this.B0_S37_ID.Text = Banks[0].samples[36].id.ToString();
                int start = Banks[0].samples[36].start;
                int id = Banks[0].samples[36].id;
                this.B0_S37_ID.ReadOnly = true;
                foreach (Sample smp in Banks[0].samples)
                {
                    if (smp != null)
                    {
                        if (IsBetween(start, smp.start, smp.end))
                        {
                            if (Banks[0].samples[36].id > smp.id)
                            {
                                Banks[0].samples[smp.id].parents.Add(id);
                                Banks[0].samples[36].depends.Add(smp.id);
                                this.B0_S37_Export.Enabled = false;
                                this.B0_S37_Import.Enabled = false;
                                if (Banks[0].samples[36].depends.Count == 1)
                                {
                                    //find offset
                                    Banks[0].samples[36].offset =start - smp.start;
                                }
                            }
                        }
                    }
                }
                string deps = "";
                if (Banks[0].samples[36].depends != null)
                {
                    foreach (int dep in Banks[0].samples[36].depends)
                    {
                        deps += dep + ",";
                    }

                }
                this.B0_S37_Dep.Text = deps;
                this.B0_S37_Dep.ReadOnly = true;
                this.B0_S37_Off.Text = Banks[0].samples[36].offset.ToString("X");
                this.B0_S37_Off.ReadOnly = true;
                this.B0_S37_Len.Text = Banks[0].samples[36].length.ToString("X");
                if (Banks[0].samples[36].common == true)
                {
                    this.B0_S37_Len.Enabled = false;
                    this.B0_S37_Import.Enabled = false;
                }
                else
                {
                    this.B0_S37_Len.ReadOnly = true;
                }
            }
            if (Banks[0].samples[37] != null)
            {
                this.B0_S38_Enable.Enabled = true;
                this.B0_S38_Enable.Checked = true;
                this.B0_S38_Export.Enabled = true;
                this.B0_S38_Import.Enabled = true;
                this.B0_S38_ID.Text = Banks[0].samples[37].id.ToString();
                int start = Banks[0].samples[37].start;
                int id = Banks[0].samples[37].id;
                this.B0_S38_ID.ReadOnly = true;
                foreach (Sample smp in Banks[0].samples)
                {
                    if (smp != null)
                    {
                        if (IsBetween(start, smp.start, smp.end))
                        {
                            if (Banks[0].samples[37].id > smp.id)
                            {
                                Banks[0].samples[smp.id].parents.Add(id);
                                Banks[0].samples[37].depends.Add(smp.id);
                                this.B0_S38_Export.Enabled = false;
                                this.B0_S38_Import.Enabled = false;
                                if (Banks[0].samples[37].depends.Count == 1)
                                {
                                    //find offset
                                    Banks[0].samples[37].offset =start - smp.start;
                                }
                            }
                        }
                    }
                }
                string deps = "";
                if (Banks[0].samples[37].depends != null)
                {
                    foreach (int dep in Banks[0].samples[37].depends)
                    {
                        deps += dep + ",";
                    }

                }
                this.B0_S38_Dep.Text = deps;
                this.B0_S38_Dep.ReadOnly = true;
                this.B0_S38_Off.Text = Banks[0].samples[37].offset.ToString("X");
                this.B0_S38_Off.ReadOnly = true;
                this.B0_S38_Len.Text = Banks[0].samples[37].length.ToString("X");
                if (Banks[0].samples[37].common == true)
                {
                    this.B0_S38_Len.Enabled = false;
                    this.B0_S38_Import.Enabled = false;
                }
                else
                {
                    this.B0_S38_Len.ReadOnly = true;
                }
            }
            if (Banks[0].samples[38] != null)
            {
                this.B0_S39_Enable.Enabled = true;
                this.B0_S39_Enable.Checked = true;
                this.B0_S39_Export.Enabled = true;
                this.B0_S39_Import.Enabled = true;
                this.B0_S39_ID.Text = Banks[0].samples[38].id.ToString();
                int start = Banks[0].samples[38].start;
                int id = Banks[0].samples[38].id;
                this.B0_S39_ID.ReadOnly = true;
                foreach (Sample smp in Banks[0].samples)
                {
                    if (smp != null)
                    {
                        if (IsBetween(start, smp.start, smp.end))
                        {
                            if (Banks[0].samples[38].id > smp.id)
                            {
                                Banks[0].samples[smp.id].parents.Add(id);
                                Banks[0].samples[38].depends.Add(smp.id);
                                this.B0_S39_Export.Enabled = false;
                                this.B0_S39_Import.Enabled = false;
                                if (Banks[0].samples[38].depends.Count == 1)
                                {
                                    //find offset
                                    Banks[0].samples[38].offset =start - smp.start;
                                }
                            }
                        }
                    }
                }
                string deps = "";
                if (Banks[0].samples[38].depends != null)
                {
                    foreach (int dep in Banks[0].samples[38].depends)
                    {
                        deps += dep + ",";
                    }

                }
                this.B0_S39_Dep.Text = deps;
                this.B0_S39_Dep.ReadOnly = true;
                this.B0_S39_Off.Text = Banks[0].samples[38].offset.ToString("X");
                this.B0_S39_Off.ReadOnly = true;
                this.B0_S39_Len.Text = Banks[0].samples[38].length.ToString("X");
                if (Banks[0].samples[38].common == true)
                {
                    this.B0_S39_Len.Enabled = false;
                    this.B0_S39_Import.Enabled = false;
                }
                else
                {
                    this.B0_S39_Len.ReadOnly = true;
                }
            }
            if (Banks[0].samples[39] != null)
            {
                this.B0_S40_Enable.Enabled = true;
                this.B0_S40_Enable.Checked = true;
                this.B0_S40_Export.Enabled = true;
                this.B0_S40_Import.Enabled = true;
                this.B0_S40_ID.Text = Banks[0].samples[39].id.ToString();
                int start = Banks[0].samples[39].start;
                int id = Banks[0].samples[39].id;
                this.B0_S40_ID.ReadOnly = true;
                foreach (Sample smp in Banks[0].samples)
                {
                    if (smp != null)
                    {
                        if (IsBetween(start, smp.start, smp.end))
                        {
                            if (Banks[0].samples[39].id > smp.id)
                            {
                                Banks[0].samples[39].depends.Add(smp.id);
                                this.B0_S40_Export.Enabled = false;
                                this.B0_S40_Import.Enabled = false;
                                if (Banks[0].samples[39].depends.Count == 1)
                                {
                                    //find offset
                                    Banks[0].samples[39].offset =start - smp.start;
                                }
                            }
                        }
                    }
                }
                string deps = "";
                if (Banks[0].samples[39].depends != null)
                {
                    foreach (int dep in Banks[0].samples[39].depends)
                    {
                        deps += dep + ",";
                    }

                }
                this.B0_S40_Dep.Text = deps;
                this.B0_S40_Dep.ReadOnly = true;
                this.B0_S40_Off.Text = Banks[0].samples[39].offset.ToString("X");
                this.B0_S40_Off.ReadOnly = true;
                this.B0_S40_Len.Text = Banks[0].samples[39].length.ToString("X");
                if (Banks[0].samples[39].common == true)
                {
                    this.B0_S40_Len.Enabled = false;
                    this.B0_S40_Import.Enabled = false;
                }
                else
                {
                    this.B0_S40_Len.ReadOnly = true;
                }
            }
            if (Banks[0].samples[40] != null)
            {
                this.B0_S41_Enable.Enabled = true;
                this.B0_S41_Enable.Checked = true;
                this.B0_S41_Export.Enabled = true;
                this.B0_S41_Import.Enabled = true;
                this.B0_S41_ID.Text = Banks[0].samples[40].id.ToString();
                int start = Banks[0].samples[40].start;
                int id = Banks[0].samples[40].id;
                this.B0_S41_ID.ReadOnly = true;
                foreach (Sample smp in Banks[0].samples)
                {
                    if (smp != null)
                    {
                        if (IsBetween(start, smp.start, smp.end))
                        {
                            if (Banks[0].samples[40].id > smp.id)
                            {
                                Banks[0].samples[smp.id].parents.Add(id);
                                Banks[0].samples[40].depends.Add(smp.id);
                                this.B0_S41_Export.Enabled = false;
                                this.B0_S41_Import.Enabled = false;
                                if (Banks[0].samples[40].depends.Count == 1)
                                {
                                    //find offset
                                    Banks[0].samples[40].offset =start - smp.start;
                                }
                            }
                        }
                    }
                }
                string deps = "";
                if (Banks[0].samples[40].depends != null)
                {
                    foreach (int dep in Banks[0].samples[40].depends)
                    {
                        deps += dep + ",";
                    }

                }
                this.B0_S41_Dep.Text = deps;
                this.B0_S41_Dep.ReadOnly = true;
                this.B0_S41_Off.Text = Banks[0].samples[40].offset.ToString("X");
                this.B0_S41_Off.ReadOnly = true;
                this.B0_S41_Len.Text = Banks[0].samples[40].length.ToString("X");
                if (Banks[0].samples[40].common == true)
                {
                    this.B0_S41_Len.Enabled = false;
                    this.B0_S41_Import.Enabled = false;
                }
                else
                {
                    this.B0_S41_Len.ReadOnly = true;
                }
            }
            if (Banks[0].samples[41] != null)
            {
                this.B0_S42_Enable.Enabled = true;
                this.B0_S42_Enable.Checked = true;
                this.B0_S42_Export.Enabled = true;
                this.B0_S42_Import.Enabled = true;
                this.B0_S42_ID.Text = Banks[0].samples[41].id.ToString();
                int start = Banks[0].samples[41].start;
                int id = Banks[0].samples[41].id;
                this.B0_S42_ID.ReadOnly = true;
                foreach (Sample smp in Banks[0].samples)
                {
                    if (smp != null)
                    {
                        if (IsBetween(start, smp.start, smp.end))
                        {
                            if (Banks[0].samples[41].id > smp.id)
                            {
                                Banks[0].samples[smp.id].parents.Add(id);
                                Banks[0].samples[41].depends.Add(smp.id);
                                this.B0_S42_Export.Enabled = false;
                                this.B0_S42_Import.Enabled = false;
                                if (Banks[0].samples[41].depends.Count == 1)
                                {
                                    //find offset
                                    Banks[0].samples[41].offset =start - smp.start;
                                }
                            }
                        }
                    }
                }
                string deps = "";
                if (Banks[0].samples[41].depends != null)
                {
                    foreach (int dep in Banks[0].samples[41].depends)
                    {
                        deps += dep + ",";
                    }

                }
                this.B0_S42_Dep.Text = deps;
                this.B0_S42_Dep.ReadOnly = true;
                this.B0_S42_Off.Text = Banks[0].samples[41].offset.ToString("X");
                this.B0_S42_Off.ReadOnly = true;
                this.B0_S42_Len.Text = Banks[0].samples[41].length.ToString("X");
                if (Banks[0].samples[41].common == true)
                {
                    this.B0_S42_Len.Enabled = false;
                    this.B0_S42_Import.Enabled = false;
                }
                else
                {
                    this.B0_S42_Len.ReadOnly = true;
                }
            }
            if (Banks[0].samples[42] != null)
            {
                this.B0_S43_Enable.Enabled = true;
                this.B0_S43_Enable.Checked = true;
                this.B0_S43_Export.Enabled = true;
                this.B0_S43_Import.Enabled = true;
                this.B0_S43_ID.Text = Banks[0].samples[42].id.ToString();
                int start = Banks[0].samples[42].start;
                int id = Banks[0].samples[42].id;
                this.B0_S43_ID.ReadOnly = true;
                foreach (Sample smp in Banks[0].samples)
                {
                    if (smp != null)
                    {
                        if (IsBetween(start, smp.start, smp.end))
                        {
                            if (Banks[0].samples[42].id > smp.id)
                            {
                                Banks[0].samples[smp.id].parents.Add(id);
                                Banks[0].samples[42].depends.Add(smp.id);
                                this.B0_S43_Export.Enabled = false;
                                this.B0_S43_Import.Enabled = false;
                                if (Banks[0].samples[42].depends.Count == 1)
                                {
                                    //find offset
                                    Banks[0].samples[42].offset =start - smp.start;
                                }
                            }
                        }
                    }
                }
                string deps = "";
                if (Banks[0].samples[42].depends != null)
                {
                    foreach (int dep in Banks[0].samples[42].depends)
                    {
                        deps += dep + ",";
                    }

                }
                this.B0_S43_Dep.Text = deps;
                this.B0_S43_Dep.ReadOnly = true;
                this.B0_S43_Off.Text = Banks[0].samples[42].offset.ToString("X");
                this.B0_S43_Off.ReadOnly = true;
                this.B0_S43_Len.Text = Banks[0].samples[42].length.ToString("X");
                if (Banks[0].samples[42].common == true)
                {
                    this.B0_S43_Len.Enabled = false;
                    this.B0_S43_Import.Enabled = false;
                }
                else
                {
                    this.B0_S43_Len.ReadOnly = true;
                }

            }
            if (Banks[0].samples[43] != null)
            {
                this.B0_S44_Enable.Enabled = true;
                this.B0_S44_Enable.Checked = true;
                this.B0_S44_Export.Enabled = true;
                this.B0_S44_Import.Enabled = true;
                this.B0_S44_ID.Text = Banks[0].samples[43].id.ToString();
                int start = Banks[0].samples[43].start;
                int id = Banks[0].samples[43].id;
                this.B0_S44_ID.ReadOnly = true;
                foreach (Sample smp in Banks[0].samples)
                {
                    if (smp != null)
                    {
                        if (IsBetween(start, smp.start, smp.end))
                        {
                            if (Banks[0].samples[43].id > smp.id)
                            {
                                Banks[0].samples[43].depends.Add(smp.id);
                                this.B0_S44_Export.Enabled = false;
                                this.B0_S44_Import.Enabled = false;
                                if (Banks[0].samples[43].depends.Count == 1)
                                {
                                    //find offset
                                    Banks[0].samples[43].offset =start - smp.start;
                                }
                            }
                        }
                    }
                }
                string deps = "";
                if (Banks[0].samples[43].depends != null)
                {
                    foreach (int dep in Banks[0].samples[43].depends)
                    {
                        deps += dep + ",";
                    }

                }
                this.B0_S44_Dep.Text = deps;
                this.B0_S44_Dep.ReadOnly = true;
                this.B0_S44_Off.Text = Banks[0].samples[43].offset.ToString("X");
                this.B0_S44_Off.ReadOnly = true;
                this.B0_S44_Len.Text = Banks[0].samples[43].length.ToString("X");
                if (Banks[0].samples[43].common == true)
                {
                    this.B0_S44_Len.Enabled = false;
                    this.B0_S44_Import.Enabled = false;
                }
                else
                {
                    this.B0_S44_Len.ReadOnly = true;
                }
            }
            if (Banks[0].samples[44] != null)
            {
                this.B0_S45_Enable.Enabled = true;
                this.B0_S45_Enable.Checked = true;
                this.B0_S45_Export.Enabled = true;
                this.B0_S45_Import.Enabled = true;
                this.B0_S45_ID.Text = Banks[0].samples[44].id.ToString();
                int start = Banks[0].samples[44].start;
                int id = Banks[0].samples[44].id;
                this.B0_S45_ID.ReadOnly = true;
                foreach (Sample smp in Banks[0].samples)
                {
                    if (smp != null)
                    {
                        if (IsBetween(start, smp.start, smp.end))
                        {
                            if (Banks[0].samples[44].id > smp.id)
                            {
                                Banks[0].samples[smp.id].parents.Add(id);
                                Banks[0].samples[44].depends.Add(smp.id);
                                this.B0_S45_Export.Enabled = false;
                                this.B0_S45_Import.Enabled = false;
                                if (Banks[0].samples[44].depends.Count == 1)
                                {
                                    //find offset
                                    Banks[0].samples[44].offset =start - smp.start;
                                }
                            }
                        }
                    }
                }
                string deps = "";
                if (Banks[0].samples[44].depends != null)
                {
                    foreach (int dep in Banks[0].samples[44].depends)
                    {
                        deps += dep + ",";
                    }

                }
                this.B0_S45_Dep.Text = deps;
                this.B0_S45_Dep.ReadOnly = true;
                this.B0_S45_Off.Text = Banks[0].samples[44].offset.ToString("X");
                this.B0_S45_Off.ReadOnly = true;
                this.B0_S45_Len.Text = Banks[0].samples[44].length.ToString("X");
                if (Banks[0].samples[44].common == true)
                {
                    this.B0_S45_Len.Enabled = false;
                    this.B0_S45_Import.Enabled = false;
                }
                else
                {
                    this.B0_S45_Len.ReadOnly = true;
                }
            }
            if (Banks[0].samples[45] != null)
            {
                this.B0_S46_Enable.Enabled = true;
                this.B0_S46_Enable.Checked = true;
                this.B0_S46_Export.Enabled = true;
                this.B0_S46_Import.Enabled = true;
                this.B0_S46_ID.Text = Banks[0].samples[45].id.ToString();
                int start = Banks[0].samples[45].start;
                int id = Banks[0].samples[45].id;
                this.B0_S46_ID.ReadOnly = true;
                foreach (Sample smp in Banks[0].samples)
                {
                    if (smp != null)
                    {
                        if (IsBetween(start, smp.start, smp.end))
                        {
                            if (Banks[0].samples[45].id > smp.id)
                            {
                                Banks[0].samples[smp.id].parents.Add(id);
                                Banks[0].samples[45].depends.Add(smp.id);
                                this.B0_S46_Export.Enabled = false;
                                this.B0_S46_Import.Enabled = false;
                                if (Banks[0].samples[45].depends.Count == 1)
                                {
                                    //find offset
                                    Banks[0].samples[45].offset =start - smp.start;
                                }
                            }
                        }
                    }
                }
                string deps = "";
                if (Banks[0].samples[45].depends != null)
                {
                    foreach (int dep in Banks[0].samples[45].depends)
                    {
                        deps += dep + ",";
                    }

                }
                this.B0_S46_Dep.Text = deps;
                this.B0_S46_Dep.ReadOnly = true;
                this.B0_S46_Off.Text = Banks[0].samples[45].offset.ToString("X");
                this.B0_S46_Off.ReadOnly = true;
                this.B0_S46_Len.Text = Banks[0].samples[45].length.ToString("X");
                if (Banks[0].samples[45].common == true)
                {
                    this.B0_S46_Len.Enabled = false;
                    this.B0_S46_Import.Enabled = false;
                }
                else
                {
                    this.B0_S46_Len.ReadOnly = true;
                }
            }
            if (Banks[0].samples[46] != null)
            {
                this.B0_S47_Enable.Enabled = true;
                this.B0_S47_Enable.Checked = true;
                this.B0_S47_Export.Enabled = true;
                this.B0_S47_Import.Enabled = true;
                this.B0_S47_ID.Text = Banks[0].samples[46].id.ToString();
                int start = Banks[0].samples[46].start;
                int id = Banks[0].samples[46].id;
                this.B0_S47_ID.ReadOnly = true;
                foreach (Sample smp in Banks[0].samples)
                {
                    if (smp != null)
                    {
                        if (IsBetween(start, smp.start, smp.end))
                        {
                            if (Banks[0].samples[46].id > smp.id)
                            {
                                Banks[0].samples[smp.id].parents.Add(id);
                                Banks[0].samples[46].depends.Add(smp.id);
                                this.B0_S47_Export.Enabled = false;
                                this.B0_S47_Import.Enabled = false;
                                if (Banks[0].samples[46].depends.Count == 1)
                                {
                                    //find offset
                                    Banks[0].samples[46].offset =start - smp.start;
                                }
                            }
                        }
                    }
                }
                string deps = "";
                if (Banks[0].samples[46].depends != null)
                {
                    foreach (int dep in Banks[0].samples[46].depends)
                    {
                        deps += dep + ",";
                    }

                }
                this.B0_S47_Dep.Text = deps;
                this.B0_S47_Dep.ReadOnly = true;
                this.B0_S47_Off.Text = Banks[0].samples[46].offset.ToString("X");
                this.B0_S47_Off.ReadOnly = true;
                this.B0_S47_Len.Text = Banks[0].samples[46].length.ToString("X");
                if (Banks[0].samples[46].common == true)
                {
                    this.B0_S47_Len.Enabled = false;
                    this.B0_S47_Import.Enabled = false;
                }
                else
                {
                    this.B0_S47_Len.ReadOnly = true;
                }
            }
            if (Banks[0].samples[47] != null)
            {
                this.B0_S48_Enable.Enabled = true;
                this.B0_S48_Enable.Checked = true;
                this.B0_S48_Export.Enabled = true;
                this.B0_S48_Import.Enabled = true;
                this.B0_S48_ID.Text = Banks[0].samples[47].id.ToString();
                int start = Banks[0].samples[47].start;
                int id = Banks[0].samples[47].id;
                this.B0_S48_ID.ReadOnly = true;
                foreach (Sample smp in Banks[0].samples)
                {
                    if (smp != null)
                    {
                        if (IsBetween(start, smp.start, smp.end))
                        {
                            if (Banks[0].samples[47].id > smp.id)
                            {
                                Banks[0].samples[smp.id].parents.Add(id);
                                Banks[0].samples[47].depends.Add(smp.id);
                                this.B0_S48_Export.Enabled = false;
                                this.B0_S48_Import.Enabled = false;
                                if (Banks[0].samples[47].depends.Count == 1)
                                {
                                    //find offset
                                    Banks[0].samples[47].offset =start - smp.start;
                                }
                            }
                        }
                    }
                }
                string deps = "";
                if (Banks[0].samples[47].depends != null)
                {
                    foreach (int dep in Banks[0].samples[47].depends)
                    {
                        deps += dep + ",";
                    }

                }
                this.B0_S48_Dep.Text = deps;
                this.B0_S48_Dep.ReadOnly = true;
                this.B0_S48_Off.Text = Banks[0].samples[47].offset.ToString("X");
                this.B0_S48_Off.ReadOnly = true;
                this.B0_S48_Len.Text = Banks[0].samples[47].length.ToString("X");
                if (Banks[0].samples[47].common == true)
                {
                    this.B0_S48_Len.Enabled = false;
                    this.B0_S48_Import.Enabled = false;
                }
                else
                {
                    this.B0_S48_Len.ReadOnly = true;
                }
            }
            if (Banks[0].samples[48] != null)
            {
                this.B0_S49_Enable.Enabled = true;
                this.B0_S49_Enable.Checked = true;
                this.B0_S49_Export.Enabled = true;
                this.B0_S49_Import.Enabled = true;
                this.B0_S49_ID.Text = Banks[0].samples[48].id.ToString();
                int start = Banks[0].samples[48].start;
                int id = Banks[0].samples[48].id;
                this.B0_S49_ID.ReadOnly = true;
                foreach (Sample smp in Banks[0].samples)
                {
                    if (smp != null)
                    {
                        if (IsBetween(start, smp.start, smp.end))
                        {
                            if (Banks[0].samples[48].id > smp.id)
                            {
                                Banks[0].samples[smp.id].parents.Add(id);
                                Banks[0].samples[48].depends.Add(smp.id);
                                this.B0_S49_Export.Enabled = false;
                                this.B0_S49_Import.Enabled = false;
                                if (Banks[0].samples[48].depends.Count == 1)
                                {
                                    //find offset
                                    Banks[0].samples[48].offset =start - smp.start;
                                }
                            }
                        }
                    }
                }
                string deps = "";
                if (Banks[0].samples[48].depends != null)
                {
                    foreach (int dep in Banks[0].samples[48].depends)
                    {
                        deps += dep + ",";
                    }

                }
                this.B0_S49_Dep.Text = deps;
                this.B0_S49_Dep.ReadOnly = true;
                this.B0_S49_Off.Text = Banks[0].samples[48].offset.ToString("X");
                this.B0_S49_Off.ReadOnly = true;
                this.B0_S49_Len.Text = Banks[0].samples[48].length.ToString("X");
                if (Banks[0].samples[48].common == true)
                {
                    this.B0_S49_Len.Enabled = false;
                    this.B0_S49_Import.Enabled = false;
                }
                else
                {
                    this.B0_S49_Len.ReadOnly = true;
                }
            }
            if (Banks[0].samples[49] != null)
            {
                this.B0_S50_Enable.Enabled = true;
                this.B0_S50_Enable.Checked = true;
                this.B0_S50_Export.Enabled = true;
                this.B0_S50_Import.Enabled = true;
                this.B0_S50_ID.Text = Banks[0].samples[49].id.ToString();
                int start = Banks[0].samples[49].start;
                int id = Banks[0].samples[49].id;
                this.B0_S50_ID.ReadOnly = true;
                foreach (Sample smp in Banks[0].samples)
                {
                    if (smp != null)
                    {
                        if (IsBetween(start, smp.start, smp.end))
                        {
                            if (Banks[0].samples[49].id > smp.id)
                            {
                                Banks[0].samples[smp.id].parents.Add(id);
                                Banks[0].samples[49].depends.Add(smp.id);
                                this.B0_S50_Export.Enabled = false;
                                this.B0_S50_Import.Enabled = false;
                                if (Banks[0].samples[49].depends.Count == 1)
                                {
                                    //find offset
                                    Banks[0].samples[49].offset =start - smp.start;
                                }
                            }
                        }
                    }
                }
                string deps = "";
                if (Banks[0].samples[49].depends != null)
                {
                    foreach (int dep in Banks[0].samples[49].depends)
                    {
                        deps += dep + ",";
                    }

                }
                this.B0_S50_Dep.Text = deps;
                this.B0_S50_Dep.ReadOnly = true;
                this.B0_S50_Off.Text = Banks[0].samples[49].offset.ToString("X");
                this.B0_S50_Off.ReadOnly = true;
                this.B0_S50_Len.Text = Banks[0].samples[49].length.ToString("X");
                if (Banks[0].samples[49].common == true)
                {
                    this.B0_S50_Len.Enabled = false;
                    this.B0_S50_Import.Enabled = false;
                }
                else
                {
                    this.B0_S50_Len.ReadOnly = true;
                }
            }
            if (Banks[0].samples[50] != null)
            {
                this.B0_S51_Enable.Enabled = true;
                this.B0_S51_Enable.Checked = true;
                this.B0_S51_Export.Enabled = true;
                this.B0_S51_Import.Enabled = true;
                this.B0_S51_ID.Text = Banks[0].samples[50].id.ToString();
                int start = Banks[0].samples[50].start;
                int id = Banks[0].samples[50].id;
                this.B0_S51_ID.ReadOnly = true;
                foreach (Sample smp in Banks[0].samples)
                {
                    if (smp != null)
                    {
                        if (IsBetween(start, smp.start, smp.end))
                        {
                            if (Banks[0].samples[50].id > smp.id)
                            {
                                Banks[0].samples[smp.id].parents.Add(id);
                                Banks[0].samples[50].depends.Add(smp.id);
                                this.B0_S51_Export.Enabled = false;
                                this.B0_S51_Import.Enabled = false;
                                if (Banks[0].samples[50].depends.Count == 1)
                                {
                                    //find offset
                                    Banks[0].samples[50].offset =start - smp.start;
                                }
                            }
                        }
                    }
                }
                string deps = "";
                if (Banks[0].samples[50].depends != null)
                {
                    foreach (int dep in Banks[0].samples[50].depends)
                    {
                        deps += dep + ",";
                    }

                }
                this.B0_S51_Dep.Text = deps;
                this.B0_S51_Dep.ReadOnly = true;
                this.B0_S51_Off.Text = Banks[0].samples[50].offset.ToString("X");
                this.B0_S51_Off.ReadOnly = true;
                this.B0_S51_Len.Text = Banks[0].samples[50].length.ToString("X");
                if (Banks[0].samples[50].common == true)
                {
                    this.B0_S51_Len.Enabled = false;
                    this.B0_S51_Import.Enabled = false;
                }
                else
                {
                    this.B0_S51_Len.ReadOnly = true;
                }
            }
            if (Banks[0].samples[51] != null)
            {
                this.B0_S52_Enable.Enabled = true;
                this.B0_S52_Enable.Checked = true;
                this.B0_S52_Export.Enabled = true;
                this.B0_S52_Import.Enabled = true;
                this.B0_S52_ID.Text = Banks[0].samples[51].id.ToString();
                int start = Banks[0].samples[51].start;
                int id = Banks[0].samples[51].id;
                this.B0_S52_ID.ReadOnly = true;
                foreach (Sample smp in Banks[0].samples)
                {
                    if (smp != null)
                    {
                        if (IsBetween(start, smp.start, smp.end))
                        {
                            if (Banks[0].samples[51].id > smp.id)
                            {
                                Banks[0].samples[smp.id].parents.Add(id);
                                Banks[0].samples[51].depends.Add(smp.id);
                                this.B0_S52_Export.Enabled = false;
                                this.B0_S52_Import.Enabled = false;
                                if (Banks[0].samples[51].depends.Count == 1)
                                {
                                    //find offset
                                    Banks[0].samples[51].offset =start - smp.start;
                                }
                            }
                        }
                    }
                }
                string deps = "";
                if (Banks[0].samples[51].depends != null)
                {
                    foreach (int dep in Banks[0].samples[51].depends)
                    {
                        deps += dep + ",";
                    }

                }
                this.B0_S52_Dep.Text = deps;
                this.B0_S52_Dep.ReadOnly = true;
                this.B0_S52_Off.Text = Banks[0].samples[51].offset.ToString("X");
                this.B0_S52_Off.ReadOnly = true;
                this.B0_S52_Len.Text = Banks[0].samples[51].length.ToString("X");
                if (Banks[0].samples[51].common == true)
                {
                    this.B0_S52_Len.Enabled = false;
                    this.B0_S52_Import.Enabled = false;
                }
                else
                {
                    this.B0_S52_Len.ReadOnly = true;
                }
            }
            if (Banks[0].samples[52] != null)
            {
                this.B0_S53_Enable.Enabled = true;
                this.B0_S53_Enable.Checked = true;
                this.B0_S53_Export.Enabled = true;
                this.B0_S53_Import.Enabled = true;
                this.B0_S53_ID.Text = Banks[0].samples[52].id.ToString();
                int start = Banks[0].samples[52].start;
                int id = Banks[0].samples[52].id;
                this.B0_S53_ID.ReadOnly = true;
                foreach (Sample smp in Banks[0].samples)
                {
                    if (smp != null)
                    {
                        if (IsBetween(start, smp.start, smp.end))
                        {
                            if (Banks[0].samples[52].id > smp.id)
                            {
                                Banks[0].samples[smp.id].parents.Add(id);
                                Banks[0].samples[52].depends.Add(smp.id);
                                this.B0_S53_Export.Enabled = false;
                                this.B0_S53_Import.Enabled = false;
                                if (Banks[0].samples[52].depends.Count == 1)
                                {
                                    //find offset
                                    Banks[0].samples[52].offset =start - smp.start;
                                }
                            }
                        }
                    }
                }
                string deps = "";
                if (Banks[0].samples[52].depends != null)
                {
                    foreach (int dep in Banks[0].samples[52].depends)
                    {
                        deps += dep + ",";
                    }

                }
                this.B0_S53_Dep.Text = deps;
                this.B0_S53_Dep.ReadOnly = true;
                this.B0_S53_Off.Text = Banks[0].samples[52].offset.ToString("X");
                this.B0_S53_Off.ReadOnly = true;
                this.B0_S53_Len.Text = Banks[0].samples[52].length.ToString("X");
                if (Banks[0].samples[52].common == true)
                {
                    this.B0_S53_Len.Enabled = false;
                    this.B0_S53_Import.Enabled = false;
                }
                else
                {
                    this.B0_S53_Len.ReadOnly = true;
                }

            }
            if (Banks[0].samples[53] != null)
            {
                this.B0_S54_Enable.Enabled = true;
                this.B0_S54_Enable.Checked = true;
                this.B0_S54_Export.Enabled = true;
                this.B0_S54_Import.Enabled = true;
                this.B0_S54_ID.Text = Banks[0].samples[53].id.ToString();
                int start = Banks[0].samples[53].start;
                int id = Banks[0].samples[53].id;
                this.B0_S54_ID.ReadOnly = true;
                foreach (Sample smp in Banks[0].samples)
                {
                    if (smp != null)
                    {
                        if (IsBetween(start, smp.start, smp.end))
                        {
                            if (Banks[0].samples[53].id > smp.id)
                            {
                                Banks[0].samples[smp.id].parents.Add(id);
                                Banks[0].samples[53].depends.Add(smp.id);
                                this.B0_S54_Export.Enabled = false;
                                this.B0_S54_Import.Enabled = false;
                                if (Banks[0].samples[53].depends.Count == 1)
                                {
                                    //find offset
                                    Banks[0].samples[53].offset =start - smp.start;
                                }
                            }
                        }
                    }
                }
                string deps = "";
                if (Banks[0].samples[53].depends != null)
                {
                    foreach (int dep in Banks[0].samples[53].depends)
                    {
                        deps += dep + ",";
                    }

                }
                this.B0_S54_Dep.Text = deps;
                this.B0_S54_Dep.ReadOnly = true;
                this.B0_S54_Off.Text = Banks[0].samples[53].offset.ToString("X");
                this.B0_S54_Off.ReadOnly = true;
                this.B0_S54_Len.Text = Banks[0].samples[53].length.ToString("X");
                if (Banks[0].samples[53].common == true)
                {
                    this.B0_S54_Len.Enabled = false;
                    this.B0_S54_Import.Enabled = false;
                }
                else
                {
                    this.B0_S54_Len.ReadOnly = true;
                }
            }
            if (Banks[0].samples[54] != null)
            {
                this.B0_S55_Enable.Enabled = true;
                this.B0_S55_Enable.Checked = true;
                this.B0_S55_Export.Enabled = true;
                this.B0_S55_Import.Enabled = true;
                this.B0_S55_ID.Text = Banks[0].samples[54].id.ToString();
                int start = Banks[0].samples[54].start;
                int id = Banks[0].samples[54].id;
                this.B0_S55_ID.ReadOnly = true;
                foreach (Sample smp in Banks[0].samples)
                {
                    if (smp != null)
                    {
                        if (IsBetween(start, smp.start, smp.end))
                        {
                            if (Banks[0].samples[54].id > smp.id)
                            {
                                Banks[0].samples[smp.id].parents.Add(id);
                                Banks[0].samples[54].depends.Add(smp.id);
                                this.B0_S55_Export.Enabled = false;
                                this.B0_S55_Import.Enabled = false;
                                if (Banks[0].samples[54].depends.Count == 1)
                                {
                                    //find offset
                                    Banks[0].samples[54].offset =start - smp.start;
                                }
                            }
                        }
                    }
                }
                string deps = "";
                if (Banks[0].samples[54].depends != null)
                {
                    foreach (int dep in Banks[0].samples[54].depends)
                    {
                        deps += dep + ",";
                    }

                }
                this.B0_S55_Dep.Text = deps;
                this.B0_S55_Dep.ReadOnly = true;
                this.B0_S55_Off.Text = Banks[0].samples[54].offset.ToString("X");
                this.B0_S55_Off.ReadOnly = true;
                this.B0_S55_Len.Text = Banks[0].samples[54].length.ToString("X");
                if (Banks[0].samples[54].common == true)
                {
                    this.B0_S55_Len.Enabled = false;
                    this.B0_S55_Import.Enabled = false;
                }
                else
                {
                    this.B0_S55_Len.ReadOnly = true;
                }
            }
            if (Banks[0].samples[55] != null)
            {
                this.B0_S56_Enable.Enabled = true;
                this.B0_S56_Enable.Checked = true;
                this.B0_S56_Export.Enabled = true;
                this.B0_S56_Import.Enabled = true;
                this.B0_S56_ID.Text = Banks[0].samples[55].id.ToString();
                int start = Banks[0].samples[55].start;
                int id = Banks[0].samples[55].id;
                this.B0_S56_ID.ReadOnly = true;
                foreach (Sample smp in Banks[0].samples)
                {
                    if (smp != null)
                    {
                        if (IsBetween(start, smp.start, smp.end))
                        {
                            if (Banks[0].samples[55].id > smp.id)
                            {
                                Banks[0].samples[smp.id].parents.Add(id);
                                Banks[0].samples[55].depends.Add(smp.id);
                                this.B0_S56_Export.Enabled = false;
                                this.B0_S56_Import.Enabled = false;
                                if (Banks[0].samples[55].depends.Count == 1)
                                {
                                    //find offset
                                    Banks[0].samples[55].offset =start - smp.start;
                                }
                            }
                        }
                    }
                }
                string deps = "";
                if (Banks[0].samples[55].depends != null)
                {
                    foreach (int dep in Banks[0].samples[55].depends)
                    {
                        deps += dep + ",";
                    }

                }
                this.B0_S56_Dep.Text = deps;
                this.B0_S56_Dep.ReadOnly = true;
                this.B0_S56_Off.Text = Banks[0].samples[55].offset.ToString("X");
                this.B0_S56_Off.ReadOnly = true;
                this.B0_S56_Len.Text = Banks[0].samples[55].length.ToString("X");
                if (Banks[0].samples[55].common == true)
                {
                    this.B0_S56_Len.Enabled = false;
                    this.B0_S56_Import.Enabled = false;
                }
                else
                {
                    this.B0_S56_Len.ReadOnly = true;
                }
            }
            if (Banks[0].samples[56] != null)
            {
                this.B0_S57_Enable.Enabled = true;
                this.B0_S57_Enable.Checked = true;
                this.B0_S57_Export.Enabled = true;
                this.B0_S57_Import.Enabled = true;
                this.B0_S57_ID.Text = Banks[0].samples[56].id.ToString();
                int start = Banks[0].samples[56].start;
                int id = Banks[0].samples[56].id;
                this.B0_S57_ID.ReadOnly = true;
                foreach (Sample smp in Banks[0].samples)
                {
                    if (smp != null)
                    {
                        if (IsBetween(start, smp.start, smp.end))
                        {
                            if (Banks[0].samples[56].id > smp.id)
                            {
                                Banks[0].samples[smp.id].parents.Add(id);
                                Banks[0].samples[56].depends.Add(smp.id);
                                this.B0_S57_Export.Enabled = false;
                                this.B0_S57_Import.Enabled = false;
                                if (Banks[0].samples[56].depends.Count == 1)
                                {
                                    //find offset
                                    Banks[0].samples[56].offset =start - smp.start;
                                }
                            }
                        }
                    }
                }
                string deps = "";
                if (Banks[0].samples[56].depends != null)
                {
                    foreach (int dep in Banks[0].samples[56].depends)
                    {
                        deps += dep + ",";
                    }

                }
                this.B0_S57_Dep.Text = deps;
                this.B0_S57_Dep.ReadOnly = true;
                this.B0_S57_Off.Text = Banks[0].samples[56].offset.ToString("X");
                this.B0_S57_Off.ReadOnly = true;
                this.B0_S57_Len.Text = Banks[0].samples[56].length.ToString("X");
                if (Banks[0].samples[56].common == true)
                {
                    this.B0_S57_Len.Enabled = false;
                    this.B0_S57_Import.Enabled = false;
                }
                else
                {
                    this.B0_S57_Len.ReadOnly = true;
                }
            }
            if (Banks[0].samples[57] != null)
            {
                this.B0_S58_Enable.Enabled = true;
                this.B0_S58_Enable.Checked = true;
                this.B0_S58_Export.Enabled = true;
                this.B0_S58_Import.Enabled = true;
                this.B0_S58_ID.Text = Banks[0].samples[57].id.ToString();
                int start = Banks[0].samples[57].start;
                int id = Banks[0].samples[57].id;
                this.B0_S58_ID.ReadOnly = true;
                foreach (Sample smp in Banks[0].samples)
                {
                    if (smp != null)
                    {
                        if (IsBetween(start, smp.start, smp.end))
                        {
                            if (Banks[0].samples[57].id > smp.id)
                            {
                                Banks[0].samples[smp.id].parents.Add(id);
                                Banks[0].samples[57].depends.Add(smp.id);
                                this.B0_S58_Export.Enabled = false;
                                this.B0_S58_Import.Enabled = false;
                                if (Banks[0].samples[57].depends.Count == 1)
                                {
                                    //find offset
                                    Banks[0].samples[57].offset =start - smp.start;
                                }
                            }
                        }
                    }
                }
                string deps = "";
                if (Banks[0].samples[57].depends != null)
                {
                    foreach (int dep in Banks[0].samples[57].depends)
                    {
                        deps += dep + ",";
                    }

                }
                this.B0_S58_Dep.Text = deps;
                this.B0_S58_Dep.ReadOnly = true;
                this.B0_S58_Off.Text = Banks[0].samples[57].offset.ToString("X");
                this.B0_S58_Off.ReadOnly = true;
                this.B0_S58_Len.Text = Banks[0].samples[57].length.ToString("X");
                if (Banks[0].samples[57].common == true)
                {
                    this.B0_S58_Len.Enabled = false;
                    this.B0_S58_Import.Enabled = false;
                }
                else
                {
                    this.B0_S58_Len.ReadOnly = true;
                }
            }
            if (Banks[0].samples[58] != null)
            {
                this.B0_S59_Enable.Enabled = true;
                this.B0_S59_Enable.Checked = true;
                this.B0_S59_Export.Enabled = true;
                this.B0_S59_Import.Enabled = true;
                this.B0_S59_ID.Text = Banks[0].samples[58].id.ToString();
                int start = Banks[0].samples[58].start;
                int id = Banks[0].samples[58].id;
                this.B0_S59_ID.ReadOnly = true;
                foreach (Sample smp in Banks[0].samples)
                {
                    if (smp != null)
                    {
                        if (IsBetween(start, smp.start, smp.end))
                        {
                            if (Banks[0].samples[58].id > smp.id)
                            {
                                Banks[0].samples[smp.id].parents.Add(id);
                                Banks[0].samples[58].depends.Add(smp.id);
                                this.B0_S59_Export.Enabled = false;
                                this.B0_S59_Import.Enabled = false;
                                if (Banks[0].samples[58].depends.Count == 1)
                                {
                                    //find offset
                                    Banks[0].samples[58].offset =start - smp.start;
                                }
                            }
                        }
                    }
                }
                string deps = "";
                if (Banks[0].samples[58].depends != null)
                {
                    foreach (int dep in Banks[0].samples[58].depends)
                    {
                        deps += dep + ",";
                    }

                }
                this.B0_S59_Dep.Text = deps;
                this.B0_S59_Dep.ReadOnly = true;
                this.B0_S59_Off.Text = Banks[0].samples[58].offset.ToString("X");
                this.B0_S59_Off.ReadOnly = true;
                this.B0_S59_Len.Text = Banks[0].samples[58].length.ToString("X");
                if (Banks[0].samples[58].common == true)
                {
                    this.B0_S59_Len.Enabled = false;
                    this.B0_S59_Import.Enabled = false;
                }
                else
                {
                    this.B0_S59_Len.ReadOnly = true;
                }
            }
            if (Banks[0].samples[59] != null)
            {
                this.B0_S60_Enable.Enabled = true;
                this.B0_S60_Enable.Checked = true;
                this.B0_S60_Export.Enabled = true;
                this.B0_S60_Import.Enabled = true;
                this.B0_S60_ID.Text = Banks[0].samples[59].id.ToString();
                int start = Banks[0].samples[59].start;
                int id = Banks[0].samples[59].id;
                this.B0_S60_ID.ReadOnly = true;
                foreach (Sample smp in Banks[0].samples)
                {
                    if (smp != null)
                    {
                        if (IsBetween(start, smp.start, smp.end))
                        {
                            if (Banks[0].samples[59].id > smp.id)
                            {
                                Banks[0].samples[smp.id].parents.Add(id);
                                Banks[0].samples[59].depends.Add(smp.id);
                                this.B0_S60_Export.Enabled = false;
                                this.B0_S60_Import.Enabled = false;
                                if (Banks[0].samples[59].depends.Count == 1)
                                {
                                    //find offset
                                    Banks[0].samples[59].offset =start - smp.start;
                                }
                            }
                        }
                    }
                }
                string deps = "";
                if (Banks[0].samples[59].depends != null)
                {
                    foreach (int dep in Banks[0].samples[59].depends)
                    {
                        deps += dep + ",";
                    }

                }
                this.B0_S60_Dep.Text = deps;
                this.B0_S60_Dep.ReadOnly = true;
                this.B0_S60_Off.Text = Banks[0].samples[59].offset.ToString("X");
                this.B0_S60_Off.ReadOnly = true;
                this.B0_S60_Len.Text = Banks[0].samples[59].length.ToString("X");
                if (Banks[0].samples[59].common == true)
                {
                    this.B0_S60_Len.Enabled = false;
                    this.B0_S60_Import.Enabled = false;
                }
                else
                {
                    this.B0_S60_Len.ReadOnly = true;
                }
            }
            if (Banks[0].samples[60] != null)
            {
                this.B0_S61_Enable.Enabled = true;
                this.B0_S61_Enable.Checked = true;
                this.B0_S61_Export.Enabled = true;
                this.B0_S61_Import.Enabled = true;
                this.B0_S61_ID.Text = Banks[0].samples[60].id.ToString();
                int start = Banks[0].samples[60].start;
                int id = Banks[0].samples[60].id;
                this.B0_S61_ID.ReadOnly = true;
                foreach (Sample smp in Banks[0].samples)
                {
                    if (smp != null)
                    {
                        if (IsBetween(start, smp.start, smp.end))
                        {
                            if (Banks[0].samples[60].id > smp.id)
                            {
                                Banks[0].samples[smp.id].parents.Add(id);
                                Banks[0].samples[60].depends.Add(smp.id);
                                this.B0_S61_Export.Enabled = false;
                                this.B0_S61_Import.Enabled = false;
                                if (Banks[0].samples[60].depends.Count == 1)
                                {
                                    //find offset
                                    Banks[0].samples[60].offset =start - smp.start;
                                }
                            }
                        }
                    }
                }
                string deps = "";
                if (Banks[0].samples[60].depends != null)
                {
                    foreach (int dep in Banks[0].samples[60].depends)
                    {
                        deps += dep + ",";
                    }

                }
                this.B0_S61_Dep.Text = deps;
                this.B0_S61_Dep.ReadOnly = true;
                this.B0_S61_Off.Text = Banks[0].samples[60].offset.ToString("X");
                this.B0_S61_Off.ReadOnly = true;
                this.B0_S61_Len.Text = Banks[0].samples[60].length.ToString("X");
                if (Banks[0].samples[60].common == true)
                {
                    this.B0_S61_Len.Enabled = false;
                    this.B0_S61_Import.Enabled = false;
                }
                else
                {
                    this.B0_S61_Len.ReadOnly = true;
                }
            }
            if (Banks[0].samples[61] != null)
            {
                this.B0_S62_Enable.Enabled = true;
                this.B0_S62_Enable.Checked = true;
                this.B0_S62_Export.Enabled = true;
                this.B0_S62_Import.Enabled = true;
                this.B0_S62_ID.Text = Banks[0].samples[61].id.ToString();
                int start = Banks[0].samples[61].start;
                int id = Banks[0].samples[61].id;
                this.B0_S62_ID.ReadOnly = true;
                foreach (Sample smp in Banks[0].samples)
                {
                    if (smp != null)
                    {
                        if (IsBetween(start, smp.start, smp.end))
                        {
                            if (Banks[0].samples[61].id > smp.id)
                            {
                                Banks[0].samples[smp.id].parents.Add(id);
                                Banks[0].samples[61].depends.Add(smp.id);
                                this.B0_S62_Export.Enabled = false;
                                this.B0_S62_Import.Enabled = false;
                                if (Banks[0].samples[61].depends.Count == 1)
                                {
                                    //find offset
                                    Banks[0].samples[61].offset =start - smp.start;
                                }
                            }
                        }
                    }
                }
                string deps = "";
                if (Banks[0].samples[61].depends != null)
                {
                    foreach (int dep in Banks[0].samples[61].depends)
                    {
                        deps += dep + ",";
                    }

                }
                this.B0_S62_Dep.Text = deps;
                this.B0_S62_Dep.ReadOnly = true;
                this.B0_S62_Off.Text = Banks[0].samples[61].offset.ToString("X");
                this.B0_S62_Off.ReadOnly = true;
                this.B0_S62_Len.Text = Banks[0].samples[61].length.ToString("X");
                if (Banks[0].samples[61].common == true)
                {
                    this.B0_S62_Len.Enabled = false;
                    this.B0_S62_Import.Enabled = false;
                }
                else
                {
                    this.B0_S62_Len.ReadOnly = true;
                }
            }
            if (Banks[0].samples[62] != null)
            {
                this.B0_S63_Enable.Enabled = true;
                this.B0_S63_Enable.Checked = true;
                this.B0_S63_Export.Enabled = true;
                this.B0_S63_Import.Enabled = true;
                this.B0_S63_ID.Text = Banks[0].samples[62].id.ToString();
                int start = Banks[0].samples[62].start;
                int id = Banks[0].samples[62].id;
                this.B0_S63_ID.ReadOnly = true;
                foreach (Sample smp in Banks[0].samples)
                {
                    if (smp != null)
                    {
                        if (IsBetween(start, smp.start, smp.end))
                        {
                            if (Banks[0].samples[62].id > smp.id)
                            {
                                Banks[0].samples[smp.id].parents.Add(id);
                                Banks[0].samples[62].depends.Add(smp.id);
                                this.B0_S63_Export.Enabled = false;
                                this.B0_S63_Import.Enabled = false;
                                if (Banks[0].samples[62].depends.Count == 1)
                                {
                                    //find offset
                                    Banks[0].samples[62].offset =start - smp.start;
                                }
                            }
                        }
                    }
                }
                string deps = "";
                if (Banks[0].samples[62].depends != null)
                {
                    foreach (int dep in Banks[0].samples[62].depends)
                    {
                        deps += dep + ",";
                    }

                }
                this.B0_S63_Dep.Text = deps;
                this.B0_S63_Dep.ReadOnly = true;
                this.B0_S63_Off.Text = Banks[0].samples[62].offset.ToString("X");
                this.B0_S63_Off.ReadOnly = true;
                this.B0_S63_Len.Text = Banks[0].samples[62].length.ToString("X");
                if (Banks[0].samples[62].common == true)
                {
                    this.B0_S63_Len.Enabled = false;
                    this.B0_S63_Import.Enabled = false;
                }
                else
                {
                    this.B0_S63_Len.ReadOnly = true;
                }

            }
            if (Banks[0].samples[63] != null)
            {
                this.B0_S64_Enable.Enabled = true;
                this.B0_S64_Enable.Checked = true;
                this.B0_S64_Export.Enabled = true;
                this.B0_S64_Import.Enabled = true;
                this.B0_S64_ID.Text = Banks[0].samples[63].id.ToString();
                int start = Banks[0].samples[63].start;
                int id = Banks[0].samples[63].id;
                this.B0_S64_ID.ReadOnly = true;
                foreach (Sample smp in Banks[0].samples)
                {
                    if (smp != null)
                    {
                        if (IsBetween(start, smp.start, smp.end))
                        {
                            if (Banks[0].samples[63].id > smp.id)
                            {
                                Banks[0].samples[smp.id].parents.Add(id);
                                Banks[0].samples[63].depends.Add(smp.id);
                                this.B0_S64_Export.Enabled = false;
                                this.B0_S64_Import.Enabled = false;
                                if (Banks[0].samples[63].depends.Count == 1)
                                {
                                    //find offset
                                    Banks[0].samples[63].offset =start - smp.start;
                                }
                            }
                        }
                    }
                }
                string deps = "";
                if (Banks[0].samples[63].depends != null)
                {
                    foreach (int dep in Banks[0].samples[63].depends)
                    {
                        deps += dep + ",";
                    }

                }
                this.B0_S64_Dep.Text = deps;
                this.B0_S64_Dep.ReadOnly = true;
                this.B0_S64_Off.Text = Banks[0].samples[63].offset.ToString("X");
                this.B0_S64_Off.ReadOnly = true;
                this.B0_S64_Len.Text = Banks[0].samples[63].length.ToString("X");
                if (Banks[0].samples[63].common == true)
                {
                    this.B0_S64_Len.Enabled = false;
                    this.B0_S64_Import.Enabled = false;
                }
                else
                {
                    this.B0_S64_Len.ReadOnly = true;
                }
            }
            if (Banks[0].samples[64] != null)
            {
                this.B0_S65_Enable.Enabled = true;
                this.B0_S65_Enable.Checked = true;
                this.B0_S65_Export.Enabled = true;
                this.B0_S65_Import.Enabled = true;
                this.B0_S65_ID.Text = Banks[0].samples[64].id.ToString();
                int start = Banks[0].samples[64].start;
                int id = Banks[0].samples[64].id;
                this.B0_S65_ID.ReadOnly = true;
                foreach (Sample smp in Banks[0].samples)
                {
                    if (smp != null)
                    {
                        if (IsBetween(start, smp.start, smp.end))
                        {
                            if (Banks[0].samples[64].id > smp.id)
                            {
                                Banks[0].samples[smp.id].parents.Add(id);
                                Banks[0].samples[64].depends.Add(smp.id);
                                this.B0_S65_Export.Enabled = false;
                                this.B0_S65_Import.Enabled = false;
                                if (Banks[0].samples[64].depends.Count == 1)
                                {
                                    //find offset
                                    Banks[0].samples[64].offset =start - smp.start;
                                }
                            }
                        }
                    }
                }
                string deps = "";
                if (Banks[0].samples[64].depends != null)
                {
                    foreach (int dep in Banks[0].samples[64].depends)
                    {
                        deps += dep + ",";
                    }

                }
                this.B0_S65_Dep.Text = deps;
                this.B0_S65_Dep.ReadOnly = true;
                this.B0_S65_Off.Text = Banks[0].samples[64].offset.ToString("X");
                this.B0_S65_Off.ReadOnly = true;
                this.B0_S65_Len.Text = Banks[0].samples[64].length.ToString("X");
                if (Banks[0].samples[64].common == true)
                {
                    this.B0_S65_Len.Enabled = false;
                    this.B0_S65_Import.Enabled = false;
                }
                else
                {
                    this.B0_S65_Len.ReadOnly = true;
                }
            }
            if (Banks[0].samples[65] != null)
            {
                this.B0_S66_Enable.Enabled = true;
                this.B0_S66_Enable.Checked = true;
                this.B0_S66_Export.Enabled = true;
                this.B0_S66_Import.Enabled = true;
                this.B0_S66_ID.Text = Banks[0].samples[65].id.ToString();
                int start = Banks[0].samples[65].start;
                int id = Banks[0].samples[65].id;
                this.B0_S66_ID.ReadOnly = true;
                foreach (Sample smp in Banks[0].samples)
                {
                    if (smp != null)
                    {
                        if (IsBetween(start, smp.start, smp.end))
                        {
                            if (Banks[0].samples[65].id > smp.id)
                            {
                                Banks[0].samples[smp.id].parents.Add(id);
                                Banks[0].samples[65].depends.Add(smp.id);
                                this.B0_S66_Export.Enabled = false;
                                this.B0_S66_Import.Enabled = false;
                                if (Banks[0].samples[65].depends.Count == 1)
                                {
                                    //find offset
                                    Banks[0].samples[65].offset =start - smp.start;
                                }
                            }
                        }
                    }
                }
                string deps = "";
                if (Banks[0].samples[65].depends != null)
                {
                    foreach (int dep in Banks[0].samples[65].depends)
                    {
                        deps += dep + ",";
                    }

                }
                this.B0_S66_Dep.Text = deps;
                this.B0_S66_Dep.ReadOnly = true;
                this.B0_S66_Off.Text = Banks[0].samples[65].offset.ToString("X");
                this.B0_S66_Off.ReadOnly = true;
                this.B0_S66_Len.Text = Banks[0].samples[65].length.ToString("X");
                if (Banks[0].samples[65].common == true)
                {
                    this.B0_S66_Len.Enabled = false;
                    this.B0_S66_Import.Enabled = false;
                }
                else
                {
                    this.B0_S66_Len.ReadOnly = true;
                }
            }
            if (Banks[0].samples[66] != null)
            {
                this.B0_S67_Enable.Enabled = true;
                this.B0_S67_Enable.Checked = true;
                this.B0_S67_Export.Enabled = true;
                this.B0_S67_Import.Enabled = true;
                this.B0_S67_ID.Text = Banks[0].samples[66].id.ToString();
                int start = Banks[0].samples[66].start;
                int id = Banks[0].samples[66].id;
                this.B0_S67_ID.ReadOnly = true;
                foreach (Sample smp in Banks[0].samples)
                {
                    if (smp != null)
                    {
                        if (IsBetween(start, smp.start, smp.end))
                        {
                            if (Banks[0].samples[66].id > smp.id)
                            {
                                Banks[0].samples[smp.id].parents.Add(id);
                                Banks[0].samples[66].depends.Add(smp.id);
                                this.B0_S67_Export.Enabled = false;
                                this.B0_S67_Import.Enabled = false;
                                if (Banks[0].samples[66].depends.Count == 1)
                                {
                                    //find offset
                                    Banks[0].samples[66].offset =start - smp.start;
                                }
                            }
                        }
                    }
                }
                string deps = "";
                if (Banks[0].samples[66].depends != null)
                {
                    foreach (int dep in Banks[0].samples[66].depends)
                    {
                        deps += dep + ",";
                    }

                }
                this.B0_S67_Dep.Text = deps;
                this.B0_S67_Dep.ReadOnly = true;
                this.B0_S67_Off.Text = Banks[0].samples[66].offset.ToString("X");
                this.B0_S67_Off.ReadOnly = true;
                this.B0_S67_Len.Text = Banks[0].samples[66].length.ToString("X");
                if (Banks[0].samples[66].common == true)
                {
                    this.B0_S67_Len.Enabled = false;
                    this.B0_S67_Import.Enabled = false;
                }
                else
                {
                    this.B0_S67_Len.ReadOnly = true;
                }
            }
            if (Banks[0].samples[67] != null)
            {
                this.B0_S68_Enable.Enabled = true;
                this.B0_S68_Enable.Checked = true;
                this.B0_S68_Export.Enabled = true;
                this.B0_S68_Import.Enabled = true;
                this.B0_S68_ID.Text = Banks[0].samples[67].id.ToString();
                int start = Banks[0].samples[67].start;
                int id = Banks[0].samples[67].id;
                this.B0_S68_ID.ReadOnly = true;
                foreach (Sample smp in Banks[0].samples)
                {
                    if (smp != null)
                    {
                        if (IsBetween(start, smp.start, smp.end))
                        {
                            if (Banks[0].samples[67].id > smp.id)
                            {
                                Banks[0].samples[smp.id].parents.Add(id);
                                Banks[0].samples[67].depends.Add(smp.id);
                                this.B0_S68_Export.Enabled = false;
                                this.B0_S68_Import.Enabled = false;
                                if (Banks[0].samples[67].depends.Count == 1)
                                {
                                    //find offset
                                    Banks[0].samples[67].offset =start - smp.start;
                                }
                            }
                        }
                    }
                }
                string deps = "";
                if (Banks[0].samples[67].depends != null)
                {
                    foreach (int dep in Banks[0].samples[67].depends)
                    {
                        deps += dep + ",";
                    }

                }
                this.B0_S68_Dep.Text = deps;
                this.B0_S68_Dep.ReadOnly = true;
                this.B0_S68_Off.Text = Banks[0].samples[67].offset.ToString("X");
                this.B0_S68_Off.ReadOnly = true;
                this.B0_S68_Len.Text = Banks[0].samples[67].length.ToString("X");
                if (Banks[0].samples[67].common == true)
                {
                    this.B0_S68_Len.Enabled = false;
                    this.B0_S68_Import.Enabled = false;
                }
                else
                {
                    this.B0_S68_Len.ReadOnly = true;
                }
            }
            if (Banks[0].samples[68] != null)
            {
                this.B0_S69_Enable.Enabled = true;
                this.B0_S69_Enable.Checked = true;
                this.B0_S69_Export.Enabled = true;
                this.B0_S69_Import.Enabled = true;
                this.B0_S69_ID.Text = Banks[0].samples[68].id.ToString();
                int start = Banks[0].samples[68].start;
                int id = Banks[0].samples[68].id;
                this.B0_S69_ID.ReadOnly = true;
                foreach (Sample smp in Banks[0].samples)
                {
                    if (smp != null)
                    {
                        if (IsBetween(start, smp.start, smp.end))
                        {
                            if (Banks[0].samples[68].id > smp.id)
                            {
                                Banks[0].samples[smp.id].parents.Add(id);
                                Banks[0].samples[68].depends.Add(smp.id);
                                this.B0_S69_Export.Enabled = false;
                                this.B0_S69_Import.Enabled = false;
                                if (Banks[0].samples[68].depends.Count == 1)
                                {
                                    //find offset
                                    Banks[0].samples[68].offset =start - smp.start;
                                }
                            }
                        }
                    }
                }
                string deps = "";
                if (Banks[0].samples[68].depends != null)
                {
                    foreach (int dep in Banks[0].samples[68].depends)
                    {
                        deps += dep + ",";
                    }

                }
                this.B0_S69_Dep.Text = deps;
                this.B0_S69_Dep.ReadOnly = true;
                this.B0_S69_Off.Text = Banks[0].samples[68].offset.ToString("X");
                this.B0_S69_Off.ReadOnly = true;
                this.B0_S69_Len.Text = Banks[0].samples[68].length.ToString("X");
                if (Banks[0].samples[68].common == true)
                {
                    this.B0_S69_Len.Enabled = false;
                    this.B0_S69_Import.Enabled = false;
                }
                else
                {
                    this.B0_S69_Len.ReadOnly = true;
                }
            }
            if (Banks[0].samples[69] != null)
            {
                this.B0_S70_Enable.Enabled = true;
                this.B0_S70_Enable.Checked = true;
                this.B0_S70_Export.Enabled = true;
                this.B0_S70_Import.Enabled = true;
                this.B0_S70_ID.Text = Banks[0].samples[69].id.ToString();
                int start = Banks[0].samples[69].start;
                int id = Banks[0].samples[69].id;
                this.B0_S70_ID.ReadOnly = true;
                foreach (Sample smp in Banks[0].samples)
                {
                    if (smp != null)
                    {
                        if (IsBetween(start, smp.start, smp.end))
                        {
                            if (Banks[0].samples[69].id > smp.id)
                            {
                                Banks[0].samples[smp.id].parents.Add(id);
                                Banks[0].samples[69].depends.Add(smp.id);
                                this.B0_S70_Export.Enabled = false;
                                this.B0_S70_Import.Enabled = false;
                                if (Banks[0].samples[69].depends.Count == 1)
                                {
                                    //find offset
                                    Banks[0].samples[69].offset =start - smp.start;
                                }
                            }
                        }
                    }
                }
                string deps = "";
                if (Banks[0].samples[69].depends != null)
                {
                    foreach (int dep in Banks[0].samples[69].depends)
                    {
                        deps += dep + ",";
                    }

                }
                this.B0_S70_Dep.Text = deps;
                this.B0_S70_Dep.ReadOnly = true;
                this.B0_S70_Off.Text = Banks[0].samples[69].offset.ToString("X");
                this.B0_S70_Off.ReadOnly = true;
                this.B0_S70_Len.Text = Banks[0].samples[69].length.ToString("X");
                if (Banks[0].samples[69].common == true)
                {
                    this.B0_S70_Len.Enabled = false;
                    this.B0_S70_Import.Enabled = false;
                }
                else
                {
                    this.B0_S70_Len.ReadOnly = true;
                }
            }
            if (Banks[0].samples[70] != null)
            {
                this.B0_S71_Enable.Enabled = true;
                this.B0_S71_Enable.Checked = true;
                this.B0_S71_Export.Enabled = true;
                this.B0_S71_Import.Enabled = true;
                this.B0_S71_ID.Text = Banks[0].samples[70].id.ToString();
                int start = Banks[0].samples[70].start;
                int id = Banks[0].samples[70].id;
                this.B0_S71_ID.ReadOnly = true;
                foreach (Sample smp in Banks[0].samples)
                {
                    if (smp != null)
                    {
                        if (IsBetween(start, smp.start, smp.end))
                        {
                            if (Banks[0].samples[70].id > smp.id)
                            {
                                Banks[0].samples[smp.id].parents.Add(id);
                                Banks[0].samples[70].depends.Add(smp.id);
                                this.B0_S71_Export.Enabled = false;
                                this.B0_S71_Import.Enabled = false;
                                if (Banks[0].samples[70].depends.Count == 1)
                                {
                                    //find offset
                                    Banks[0].samples[70].offset =start - smp.start;
                                }
                            }
                        }
                    }
                }
                string deps = "";
                if (Banks[0].samples[70].depends != null)
                {
                    foreach (int dep in Banks[0].samples[70].depends)
                    {
                        deps += dep + ",";
                    }

                }
                this.B0_S71_Dep.Text = deps;
                this.B0_S71_Dep.ReadOnly = true;
                this.B0_S71_Off.Text = Banks[0].samples[70].offset.ToString("X");
                this.B0_S71_Off.ReadOnly = true;
                this.B0_S71_Len.Text = Banks[0].samples[70].length.ToString("X");
                if (Banks[0].samples[70].common == true)
                {
                    this.B0_S71_Len.Enabled = false;
                    this.B0_S71_Import.Enabled = false;
                }
                else
                {
                    this.B0_S71_Len.ReadOnly = true;
                }
            }
            if (Banks[0].samples[71] != null)
            {
                this.B0_S72_Enable.Enabled = true;
                this.B0_S72_Enable.Checked = true;
                this.B0_S72_Export.Enabled = true;
                this.B0_S72_Import.Enabled = true;
                this.B0_S72_ID.Text = Banks[0].samples[71].id.ToString();
                int start = Banks[0].samples[71].start;
                int id = Banks[0].samples[71].id;
                this.B0_S72_ID.ReadOnly = true;
                foreach (Sample smp in Banks[0].samples)
                {
                    if (smp != null)
                    {
                        if (IsBetween(start, smp.start, smp.end))
                        {
                            if (Banks[0].samples[71].id > smp.id)
                            {
                                Banks[0].samples[smp.id].parents.Add(id);
                                Banks[0].samples[71].depends.Add(smp.id);
                                this.B0_S72_Export.Enabled = false;
                                this.B0_S72_Import.Enabled = false;
                                if (Banks[0].samples[71].depends.Count == 1)
                                {
                                    //find offset
                                    Banks[0].samples[71].offset =start - smp.start;
                                }
                            }
                        }
                    }
                }
                string deps = "";
                if (Banks[0].samples[71].depends != null)
                {
                    foreach (int dep in Banks[0].samples[71].depends)
                    {
                        deps += dep + ",";
                    }

                }
                this.B0_S72_Dep.Text = deps;
                this.B0_S72_Dep.ReadOnly = true;
                this.B0_S72_Off.Text = Banks[0].samples[71].offset.ToString("X");
                this.B0_S72_Off.ReadOnly = true;
                this.B0_S72_Len.Text = Banks[0].samples[71].length.ToString("X");
                if (Banks[0].samples[71].common == true)
                {
                    this.B0_S72_Len.Enabled = false;
                    this.B0_S72_Import.Enabled = false;
                }
                else
                {
                    this.B0_S72_Len.ReadOnly = true;
                }
            }
            if (Banks[0].samples[72] != null)
            {
                this.B0_S73_Enable.Enabled = true;
                this.B0_S73_Enable.Checked = true;
                this.B0_S73_Export.Enabled = true;
                this.B0_S73_Import.Enabled = true;
                this.B0_S73_ID.Text = Banks[0].samples[72].id.ToString();
                int start = Banks[0].samples[72].start;
                int id = Banks[0].samples[72].id;
                this.B0_S73_ID.ReadOnly = true;
                foreach (Sample smp in Banks[0].samples)
                {
                    if (smp != null)
                    {
                        if (IsBetween(start, smp.start, smp.end))
                        {
                            if (Banks[0].samples[72].id > smp.id)
                            {
                                Banks[0].samples[smp.id].parents.Add(id);
                                Banks[0].samples[72].depends.Add(smp.id);
                                this.B0_S73_Export.Enabled = false;
                                this.B0_S73_Import.Enabled = false;
                                if (Banks[0].samples[72].depends.Count == 1)
                                {
                                    //find offset
                                    Banks[0].samples[72].offset =start - smp.start;
                                }
                            }
                        }
                    }
                }
                string deps = "";
                if (Banks[0].samples[72].depends != null)
                {
                    foreach (int dep in Banks[0].samples[72].depends)
                    {
                        deps += dep + ",";
                    }

                }
                this.B0_S73_Dep.Text = deps;
                this.B0_S73_Dep.ReadOnly = true;
                this.B0_S73_Off.Text = Banks[0].samples[72].offset.ToString("X");
                this.B0_S73_Off.ReadOnly = true;
                this.B0_S73_Len.Text = Banks[0].samples[72].length.ToString("X");
                if (Banks[0].samples[72].common == true)
                {
                    this.B0_S73_Len.Enabled = false;
                    this.B0_S73_Import.Enabled = false;
                }
                else
                {
                    this.B0_S73_Len.ReadOnly = true;
                }

            }
            if (Banks[0].samples[73] != null)
            {
                this.B0_S74_Enable.Enabled = true;
                this.B0_S74_Enable.Checked = true;
                this.B0_S74_Export.Enabled = true;
                this.B0_S74_Import.Enabled = true;
                this.B0_S74_ID.Text = Banks[0].samples[73].id.ToString();
                int start = Banks[0].samples[73].start;
                int id = Banks[0].samples[73].id;
                this.B0_S74_ID.ReadOnly = true;
                foreach (Sample smp in Banks[0].samples)
                {
                    if (smp != null)
                    {
                        if (IsBetween(start, smp.start, smp.end))
                        {
                            if (Banks[0].samples[73].id > smp.id)
                            {
                                Banks[0].samples[smp.id].parents.Add(id);
                                Banks[0].samples[73].depends.Add(smp.id);
                                this.B0_S74_Export.Enabled = false;
                                this.B0_S74_Import.Enabled = false;
                                if (Banks[0].samples[73].depends.Count == 1)
                                {
                                    //find offset
                                    Banks[0].samples[73].offset =start - smp.start;
                                }
                            }
                        }
                    }
                }
                string deps = "";
                if (Banks[0].samples[73].depends != null)
                {
                    foreach (int dep in Banks[0].samples[73].depends)
                    {
                        deps += dep + ",";
                    }

                }
                this.B0_S74_Dep.Text = deps;
                this.B0_S74_Dep.ReadOnly = true;
                this.B0_S74_Off.Text = Banks[0].samples[73].offset.ToString("X");
                this.B0_S74_Off.ReadOnly = true;
                this.B0_S74_Len.Text = Banks[0].samples[73].length.ToString("X");
                if (Banks[0].samples[73].common == true)
                {
                    this.B0_S74_Len.Enabled = false;
                    this.B0_S74_Import.Enabled = false;
                }
                else
                {
                    this.B0_S74_Len.ReadOnly = true;
                }
            }
            if (Banks[0].samples[74] != null)
            {
                this.B0_S75_Enable.Enabled = true;
                this.B0_S75_Enable.Checked = true;
                this.B0_S75_Export.Enabled = true;
                this.B0_S75_Import.Enabled = true;
                this.B0_S75_ID.Text = Banks[0].samples[74].id.ToString();
                int start = Banks[0].samples[74].start;
                int id = Banks[0].samples[74].id;
                this.B0_S75_ID.ReadOnly = true;
                foreach (Sample smp in Banks[0].samples)
                {
                    if (smp != null)
                    {
                        if (IsBetween(start, smp.start, smp.end))
                        {
                            if (Banks[0].samples[74].id > smp.id)
                            {
                                Banks[0].samples[smp.id].parents.Add(id);
                                Banks[0].samples[74].depends.Add(smp.id);
                                this.B0_S75_Export.Enabled = false;
                                this.B0_S75_Import.Enabled = false;
                                if (Banks[0].samples[74].depends.Count == 1)
                                {
                                    //find offset
                                    Banks[0].samples[74].offset =start - smp.start;
                                }
                            }
                        }
                    }
                }
                string deps = "";
                if (Banks[0].samples[74].depends != null)
                {
                    foreach (int dep in Banks[0].samples[74].depends)
                    {
                        deps += dep + ",";
                    }

                }
                this.B0_S75_Dep.Text = deps;
                this.B0_S75_Dep.ReadOnly = true;
                this.B0_S75_Off.Text = Banks[0].samples[74].offset.ToString("X");
                this.B0_S75_Off.ReadOnly = true;
                this.B0_S75_Len.Text = Banks[0].samples[74].length.ToString("X");
                if (Banks[0].samples[74].common == true)
                {
                    this.B0_S75_Len.Enabled = false;
                    this.B0_S75_Import.Enabled = false;
                }
                else
                {
                    this.B0_S75_Len.ReadOnly = true;
                }
            }
            if (Banks[0].samples[75] != null)
            {
                this.B0_S76_Enable.Enabled = true;
                this.B0_S76_Enable.Checked = true;
                this.B0_S76_Export.Enabled = true;
                this.B0_S76_Import.Enabled = true;
                this.B0_S76_ID.Text = Banks[0].samples[75].id.ToString();
                int start = Banks[0].samples[75].start;
                int id = Banks[0].samples[75].id;
                this.B0_S76_ID.ReadOnly = true;
                foreach (Sample smp in Banks[0].samples)
                {
                    if (smp != null)
                    {
                        if (IsBetween(start, smp.start, smp.end))
                        {
                            if (Banks[0].samples[75].id > smp.id)
                            {
                                Banks[0].samples[smp.id].parents.Add(id);
                                Banks[0].samples[75].depends.Add(smp.id);
                                this.B0_S76_Export.Enabled = false;
                                this.B0_S76_Import.Enabled = false;
                                if (Banks[0].samples[75].depends.Count == 1)
                                {
                                    //find offset
                                    Banks[0].samples[75].offset =start - smp.start;
                                }
                            }
                        }
                    }
                }
                string deps = "";
                if (Banks[0].samples[75].depends != null)
                {
                    foreach (int dep in Banks[0].samples[75].depends)
                    {
                        deps += dep + ",";
                    }

                }
                this.B0_S76_Dep.Text = deps;
                this.B0_S76_Dep.ReadOnly = true;
                this.B0_S76_Off.Text = Banks[0].samples[75].offset.ToString("X");
                this.B0_S76_Off.ReadOnly = true;
                this.B0_S76_Len.Text = Banks[0].samples[75].length.ToString("X");
                if (Banks[0].samples[75].common == true)
                {
                    this.B0_S76_Len.Enabled = false;
                    this.B0_S76_Import.Enabled = false;
                }
                else
                {
                    this.B0_S76_Len.ReadOnly = true;
                }
            }
            if (Banks[0].samples[76] != null)
            {
                this.B0_S77_Enable.Enabled = true;
                this.B0_S77_Enable.Checked = true;
                this.B0_S77_Export.Enabled = true;
                this.B0_S77_Import.Enabled = true;
                this.B0_S77_ID.Text = Banks[0].samples[76].id.ToString();
                int start = Banks[0].samples[76].start;
                int id = Banks[0].samples[76].id;
                this.B0_S77_ID.ReadOnly = true;
                foreach (Sample smp in Banks[0].samples)
                {
                    if (smp != null)
                    {
                        if (IsBetween(start, smp.start, smp.end))
                        {
                            if (Banks[0].samples[76].id > smp.id)
                            {
                                Banks[0].samples[smp.id].parents.Add(id);
                                Banks[0].samples[76].depends.Add(smp.id);
                                this.B0_S77_Export.Enabled = false;
                                this.B0_S77_Import.Enabled = false;
                                if (Banks[0].samples[76].depends.Count == 1)
                                {
                                    //find offset
                                    Banks[0].samples[76].offset =start - smp.start;
                                }
                            }
                        }
                    }
                }
                string deps = "";
                if (Banks[0].samples[76].depends != null)
                {
                    foreach (int dep in Banks[0].samples[76].depends)
                    {
                        deps += dep + ",";
                    }

                }
                this.B0_S77_Dep.Text = deps;
                this.B0_S77_Dep.ReadOnly = true;
                this.B0_S77_Off.Text = Banks[0].samples[76].offset.ToString("X");
                this.B0_S77_Off.ReadOnly = true;
                this.B0_S77_Len.Text = Banks[0].samples[76].length.ToString("X");
                if (Banks[0].samples[76].common == true)
                {
                    this.B0_S77_Len.Enabled = false;
                    this.B0_S77_Import.Enabled = false;
                }
                else
                {
                    this.B0_S77_Len.ReadOnly = true;
                }
            }
            if (Banks[0].samples[77] != null)
            {
                this.B0_S78_Enable.Enabled = true;
                this.B0_S78_Enable.Checked = true;
                this.B0_S78_Export.Enabled = true;
                this.B0_S78_Import.Enabled = true;
                this.B0_S78_ID.Text = Banks[0].samples[77].id.ToString();
                int start = Banks[0].samples[77].start;
                int id = Banks[0].samples[77].id;
                this.B0_S78_ID.ReadOnly = true;
                foreach (Sample smp in Banks[0].samples)
                {
                    if (smp != null)
                    {
                        if (IsBetween(start, smp.start, smp.end))
                        {
                            if (Banks[0].samples[77].id > smp.id)
                            {
                                Banks[0].samples[smp.id].parents.Add(id);
                                Banks[0].samples[77].depends.Add(smp.id);
                                this.B0_S78_Export.Enabled = false;
                                this.B0_S78_Import.Enabled = false;
                                if (Banks[0].samples[77].depends.Count == 1)
                                {
                                    //find offset
                                    Banks[0].samples[77].offset =start - smp.start;
                                }
                            }
                        }
                    }
                }
                string deps = "";
                if (Banks[0].samples[77].depends != null)
                {
                    foreach (int dep in Banks[0].samples[77].depends)
                    {
                        deps += dep + ",";
                    }

                }
                this.B0_S78_Dep.Text = deps;
                this.B0_S78_Dep.ReadOnly = true;
                this.B0_S78_Off.Text = Banks[0].samples[77].offset.ToString("X");
                this.B0_S78_Off.ReadOnly = true;
                this.B0_S78_Len.Text = Banks[0].samples[77].length.ToString("X");
                if (Banks[0].samples[77].common == true)
                {
                    this.B0_S78_Len.Enabled = false;
                    this.B0_S78_Import.Enabled = false;
                }
                else
                {
                    this.B0_S78_Len.ReadOnly = true;
                }
            }
            if (Banks[0].samples[78] != null)
            {
                this.B0_S79_Enable.Enabled = true;
                this.B0_S79_Enable.Checked = true;
                this.B0_S79_Export.Enabled = true;
                this.B0_S79_Import.Enabled = true;
                this.B0_S79_ID.Text = Banks[0].samples[78].id.ToString();
                int start = Banks[0].samples[78].start;
                int id = Banks[0].samples[78].id;
                this.B0_S79_ID.ReadOnly = true;
                foreach (Sample smp in Banks[0].samples)
                {
                    if (smp != null)
                    {
                        if (IsBetween(start, smp.start, smp.end))
                        {
                            if (Banks[0].samples[78].id > smp.id)
                            {
                                Banks[0].samples[smp.id].parents.Add(id);
                                Banks[0].samples[78].depends.Add(smp.id);
                                this.B0_S79_Export.Enabled = false;
                                this.B0_S79_Import.Enabled = false;
                                if (Banks[0].samples[78].depends.Count == 1)
                                {
                                    //find offset
                                    Banks[0].samples[78].offset =start - smp.start;
                                }
                            }
                        }
                    }
                }
                string deps = "";
                if (Banks[0].samples[78].depends != null)
                {
                    foreach (int dep in Banks[0].samples[78].depends)
                    {
                        deps += dep + ",";
                    }

                }
                this.B0_S79_Dep.Text = deps;
                this.B0_S79_Dep.ReadOnly = true;
                this.B0_S79_Off.Text = Banks[0].samples[78].offset.ToString("X");
                this.B0_S79_Off.ReadOnly = true;
                this.B0_S79_Len.Text = Banks[0].samples[78].length.ToString("X");
                if (Banks[0].samples[78].common == true)
                {
                    this.B0_S79_Len.Enabled = false;
                    this.B0_S79_Import.Enabled = false;
                }
                else
                {
                    this.B0_S79_Len.ReadOnly = true;
                }
            }
            if (Banks[0].samples[79] != null)
            {
                this.B0_S80_Enable.Enabled = true;
                this.B0_S80_Enable.Checked = true;
                this.B0_S80_Export.Enabled = true;
                this.B0_S80_Import.Enabled = true;
                this.B0_S80_ID.Text = Banks[0].samples[79].id.ToString();
                int start = Banks[0].samples[79].start;
                int id = Banks[0].samples[79].id;
                this.B0_S80_ID.ReadOnly = true;
                foreach (Sample smp in Banks[0].samples)
                {
                    if (smp != null)
                    {
                        if (IsBetween(start, smp.start, smp.end))
                        {
                            if (Banks[0].samples[79].id > smp.id)
                            {
                                Banks[0].samples[smp.id].parents.Add(id);
                                Banks[0].samples[79].depends.Add(smp.id);
                                this.B0_S80_Export.Enabled = false;
                                this.B0_S80_Import.Enabled = false;
                                if (Banks[0].samples[79].depends.Count == 1)
                                {
                                    //find offset
                                    Banks[0].samples[79].offset =start - smp.start;
                                }
                            }
                        }
                    }
                }
                string deps = "";
                if (Banks[0].samples[79].depends != null)
                {
                    foreach (int dep in Banks[0].samples[79].depends)
                    {
                        deps += dep + ",";
                    }

                }
                this.B0_S80_Dep.Text = deps;
                this.B0_S80_Dep.ReadOnly = true;
                this.B0_S80_Off.Text = Banks[0].samples[79].offset.ToString("X");
                this.B0_S80_Off.ReadOnly = true;
                this.B0_S80_Len.Text = Banks[0].samples[79].length.ToString("X");
                if (Banks[0].samples[79].common == true)
                {
                    this.B0_S80_Len.Enabled = false;
                    this.B0_S80_Import.Enabled = false;
                }
                else
                {
                    this.B0_S80_Len.ReadOnly = true;
                }
            }
            if (Banks[0].samples[80] != null)
            {
                this.B0_S81_Enable.Enabled = true;
                this.B0_S81_Enable.Checked = true;
                this.B0_S81_Export.Enabled = true;
                this.B0_S81_Import.Enabled = true;
                this.B0_S81_ID.Text = Banks[0].samples[80].id.ToString();
                int start = Banks[0].samples[80].start;
                int id = Banks[0].samples[80].id;
                this.B0_S81_ID.ReadOnly = true;
                foreach (Sample smp in Banks[0].samples)
                {
                    if (smp != null)
                    {
                        if (IsBetween(start, smp.start, smp.end))
                        {
                            if (Banks[0].samples[80].id > smp.id)
                            {
                                Banks[0].samples[smp.id].parents.Add(id);
                                Banks[0].samples[80].depends.Add(smp.id);
                                this.B0_S81_Export.Enabled = false;
                                this.B0_S81_Import.Enabled = false;
                                if (Banks[0].samples[80].depends.Count == 1)
                                {
                                    //find offset
                                    Banks[0].samples[80].offset =start - smp.start;
                                }
                            }
                        }
                    }
                }
                string deps = "";
                if (Banks[0].samples[80].depends != null)
                {
                    foreach (int dep in Banks[0].samples[80].depends)
                    {
                        deps += dep + ",";
                    }

                }
                this.B0_S81_Dep.Text = deps;
                this.B0_S81_Dep.ReadOnly = true;
                this.B0_S81_Off.Text = Banks[0].samples[80].offset.ToString("X");
                this.B0_S81_Off.ReadOnly = true;
                this.B0_S81_Len.Text = Banks[0].samples[80].length.ToString("X");
                if (Banks[0].samples[80].common == true)
                {
                    this.B0_S81_Len.Enabled = false;
                    this.B0_S81_Import.Enabled = false;
                }
                else
                {
                    this.B0_S81_Len.ReadOnly = true;
                }
            }
            if (Banks[0].samples[81] != null)
            {
                this.B0_S82_Enable.Enabled = true;
                this.B0_S82_Enable.Checked = true;
                this.B0_S82_Export.Enabled = true;
                this.B0_S82_Import.Enabled = true;
                this.B0_S82_ID.Text = Banks[0].samples[81].id.ToString();
                int start = Banks[0].samples[81].start;
                int id = Banks[0].samples[81].id;
                this.B0_S82_ID.ReadOnly = true;
                foreach (Sample smp in Banks[0].samples)
                {
                    if (smp != null)
                    {
                        if (IsBetween(start, smp.start, smp.end))
                        {
                            if (Banks[0].samples[81].id > smp.id)
                            {
                                Banks[0].samples[smp.id].parents.Add(id);
                                Banks[0].samples[81].depends.Add(smp.id);
                                this.B0_S82_Export.Enabled = false;
                                this.B0_S82_Import.Enabled = false;
                                if (Banks[0].samples[81].depends.Count == 1)
                                {
                                    //find offset
                                    Banks[0].samples[81].offset =start - smp.start;
                                }
                            }
                        }
                    }
                }
                string deps = "";
                if (Banks[0].samples[81].depends != null)
                {
                    foreach (int dep in Banks[0].samples[81].depends)
                    {
                        deps += dep + ",";
                    }

                }
                this.B0_S82_Dep.Text = deps;
                this.B0_S82_Dep.ReadOnly = true;
                this.B0_S82_Off.Text = Banks[0].samples[81].offset.ToString("X");
                this.B0_S82_Off.ReadOnly = true;
                this.B0_S82_Len.Text = Banks[0].samples[81].length.ToString("X");
                if (Banks[0].samples[81].common == true)
                {
                    this.B0_S82_Len.Enabled = false;
                    this.B0_S82_Import.Enabled = false;
                }
                else
                {
                    this.B0_S82_Len.ReadOnly = true;
                }
            }
            if (Banks[0].samples[82] != null)
            {
                this.B0_S83_Enable.Enabled = true;
                this.B0_S83_Enable.Checked = true;
                this.B0_S83_Export.Enabled = true;
                this.B0_S83_Import.Enabled = true;
                this.B0_S83_ID.Text = Banks[0].samples[82].id.ToString();
                int start = Banks[0].samples[82].start;
                int id = Banks[0].samples[82].id;
                this.B0_S83_ID.ReadOnly = true;
                foreach (Sample smp in Banks[0].samples)
                {
                    if (smp != null)
                    {
                        if (IsBetween(start, smp.start, smp.end))
                        {
                            if (Banks[0].samples[82].id > smp.id)
                            {
                                Banks[0].samples[smp.id].parents.Add(id);
                                Banks[0].samples[82].depends.Add(smp.id);
                                this.B0_S83_Export.Enabled = false;
                                this.B0_S83_Import.Enabled = false;
                                if (Banks[0].samples[82].depends.Count == 1)
                                {
                                    //find offset
                                    Banks[0].samples[82].offset =start - smp.start;
                                }
                            }
                        }
                    }
                }
                string deps = "";
                if (Banks[0].samples[82].depends != null)
                {
                    foreach (int dep in Banks[0].samples[82].depends)
                    {
                        deps += dep + ",";
                    }

                }
                this.B0_S83_Dep.Text = deps;
                this.B0_S83_Dep.ReadOnly = true;
                this.B0_S83_Off.Text = Banks[0].samples[82].offset.ToString("X");
                this.B0_S83_Off.ReadOnly = true;
                this.B0_S83_Len.Text = Banks[0].samples[82].length.ToString("X");
                if (Banks[0].samples[82].common == true)
                {
                    this.B0_S83_Len.Enabled = false;
                    this.B0_S83_Import.Enabled = false;
                }
                else
                {
                    this.B0_S83_Len.ReadOnly = true;
                }

            }
            if (Banks[0].samples[83] != null)
            {
                this.B0_S84_Enable.Enabled = true;
                this.B0_S84_Enable.Checked = true;
                this.B0_S84_Export.Enabled = true;
                this.B0_S84_Import.Enabled = true;
                this.B0_S84_ID.Text = Banks[0].samples[83].id.ToString();
                int start = Banks[0].samples[83].start;
                int id = Banks[0].samples[83].id;
                this.B0_S84_ID.ReadOnly = true;
                foreach (Sample smp in Banks[0].samples)
                {
                    if (smp != null)
                    {
                        if (IsBetween(start, smp.start, smp.end))
                        {
                            if (Banks[0].samples[83].id > smp.id)
                            {
                                Banks[0].samples[smp.id].parents.Add(id);
                                Banks[0].samples[83].depends.Add(smp.id);
                                this.B0_S84_Export.Enabled = false;
                                this.B0_S84_Import.Enabled = false;
                                if (Banks[0].samples[83].depends.Count == 1)
                                {
                                    //find offset
                                    Banks[0].samples[83].offset =start - smp.start;
                                }
                            }
                        }
                    }
                }
                string deps = "";
                if (Banks[0].samples[83].depends != null)
                {
                    foreach (int dep in Banks[0].samples[83].depends)
                    {
                        deps += dep + ",";
                    }

                }
                this.B0_S84_Dep.Text = deps;
                this.B0_S84_Dep.ReadOnly = true;
                this.B0_S84_Off.Text = Banks[0].samples[83].offset.ToString("X");
                this.B0_S84_Off.ReadOnly = true;
                this.B0_S84_Len.Text = Banks[0].samples[83].length.ToString("X");
                if (Banks[0].samples[83].common == true)
                {
                    this.B0_S84_Len.Enabled = false;
                    this.B0_S84_Import.Enabled = false;
                }
                else
                {
                    this.B0_S84_Len.ReadOnly = true;
                }
            }
            if (Banks[0].samples[84] != null)
            {
                this.B0_S85_Enable.Enabled = true;
                this.B0_S85_Enable.Checked = true;
                this.B0_S85_Export.Enabled = true;
                this.B0_S85_Import.Enabled = true;
                this.B0_S85_ID.Text = Banks[0].samples[84].id.ToString();
                int start = Banks[0].samples[84].start;
                int id = Banks[0].samples[84].id;
                this.B0_S85_ID.ReadOnly = true;
                foreach (Sample smp in Banks[0].samples)
                {
                    if (smp != null)
                    {
                        if (IsBetween(start, smp.start, smp.end))
                        {
                            if (Banks[0].samples[84].id > smp.id)
                            {
                                Banks[0].samples[smp.id].parents.Add(id);
                                Banks[0].samples[84].depends.Add(smp.id);
                                this.B0_S85_Export.Enabled = false;
                                this.B0_S85_Import.Enabled = false;
                                if (Banks[0].samples[84].depends.Count == 1)
                                {
                                    //find offset
                                    Banks[0].samples[84].offset =start - smp.start;
                                }
                            }
                        }
                    }
                }
                string deps = "";
                if (Banks[0].samples[84].depends != null)
                {
                    foreach (int dep in Banks[0].samples[84].depends)
                    {
                        deps += dep + ",";
                    }

                }
                this.B0_S85_Dep.Text = deps;
                this.B0_S85_Dep.ReadOnly = true;
                this.B0_S85_Off.Text = Banks[0].samples[84].offset.ToString("X");
                this.B0_S85_Off.ReadOnly = true;
                this.B0_S85_Len.Text = Banks[0].samples[84].length.ToString("X");
                if (Banks[0].samples[84].common == true)
                {
                    this.B0_S85_Len.Enabled = false;
                    this.B0_S85_Import.Enabled = false;
                }
                else
                {
                    this.B0_S85_Len.ReadOnly = true;
                }
            }
            if (Banks[0].samples[85] != null)
            {
                this.B0_S86_Enable.Enabled = true;
                this.B0_S86_Enable.Checked = true;
                this.B0_S86_Export.Enabled = true;
                this.B0_S86_Import.Enabled = true;
                this.B0_S86_ID.Text = Banks[0].samples[85].id.ToString();
                int start = Banks[0].samples[85].start;
                int id = Banks[0].samples[85].id;
                this.B0_S86_ID.ReadOnly = true;
                foreach (Sample smp in Banks[0].samples)
                {
                    if (smp != null)
                    {
                        if (IsBetween(start, smp.start, smp.end))
                        {
                            if (Banks[0].samples[85].id > smp.id)
                            {
                                Banks[0].samples[smp.id].parents.Add(id);
                                Banks[0].samples[85].depends.Add(smp.id);
                                this.B0_S86_Export.Enabled = false;
                                this.B0_S86_Import.Enabled = false;
                                if (Banks[0].samples[85].depends.Count == 1)
                                {
                                    //find offset
                                    Banks[0].samples[85].offset =start - smp.start;
                                }
                            }
                        }
                    }
                }
                string deps = "";
                if (Banks[0].samples[85].depends != null)
                {
                    foreach (int dep in Banks[0].samples[85].depends)
                    {
                        deps += dep + ",";
                    }

                }
                this.B0_S86_Dep.Text = deps;
                this.B0_S86_Dep.ReadOnly = true;
                this.B0_S86_Off.Text = Banks[0].samples[85].offset.ToString("X");
                this.B0_S86_Off.ReadOnly = true;
                this.B0_S86_Len.Text = Banks[0].samples[85].length.ToString("X");
                if (Banks[0].samples[85].common == true)
                {
                    this.B0_S86_Len.Enabled = false;
                    this.B0_S86_Import.Enabled = false;
                }
                else
                {
                    this.B0_S86_Len.ReadOnly = true;
                }
            }
            if (Banks[0].samples[86] != null)
            {
                this.B0_S87_Enable.Enabled = true;
                this.B0_S87_Enable.Checked = true;
                this.B0_S87_Export.Enabled = true;
                this.B0_S87_Import.Enabled = true;
                this.B0_S87_ID.Text = Banks[0].samples[86].id.ToString();
                int start = Banks[0].samples[86].start;
                int id = Banks[0].samples[86].id;
                this.B0_S87_ID.ReadOnly = true;
                foreach (Sample smp in Banks[0].samples)
                {
                    if (smp != null)
                    {
                        if (IsBetween(start, smp.start, smp.end))
                        {
                            if (Banks[0].samples[86].id > smp.id)
                            {
                                Banks[0].samples[smp.id].parents.Add(id);
                                Banks[0].samples[86].depends.Add(smp.id);
                                this.B0_S87_Export.Enabled = false;
                                this.B0_S87_Import.Enabled = false;
                                if (Banks[0].samples[86].depends.Count == 1)
                                {
                                    //find offset
                                    Banks[0].samples[86].offset =start - smp.start;
                                }
                            }
                        }
                    }
                }
                string deps = "";
                if (Banks[0].samples[86].depends != null)
                {
                    foreach (int dep in Banks[0].samples[86].depends)
                    {
                        deps += dep + ",";
                    }

                }
                this.B0_S87_Dep.Text = deps;
                this.B0_S87_Dep.ReadOnly = true;
                this.B0_S87_Off.Text = Banks[0].samples[86].offset.ToString("X");
                this.B0_S87_Off.ReadOnly = true;
                this.B0_S87_Len.Text = Banks[0].samples[86].length.ToString("X");
                if (Banks[0].samples[86].common == true)
                {
                    this.B0_S87_Len.Enabled = false;
                    this.B0_S87_Import.Enabled = false;
                }
                else
                {
                    this.B0_S87_Len.ReadOnly = true;
                }
            }
            if (Banks[0].samples[87] != null)
            {
                this.B0_S88_Enable.Enabled = true;
                this.B0_S88_Enable.Checked = true;
                this.B0_S88_Export.Enabled = true;
                this.B0_S88_Import.Enabled = true;
                this.B0_S88_ID.Text = Banks[0].samples[87].id.ToString();
                int start = Banks[0].samples[87].start;
                int id = Banks[0].samples[87].id;
                this.B0_S88_ID.ReadOnly = true;
                foreach (Sample smp in Banks[0].samples)
                {
                    if (smp != null)
                    {
                        if (IsBetween(start, smp.start, smp.end))
                        {
                            if (Banks[0].samples[87].id > smp.id)
                            {
                                Banks[0].samples[smp.id].parents.Add(id);
                                Banks[0].samples[87].depends.Add(smp.id);
                                this.B0_S88_Export.Enabled = false;
                                this.B0_S88_Import.Enabled = false;
                                if (Banks[0].samples[87].depends.Count == 1)
                                {
                                    //find offset
                                    Banks[0].samples[87].offset =start - smp.start;
                                }
                            }
                        }
                    }
                }
                string deps = "";
                if (Banks[0].samples[87].depends != null)
                {
                    foreach (int dep in Banks[0].samples[87].depends)
                    {
                        deps += dep + ",";
                    }

                }
                this.B0_S88_Dep.Text = deps;
                this.B0_S88_Dep.ReadOnly = true;
                this.B0_S88_Off.Text = Banks[0].samples[87].offset.ToString("X");
                this.B0_S88_Off.ReadOnly = true;
                this.B0_S88_Len.Text = Banks[0].samples[87].length.ToString("X");
                if (Banks[0].samples[87].common == true)
                {
                    this.B0_S88_Len.Enabled = false;
                    this.B0_S88_Import.Enabled = false;
                }
                else
                {
                    this.B0_S88_Len.ReadOnly = true;
                }
            }
            if (Banks[0].samples[88] != null)
            {
                this.B0_S89_Enable.Enabled = true;
                this.B0_S89_Enable.Checked = true;
                this.B0_S89_Export.Enabled = true;
                this.B0_S89_Import.Enabled = true;
                this.B0_S89_ID.Text = Banks[0].samples[88].id.ToString();
                int start = Banks[0].samples[88].start;
                int id = Banks[0].samples[88].id;
                this.B0_S89_ID.ReadOnly = true;
                foreach (Sample smp in Banks[0].samples)
                {
                    if (smp != null)
                    {
                        if (IsBetween(start, smp.start, smp.end))
                        {
                            if (Banks[0].samples[88].id > smp.id)
                            {
                                Banks[0].samples[smp.id].parents.Add(id);
                                Banks[0].samples[88].depends.Add(smp.id);
                                this.B0_S89_Export.Enabled = false;
                                this.B0_S89_Import.Enabled = false;
                                if (Banks[0].samples[88].depends.Count == 1)
                                {
                                    //find offset
                                    Banks[0].samples[88].offset =start - smp.start;
                                }
                            }
                        }
                    }
                }
                string deps = "";
                if (Banks[0].samples[88].depends != null)
                {
                    foreach (int dep in Banks[0].samples[88].depends)
                    {
                        deps += dep + ",";
                    }

                }
                this.B0_S89_Dep.Text = deps;
                this.B0_S89_Dep.ReadOnly = true;
                this.B0_S89_Off.Text = Banks[0].samples[88].offset.ToString("X");
                this.B0_S89_Off.ReadOnly = true;
                this.B0_S89_Len.Text = Banks[0].samples[88].length.ToString("X");
                if (Banks[0].samples[88].common == true)
                {
                    this.B0_S89_Len.Enabled = false;
                    this.B0_S89_Import.Enabled = false;
                }
                else
                {
                    this.B0_S89_Len.ReadOnly = true;
                }
            }
            if (Banks[0].samples[89] != null)
            {
                this.B0_S90_Enable.Enabled = true;
                this.B0_S90_Enable.Checked = true;
                this.B0_S90_Export.Enabled = true;
                this.B0_S90_Import.Enabled = true;
                this.B0_S90_ID.Text = Banks[0].samples[89].id.ToString();
                int start = Banks[0].samples[89].start;
                int id = Banks[0].samples[89].id;
                this.B0_S90_ID.ReadOnly = true;
                foreach (Sample smp in Banks[0].samples)
                {
                    if (smp != null)
                    {
                        if (IsBetween(start, smp.start, smp.end))
                        {
                            if (Banks[0].samples[89].id > smp.id)
                            {
                                Banks[0].samples[smp.id].parents.Add(id);
                                Banks[0].samples[89].depends.Add(smp.id);
                                this.B0_S90_Export.Enabled = false;
                                this.B0_S90_Import.Enabled = false;
                                if (Banks[0].samples[89].depends.Count == 1)
                                {
                                    //find offset
                                    Banks[0].samples[89].offset =start - smp.start;
                                }
                            }
                        }
                    }
                }
                string deps = "";
                if (Banks[0].samples[89].depends != null)
                {
                    foreach (int dep in Banks[0].samples[89].depends)
                    {
                        deps += dep + ",";
                    }

                }
                this.B0_S90_Dep.Text = deps;
                this.B0_S90_Dep.ReadOnly = true;
                this.B0_S90_Off.Text = Banks[0].samples[89].offset.ToString("X");
                this.B0_S90_Off.ReadOnly = true;
                this.B0_S90_Len.Text = Banks[0].samples[89].length.ToString("X");
                if (Banks[0].samples[89].common == true)
                {
                    this.B0_S90_Len.Enabled = false;
                    this.B0_S90_Import.Enabled = false;
                }
                else
                {
                    this.B0_S90_Len.ReadOnly = true;
                }
            }
            if (Banks[0].samples[90] != null)
            {
                this.B0_S91_Enable.Enabled = true;
                this.B0_S91_Enable.Checked = true;
                this.B0_S91_Export.Enabled = true;
                this.B0_S91_Import.Enabled = true;
                this.B0_S91_ID.Text = Banks[0].samples[90].id.ToString();
                int start = Banks[0].samples[90].start;
                int id = Banks[0].samples[90].id;
                this.B0_S91_ID.ReadOnly = true;
                foreach (Sample smp in Banks[0].samples)
                {
                    if (smp != null)
                    {
                        if (IsBetween(start, smp.start, smp.end))
                        {
                            if (Banks[0].samples[90].id > smp.id)
                            {
                                Banks[0].samples[smp.id].parents.Add(id);
                                Banks[0].samples[90].depends.Add(smp.id);
                                this.B0_S91_Export.Enabled = false;
                                this.B0_S91_Import.Enabled = false;
                                if (Banks[0].samples[90].depends.Count == 1)
                                {
                                    //find offset
                                    Banks[0].samples[90].offset =start - smp.start;
                                }
                            }
                        }
                    }
                }
                string deps = "";
                if (Banks[0].samples[90].depends != null)
                {
                    foreach (int dep in Banks[0].samples[90].depends)
                    {
                        deps += dep + ",";
                    }

                }
                this.B0_S91_Dep.Text = deps;
                this.B0_S91_Dep.ReadOnly = true;
                this.B0_S91_Off.Text = Banks[0].samples[90].offset.ToString("X");
                this.B0_S91_Off.ReadOnly = true;
                this.B0_S91_Len.Text = Banks[0].samples[90].length.ToString("X");
                if (Banks[0].samples[90].common == true)
                {
                    this.B0_S91_Len.Enabled = false;
                    this.B0_S91_Import.Enabled = false;
                }
                else
                {
                    this.B0_S91_Len.ReadOnly = true;
                }
            }
            if (Banks[0].samples[91] != null)
            {
                this.B0_S92_Enable.Enabled = true;
                this.B0_S92_Enable.Checked = true;
                this.B0_S92_Export.Enabled = true;
                this.B0_S92_Import.Enabled = true;
                this.B0_S92_ID.Text = Banks[0].samples[91].id.ToString();
                int start = Banks[0].samples[91].start;
                int id = Banks[0].samples[91].id;
                this.B0_S92_ID.ReadOnly = true;
                foreach (Sample smp in Banks[0].samples)
                {
                    if (smp != null)
                    {
                        if (IsBetween(start, smp.start, smp.end))
                        {
                            if (Banks[0].samples[91].id > smp.id)
                            {
                                Banks[0].samples[smp.id].parents.Add(id);
                                Banks[0].samples[91].depends.Add(smp.id);
                                this.B0_S92_Export.Enabled = false;
                                this.B0_S92_Import.Enabled = false;
                                if (Banks[0].samples[91].depends.Count == 1)
                                {
                                    //find offset
                                    Banks[0].samples[91].offset =start - smp.start;
                                }
                            }
                        }
                    }
                }
                string deps = "";
                if (Banks[0].samples[91].depends != null)
                {
                    foreach (int dep in Banks[0].samples[91].depends)
                    {
                        deps += dep + ",";
                    }

                }
                this.B0_S92_Dep.Text = deps;
                this.B0_S92_Dep.ReadOnly = true;
                this.B0_S92_Off.Text = Banks[0].samples[91].offset.ToString("X");
                this.B0_S92_Off.ReadOnly = true;
                this.B0_S92_Len.Text = Banks[0].samples[91].length.ToString("X");
                if (Banks[0].samples[91].common == true)
                {
                    this.B0_S92_Len.Enabled = false;
                    this.B0_S92_Import.Enabled = false;
                }
                else
                {
                    this.B0_S92_Len.ReadOnly = true;
                }
            }
            if (Banks[0].samples[92] != null)
            {
                this.B0_S93_Enable.Enabled = true;
                this.B0_S93_Enable.Checked = true;
                this.B0_S93_Export.Enabled = true;
                this.B0_S93_Import.Enabled = true;
                this.B0_S93_ID.Text = Banks[0].samples[92].id.ToString();
                int start = Banks[0].samples[92].start;
                int id = Banks[0].samples[92].id;
                this.B0_S93_ID.ReadOnly = true;
                foreach (Sample smp in Banks[0].samples)
                {
                    if (smp != null)
                    {
                        if (IsBetween(start, smp.start, smp.end))
                        {
                            if (Banks[0].samples[92].id > smp.id)
                            {
                                Banks[0].samples[smp.id].parents.Add(id);
                                Banks[0].samples[92].depends.Add(smp.id);
                                this.B0_S93_Export.Enabled = false;
                                this.B0_S93_Import.Enabled = false;
                                if (Banks[0].samples[92].depends.Count == 1)
                                {
                                    //find offset
                                    Banks[0].samples[92].offset =start - smp.start;
                                }
                            }
                        }
                    }
                }
                string deps = "";
                if (Banks[0].samples[92].depends != null)
                {
                    foreach (int dep in Banks[0].samples[92].depends)
                    {
                        deps += dep + ",";
                    }

                }
                this.B0_S93_Dep.Text = deps;
                this.B0_S93_Dep.ReadOnly = true;
                this.B0_S93_Off.Text = Banks[0].samples[92].offset.ToString("X");
                this.B0_S93_Off.ReadOnly = true;
                this.B0_S93_Len.Text = Banks[0].samples[92].length.ToString("X");
                if (Banks[0].samples[92].common == true)
                {
                    this.B0_S93_Len.Enabled = false;
                    this.B0_S93_Import.Enabled = false;
                }
                else
                {
                    this.B0_S93_Len.ReadOnly = true;
                }

            }
            if (Banks[0].samples[93] != null)
            {
                this.B0_S94_Enable.Enabled = true;
                this.B0_S94_Enable.Checked = true;
                this.B0_S94_Export.Enabled = true;
                this.B0_S94_Import.Enabled = true;
                this.B0_S94_ID.Text = Banks[0].samples[93].id.ToString();
                int start = Banks[0].samples[93].start;
                int id = Banks[0].samples[93].id;
                this.B0_S94_ID.ReadOnly = true;
                foreach (Sample smp in Banks[0].samples)
                {
                    if (smp != null)
                    {
                        if (IsBetween(start, smp.start, smp.end))
                        {
                            if (Banks[0].samples[93].id > smp.id)
                            {
                                Banks[0].samples[smp.id].parents.Add(id);
                                Banks[0].samples[93].depends.Add(smp.id);
                                this.B0_S94_Export.Enabled = false;
                                this.B0_S94_Import.Enabled = false;
                                if (Banks[0].samples[93].depends.Count == 1)
                                {
                                    //find offset
                                    Banks[0].samples[93].offset =start - smp.start;
                                }
                            }
                        }
                    }
                }
                string deps = "";
                if (Banks[0].samples[93].depends != null)
                {
                    foreach (int dep in Banks[0].samples[93].depends)
                    {
                        deps += dep + ",";
                    }

                }
                this.B0_S94_Dep.Text = deps;
                this.B0_S94_Dep.ReadOnly = true;
                this.B0_S94_Off.Text = Banks[0].samples[93].offset.ToString("X");
                this.B0_S94_Off.ReadOnly = true;
                this.B0_S94_Len.Text = Banks[0].samples[93].length.ToString("X");
                if (Banks[0].samples[93].common == true)
                {
                    this.B0_S94_Len.Enabled = false;
                    this.B0_S94_Import.Enabled = false;
                }
                else
                {
                    this.B0_S94_Len.ReadOnly = true;
                }
            }
            if (Banks[0].samples[94] != null)
            {
                this.B0_S95_Enable.Enabled = true;
                this.B0_S95_Enable.Checked = true;
                this.B0_S95_Export.Enabled = true;
                this.B0_S95_Import.Enabled = true;
                this.B0_S95_ID.Text = Banks[0].samples[94].id.ToString();
                int start = Banks[0].samples[94].start;
                int id = Banks[0].samples[94].id;
                this.B0_S95_ID.ReadOnly = true;
                foreach (Sample smp in Banks[0].samples)
                {
                    if (smp != null)
                    {
                        if (IsBetween(start, smp.start, smp.end))
                        {
                            if (Banks[0].samples[94].id > smp.id)
                            {
                                Banks[0].samples[smp.id].parents.Add(id);
                                Banks[0].samples[94].depends.Add(smp.id);
                                this.B0_S95_Export.Enabled = false;
                                this.B0_S95_Import.Enabled = false;
                                if (Banks[0].samples[94].depends.Count == 1)
                                {
                                    //find offset
                                    Banks[0].samples[94].offset =start - smp.start;
                                }
                            }
                        }
                    }
                }
                string deps = "";
                if (Banks[0].samples[94].depends != null)
                {
                    foreach (int dep in Banks[0].samples[94].depends)
                    {
                        deps += dep + ",";
                    }

                }
                this.B0_S95_Dep.Text = deps;
                this.B0_S95_Dep.ReadOnly = true;
                this.B0_S95_Off.Text = Banks[0].samples[94].offset.ToString("X");
                this.B0_S95_Off.ReadOnly = true;
                this.B0_S95_Len.Text = Banks[0].samples[94].length.ToString("X");
                if (Banks[0].samples[94].common == true)
                {
                    this.B0_S95_Len.Enabled = false;
                    this.B0_S95_Import.Enabled = false;
                }
                else
                {
                    this.B0_S95_Len.ReadOnly = true;
                }
            }
            if (Banks[0].samples[95] != null)
            {
                this.B0_S96_Enable.Enabled = true;
                this.B0_S96_Enable.Checked = true;
                this.B0_S96_Export.Enabled = true;
                this.B0_S96_Import.Enabled = true;
                this.B0_S96_ID.Text = Banks[0].samples[95].id.ToString();
                int start = Banks[0].samples[95].start;
                int id = Banks[0].samples[95].id;
                this.B0_S96_ID.ReadOnly = true;
                foreach (Sample smp in Banks[0].samples)
                {
                    if (smp != null)
                    {
                        if (IsBetween(start, smp.start, smp.end))
                        {
                            if (Banks[0].samples[95].id > smp.id)
                            {
                                Banks[0].samples[smp.id].parents.Add(id);
                                Banks[0].samples[95].depends.Add(smp.id);
                                this.B0_S96_Export.Enabled = false;
                                this.B0_S96_Import.Enabled = false;
                                if (Banks[0].samples[95].depends.Count == 1)
                                {
                                    //find offset
                                    Banks[0].samples[95].offset =start - smp.start;
                                }
                            }
                        }
                    }
                }
                string deps = "";
                if (Banks[0].samples[95].depends != null)
                {
                    foreach (int dep in Banks[0].samples[95].depends)
                    {
                        deps += dep + ",";
                    }

                }
                this.B0_S96_Dep.Text = deps;
                this.B0_S96_Dep.ReadOnly = true;
                this.B0_S96_Off.Text = Banks[0].samples[95].offset.ToString("X");
                this.B0_S96_Off.ReadOnly = true;
                this.B0_S96_Len.Text = Banks[0].samples[95].length.ToString("X");
                if (Banks[0].samples[95].common == true)
                {
                    this.B0_S96_Len.Enabled = false;
                    this.B0_S96_Import.Enabled = false;
                }
                else
                {
                    this.B0_S96_Len.ReadOnly = true;
                }
            }
            if (Banks[0].samples[96] != null)
            {
                this.B0_S97_Enable.Enabled = true;
                this.B0_S97_Enable.Checked = true;
                this.B0_S97_Export.Enabled = true;
                this.B0_S97_Import.Enabled = true;
                this.B0_S97_ID.Text = Banks[0].samples[96].id.ToString();
                int start = Banks[0].samples[96].start;
                int id = Banks[0].samples[96].id;
                this.B0_S97_ID.ReadOnly = true;
                foreach (Sample smp in Banks[0].samples)
                {
                    if (smp != null)
                    {
                        if (IsBetween(start, smp.start, smp.end))
                        {
                            if (Banks[0].samples[96].id > smp.id)
                            {
                                Banks[0].samples[smp.id].parents.Add(id);
                                Banks[0].samples[96].depends.Add(smp.id);
                                this.B0_S97_Export.Enabled = false;
                                this.B0_S97_Import.Enabled = false;
                                if (Banks[0].samples[96].depends.Count == 1)
                                {
                                    //find offset
                                    Banks[0].samples[96].offset =start - smp.start;
                                }
                            }
                        }
                    }
                }
                string deps = "";
                if (Banks[0].samples[96].depends != null)
                {
                    foreach (int dep in Banks[0].samples[96].depends)
                    {
                        deps += dep + ",";
                    }

                }
                this.B0_S97_Dep.Text = deps;
                this.B0_S97_Dep.ReadOnly = true;
                this.B0_S97_Off.Text = Banks[0].samples[96].offset.ToString("X");
                this.B0_S97_Off.ReadOnly = true;
                this.B0_S97_Len.Text = Banks[0].samples[96].length.ToString("X");
                if (Banks[0].samples[96].common == true)
                {
                    this.B0_S97_Len.Enabled = false;
                    this.B0_S97_Import.Enabled = false;
                }
                else
                {
                    this.B0_S97_Len.ReadOnly = true;
                }
            }
            if (Banks[0].samples[97] != null)
            {
                this.B0_S98_Enable.Enabled = true;
                this.B0_S98_Enable.Checked = true;
                this.B0_S98_Export.Enabled = true;
                this.B0_S98_Import.Enabled = true;
                this.B0_S98_ID.Text = Banks[0].samples[97].id.ToString();
                int start = Banks[0].samples[97].start;
                int id = Banks[0].samples[97].id;
                this.B0_S98_ID.ReadOnly = true;
                foreach (Sample smp in Banks[0].samples)
                {
                    if (smp != null)
                    {
                        if (IsBetween(start, smp.start, smp.end))
                        {
                            if (Banks[0].samples[97].id > smp.id)
                            {
                                Banks[0].samples[smp.id].parents.Add(id);
                                Banks[0].samples[97].depends.Add(smp.id);
                                this.B0_S98_Export.Enabled = false;
                                this.B0_S98_Import.Enabled = false;
                                if (Banks[0].samples[97].depends.Count == 1)
                                {
                                    //find offset
                                    Banks[0].samples[97].offset =start - smp.start;
                                }
                            }
                        }
                    }
                }
                string deps = "";
                if (Banks[0].samples[97].depends != null)
                {
                    foreach (int dep in Banks[0].samples[97].depends)
                    {
                        deps += dep + ",";
                    }

                }
                this.B0_S98_Dep.Text = deps;
                this.B0_S98_Dep.ReadOnly = true;
                this.B0_S98_Off.Text = Banks[0].samples[97].offset.ToString("X");
                this.B0_S98_Off.ReadOnly = true;
                this.B0_S98_Len.Text = Banks[0].samples[97].length.ToString("X");
                if (Banks[0].samples[97].common == true)
                {
                    this.B0_S98_Len.Enabled = false;
                    this.B0_S98_Import.Enabled = false;
                }
                else
                {
                    this.B0_S98_Len.ReadOnly = true;
                }
            }
            if (Banks[0].samples[98] != null)
            {
                this.B0_S99_Enable.Enabled = true;
                this.B0_S99_Enable.Checked = true;
                this.B0_S99_Export.Enabled = true;
                this.B0_S99_Import.Enabled = true;
                this.B0_S99_ID.Text = Banks[0].samples[98].id.ToString();
                int start = Banks[0].samples[98].start;
                int id = Banks[0].samples[98].id;
                this.B0_S99_ID.ReadOnly = true;
                foreach (Sample smp in Banks[0].samples)
                {
                    if (smp != null)
                    {
                        if (IsBetween(start, smp.start, smp.end))
                        {
                            if (Banks[0].samples[98].id > smp.id)
                            {
                                Banks[0].samples[smp.id].parents.Add(id);
                                Banks[0].samples[98].depends.Add(smp.id);
                                this.B0_S99_Export.Enabled = false;
                                this.B0_S99_Import.Enabled = false;
                                if (Banks[0].samples[98].depends.Count == 1)
                                {
                                    //find offset
                                    Banks[0].samples[98].offset =start - smp.start;
                                }
                            }
                        }
                    }
                }
                string deps = "";
                if (Banks[0].samples[98].depends != null)
                {
                    foreach (int dep in Banks[0].samples[98].depends)
                    {
                        deps += dep + ",";
                    }

                }
                this.B0_S99_Dep.Text = deps;
                this.B0_S99_Dep.ReadOnly = true;
                this.B0_S99_Off.Text = Banks[0].samples[98].offset.ToString("X");
                this.B0_S99_Off.ReadOnly = true;
                this.B0_S99_Len.Text = Banks[0].samples[98].length.ToString("X");
                if (Banks[0].samples[98].common == true)
                {
                    this.B0_S99_Len.Enabled = false;
                    this.B0_S99_Import.Enabled = false;
                }
                else
                {
                    this.B0_S99_Len.ReadOnly = true;
                }
            }
            if (Banks[0].samples[99] != null)
            {
                this.B0_S100_Enable.Enabled = true;
                this.B0_S100_Enable.Checked = true;
                this.B0_S100_Export.Enabled = true;
                this.B0_S100_Import.Enabled = true;
                this.B0_S100_ID.Text = Banks[0].samples[99].id.ToString();
                int start = Banks[0].samples[99].start;
                int id = Banks[0].samples[99].id;
                this.B0_S100_ID.ReadOnly = true;
                foreach (Sample smp in Banks[0].samples)
                {
                    if (smp != null)
                    {
                        if (IsBetween(start, smp.start, smp.end))
                        {
                            if (Banks[0].samples[99].id > smp.id)
                            {
                                Banks[0].samples[smp.id].parents.Add(id);
                                Banks[0].samples[99].depends.Add(smp.id);
                                this.B0_S100_Export.Enabled = false;
                                this.B0_S100_Import.Enabled = false;
                                if (Banks[0].samples[99].depends.Count == 1)
                                {
                                    //find offset
                                    Banks[0].samples[99].offset =start - smp.start;
                                }
                            }
                        }
                    }
                }
                string deps = "";
                if (Banks[0].samples[99].depends != null)
                {
                    foreach (int dep in Banks[0].samples[99].depends)
                    {
                        deps += dep + ",";
                    }

                }
                this.B0_S100_Dep.Text = deps;
                this.B0_S100_Dep.ReadOnly = true;
                this.B0_S100_Off.Text = Banks[0].samples[99].offset.ToString("X");
                this.B0_S100_Off.ReadOnly = true;
                this.B0_S100_Len.Text = Banks[0].samples[99].length.ToString("X");
                if (Banks[0].samples[99].common == true)
                {
                    this.B0_S100_Len.Enabled = false;
                    this.B0_S100_Import.Enabled = false;
                }
                else
                {
                    this.B0_S100_Len.ReadOnly = true;
                }
            }
            if (Banks[0].samples[100] != null)
            {
                this.B0_S101_Enable.Enabled = true;
                this.B0_S101_Enable.Checked = true;
                this.B0_S101_Export.Enabled = true;
                this.B0_S101_Import.Enabled = true;
                this.B0_S101_ID.Text = Banks[0].samples[100].id.ToString();
                int start = Banks[0].samples[100].start;
                int id = Banks[0].samples[100].id;
                this.B0_S101_ID.ReadOnly = true;
                foreach (Sample smp in Banks[0].samples)
                {
                    if (smp != null)
                    {
                        if (IsBetween(start, smp.start, smp.end))
                        {
                            if (Banks[0].samples[100].id > smp.id)
                            {
                                Banks[0].samples[smp.id].parents.Add(id);
                                Banks[0].samples[100].depends.Add(smp.id);
                                this.B0_S101_Export.Enabled = false;
                                this.B0_S101_Import.Enabled = false;
                                if (Banks[0].samples[100].depends.Count == 1)
                                {
                                    //find offset
                                    Banks[0].samples[100].offset =start - smp.start;
                                }
                            }
                        }
                    }
                }
                string deps = "";
                if (Banks[0].samples[100].depends != null)
                {
                    foreach (int dep in Banks[0].samples[100].depends)
                    {
                        deps += dep + ",";
                    }

                }
                this.B0_S101_Dep.Text = deps;
                this.B0_S101_Dep.ReadOnly = true;
                this.B0_S101_Off.Text = Banks[0].samples[100].offset.ToString("X");
                this.B0_S101_Off.ReadOnly = true;
                this.B0_S101_Len.Text = Banks[0].samples[100].length.ToString("X");
                if (Banks[0].samples[100].common == true)
                {
                    this.B0_S101_Len.Enabled = false;
                    this.B0_S101_Import.Enabled = false;
                }
                else
                {
                    this.B0_S101_Len.ReadOnly = true;
                }
            }
            if (Banks[0].samples[101] != null)
            {
                this.B0_S102_Enable.Enabled = true;
                this.B0_S102_Enable.Checked = true;
                this.B0_S102_Export.Enabled = true;
                this.B0_S102_Import.Enabled = true;
                this.B0_S102_ID.Text = Banks[0].samples[101].id.ToString();
                int start = Banks[0].samples[101].start;
                int id = Banks[0].samples[101].id;
                this.B0_S102_ID.ReadOnly = true;
                foreach (Sample smp in Banks[0].samples)
                {
                    if (smp != null)
                    {
                        if (IsBetween(start, smp.start, smp.end))
                        {
                            if (Banks[0].samples[101].id > smp.id)
                            {
                                Banks[0].samples[smp.id].parents.Add(id);
                                Banks[0].samples[101].depends.Add(smp.id);
                                this.B0_S102_Export.Enabled = false;
                                this.B0_S102_Import.Enabled = false;
                                if (Banks[0].samples[101].depends.Count == 1)
                                {
                                    //find offset
                                    Banks[0].samples[101].offset =start - smp.start;
                                }
                            }
                        }
                    }
                }
                string deps = "";
                if (Banks[0].samples[101].depends != null)
                {
                    foreach (int dep in Banks[0].samples[101].depends)
                    {
                        deps += dep + ",";
                    }

                }
                this.B0_S102_Dep.Text = deps;
                this.B0_S102_Dep.ReadOnly = true;
                this.B0_S102_Off.Text = Banks[0].samples[101].offset.ToString("X");
                this.B0_S102_Off.ReadOnly = true;
                this.B0_S102_Len.Text = Banks[0].samples[101].length.ToString("X");
                if (Banks[0].samples[101].common == true)
                {
                    this.B0_S102_Len.Enabled = false;
                    this.B0_S102_Import.Enabled = false;
                }
                else
                {
                    this.B0_S102_Len.ReadOnly = true;
                }
            }
            if (Banks[0].samples[102] != null)
            {
                this.B0_S103_Enable.Enabled = true;
                this.B0_S103_Enable.Checked = true;
                this.B0_S103_Export.Enabled = true;
                this.B0_S103_Import.Enabled = true;
                this.B0_S103_ID.Text = Banks[0].samples[102].id.ToString();
                int start = Banks[0].samples[102].start;
                int id = Banks[0].samples[102].id;
                this.B0_S103_ID.ReadOnly = true;
                foreach (Sample smp in Banks[0].samples)
                {
                    if (smp != null)
                    {
                        if (IsBetween(start, smp.start, smp.end))
                        {
                            if (Banks[0].samples[102].id > smp.id)
                            {
                                Banks[0].samples[smp.id].parents.Add(id);
                                Banks[0].samples[102].depends.Add(smp.id);
                                this.B0_S103_Export.Enabled = false;
                                this.B0_S103_Import.Enabled = false;
                                if (Banks[0].samples[102].depends.Count == 1)
                                {
                                    //find offset
                                    Banks[0].samples[102].offset =start - smp.start;
                                }
                            }
                        }
                    }
                }
                string deps = "";
                if (Banks[0].samples[102].depends != null)
                {
                    foreach (int dep in Banks[0].samples[102].depends)
                    {
                        deps += dep + ",";
                    }

                }
                this.B0_S103_Dep.Text = deps;
                this.B0_S103_Dep.ReadOnly = true;
                this.B0_S103_Off.Text = Banks[0].samples[102].offset.ToString("X");
                this.B0_S103_Off.ReadOnly = true;
                this.B0_S103_Len.Text = Banks[0].samples[102].length.ToString("X");
                if (Banks[0].samples[102].common == true)
                {
                    this.B0_S103_Len.Enabled = false;
                    this.B0_S103_Import.Enabled = false;
                }
                else
                {
                    this.B0_S103_Len.ReadOnly = true;
                }

            }
            if (Banks[0].samples[103] != null)
            {
                this.B0_S104_Enable.Enabled = true;
                this.B0_S104_Enable.Checked = true;
                this.B0_S104_Export.Enabled = true;
                this.B0_S104_Import.Enabled = true;
                this.B0_S104_ID.Text = Banks[0].samples[103].id.ToString();
                int start = Banks[0].samples[103].start;
                int id = Banks[0].samples[103].id;
                this.B0_S104_ID.ReadOnly = true;
                foreach (Sample smp in Banks[0].samples)
                {
                    if (smp != null)
                    {
                        if (IsBetween(start, smp.start, smp.end))
                        {
                            if (Banks[0].samples[103].id > smp.id)
                            {
                                Banks[0].samples[smp.id].parents.Add(id);
                                Banks[0].samples[103].depends.Add(smp.id);
                                this.B0_S104_Export.Enabled = false;
                                this.B0_S104_Import.Enabled = false;
                                if (Banks[0].samples[103].depends.Count == 1)
                                {
                                    //find offset
                                    Banks[0].samples[103].offset =start - smp.start;
                                }
                            }
                        }
                    }
                }
                string deps = "";
                if (Banks[0].samples[103].depends != null)
                {
                    foreach (int dep in Banks[0].samples[103].depends)
                    {
                        deps += dep + ",";
                    }

                }
                this.B0_S104_Dep.Text = deps;
                this.B0_S104_Dep.ReadOnly = true;
                this.B0_S104_Off.Text = Banks[0].samples[103].offset.ToString("X");
                this.B0_S104_Off.ReadOnly = true;
                this.B0_S104_Len.Text = Banks[0].samples[103].length.ToString("X");
                if (Banks[0].samples[103].common == true)
                {
                    this.B0_S104_Len.Enabled = false;
                    this.B0_S104_Import.Enabled = false;
                }
                else
                {
                    this.B0_S104_Len.ReadOnly = true;
                }
            }
            if (Banks[0].samples[104] != null)
            {
                this.B0_S105_Enable.Enabled = true;
                this.B0_S105_Enable.Checked = true;
                this.B0_S105_Export.Enabled = true;
                this.B0_S105_Import.Enabled = true;
                this.B0_S105_ID.Text = Banks[0].samples[104].id.ToString();
                int start = Banks[0].samples[104].start;
                int id = Banks[0].samples[104].id;
                this.B0_S105_ID.ReadOnly = true;
                foreach (Sample smp in Banks[0].samples)
                {
                    if (smp != null)
                    {
                        if (IsBetween(start, smp.start, smp.end))
                        {
                            if (Banks[0].samples[104].id > smp.id)
                            {
                                Banks[0].samples[smp.id].parents.Add(id);
                                Banks[0].samples[104].depends.Add(smp.id);
                                this.B0_S105_Export.Enabled = false;
                                this.B0_S105_Import.Enabled = false;
                                if (Banks[0].samples[104].depends.Count == 1)
                                {
                                    //find offset
                                    Banks[0].samples[104].offset =start - smp.start;
                                }
                            }
                        }
                    }
                }
                string deps = "";
                if (Banks[0].samples[104].depends != null)
                {
                    foreach (int dep in Banks[0].samples[104].depends)
                    {
                        deps += dep + ",";
                    }

                }
                this.B0_S105_Dep.Text = deps;
                this.B0_S105_Dep.ReadOnly = true;
                this.B0_S105_Off.Text = Banks[0].samples[104].offset.ToString("X");
                this.B0_S105_Off.ReadOnly = true;
                this.B0_S105_Len.Text = Banks[0].samples[104].length.ToString("X");
                if (Banks[0].samples[104].common == true)
                {
                    this.B0_S105_Len.Enabled = false;
                    this.B0_S105_Import.Enabled = false;
                }
                else
                {
                    this.B0_S105_Len.ReadOnly = true;
                }
            }
            if (Banks[0].samples[105] != null)
            {
                this.B0_S106_Enable.Enabled = true;
                this.B0_S106_Enable.Checked = true;
                this.B0_S106_Export.Enabled = true;
                this.B0_S106_Import.Enabled = true;
                this.B0_S106_ID.Text = Banks[0].samples[105].id.ToString();
                int start = Banks[0].samples[105].start;
                int id = Banks[0].samples[105].id;
                this.B0_S106_ID.ReadOnly = true;
                foreach (Sample smp in Banks[0].samples)
                {
                    if (smp != null)
                    {
                        if (IsBetween(start, smp.start, smp.end))
                        {
                            if (Banks[0].samples[105].id > smp.id)
                            {
                                Banks[0].samples[smp.id].parents.Add(id);
                                Banks[0].samples[105].depends.Add(smp.id);
                                this.B0_S106_Export.Enabled = false;
                                this.B0_S106_Import.Enabled = false;
                                if (Banks[0].samples[105].depends.Count == 1)
                                {
                                    //find offset
                                    Banks[0].samples[105].offset =start - smp.start;
                                }
                            }
                        }
                    }
                }
                string deps = "";
                if (Banks[0].samples[105].depends != null)
                {
                    foreach (int dep in Banks[0].samples[105].depends)
                    {
                        deps += dep + ",";
                    }

                }
                this.B0_S106_Dep.Text = deps;
                this.B0_S106_Dep.ReadOnly = true;
                this.B0_S106_Off.Text = Banks[0].samples[105].offset.ToString("X");
                this.B0_S106_Off.ReadOnly = true;
                this.B0_S106_Len.Text = Banks[0].samples[105].length.ToString("X");
                if (Banks[0].samples[105].common == true)
                {
                    this.B0_S106_Len.Enabled = false;
                    this.B0_S106_Import.Enabled = false;
                }
                else
                {
                    this.B0_S106_Len.ReadOnly = true;
                }
            }
            if (Banks[0].samples[106] != null)
            {
                this.B0_S107_Enable.Enabled = true;
                this.B0_S107_Enable.Checked = true;
                this.B0_S107_Export.Enabled = true;
                this.B0_S107_Import.Enabled = true;
                this.B0_S107_ID.Text = Banks[0].samples[106].id.ToString();
                int start = Banks[0].samples[106].start;
                int id = Banks[0].samples[106].id;
                this.B0_S107_ID.ReadOnly = true;
                foreach (Sample smp in Banks[0].samples)
                {
                    if (smp != null)
                    {
                        if (IsBetween(start, smp.start, smp.end))
                        {
                            if (Banks[0].samples[106].id > smp.id)
                            {
                                Banks[0].samples[smp.id].parents.Add(id);
                                Banks[0].samples[106].depends.Add(smp.id);
                                this.B0_S107_Export.Enabled = false;
                                this.B0_S107_Import.Enabled = false;
                                if (Banks[0].samples[106].depends.Count == 1)
                                {
                                    //find offset
                                    Banks[0].samples[106].offset =start - smp.start;
                                }
                            }
                        }
                    }
                }
                string deps = "";
                if (Banks[0].samples[106].depends != null)
                {
                    foreach (int dep in Banks[0].samples[106].depends)
                    {
                        deps += dep + ",";
                    }

                }
                this.B0_S107_Dep.Text = deps;
                this.B0_S107_Dep.ReadOnly = true;
                this.B0_S107_Off.Text = Banks[0].samples[106].offset.ToString("X");
                this.B0_S107_Off.ReadOnly = true;
                this.B0_S107_Len.Text = Banks[0].samples[106].length.ToString("X");
                if (Banks[0].samples[106].common == true)
                {
                    this.B0_S107_Len.Enabled = false;
                    this.B0_S107_Import.Enabled = false;
                }
                else
                {
                    this.B0_S107_Len.ReadOnly = true;
                }
            }
            if (Banks[0].samples[107] != null)
            {
                this.B0_S108_Enable.Enabled = true;
                this.B0_S108_Enable.Checked = true;
                this.B0_S108_Export.Enabled = true;
                this.B0_S108_Import.Enabled = true;
                this.B0_S108_ID.Text = Banks[0].samples[107].id.ToString();
                int start = Banks[0].samples[107].start;
                int id = Banks[0].samples[107].id;
                this.B0_S108_ID.ReadOnly = true;
                foreach (Sample smp in Banks[0].samples)
                {
                    if (smp != null)
                    {
                        if (IsBetween(start, smp.start, smp.end))
                        {
                            if (Banks[0].samples[107].id > smp.id)
                            {
                                Banks[0].samples[smp.id].parents.Add(id);
                                Banks[0].samples[107].depends.Add(smp.id);
                                this.B0_S108_Export.Enabled = false;
                                this.B0_S108_Import.Enabled = false;
                                if (Banks[0].samples[107].depends.Count == 1)
                                {
                                    //find offset
                                    Banks[0].samples[107].offset =start - smp.start;
                                }
                            }
                        }
                    }
                }
                string deps = "";
                if (Banks[0].samples[107].depends != null)
                {
                    foreach (int dep in Banks[0].samples[107].depends)
                    {
                        deps += dep + ",";
                    }

                }
                this.B0_S108_Dep.Text = deps;
                this.B0_S108_Dep.ReadOnly = true;
                this.B0_S108_Off.Text = Banks[0].samples[107].offset.ToString("X");
                this.B0_S108_Off.ReadOnly = true;
                this.B0_S108_Len.Text = Banks[0].samples[107].length.ToString("X");
                if (Banks[0].samples[107].common == true)
                {
                    this.B0_S108_Len.Enabled = false;
                    this.B0_S108_Import.Enabled = false;
                }
                else
                {
                    this.B0_S108_Len.ReadOnly = true;
                }
            }
            if (Banks[0].samples[108] != null)
            {
                this.B0_S109_Enable.Enabled = true;
                this.B0_S109_Enable.Checked = true;
                this.B0_S109_Export.Enabled = true;
                this.B0_S109_Import.Enabled = true;
                this.B0_S109_ID.Text = Banks[0].samples[108].id.ToString();
                int start = Banks[0].samples[108].start;
                int id = Banks[0].samples[108].id;
                this.B0_S109_ID.ReadOnly = true;
                foreach (Sample smp in Banks[0].samples)
                {
                    if (smp != null)
                    {
                        if (IsBetween(start, smp.start, smp.end))
                        {
                            if (Banks[0].samples[108].id > smp.id)
                            {
                                Banks[0].samples[smp.id].parents.Add(id);
                                Banks[0].samples[108].depends.Add(smp.id);
                                this.B0_S109_Export.Enabled = false;
                                this.B0_S109_Import.Enabled = false;
                                if (Banks[0].samples[108].depends.Count == 1)
                                {
                                    //find offset
                                    Banks[0].samples[108].offset =start - smp.start;
                                }
                            }
                        }
                    }
                }
                string deps = "";
                if (Banks[0].samples[108].depends != null)
                {
                    foreach (int dep in Banks[0].samples[108].depends)
                    {
                        deps += dep + ",";
                    }

                }
                this.B0_S109_Dep.Text = deps;
                this.B0_S109_Dep.ReadOnly = true;
                this.B0_S109_Off.Text = Banks[0].samples[108].offset.ToString("X");
                this.B0_S109_Off.ReadOnly = true;
                this.B0_S109_Len.Text = Banks[0].samples[108].length.ToString("X");
                if (Banks[0].samples[108].common == true)
                {
                    this.B0_S109_Len.Enabled = false;
                    this.B0_S109_Import.Enabled = false;
                }
                else
                {
                    this.B0_S109_Len.ReadOnly = true;
                }
            }
            if (Banks[0].samples[109] != null)
            {
                this.B0_S110_Enable.Enabled = true;
                this.B0_S110_Enable.Checked = true;
                this.B0_S110_Export.Enabled = true;
                this.B0_S110_Import.Enabled = true;
                this.B0_S110_ID.Text = Banks[0].samples[109].id.ToString();
                int start = Banks[0].samples[109].start;
                int id = Banks[0].samples[109].id;
                this.B0_S110_ID.ReadOnly = true;
                foreach (Sample smp in Banks[0].samples)
                {
                    if (smp != null)
                    {
                        if (IsBetween(start, smp.start, smp.end))
                        {
                            if (Banks[0].samples[109].id > smp.id)
                            {
                                Banks[0].samples[smp.id].parents.Add(id);
                                Banks[0].samples[109].depends.Add(smp.id);
                                this.B0_S110_Export.Enabled = false;
                                this.B0_S110_Import.Enabled = false;
                                if (Banks[0].samples[109].depends.Count == 1)
                                {
                                    //find offset
                                    Banks[0].samples[109].offset =start - smp.start;
                                }
                            }
                        }
                    }
                }
                string deps = "";
                if (Banks[0].samples[109].depends != null)
                {
                    foreach (int dep in Banks[0].samples[109].depends)
                    {
                        deps += dep + ",";
                    }

                }
                this.B0_S110_Dep.Text = deps;
                this.B0_S110_Dep.ReadOnly = true;
                this.B0_S110_Off.Text = Banks[0].samples[109].offset.ToString("X");
                this.B0_S110_Off.ReadOnly = true;
                this.B0_S110_Len.Text = Banks[0].samples[109].length.ToString("X");
                if (Banks[0].samples[109].common == true)
                {
                    this.B0_S110_Len.Enabled = false;
                    this.B0_S110_Import.Enabled = false;
                }
                else
                {
                    this.B0_S110_Len.ReadOnly = true;
                }
            }
            if (Banks[0].samples[110] != null)
            {
                this.B0_S111_Enable.Enabled = true;
                this.B0_S111_Enable.Checked = true;
                this.B0_S111_Export.Enabled = true;
                this.B0_S111_Import.Enabled = true;
                this.B0_S111_ID.Text = Banks[0].samples[110].id.ToString();
                int start = Banks[0].samples[110].start;
                int id = Banks[0].samples[110].id;
                this.B0_S111_ID.ReadOnly = true;
                foreach (Sample smp in Banks[0].samples)
                {
                    if (smp != null)
                    {
                        if (IsBetween(start, smp.start, smp.end))
                        {
                            if (Banks[0].samples[110].id > smp.id)
                            {
                                Banks[0].samples[smp.id].parents.Add(id);
                                Banks[0].samples[110].depends.Add(smp.id);
                                this.B0_S111_Export.Enabled = false;
                                this.B0_S111_Import.Enabled = false;
                                if (Banks[0].samples[110].depends.Count == 1)
                                {
                                    //find offset
                                    Banks[0].samples[110].offset =start - smp.start;
                                }
                            }
                        }
                    }
                }
                string deps = "";
                if (Banks[0].samples[110].depends != null)
                {
                    foreach (int dep in Banks[0].samples[110].depends)
                    {
                        deps += dep + ",";
                    }

                }
                this.B0_S111_Dep.Text = deps;
                this.B0_S111_Dep.ReadOnly = true;
                this.B0_S111_Off.Text = Banks[0].samples[110].offset.ToString("X");
                this.B0_S111_Off.ReadOnly = true;
                this.B0_S111_Len.Text = Banks[0].samples[110].length.ToString("X");
                if (Banks[0].samples[110].common == true)
                {
                    this.B0_S111_Len.Enabled = false;
                    this.B0_S111_Import.Enabled = false;
                }
                else
                {
                    this.B0_S111_Len.ReadOnly = true;
                }
            }
            if (Banks[0].samples[111] != null)
            {
                this.B0_S112_Enable.Enabled = true;
                this.B0_S112_Enable.Checked = true;
                this.B0_S112_Export.Enabled = true;
                this.B0_S112_Import.Enabled = true;
                this.B0_S112_ID.Text = Banks[0].samples[111].id.ToString();
                int start = Banks[0].samples[111].start;
                int id = Banks[0].samples[111].id;
                this.B0_S112_ID.ReadOnly = true;
                foreach (Sample smp in Banks[0].samples)
                {
                    if (smp != null)
                    {
                        if (IsBetween(start, smp.start, smp.end))
                        {
                            if (Banks[0].samples[111].id > smp.id)
                            {
                                Banks[0].samples[smp.id].parents.Add(id);
                                Banks[0].samples[111].depends.Add(smp.id);
                                this.B0_S112_Export.Enabled = false;
                                this.B0_S112_Import.Enabled = false;
                                if (Banks[0].samples[111].depends.Count == 1)
                                {
                                    //find offset
                                    Banks[0].samples[111].offset =start - smp.start;
                                }
                            }
                        }
                    }
                }
                string deps = "";
                if (Banks[0].samples[111].depends != null)
                {
                    foreach (int dep in Banks[0].samples[111].depends)
                    {
                        deps += dep + ",";
                    }

                }
                this.B0_S112_Dep.Text = deps;
                this.B0_S112_Dep.ReadOnly = true;
                this.B0_S112_Off.Text = Banks[0].samples[111].offset.ToString("X");
                this.B0_S112_Off.ReadOnly = true;
                this.B0_S112_Len.Text = Banks[0].samples[111].length.ToString("X");
                if (Banks[0].samples[111].common == true)
                {
                    this.B0_S112_Len.Enabled = false;
                    this.B0_S112_Import.Enabled = false;
                }
                else
                {
                    this.B0_S112_Len.ReadOnly = true;
                }
            }
            if (Banks[0].samples[112] != null)
            {
                this.B0_S113_Enable.Enabled = true;
                this.B0_S113_Enable.Checked = true;
                this.B0_S113_Export.Enabled = true;
                this.B0_S113_Import.Enabled = true;
                this.B0_S113_ID.Text = Banks[0].samples[112].id.ToString();
                int start = Banks[0].samples[112].start;
                int id = Banks[0].samples[112].id;
                this.B0_S113_ID.ReadOnly = true;
                foreach (Sample smp in Banks[0].samples)
                {
                    if (smp != null)
                    {
                        if (IsBetween(start, smp.start, smp.end))
                        {
                            if (Banks[0].samples[112].id > smp.id)
                            {
                                Banks[0].samples[smp.id].parents.Add(id);
                                Banks[0].samples[112].depends.Add(smp.id);
                                this.B0_S113_Export.Enabled = false;
                                this.B0_S113_Import.Enabled = false;
                                if (Banks[0].samples[112].depends.Count == 1)
                                {
                                    //find offset
                                    Banks[0].samples[112].offset =start - smp.start;
                                }
                            }
                        }
                    }
                }
                string deps = "";
                if (Banks[0].samples[112].depends != null)
                {
                    foreach (int dep in Banks[0].samples[112].depends)
                    {
                        deps += dep + ",";
                    }

                }
                this.B0_S113_Dep.Text = deps;
                this.B0_S113_Dep.ReadOnly = true;
                this.B0_S113_Off.Text = Banks[0].samples[112].offset.ToString("X");
                this.B0_S113_Off.ReadOnly = true;
                this.B0_S113_Len.Text = Banks[0].samples[112].length.ToString("X");
                if (Banks[0].samples[112].common == true)
                {
                    this.B0_S113_Len.Enabled = false;
                    this.B0_S113_Import.Enabled = false;
                }
                else
                {
                    this.B0_S113_Len.ReadOnly = true;
                }

            }
            if (Banks[0].samples[113] != null)
            {
                this.B0_S114_Enable.Enabled = true;
                this.B0_S114_Enable.Checked = true;
                this.B0_S114_Export.Enabled = true;
                this.B0_S114_Import.Enabled = true;
                this.B0_S114_ID.Text = Banks[0].samples[113].id.ToString();
                int start = Banks[0].samples[113].start;
                int id = Banks[0].samples[113].id;
                this.B0_S114_ID.ReadOnly = true;
                foreach (Sample smp in Banks[0].samples)
                {
                    if (smp != null)
                    {
                        if (IsBetween(start, smp.start, smp.end))
                        {
                            if (Banks[0].samples[113].id > smp.id)
                            {
                                Banks[0].samples[smp.id].parents.Add(id);
                                Banks[0].samples[113].depends.Add(smp.id);
                                this.B0_S114_Export.Enabled = false;
                                this.B0_S114_Import.Enabled = false;
                                if (Banks[0].samples[113].depends.Count == 1)
                                {
                                    //find offset
                                    Banks[0].samples[113].offset =start - smp.start;
                                }
                            }
                        }
                    }
                }
                string deps = "";
                if (Banks[0].samples[113].depends != null)
                {
                    foreach (int dep in Banks[0].samples[113].depends)
                    {
                        deps += dep + ",";
                    }

                }
                this.B0_S114_Dep.Text = deps;
                this.B0_S114_Dep.ReadOnly = true;
                this.B0_S114_Off.Text = Banks[0].samples[113].offset.ToString("X");
                this.B0_S114_Off.ReadOnly = true;
                this.B0_S114_Len.Text = Banks[0].samples[113].length.ToString("X");
                if (Banks[0].samples[113].common == true)
                {
                    this.B0_S114_Len.Enabled = false;
                    this.B0_S114_Import.Enabled = false;
                }
                else
                {
                    this.B0_S114_Len.ReadOnly = true;
                }
            }
            if (Banks[0].samples[114] != null)
            {
                this.B0_S115_Enable.Enabled = true;
                this.B0_S115_Enable.Checked = true;
                this.B0_S115_Export.Enabled = true;
                this.B0_S115_Import.Enabled = true;
                this.B0_S115_ID.Text = Banks[0].samples[114].id.ToString();
                int start = Banks[0].samples[114].start;
                int id = Banks[0].samples[114].id;
                this.B0_S115_ID.ReadOnly = true;
                foreach (Sample smp in Banks[0].samples)
                {
                    if (smp != null)
                    {
                        if (IsBetween(start, smp.start, smp.end))
                        {
                            if (Banks[0].samples[114].id > smp.id)
                            {
                                Banks[0].samples[smp.id].parents.Add(id);
                                Banks[0].samples[114].depends.Add(smp.id);
                                this.B0_S115_Export.Enabled = false;
                                this.B0_S115_Import.Enabled = false;
                                if (Banks[0].samples[114].depends.Count == 1)
                                {
                                    //find offset
                                    Banks[0].samples[114].offset =start - smp.start;
                                }
                            }
                        }
                    }
                }
                string deps = "";
                if (Banks[0].samples[114].depends != null)
                {
                    foreach (int dep in Banks[0].samples[114].depends)
                    {
                        deps += dep + ",";
                    }

                }
                this.B0_S115_Dep.Text = deps;
                this.B0_S115_Dep.ReadOnly = true;
                this.B0_S115_Off.Text = Banks[0].samples[114].offset.ToString("X");
                this.B0_S115_Off.ReadOnly = true;
                this.B0_S115_Len.Text = Banks[0].samples[114].length.ToString("X");
                if (Banks[0].samples[114].common == true)
                {
                    this.B0_S115_Len.Enabled = false;
                    this.B0_S115_Import.Enabled = false;
                }
                else
                {
                    this.B0_S115_Len.ReadOnly = true;
                }
            }
            if (Banks[0].samples[115] != null)
            {
                this.B0_S116_Enable.Enabled = true;
                this.B0_S116_Enable.Checked = true;
                this.B0_S116_Export.Enabled = true;
                this.B0_S116_Import.Enabled = true;
                this.B0_S116_ID.Text = Banks[0].samples[115].id.ToString();
                int start = Banks[0].samples[115].start;
                int id = Banks[0].samples[115].id;
                this.B0_S116_ID.ReadOnly = true;
                foreach (Sample smp in Banks[0].samples)
                {
                    if (smp != null)
                    {
                        if (IsBetween(start, smp.start, smp.end))
                        {
                            if (Banks[0].samples[115].id > smp.id)
                            {
                                Banks[0].samples[smp.id].parents.Add(id);
                                Banks[0].samples[115].depends.Add(smp.id);
                                this.B0_S116_Export.Enabled = false;
                                this.B0_S116_Import.Enabled = false;
                                if (Banks[0].samples[115].depends.Count == 1)
                                {
                                    //find offset
                                    Banks[0].samples[115].offset =start - smp.start;
                                }
                            }
                        }
                    }
                }
                string deps = "";
                if (Banks[0].samples[115].depends != null)
                {
                    foreach (int dep in Banks[0].samples[115].depends)
                    {
                        deps += dep + ",";
                    }

                }
                this.B0_S116_Dep.Text = deps;
                this.B0_S116_Dep.ReadOnly = true;
                this.B0_S116_Off.Text = Banks[0].samples[115].offset.ToString("X");
                this.B0_S116_Off.ReadOnly = true;
                this.B0_S116_Len.Text = Banks[0].samples[115].length.ToString("X");
                if (Banks[0].samples[115].common == true)
                {
                    this.B0_S116_Len.Enabled = false;
                    this.B0_S116_Import.Enabled = false;
                }
                else
                {
                    this.B0_S116_Len.ReadOnly = true;
                }
            }
            if (Banks[0].samples[116] != null)
            {
                this.B0_S117_Enable.Enabled = true;
                this.B0_S117_Enable.Checked = true;
                this.B0_S117_Export.Enabled = true;
                this.B0_S117_Import.Enabled = true;
                this.B0_S117_ID.Text = Banks[0].samples[116].id.ToString();
                int start = Banks[0].samples[116].start;
                int id = Banks[0].samples[116].id;
                this.B0_S117_ID.ReadOnly = true;
                foreach (Sample smp in Banks[0].samples)
                {
                    if (smp != null)
                    {
                        if (IsBetween(start, smp.start, smp.end))
                        {
                            if (Banks[0].samples[116].id > smp.id)
                            {
                                Banks[0].samples[smp.id].parents.Add(id);
                                Banks[0].samples[116].depends.Add(smp.id);
                                this.B0_S117_Export.Enabled = false;
                                this.B0_S117_Import.Enabled = false;
                                if (Banks[0].samples[116].depends.Count == 1)
                                {
                                    //find offset
                                    Banks[0].samples[116].offset =start - smp.start;
                                }
                            }
                        }
                    }
                }
                string deps = "";
                if (Banks[0].samples[116].depends != null)
                {
                    foreach (int dep in Banks[0].samples[116].depends)
                    {
                        deps += dep + ",";
                    }

                }
                this.B0_S117_Dep.Text = deps;
                this.B0_S117_Dep.ReadOnly = true;
                this.B0_S117_Off.Text = Banks[0].samples[116].offset.ToString("X");
                this.B0_S117_Off.ReadOnly = true;
                this.B0_S117_Len.Text = Banks[0].samples[116].length.ToString("X");
                if (Banks[0].samples[116].common == true)
                {
                    this.B0_S117_Len.Enabled = false;
                    this.B0_S117_Import.Enabled = false;
                }
                else
                {
                    this.B0_S117_Len.ReadOnly = true;
                }
            }
            if (Banks[0].samples[117] != null)
            {
                this.B0_S118_Enable.Enabled = true;
                this.B0_S118_Enable.Checked = true;
                this.B0_S118_Export.Enabled = true;
                this.B0_S118_Import.Enabled = true;
                this.B0_S118_ID.Text = Banks[0].samples[117].id.ToString();
                int start = Banks[0].samples[117].start;
                int id = Banks[0].samples[117].id;
                this.B0_S118_ID.ReadOnly = true;
                foreach (Sample smp in Banks[0].samples)
                {
                    if (smp != null)
                    {
                        if (IsBetween(start, smp.start, smp.end))
                        {
                            if (Banks[0].samples[117].id > smp.id)
                            {
                                Banks[0].samples[smp.id].parents.Add(id);
                                Banks[0].samples[117].depends.Add(smp.id);
                                this.B0_S118_Export.Enabled = false;
                                this.B0_S118_Import.Enabled = false;
                                if (Banks[0].samples[117].depends.Count == 1)
                                {
                                    //find offset
                                    Banks[0].samples[117].offset =start - smp.start;
                                }
                            }
                        }
                    }
                }
                string deps = "";
                if (Banks[0].samples[117].depends != null)
                {
                    foreach (int dep in Banks[0].samples[117].depends)
                    {
                        deps += dep + ",";
                    }

                }
                this.B0_S118_Dep.Text = deps;
                this.B0_S118_Dep.ReadOnly = true;
                this.B0_S118_Off.Text = Banks[0].samples[117].offset.ToString("X");
                this.B0_S118_Off.ReadOnly = true;
                this.B0_S118_Len.Text = Banks[0].samples[117].length.ToString("X");
                if (Banks[0].samples[117].common == true)
                {
                    this.B0_S118_Len.Enabled = false;
                    this.B0_S118_Import.Enabled = false;
                }
                else
                {
                    this.B0_S118_Len.ReadOnly = true;
                }
            }
            if (Banks[0].samples[118] != null)
            {
                this.B0_S119_Enable.Enabled = true;
                this.B0_S119_Enable.Checked = true;
                this.B0_S119_Export.Enabled = true;
                this.B0_S119_Import.Enabled = true;
                this.B0_S119_ID.Text = Banks[0].samples[118].id.ToString();
                int start = Banks[0].samples[118].start;
                int id = Banks[0].samples[118].id;
                this.B0_S119_ID.ReadOnly = true;
                foreach (Sample smp in Banks[0].samples)
                {
                    if (smp != null)
                    {
                        if (IsBetween(start, smp.start, smp.end))
                        {
                            if (Banks[0].samples[118].id > smp.id)
                            {
                                Banks[0].samples[smp.id].parents.Add(id);
                                Banks[0].samples[118].depends.Add(smp.id);
                                this.B0_S119_Export.Enabled = false;
                                this.B0_S119_Import.Enabled = false;
                                if (Banks[0].samples[118].depends.Count == 1)
                                {
                                    //find offset
                                    Banks[0].samples[118].offset =start - smp.start;
                                }
                            }
                        }
                    }
                }
                string deps = "";
                if (Banks[0].samples[118].depends != null)
                {
                    foreach (int dep in Banks[0].samples[118].depends)
                    {
                        deps += dep + ",";
                    }

                }
                this.B0_S119_Dep.Text = deps;
                this.B0_S119_Dep.ReadOnly = true;
                this.B0_S119_Off.Text = Banks[0].samples[118].offset.ToString("X");
                this.B0_S119_Off.ReadOnly = true;
                this.B0_S119_Len.Text = Banks[0].samples[118].length.ToString("X");
                if (Banks[0].samples[118].common == true)
                {
                    this.B0_S119_Len.Enabled = false;
                    this.B0_S119_Import.Enabled = false;
                }
                else
                {
                    this.B0_S119_Len.ReadOnly = true;
                }
            }
            if (Banks[0].samples[119] != null)
            {
                this.B0_S120_Enable.Enabled = true;
                this.B0_S120_Enable.Checked = true;
                this.B0_S120_Export.Enabled = true;
                this.B0_S120_Import.Enabled = true;
                this.B0_S120_ID.Text = Banks[0].samples[119].id.ToString();
                int start = Banks[0].samples[119].start;
                int id = Banks[0].samples[119].id;
                this.B0_S120_ID.ReadOnly = true;
                foreach (Sample smp in Banks[0].samples)
                {
                    if (smp != null)
                    {
                        if (IsBetween(start, smp.start, smp.end))
                        {
                            if (Banks[0].samples[119].id > smp.id)
                            {
                                Banks[0].samples[smp.id].parents.Add(id);
                                Banks[0].samples[119].depends.Add(smp.id);
                                this.B0_S120_Export.Enabled = false;
                                this.B0_S120_Import.Enabled = false;
                                if (Banks[0].samples[119].depends.Count == 1)
                                {
                                    //find offset
                                    Banks[0].samples[119].offset =start - smp.start;
                                }
                            }
                        }
                    }
                }
                string deps = "";
                if (Banks[0].samples[119].depends != null)
                {
                    foreach (int dep in Banks[0].samples[119].depends)
                    {
                        deps += dep + ",";
                    }

                }
                this.B0_S120_Dep.Text = deps;
                this.B0_S120_Dep.ReadOnly = true;
                this.B0_S120_Off.Text = Banks[0].samples[119].offset.ToString("X");
                this.B0_S120_Off.ReadOnly = true;
                this.B0_S120_Len.Text = Banks[0].samples[119].length.ToString("X");
                if (Banks[0].samples[119].common == true)
                {
                    this.B0_S120_Len.Enabled = false;
                    this.B0_S120_Import.Enabled = false;
                }
                else
                {
                    this.B0_S120_Len.ReadOnly = true;
                }
            }
            if (Banks[0].samples[120] != null)
            {
                this.B0_S121_Enable.Enabled = true;
                this.B0_S121_Enable.Checked = true;
                this.B0_S121_Export.Enabled = true;
                this.B0_S121_Import.Enabled = true;
                this.B0_S121_ID.Text = Banks[0].samples[120].id.ToString();
                int start = Banks[0].samples[120].start;
                int id = Banks[0].samples[120].id;
                this.B0_S121_ID.ReadOnly = true;
                foreach (Sample smp in Banks[0].samples)
                {
                    if (smp != null)
                    {
                        if (IsBetween(start, smp.start, smp.end))
                        {
                            if (Banks[0].samples[120].id > smp.id)
                            {
                                Banks[0].samples[smp.id].parents.Add(id);
                                Banks[0].samples[120].depends.Add(smp.id);
                                this.B0_S121_Export.Enabled = false;
                                this.B0_S121_Import.Enabled = false;
                                if (Banks[0].samples[120].depends.Count == 1)
                                {
                                    //find offset
                                    Banks[0].samples[120].offset =start - smp.start;
                                }
                            }
                        }
                    }
                }
                string deps = "";
                if (Banks[0].samples[120].depends != null)
                {
                    foreach (int dep in Banks[0].samples[120].depends)
                    {
                        deps += dep + ",";
                    }

                }
                this.B0_S121_Dep.Text = deps;
                this.B0_S121_Dep.ReadOnly = true;
                this.B0_S121_Off.Text = Banks[0].samples[120].offset.ToString("X");
                this.B0_S121_Off.ReadOnly = true;
                this.B0_S121_Len.Text = Banks[0].samples[120].length.ToString("X");
                if (Banks[0].samples[120].common == true)
                {
                    this.B0_S121_Len.Enabled = false;
                    this.B0_S121_Import.Enabled = false;
                }
                else
                {
                    this.B0_S121_Len.ReadOnly = true;
                }
            }
            if (Banks[0].samples[121] != null)
            {
                this.B0_S122_Enable.Enabled = true;
                this.B0_S122_Enable.Checked = true;
                this.B0_S122_Export.Enabled = true;
                this.B0_S122_Import.Enabled = true;
                this.B0_S122_ID.Text = Banks[0].samples[121].id.ToString();
                int start = Banks[0].samples[121].start;
                int id = Banks[0].samples[121].id;
                this.B0_S122_ID.ReadOnly = true;
                foreach (Sample smp in Banks[0].samples)
                {
                    if (smp != null)
                    {
                        if (IsBetween(start, smp.start, smp.end))
                        {
                            if (Banks[0].samples[121].id > smp.id)
                            {
                                Banks[0].samples[smp.id].parents.Add(id);
                                Banks[0].samples[121].depends.Add(smp.id);
                                this.B0_S122_Export.Enabled = false;
                                this.B0_S122_Import.Enabled = false;
                                if (Banks[0].samples[121].depends.Count == 1)
                                {
                                    //find offset
                                    Banks[0].samples[121].offset =start - smp.start;
                                }
                            }
                        }
                    }
                }
                string deps = "";
                if (Banks[0].samples[121].depends != null)
                {
                    foreach (int dep in Banks[0].samples[121].depends)
                    {
                        deps += dep + ",";
                    }

                }
                this.B0_S122_Dep.Text = deps;
                this.B0_S122_Dep.ReadOnly = true;
                this.B0_S122_Off.Text = Banks[0].samples[121].offset.ToString("X");
                this.B0_S122_Off.ReadOnly = true;
                this.B0_S122_Len.Text = Banks[0].samples[121].length.ToString("X");
                if (Banks[0].samples[121].common == true)
                {
                    this.B0_S122_Len.Enabled = false;
                    this.B0_S122_Import.Enabled = false;
                }
                else
                {
                    this.B0_S122_Len.ReadOnly = true;
                }
            }
            if (Banks[0].samples[122] != null)
            {
                this.B0_S123_Enable.Enabled = true;
                this.B0_S123_Enable.Checked = true;
                this.B0_S123_Export.Enabled = true;
                this.B0_S123_Import.Enabled = true;
                this.B0_S123_ID.Text = Banks[0].samples[122].id.ToString();
                int start = Banks[0].samples[122].start;
                int id = Banks[0].samples[122].id;
                this.B0_S123_ID.ReadOnly = true;
                foreach (Sample smp in Banks[0].samples)
                {
                    if (smp != null)
                    {
                        if (IsBetween(start, smp.start, smp.end))
                        {
                            if (Banks[0].samples[122].id > smp.id)
                            {
                                Banks[0].samples[smp.id].parents.Add(id);
                                Banks[0].samples[122].depends.Add(smp.id);
                                this.B0_S123_Export.Enabled = false;
                                this.B0_S123_Import.Enabled = false;
                                if (Banks[0].samples[122].depends.Count == 1)
                                {
                                    //find offset
                                    Banks[0].samples[122].offset =start - smp.start;
                                }
                            }
                        }
                    }
                }
                string deps = "";
                if (Banks[0].samples[122].depends != null)
                {
                    foreach (int dep in Banks[0].samples[122].depends)
                    {
                        deps += dep + ",";
                    }

                }
                this.B0_S123_Dep.Text = deps;
                this.B0_S123_Dep.ReadOnly = true;
                this.B0_S123_Off.Text = Banks[0].samples[122].offset.ToString("X");
                this.B0_S123_Off.ReadOnly = true;
                this.B0_S123_Len.Text = Banks[0].samples[122].length.ToString("X");
                if (Banks[0].samples[122].common == true)
                {
                    this.B0_S123_Len.Enabled = false;
                    this.B0_S123_Import.Enabled = false;
                }
                else
                {
                    this.B0_S123_Len.ReadOnly = true;
                }

            }
            if (Banks[0].samples[123] != null)
            {
                this.B0_S124_Enable.Enabled = true;
                this.B0_S124_Enable.Checked = true;
                this.B0_S124_Export.Enabled = true;
                this.B0_S124_Import.Enabled = true;
                this.B0_S124_ID.Text = Banks[0].samples[123].id.ToString();
                int start = Banks[0].samples[123].start;
                int id = Banks[0].samples[123].id;
                this.B0_S124_ID.ReadOnly = true;
                foreach (Sample smp in Banks[0].samples)
                {
                    if (smp != null)
                    {
                        if (IsBetween(start, smp.start, smp.end))
                        {
                            if (Banks[0].samples[123].id > smp.id)
                            {
                                Banks[0].samples[smp.id].parents.Add(id);
                                Banks[0].samples[123].depends.Add(smp.id);
                                this.B0_S124_Export.Enabled = false;
                                this.B0_S124_Import.Enabled = false;
                                if (Banks[0].samples[123].depends.Count == 1)
                                {
                                    //find offset
                                    Banks[0].samples[123].offset =start - smp.start;
                                }
                            }
                        }
                    }
                }
                string deps = "";
                if (Banks[0].samples[123].depends != null)
                {
                    foreach (int dep in Banks[0].samples[123].depends)
                    {
                        deps += dep + ",";
                    }

                }
                this.B0_S124_Dep.Text = deps;
                this.B0_S124_Dep.ReadOnly = true;
                this.B0_S124_Off.Text = Banks[0].samples[123].offset.ToString("X");
                this.B0_S124_Off.ReadOnly = true;
                this.B0_S124_Len.Text = Banks[0].samples[123].length.ToString("X");
                if (Banks[0].samples[123].common == true)
                {
                    this.B0_S124_Len.Enabled = false;
                    this.B0_S124_Import.Enabled = false;
                }
                else
                {
                    this.B0_S124_Len.ReadOnly = true;
                }
            }
            if (Banks[0].samples[124] != null)
            {
                this.B0_S125_Enable.Enabled = true;
                this.B0_S125_Enable.Checked = true;
                this.B0_S125_Export.Enabled = true;
                this.B0_S125_Import.Enabled = true;
                this.B0_S125_ID.Text = Banks[0].samples[124].id.ToString();
                int start = Banks[0].samples[124].start;
                int id = Banks[0].samples[124].id;
                this.B0_S125_ID.ReadOnly = true;
                foreach (Sample smp in Banks[0].samples)
                {
                    if (smp != null)
                    {
                        if (IsBetween(start, smp.start, smp.end))
                        {
                            if (Banks[0].samples[124].id > smp.id)
                            {
                                Banks[0].samples[smp.id].parents.Add(id);
                                Banks[0].samples[124].depends.Add(smp.id);
                                this.B0_S125_Export.Enabled = false;
                                this.B0_S125_Import.Enabled = false;
                                if (Banks[0].samples[124].depends.Count == 1)
                                {
                                    //find offset
                                    Banks[0].samples[124].offset =start - smp.start;
                                }
                            }
                        }
                    }
                }
                string deps = "";
                if (Banks[0].samples[124].depends != null)
                {
                    foreach (int dep in Banks[0].samples[124].depends)
                    {
                        deps += dep + ",";
                    }

                }
                this.B0_S125_Dep.Text = deps;
                this.B0_S125_Dep.ReadOnly = true;
                this.B0_S125_Off.Text = Banks[0].samples[124].offset.ToString("X");
                this.B0_S125_Off.ReadOnly = true;
                this.B0_S125_Len.Text = Banks[0].samples[124].length.ToString("X");
                if (Banks[0].samples[124].common == true)
                {
                    this.B0_S125_Len.Enabled = false;
                    this.B0_S125_Import.Enabled = false;
                }
                else
                {
                    this.B0_S125_Len.ReadOnly = true;
                }
            }
            if (Banks[0].samples[125] != null)
            {
                this.B0_S126_Enable.Enabled = true;
                this.B0_S126_Enable.Checked = true;
                this.B0_S126_Export.Enabled = true;
                this.B0_S126_Import.Enabled = true;
                this.B0_S126_ID.Text = Banks[0].samples[125].id.ToString();
                int start = Banks[0].samples[125].start;
                int id = Banks[0].samples[125].id;
                this.B0_S126_ID.ReadOnly = true;
                foreach (Sample smp in Banks[0].samples)
                {
                    if (smp != null)
                    {
                        if (IsBetween(start, smp.start, smp.end))
                        {
                            if (Banks[0].samples[125].id > smp.id)
                            {
                                Banks[0].samples[smp.id].parents.Add(id);
                                Banks[0].samples[125].depends.Add(smp.id);
                                this.B0_S126_Export.Enabled = false;
                                this.B0_S126_Import.Enabled = false;
                                if (Banks[0].samples[125].depends.Count == 1)
                                {
                                    //find offset
                                    Banks[0].samples[125].offset =start - smp.start;
                                }
                            }
                        }
                    }
                }
                string deps = "";
                if (Banks[0].samples[125].depends != null)
                {
                    foreach (int dep in Banks[0].samples[125].depends)
                    {
                        deps += dep + ",";
                    }

                }
                this.B0_S126_Dep.Text = deps;
                this.B0_S126_Dep.ReadOnly = true;
                this.B0_S126_Off.Text = Banks[0].samples[125].offset.ToString("X");
                this.B0_S126_Off.ReadOnly = true;
                this.B0_S126_Len.Text = Banks[0].samples[125].length.ToString("X");
                if (Banks[0].samples[125].common == true)
                {
                    this.B0_S126_Len.Enabled = false;
                    this.B0_S126_Import.Enabled = false;
                }
                else
                {
                    this.B0_S126_Len.ReadOnly = true;
                }
            }
            if (Banks[0].samples[126] != null)
            {
                this.B0_S127_Enable.Enabled = true;
                this.B0_S127_Enable.Checked = true;
                this.B0_S127_Export.Enabled = true;
                this.B0_S127_Import.Enabled = true;
                this.B0_S127_ID.Text = Banks[0].samples[126].id.ToString();
                int start = Banks[0].samples[126].start;
                int id = Banks[0].samples[126].id;
                this.B0_S127_ID.ReadOnly = true;
                foreach (Sample smp in Banks[0].samples)
                {
                    if (smp != null)
                    {
                        if (IsBetween(start, smp.start, smp.end))
                        {
                            if (Banks[0].samples[126].id > smp.id)
                            {
                                Banks[0].samples[smp.id].parents.Add(id);
                                Banks[0].samples[126].depends.Add(smp.id);
                                this.B0_S127_Export.Enabled = false;
                                this.B0_S127_Import.Enabled = false;
                                if (Banks[0].samples[126].depends.Count == 1)
                                {
                                    //find offset
                                    Banks[0].samples[126].offset =start - smp.start;
                                }
                            }
                        }
                    }
                }
                string deps = "";
                if (Banks[0].samples[126].depends != null)
                {
                    foreach (int dep in Banks[0].samples[126].depends)
                    {
                        deps += dep + ",";
                    }

                }
                this.B0_S127_Dep.Text = deps;
                this.B0_S127_Dep.ReadOnly = true;
                this.B0_S127_Off.Text = Banks[0].samples[126].offset.ToString("X");
                this.B0_S127_Off.ReadOnly = true;
                this.B0_S127_Len.Text = Banks[0].samples[126].length.ToString("X");
                if (Banks[0].samples[126].common == true)
                {
                    this.B0_S127_Len.Enabled = false;
                    this.B0_S127_Import.Enabled = false;
                }
                else
                {
                    this.B0_S127_Len.ReadOnly = true;
                }
            }
            computetimeBank0();
        }

        private void computetimeBank0()
        {
            //compute bytes spare
            int totalsize = 0x20000 - Banks[0].headersize;
            foreach (Sample smp in Banks[0].samples)
            {
                if (smp != null)
                {
                    if (smp.common == false)
                    {
                        if (smp.depends.Count() == 0)
                        {
                            if (smp.enabled == true)
                            {
                                totalsize -= smp.length;
                            }

                        }
                    }
                    if ((smp.id == Banks[0].lastsample) && Banks[0].samples[Banks[0].lastsample].enabled == false)
                    {
                        totalsize += 0x08;
                    }
                }
            }
            bank1bytes.Text = totalsize.ToString("X");
            float time = (totalsize / float.Parse(samprate.Text)) * 2;
            bank1time.Text = time.ToString("0.00000");
        }

        private bool IsBetween(int item, int start, int end)
        {
                return Comparer<int>.Default.Compare(item, start) > 0
                    && Comparer<int>.Default.Compare(item, end) < 0;
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void B0_S1_Export_Click(object sender, EventArgs e)
        {
            exportRAWfile(0, 0);
        }

        private void exportRAWfile(int bank, int sample)
        {
            SaveFileDialog SF = new SaveFileDialog
            {
                Title = "Save RAW File",
                InitialDirectory = "C:\\",
                Filter = "All files (*) | *.*",
                OverwritePrompt = true
            };
            if (SF.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                SF.FilterIndex = 0;
                SF.RestoreDirectory = true;
                File.WriteAllBytes(SF.FileName, Banks[bank].samples[sample].RAW);
            }

        }

        private void B0_S1_Import_Click(object sender, EventArgs e)
        {
            importRAWfile(0, 1);
        }

        private void importRAWfile(int bank, int sample)
        {
            OpenFileDialog OF = new OpenFileDialog
            {
                Title = "Open RAW File",
                InitialDirectory = "C:\\",
                Filter = "All files (*) | *.*",
            };
            if (OF.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                OF.FilterIndex = 0;
                OF.RestoreDirectory = true;
                Banks[bank].samples[sample].RAW = File.ReadAllBytes(OF.FileName);
                Banks[bank].samples[sample].depends.Clear();
                Banks[bank].samples[sample].length = Banks[bank].samples[sample].RAW.Length;
            }

        }

        private void GenerateROMs(object sender, EventArgs e)
        {
            int[] newstarts = new int[127];
            //TODO: test just does bank 1 for now
            byte[] result = new byte[0x40000];
            for (int i = 0; i < 8; i++)
            {
                result[i] = 0x00;
            }
            int cursor = 8;
            int headersize = Banks[0].headersize;
            Sample lastsample = Banks[0].samples[Banks[0].lastsample];
            if (lastsample.enabled == false)
            {
                //we can use the last sample's headerspace and make a few bytes.
                headersize -= 0x08;
            }

            foreach (Sample smp in Banks[0].samples)
            {
                if (smp != null)
                {

                    if (smp.enabled == true)
                    {
                        if (smp.common == true)
                        {
                            newstarts[smp.id] = smp.start;
                            result[cursor] = (byte)(smp.start >> 0x10);
                            cursor++;
                            result[cursor] = (byte)((smp.start >> 0x08) & 0xff);
                            cursor++;
                            result[cursor] = (byte)((smp.start) & 0xff);
                            cursor++;
                            result[cursor] = (byte)(smp.end >> 0x10);
                            cursor++;
                            result[cursor] = (byte)((smp.end >> 0x08) & 0xff);
                            cursor++;
                            result[cursor] = (byte)((smp.end) & 0xff);
                            cursor++;
                            result[cursor] = 0x00;
                            cursor++;
                            result[cursor] = 0x00;
                            cursor++;

                            Array.Copy(smp.RAW, 0, result, smp.start, smp.length);
                        }
                        else
                        {
                            if (smp.depends.Count == 0)
                            {
                                int StartPosition = headersize;
                                newstarts[smp.id] = StartPosition;
                                int EndPosition = StartPosition + smp.length;
                                result[cursor] = (byte)(StartPosition >> 0x10);
                                cursor++;
                                result[cursor] = (byte)((StartPosition >> 0x08) & 0xff);
                                cursor++;
                                result[cursor] = (byte)((StartPosition) & 0xff);
                                cursor++;
                                result[cursor] = (byte)(EndPosition >> 0x10);
                                cursor++;
                                result[cursor] = (byte)((EndPosition >> 0x08) & 0xff);
                                cursor++;
                                result[cursor] = (byte)((EndPosition) & 0xff);
                                cursor++;
                                result[cursor] = 0x00;
                                cursor++;
                                result[cursor] = 0x00;
                                cursor++;

                                Array.Copy(smp.RAW, 0, result, StartPosition, smp.length);
                                headersize += smp.length;
                            }
                            else
                            {
                                int StartPosition = newstarts[smp.depends.ElementAt(0)] + smp.offset;
                                newstarts[smp.id] = StartPosition;
                                int EndPosition = StartPosition + smp.length;
                                result[cursor] = (byte)(StartPosition >> 0x10);
                                cursor++;
                                result[cursor] = (byte)((StartPosition >> 0x08) & 0xff);
                                cursor++;
                                result[cursor] = (byte)((StartPosition) & 0xff);
                                cursor++;
                                result[cursor] = (byte)(EndPosition >> 0x10);
                                cursor++;
                                result[cursor] = (byte)((EndPosition >> 0x08) & 0xff);
                                cursor++;
                                result[cursor] = (byte)((EndPosition) & 0xff);
                                cursor++;
                                result[cursor] = 0x00;
                                cursor++;
                                result[cursor] = 0x00;
                                cursor++;

                                Array.Copy(smp.RAW, 0, result, StartPosition, smp.length);
                            }
                        }
                    }
                    else if (smp.id != lastsample.id)
                    {
                        newstarts[smp.id] = 0;
                        result[cursor] = 0x00;
                        cursor++;
                        result[cursor] = 0x00;
                        cursor++;
                        result[cursor] = 0x00;
                        cursor++;
                        result[cursor] = 0x00;
                        cursor++;
                        result[cursor] = 0x00;
                        cursor++;
                        result[cursor] = 0x00;
                        cursor++;
                        result[cursor] = 0x00;
                        cursor++;
                        result[cursor] = 0x00;
                        cursor++;
                    }
                }
            }
            SaveFileDialog SF = new SaveFileDialog
            {
                Title = "Save ROM File",
                InitialDirectory = "C:\\adpcm\roms",
                Filter = "All files (*) | *.*",
                OverwritePrompt = true
            };
            if (SF.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                SF.FilterIndex = 0;
                SF.RestoreDirectory = true;
                File.WriteAllBytes(SF.FileName, result);
            }

        }
        private void B0_S1_Enable_Click(object sender, EventArgs e)
        {
            Banks[0].samples[0].enabled = B0_S1_Enable.Checked;
            computetimeBank0();
        }
        private void B0_S2_Enable_Click(object sender, EventArgs e)
        {
            Banks[0].samples[1].enabled = B0_S2_Enable.Checked;
            computetimeBank0();
        }
        private void B0_S3_Enable_Click(object sender, EventArgs e)
        {
            Banks[0].samples[2].enabled = B0_S3_Enable.Checked;
            computetimeBank0();
        }
        private void B0_S4_Enable_Click(object sender, EventArgs e)
        {
            Banks[0].samples[3].enabled = B0_S4_Enable.Checked;
            computetimeBank0();
        }
        private void B0_S5_Enable_Click(object sender, EventArgs e)
        {
            Banks[0].samples[4].enabled = B0_S5_Enable.Checked;
            computetimeBank0();
        }
        private void B0_S6_Enable_Click(object sender, EventArgs e)
        {
            Banks[0].samples[5].enabled = B0_S6_Enable.Checked;
            computetimeBank0();
        }
        private void B0_S7_Enable_Click(object sender, EventArgs e)
        {
            Banks[0].samples[6].enabled = B0_S7_Enable.Checked;
            computetimeBank0();
        }
        private void B0_S8_Enable_Click(object sender, EventArgs e)
        {
            Banks[0].samples[7].enabled = B0_S8_Enable.Checked;
            computetimeBank0();
        }
        private void B0_S9_Enable_Click(object sender, EventArgs e)
        {
            Banks[0].samples[8].enabled = B0_S9_Enable.Checked;
            computetimeBank0();
        }
        private void B0_S10_Enable_Click(object sender, EventArgs e)
        {
            Banks[0].samples[9].enabled = B0_S10_Enable.Checked;
            computetimeBank0();
        }
        private void B0_S11_Enable_Click(object sender, EventArgs e)
        {
            Banks[0].samples[10].enabled = B0_S11_Enable.Checked;
            computetimeBank0();
        }
        private void B0_S12_Enable_Click(object sender, EventArgs e)
        {
            Banks[0].samples[11].enabled = B0_S12_Enable.Checked;
            computetimeBank0();
        }
        private void B0_S13_Enable_Click(object sender, EventArgs e)
        {
            Banks[0].samples[12].enabled = B0_S13_Enable.Checked;
            computetimeBank0();
        }
        private void B0_S14_Enable_Click(object sender, EventArgs e)
        {
            Banks[0].samples[13].enabled = B0_S14_Enable.Checked;
            computetimeBank0();
        }
        private void B0_S15_Enable_Click(object sender, EventArgs e)
        {
            Banks[0].samples[14].enabled = B0_S15_Enable.Checked;
            computetimeBank0();
        }
        private void B0_S16_Enable_Click(object sender, EventArgs e)
        {
            Banks[0].samples[15].enabled = B0_S16_Enable.Checked;
            computetimeBank0();
        }
        private void B0_S17_Enable_Click(object sender, EventArgs e)
        {
            Banks[0].samples[16].enabled = B0_S17_Enable.Checked;
            computetimeBank0();
        }
        private void B0_S18_Enable_Click(object sender, EventArgs e)
        {
            Banks[0].samples[17].enabled = B0_S18_Enable.Checked;
            computetimeBank0();
        }
        private void B0_S19_Enable_Click(object sender, EventArgs e)
        {
            Banks[0].samples[18].enabled = B0_S19_Enable.Checked;
            computetimeBank0();
        }
        private void B0_S20_Enable_Click(object sender, EventArgs e)
        {
            Banks[0].samples[19].enabled = B0_S20_Enable.Checked;
            computetimeBank0();
        }
        private void B0_S21_Enable_Click(object sender, EventArgs e)
        {
            Banks[0].samples[20].enabled = B0_S21_Enable.Checked;
            computetimeBank0();
        }
        private void B0_S22_Enable_Click(object sender, EventArgs e)
        {
            Banks[0].samples[21].enabled = B0_S22_Enable.Checked;
            computetimeBank0();
        }
        private void B0_S23_Enable_Click(object sender, EventArgs e)
        {
            Banks[0].samples[22].enabled = B0_S23_Enable.Checked;
            computetimeBank0();
        }
        private void B0_S24_Enable_Click(object sender, EventArgs e)
        {
            Banks[0].samples[23].enabled = B0_S24_Enable.Checked;
            computetimeBank0();
        }
        private void B0_S25_Enable_Click(object sender, EventArgs e)
        {
            Banks[0].samples[24].enabled = B0_S25_Enable.Checked;
            computetimeBank0();
        }
        private void B0_S26_Enable_Click(object sender, EventArgs e)
        {
            Banks[0].samples[25].enabled = B0_S26_Enable.Checked;
            computetimeBank0();
        }
        private void B0_S27_Enable_Click(object sender, EventArgs e)
        {
            Banks[0].samples[26].enabled = B0_S27_Enable.Checked;
            computetimeBank0();
        }
        private void B0_S28_Enable_Click(object sender, EventArgs e)
        {
            Banks[0].samples[27].enabled = B0_S28_Enable.Checked;
            computetimeBank0();
        }
        private void B0_S29_Enable_Click(object sender, EventArgs e)
        {
            Banks[0].samples[28].enabled = B0_S29_Enable.Checked;
            computetimeBank0();
        }
        private void B0_S30_Enable_Click(object sender, EventArgs e)
        {
            Banks[0].samples[29].enabled = B0_S30_Enable.Checked;
            computetimeBank0();
        }
        private void B0_S31_Enable_Click(object sender, EventArgs e)
        {
            Banks[0].samples[30].enabled = B0_S31_Enable.Checked;
            computetimeBank0();
        }
        private void B0_S32_Enable_Click(object sender, EventArgs e)
        {
            Banks[0].samples[31].enabled = B0_S32_Enable.Checked;
            computetimeBank0();
        }
        private void B0_S33_Enable_Click(object sender, EventArgs e)
        {
            Banks[0].samples[32].enabled = B0_S33_Enable.Checked;
            computetimeBank0();
        }
        private void B0_S34_Enable_Click(object sender, EventArgs e)
        {
            Banks[0].samples[33].enabled = B0_S34_Enable.Checked;
            computetimeBank0();
        }
        private void B0_S35_Enable_Click(object sender, EventArgs e)
        {
            Banks[0].samples[34].enabled = B0_S35_Enable.Checked;
            computetimeBank0();
        }
        private void B0_S36_Enable_Click(object sender, EventArgs e)
        {
            Banks[0].samples[35].enabled = B0_S36_Enable.Checked;
            computetimeBank0();
        }
        private void B0_S37_Enable_Click(object sender, EventArgs e)
        {
            Banks[0].samples[36].enabled = B0_S37_Enable.Checked;
            computetimeBank0();
        }
        private void B0_S38_Enable_Click(object sender, EventArgs e)
        {
            Banks[0].samples[37].enabled = B0_S38_Enable.Checked;
            computetimeBank0();
        }
        private void B0_S39_Enable_Click(object sender, EventArgs e)
        {
            Banks[0].samples[38].enabled = B0_S39_Enable.Checked;
            computetimeBank0();
        }
        private void B0_S40_Enable_Click(object sender, EventArgs e)
        {
            Banks[0].samples[39].enabled = B0_S40_Enable.Checked;
            computetimeBank0();
        }
        private void B0_S41_Enable_Click(object sender, EventArgs e)
        {
            Banks[0].samples[40].enabled = B0_S41_Enable.Checked;
            computetimeBank0();
        }
        private void B0_S42_Enable_Click(object sender, EventArgs e)
        {
            Banks[0].samples[41].enabled = B0_S42_Enable.Checked;
            computetimeBank0();
        }
        private void B0_S43_Enable_Click(object sender, EventArgs e)
        {
            Banks[0].samples[42].enabled = B0_S43_Enable.Checked;
            computetimeBank0();
        }
        private void B0_S44_Enable_Click(object sender, EventArgs e)
        {
            Banks[0].samples[43].enabled = B0_S44_Enable.Checked;
            computetimeBank0();
        }
        private void B0_S45_Enable_Click(object sender, EventArgs e)
        {
            Banks[0].samples[44].enabled = B0_S45_Enable.Checked;
            computetimeBank0();
        }
        private void B0_S46_Enable_Click(object sender, EventArgs e)
        {
            Banks[0].samples[45].enabled = B0_S46_Enable.Checked;
            computetimeBank0();
        }
        private void B0_S47_Enable_Click(object sender, EventArgs e)
        {
            Banks[0].samples[46].enabled = B0_S47_Enable.Checked;
            computetimeBank0();
        }
        private void B0_S48_Enable_Click(object sender, EventArgs e)
        {
            Banks[0].samples[47].enabled = B0_S48_Enable.Checked;
            computetimeBank0();
        }
        private void B0_S49_Enable_Click(object sender, EventArgs e)
        {
            Banks[0].samples[48].enabled = B0_S49_Enable.Checked;
            computetimeBank0();
        }
        private void B0_S50_Enable_Click(object sender, EventArgs e)
        {
            Banks[0].samples[49].enabled = B0_S50_Enable.Checked;
            computetimeBank0();
        }
        private void B0_S51_Enable_Click(object sender, EventArgs e)
        {
            Banks[0].samples[50].enabled = B0_S51_Enable.Checked;
            computetimeBank0();
        }
        private void B0_S52_Enable_Click(object sender, EventArgs e)
        {
            Banks[0].samples[51].enabled = B0_S52_Enable.Checked;
            computetimeBank0();
        }
        private void B0_S53_Enable_Click(object sender, EventArgs e)
        {
            Banks[0].samples[52].enabled = B0_S53_Enable.Checked;
            computetimeBank0();
        }
        private void B0_S54_Enable_Click(object sender, EventArgs e)
        {
            Banks[0].samples[53].enabled = B0_S54_Enable.Checked;
            computetimeBank0();
        }
        private void B0_S55_Enable_Click(object sender, EventArgs e)
        {
            Banks[0].samples[54].enabled = B0_S55_Enable.Checked;
            computetimeBank0();
        }
        private void B0_S56_Enable_Click(object sender, EventArgs e)
        {
            Banks[0].samples[55].enabled = B0_S56_Enable.Checked;
            computetimeBank0();
        }
        private void B0_S57_Enable_Click(object sender, EventArgs e)
        {
            Banks[0].samples[56].enabled = B0_S57_Enable.Checked;
            computetimeBank0();
        }
        private void B0_S58_Enable_Click(object sender, EventArgs e)
        {
            Banks[0].samples[57].enabled = B0_S58_Enable.Checked;
            computetimeBank0();
        }
        private void B0_S59_Enable_Click(object sender, EventArgs e)
        {
            Banks[0].samples[58].enabled = B0_S59_Enable.Checked;
            computetimeBank0();
        }
        private void B0_S60_Enable_Click(object sender, EventArgs e)
        {
            Banks[0].samples[59].enabled = B0_S60_Enable.Checked;
            computetimeBank0();
        }
        private void B0_S61_Enable_Click(object sender, EventArgs e)
        {
            Banks[0].samples[60].enabled = B0_S61_Enable.Checked;
            computetimeBank0();
        }
        private void B0_S62_Enable_Click(object sender, EventArgs e)
        {
            Banks[0].samples[61].enabled = B0_S62_Enable.Checked;
            computetimeBank0();
        }
        private void B0_S63_Enable_Click(object sender, EventArgs e)
        {
            Banks[0].samples[62].enabled = B0_S63_Enable.Checked;
            computetimeBank0();
        }
        private void B0_S64_Enable_Click(object sender, EventArgs e)
        {
            Banks[0].samples[63].enabled = B0_S64_Enable.Checked;
            computetimeBank0();
        }
        private void B0_S65_Enable_Click(object sender, EventArgs e)
        {
            Banks[0].samples[64].enabled = B0_S65_Enable.Checked;
            computetimeBank0();
        }
        private void B0_S66_Enable_Click(object sender, EventArgs e)
        {
            Banks[0].samples[65].enabled = B0_S66_Enable.Checked;
            computetimeBank0();
        }
        private void B0_S67_Enable_Click(object sender, EventArgs e)
        {
            Banks[0].samples[66].enabled = B0_S67_Enable.Checked;
            computetimeBank0();
        }
        private void B0_S68_Enable_Click(object sender, EventArgs e)
        {
            Banks[0].samples[67].enabled = B0_S68_Enable.Checked;
            computetimeBank0();
        }
        private void B0_S69_Enable_Click(object sender, EventArgs e)
        {
            Banks[0].samples[68].enabled = B0_S69_Enable.Checked;
            computetimeBank0();
        }
        private void B0_S70_Enable_Click(object sender, EventArgs e)
        {
            Banks[0].samples[69].enabled = B0_S70_Enable.Checked;
            computetimeBank0();
        }
        private void B0_S71_Enable_Click(object sender, EventArgs e)
        {
            Banks[0].samples[70].enabled = B0_S71_Enable.Checked;
            computetimeBank0();
        }
        private void B0_S72_Enable_Click(object sender, EventArgs e)
        {
            Banks[0].samples[71].enabled = B0_S72_Enable.Checked;
            computetimeBank0();
        }
        private void B0_S73_Enable_Click(object sender, EventArgs e)
        {
            Banks[0].samples[72].enabled = B0_S73_Enable.Checked;
            computetimeBank0();
        }
        private void B0_S74_Enable_Click(object sender, EventArgs e)
        {
            Banks[0].samples[73].enabled = B0_S74_Enable.Checked;
            computetimeBank0();
        }
        private void B0_S75_Enable_Click(object sender, EventArgs e)
        {
            Banks[0].samples[74].enabled = B0_S75_Enable.Checked;
            computetimeBank0();
        }
        private void B0_S76_Enable_Click(object sender, EventArgs e)
        {
            Banks[0].samples[75].enabled = B0_S76_Enable.Checked;
            computetimeBank0();
        }
        private void B0_S77_Enable_Click(object sender, EventArgs e)
        {
            Banks[0].samples[76].enabled = B0_S77_Enable.Checked;
            computetimeBank0();
        }
        private void B0_S78_Enable_Click(object sender, EventArgs e)
        {
            Banks[0].samples[77].enabled = B0_S78_Enable.Checked;
            computetimeBank0();
        }
        private void B0_S79_Enable_Click(object sender, EventArgs e)
        {
            Banks[0].samples[78].enabled = B0_S79_Enable.Checked;
            computetimeBank0();
        }
        private void B0_S80_Enable_Click(object sender, EventArgs e)
        {
            Banks[0].samples[79].enabled = B0_S80_Enable.Checked;
            computetimeBank0();
        }
        private void B0_S81_Enable_Click(object sender, EventArgs e)
        {
            Banks[0].samples[80].enabled = B0_S81_Enable.Checked;
            computetimeBank0();
        }
        private void B0_S82_Enable_Click(object sender, EventArgs e)
        {
            Banks[0].samples[81].enabled = B0_S82_Enable.Checked;
            computetimeBank0();
        }
        private void B0_S83_Enable_Click(object sender, EventArgs e)
        {
            Banks[0].samples[82].enabled = B0_S83_Enable.Checked;
            computetimeBank0();
        }
        private void B0_S84_Enable_Click(object sender, EventArgs e)
        {
            Banks[0].samples[83].enabled = B0_S84_Enable.Checked;
            computetimeBank0();
        }
        private void B0_S85_Enable_Click(object sender, EventArgs e)
        {
            Banks[0].samples[84].enabled = B0_S85_Enable.Checked;
            computetimeBank0();
        }
        private void B0_S86_Enable_Click(object sender, EventArgs e)
        {
            Banks[0].samples[85].enabled = B0_S86_Enable.Checked;
            computetimeBank0();
        }
        private void B0_S87_Enable_Click(object sender, EventArgs e)
        {
            Banks[0].samples[86].enabled = B0_S87_Enable.Checked;
            computetimeBank0();
        }
        private void B0_S88_Enable_Click(object sender, EventArgs e)
        {
            Banks[0].samples[87].enabled = B0_S88_Enable.Checked;
            computetimeBank0();
        }
        private void B0_S89_Enable_Click(object sender, EventArgs e)
        {
            Banks[0].samples[88].enabled = B0_S89_Enable.Checked;
            computetimeBank0();
        }
        private void B0_S90_Enable_Click(object sender, EventArgs e)
        {
            Banks[0].samples[89].enabled = B0_S90_Enable.Checked;
            computetimeBank0();
        }
        private void B0_S91_Enable_Click(object sender, EventArgs e)
        {
            Banks[0].samples[90].enabled = B0_S91_Enable.Checked;
            computetimeBank0();
        }
        private void B0_S92_Enable_Click(object sender, EventArgs e)
        {
            Banks[0].samples[91].enabled = B0_S92_Enable.Checked;
            computetimeBank0();
        }
        private void B0_S93_Enable_Click(object sender, EventArgs e)
        {
            Banks[0].samples[92].enabled = B0_S93_Enable.Checked;
            computetimeBank0();
        }
        private void B0_S94_Enable_Click(object sender, EventArgs e)
        {
            Banks[0].samples[93].enabled = B0_S94_Enable.Checked;
            computetimeBank0();
        }
        private void B0_S95_Enable_Click(object sender, EventArgs e)
        {
            Banks[0].samples[94].enabled = B0_S95_Enable.Checked;
            computetimeBank0();
        }
        private void B0_S96_Enable_Click(object sender, EventArgs e)
        {
            Banks[0].samples[95].enabled = B0_S96_Enable.Checked;
            computetimeBank0();
        }
        private void B0_S97_Enable_Click(object sender, EventArgs e)
        {
            Banks[0].samples[96].enabled = B0_S97_Enable.Checked;
            computetimeBank0();
        }
        private void B0_S98_Enable_Click(object sender, EventArgs e)
        {
            Banks[0].samples[97].enabled = B0_S98_Enable.Checked;
            computetimeBank0();
        }
        private void B0_S99_Enable_Click(object sender, EventArgs e)
        {
            Banks[0].samples[98].enabled = B0_S99_Enable.Checked;
            computetimeBank0();
        }
        private void B0_S100_Enable_Click(object sender, EventArgs e)
        {
            Banks[0].samples[99].enabled = B0_S100_Enable.Checked;
            computetimeBank0();
        }
        private void B0_S101_Enable_Click(object sender, EventArgs e)
        {
            Banks[0].samples[100].enabled = B0_S101_Enable.Checked;
            computetimeBank0();
        }
        private void B0_S102_Enable_Click(object sender, EventArgs e)
        {
            Banks[0].samples[101].enabled = B0_S102_Enable.Checked;
            computetimeBank0();
        }
        private void B0_S103_Enable_Click(object sender, EventArgs e)
        {
            Banks[0].samples[102].enabled = B0_S103_Enable.Checked;
            computetimeBank0();
        }
        private void B0_S104_Enable_Click(object sender, EventArgs e)
        {
            Banks[0].samples[103].enabled = B0_S104_Enable.Checked;
            computetimeBank0();
        }
        private void B0_S105_Enable_Click(object sender, EventArgs e)
        {
            Banks[0].samples[104].enabled = B0_S105_Enable.Checked;
            computetimeBank0();
        }
        private void B0_S106_Enable_Click(object sender, EventArgs e)
        {
            Banks[0].samples[105].enabled = B0_S106_Enable.Checked;
            computetimeBank0();
        }
        private void B0_S107_Enable_Click(object sender, EventArgs e)
        {
            Banks[0].samples[106].enabled = B0_S107_Enable.Checked;
            computetimeBank0();
        }
        private void B0_S108_Enable_Click(object sender, EventArgs e)
        {
            Banks[0].samples[107].enabled = B0_S108_Enable.Checked;
            computetimeBank0();
        }
        private void B0_S109_Enable_Click(object sender, EventArgs e)
        {
            Banks[0].samples[108].enabled = B0_S109_Enable.Checked;
            computetimeBank0();
        }
        private void B0_S110_Enable_Click(object sender, EventArgs e)
        {
            Banks[0].samples[109].enabled = B0_S110_Enable.Checked;
            computetimeBank0();
        }
        private void B0_S111_Enable_Click(object sender, EventArgs e)
        {
            Banks[0].samples[110].enabled = B0_S111_Enable.Checked;
            computetimeBank0();
        }
        private void B0_S112_Enable_Click(object sender, EventArgs e)
        {
            Banks[0].samples[111].enabled = B0_S112_Enable.Checked;
            computetimeBank0();
        }
        private void B0_S113_Enable_Click(object sender, EventArgs e)
        {
            Banks[0].samples[112].enabled = B0_S113_Enable.Checked;
            computetimeBank0();
        }
        private void B0_S114_Enable_Click(object sender, EventArgs e)
        {
            Banks[0].samples[113].enabled = B0_S114_Enable.Checked;
            computetimeBank0();
        }
        private void B0_S115_Enable_Click(object sender, EventArgs e)
        {
            Banks[0].samples[114].enabled = B0_S115_Enable.Checked;
            computetimeBank0();
        }
        private void B0_S116_Enable_Click(object sender, EventArgs e)
        {
            Banks[0].samples[115].enabled = B0_S116_Enable.Checked;
            computetimeBank0();
        }
        private void B0_S117_Enable_Click(object sender, EventArgs e)
        {
            Banks[0].samples[116].enabled = B0_S117_Enable.Checked;
            computetimeBank0();
        }
        private void B0_S118_Enable_Click(object sender, EventArgs e)
        {
            Banks[0].samples[117].enabled = B0_S118_Enable.Checked;
            computetimeBank0();
        }
        private void B0_S119_Enable_Click(object sender, EventArgs e)
        {
            Banks[0].samples[118].enabled = B0_S119_Enable.Checked;
            computetimeBank0();
        }
        private void B0_S120_Enable_Click(object sender, EventArgs e)
        {
            Banks[0].samples[119].enabled = B0_S120_Enable.Checked;
            computetimeBank0();
        }
        private void B0_S121_Enable_Click(object sender, EventArgs e)
        {
            Banks[0].samples[120].enabled = B0_S121_Enable.Checked;
            computetimeBank0();
        }
        private void B0_S122_Enable_Click(object sender, EventArgs e)
        {
            Banks[0].samples[121].enabled = B0_S122_Enable.Checked;
            computetimeBank0();
        }
        private void B0_S123_Enable_Click(object sender, EventArgs e)
        {
            Banks[0].samples[122].enabled = B0_S123_Enable.Checked;
            computetimeBank0();
        }
        private void B0_S124_Enable_Click(object sender, EventArgs e)
        {
            Banks[0].samples[123].enabled = B0_S124_Enable.Checked;
            computetimeBank0();
        }
        private void B0_S125_Enable_Click(object sender, EventArgs e)
        {
            Banks[0].samples[124].enabled = B0_S125_Enable.Checked;
            computetimeBank0();
        }

        private void B0_S126_Enable_Click(object sender, EventArgs e)
        {
            Banks[0].samples[125].enabled = B0_S126_Enable.Checked;
            computetimeBank0();
        }
        private void B0_S127_Enable_Click(object sender, EventArgs e)
        {
            Banks[0].samples[126].enabled = B0_S127_Enable.Checked;
            computetimeBank0();
        }

    }
}
