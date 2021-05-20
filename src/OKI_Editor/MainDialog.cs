using NAudio.Wave;
using NAudio.Wave.SampleProviders;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace OKI_Editor
{
    public partial class MainDialog : Form
    {
        System.Windows.Forms.Button[] B0_Play = new System.Windows.Forms.Button[128];
        System.Windows.Forms.Button[] B0_Export = new System.Windows.Forms.Button[128];
        System.Windows.Forms.TextBox[] B0_Length = new System.Windows.Forms.TextBox[128];
        System.Windows.Forms.TextBox[] B0_Offset = new System.Windows.Forms.TextBox[128];
        System.Windows.Forms.TextBox[] B0_Depends = new System.Windows.Forms.TextBox[128];
        System.Windows.Forms.Button[] B0_Import = new System.Windows.Forms.Button[128];
        System.Windows.Forms.CheckBox[] B0_Enable = new System.Windows.Forms.CheckBox[128];
        System.Windows.Forms.CheckBox[] B0_Common = new System.Windows.Forms.CheckBox[128];
        System.Windows.Forms.TextBox[] B0_ID = new System.Windows.Forms.TextBox[128];

        System.Windows.Forms.Button[] B2_Play = new System.Windows.Forms.Button[128];
        System.Windows.Forms.Button[] B2_Export = new System.Windows.Forms.Button[128];
        System.Windows.Forms.TextBox[] B2_Length = new System.Windows.Forms.TextBox[128];
        System.Windows.Forms.TextBox[] B2_Offset = new System.Windows.Forms.TextBox[128];
        System.Windows.Forms.TextBox[] B2_Depends = new System.Windows.Forms.TextBox[128];
        System.Windows.Forms.Button[] B2_Import = new System.Windows.Forms.Button[128];
        System.Windows.Forms.CheckBox[] B2_Enable = new System.Windows.Forms.CheckBox[128];
        System.Windows.Forms.CheckBox[] B2_Common = new System.Windows.Forms.CheckBox[128];
        System.Windows.Forms.TextBox[] B2_ID = new System.Windows.Forms.TextBox[128];

        System.Windows.Forms.Button[] B3_Play = new System.Windows.Forms.Button[128];
        System.Windows.Forms.Button[] B3_Export = new System.Windows.Forms.Button[128];
        System.Windows.Forms.TextBox[] B3_Length = new System.Windows.Forms.TextBox[128];
        System.Windows.Forms.TextBox[] B3_Offset = new System.Windows.Forms.TextBox[128];
        System.Windows.Forms.TextBox[] B3_Depends = new System.Windows.Forms.TextBox[128];
        System.Windows.Forms.Button[] B3_Import = new System.Windows.Forms.Button[128];
        System.Windows.Forms.CheckBox[] B3_Enable = new System.Windows.Forms.CheckBox[128];
        System.Windows.Forms.CheckBox[] B3_Common = new System.Windows.Forms.CheckBox[128];
        System.Windows.Forms.TextBox[] B3_ID = new System.Windows.Forms.TextBox[128];

        System.Windows.Forms.Button[] B4_Play = new System.Windows.Forms.Button[128];
        System.Windows.Forms.Button[] B4_Export = new System.Windows.Forms.Button[128];
        System.Windows.Forms.TextBox[] B4_Length = new System.Windows.Forms.TextBox[128];
        System.Windows.Forms.TextBox[] B4_Offset = new System.Windows.Forms.TextBox[128];
        System.Windows.Forms.TextBox[] B4_Depends = new System.Windows.Forms.TextBox[128];
        System.Windows.Forms.Button[] B4_Import = new System.Windows.Forms.Button[128];
        System.Windows.Forms.CheckBox[] B4_Enable = new System.Windows.Forms.CheckBox[128];
        System.Windows.Forms.CheckBox[] B4_Common = new System.Windows.Forms.CheckBox[128];
        System.Windows.Forms.TextBox[] B4_ID = new System.Windows.Forms.TextBox[128];

        System.Windows.Forms.Button[] B5_Play = new System.Windows.Forms.Button[128];
        System.Windows.Forms.Button[] B5_Export = new System.Windows.Forms.Button[128];
        System.Windows.Forms.TextBox[] B5_Length = new System.Windows.Forms.TextBox[128];
        System.Windows.Forms.TextBox[] B5_Offset = new System.Windows.Forms.TextBox[128];
        System.Windows.Forms.TextBox[] B5_Depends = new System.Windows.Forms.TextBox[128];
        System.Windows.Forms.Button[] B5_Import = new System.Windows.Forms.Button[128];
        System.Windows.Forms.CheckBox[] B5_Enable = new System.Windows.Forms.CheckBox[128];
        System.Windows.Forms.CheckBox[] B5_Common = new System.Windows.Forms.CheckBox[128];
        System.Windows.Forms.TextBox[] B5_ID = new System.Windows.Forms.TextBox[128];

        System.Windows.Forms.Button[] B6_Play = new System.Windows.Forms.Button[128];
        System.Windows.Forms.Button[] B6_Export = new System.Windows.Forms.Button[128];
        System.Windows.Forms.TextBox[] B6_Length = new System.Windows.Forms.TextBox[128];
        System.Windows.Forms.TextBox[] B6_Offset = new System.Windows.Forms.TextBox[128];
        System.Windows.Forms.TextBox[] B6_Depends = new System.Windows.Forms.TextBox[128];
        System.Windows.Forms.Button[] B6_Import = new System.Windows.Forms.Button[128];
        System.Windows.Forms.CheckBox[] B6_Enable = new System.Windows.Forms.CheckBox[128];
        System.Windows.Forms.CheckBox[] B6_Common = new System.Windows.Forms.CheckBox[128];
        System.Windows.Forms.TextBox[] B6_ID = new System.Windows.Forms.TextBox[128];

        System.Windows.Forms.Button[] B7_Play = new System.Windows.Forms.Button[128];
        System.Windows.Forms.Button[] B7_Export = new System.Windows.Forms.Button[128];
        System.Windows.Forms.TextBox[] B7_Length = new System.Windows.Forms.TextBox[128];
        System.Windows.Forms.TextBox[] B7_Offset = new System.Windows.Forms.TextBox[128];
        System.Windows.Forms.TextBox[] B7_Depends = new System.Windows.Forms.TextBox[128];
        System.Windows.Forms.Button[] B7_Import = new System.Windows.Forms.Button[128];
        System.Windows.Forms.CheckBox[] B7_Enable = new System.Windows.Forms.CheckBox[128];
        System.Windows.Forms.CheckBox[] B7_Common = new System.Windows.Forms.CheckBox[128];
        System.Windows.Forms.TextBox[] B7_ID = new System.Windows.Forms.TextBox[128];

        System.Windows.Forms.Button[] BCOM_Play = new System.Windows.Forms.Button[128];
        System.Windows.Forms.Button[] BCOM_Export = new System.Windows.Forms.Button[128];
        System.Windows.Forms.TextBox[] BCOM_Length = new System.Windows.Forms.TextBox[128];
        System.Windows.Forms.TextBox[] BCOM_Offset = new System.Windows.Forms.TextBox[128];
        System.Windows.Forms.TextBox[] BCOM_Depends = new System.Windows.Forms.TextBox[128];
        System.Windows.Forms.Button[] BCOM_Import = new System.Windows.Forms.Button[128];
        System.Windows.Forms.CheckBox[] BCOM_Enable = new System.Windows.Forms.CheckBox[128];
        System.Windows.Forms.CheckBox[] BCOM_Common = new System.Windows.Forms.CheckBox[128];
        System.Windows.Forms.TextBox[] BCOM_ID = new System.Windows.Forms.TextBox[128];


        private short ADPCMIndex;
        private short ADPCMLast;

        private string ImportDir = "C:\\adpcm\\";
        private string ExportDir = "C:\\adpcm\\";
        private string ROMExportDir = "C:\\adpcm\\";
        short[] StepOKI = { 16, 17, 19, 21, 23, 25, 28, 31, 34, 37,
                     41, 45, 50, 55, 60, 66, 73, 80, 88, 97,
                     107, 118, 130, 143, 157, 173, 190, 209, 230, 253,
                     279, 307, 337, 371, 408, 449, 494, 544, 598, 658,
                     724, 796, 876, 963, 1060, 1166, 1282, 1411, 1552 };

        short[] OKIAdjusts = { -1, -1, -1, -1, 2, 4, 6, 8, -1, -1, -1, -1, 2, 4, 6, 8 };


        public MainDialog()
        {
            InitializeComponent();
            ADPCMIndex = 0;
            ADPCMLast = 0;
        }

        public byte[] WPCROM { get; private set; }

        public byte[] U12 { get; private set; }
        public int U12Totalsize { get; private set; }

        public byte[] U13 { get; private set; }
        public int U13Totalsize { get; private set; }
        public bool U12Mirror { get; private set; }
        public bool U13Mirror { get; private set; }

        public CommonBank CommonBank { get; private set; }

        public Bank[] Banks { get; private set; }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void AboutLoad(object sender, EventArgs e)
        {
            AboutBox1 a = new AboutBox1();
            a.Show();
        }

        private void ROMReload(string U12Name, string U13Name)
        {
            Banks = new Bank[9];
            CommonBank = new CommonBank();
            U12 = new byte[0x80000];
            U13 = new byte[0x80000];
            WPCROM = new byte[0x160000];
            U12Totalsize = 0;
            U13Totalsize = 0;

            byte[] bytes = File.ReadAllBytes(U12Name);
            Array.Copy(bytes, 0, U12, U12Totalsize, bytes.Length);
            U12Totalsize += bytes.Length;

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

            bytes = File.ReadAllBytes(U13Name);
            Array.Copy(bytes, 0, U13, U13Totalsize, bytes.Length);
            U13Totalsize += bytes.Length;

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

            Banks[0] = new Bank(0, WPCROM, 0x40000, CommonBank);
            SetCtrl(0);

            if (U12Mirror == false)
            {
                Banks[2] = new Bank(2, WPCROM, 0x20000, CommonBank);
                SetCtrl(2);
                Banks[3] = new Bank(3, WPCROM, 0x00000, CommonBank);
                SetCtrl(3);
                B2_Table.Enabled = true;
                B3_Table.Enabled = true;
            }
            else
            {
                B2_Table.Enabled = false;
                B3_Table.Enabled = false;
            }
            if (U13Mirror == false)
            {
                Banks[4] = new Bank(4, WPCROM, 0xe0000, CommonBank);
                SetCtrl(4);
                Banks[5] = new Bank(5, WPCROM, 0xc0000, CommonBank);
                SetCtrl(5);
                B4_Table.Enabled = true;
                B5_Table.Enabled = true;
				Banks[6] = new Bank(6, WPCROM, 0xa0000, CommonBank);
				SetCtrl(6);
				Banks[7] = new Bank(7, WPCROM, 0x80000, CommonBank);
				SetCtrl(7);
                B6_Table.Enabled = true;
                B7_Table.Enabled = true;
            }
            else
            {
//                B2_Table.Enabled = false;
 //               B3_Table.Enabled = false;
				Banks[4] = new Bank(4, WPCROM, 0xa0000, CommonBank);
				SetCtrl(4);
				Banks[5] = new Bank(5, WPCROM, 0x80000, CommonBank);
				SetCtrl(5);
                B4_Table.Enabled = true;
                B5_Table.Enabled = true;
            }

            Banks[8] = CommonBank;
            SetCtrl(8);
        }

        private void ImportLoad(object sender, EventArgs e)
        {
            ROMLoader rl = new ROMLoader();
            rl.ShowDialog();
            if (rl.DialogResult == DialogResult.OK)
            {
                Banks = new Bank[9];
                CommonBank = new CommonBank();
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

                Banks[0] = new Bank(0, WPCROM, 0x40000, CommonBank);
                SetCtrl(0);

                if (U12Mirror == false)
                {
                    Banks[2] = new Bank(2, WPCROM, 0x20000, CommonBank);
                    SetCtrl(2);
                    Banks[3] = new Bank(3, WPCROM, 0x00000, CommonBank);
                    SetCtrl(3);
                    B2_Table.Enabled = true;
                    B3_Table.Enabled = true;
                }
                else
                {
                    B2_Table.Enabled = false;
                    B3_Table.Enabled = false;
                }
                if (U13Mirror == false)
                {
                    Banks[4] = new Bank(4, WPCROM, 0xe0000, CommonBank);
                    SetCtrl(4);
                    Banks[5] = new Bank(5, WPCROM, 0xc0000, CommonBank);
                    SetCtrl(5);
                    B4_Table.Enabled = true;
                    B5_Table.Enabled = true;
					Banks[6] = new Bank(6, WPCROM, 0xa0000, CommonBank);
					SetCtrl(6);
					Banks[7] = new Bank(7, WPCROM, 0x80000, CommonBank);
					SetCtrl(7);
                    B6_Table.Enabled = true;
                    B7_Table.Enabled = true;
                }
                else
                {
					Banks[4] = new Bank(4, WPCROM, 0xa0000, CommonBank);
					SetCtrl(4);
					Banks[5] = new Bank(5, WPCROM, 0x80000, CommonBank);
					SetCtrl(5);
                    B4_Table.Enabled = true;
                    B5_Table.Enabled = true;
                    B6_Table.Enabled = false;
                    B7_Table.Enabled = false;

                }
                Banks[8] = CommonBank;
                SetCtrl(8);
            }
        }

        private void UpdateCtrl(int bank)
        {
            TextBox[][] dependsArr = { B0_Depends, B0_Depends, B2_Depends, B3_Depends, B4_Depends, B5_Depends, B6_Depends, B7_Depends, BCOM_Depends };
            TextBox[][] offsetArr = { B0_Offset, B0_Offset, B2_Offset, B3_Offset, B4_Offset, B5_Offset, B6_Offset, B7_Offset, BCOM_Offset };
            TextBox[][] lengthArr = { B0_Length, B0_Length, B2_Length, B3_Length, B4_Length, B5_Length, B6_Length, B7_Length, BCOM_Length };

            for (int i = 0; i < 127; i++)
            {
                if (Banks[bank].samples[i].enabled == true)
                {
                    Banks[bank].samples[i].depends.Clear();
                    dependsArr[bank][i].Text = "";
                    offsetArr[bank][i].Text = "0x" + Banks[bank].samples[i].offset.ToString("x");
                    int ticks = (int)Math.Round(Banks[bank].samples[i].length * 0.13);

                    lengthArr[bank][i].Text = "0x" + Banks[bank].samples[i].length.ToString("x") + ",0x" + ticks.ToString("x");
                }
            }
        }



        private void UpdateCtrl0()
        {
            UpdateCtrl(0);
        }
        private void UpdateCtrl2()
        {
            UpdateCtrl(2);
        }
        private void UpdateCtrl3()
        {
            UpdateCtrl(3);
        }
        private void UpdateCtrl4()
        {
            UpdateCtrl(4);
        }
        private void UpdateCtrl5()
        {
            UpdateCtrl(5);
        }
        private void UpdateCtrl6()
        {
            UpdateCtrl(6);
        }
        private void UpdateCtrl7()
        {
            UpdateCtrl(7);
        }
        private void UpdateCtrlCOM()
        {
            UpdateCtrl(8);
        }

        private void SetCtrl(int bank)
        {
            Button[][] playArr = { B0_Play, B0_Play, B2_Play, B3_Play, B4_Play, B5_Play, B6_Play, B7_Play, BCOM_Play };
            TextBox[][] idArr = { B0_ID, B0_ID, B2_ID, B3_ID, B4_ID, B5_ID, B6_ID, B7_ID, BCOM_ID };
            Button[][] importArr = { B0_Import, B0_Import, B2_Import, B3_Import, B4_Import, B5_Import, B6_Import, B7_Import, BCOM_Import };
            Button[][] exportArr = { B0_Export, B0_Export, B2_Export, B3_Export, B4_Export, B5_Export, B6_Export, B7_Export, BCOM_Export };
            CheckBox[][] commonArr = { B0_Common, B0_Common, B2_Common, B3_Common, B4_Common, B5_Common, B6_Common, B7_Common, BCOM_Common };
            CheckBox[][] enableArr = { B0_Enable, B0_Enable, B2_Enable, B3_Enable, B4_Enable, B5_Enable, B6_Enable, B7_Enable, BCOM_Enable };
            TextBox[][] dependsArr = { B0_Depends, B0_Depends, B2_Depends, B3_Depends, B4_Depends, B5_Depends, B6_Depends, B7_Depends, BCOM_Depends };
            TextBox[][] offsetArr = { B0_Offset, B0_Offset, B2_Offset, B3_Offset, B4_Offset, B5_Offset, B6_Offset, B7_Offset, BCOM_Offset };
            TextBox[][] lengthArr = { B0_Length, B0_Length, B2_Length, B3_Length, B4_Length, B5_Length, B6_Length, B7_Length, BCOM_Length };

            for (int i = 0; i < 127; i++)
            {
                playArr[bank][i].Enabled = Banks[bank].samples[i].enabled;
                idArr[bank][i].Text = i.ToString("X2");
                if (Banks[bank].samples[i].enabled == true)
                {
                    enableArr[bank][i].Enabled = true;
                    enableArr[bank][i].Checked = true;

                    if (Banks[bank].samples[i].common == true)
                    {
                        idArr[bank][i].Text = "C" + (Banks[bank].samples[i].commonid.ToString("X2"));
                        idArr[bank][i].Enabled = true;
                        importArr[bank][i].Enabled = false;
                        exportArr[bank][i].Enabled = false;
                        commonArr[bank][i].Checked = true;
                    }
                    else
                    {
                        idArr[bank][i].Text = i.ToString("X2");
                        idArr[bank][i].Enabled = false;
                        importArr[bank][i].Enabled = true;
                        exportArr[bank][i].Enabled = true;
                        commonArr[bank][i].Checked = false;
                    }

                    int start = Banks[bank].samples[i].start;
                    int id = Banks[bank].samples[i].id;
                    for (int j = 0; j < 127; j++)
                    {
                        Sample smp = Banks[bank].samples[j];
                        if (smp.enabled == true)
                        {
                            if (IsBetween(start, smp.start, smp.end))
                            {
                                if (Banks[bank].samples[i].id > smp.id)
                                {
                                    Banks[bank].samples[smp.id].parents.Add(id);
                                    Banks[bank].samples[i].depends.Add(smp.id);
                                    if (Banks[bank].samples[i].depends.Count == 1)
                                    {
                                        //find offset
                                        Banks[bank].samples[i].offset = start - smp.start;
                                    }
                                }
                            }
                        }
                    }
                    string deps = "";
                    if (Banks[bank].samples[i].common == true)
                    {
                        Banks[bank].samples[i].depends.Clear();
                        Banks[bank].samples[i].offset = Banks[bank].samples[i].start - 0x20000;
                    }
                    if (Banks[bank].samples[i].depends.Count > 0)
                    {
                        int dep = Banks[bank].samples[i].depends[0];
                        {
                            deps = dep.ToString("X2");
                        }
                    }
                    dependsArr[bank][i].Text = deps;
                    offsetArr[bank][i].Text = "0x" + Banks[bank].samples[i].offset.ToString("x");
                    int ticks = (int)Math.Round(Banks[bank].samples[i].length * 0.13);
                    lengthArr[bank][i].Text = "0x" + Banks[bank].samples[i].length.ToString("x") + ",0x" +ticks.ToString("x");
                }

            }
            ComputeTimeBank(bank);
        }

        private void ComputeTimeBank(int bank)
        {
            TextBox[] bytesArr = { B0_Bytes, B0_Bytes, B2_Bytes, B3_Bytes, B4_Bytes, B5_Bytes, B6_Bytes, B7_Bytes, BCOM_Bytes };
            TextBox[] secondsArr = { B0_Seconds, B0_Seconds, B2_Seconds, B3_Seconds, B4_Seconds, B5_Seconds, B6_Seconds, B7_Seconds, BCOM_Seconds };
            //compute bytes spare
            int totalsize = 0x20000 - Banks[bank].headersize;
            foreach (Sample smp in Banks[bank].samples)
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
                    if ((smp.id == Banks[bank].lastsample) && Banks[bank].samples[Banks[bank].lastsample].enabled == false)
                    {
                        totalsize += 0x08;
                    }
                }
            }
            Banks[bank].sparespace = totalsize;

            if (totalsize < 0)
            {
                bytesArr[bank].Text = "- 0x" + Math.Abs(totalsize).ToString("x");
            }
            else
            {
                bytesArr[bank].Text = "0x" + totalsize.ToString("x");
            }
            float time = (totalsize / float.Parse(samprate.Text)) * 2;
            secondsArr[bank].Text = time.ToString("0.00000");
        }


        private bool IsBetween(int item, int start, int end)
        {
            return Comparer<int>.Default.Compare(item, start) > 0
                && Comparer<int>.Default.Compare(item, end) < 0;
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void exportRAWfile(int bank, int sample)
        {
            Bank bankdata;

            {
                bankdata = Banks[bank];
            }
            SaveFileDialog SF = new SaveFileDialog
            {
                Title = "Save File",
                InitialDirectory = ExportDir,
                Filter = "WAV files (*.wav)|*.wav|VOX files (*.vox)|*.vox",
                FilterIndex = 2,
                SupportMultiDottedExtensions = false,
                OverwritePrompt = true
            };
            if (SF.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                SF.FilterIndex = 0;
                ExportDir = System.IO.Path.GetDirectoryName(SF.FileName);
                Sample smp = bankdata.samples[sample];

                if (smp.depends.Count > 0)
                {
                    int StartPosition = smp.offset;
                    int EndPosition = StartPosition + smp.length;
                    byte[] tmp = new byte[smp.length];

                    int parentid = smp.depends.ElementAt(0);
                    Sample parent;
                    if (smp.common == true)
                    {

                        parent = CommonBank.samples[parentid];
                    }
                    else
                    {
                        parent = bankdata.samples[parentid];
                    }

                    Array.Copy(parent.RAW, smp.offset, tmp, 0, smp.length);
                    if (SF.FileName.ToLower().Contains(".vox"))
                    {
                        File.WriteAllBytes(SF.FileName, tmp);
                    }
                    else
                    {
                        ExportSample(tmp, SF.FileName);
                    }
                }
                else
                {
                    if (SF.FileName.ToLower().Contains(".vox"))
                    {
                        File.WriteAllBytes(SF.FileName, bankdata.samples[sample].RAW);
                    }
                    else
                    {
                        ExportSample(bankdata.samples[sample].RAW, SF.FileName);
                    }
                }
            }

        }

        private void ImportRAWfile(int bank, int sample)
        {
            Bank bankdata;

            {
                bankdata = Banks[bank];
            }
            OpenFileDialog OF = new OpenFileDialog
            {
                Title = "Open Audio File",
                InitialDirectory = ImportDir,
                Filter = "WAV files (*.wav)|*.wav|VOX files (*.vox)|*.*",
                FilterIndex = 1,
                SupportMultiDottedExtensions = false
            };
            if (OF.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {

                OF.FilterIndex = 0;
                ImportDir = System.IO.Path.GetDirectoryName(OF.FileName);
                byte[] tmp = File.ReadAllBytes(OF.FileName);

                if (OF.FileName.ToLower().Contains(".wav"))
                {
                    int sampleRate = (int)float.Parse(samprate.Text);

                    using (Stream stream = new MemoryStream(tmp))
                    {
                        using (WaveFileReader wavFileReader = new WaveFileReader(stream))
                        {
                            WaveFormat outFormat = new WaveFormat(sampleRate, 16, 1);
                            MediaFoundationResampler resampler = new MediaFoundationResampler(wavFileReader, outFormat)
                            {
                                ResamplerQuality = 60
                            };
                            ISampleProvider Source = resampler.ToSampleProvider();
                            SampleToWaveProvider16 monoSource = new SampleToWaveProvider16(Source);
                            using (MemoryStream outputStream = new MemoryStream())
                            {
                                byte[] bytesOutput = new byte[outFormat.AverageBytesPerSecond];
                                while (true)
                                {
                                    int bytesRead = monoSource.Read(bytesOutput, 0, bytesOutput.Length);
                                    if (bytesRead == 0)
                                        break;
                                    outputStream.Write(bytesOutput, 0, bytesRead);
                                }
                                byte[] rawdata = (outputStream.ToArray()); // This is raw PCM data
                                short[] DataToEncode = new short[(int)Math.Ceiling(rawdata.Length / 2.0)];

                                Buffer.BlockCopy(rawdata, 0, DataToEncode, 0, rawdata.Length);
                                rawdata = null;
                                //rewrite as ADPCM data
                                tmp = OKIEncode(DataToEncode);
                            }
                        }
                    }
                }

                int newspace = 0;
                newspace = bankdata.sparespace;
                if (bankdata.samples[sample].depends.Count > 0 && bankdata.samples[sample].depends.Count > 0)
                {
                  //  newspace = bankdata.sparespace;
                }
                else
                {
                    if (bankdata.samples[sample].RAW != null)
                    {
                        newspace += bankdata.samples[sample].RAW.Length;
                    }
                    else
                    {
                        bankdata.samples[sample].RAW = new byte[0];
                    }
                }

                int calcspace = newspace - tmp.Length;
                bool proceed = false;

                if (calcspace < 0)
                {
                    DialogResult confirmResult = MessageBox.Show("Importing this file will exceed the available space by 0x" +
                    Math.Abs(calcspace).ToString("x") + " bytes, proceed?", "Space Warning",
                                                         MessageBoxButtons.OKCancel);
                    if (confirmResult == DialogResult.OK)
                    {
                        proceed = true;
                    }
                }
                else
                {
                    proceed = true;
                }

                if (proceed == true)
                {
                    bankdata.samples[sample].RAW = null;
                    bankdata.samples[sample].RAW = tmp;
                    bankdata.samples[sample].depends.Clear();
                    bankdata.samples[sample].common = false;
                    bankdata.samples[sample].offset = 0;
                    bankdata.samples[sample].start = sample * 0x40000;
                    bankdata.samples[sample].length = bankdata.samples[sample].RAW.Length;
                    SetCtrl(bank);
                    ComputeTimeBank(bank);
                }
            }
            MessageBox.Show("Import complete", "Import Complete",
                                             MessageBoxButtons.OK);
        }

        private byte[] OKIEncode(short[] input)
        {

            byte[] output = new byte[input.Length / 2];
            //convert to 12 bit by clamping
            for (int i = 0; i < input.Length; i++)
            {
                input[i] = (short)(input[i] / 16);
            }

            int j = 0;
            for (int i = 0; i < (input.Length / 2); i++)
            {
                output[i] = (byte)(OKIEncodeShort(input[j++]) << 4);
                if (j > input.Length)  /* only true for last sample when n is odd */
                    output[i] |= (byte)OKIEncodeShort(0);
                else
                    output[i] |= (byte)OKIEncodeShort(input[j++]);
            }

            return output;
        }

        private void PlayRAWfile(int bank, int sample)
        {
            Bank bankdata;

            {
                bankdata = Banks[bank];
            }

            {
                Sample smp = bankdata.samples[sample];
                bool commonflag = smp.common;
                if (commonflag == true)
                {
                    int id = smp.commonid;
                    smp = CommonBank.samples[id];
                }
                if (smp.depends.Count > 0)
                {
                    int StartPosition = smp.offset;
                    int EndPosition = StartPosition + smp.length;

                    int Position = StartPosition;

                    int parentid = smp.depends.ElementAt(0);
                    Sample parent;
                    if (commonflag == true)
                    {
                        parent = CommonBank.samples[parentid];
                    }
                    else
                    {
                        parent = bankdata.samples[parentid];
                    }

                    PlayADPCMSample(parent, Position, EndPosition);
                }
                else
                {
                    int Position = 0;
                    int EndPosition = smp.length;
                    PlayADPCMSample(smp, Position, EndPosition);
                }
            }

        }

        private void PlayADPCMSample(Sample parent, int position, int endPosition)
        {
            int SampleCount = 0;
            int length = endPosition - position;
            short[] ADPCMBuffer = new short[length * 2];

            while (position < endPosition)
            {
                ADPCMBuffer[SampleCount] = OKIDecodeNibble((parent.RAW[position] & 0xf0) >> 4);
                SampleCount++;
                ADPCMBuffer[SampleCount] = OKIDecodeNibble(parent.RAW[position] & 0xf);
                SampleCount++;
                position++;
            }

            PlaySample(ADPCMBuffer);
        }

        static byte[] FromShort(short number)
        {
            byte byte2 = (byte)(number >> 8);
            byte byte1 = (byte)(number & 0xff);
            byte[] output = { byte1, byte2 };
            return output;
        }

        private void PlaySample(short[] ADPCMBuffer)
        {
            byte[] ADPCMPlayBuffer = new byte[ADPCMBuffer.Length * 2];
            for (int i = 0; i < ADPCMBuffer.Length; i++)
            {
                ADPCMBuffer[i] = (short)(ADPCMBuffer[i] * 16);
                byte[] tmp = FromShort(ADPCMBuffer[i]);

                int cursor = (i * 2);
                ADPCMPlayBuffer[cursor] = tmp[0];
                ADPCMPlayBuffer[(cursor + 1)] = tmp[1];
            }

            int sampleRate = (int)float.Parse(samprate.Text);
            MemoryStream ms = new MemoryStream(ADPCMPlayBuffer);
            RawSourceWaveStream rs = new RawSourceWaveStream(ms, new WaveFormat(sampleRate, 16, 1));

            WaveOutEvent wo = new WaveOutEvent();
            wo.Init(rs);
            wo.Play();
            while (wo.PlaybackState == PlaybackState.Playing)
            {
                Thread.Sleep(500);
            }
            wo.Dispose();
        }

        private void ExportSample(byte[] ADPCMData, string Filename)
        {
            int SampleCount = 0;
            int length = ADPCMData.Length;
            short[] ADPCMBuffer = new short[length * 2];
            int position = 0;
            int endPosition = length;

            while (position < endPosition)
            {
                ADPCMBuffer[SampleCount] = OKIDecodeNibble((ADPCMData[position] & 0xf0) >> 4);
                SampleCount++;
                ADPCMBuffer[SampleCount] = OKIDecodeNibble(ADPCMData[position] & 0xf);
                SampleCount++;
                position++;
            }

            byte[] ADPCMPlayBuffer = new byte[ADPCMBuffer.Length * 2];
            for (int i = 0; i < ADPCMBuffer.Length; i++)
            {
                ADPCMBuffer[i] = (short)(ADPCMBuffer[i] * 16);
                byte[] tmp = FromShort(ADPCMBuffer[i]);

                int cursor = (i * 2);
                ADPCMPlayBuffer[cursor] = tmp[0];
                ADPCMPlayBuffer[(cursor + 1)] = tmp[1];
            }

            var sampleRate = (int)float.Parse(samprate.Text);
            var ms = new MemoryStream(ADPCMPlayBuffer);
            var rs = new RawSourceWaveStream(ms, new WaveFormat(sampleRate, 16, 1));

            WaveFileWriter.CreateWaveFile(Filename, rs);
            MessageBox.Show("Export to " + Filename + " complete", "Export Complete",
                                                         MessageBoxButtons.OK);

        }

        private byte[] GenerateBank(int bank)
        {
            int[] newstarts = new int[128];
            byte[] result = new byte[0x20000];

            Bank bankdata = Banks[bank];
            if (bank == 8)
            {

                if (bankdata.sparespace < 0)
                {
                    MessageBox.Show("Common Bank is too large, cannot proceed", "Space Error",
                                                                 MessageBoxButtons.OK);
                }
                int StartPosition = 0;
                foreach (Sample smp in CommonBank.samples)
                {
                    if (smp != null)
                    {

                        if (smp.enabled == true)
                        {
                            {
                                if (smp.depends.Count == 0)
                                {
                                    newstarts[smp.id] = StartPosition;
                                    smp.start = StartPosition;
                                    int EndPosition = StartPosition + smp.length;
                                    smp.end = EndPosition;
                                    Array.Copy(smp.RAW, 0, result, StartPosition, smp.length);
                                    StartPosition += smp.length;
                                }
                                else
                                {
                                    int TMPStartPosition = newstarts[smp.depends.ElementAt(0)] + smp.offset;
                                    newstarts[smp.id] = TMPStartPosition;
                                    smp.start = TMPStartPosition;
                                    int TMPEndPosition = StartPosition + smp.length;
                                    smp.end = TMPEndPosition;
                                }
                            }
                        }
                    }
                }
                return result;

            }
            else
            {
                int cursor = 0x08;
                int headersize = Banks[bank].headersize;
                Sample lastsample = Banks[bank].samples[Banks[bank].lastsample];
                if (lastsample.enabled == false)
                {
                    //we can use the last sample's headerspace and make a few bytes.
                    headersize -= 0x08;
                }

                if (Banks[bank].sparespace < 0)
                {
                    MessageBox.Show("Bank " + bank + "is too large, cannot proceed", "Space Error",
                                                                 MessageBoxButtons.OK);
                }

                foreach (Sample smp in Banks[bank].samples)
                {
                    if (smp != null)
                    {
                        if (smp.enabled == true)
                        {
                            if (smp.common == true)
                            {
                                if (smp.depends.Count == 0)
                                {
                                    smp.start = CommonBank.samples[smp.commonid].start;
                                    smp.end = smp.start + smp.length;
                                    newstarts[smp.id] = smp.start + 0x20000;
                                    int start = newstarts[smp.id];
                                    int end = start + smp.length;

                                    result[cursor] = (byte)(start >> 0x10);
                                    cursor++;
                                    result[cursor] = (byte)((start >> 0x08) & 0xff);
                                    cursor++;
                                    result[cursor] = (byte)((start) & 0xff);
                                    cursor++;
                                    result[cursor] = (byte)(end >> 0x10);
                                    cursor++;
                                    result[cursor] = (byte)((end >> 0x08) & 0xff);
                                    cursor++;
                                    result[cursor] = (byte)((end) & 0xff);
                                    cursor++;
                                    result[cursor] = 0x00;
                                    cursor++;
                                    result[cursor] = 0x00;
                                    cursor++;
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

                                }
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

                                    if (smp.length > 0)
                                    {
                                        Array.Copy(smp.RAW, 0, result, StartPosition, smp.length);
                                    }
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

                                    //                                    Array.Copy(smp.RAW, 0, result, StartPosition, smp.length);
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
                return result;
            }
        }

        private void GenerateROMs(object sender, EventArgs e)
        {
            byte[] bank0 = null;
            byte[] bank2 = null;
            byte[] bank3 = null;
            byte[] bank4 = null;
            byte[] bank5 = null;
            byte[] bank6 = null;
            byte[] bank7 = null;
            byte[] bankCOM = null;
            //Do the common Bank first
            bankCOM = GenerateBank(8);


            bank0 = GenerateBank(0);

            if (U12Mirror == false)
            {
                bank2 = GenerateBank(2);
                bank3 = GenerateBank(3);
            }
            if (U13Mirror == false)
            {
                bank6 = GenerateBank(6);
                bank7 = GenerateBank(7);
            }
            bank4 = GenerateBank(4);
            bank5 = GenerateBank(5);


            string U12Name="";
            SaveFileDialog SF = new SaveFileDialog
            {
                Title = "Save U12 File",
                InitialDirectory = ROMExportDir,
                Filter = "All files (*) | *.*",
                OverwritePrompt = true
            };
            if (SF.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                SF.FilterIndex = 0;
                ROMExportDir = System.IO.Path.GetDirectoryName(SF.FileName);

                byte[] U12Out;
                if (U12Mirror == false)
                {
                    U12Out = new byte[0x80000];
                    Array.Copy(bank3, 0, U12Out, 0x00000, 0x20000);
                    Array.Copy(bank2, 0, U12Out, 0x20000, 0x20000);
                    Array.Copy(bank0, 0, U12Out, 0x40000, 0x20000);
                    Array.Copy(bankCOM, 0, U12Out, 0x60000, 0x20000);//common
                }
                else
                {
                    U12Out = new byte[0x40000];
                    Array.Copy(bank0, 0, U12Out, 0x00000, 0x20000);
                    Array.Copy(bankCOM, 0, U12Out, 0x20000, 0x20000);//common
                }

                U12Name = SF.FileName;
                File.WriteAllBytes(SF.FileName, U12Out);
                U12Out = null;
            }

            string U13Name="";

            SF = new SaveFileDialog
            {
                Title = "Save U13 File",
                InitialDirectory = ROMExportDir,
                Filter = "All files (*) | *.*",
                OverwritePrompt = true
            };
            if (SF.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                SF.FilterIndex = 0;
                ROMExportDir = System.IO.Path.GetDirectoryName(SF.FileName);

                byte[] U13Out;
                if (U13Mirror == false)
                {
                    U13Out = new byte[0x80000];
                    Array.Copy(bank7, 0, U13Out, 0x00000, 0x20000);
                    Array.Copy(bank6, 0, U13Out, 0x20000, 0x20000);
                    Array.Copy(bank5, 0, U13Out, 0x40000, 0x20000);
                    Array.Copy(bank4, 0, U13Out, 0x60000, 0x20000);
                }
                else
                {
                    U13Out = new byte[0x40000];
                    Array.Copy(bank5, 0, U13Out, 0x00000, 0x20000);
                    Array.Copy(bank4, 0, U13Out, 0x20000, 0x20000);
                }
                U13Name = SF.FileName;

                File.WriteAllBytes(SF.FileName, U13Out);
                U13Out = null;
            }
            MessageBox.Show("Export of ROMs complete", "Export Complete",
                                                         MessageBoxButtons.OK);
            bank0 = null;
            bank2 = null;
            bank3 = null;
            bank4 = null;
            bank5 = null;
            bank6 = null;
            bank7 = null;
            bankCOM = null;

            ROMReload(U12Name, U13Name);

        }
        private void UpdateEnable(int bank, int sample, bool state, Button import, Button export, Button play)
        {
            Sample smp;
            {
                smp = Banks[bank].samples[sample];
            }
            smp.enabled = state;
            import.Enabled = state;
            export.Enabled = state;
            play.Enabled = state;

            for (int i=0; i < 128; i++)
            {
              Sample test = Banks[bank].samples[sample];
              if (test.enabled) {
                Banks[bank].lastsample = i;					
              }
            }
            ComputeTimeBank(bank);

        }


        private void UpdateLength(int bank, int sample, String text)
        {
//            if (bank < 8)
            {
                if (text.Length == 0)
                {
                    text = Banks[bank].samples[sample].length.ToString();
                }
                Banks[bank].samples[sample].length = int.Parse(text, NumberStyles.HexNumber);
            }
            SetCtrl(bank);
        }

        private void UpdateOffset(int bank, int sample, String text)
        {
            {
                if (text.Length == 0)
                {
                    Banks[bank].samples[sample].offset = 0;
                }
                Banks[bank].samples[sample].offset = int.Parse(text, NumberStyles.HexNumber);
            }
            SetCtrl(bank);
        }

        private void UpdateDepend(int bank, int sample, String text)
        {
            Bank bankdata;
            {
                bankdata = Banks[bank];
            }
            if (text.Length == 0)
            {
                bankdata.samples[sample].depends.Clear();
            }
            if (text.Contains("0x"))
            {
                bankdata.samples[sample].depends[0] = int.Parse(text, NumberStyles.HexNumber);
            }
            else
            {
                bankdata.samples[sample].depends[0] = int.Parse(text);
            }
            SetCtrl(bank);

        }


        private void UpdateID(int bank, int sample, String text)
        {
            Sample smp = Banks[bank].samples[sample];
            String[] splitarray = text.Split('C');
            if (splitarray.Length == 2)
            {
                int comid = int.Parse(splitarray[1], NumberStyles.Integer);


                smp.common = true;
                smp.commonid = comid;
                SetCtrl(bank);
            }
            else
            {
                text = "C" + smp.commonid.ToString("X2");
            }

        }

        byte OKIEncodeShort(short Short)
        {
            int oki_byte;
            short E, SS;

            SS = SS = StepOKI[ADPCMIndex];
            oki_byte = 0x00;

            short delta = (short)(Short - ADPCMLast);
            if (delta < 0)
            {
                // dropping waveform
                oki_byte = 0x08;
                E = (short)-delta;
            }
            else
            {
                E = delta;
            }
            if (E >= SS)
            {
                oki_byte = (oki_byte | 0x04);
                E -= SS;
            }
            if (E >= SS / 2)
            {
                oki_byte = (oki_byte | 0x02);
                E -= (byte)(SS / 2);
            }
            if (E >= SS / 4)
            {
                oki_byte = (oki_byte | 0x01);
            }

            //The reference implementation uses the decoder to predict the last sample
            ADPCMLast = OKIDecodeNibble(oki_byte);
            return (byte)oki_byte;
        }

        short OKIDecodeNibble(int Nibble)
        {
            short SS, Sample, Diff, E;


            SS = StepOKI[ADPCMIndex];
            E = (short)(SS / 8);

            if ((Nibble & 0x01) > 0)
            {
                E += (short)(SS >> 2);
            }
            if ((Nibble & 0x02) > 0)
            {
                E += (short)(SS >> 1);
            }
            if ((Nibble & 0x04) > 0)
            {
                E += (short)SS;
            }

            if ((Nibble & 0x08) > 0)
            {
                Diff = (short)-E;
            }
            else
            {
                Diff = (short)E;
            }

            Sample = (short)(ADPCMLast + Diff);

            if (Sample > 2047)
            {
                Sample = 2047;
            }
            if (Sample < -2048)
            {
                Sample = -2048;
            }

            ADPCMLast = Sample;
            ADPCMIndex += OKIAdjusts[Nibble];

            if (ADPCMIndex > 48)
            {
                ADPCMIndex = 48;
            }
            if (ADPCMIndex < 0)
            {
                ADPCMIndex = 0;
            }

            return (Sample);

        }

    }
}
