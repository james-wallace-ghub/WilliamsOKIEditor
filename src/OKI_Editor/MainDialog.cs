using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
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

        private void updateCtrl0()
        {
            if (Banks[0].samples[0].enabled == true)
            {
                Banks[0].samples[0].depends.Clear();
                this.B0_S1_Dep.Text = "";
                this.B0_S1_Off.Text = "0x" + Banks[0].samples[0].offset.ToString("x");
                this.B0_S1_Len.Text = "0x" + Banks[0].samples[0].length.ToString("x");
            }
            if (Banks[0].samples[1].enabled == true)
            {
                Banks[0].samples[1].depends.Clear();
                this.B0_S2_Dep.Text = "";
                this.B0_S2_Off.Text = "0x" + Banks[0].samples[1].offset.ToString("x");
                this.B0_S2_Len.Text = "0x" + Banks[0].samples[1].length.ToString("x");
            }
            if (Banks[0].samples[2].enabled == true)
            {
                Banks[0].samples[2].depends.Clear();
                this.B0_S3_Dep.Text = "";
                this.B0_S3_Off.Text = "0x" + Banks[0].samples[2].offset.ToString("x");
                this.B0_S3_Len.Text = "0x" + Banks[0].samples[2].length.ToString("x");
            }
            if (Banks[0].samples[3].enabled == true)
            {
                Banks[0].samples[3].depends.Clear();
                this.B0_S4_Dep.Text = "";
                this.B0_S4_Off.Text = "0x" + Banks[0].samples[3].offset.ToString("x");
                this.B0_S4_Len.Text = "0x" + Banks[0].samples[3].length.ToString("x");
            }
            if (Banks[0].samples[4].enabled == true)
            {
                Banks[0].samples[4].depends.Clear();
                this.B0_S5_Dep.Text = "";
                this.B0_S5_Off.Text = "0x" + Banks[0].samples[4].offset.ToString("x");
                this.B0_S5_Len.Text = "0x" + Banks[0].samples[4].length.ToString("x");
            }
            if (Banks[0].samples[5].enabled == true)
            {
                Banks[0].samples[5].depends.Clear();
                this.B0_S6_Dep.Text = "";
                this.B0_S6_Off.Text = "0x" + Banks[0].samples[5].offset.ToString("x");
                this.B0_S6_Len.Text = "0x" + Banks[0].samples[5].length.ToString("x");
            }
            if (Banks[0].samples[6].enabled == true)
            {
                Banks[0].samples[6].depends.Clear();
                this.B0_S7_Dep.Text = "";
                this.B0_S7_Off.Text = "0x" + Banks[0].samples[6].offset.ToString("x");
                this.B0_S7_Len.Text = "0x" + Banks[0].samples[6].length.ToString("x");
            }
            if (Banks[0].samples[7].enabled == true)
            {
                Banks[0].samples[7].depends.Clear();
                this.B0_S8_Dep.Text = "";
                this.B0_S8_Off.Text = "0x" + Banks[0].samples[7].offset.ToString("x");
                this.B0_S8_Len.Text = "0x" + Banks[0].samples[7].length.ToString("x");
            }
            if (Banks[0].samples[8].enabled == true)
            {
                Banks[0].samples[8].depends.Clear();
                this.B0_S9_Dep.Text = "";
                this.B0_S9_Off.Text = "0x" + Banks[0].samples[8].offset.ToString("x");
                this.B0_S9_Len.Text = "0x" + Banks[0].samples[8].length.ToString("x");
            }
            if (Banks[0].samples[9].enabled == true)
            {
                Banks[0].samples[9].depends.Clear();
                this.B0_S10_Dep.Text = "";
                this.B0_S10_Off.Text = "0x" + Banks[0].samples[9].offset.ToString("x");
                this.B0_S10_Len.Text = "0x" + Banks[0].samples[9].length.ToString("x");
            }
            if (Banks[0].samples[10].enabled == true)
            {
                Banks[0].samples[10].depends.Clear();
                this.B0_S11_Dep.Text = "";
                this.B0_S11_Off.Text = "0x" + Banks[0].samples[10].offset.ToString("x");
                this.B0_S11_Len.Text = "0x" + Banks[0].samples[10].length.ToString("x");
            }
            if (Banks[0].samples[11].enabled == true)
            {
                Banks[0].samples[11].depends.Clear();
                this.B0_S12_Dep.Text = "";
                this.B0_S12_Off.Text = "0x" + Banks[0].samples[11].offset.ToString("x");
                this.B0_S12_Len.Text = "0x" + Banks[0].samples[11].length.ToString("x");
            }
            if (Banks[0].samples[12].enabled == true)
            {
                Banks[0].samples[12].depends.Clear();
                this.B0_S13_Dep.Text = "";
                this.B0_S13_Off.Text = "0x" + Banks[0].samples[12].offset.ToString("x");
                this.B0_S13_Len.Text = "0x" + Banks[0].samples[12].length.ToString("x");
            }
            if (Banks[0].samples[13].enabled == true)
            {
                Banks[0].samples[13].depends.Clear();
                this.B0_S14_Dep.Text = "";
                this.B0_S14_Off.Text = "0x" + Banks[0].samples[13].offset.ToString("x");
                this.B0_S14_Len.Text = "0x" + Banks[0].samples[13].length.ToString("x");
            }
            if (Banks[0].samples[14].enabled == true)
            {
                Banks[0].samples[14].depends.Clear();
                this.B0_S15_Dep.Text = "";
                this.B0_S15_Off.Text = "0x" + Banks[0].samples[14].offset.ToString("x");
                this.B0_S15_Len.Text = "0x" + Banks[0].samples[14].length.ToString("x");
            }
            if (Banks[0].samples[15].enabled == true)
            {
                Banks[0].samples[15].depends.Clear();
                this.B0_S16_Dep.Text = "";
                this.B0_S16_Off.Text = "0x" + Banks[0].samples[15].offset.ToString("x");
                this.B0_S16_Len.Text = "0x" + Banks[0].samples[15].length.ToString("x");
            }
            if (Banks[0].samples[16].enabled == true)
            {
                Banks[0].samples[16].depends.Clear();
                this.B0_S17_Dep.Text = "";
                this.B0_S17_Off.Text = "0x" + Banks[0].samples[16].offset.ToString("x");
                this.B0_S17_Len.Text = "0x" + Banks[0].samples[16].length.ToString("x");
            }
            if (Banks[0].samples[17].enabled == true)
            {
                Banks[0].samples[17].depends.Clear();
                this.B0_S18_Dep.Text = "";
                this.B0_S18_Off.Text = "0x" + Banks[0].samples[17].offset.ToString("x");
                this.B0_S18_Len.Text = "0x" + Banks[0].samples[17].length.ToString("x");
            }
            if (Banks[0].samples[18].enabled == true)
            {
                Banks[0].samples[18].depends.Clear();
                this.B0_S19_Dep.Text = "";
                this.B0_S19_Off.Text = "0x" + Banks[0].samples[18].offset.ToString("x");
                this.B0_S19_Len.Text = "0x" + Banks[0].samples[18].length.ToString("x");
            }
            if (Banks[0].samples[19].enabled == true)
            {
                Banks[0].samples[19].depends.Clear();
                this.B0_S110_Dep.Text = "";
                this.B0_S110_Off.Text = "0x" + Banks[0].samples[19].offset.ToString("x");
                this.B0_S110_Len.Text = "0x" + Banks[0].samples[19].length.ToString("x");
            }
            if (Banks[0].samples[20].enabled == true)
            {
                Banks[0].samples[20].depends.Clear();
                this.B0_S21_Dep.Text = "";
                this.B0_S21_Off.Text = "0x" + Banks[0].samples[20].offset.ToString("x");
                this.B0_S21_Len.Text = "0x" + Banks[0].samples[20].length.ToString("x");
            }
            if (Banks[0].samples[21].enabled == true)
            {
                Banks[0].samples[21].depends.Clear();
                this.B0_S22_Dep.Text = "";
                this.B0_S22_Off.Text = "0x" + Banks[0].samples[21].offset.ToString("x");
                this.B0_S22_Len.Text = "0x" + Banks[0].samples[21].length.ToString("x");
            }
            if (Banks[0].samples[22].enabled == true)
            {
                Banks[0].samples[22].depends.Clear();
                this.B0_S23_Dep.Text = "";
                this.B0_S23_Off.Text = "0x" + Banks[0].samples[22].offset.ToString("x");
                this.B0_S23_Len.Text = "0x" + Banks[0].samples[22].length.ToString("x");
            }
            if (Banks[0].samples[23].enabled == true)
            {
                Banks[0].samples[23].depends.Clear();
                this.B0_S24_Dep.Text = "";
                this.B0_S24_Off.Text = "0x" + Banks[0].samples[23].offset.ToString("x");
                this.B0_S24_Len.Text = "0x" + Banks[0].samples[23].length.ToString("x");
            }
            if (Banks[0].samples[24].enabled == true)
            {
                Banks[0].samples[24].depends.Clear();
                this.B0_S25_Dep.Text = "";
                this.B0_S25_Off.Text = "0x" + Banks[0].samples[24].offset.ToString("x");
                this.B0_S25_Len.Text = "0x" + Banks[0].samples[24].length.ToString("x");
            }
            if (Banks[0].samples[25].enabled == true)
            {
                Banks[0].samples[25].depends.Clear();
                this.B0_S26_Dep.Text = "";
                this.B0_S26_Off.Text = "0x" + Banks[0].samples[25].offset.ToString("x");
                this.B0_S26_Len.Text = "0x" + Banks[0].samples[25].length.ToString("x");
            }
            if (Banks[0].samples[26].enabled == true)
            {
                Banks[0].samples[26].depends.Clear();
                this.B0_S27_Dep.Text = "";
                this.B0_S27_Off.Text = "0x" + Banks[0].samples[26].offset.ToString("x");
                this.B0_S27_Len.Text = "0x" + Banks[0].samples[26].length.ToString("x");
            }
            if (Banks[0].samples[27].enabled == true)
            {
                Banks[0].samples[27].depends.Clear();
                this.B0_S28_Dep.Text = "";
                this.B0_S28_Off.Text = "0x" + Banks[0].samples[27].offset.ToString("x");
                this.B0_S28_Len.Text = "0x" + Banks[0].samples[27].length.ToString("x");
            }
            if (Banks[0].samples[28].enabled == true)
            {
                Banks[0].samples[28].depends.Clear();
                this.B0_S29_Dep.Text = "";
                this.B0_S29_Off.Text = "0x" + Banks[0].samples[28].offset.ToString("x");
                this.B0_S29_Len.Text = "0x" + Banks[0].samples[28].length.ToString("x");
            }
            if (Banks[0].samples[29].enabled == true)
            {
                Banks[0].samples[29].depends.Clear();
                this.B0_S30_Dep.Text = "";
                this.B0_S30_Off.Text = "0x" + Banks[0].samples[29].offset.ToString("x");
                this.B0_S30_Len.Text = "0x" + Banks[0].samples[29].length.ToString("x");
            }
            if (Banks[0].samples[30].enabled == true)
            {
                Banks[0].samples[30].depends.Clear();
                this.B0_S31_Dep.Text = "";
                this.B0_S31_Off.Text = "0x" + Banks[0].samples[30].offset.ToString("x");
                this.B0_S31_Len.Text = "0x" + Banks[0].samples[30].length.ToString("x");
            }
            if (Banks[0].samples[31].enabled == true)
            {
                Banks[0].samples[31].depends.Clear();
                this.B0_S32_Dep.Text = "";
                this.B0_S32_Off.Text = "0x" + Banks[0].samples[31].offset.ToString("x");
                this.B0_S32_Len.Text = "0x" + Banks[0].samples[31].length.ToString("x");
            }
            if (Banks[0].samples[32].enabled == true)
            {
                Banks[0].samples[32].depends.Clear();
                this.B0_S33_Dep.Text = "";
                this.B0_S33_Off.Text = "0x" + Banks[0].samples[32].offset.ToString("x");
                this.B0_S33_Len.Text = "0x" + Banks[0].samples[32].length.ToString("x");
            }
            if (Banks[0].samples[33].enabled == true)
            {
                Banks[0].samples[33].depends.Clear();
                this.B0_S34_Dep.Text = "";
                this.B0_S34_Off.Text = "0x" + Banks[0].samples[33].offset.ToString("x");
                this.B0_S34_Len.Text = "0x" + Banks[0].samples[33].length.ToString("x");
            }
            if (Banks[0].samples[34].enabled == true)
            {
                Banks[0].samples[34].depends.Clear();
                this.B0_S35_Dep.Text = "";
                this.B0_S35_Off.Text = "0x" + Banks[0].samples[34].offset.ToString("x");
                this.B0_S35_Len.Text = "0x" + Banks[0].samples[34].length.ToString("x");
            }
            if (Banks[0].samples[35].enabled == true)
            {
                Banks[0].samples[35].depends.Clear();
                this.B0_S36_Dep.Text = "";
                this.B0_S36_Off.Text = "0x" + Banks[0].samples[35].offset.ToString("x");
                this.B0_S36_Len.Text = "0x" + Banks[0].samples[35].length.ToString("x");
            }
            if (Banks[0].samples[36].enabled == true)
            {
                Banks[0].samples[36].depends.Clear();
                this.B0_S37_Dep.Text = "";
                this.B0_S37_Off.Text = "0x" + Banks[0].samples[36].offset.ToString("x");
                this.B0_S37_Len.Text = "0x" + Banks[0].samples[36].length.ToString("x");
            }
            if (Banks[0].samples[37].enabled == true)
            {
                Banks[0].samples[37].depends.Clear();
                this.B0_S38_Dep.Text = "";
                this.B0_S38_Off.Text = "0x" + Banks[0].samples[37].offset.ToString("x");
                this.B0_S38_Len.Text = "0x" + Banks[0].samples[37].length.ToString("x");
            }
            if (Banks[0].samples[38].enabled == true)
            {
                Banks[0].samples[38].depends.Clear();
                this.B0_S39_Dep.Text = "";
                this.B0_S39_Off.Text = "0x" + Banks[0].samples[38].offset.ToString("x");
                this.B0_S39_Len.Text = "0x" + Banks[0].samples[38].length.ToString("x");
            }
            if (Banks[0].samples[39].enabled == true)
            {
                Banks[0].samples[39].depends.Clear();
                this.B0_S40_Dep.Text = "";
                this.B0_S40_Off.Text = "0x" + Banks[0].samples[39].offset.ToString("x");
                this.B0_S40_Len.Text = "0x" + Banks[0].samples[39].length.ToString("x");
            }
            if (Banks[0].samples[40].enabled == true)
            {
                Banks[0].samples[40].depends.Clear();
                this.B0_S41_Dep.Text = "";
                this.B0_S41_Off.Text = "0x" + Banks[0].samples[40].offset.ToString("x");
                this.B0_S41_Len.Text = "0x" + Banks[0].samples[40].length.ToString("x");
            }
            if (Banks[0].samples[41].enabled == true)
            {
                Banks[0].samples[41].depends.Clear();
                this.B0_S42_Dep.Text = "";
                this.B0_S42_Off.Text = "0x" + Banks[0].samples[41].offset.ToString("x");
                this.B0_S42_Len.Text = "0x" + Banks[0].samples[41].length.ToString("x");
            }
            if (Banks[0].samples[42].enabled == true)
            {
                Banks[0].samples[42].depends.Clear();
                this.B0_S43_Dep.Text = "";
                this.B0_S43_Off.Text = "0x" + Banks[0].samples[42].offset.ToString("x");
                this.B0_S43_Len.Text = "0x" + Banks[0].samples[42].length.ToString("x");
            }
            if (Banks[0].samples[43].enabled == true)
            {
                Banks[0].samples[43].depends.Clear();
                this.B0_S44_Dep.Text = "";
                this.B0_S44_Off.Text = "0x" + Banks[0].samples[43].offset.ToString("x");
                this.B0_S44_Len.Text = "0x" + Banks[0].samples[43].length.ToString("x");
            }
            if (Banks[0].samples[44].enabled == true)
            {
                Banks[0].samples[44].depends.Clear();
                this.B0_S45_Dep.Text = "";
                this.B0_S45_Off.Text = "0x" + Banks[0].samples[44].offset.ToString("x");
                this.B0_S45_Len.Text = "0x" + Banks[0].samples[44].length.ToString("x");
            }
            if (Banks[0].samples[45].enabled == true)
            {
                Banks[0].samples[45].depends.Clear();
                this.B0_S46_Dep.Text = "";
                this.B0_S46_Off.Text = "0x" + Banks[0].samples[45].offset.ToString("x");
                this.B0_S46_Len.Text = "0x" + Banks[0].samples[45].length.ToString("x");
            }
            if (Banks[0].samples[46].enabled == true)
            {
                Banks[0].samples[46].depends.Clear();
                this.B0_S47_Dep.Text = "";
                this.B0_S47_Off.Text = "0x" + Banks[0].samples[46].offset.ToString("x");
                this.B0_S47_Len.Text = "0x" + Banks[0].samples[46].length.ToString("x");
            }
            if (Banks[0].samples[47].enabled == true)
            {
                Banks[0].samples[47].depends.Clear();
                this.B0_S48_Dep.Text = "";
                this.B0_S48_Off.Text = "0x" + Banks[0].samples[47].offset.ToString("x");
                this.B0_S48_Len.Text = "0x" + Banks[0].samples[47].length.ToString("x");
            }
            if (Banks[0].samples[48].enabled == true)
            {
                Banks[0].samples[48].depends.Clear();
                this.B0_S49_Dep.Text = "";
                this.B0_S49_Off.Text = "0x" + Banks[0].samples[48].offset.ToString("x");
                this.B0_S49_Len.Text = "0x" + Banks[0].samples[48].length.ToString("x");
            }
            if (Banks[0].samples[49].enabled == true)
            {
                Banks[0].samples[49].depends.Clear();
                this.B0_S50_Dep.Text = "";
                this.B0_S50_Off.Text = "0x" + Banks[0].samples[49].offset.ToString("x");
                this.B0_S50_Len.Text = "0x" + Banks[0].samples[49].length.ToString("x");
            }
            if (Banks[0].samples[50].enabled == true)
            {
                Banks[0].samples[50].depends.Clear();
                this.B0_S51_Dep.Text = "";
                this.B0_S51_Off.Text = "0x" + Banks[0].samples[50].offset.ToString("x");
                this.B0_S51_Len.Text = "0x" + Banks[0].samples[50].length.ToString("x");
            }
            if (Banks[0].samples[51].enabled == true)
            {
                Banks[0].samples[51].depends.Clear();
                this.B0_S52_Dep.Text = "";
                this.B0_S52_Off.Text = "0x" + Banks[0].samples[51].offset.ToString("x");
                this.B0_S52_Len.Text = "0x" + Banks[0].samples[51].length.ToString("x");
            }
            if (Banks[0].samples[52].enabled == true)
            {
                Banks[0].samples[52].depends.Clear();
                this.B0_S53_Dep.Text = "";
                this.B0_S53_Off.Text = "0x" + Banks[0].samples[52].offset.ToString("x");
                this.B0_S53_Len.Text = "0x" + Banks[0].samples[52].length.ToString("x");
            }
            if (Banks[0].samples[53].enabled == true)
            {
                Banks[0].samples[53].depends.Clear();
                this.B0_S54_Dep.Text = "";
                this.B0_S54_Off.Text = "0x" + Banks[0].samples[53].offset.ToString("x");
                this.B0_S54_Len.Text = "0x" + Banks[0].samples[53].length.ToString("x");
            }
            if (Banks[0].samples[54].enabled == true)
            {
                Banks[0].samples[54].depends.Clear();
                this.B0_S55_Dep.Text = "";
                this.B0_S55_Off.Text = "0x" + Banks[0].samples[54].offset.ToString("x");
                this.B0_S55_Len.Text = "0x" + Banks[0].samples[54].length.ToString("x");
            }
            if (Banks[0].samples[55].enabled == true)
            {
                Banks[0].samples[55].depends.Clear();
                this.B0_S56_Dep.Text = "";
                this.B0_S56_Off.Text = "0x" + Banks[0].samples[55].offset.ToString("x");
                this.B0_S56_Len.Text = "0x" + Banks[0].samples[55].length.ToString("x");
            }
            if (Banks[0].samples[56].enabled == true)
            {
                Banks[0].samples[56].depends.Clear();
                this.B0_S57_Dep.Text = "";
                this.B0_S57_Off.Text = "0x" + Banks[0].samples[56].offset.ToString("x");
                this.B0_S57_Len.Text = "0x" + Banks[0].samples[56].length.ToString("x");
            }
            if (Banks[0].samples[57].enabled == true)
            {
                Banks[0].samples[57].depends.Clear();
                this.B0_S58_Dep.Text = "";
                this.B0_S58_Off.Text = "0x" + Banks[0].samples[57].offset.ToString("x");
                this.B0_S58_Len.Text = "0x" + Banks[0].samples[57].length.ToString("x");
            }
            if (Banks[0].samples[58].enabled == true)
            {
                Banks[0].samples[58].depends.Clear();
                this.B0_S59_Dep.Text = "";
                this.B0_S59_Off.Text = "0x" + Banks[0].samples[58].offset.ToString("x");
                this.B0_S59_Len.Text = "0x" + Banks[0].samples[58].length.ToString("x");
            }
            if (Banks[0].samples[59].enabled == true)
            {
                Banks[0].samples[59].depends.Clear();
                this.B0_S60_Dep.Text = "";
                this.B0_S60_Off.Text = "0x" + Banks[0].samples[59].offset.ToString("x");
                this.B0_S60_Len.Text = "0x" + Banks[0].samples[59].length.ToString("x");
            }
            if (Banks[0].samples[60].enabled == true)
            {
                Banks[0].samples[60].depends.Clear();
                this.B0_S61_Dep.Text = "";
                this.B0_S61_Off.Text = "0x" + Banks[0].samples[60].offset.ToString("x");
                this.B0_S61_Len.Text = "0x" + Banks[0].samples[60].length.ToString("x");
            }
            if (Banks[0].samples[61].enabled == true)
            {
                Banks[0].samples[61].depends.Clear();
                this.B0_S62_Dep.Text = "";
                this.B0_S62_Off.Text = "0x" + Banks[0].samples[61].offset.ToString("x");
                this.B0_S62_Len.Text = "0x" + Banks[0].samples[61].length.ToString("x");
            }
            if (Banks[0].samples[62].enabled == true)
            {
                Banks[0].samples[62].depends.Clear();
                this.B0_S63_Dep.Text = "";
                this.B0_S63_Off.Text = "0x" + Banks[0].samples[62].offset.ToString("x");
                this.B0_S63_Len.Text = "0x" + Banks[0].samples[62].length.ToString("x");
            }
            if (Banks[0].samples[63].enabled == true)
            {
                Banks[0].samples[63].depends.Clear();
                this.B0_S64_Dep.Text = "";
                this.B0_S64_Off.Text = "0x" + Banks[0].samples[63].offset.ToString("x");
                this.B0_S64_Len.Text = "0x" + Banks[0].samples[63].length.ToString("x");
            }
            if (Banks[0].samples[64].enabled == true)
            {
                Banks[0].samples[64].depends.Clear();
                this.B0_S65_Dep.Text = "";
                this.B0_S65_Off.Text = "0x" + Banks[0].samples[64].offset.ToString("x");
                this.B0_S65_Len.Text = "0x" + Banks[0].samples[64].length.ToString("x");
            }
            if (Banks[0].samples[65].enabled == true)
            {
                Banks[0].samples[65].depends.Clear();
                this.B0_S66_Dep.Text = "";
                this.B0_S66_Off.Text = "0x" + Banks[0].samples[65].offset.ToString("x");
                this.B0_S66_Len.Text = "0x" + Banks[0].samples[65].length.ToString("x");
            }
            if (Banks[0].samples[66].enabled == true)
            {
                Banks[0].samples[66].depends.Clear();
                this.B0_S67_Dep.Text = "";
                this.B0_S67_Off.Text = "0x" + Banks[0].samples[66].offset.ToString("x");
                this.B0_S67_Len.Text = "0x" + Banks[0].samples[66].length.ToString("x");
            }
            if (Banks[0].samples[67].enabled == true)
            {
                Banks[0].samples[67].depends.Clear();
                this.B0_S68_Dep.Text = "";
                this.B0_S68_Off.Text = "0x" + Banks[0].samples[67].offset.ToString("x");
                this.B0_S68_Len.Text = "0x" + Banks[0].samples[67].length.ToString("x");
            }
            if (Banks[0].samples[68].enabled == true)
            {
                Banks[0].samples[68].depends.Clear();
                this.B0_S69_Dep.Text = "";
                this.B0_S69_Off.Text = "0x" + Banks[0].samples[68].offset.ToString("x");
                this.B0_S69_Len.Text = "0x" + Banks[0].samples[68].length.ToString("x");
            }
            if (Banks[0].samples[69].enabled == true)
            {
                Banks[0].samples[69].depends.Clear();
                this.B0_S70_Dep.Text = "";
                this.B0_S70_Off.Text = "0x" + Banks[0].samples[69].offset.ToString("x");
                this.B0_S70_Len.Text = "0x" + Banks[0].samples[69].length.ToString("x");
            }
            if (Banks[0].samples[70].enabled == true)
            {
                Banks[0].samples[70].depends.Clear();
                this.B0_S71_Dep.Text = "";
                this.B0_S71_Off.Text = "0x" + Banks[0].samples[70].offset.ToString("x");
                this.B0_S71_Len.Text = "0x" + Banks[0].samples[70].length.ToString("x");
            }
            if (Banks[0].samples[71].enabled == true)
            {
                Banks[0].samples[71].depends.Clear();
                this.B0_S72_Dep.Text = "";
                this.B0_S72_Off.Text = "0x" + Banks[0].samples[71].offset.ToString("x");
                this.B0_S72_Len.Text = "0x" + Banks[0].samples[71].length.ToString("x");
            }
            if (Banks[0].samples[72].enabled == true)
            {
                Banks[0].samples[72].depends.Clear();
                this.B0_S73_Dep.Text = "";
                this.B0_S73_Off.Text = "0x" + Banks[0].samples[72].offset.ToString("x");
                this.B0_S73_Len.Text = "0x" + Banks[0].samples[72].length.ToString("x");
            }
            if (Banks[0].samples[73].enabled == true)
            {
                Banks[0].samples[73].depends.Clear();
                this.B0_S74_Dep.Text = "";
                this.B0_S74_Off.Text = "0x" + Banks[0].samples[73].offset.ToString("x");
                this.B0_S74_Len.Text = "0x" + Banks[0].samples[73].length.ToString("x");
            }
            if (Banks[0].samples[74].enabled == true)
            {
                Banks[0].samples[74].depends.Clear();
                this.B0_S75_Dep.Text = "";
                this.B0_S75_Off.Text = "0x" + Banks[0].samples[74].offset.ToString("x");
                this.B0_S75_Len.Text = "0x" + Banks[0].samples[74].length.ToString("x");
            }
            if (Banks[0].samples[75].enabled == true)
            {
                Banks[0].samples[75].depends.Clear();
                this.B0_S76_Dep.Text = "";
                this.B0_S76_Off.Text = "0x" + Banks[0].samples[75].offset.ToString("x");
                this.B0_S76_Len.Text = "0x" + Banks[0].samples[75].length.ToString("x");
            }
            if (Banks[0].samples[76].enabled == true)
            {
                Banks[0].samples[76].depends.Clear();
                this.B0_S77_Dep.Text = "";
                this.B0_S77_Off.Text = "0x" + Banks[0].samples[76].offset.ToString("x");
                this.B0_S77_Len.Text = "0x" + Banks[0].samples[76].length.ToString("x");
            }
            if (Banks[0].samples[77].enabled == true)
            {
                Banks[0].samples[77].depends.Clear();
                this.B0_S78_Dep.Text = "";
                this.B0_S78_Off.Text = "0x" + Banks[0].samples[77].offset.ToString("x");
                this.B0_S78_Len.Text = "0x" + Banks[0].samples[77].length.ToString("x");
            }
            if (Banks[0].samples[78].enabled == true)
            {
                Banks[0].samples[78].depends.Clear();
                this.B0_S79_Dep.Text = "";
                this.B0_S79_Off.Text = "0x" + Banks[0].samples[78].offset.ToString("x");
                this.B0_S79_Len.Text = "0x" + Banks[0].samples[78].length.ToString("x");
            }
            if (Banks[0].samples[79].enabled == true)
            {
                Banks[0].samples[79].depends.Clear();
                this.B0_S80_Dep.Text = "";
                this.B0_S80_Off.Text = "0x" + Banks[0].samples[79].offset.ToString("x");
                this.B0_S80_Len.Text = "0x" + Banks[0].samples[79].length.ToString("x");
            }
            if (Banks[0].samples[80].enabled == true)
            {
                Banks[0].samples[80].depends.Clear();
                this.B0_S81_Dep.Text = "";
                this.B0_S81_Off.Text = "0x" + Banks[0].samples[80].offset.ToString("x");
                this.B0_S81_Len.Text = "0x" + Banks[0].samples[80].length.ToString("x");
            }
            if (Banks[0].samples[81].enabled == true)
            {
                Banks[0].samples[81].depends.Clear();
                this.B0_S82_Dep.Text = "";
                this.B0_S82_Off.Text = "0x" + Banks[0].samples[81].offset.ToString("x");
                this.B0_S82_Len.Text = "0x" + Banks[0].samples[81].length.ToString("x");
            }
            if (Banks[0].samples[82].enabled == true)
            {
                Banks[0].samples[82].depends.Clear();
                this.B0_S83_Dep.Text = "";
                this.B0_S83_Off.Text = "0x" + Banks[0].samples[82].offset.ToString("x");
                this.B0_S83_Len.Text = "0x" + Banks[0].samples[82].length.ToString("x");
            }
            if (Banks[0].samples[83].enabled == true)
            {
                Banks[0].samples[83].depends.Clear();
                this.B0_S84_Dep.Text = "";
                this.B0_S84_Off.Text = "0x" + Banks[0].samples[83].offset.ToString("x");
                this.B0_S84_Len.Text = "0x" + Banks[0].samples[83].length.ToString("x");
            }
            if (Banks[0].samples[84].enabled == true)
            {
                Banks[0].samples[84].depends.Clear();
                this.B0_S85_Dep.Text = "";
                this.B0_S85_Off.Text = "0x" + Banks[0].samples[84].offset.ToString("x");
                this.B0_S85_Len.Text = "0x" + Banks[0].samples[84].length.ToString("x");
            }
            if (Banks[0].samples[85].enabled == true)
            {
                Banks[0].samples[85].depends.Clear();
                this.B0_S86_Dep.Text = "";
                this.B0_S86_Off.Text = "0x" + Banks[0].samples[85].offset.ToString("x");
                this.B0_S86_Len.Text = "0x" + Banks[0].samples[85].length.ToString("x");
            }
            if (Banks[0].samples[86].enabled == true)
            {
                Banks[0].samples[86].depends.Clear();
                this.B0_S87_Dep.Text = "";
                this.B0_S87_Off.Text = "0x" + Banks[0].samples[86].offset.ToString("x");
                this.B0_S87_Len.Text = "0x" + Banks[0].samples[86].length.ToString("x");
            }
            if (Banks[0].samples[87].enabled == true)
            {
                Banks[0].samples[87].depends.Clear();
                this.B0_S88_Dep.Text = "";
                this.B0_S88_Off.Text = "0x" + Banks[0].samples[87].offset.ToString("x");
                this.B0_S88_Len.Text = "0x" + Banks[0].samples[87].length.ToString("x");
            }
            if (Banks[0].samples[88].enabled == true)
            {
                Banks[0].samples[88].depends.Clear();
                this.B0_S89_Dep.Text = "";
                this.B0_S89_Off.Text = "0x" + Banks[0].samples[88].offset.ToString("x");
                this.B0_S89_Len.Text = "0x" + Banks[0].samples[88].length.ToString("x");
            }
            if (Banks[0].samples[89].enabled == true)
            {
                Banks[0].samples[89].depends.Clear();
                this.B0_S90_Dep.Text = "";
                this.B0_S90_Off.Text = "0x" + Banks[0].samples[89].offset.ToString("x");
                this.B0_S90_Len.Text = "0x" + Banks[0].samples[89].length.ToString("x");
            }
            if (Banks[0].samples[90].enabled == true)
            {
                Banks[0].samples[90].depends.Clear();
                this.B0_S91_Dep.Text = "";
                this.B0_S91_Off.Text = "0x" + Banks[0].samples[90].offset.ToString("x");
                this.B0_S91_Len.Text = "0x" + Banks[0].samples[90].length.ToString("x");
            }
            if (Banks[0].samples[91].enabled == true)
            {
                Banks[0].samples[91].depends.Clear();
                this.B0_S92_Dep.Text = "";
                this.B0_S92_Off.Text = "0x" + Banks[0].samples[91].offset.ToString("x");
                this.B0_S92_Len.Text = "0x" + Banks[0].samples[91].length.ToString("x");
            }
            if (Banks[0].samples[92].enabled == true)
            {
                Banks[0].samples[92].depends.Clear();
                this.B0_S93_Dep.Text = "";
                this.B0_S93_Off.Text = "0x" + Banks[0].samples[92].offset.ToString("x");
                this.B0_S93_Len.Text = "0x" + Banks[0].samples[92].length.ToString("x");
            }
            if (Banks[0].samples[93].enabled == true)
            {
                Banks[0].samples[93].depends.Clear();
                this.B0_S94_Dep.Text = "";
                this.B0_S94_Off.Text = "0x" + Banks[0].samples[93].offset.ToString("x");
                this.B0_S94_Len.Text = "0x" + Banks[0].samples[93].length.ToString("x");
            }
            if (Banks[0].samples[94].enabled == true)
            {
                Banks[0].samples[94].depends.Clear();
                this.B0_S95_Dep.Text = "";
                this.B0_S95_Off.Text = "0x" + Banks[0].samples[94].offset.ToString("x");
                this.B0_S95_Len.Text = "0x" + Banks[0].samples[94].length.ToString("x");
            }
            if (Banks[0].samples[95].enabled == true)
            {
                Banks[0].samples[95].depends.Clear();
                this.B0_S96_Dep.Text = "";
                this.B0_S96_Off.Text = "0x" + Banks[0].samples[95].offset.ToString("x");
                this.B0_S96_Len.Text = "0x" + Banks[0].samples[95].length.ToString("x");
            }
            if (Banks[0].samples[96].enabled == true)
            {
                Banks[0].samples[96].depends.Clear();
                this.B0_S97_Dep.Text = "";
                this.B0_S97_Off.Text = "0x" + Banks[0].samples[96].offset.ToString("x");
                this.B0_S97_Len.Text = "0x" + Banks[0].samples[96].length.ToString("x");
            }
            if (Banks[0].samples[97].enabled == true)
            {
                Banks[0].samples[97].depends.Clear();
                this.B0_S98_Dep.Text = "";
                this.B0_S98_Off.Text = "0x" + Banks[0].samples[97].offset.ToString("x");
                this.B0_S98_Len.Text = "0x" + Banks[0].samples[97].length.ToString("x");
            }
            if (Banks[0].samples[98].enabled == true)
            {
                Banks[0].samples[98].depends.Clear();
                this.B0_S99_Dep.Text = "";
                this.B0_S99_Off.Text = "0x" + Banks[0].samples[98].offset.ToString("x");
                this.B0_S99_Len.Text = "0x" + Banks[0].samples[98].length.ToString("x");
            }
            if (Banks[0].samples[99].enabled == true)
            {
                Banks[0].samples[99].depends.Clear();
                this.B0_S100_Dep.Text = "";
                this.B0_S100_Off.Text = "0x" + Banks[0].samples[99].offset.ToString("x");
                this.B0_S100_Len.Text = "0x" + Banks[0].samples[99].length.ToString("x");
            }
            if (Banks[0].samples[100].enabled == true)
            {
                Banks[0].samples[100].depends.Clear();
                this.B0_S101_Dep.Text = "";
                this.B0_S101_Off.Text = "0x" + Banks[0].samples[100].offset.ToString("x");
                this.B0_S101_Len.Text = "0x" + Banks[0].samples[100].length.ToString("x");
            }
            if (Banks[0].samples[101].enabled == true)
            {
                Banks[0].samples[101].depends.Clear();
                this.B0_S102_Dep.Text = "";
                this.B0_S102_Off.Text = "0x" + Banks[0].samples[101].offset.ToString("x");
                this.B0_S102_Len.Text = "0x" + Banks[0].samples[101].length.ToString("x");
            }
            if (Banks[0].samples[102].enabled == true)
            {
                Banks[0].samples[102].depends.Clear();
                this.B0_S103_Dep.Text = "";
                this.B0_S103_Off.Text = "0x" + Banks[0].samples[102].offset.ToString("x");
                this.B0_S103_Len.Text = "0x" + Banks[0].samples[102].length.ToString("x");
            }
            if (Banks[0].samples[103].enabled == true)
            {
                Banks[0].samples[103].depends.Clear();
                this.B0_S104_Dep.Text = "";
                this.B0_S104_Off.Text = "0x" + Banks[0].samples[103].offset.ToString("x");
                this.B0_S104_Len.Text = "0x" + Banks[0].samples[103].length.ToString("x");
            }
            if (Banks[0].samples[104].enabled == true)
            {
                Banks[0].samples[104].depends.Clear();
                this.B0_S105_Dep.Text = "";
                this.B0_S105_Off.Text = "0x" + Banks[0].samples[104].offset.ToString("x");
                this.B0_S105_Len.Text = "0x" + Banks[0].samples[104].length.ToString("x");
            }
            if (Banks[0].samples[105].enabled == true)
            {
                Banks[0].samples[105].depends.Clear();
                this.B0_S106_Dep.Text = "";
                this.B0_S106_Off.Text = "0x" + Banks[0].samples[105].offset.ToString("x");
                this.B0_S106_Len.Text = "0x" + Banks[0].samples[105].length.ToString("x");
            }
            if (Banks[0].samples[106].enabled == true)
            {
                Banks[0].samples[106].depends.Clear();
                this.B0_S107_Dep.Text = "";
                this.B0_S107_Off.Text = "0x" + Banks[0].samples[106].offset.ToString("x");
                this.B0_S107_Len.Text = "0x" + Banks[0].samples[106].length.ToString("x");
            }
            if (Banks[0].samples[107].enabled == true)
            {
                Banks[0].samples[107].depends.Clear();
                this.B0_S108_Dep.Text = "";
                this.B0_S108_Off.Text = "0x" + Banks[0].samples[107].offset.ToString("x");
                this.B0_S108_Len.Text = "0x" + Banks[0].samples[107].length.ToString("x");
            }
            if (Banks[0].samples[108].enabled == true)
            {
                Banks[0].samples[108].depends.Clear();
                this.B0_S109_Dep.Text = "";
                this.B0_S109_Off.Text = "0x" + Banks[0].samples[108].offset.ToString("x");
                this.B0_S109_Len.Text = "0x" + Banks[0].samples[108].length.ToString("x");
            }
            if (Banks[0].samples[109].enabled == true)
            {
                Banks[0].samples[109].depends.Clear();
                this.B0_S110_Dep.Text = "";
                this.B0_S110_Off.Text = "0x" + Banks[0].samples[109].offset.ToString("x");
                this.B0_S110_Len.Text = "0x" + Banks[0].samples[109].length.ToString("x");
            }
            if (Banks[0].samples[110].enabled == true)
            {
                Banks[0].samples[110].depends.Clear();
                this.B0_S111_Dep.Text = "";
                this.B0_S111_Off.Text = "0x" + Banks[0].samples[110].offset.ToString("x");
                this.B0_S111_Len.Text = "0x" + Banks[0].samples[110].length.ToString("x");
            }
            if (Banks[0].samples[111].enabled == true)
            {
                Banks[0].samples[111].depends.Clear();
                this.B0_S112_Dep.Text = "";
                this.B0_S112_Off.Text = "0x" + Banks[0].samples[111].offset.ToString("x");
                this.B0_S112_Len.Text = "0x" + Banks[0].samples[111].length.ToString("x");
            }
            if (Banks[0].samples[112].enabled == true)
            {
                Banks[0].samples[112].depends.Clear();
                this.B0_S113_Dep.Text = "";
                this.B0_S113_Off.Text = "0x" + Banks[0].samples[112].offset.ToString("x");
                this.B0_S113_Len.Text = "0x" + Banks[0].samples[112].length.ToString("x");
            }
            if (Banks[0].samples[113].enabled == true)
            {
                Banks[0].samples[113].depends.Clear();
                this.B0_S114_Dep.Text = "";
                this.B0_S114_Off.Text = "0x" + Banks[0].samples[113].offset.ToString("x");
                this.B0_S114_Len.Text = "0x" + Banks[0].samples[113].length.ToString("x");
            }
            if (Banks[0].samples[114].enabled == true)
            {
                Banks[0].samples[114].depends.Clear();
                this.B0_S115_Dep.Text = "";
                this.B0_S115_Off.Text = "0x" + Banks[0].samples[114].offset.ToString("x");
                this.B0_S115_Len.Text = "0x" + Banks[0].samples[114].length.ToString("x");
            }
            if (Banks[0].samples[115].enabled == true)
            {
                Banks[0].samples[115].depends.Clear();
                this.B0_S116_Dep.Text = "";
                this.B0_S116_Off.Text = "0x" + Banks[0].samples[115].offset.ToString("x");
                this.B0_S116_Len.Text = "0x" + Banks[0].samples[115].length.ToString("x");
            }
            if (Banks[0].samples[116].enabled == true)
            {
                Banks[0].samples[116].depends.Clear();
                this.B0_S117_Dep.Text = "";
                this.B0_S117_Off.Text = "0x" + Banks[0].samples[116].offset.ToString("x");
                this.B0_S117_Len.Text = "0x" + Banks[0].samples[116].length.ToString("x");
            }
            if (Banks[0].samples[117].enabled == true)
            {
                Banks[0].samples[117].depends.Clear();
                this.B0_S118_Dep.Text = "";
                this.B0_S118_Off.Text = "0x" + Banks[0].samples[117].offset.ToString("x");
                this.B0_S118_Len.Text = "0x" + Banks[0].samples[117].length.ToString("x");
            }
            if (Banks[0].samples[118].enabled == true)
            {
                Banks[0].samples[118].depends.Clear();
                this.B0_S119_Dep.Text = "";
                this.B0_S119_Off.Text = "0x" + Banks[0].samples[118].offset.ToString("x");
                this.B0_S119_Len.Text = "0x" + Banks[0].samples[118].length.ToString("x");
            }
            if (Banks[0].samples[119].enabled == true)
            {
                Banks[0].samples[119].depends.Clear();
                this.B0_S120_Dep.Text = "";
                this.B0_S120_Off.Text = "0x" + Banks[0].samples[119].offset.ToString("x");
                this.B0_S120_Len.Text = "0x" + Banks[0].samples[119].length.ToString("x");
            }
            if (Banks[0].samples[120].enabled == true)
            {
                Banks[0].samples[120].depends.Clear();
                this.B0_S121_Dep.Text = "";
                this.B0_S121_Off.Text = "0x" + Banks[0].samples[120].offset.ToString("x");
                this.B0_S121_Len.Text = "0x" + Banks[0].samples[120].length.ToString("x");
            }
            if (Banks[0].samples[121].enabled == true)
            {
                Banks[0].samples[121].depends.Clear();
                this.B0_S122_Dep.Text = "";
                this.B0_S122_Off.Text = "0x" + Banks[0].samples[121].offset.ToString("x");
                this.B0_S122_Len.Text = "0x" + Banks[0].samples[121].length.ToString("x");
            }
            if (Banks[0].samples[122].enabled == true)
            {
                Banks[0].samples[122].depends.Clear();
                this.B0_S123_Dep.Text = "";
                this.B0_S123_Off.Text = "0x" + Banks[0].samples[122].offset.ToString("x");
                this.B0_S123_Len.Text = "0x" + Banks[0].samples[122].length.ToString("x");
            }
            if (Banks[0].samples[123].enabled == true)
            {
                Banks[0].samples[123].depends.Clear();
                this.B0_S124_Dep.Text = "";
                this.B0_S124_Off.Text = "0x" + Banks[0].samples[123].offset.ToString("x");
                this.B0_S124_Len.Text = "0x" + Banks[0].samples[123].length.ToString("x");
            }
            if (Banks[0].samples[124].enabled == true)
            {
                Banks[0].samples[124].depends.Clear();
                this.B0_S125_Dep.Text = "";
                this.B0_S125_Off.Text = "0x" + Banks[0].samples[124].offset.ToString("x");
                this.B0_S125_Len.Text = "0x" + Banks[0].samples[124].length.ToString("x");
            }
            if (Banks[0].samples[125].enabled == true)
            {
                Banks[0].samples[125].depends.Clear();
                this.B0_S126_Dep.Text = "";
                this.B0_S126_Off.Text = "0x" + Banks[0].samples[125].offset.ToString("x");
                this.B0_S126_Len.Text = "0x" + Banks[0].samples[125].length.ToString("x");
            }
            if (Banks[0].samples[126].enabled == true)
            {
                Banks[0].samples[126].depends.Clear();
                this.B0_S127_Dep.Text = "";
                this.B0_S127_Off.Text = "0x" + Banks[0].samples[126].offset.ToString("x");
                this.B0_S127_Len.Text = "0x" + Banks[0].samples[126].length.ToString("x");
            }
        }
        private void setCtrl0()
        {
            if (Banks[0].samples[0].enabled == true)
            {
                this.B0_S1_Enable.Enabled = true;
                this.B0_S1_Enable.Checked = true;
                this.B0_S1_Export.Enabled = true;

                if (Banks[0].samples[0].common == true)
                {
                    this.B0_S1_Import.Enabled = false;
                    this.B0_S1_Common.Checked = true;
                }
                else
                {
                    this.B0_S1_Import.Enabled = true;
                    this.B0_S1_Common.Checked = false;
                }

                int start = Banks[0].samples[0].start;
                int id = Banks[0].samples[0].id;
                for (int i = 0; i < 127; i++)
                {
                    Sample smp = Banks[0].samples[i];
                    if (smp.enabled == true)
                    {
                        if (IsBetween(start, smp.start, smp.end))
                        {
                            if (Banks[0].samples[0].id > smp.id)
                            {
                                Banks[0].samples[smp.id].parents.Add(id);
                                Banks[0].samples[0].depends.Add(smp.id);
                                if (Banks[0].samples[0].depends.Count == 1)
                                {
                                    //find offset
                                    Banks[0].samples[0].offset = start - smp.start;
                                }
                            }
                        }
                    }
                }
                string deps = "";
                if (Banks[0].samples[0].common == true)
                {
                    Banks[0].samples[0].depends.Clear();
                    Banks[0].samples[0].offset = Banks[0].samples[0].start - 0x20000;
                }
                if (Banks[0].samples[0].depends.Count > 0)
                {
                    int dep = Banks[0].samples[0].depends[0];
                    {
                        deps = dep.ToString();
                    }
                }
                this.B0_S1_Dep.Text = deps;
                this.B0_S1_Off.Text = "0x" + Banks[0].samples[0].offset.ToString("x");
                this.B0_S1_Len.Text = "0x" + Banks[0].samples[0].length.ToString("x");
            }
            if (Banks[0].samples[1].enabled == true)
            {
                this.B0_S2_Enable.Enabled = true;
                this.B0_S2_Enable.Checked = true;
                this.B0_S2_Export.Enabled = true;

                if (Banks[0].samples[1].common == true)
                {
                    this.B0_S2_Import.Enabled = false;
                    this.B0_S2_Common.Checked = true;
                }
                else
                {
                    this.B0_S2_Import.Enabled = true;
                    this.B0_S2_Common.Checked = false;
                }

                int start = Banks[0].samples[1].start;
                int id = Banks[0].samples[1].id;
                for (int i = 0; i < 127; i++)
                {
                    Sample smp = Banks[0].samples[i];
                    if (smp.enabled == true)
                    {
                        if (IsBetween(start, smp.start, smp.end))
                        {
                            if (Banks[0].samples[1].id > smp.id)
                            {
                                Banks[0].samples[smp.id].parents.Add(id);
                                Banks[0].samples[1].depends.Add(smp.id);
                                if (Banks[0].samples[1].depends.Count == 1)
                                {
                                    //find offset
                                    Banks[0].samples[1].offset = start - smp.start;
                                }
                            }
                        }
                    }
                }
                string deps = "";
                if (Banks[0].samples[1].common == true)
                {
                    Banks[0].samples[1].depends.Clear();
                    Banks[0].samples[1].offset = Banks[0].samples[1].start - 0x20000;
                }
                if (Banks[0].samples[1].depends.Count > 0)
                {
                    int dep = Banks[0].samples[1].depends[0];
                    {
                        deps = dep.ToString();
                    }
                }
                this.B0_S2_Dep.Text = deps;
                this.B0_S2_Off.Text = "0x" + Banks[0].samples[1].offset.ToString("x");
                this.B0_S2_Len.Text = "0x" + Banks[0].samples[1].length.ToString("x");
            }
            if (Banks[0].samples[2].enabled == true)
            {
                this.B0_S3_Enable.Enabled = true;
                this.B0_S3_Enable.Checked = true;
                this.B0_S3_Export.Enabled = true;

                if (Banks[0].samples[2].common == true)
                {
                    this.B0_S3_Import.Enabled = false;
                    this.B0_S3_Common.Checked = true;
                }
                else
                {
                    this.B0_S3_Import.Enabled = true;
                    this.B0_S3_Common.Checked = false;
                }

                int start = Banks[0].samples[2].start;
                int id = Banks[0].samples[2].id;
                for (int i = 0; i < 127; i++)
                {
                    Sample smp = Banks[0].samples[i];
                    if (smp.enabled == true)
                    {
                        if (IsBetween(start, smp.start, smp.end))
                        {
                            if (Banks[0].samples[2].id > smp.id)
                            {
                                Banks[0].samples[smp.id].parents.Add(id);
                                Banks[0].samples[2].depends.Add(smp.id);
                                if (Banks[0].samples[2].depends.Count == 1)
                                {
                                    //find offset
                                    Banks[0].samples[2].offset = start - smp.start;
                                }
                            }
                        }
                    }
                }
                string deps = "";
                if (Banks[0].samples[2].common == true)
                {
                    Banks[0].samples[2].depends.Clear();
                    Banks[0].samples[2].offset = Banks[0].samples[2].start - 0x20000;
                }

                if (Banks[0].samples[2].depends.Count > 0)
                {
                    int dep = Banks[0].samples[2].depends[0];
                    {
                        deps = dep.ToString();
                    }

                }
                this.B0_S3_Dep.Text = deps;
                this.B0_S3_Off.Text = "0x" + Banks[0].samples[2].offset.ToString("x");
                this.B0_S3_Len.Text = "0x" + Banks[0].samples[2].length.ToString("x");
            }
            if (Banks[0].samples[3].enabled == true)
            {
                this.B0_S4_Enable.Enabled = true;
                this.B0_S4_Enable.Checked = true;
                this.B0_S4_Export.Enabled = true;

                if (Banks[0].samples[3].common == true)
                {
                    this.B0_S4_Import.Enabled = false;
                    this.B0_S4_Common.Checked = true;
                }
                else
                {
                    this.B0_S4_Import.Enabled = true;
                    this.B0_S4_Common.Checked = false;
                }

                int start = Banks[0].samples[3].start;
                int id = Banks[0].samples[3].id;
                for (int i = 0; i < 127; i++)
                {
                    Sample smp = Banks[0].samples[i];
                    if (smp.enabled == true)
                    {
                        if (IsBetween(start, smp.start, smp.end))
                        {
                            if (Banks[0].samples[3].id > smp.id)
                            {
                                Banks[0].samples[smp.id].parents.Add(id);
                                Banks[0].samples[3].depends.Add(smp.id);
                                if (Banks[0].samples[3].depends.Count == 1)
                                {
                                    //find offset
                                    Banks[0].samples[3].offset = start - smp.start;
                                }
                            }
                        }
                    }
                }
                string deps = "";
                if (Banks[0].samples[3].common == true)
                {
                    Banks[0].samples[3].depends.Clear();
                    Banks[0].samples[3].offset = Banks[0].samples[3].start - 0x20000;
                }
                if (Banks[0].samples[3].depends.Count > 0)
                {
                    int dep = Banks[0].samples[3].depends[0];
                    {
                        deps = dep.ToString();
                    }

                }
                this.B0_S4_Dep.Text = deps;
                this.B0_S4_Off.Text = "0x" + Banks[0].samples[3].offset.ToString("x");
                this.B0_S4_Len.Text = "0x" + Banks[0].samples[3].length.ToString("x");
            }
            if (Banks[0].samples[4].enabled == true)
            {
                this.B0_S5_Enable.Enabled = true;
                this.B0_S5_Enable.Checked = true;
                this.B0_S5_Export.Enabled = true;

                if (Banks[0].samples[4].common == true)
                {
                    this.B0_S5_Import.Enabled = false;
                    this.B0_S5_Common.Checked = true;
                }
                else
                {
                    this.B0_S5_Import.Enabled = true;
                    this.B0_S5_Common.Checked = false;
                }
                int start = Banks[0].samples[4].start;
                int id = Banks[0].samples[4].id;
                for (int i = 0; i < 127; i++)
                {
                    Sample smp = Banks[0].samples[i];
                    if (smp.enabled == true)
                    {
                        if (IsBetween(start, smp.start, smp.end))
                        {
                            if (Banks[0].samples[4].id > smp.id)
                            {
                                Banks[0].samples[smp.id].parents.Add(id);
                                Banks[0].samples[4].depends.Add(smp.id);
                                if (Banks[0].samples[4].depends.Count == 1)
                                {
                                    //find offset
                                    Banks[0].samples[4].offset = start - smp.start;
                                }
                            }
                        }
                    }
                }
                string deps = "";
                if (Banks[0].samples[4].common == true)
                {
                    Banks[0].samples[4].depends.Clear();
                    Banks[0].samples[4].offset = Banks[0].samples[4].start - 0x20000;
                }
                if (Banks[0].samples[4].depends.Count > 0)
                {
                    int dep = Banks[0].samples[4].depends[0];
                    {
                        deps = dep.ToString();
                    }

                }
                this.B0_S5_Dep.Text = deps;
                this.B0_S5_Off.Text = "0x" + Banks[0].samples[4].offset.ToString("x");
                this.B0_S5_Len.Text = "0x" + Banks[0].samples[4].length.ToString("x");
            }
            if (Banks[0].samples[5].enabled == true)
            {
                this.B0_S6_Enable.Enabled = true;
                this.B0_S6_Enable.Checked = true;
                this.B0_S6_Export.Enabled = true;

                if (Banks[0].samples[5].common == true)
                {
                    this.B0_S6_Import.Enabled = false;
                    this.B0_S6_Common.Checked = true;
                }
                else
                {
                    this.B0_S6_Import.Enabled = true;
                    this.B0_S6_Common.Checked = false;
                }

                int start = Banks[0].samples[5].start;
                int id = Banks[0].samples[5].id;
                for (int i = 0; i < 127; i++)
                {
                    Sample smp = Banks[0].samples[i];
                    if (smp.enabled == true)
                    {
                        if (IsBetween(start, smp.start, smp.end))
                        {
                            if (Banks[0].samples[5].id > smp.id)
                            {
                                Banks[0].samples[smp.id].parents.Add(id);
                                Banks[0].samples[5].depends.Add(smp.id);
                                if (Banks[0].samples[5].depends.Count == 1)
                                {
                                    //find offset
                                    Banks[0].samples[5].offset = start - smp.start;
                                }
                            }
                        }
                    }
                }
                string deps = "";
                if (Banks[0].samples[5].common == true)
                {
                    Banks[0].samples[5].depends.Clear();
                    Banks[0].samples[5].offset = Banks[0].samples[5].start - 0x20000;
                }
                if (Banks[0].samples[5].depends.Count > 0)
                {
                    int dep = Banks[0].samples[5].depends[0];
                    {
                        deps = dep.ToString();
                    }

                }
                this.B0_S6_Dep.Text = deps;
                this.B0_S6_Off.Text = "0x" + Banks[0].samples[5].offset.ToString("x");
                this.B0_S6_Len.Text = "0x" + Banks[0].samples[5].length.ToString("x");
            }
            if (Banks[0].samples[6].enabled == true)
            {
                this.B0_S7_Enable.Enabled = true;
                this.B0_S7_Enable.Checked = true;
                this.B0_S7_Export.Enabled = true;

                if (Banks[0].samples[6].common == true)
                {
                    this.B0_S7_Import.Enabled = false;
                    this.B0_S7_Common.Checked = true;
                }
                else
                {
                    this.B0_S7_Import.Enabled = true;
                    this.B0_S7_Common.Checked = false;
                }

                int start = Banks[0].samples[6].start;
                int id = Banks[0].samples[6].id;
                for (int i = 0; i < 127; i++)
                {
                    Sample smp = Banks[0].samples[i];
                    if (smp.enabled == true)
                    {
                        if (IsBetween(start, smp.start, smp.end))
                        {
                            if (Banks[0].samples[6].id > smp.id)
                            {
                                Banks[0].samples[smp.id].parents.Add(id);
                                Banks[0].samples[6].depends.Add(smp.id);
                                if (Banks[0].samples[6].depends.Count == 1)
                                {
                                    //find offset
                                    Banks[0].samples[6].offset = start - smp.start;
                                }
                            }
                        }
                    }
                }
                string deps = "";
                if (Banks[0].samples[6].common == true)
                {
                    Banks[0].samples[6].depends.Clear();
                    Banks[0].samples[6].offset = Banks[0].samples[6].start - 0x20000;
                }
                if (Banks[0].samples[6].depends.Count > 0)
                {
                    int dep = Banks[0].samples[6].depends[0];
                    {
                        deps = dep.ToString();
                    }

                }
                this.B0_S7_Dep.Text = deps;
                this.B0_S7_Off.Text = "0x" + Banks[0].samples[6].offset.ToString("x");
                this.B0_S7_Len.Text = "0x" + Banks[0].samples[6].length.ToString("x");
            }
            if (Banks[0].samples[7].enabled == true)
            {
                this.B0_S8_Enable.Enabled = true;
                this.B0_S8_Enable.Checked = true;
                this.B0_S8_Export.Enabled = true;

                if (Banks[0].samples[7].common == true)
                {
                    this.B0_S8_Import.Enabled = false;
                    this.B0_S8_Common.Checked = true;
                }
                else
                {
                    this.B0_S8_Import.Enabled = true;
                    this.B0_S8_Common.Checked = false;
                }

                int start = Banks[0].samples[7].start;
                int id = Banks[0].samples[7].id;
                for (int i = 0; i < 127; i++)
                {
                    Sample smp = Banks[0].samples[i];
                    if (smp.enabled == true)
                    {
                        if (IsBetween(start, smp.start, smp.end))
                        {
                            if (Banks[0].samples[7].id > smp.id)
                            {
                                Banks[0].samples[smp.id].parents.Add(id);
                                Banks[0].samples[7].depends.Add(smp.id);
                                if (Banks[0].samples[7].depends.Count == 1)
                                {
                                    //find offset
                                    Banks[0].samples[7].offset = start - smp.start;
                                }
                            }
                        }
                    }
                }
                string deps = "";
                if (Banks[0].samples[7].common == true)
                {
                    Banks[0].samples[7].depends.Clear();
                    Banks[0].samples[7].offset = Banks[0].samples[7].start - 0x20000;
                }
                if (Banks[0].samples[7].depends.Count > 0)
                {
                    int dep = Banks[0].samples[7].depends[0];
                    {
                        deps = dep.ToString();
                    }

                }
                this.B0_S8_Dep.Text = deps;
                this.B0_S8_Off.Text = "0x" + Banks[0].samples[7].offset.ToString("x");
                this.B0_S8_Len.Text = "0x" + Banks[0].samples[7].length.ToString("x");
            }
            if (Banks[0].samples[8].enabled == true)
            {
                this.B0_S9_Enable.Enabled = true;
                this.B0_S9_Enable.Checked = true;
                this.B0_S9_Export.Enabled = true;

                if (Banks[0].samples[8].common == true)
                {
                    this.B0_S9_Import.Enabled = false;
                    this.B0_S9_Common.Checked = true;
                }
                else
                {
                    this.B0_S9_Import.Enabled = true;
                    this.B0_S9_Common.Checked = false;
                }

                int start = Banks[0].samples[8].start;
                int id = Banks[0].samples[8].id;
                for (int i = 0; i < 127; i++)
                {
                    Sample smp = Banks[0].samples[i];
                    if (smp.enabled == true)
                    {
                        if (IsBetween(start, smp.start, smp.end))
                        {
                            if (Banks[0].samples[8].id > smp.id)
                            {
                                Banks[0].samples[smp.id].parents.Add(id);
                                Banks[0].samples[8].depends.Add(smp.id);
                                if (Banks[0].samples[8].depends.Count == 1)
                                {
                                    //find offset
                                    Banks[0].samples[8].offset = start - smp.start;
                                }
                            }
                        }
                    }
                }
                string deps = "";
                if (Banks[0].samples[8].common == true)
                {
                    Banks[0].samples[8].depends.Clear();
                    Banks[0].samples[8].offset = Banks[0].samples[8].start - 0x20000;
                }
                if (Banks[0].samples[8].depends.Count > 0)
                {
                    int dep = Banks[0].samples[8].depends[0];
                    {
                        deps = dep.ToString();
                    }

                }
                this.B0_S9_Dep.Text = deps;
                this.B0_S9_Off.Text = "0x" + Banks[0].samples[8].offset.ToString("x");
                this.B0_S9_Len.Text = "0x" + Banks[0].samples[8].length.ToString("x");
            }
            if (Banks[0].samples[9].enabled == true)
            {
                this.B0_S10_Enable.Enabled = true;
                this.B0_S10_Enable.Checked = true;
                this.B0_S10_Export.Enabled = true;

                if (Banks[0].samples[9].common == true)
                {
                    this.B0_S10_Import.Enabled = false;
                    this.B0_S10_Common.Checked = true;
                }
                else
                {
                    this.B0_S10_Import.Enabled = true;
                    this.B0_S10_Common.Checked = false;
                }

                int start = Banks[0].samples[9].start;
                int id = Banks[0].samples[9].id;
                for (int i = 0; i < 127; i++)
                {
                    Sample smp = Banks[0].samples[i];
                    if (smp.enabled == true)
                    {
                        if (IsBetween(start, smp.start, smp.end))
                        {
                            if (Banks[0].samples[9].id > smp.id)
                            {
                                Banks[0].samples[smp.id].parents.Add(id);
                                Banks[0].samples[9].depends.Add(smp.id);
                                if (Banks[0].samples[9].depends.Count == 1)
                                {
                                    //find offset
                                    Banks[0].samples[9].offset = start - smp.start;
                                }
                            }
                        }
                    }
                }
                string deps = "";
                if (Banks[0].samples[9].common == true)
                {
                    Banks[0].samples[9].depends.Clear();
                    Banks[0].samples[9].offset = Banks[0].samples[9].start - 0x20000;
                }
                if (Banks[0].samples[9].depends.Count > 0)
                {
                    int dep = Banks[0].samples[9].depends[0];
                    {
                        deps = dep.ToString();
                    }

                }
                this.B0_S10_Dep.Text = deps;
                this.B0_S10_Off.Text = "0x" + Banks[0].samples[9].offset.ToString("x");
                this.B0_S10_Len.Text = "0x" + Banks[0].samples[9].length.ToString("x");
            }
            if (Banks[0].samples[10].enabled == true)
            {
                this.B0_S11_Enable.Enabled = true;
                this.B0_S11_Enable.Checked = true;
                this.B0_S11_Export.Enabled = true;

                if (Banks[0].samples[10].common == true)
                {
                    this.B0_S11_Import.Enabled = false;
                    this.B0_S11_Common.Checked = true;
                }
                else
                {
                    this.B0_S11_Import.Enabled = true;
                    this.B0_S11_Common.Checked = false;
                }

                int start = Banks[0].samples[10].start;
                int id = Banks[0].samples[10].id;
                for (int i = 0; i < 127; i++)
                {
                    Sample smp = Banks[0].samples[i];
                    if (smp.enabled == true)
                    {
                        if (IsBetween(start, smp.start, smp.end))
                        {
                            if (Banks[0].samples[10].id > smp.id)
                            {
                                Banks[0].samples[smp.id].parents.Add(id);
                                Banks[0].samples[10].depends.Add(smp.id);
                                if (Banks[0].samples[10].depends.Count == 1)
                                {
                                    //find offset
                                    Banks[0].samples[10].offset = start - smp.start;
                                }
                            }
                        }
                    }
                }
                string deps = "";
                if (Banks[0].samples[10].common == true)
                {
                    Banks[0].samples[10].depends.Clear();
                    Banks[0].samples[10].offset = Banks[0].samples[10].start - 0x20000;
                }
                if (Banks[0].samples[10].depends.Count > 0)
                {
                    int dep = Banks[0].samples[10].depends[0];
                    {
                        deps = dep.ToString();
                    }
                }
                this.B0_S11_Dep.Text = deps;
                this.B0_S11_Off.Text = "0x" + Banks[0].samples[10].offset.ToString("x");
                this.B0_S11_Len.Text = "0x" + Banks[0].samples[10].length.ToString("x");
            }
            if (Banks[0].samples[11].enabled == true)
            {
                this.B0_S12_Enable.Enabled = true;
                this.B0_S12_Enable.Checked = true;
                this.B0_S12_Export.Enabled = true;

                if (Banks[0].samples[11].common == true)
                {
                    this.B0_S12_Import.Enabled = false;
                    this.B0_S12_Common.Checked = true;
                }
                else
                {
                    this.B0_S12_Import.Enabled = true;
                    this.B0_S12_Common.Checked = false;
                }

                int start = Banks[0].samples[11].start;
                int id = Banks[0].samples[11].id;
                for (int i = 0; i < 127; i++)
                {
                    Sample smp = Banks[0].samples[i];
                    if (smp.enabled == true)
                    {
                        if (IsBetween(start, smp.start, smp.end))
                        {
                            if (Banks[0].samples[11].id > smp.id)
                            {
                                Banks[0].samples[smp.id].parents.Add(id);
                                Banks[0].samples[11].depends.Add(smp.id);
                                if (Banks[0].samples[11].depends.Count == 1)
                                {
                                    //find offset
                                    Banks[0].samples[11].offset = start - smp.start;
                                }
                            }
                        }
                    }
                }
                string deps = "";
                if (Banks[0].samples[11].common == true)
                {
                    Banks[0].samples[11].depends.Clear();
                    Banks[0].samples[11].offset = Banks[0].samples[11].start - 0x20000;
                }
                if (Banks[0].samples[11].depends.Count > 0)
                {
                    int dep = Banks[0].samples[11].depends[0];
                    {
                        deps = dep.ToString();
                    }
                }
                this.B0_S12_Dep.Text = deps;
                this.B0_S12_Off.Text = "0x" + Banks[0].samples[11].offset.ToString("x");
                this.B0_S12_Len.Text = "0x" + Banks[0].samples[11].length.ToString("x");
            }
            if (Banks[0].samples[12].enabled == true)
            {
                this.B0_S13_Enable.Enabled = true;
                this.B0_S13_Enable.Checked = true;
                this.B0_S13_Export.Enabled = true;

                if (Banks[0].samples[12].common == true)
                {
                    this.B0_S13_Import.Enabled = false;
                    this.B0_S13_Common.Checked = true;
                }
                else
                {
                    this.B0_S13_Import.Enabled = true;
                    this.B0_S13_Common.Checked = false;
                }

                int start = Banks[0].samples[12].start;
                int id = Banks[0].samples[12].id;
                for (int i = 0; i < 127; i++)
                {
                    Sample smp = Banks[0].samples[i];
                    if (smp.enabled == true)
                    {
                        if (IsBetween(start, smp.start, smp.end))
                        {
                            if (Banks[0].samples[12].id > smp.id)
                            {
                                Banks[0].samples[smp.id].parents.Add(id);
                                Banks[0].samples[12].depends.Add(smp.id);
                                if (Banks[0].samples[12].depends.Count == 1)
                                {
                                    //find offset
                                    Banks[0].samples[12].offset = start - smp.start;
                                }
                            }
                        }
                    }
                }
                string deps = "";
                if (Banks[0].samples[12].common == true)
                {
                    Banks[0].samples[12].depends.Clear();
                    Banks[0].samples[12].offset = Banks[0].samples[12].start - 0x20000;
                }

                if (Banks[0].samples[12].depends.Count > 0)
                {
                    int dep = Banks[0].samples[12].depends[0];
                    {
                        deps = dep.ToString();
                    }

                }
                this.B0_S13_Dep.Text = deps;
                this.B0_S13_Off.Text = "0x" + Banks[0].samples[12].offset.ToString("x");
                this.B0_S13_Len.Text = "0x" + Banks[0].samples[12].length.ToString("x");
            }
            if (Banks[0].samples[13].enabled == true)
            {
                this.B0_S14_Enable.Enabled = true;
                this.B0_S14_Enable.Checked = true;
                this.B0_S14_Export.Enabled = true;

                if (Banks[0].samples[13].common == true)
                {
                    this.B0_S14_Import.Enabled = false;
                    this.B0_S14_Common.Checked = true;
                }
                else
                {
                    this.B0_S14_Import.Enabled = true;
                    this.B0_S14_Common.Checked = false;
                }

                int start = Banks[0].samples[13].start;
                int id = Banks[0].samples[13].id;
                for (int i = 0; i < 127; i++)
                {
                    Sample smp = Banks[0].samples[i];
                    if (smp.enabled == true)
                    {
                        if (IsBetween(start, smp.start, smp.end))
                        {
                            if (Banks[0].samples[13].id > smp.id)
                            {
                                Banks[0].samples[smp.id].parents.Add(id);
                                Banks[0].samples[13].depends.Add(smp.id);
                                if (Banks[0].samples[13].depends.Count == 1)
                                {
                                    //find offset
                                    Banks[0].samples[13].offset = start - smp.start;
                                }
                            }
                        }
                    }
                }
                string deps = "";
                if (Banks[0].samples[13].common == true)
                {
                    Banks[0].samples[13].depends.Clear();
                    Banks[0].samples[13].offset = Banks[0].samples[13].start - 0x20000;
                }
                if (Banks[0].samples[13].depends.Count > 0)
                {
                    int dep = Banks[0].samples[13].depends[0];
                    {
                        deps = dep.ToString();
                    }

                }
                this.B0_S14_Dep.Text = deps;
                this.B0_S14_Off.Text = "0x" + Banks[0].samples[13].offset.ToString("x");
                this.B0_S14_Len.Text = "0x" + Banks[0].samples[13].length.ToString("x");
            }
            if (Banks[0].samples[14].enabled == true)
            {
                this.B0_S15_Enable.Enabled = true;
                this.B0_S15_Enable.Checked = true;
                this.B0_S15_Export.Enabled = true;

                if (Banks[0].samples[14].common == true)
                {
                    this.B0_S15_Import.Enabled = false;
                    this.B0_S15_Common.Checked = true;
                }
                else
                {
                    this.B0_S15_Import.Enabled = true;
                    this.B0_S15_Common.Checked = false;
                }

                int start = Banks[0].samples[14].start;
                int id = Banks[0].samples[14].id;
                for (int i = 0; i < 127; i++)
                {
                    Sample smp = Banks[0].samples[i];
                    if (smp.enabled == true)
                    {
                        if (IsBetween(start, smp.start, smp.end))
                        {
                            if (Banks[0].samples[14].id > smp.id)
                            {
                                Banks[0].samples[smp.id].parents.Add(id);
                                Banks[0].samples[14].depends.Add(smp.id);
                                if (Banks[0].samples[14].depends.Count == 1)
                                {
                                    //find offset
                                    Banks[0].samples[14].offset = start - smp.start;
                                }
                            }
                        }
                    }
                }
                string deps = "";
                if (Banks[0].samples[14].common == true)
                {
                    Banks[0].samples[14].depends.Clear();
                    Banks[0].samples[14].offset = Banks[0].samples[14].start - 0x20000;
                }
                if (Banks[0].samples[14].depends.Count > 0)
                {
                    int dep = Banks[0].samples[14].depends[0];
                    {
                        deps = dep.ToString();
                    }

                }
                this.B0_S15_Dep.Text = deps;
                this.B0_S15_Off.Text = "0x" + Banks[0].samples[14].offset.ToString("x");
                this.B0_S15_Len.Text = "0x" + Banks[0].samples[14].length.ToString("x");
            }
            if (Banks[0].samples[15].enabled == true)
            {
                this.B0_S16_Enable.Enabled = true;
                this.B0_S16_Enable.Checked = true;
                this.B0_S16_Export.Enabled = true;

                if (Banks[0].samples[15].common == true)
                {
                    this.B0_S16_Import.Enabled = false;
                    this.B0_S16_Common.Checked = true;
                }
                else
                {
                    this.B0_S16_Import.Enabled = true;
                    this.B0_S16_Common.Checked = false;
                }

                int start = Banks[0].samples[15].start;
                int id = Banks[0].samples[15].id;
                for (int i = 0; i < 127; i++)
                {
                    Sample smp = Banks[0].samples[i];
                    if (smp.enabled == true)
                    {
                        if (IsBetween(start, smp.start, smp.end))
                        {
                            if (Banks[0].samples[15].id > smp.id)
                            {
                                Banks[0].samples[smp.id].parents.Add(id);
                                Banks[0].samples[15].depends.Add(smp.id);
                                if (Banks[0].samples[15].depends.Count == 1)
                                {
                                    //find offset
                                    Banks[0].samples[15].offset = start - smp.start;
                                }
                            }
                        }
                    }
                }
                string deps = "";
                if (Banks[0].samples[15].common == true)
                {
                    Banks[0].samples[15].depends.Clear();
                    Banks[0].samples[15].offset = Banks[0].samples[15].start - 0x20000;
                }
                if (Banks[0].samples[15].depends.Count > 0)
                {
                    int dep = Banks[0].samples[15].depends[0];
                    {
                        deps = dep.ToString();
                    }

                }
                this.B0_S16_Dep.Text = deps;
                this.B0_S16_Off.Text = "0x" + Banks[0].samples[15].offset.ToString("x");
                this.B0_S16_Len.Text = "0x" + Banks[0].samples[15].length.ToString("x");
            }
            if (Banks[0].samples[16].enabled == true)
            {
                this.B0_S17_Enable.Enabled = true;
                this.B0_S17_Enable.Checked = true;
                this.B0_S17_Export.Enabled = true;

                if (Banks[0].samples[16].common == true)
                {
                    this.B0_S17_Import.Enabled = false;
                    this.B0_S17_Common.Checked = true;
                }
                else
                {
                    this.B0_S17_Import.Enabled = true;
                    this.B0_S17_Common.Checked = false;
                }

                int start = Banks[0].samples[16].start;
                int id = Banks[0].samples[16].id;
                for (int i = 0; i < 127; i++)
                {
                    Sample smp = Banks[0].samples[i];
                    if (smp.enabled == true)
                    {
                        if (IsBetween(start, smp.start, smp.end))
                        {
                            if (Banks[0].samples[16].id > smp.id)
                            {
                                Banks[0].samples[smp.id].parents.Add(id);
                                Banks[0].samples[16].depends.Add(smp.id);
                                if (Banks[0].samples[16].depends.Count == 1)
                                {
                                    //find offset
                                    Banks[0].samples[16].offset = start - smp.start;
                                }
                            }
                        }
                    }
                }
                string deps = "";
                if (Banks[0].samples[16].common == true)
                {
                    Banks[0].samples[16].depends.Clear();
                    Banks[0].samples[16].offset = Banks[0].samples[16].start - 0x20000;
                }
                if (Banks[0].samples[16].depends.Count > 0)
                {
                    int dep = Banks[0].samples[16].depends[0];
                    {
                        deps = dep.ToString();
                    }

                }
                this.B0_S17_Dep.Text = deps;
                this.B0_S17_Off.Text = "0x" + Banks[0].samples[16].offset.ToString("x");
                this.B0_S17_Len.Text = "0x" + Banks[0].samples[16].length.ToString("x");
            }
            if (Banks[0].samples[17].enabled == true)
            {
                this.B0_S18_Enable.Enabled = true;
                this.B0_S18_Enable.Checked = true;
                this.B0_S18_Export.Enabled = true;

                if (Banks[0].samples[17].common == true)
                {
                    this.B0_S18_Import.Enabled = false;
                    this.B0_S18_Common.Checked = true;
                }
                else
                {
                    this.B0_S18_Import.Enabled = true;
                    this.B0_S18_Common.Checked = false;
                }

                int start = Banks[0].samples[17].start;
                int id = Banks[0].samples[17].id;
                for (int i = 0; i < 127; i++)
                {
                    Sample smp = Banks[0].samples[i];
                    if (smp.enabled == true)
                    {
                        if (IsBetween(start, smp.start, smp.end))
                        {
                            if (Banks[0].samples[17].id > smp.id)
                            {
                                Banks[0].samples[smp.id].parents.Add(id);
                                Banks[0].samples[17].depends.Add(smp.id);
                                if (Banks[0].samples[17].depends.Count == 1)
                                {
                                    //find offset
                                    Banks[0].samples[17].offset = start - smp.start;
                                }
                            }
                        }
                    }
                }
                string deps = "";
                if (Banks[0].samples[17].common == true)
                {
                    Banks[0].samples[17].depends.Clear();
                    Banks[0].samples[17].offset = Banks[0].samples[17].start - 0x20000;
                }
                if (Banks[0].samples[17].depends.Count > 0)
                {
                    int dep = Banks[0].samples[17].depends[0];
                    {
                        deps = dep.ToString();
                    }

                }
                this.B0_S18_Dep.Text = deps;
                this.B0_S18_Off.Text = "0x" + Banks[0].samples[17].offset.ToString("x");
                this.B0_S18_Len.Text = "0x" + Banks[0].samples[17].length.ToString("x");
            }
            if (Banks[0].samples[18].enabled == true)
            {
                this.B0_S19_Enable.Enabled = true;
                this.B0_S19_Enable.Checked = true;
                this.B0_S19_Export.Enabled = true;

                if (Banks[0].samples[18].common == true)
                {
                    this.B0_S19_Import.Enabled = false;
                    this.B0_S19_Common.Checked = true;
                }
                else
                {
                    this.B0_S19_Import.Enabled = true;
                    this.B0_S19_Common.Checked = false;
                }

                int start = Banks[0].samples[18].start;
                int id = Banks[0].samples[18].id;
                for (int i = 0; i < 127; i++)
                {
                    Sample smp = Banks[0].samples[i];
                    if (smp.enabled == true)
                    {
                        if (IsBetween(start, smp.start, smp.end))
                        {
                            if (Banks[0].samples[18].id > smp.id)
                            {
                                Banks[0].samples[smp.id].parents.Add(id);
                                Banks[0].samples[18].depends.Add(smp.id);
                                if (Banks[0].samples[18].depends.Count == 1)
                                {
                                    //find offset
                                    Banks[0].samples[18].offset = start - smp.start;
                                }
                            }
                        }
                    }
                }
                string deps = "";
                if (Banks[0].samples[18].common == true)
                {
                    Banks[0].samples[18].depends.Clear();
                    Banks[0].samples[18].offset = Banks[0].samples[18].start - 0x20000;
                }
                if (Banks[0].samples[18].depends.Count > 0)
                {
                    int dep = Banks[0].samples[18].depends[0];
                    {
                        deps = dep.ToString();
                    }

                }
                this.B0_S19_Dep.Text = deps;
                this.B0_S19_Off.Text = "0x" + Banks[0].samples[18].offset.ToString("x");
                this.B0_S19_Len.Text = "0x" + Banks[0].samples[18].length.ToString("x");
            }
            if (Banks[0].samples[19].enabled == true)
            {
                this.B0_S20_Enable.Enabled = true;
                this.B0_S20_Enable.Checked = true;
                this.B0_S20_Export.Enabled = true;

                if (Banks[0].samples[19].common == true)
                {
                    this.B0_S20_Import.Enabled = false;
                    this.B0_S20_Common.Checked = true;
                }
                else
                {
                    this.B0_S20_Import.Enabled = true;
                    this.B0_S20_Common.Checked = false;
                }

                int start = Banks[0].samples[19].start;
                int id = Banks[0].samples[19].id;
                for (int i = 0; i < 127; i++)
                {
                    Sample smp = Banks[0].samples[i];
                    if (smp.enabled == true)
                    {
                        if (IsBetween(start, smp.start, smp.end))
                        {
                            if (Banks[0].samples[19].id > smp.id)
                            {
                                Banks[0].samples[smp.id].parents.Add(id);
                                Banks[0].samples[19].depends.Add(smp.id);
                                if (Banks[0].samples[19].depends.Count == 1)
                                {
                                    //find offset
                                    Banks[0].samples[19].offset = start - smp.start;
                                }
                            }
                        }
                    }
                }
                string deps = "";
                if (Banks[0].samples[19].common == true)
                {
                    Banks[0].samples[19].depends.Clear();
                    Banks[0].samples[19].offset = Banks[0].samples[19].start - 0x20000;
                }
                if (Banks[0].samples[19].depends.Count > 0)
                {
                    int dep = Banks[0].samples[19].depends[0];
                    {
                        deps = dep.ToString();
                    }

                }
                this.B0_S20_Dep.Text = deps;
                this.B0_S20_Off.Text = "0x" + Banks[0].samples[19].offset.ToString("x");
                this.B0_S20_Len.Text = "0x" + Banks[0].samples[19].length.ToString("x");
            }
            if (Banks[0].samples[20].enabled == true)
            {
                this.B0_S21_Enable.Enabled = true;
                this.B0_S21_Enable.Checked = true;
                this.B0_S21_Export.Enabled = true;

                if (Banks[0].samples[20].common == true)
                {
                    this.B0_S21_Import.Enabled = false;
                    this.B0_S21_Common.Checked = true;
                }
                else
                {
                    this.B0_S21_Import.Enabled = true;
                    this.B0_S21_Common.Checked = false;
                }

                int start = Banks[0].samples[20].start;
                int id = Banks[0].samples[20].id;
                for (int i = 0; i < 127; i++)
                {
                    Sample smp = Banks[0].samples[i];
                    if (smp.enabled == true)
                    {
                        if (IsBetween(start, smp.start, smp.end))
                        {
                            if (Banks[0].samples[20].id > smp.id)
                            {
                                Banks[0].samples[smp.id].parents.Add(id);
                                Banks[0].samples[20].depends.Add(smp.id);
                                if (Banks[0].samples[20].depends.Count == 1)
                                {
                                    //find offset
                                    Banks[0].samples[20].offset = start - smp.start;
                                }
                            }
                        }
                    }
                }
                string deps = "";
                if (Banks[0].samples[20].common == true)
                {
                    Banks[0].samples[20].depends.Clear();
                    Banks[0].samples[20].offset = Banks[0].samples[20].start - 0x20000;
                }
                if (Banks[0].samples[20].depends.Count > 0)
                {
                    int dep = Banks[0].samples[20].depends[0];
                    {
                        deps = dep.ToString();
                    }
                }
                this.B0_S21_Dep.Text = deps;
                this.B0_S21_Off.Text = "0x" + Banks[0].samples[20].offset.ToString("x");
                this.B0_S21_Len.Text = "0x" + Banks[0].samples[20].length.ToString("x");
            }
            if (Banks[0].samples[21].enabled == true)
            {
                this.B0_S22_Enable.Enabled = true;
                this.B0_S22_Enable.Checked = true;
                this.B0_S22_Export.Enabled = true;

                if (Banks[0].samples[21].common == true)
                {
                    this.B0_S22_Import.Enabled = false;
                    this.B0_S22_Common.Checked = true;
                }
                else
                {
                    this.B0_S22_Import.Enabled = true;
                    this.B0_S22_Common.Checked = false;
                }

                int start = Banks[0].samples[21].start;
                int id = Banks[0].samples[21].id;
                for (int i = 0; i < 127; i++)
                {
                    Sample smp = Banks[0].samples[i];
                    if (smp.enabled == true)
                    {
                        if (IsBetween(start, smp.start, smp.end))
                        {
                            if (Banks[0].samples[21].id > smp.id)
                            {
                                Banks[0].samples[smp.id].parents.Add(id);
                                Banks[0].samples[21].depends.Add(smp.id);
                                if (Banks[0].samples[21].depends.Count == 1)
                                {
                                    //find offset
                                    Banks[0].samples[21].offset = start - smp.start;
                                }
                            }
                        }
                    }
                }
                string deps = "";
                if (Banks[0].samples[21].common == true)
                {
                    Banks[0].samples[21].depends.Clear();
                    Banks[0].samples[21].offset = Banks[0].samples[21].start - 0x20000;
                }
                if (Banks[0].samples[21].depends.Count > 0)
                {
                    int dep = Banks[0].samples[21].depends[0];
                    {
                        deps = dep.ToString();
                    }
                }
                this.B0_S22_Dep.Text = deps;
                this.B0_S22_Off.Text = "0x" + Banks[0].samples[21].offset.ToString("x");
                this.B0_S22_Len.Text = "0x" + Banks[0].samples[21].length.ToString("x");
            }
            if (Banks[0].samples[22].enabled == true)
            {
                this.B0_S23_Enable.Enabled = true;
                this.B0_S23_Enable.Checked = true;
                this.B0_S23_Export.Enabled = true;

                if (Banks[0].samples[22].common == true)
                {
                    this.B0_S23_Import.Enabled = false;
                    this.B0_S23_Common.Checked = true;
                }
                else
                {
                    this.B0_S23_Import.Enabled = true;
                    this.B0_S23_Common.Checked = false;
                }

                int start = Banks[0].samples[22].start;
                int id = Banks[0].samples[22].id;
                for (int i = 0; i < 127; i++)
                {
                    Sample smp = Banks[0].samples[i];
                    if (smp.enabled == true)
                    {
                        if (IsBetween(start, smp.start, smp.end))
                        {
                            if (Banks[0].samples[22].id > smp.id)
                            {
                                Banks[0].samples[smp.id].parents.Add(id);
                                Banks[0].samples[22].depends.Add(smp.id);
                                if (Banks[0].samples[22].depends.Count == 1)
                                {
                                    //find offset
                                    Banks[0].samples[22].offset = start - smp.start;
                                }
                            }
                        }
                    }
                }
                string deps = "";
                if (Banks[0].samples[22].common == true)
                {
                    Banks[0].samples[22].depends.Clear();
                    Banks[0].samples[22].offset = Banks[0].samples[22].start - 0x20000;
                }

                if (Banks[0].samples[22].depends.Count > 0)
                {
                    int dep = Banks[0].samples[22].depends[0];
                    {
                        deps = dep.ToString();
                    }

                }
                this.B0_S23_Dep.Text = deps;
                this.B0_S23_Off.Text = "0x" + Banks[0].samples[22].offset.ToString("x");
                this.B0_S23_Len.Text = "0x" + Banks[0].samples[22].length.ToString("x");
            }
            if (Banks[0].samples[23].enabled == true)
            {
                this.B0_S24_Enable.Enabled = true;
                this.B0_S24_Enable.Checked = true;
                this.B0_S24_Export.Enabled = true;

                if (Banks[0].samples[23].common == true)
                {
                    this.B0_S24_Import.Enabled = false;
                    this.B0_S24_Common.Checked = true;
                }
                else
                {
                    this.B0_S24_Import.Enabled = true;
                    this.B0_S24_Common.Checked = false;
                }

                int start = Banks[0].samples[23].start;
                int id = Banks[0].samples[23].id;
                for (int i = 0; i < 127; i++)
                {
                    Sample smp = Banks[0].samples[i];
                    if (smp.enabled == true)
                    {
                        if (IsBetween(start, smp.start, smp.end))
                        {
                            if (Banks[0].samples[23].id > smp.id)
                            {
                                Banks[0].samples[smp.id].parents.Add(id);
                                Banks[0].samples[23].depends.Add(smp.id);
                                if (Banks[0].samples[23].depends.Count == 1)
                                {
                                    //find offset
                                    Banks[0].samples[23].offset = start - smp.start;
                                }
                            }
                        }
                    }
                }
                string deps = "";
                if (Banks[0].samples[23].common == true)
                {
                    Banks[0].samples[23].depends.Clear();
                    Banks[0].samples[23].offset = Banks[0].samples[23].start - 0x20000;
                }
                if (Banks[0].samples[23].depends.Count > 0)
                {
                    int dep = Banks[0].samples[23].depends[0];
                    {
                        deps = dep.ToString();
                    }

                }
                this.B0_S24_Dep.Text = deps;
                this.B0_S24_Off.Text = "0x" + Banks[0].samples[23].offset.ToString("x");
                this.B0_S24_Len.Text = "0x" + Banks[0].samples[23].length.ToString("x");
            }
            if (Banks[0].samples[24].enabled == true)
            {
                this.B0_S25_Enable.Enabled = true;
                this.B0_S25_Enable.Checked = true;
                this.B0_S25_Export.Enabled = true;

                if (Banks[0].samples[24].common == true)
                {
                    this.B0_S25_Import.Enabled = false;
                    this.B0_S25_Common.Checked = true;
                }
                else
                {
                    this.B0_S25_Import.Enabled = true;
                    this.B0_S25_Common.Checked = false;
                }

                int start = Banks[0].samples[24].start;
                int id = Banks[0].samples[24].id;
                for (int i = 0; i < 127; i++)
                {
                    Sample smp = Banks[0].samples[i];
                    if (smp.enabled == true)
                    {
                        if (IsBetween(start, smp.start, smp.end))
                        {
                            if (Banks[0].samples[24].id > smp.id)
                            {
                                Banks[0].samples[smp.id].parents.Add(id);
                                Banks[0].samples[24].depends.Add(smp.id);
                                if (Banks[0].samples[24].depends.Count == 1)
                                {
                                    //find offset
                                    Banks[0].samples[24].offset = start - smp.start;
                                }
                            }
                        }
                    }
                }
                string deps = "";
                if (Banks[0].samples[24].common == true)
                {
                    Banks[0].samples[24].depends.Clear();
                    Banks[0].samples[24].offset = Banks[0].samples[24].start - 0x20000;
                }
                if (Banks[0].samples[24].depends.Count > 0)
                {
                    int dep = Banks[0].samples[24].depends[0];
                    {
                        deps = dep.ToString();
                    }

                }
                this.B0_S25_Dep.Text = deps;
                this.B0_S25_Off.Text = "0x" + Banks[0].samples[24].offset.ToString("x");
                this.B0_S25_Len.Text = "0x" + Banks[0].samples[24].length.ToString("x");
            }
            if (Banks[0].samples[25].enabled == true)
            {
                this.B0_S26_Enable.Enabled = true;
                this.B0_S26_Enable.Checked = true;
                this.B0_S26_Export.Enabled = true;

                if (Banks[0].samples[25].common == true)
                {
                    this.B0_S26_Import.Enabled = false;
                    this.B0_S26_Common.Checked = true;
                }
                else
                {
                    this.B0_S26_Import.Enabled = true;
                    this.B0_S26_Common.Checked = false;
                }

                int start = Banks[0].samples[25].start;
                int id = Banks[0].samples[25].id;
                for (int i = 0; i < 127; i++)
                {
                    Sample smp = Banks[0].samples[i];
                    if (smp.enabled == true)
                    {
                        if (IsBetween(start, smp.start, smp.end))
                        {
                            if (Banks[0].samples[25].id > smp.id)
                            {
                                Banks[0].samples[smp.id].parents.Add(id);
                                Banks[0].samples[25].depends.Add(smp.id);
                                if (Banks[0].samples[25].depends.Count == 1)
                                {
                                    //find offset
                                    Banks[0].samples[25].offset = start - smp.start;
                                }
                            }
                        }
                    }
                }
                string deps = "";
                if (Banks[0].samples[25].common == true)
                {
                    Banks[0].samples[25].depends.Clear();
                    Banks[0].samples[25].offset = Banks[0].samples[25].start - 0x20000;
                }
                if (Banks[0].samples[25].depends.Count > 0)
                {
                    int dep = Banks[0].samples[25].depends[0];
                    {
                        deps = dep.ToString();
                    }

                }
                this.B0_S26_Dep.Text = deps;
                this.B0_S26_Off.Text = "0x" + Banks[0].samples[25].offset.ToString("x");
                this.B0_S26_Len.Text = "0x" + Banks[0].samples[25].length.ToString("x");
            }
            if (Banks[0].samples[26].enabled == true)
            {
                this.B0_S27_Enable.Enabled = true;
                this.B0_S27_Enable.Checked = true;
                this.B0_S27_Export.Enabled = true;

                if (Banks[0].samples[26].common == true)
                {
                    this.B0_S27_Import.Enabled = false;
                    this.B0_S27_Common.Checked = true;
                }
                else
                {
                    this.B0_S27_Import.Enabled = true;
                    this.B0_S27_Common.Checked = false;
                }

                int start = Banks[0].samples[26].start;
                int id = Banks[0].samples[26].id;
                for (int i = 0; i < 127; i++)
                {
                    Sample smp = Banks[0].samples[i];
                    if (smp.enabled == true)
                    {
                        if (IsBetween(start, smp.start, smp.end))
                        {
                            if (Banks[0].samples[26].id > smp.id)
                            {
                                Banks[0].samples[smp.id].parents.Add(id);
                                Banks[0].samples[26].depends.Add(smp.id);
                                if (Banks[0].samples[26].depends.Count == 1)
                                {
                                    //find offset
                                    Banks[0].samples[26].offset = start - smp.start;
                                }
                            }
                        }
                    }
                }
                string deps = "";
                if (Banks[0].samples[26].common == true)
                {
                    Banks[0].samples[26].depends.Clear();
                    Banks[0].samples[26].offset = Banks[0].samples[26].start - 0x20000;
                }
                if (Banks[0].samples[26].depends.Count > 0)
                {
                    int dep = Banks[0].samples[26].depends[0];
                    {
                        deps = dep.ToString();
                    }

                }
                this.B0_S27_Dep.Text = deps;
                this.B0_S27_Off.Text = "0x" + Banks[0].samples[26].offset.ToString("x");
                this.B0_S27_Len.Text = "0x" + Banks[0].samples[26].length.ToString("x");
            }
            if (Banks[0].samples[27].enabled == true)
            {
                this.B0_S28_Enable.Enabled = true;
                this.B0_S28_Enable.Checked = true;
                this.B0_S28_Export.Enabled = true;

                if (Banks[0].samples[27].common == true)
                {
                    this.B0_S28_Import.Enabled = false;
                    this.B0_S28_Common.Checked = true;
                }
                else
                {
                    this.B0_S28_Import.Enabled = true;
                    this.B0_S28_Common.Checked = false;
                }

                int start = Banks[0].samples[27].start;
                int id = Banks[0].samples[27].id;
                for (int i = 0; i < 127; i++)
                {
                    Sample smp = Banks[0].samples[i];
                    if (smp.enabled == true)
                    {
                        if (IsBetween(start, smp.start, smp.end))
                        {
                            if (Banks[0].samples[27].id > smp.id)
                            {
                                Banks[0].samples[smp.id].parents.Add(id);
                                Banks[0].samples[27].depends.Add(smp.id);
                                if (Banks[0].samples[27].depends.Count == 1)
                                {
                                    //find offset
                                    Banks[0].samples[27].offset = start - smp.start;
                                }
                            }
                        }
                    }
                }
                string deps = "";
                if (Banks[0].samples[27].common == true)
                {
                    Banks[0].samples[27].depends.Clear();
                    Banks[0].samples[27].offset = Banks[0].samples[27].start - 0x20000;
                }
                if (Banks[0].samples[27].depends.Count > 0)
                {
                    int dep = Banks[0].samples[27].depends[0];
                    {
                        deps = dep.ToString();
                    }

                }
                this.B0_S28_Dep.Text = deps;
                this.B0_S28_Off.Text = "0x" + Banks[0].samples[27].offset.ToString("x");
                this.B0_S28_Len.Text = "0x" + Banks[0].samples[27].length.ToString("x");
            }
            if (Banks[0].samples[28].enabled == true)
            {
                this.B0_S29_Enable.Enabled = true;
                this.B0_S29_Enable.Checked = true;
                this.B0_S29_Export.Enabled = true;

                if (Banks[0].samples[28].common == true)
                {
                    this.B0_S29_Import.Enabled = false;
                    this.B0_S29_Common.Checked = true;
                }
                else
                {
                    this.B0_S29_Import.Enabled = true;
                    this.B0_S29_Common.Checked = false;
                }

                int start = Banks[0].samples[28].start;
                int id = Banks[0].samples[28].id;
                for (int i = 0; i < 127; i++)
                {
                    Sample smp = Banks[0].samples[i];
                    if (smp.enabled == true)
                    {
                        if (IsBetween(start, smp.start, smp.end))
                        {
                            if (Banks[0].samples[28].id > smp.id)
                            {
                                Banks[0].samples[smp.id].parents.Add(id);
                                Banks[0].samples[28].depends.Add(smp.id);
                                if (Banks[0].samples[28].depends.Count == 1)
                                {
                                    //find offset
                                    Banks[0].samples[28].offset = start - smp.start;
                                }
                            }
                        }
                    }
                }
                string deps = "";
                if (Banks[0].samples[28].common == true)
                {
                    Banks[0].samples[28].depends.Clear();
                    Banks[0].samples[28].offset = Banks[0].samples[28].start - 0x20000;
                }
                if (Banks[0].samples[28].depends.Count > 0)
                {
                    int dep = Banks[0].samples[28].depends[0];
                    {
                        deps = dep.ToString();
                    }

                }
                this.B0_S29_Dep.Text = deps;
                this.B0_S29_Off.Text = "0x" + Banks[0].samples[28].offset.ToString("x");
                this.B0_S29_Len.Text = "0x" + Banks[0].samples[28].length.ToString("x");
            }
            if (Banks[0].samples[29].enabled == true)
            {
                this.B0_S30_Enable.Enabled = true;
                this.B0_S30_Enable.Checked = true;
                this.B0_S30_Export.Enabled = true;

                if (Banks[0].samples[29].common == true)
                {
                    this.B0_S30_Import.Enabled = false;
                    this.B0_S30_Common.Checked = true;
                }
                else
                {
                    this.B0_S30_Import.Enabled = true;
                    this.B0_S30_Common.Checked = false;
                }

                int start = Banks[0].samples[29].start;
                int id = Banks[0].samples[29].id;
                for (int i = 0; i < 127; i++)
                {
                    Sample smp = Banks[0].samples[i];
                    if (smp.enabled == true)
                    {
                        if (IsBetween(start, smp.start, smp.end))
                        {
                            if (Banks[0].samples[29].id > smp.id)
                            {
                                Banks[0].samples[smp.id].parents.Add(id);
                                Banks[0].samples[29].depends.Add(smp.id);
                                if (Banks[0].samples[29].depends.Count == 1)
                                {
                                    //find offset
                                    Banks[0].samples[29].offset = start - smp.start;
                                }
                            }
                        }
                    }
                }
                string deps = "";
                if (Banks[0].samples[29].common == true)
                {
                    Banks[0].samples[29].depends.Clear();
                    Banks[0].samples[29].offset = Banks[0].samples[29].start - 0x20000;
                }
                if (Banks[0].samples[29].depends.Count > 0)
                {
                    int dep = Banks[0].samples[29].depends[0];
                    {
                        deps = dep.ToString();
                    }

                }
                this.B0_S30_Dep.Text = deps;
                this.B0_S30_Off.Text = "0x" + Banks[0].samples[29].offset.ToString("x");
                this.B0_S30_Len.Text = "0x" + Banks[0].samples[29].length.ToString("x");
            }
            if (Banks[0].samples[30].enabled == true)
            {
                this.B0_S31_Enable.Enabled = true;
                this.B0_S31_Enable.Checked = true;
                this.B0_S31_Export.Enabled = true;

                if (Banks[0].samples[30].common == true)
                {
                    this.B0_S31_Import.Enabled = false;
                    this.B0_S31_Common.Checked = true;
                }
                else
                {
                    this.B0_S31_Import.Enabled = true;
                    this.B0_S31_Common.Checked = false;
                }

                int start = Banks[0].samples[30].start;
                int id = Banks[0].samples[30].id;
                for (int i = 0; i < 127; i++)
                {
                    Sample smp = Banks[0].samples[i];
                    if (smp.enabled == true)
                    {
                        if (IsBetween(start, smp.start, smp.end))
                        {
                            if (Banks[0].samples[30].id > smp.id)
                            {
                                Banks[0].samples[smp.id].parents.Add(id);
                                Banks[0].samples[30].depends.Add(smp.id);
                                if (Banks[0].samples[30].depends.Count == 1)
                                {
                                    //find offset
                                    Banks[0].samples[30].offset = start - smp.start;
                                }
                            }
                        }
                    }
                }
                string deps = "";
                if (Banks[0].samples[30].common == true)
                {
                    Banks[0].samples[30].depends.Clear();
                    Banks[0].samples[30].offset = Banks[0].samples[30].start - 0x20000;
                }
                if (Banks[0].samples[30].depends.Count > 0)
                {
                    int dep = Banks[0].samples[30].depends[0];
                    {
                        deps = dep.ToString();
                    }
                }
                this.B0_S31_Dep.Text = deps;
                this.B0_S31_Off.Text = "0x" + Banks[0].samples[30].offset.ToString("x");
                this.B0_S31_Len.Text = "0x" + Banks[0].samples[30].length.ToString("x");
            }
            if (Banks[0].samples[31].enabled == true)
            {
                this.B0_S32_Enable.Enabled = true;
                this.B0_S32_Enable.Checked = true;
                this.B0_S32_Export.Enabled = true;

                if (Banks[0].samples[31].common == true)
                {
                    this.B0_S32_Import.Enabled = false;
                    this.B0_S32_Common.Checked = true;
                }
                else
                {
                    this.B0_S32_Import.Enabled = true;
                    this.B0_S32_Common.Checked = false;
                }

                int start = Banks[0].samples[31].start;
                int id = Banks[0].samples[31].id;
                for (int i = 0; i < 127; i++)
                {
                    Sample smp = Banks[0].samples[i];
                    if (smp.enabled == true)
                    {
                        if (IsBetween(start, smp.start, smp.end))
                        {
                            if (Banks[0].samples[31].id > smp.id)
                            {
                                Banks[0].samples[smp.id].parents.Add(id);
                                Banks[0].samples[31].depends.Add(smp.id);
                                if (Banks[0].samples[31].depends.Count == 1)
                                {
                                    //find offset
                                    Banks[0].samples[31].offset = start - smp.start;
                                }
                            }
                        }
                    }
                }
                string deps = "";
                if (Banks[0].samples[31].common == true)
                {
                    Banks[0].samples[31].depends.Clear();
                    Banks[0].samples[31].offset = Banks[0].samples[31].start - 0x20000;
                }
                if (Banks[0].samples[31].depends.Count > 0)
                {
                    int dep = Banks[0].samples[31].depends[0];
                    {
                        deps = dep.ToString();
                    }
                }
                this.B0_S32_Dep.Text = deps;
                this.B0_S32_Off.Text = "0x" + Banks[0].samples[31].offset.ToString("x");
                this.B0_S32_Len.Text = "0x" + Banks[0].samples[31].length.ToString("x");
            }
            if (Banks[0].samples[32].enabled == true)
            {
                this.B0_S33_Enable.Enabled = true;
                this.B0_S33_Enable.Checked = true;
                this.B0_S33_Export.Enabled = true;

                if (Banks[0].samples[32].common == true)
                {
                    this.B0_S33_Import.Enabled = false;
                    this.B0_S33_Common.Checked = true;
                }
                else
                {
                    this.B0_S33_Import.Enabled = true;
                    this.B0_S33_Common.Checked = false;
                }

                int start = Banks[0].samples[32].start;
                int id = Banks[0].samples[32].id;
                for (int i = 0; i < 127; i++)
                {
                    Sample smp = Banks[0].samples[i];
                    if (smp.enabled == true)
                    {
                        if (IsBetween(start, smp.start, smp.end))
                        {
                            if (Banks[0].samples[32].id > smp.id)
                            {
                                Banks[0].samples[smp.id].parents.Add(id);
                                Banks[0].samples[32].depends.Add(smp.id);
                                if (Banks[0].samples[32].depends.Count == 1)
                                {
                                    //find offset
                                    Banks[0].samples[32].offset = start - smp.start;
                                }
                            }
                        }
                    }
                }
                string deps = "";
                if (Banks[0].samples[32].common == true)
                {
                    Banks[0].samples[32].depends.Clear();
                    Banks[0].samples[32].offset = Banks[0].samples[32].start - 0x20000;
                }

                if (Banks[0].samples[32].depends.Count > 0)
                {
                    int dep = Banks[0].samples[32].depends[0];
                    {
                        deps = dep.ToString();
                    }

                }
                this.B0_S33_Dep.Text = deps;
                this.B0_S33_Off.Text = "0x" + Banks[0].samples[32].offset.ToString("x");
                this.B0_S33_Len.Text = "0x" + Banks[0].samples[32].length.ToString("x");
            }
            if (Banks[0].samples[33].enabled == true)
            {
                this.B0_S34_Enable.Enabled = true;
                this.B0_S34_Enable.Checked = true;
                this.B0_S34_Export.Enabled = true;

                if (Banks[0].samples[33].common == true)
                {
                    this.B0_S34_Import.Enabled = false;
                    this.B0_S34_Common.Checked = true;
                }
                else
                {
                    this.B0_S34_Import.Enabled = true;
                    this.B0_S34_Common.Checked = false;
                }

                int start = Banks[0].samples[33].start;
                int id = Banks[0].samples[33].id;
                for (int i = 0; i < 127; i++)
                {
                    Sample smp = Banks[0].samples[i];
                    if (smp.enabled == true)
                    {
                        if (IsBetween(start, smp.start, smp.end))
                        {
                            if (Banks[0].samples[33].id > smp.id)
                            {
                                Banks[0].samples[smp.id].parents.Add(id);
                                Banks[0].samples[33].depends.Add(smp.id);
                                if (Banks[0].samples[33].depends.Count == 1)
                                {
                                    //find offset
                                    Banks[0].samples[33].offset = start - smp.start;
                                }
                            }
                        }
                    }
                }
                string deps = "";
                if (Banks[0].samples[33].common == true)
                {
                    Banks[0].samples[33].depends.Clear();
                    Banks[0].samples[33].offset = Banks[0].samples[33].start - 0x20000;
                }
                if (Banks[0].samples[33].depends.Count > 0)
                {
                    int dep = Banks[0].samples[33].depends[0];
                    {
                        deps = dep.ToString();
                    }

                }
                this.B0_S34_Dep.Text = deps;
                this.B0_S34_Off.Text = "0x" + Banks[0].samples[33].offset.ToString("x");
                this.B0_S34_Len.Text = "0x" + Banks[0].samples[33].length.ToString("x");
            }
            if (Banks[0].samples[34].enabled == true)
            {
                this.B0_S35_Enable.Enabled = true;
                this.B0_S35_Enable.Checked = true;
                this.B0_S35_Export.Enabled = true;

                if (Banks[0].samples[34].common == true)
                {
                    this.B0_S35_Import.Enabled = false;
                    this.B0_S35_Common.Checked = true;
                }
                else
                {
                    this.B0_S35_Import.Enabled = true;
                    this.B0_S35_Common.Checked = false;
                }

                int start = Banks[0].samples[34].start;
                int id = Banks[0].samples[34].id;
                for (int i = 0; i < 127; i++)
                {
                    Sample smp = Banks[0].samples[i];
                    if (smp.enabled == true)
                    {
                        if (IsBetween(start, smp.start, smp.end))
                        {
                            if (Banks[0].samples[34].id > smp.id)
                            {
                                Banks[0].samples[smp.id].parents.Add(id);
                                Banks[0].samples[34].depends.Add(smp.id);
                                if (Banks[0].samples[34].depends.Count == 1)
                                {
                                    //find offset
                                    Banks[0].samples[34].offset = start - smp.start;
                                }
                            }
                        }
                    }
                }
                string deps = "";
                if (Banks[0].samples[34].common == true)
                {
                    Banks[0].samples[34].depends.Clear();
                    Banks[0].samples[34].offset = Banks[0].samples[34].start - 0x20000;
                }
                if (Banks[0].samples[34].depends.Count > 0)
                {
                    int dep = Banks[0].samples[34].depends[0];
                    {
                        deps = dep.ToString();
                    }

                }
                this.B0_S35_Dep.Text = deps;
                this.B0_S35_Off.Text = "0x" + Banks[0].samples[34].offset.ToString("x");
                this.B0_S35_Len.Text = "0x" + Banks[0].samples[34].length.ToString("x");
            }
            if (Banks[0].samples[35].enabled == true)
            {
                this.B0_S36_Enable.Enabled = true;
                this.B0_S36_Enable.Checked = true;
                this.B0_S36_Export.Enabled = true;

                if (Banks[0].samples[35].common == true)
                {
                    this.B0_S36_Import.Enabled = false;
                    this.B0_S36_Common.Checked = true;
                }
                else
                {
                    this.B0_S36_Import.Enabled = true;
                    this.B0_S36_Common.Checked = false;
                }

                int start = Banks[0].samples[35].start;
                int id = Banks[0].samples[35].id;
                for (int i = 0; i < 127; i++)
                {
                    Sample smp = Banks[0].samples[i];
                    if (smp.enabled == true)
                    {
                        if (IsBetween(start, smp.start, smp.end))
                        {
                            if (Banks[0].samples[35].id > smp.id)
                            {
                                Banks[0].samples[smp.id].parents.Add(id);
                                Banks[0].samples[35].depends.Add(smp.id);
                                if (Banks[0].samples[35].depends.Count == 1)
                                {
                                    //find offset
                                    Banks[0].samples[35].offset = start - smp.start;
                                }
                            }
                        }
                    }
                }
                string deps = "";
                if (Banks[0].samples[35].common == true)
                {
                    Banks[0].samples[35].depends.Clear();
                    Banks[0].samples[35].offset = Banks[0].samples[35].start - 0x20000;
                }
                if (Banks[0].samples[35].depends.Count > 0)
                {
                    int dep = Banks[0].samples[35].depends[0];
                    {
                        deps = dep.ToString();
                    }

                }
                this.B0_S36_Dep.Text = deps;
                this.B0_S36_Off.Text = "0x" + Banks[0].samples[35].offset.ToString("x");
                this.B0_S36_Len.Text = "0x" + Banks[0].samples[35].length.ToString("x");
            }
            if (Banks[0].samples[36].enabled == true)
            {
                this.B0_S37_Enable.Enabled = true;
                this.B0_S37_Enable.Checked = true;
                this.B0_S37_Export.Enabled = true;

                if (Banks[0].samples[36].common == true)
                {
                    this.B0_S37_Import.Enabled = false;
                    this.B0_S37_Common.Checked = true;
                }
                else
                {
                    this.B0_S37_Import.Enabled = true;
                    this.B0_S37_Common.Checked = false;
                }

                int start = Banks[0].samples[36].start;
                int id = Banks[0].samples[36].id;
                for (int i = 0; i < 127; i++)
                {
                    Sample smp = Banks[0].samples[i];
                    if (smp.enabled == true)
                    {
                        if (IsBetween(start, smp.start, smp.end))
                        {
                            if (Banks[0].samples[36].id > smp.id)
                            {
                                Banks[0].samples[smp.id].parents.Add(id);
                                Banks[0].samples[36].depends.Add(smp.id);
                                if (Banks[0].samples[36].depends.Count == 1)
                                {
                                    //find offset
                                    Banks[0].samples[36].offset = start - smp.start;
                                }
                            }
                        }
                    }
                }
                string deps = "";
                if (Banks[0].samples[36].common == true)
                {
                    Banks[0].samples[36].depends.Clear();
                    Banks[0].samples[36].offset = Banks[0].samples[36].start - 0x20000;
                }
                if (Banks[0].samples[36].depends.Count > 0)
                {
                    int dep = Banks[0].samples[36].depends[0];
                    {
                        deps = dep.ToString();
                    }

                }
                this.B0_S37_Dep.Text = deps;
                this.B0_S37_Off.Text = "0x" + Banks[0].samples[36].offset.ToString("x");
                this.B0_S37_Len.Text = "0x" + Banks[0].samples[36].length.ToString("x");
            }
            if (Banks[0].samples[37].enabled == true)
            {
                this.B0_S38_Enable.Enabled = true;
                this.B0_S38_Enable.Checked = true;
                this.B0_S38_Export.Enabled = true;

                if (Banks[0].samples[37].common == true)
                {
                    this.B0_S38_Import.Enabled = false;
                    this.B0_S38_Common.Checked = true;
                }
                else
                {
                    this.B0_S38_Import.Enabled = true;
                    this.B0_S38_Common.Checked = false;
                }

                int start = Banks[0].samples[37].start;
                int id = Banks[0].samples[37].id;
                for (int i = 0; i < 127; i++)
                {
                    Sample smp = Banks[0].samples[i];
                    if (smp.enabled == true)
                    {
                        if (IsBetween(start, smp.start, smp.end))
                        {
                            if (Banks[0].samples[37].id > smp.id)
                            {
                                Banks[0].samples[smp.id].parents.Add(id);
                                Banks[0].samples[37].depends.Add(smp.id);
                                if (Banks[0].samples[37].depends.Count == 1)
                                {
                                    //find offset
                                    Banks[0].samples[37].offset = start - smp.start;
                                }
                            }
                        }
                    }
                }
                string deps = "";
                if (Banks[0].samples[37].common == true)
                {
                    Banks[0].samples[37].depends.Clear();
                    Banks[0].samples[37].offset = Banks[0].samples[37].start - 0x20000;
                }
                if (Banks[0].samples[37].depends.Count > 0)
                {
                    int dep = Banks[0].samples[37].depends[0];
                    {
                        deps = dep.ToString();
                    }

                }
                this.B0_S38_Dep.Text = deps;
                this.B0_S38_Off.Text = "0x" + Banks[0].samples[37].offset.ToString("x");
                this.B0_S38_Len.Text = "0x" + Banks[0].samples[37].length.ToString("x");
            }
            if (Banks[0].samples[38].enabled == true)
            {
                this.B0_S39_Enable.Enabled = true;
                this.B0_S39_Enable.Checked = true;
                this.B0_S39_Export.Enabled = true;

                if (Banks[0].samples[38].common == true)
                {
                    this.B0_S39_Import.Enabled = false;
                    this.B0_S39_Common.Checked = true;
                }
                else
                {
                    this.B0_S39_Import.Enabled = true;
                    this.B0_S39_Common.Checked = false;
                }

                int start = Banks[0].samples[38].start;
                int id = Banks[0].samples[38].id;
                for (int i = 0; i < 127; i++)
                {
                    Sample smp = Banks[0].samples[i];
                    if (smp.enabled == true)
                    {
                        if (IsBetween(start, smp.start, smp.end))
                        {
                            if (Banks[0].samples[38].id > smp.id)
                            {
                                Banks[0].samples[smp.id].parents.Add(id);
                                Banks[0].samples[38].depends.Add(smp.id);
                                if (Banks[0].samples[38].depends.Count == 1)
                                {
                                    //find offset
                                    Banks[0].samples[38].offset = start - smp.start;
                                }
                            }
                        }
                    }
                }
                string deps = "";
                if (Banks[0].samples[38].common == true)
                {
                    Banks[0].samples[38].depends.Clear();
                    Banks[0].samples[38].offset = Banks[0].samples[38].start - 0x20000;
                }
                if (Banks[0].samples[38].depends.Count > 0)
                {
                    int dep = Banks[0].samples[38].depends[0];
                    {
                        deps = dep.ToString();
                    }

                }
                this.B0_S39_Dep.Text = deps;
                this.B0_S39_Off.Text = "0x" + Banks[0].samples[38].offset.ToString("x");
                this.B0_S39_Len.Text = "0x" + Banks[0].samples[38].length.ToString("x");
            }
            if (Banks[0].samples[39].enabled == true)
            {
                this.B0_S40_Enable.Enabled = true;
                this.B0_S40_Enable.Checked = true;
                this.B0_S40_Export.Enabled = true;

                if (Banks[0].samples[39].common == true)
                {
                    this.B0_S40_Import.Enabled = false;
                    this.B0_S40_Common.Checked = true;
                }
                else
                {
                    this.B0_S40_Import.Enabled = true;
                    this.B0_S40_Common.Checked = false;
                }

                int start = Banks[0].samples[39].start;
                int id = Banks[0].samples[39].id;
                for (int i = 0; i < 127; i++)
                {
                    Sample smp = Banks[0].samples[i];
                    if (smp.enabled == true)
                    {
                        if (IsBetween(start, smp.start, smp.end))
                        {
                            if (Banks[0].samples[39].id > smp.id)
                            {
                                Banks[0].samples[smp.id].parents.Add(id);
                                Banks[0].samples[39].depends.Add(smp.id);
                                if (Banks[0].samples[39].depends.Count == 1)
                                {
                                    //find offset
                                    Banks[0].samples[39].offset = start - smp.start;
                                }
                            }
                        }
                    }
                }
                string deps = "";
                if (Banks[0].samples[39].common == true)
                {
                    Banks[0].samples[39].depends.Clear();
                    Banks[0].samples[39].offset = Banks[0].samples[39].start - 0x20000;
                }
                if (Banks[0].samples[39].depends.Count > 0)
                {
                    int dep = Banks[0].samples[39].depends[0];
                    {
                        deps = dep.ToString();
                    }

                }
                this.B0_S40_Dep.Text = deps;
                this.B0_S40_Off.Text = "0x" + Banks[0].samples[39].offset.ToString("x");
                this.B0_S40_Len.Text = "0x" + Banks[0].samples[39].length.ToString("x");
            }
            if (Banks[0].samples[40].enabled == true)
            {
                this.B0_S41_Enable.Enabled = true;
                this.B0_S41_Enable.Checked = true;
                this.B0_S41_Export.Enabled = true;

                if (Banks[0].samples[40].common == true)
                {
                    this.B0_S41_Import.Enabled = false;
                    this.B0_S41_Common.Checked = true;
                }
                else
                {
                    this.B0_S41_Import.Enabled = true;
                    this.B0_S41_Common.Checked = false;
                }

                int start = Banks[0].samples[40].start;
                int id = Banks[0].samples[40].id;
                for (int i = 0; i < 127; i++)
                {
                    Sample smp = Banks[0].samples[i];
                    if (smp.enabled == true)
                    {
                        if (IsBetween(start, smp.start, smp.end))
                        {
                            if (Banks[0].samples[40].id > smp.id)
                            {
                                Banks[0].samples[smp.id].parents.Add(id);
                                Banks[0].samples[40].depends.Add(smp.id);
                                if (Banks[0].samples[40].depends.Count == 1)
                                {
                                    //find offset
                                    Banks[0].samples[40].offset = start - smp.start;
                                }
                            }
                        }
                    }
                }
                string deps = "";
                if (Banks[0].samples[40].common == true)
                {
                    Banks[0].samples[40].depends.Clear();
                    Banks[0].samples[40].offset = Banks[0].samples[40].start - 0x20000;
                }
                if (Banks[0].samples[40].depends.Count > 0)
                {
                    int dep = Banks[0].samples[40].depends[0];
                    {
                        deps = dep.ToString();
                    }
                }
                this.B0_S41_Dep.Text = deps;
                this.B0_S41_Off.Text = "0x" + Banks[0].samples[40].offset.ToString("x");
                this.B0_S41_Len.Text = "0x" + Banks[0].samples[40].length.ToString("x");
            }
            if (Banks[0].samples[41].enabled == true)
            {
                this.B0_S42_Enable.Enabled = true;
                this.B0_S42_Enable.Checked = true;
                this.B0_S42_Export.Enabled = true;

                if (Banks[0].samples[41].common == true)
                {
                    this.B0_S42_Import.Enabled = false;
                    this.B0_S42_Common.Checked = true;
                }
                else
                {
                    this.B0_S42_Import.Enabled = true;
                    this.B0_S42_Common.Checked = false;
                }

                int start = Banks[0].samples[41].start;
                int id = Banks[0].samples[41].id;
                for (int i = 0; i < 127; i++)
                {
                    Sample smp = Banks[0].samples[i];
                    if (smp.enabled == true)
                    {
                        if (IsBetween(start, smp.start, smp.end))
                        {
                            if (Banks[0].samples[41].id > smp.id)
                            {
                                Banks[0].samples[smp.id].parents.Add(id);
                                Banks[0].samples[41].depends.Add(smp.id);
                                if (Banks[0].samples[41].depends.Count == 1)
                                {
                                    //find offset
                                    Banks[0].samples[41].offset = start - smp.start;
                                }
                            }
                        }
                    }
                }
                string deps = "";
                if (Banks[0].samples[41].common == true)
                {
                    Banks[0].samples[41].depends.Clear();
                    Banks[0].samples[41].offset = Banks[0].samples[41].start - 0x20000;
                }
                if (Banks[0].samples[41].depends.Count > 0)
                {
                    int dep = Banks[0].samples[41].depends[0];
                    {
                        deps = dep.ToString();
                    }
                }
                this.B0_S42_Dep.Text = deps;
                this.B0_S42_Off.Text = "0x" + Banks[0].samples[41].offset.ToString("x");
                this.B0_S42_Len.Text = "0x" + Banks[0].samples[41].length.ToString("x");
            }
            if (Banks[0].samples[42].enabled == true)
            {
                this.B0_S43_Enable.Enabled = true;
                this.B0_S43_Enable.Checked = true;
                this.B0_S43_Export.Enabled = true;

                if (Banks[0].samples[42].common == true)
                {
                    this.B0_S43_Import.Enabled = false;
                    this.B0_S43_Common.Checked = true;
                }
                else
                {
                    this.B0_S43_Import.Enabled = true;
                    this.B0_S43_Common.Checked = false;
                }

                int start = Banks[0].samples[42].start;
                int id = Banks[0].samples[42].id;
                for (int i = 0; i < 127; i++)
                {
                    Sample smp = Banks[0].samples[i];
                    if (smp.enabled == true)
                    {
                        if (IsBetween(start, smp.start, smp.end))
                        {
                            if (Banks[0].samples[42].id > smp.id)
                            {
                                Banks[0].samples[smp.id].parents.Add(id);
                                Banks[0].samples[42].depends.Add(smp.id);
                                if (Banks[0].samples[42].depends.Count == 1)
                                {
                                    //find offset
                                    Banks[0].samples[42].offset = start - smp.start;
                                }
                            }
                        }
                    }
                }
                string deps = "";
                if (Banks[0].samples[42].common == true)
                {
                    Banks[0].samples[42].depends.Clear();
                    Banks[0].samples[42].offset = Banks[0].samples[42].start - 0x20000;
                }

                if (Banks[0].samples[42].depends.Count > 0)
                {
                    int dep = Banks[0].samples[42].depends[0];
                    {
                        deps = dep.ToString();
                    }

                }
                this.B0_S43_Dep.Text = deps;
                this.B0_S43_Off.Text = "0x" + Banks[0].samples[42].offset.ToString("x");
                this.B0_S43_Len.Text = "0x" + Banks[0].samples[42].length.ToString("x");
            }
            if (Banks[0].samples[43].enabled == true)
            {
                this.B0_S44_Enable.Enabled = true;
                this.B0_S44_Enable.Checked = true;
                this.B0_S44_Export.Enabled = true;

                if (Banks[0].samples[43].common == true)
                {
                    this.B0_S44_Import.Enabled = false;
                    this.B0_S44_Common.Checked = true;
                }
                else
                {
                    this.B0_S44_Import.Enabled = true;
                    this.B0_S44_Common.Checked = false;
                }

                int start = Banks[0].samples[43].start;
                int id = Banks[0].samples[43].id;
                for (int i = 0; i < 127; i++)
                {
                    Sample smp = Banks[0].samples[i];
                    if (smp.enabled == true)
                    {
                        if (IsBetween(start, smp.start, smp.end))
                        {
                            if (Banks[0].samples[43].id > smp.id)
                            {
                                Banks[0].samples[smp.id].parents.Add(id);
                                Banks[0].samples[43].depends.Add(smp.id);
                                if (Banks[0].samples[43].depends.Count == 1)
                                {
                                    //find offset
                                    Banks[0].samples[43].offset = start - smp.start;
                                }
                            }
                        }
                    }
                }
                string deps = "";
                if (Banks[0].samples[43].common == true)
                {
                    Banks[0].samples[43].depends.Clear();
                    Banks[0].samples[43].offset = Banks[0].samples[43].start - 0x20000;
                }
                if (Banks[0].samples[43].depends.Count > 0)
                {
                    int dep = Banks[0].samples[43].depends[0];
                    {
                        deps = dep.ToString();
                    }

                }
                this.B0_S44_Dep.Text = deps;
                this.B0_S44_Off.Text = "0x" + Banks[0].samples[43].offset.ToString("x");
                this.B0_S44_Len.Text = "0x" + Banks[0].samples[43].length.ToString("x");
            }
            if (Banks[0].samples[44].enabled == true)
            {
                this.B0_S45_Enable.Enabled = true;
                this.B0_S45_Enable.Checked = true;
                this.B0_S45_Export.Enabled = true;

                if (Banks[0].samples[44].common == true)
                {
                    this.B0_S45_Import.Enabled = false;
                    this.B0_S45_Common.Checked = true;
                }
                else
                {
                    this.B0_S45_Import.Enabled = true;
                    this.B0_S45_Common.Checked = false;
                }

                int start = Banks[0].samples[44].start;
                int id = Banks[0].samples[44].id;
                for (int i = 0; i < 127; i++)
                {
                    Sample smp = Banks[0].samples[i];
                    if (smp.enabled == true)
                    {
                        if (IsBetween(start, smp.start, smp.end))
                        {
                            if (Banks[0].samples[44].id > smp.id)
                            {
                                Banks[0].samples[smp.id].parents.Add(id);
                                Banks[0].samples[44].depends.Add(smp.id);
                                if (Banks[0].samples[44].depends.Count == 1)
                                {
                                    //find offset
                                    Banks[0].samples[44].offset = start - smp.start;
                                }
                            }
                        }
                    }
                }
                string deps = "";
                if (Banks[0].samples[44].common == true)
                {
                    Banks[0].samples[44].depends.Clear();
                    Banks[0].samples[44].offset = Banks[0].samples[44].start - 0x20000;
                }
                if (Banks[0].samples[44].depends.Count > 0)
                {
                    int dep = Banks[0].samples[44].depends[0];
                    {
                        deps = dep.ToString();
                    }

                }
                this.B0_S45_Dep.Text = deps;
                this.B0_S45_Off.Text = "0x" + Banks[0].samples[44].offset.ToString("x");
                this.B0_S45_Len.Text = "0x" + Banks[0].samples[44].length.ToString("x");
            }
            if (Banks[0].samples[45].enabled == true)
            {
                this.B0_S46_Enable.Enabled = true;
                this.B0_S46_Enable.Checked = true;
                this.B0_S46_Export.Enabled = true;

                if (Banks[0].samples[45].common == true)
                {
                    this.B0_S46_Import.Enabled = false;
                    this.B0_S46_Common.Checked = true;
                }
                else
                {
                    this.B0_S46_Import.Enabled = true;
                    this.B0_S46_Common.Checked = false;
                }

                int start = Banks[0].samples[45].start;
                int id = Banks[0].samples[45].id;
                for (int i = 0; i < 127; i++)
                {
                    Sample smp = Banks[0].samples[i];
                    if (smp.enabled == true)
                    {
                        if (IsBetween(start, smp.start, smp.end))
                        {
                            if (Banks[0].samples[45].id > smp.id)
                            {
                                Banks[0].samples[smp.id].parents.Add(id);
                                Banks[0].samples[45].depends.Add(smp.id);
                                if (Banks[0].samples[45].depends.Count == 1)
                                {
                                    //find offset
                                    Banks[0].samples[45].offset = start - smp.start;
                                }
                            }
                        }
                    }
                }
                string deps = "";
                if (Banks[0].samples[45].common == true)
                {
                    Banks[0].samples[45].depends.Clear();
                    Banks[0].samples[45].offset = Banks[0].samples[45].start - 0x20000;
                }
                if (Banks[0].samples[45].depends.Count > 0)
                {
                    int dep = Banks[0].samples[45].depends[0];
                    {
                        deps = dep.ToString();
                    }

                }
                this.B0_S46_Dep.Text = deps;
                this.B0_S46_Off.Text = "0x" + Banks[0].samples[45].offset.ToString("x");
                this.B0_S46_Len.Text = "0x" + Banks[0].samples[45].length.ToString("x");
            }
            if (Banks[0].samples[46].enabled == true)
            {
                this.B0_S47_Enable.Enabled = true;
                this.B0_S47_Enable.Checked = true;
                this.B0_S47_Export.Enabled = true;

                if (Banks[0].samples[46].common == true)
                {
                    this.B0_S47_Import.Enabled = false;
                    this.B0_S47_Common.Checked = true;
                }
                else
                {
                    this.B0_S47_Import.Enabled = true;
                    this.B0_S47_Common.Checked = false;
                }

                int start = Banks[0].samples[46].start;
                int id = Banks[0].samples[46].id;
                for (int i = 0; i < 127; i++)
                {
                    Sample smp = Banks[0].samples[i];
                    if (smp.enabled == true)
                    {
                        if (IsBetween(start, smp.start, smp.end))
                        {
                            if (Banks[0].samples[46].id > smp.id)
                            {
                                Banks[0].samples[smp.id].parents.Add(id);
                                Banks[0].samples[46].depends.Add(smp.id);
                                if (Banks[0].samples[46].depends.Count == 1)
                                {
                                    //find offset
                                    Banks[0].samples[46].offset = start - smp.start;
                                }
                            }
                        }
                    }
                }
                string deps = "";
                if (Banks[0].samples[46].common == true)
                {
                    Banks[0].samples[46].depends.Clear();
                    Banks[0].samples[46].offset = Banks[0].samples[46].start - 0x20000;
                }
                if (Banks[0].samples[46].depends.Count > 0)
                {
                    int dep = Banks[0].samples[46].depends[0];
                    {
                        deps = dep.ToString();
                    }

                }
                this.B0_S47_Dep.Text = deps;
                this.B0_S47_Off.Text = "0x" + Banks[0].samples[46].offset.ToString("x");
                this.B0_S47_Len.Text = "0x" + Banks[0].samples[46].length.ToString("x");
            }
            if (Banks[0].samples[47].enabled == true)
            {
                this.B0_S48_Enable.Enabled = true;
                this.B0_S48_Enable.Checked = true;
                this.B0_S48_Export.Enabled = true;

                if (Banks[0].samples[47].common == true)
                {
                    this.B0_S48_Import.Enabled = false;
                    this.B0_S48_Common.Checked = true;
                }
                else
                {
                    this.B0_S48_Import.Enabled = true;
                    this.B0_S48_Common.Checked = false;
                }

                int start = Banks[0].samples[47].start;
                int id = Banks[0].samples[47].id;
                for (int i = 0; i < 127; i++)
                {
                    Sample smp = Banks[0].samples[i];
                    if (smp.enabled == true)
                    {
                        if (IsBetween(start, smp.start, smp.end))
                        {
                            if (Banks[0].samples[47].id > smp.id)
                            {
                                Banks[0].samples[smp.id].parents.Add(id);
                                Banks[0].samples[47].depends.Add(smp.id);
                                if (Banks[0].samples[47].depends.Count == 1)
                                {
                                    //find offset
                                    Banks[0].samples[47].offset = start - smp.start;
                                }
                            }
                        }
                    }
                }
                string deps = "";
                if (Banks[0].samples[47].common == true)
                {
                    Banks[0].samples[47].depends.Clear();
                    Banks[0].samples[47].offset = Banks[0].samples[47].start - 0x20000;
                }
                if (Banks[0].samples[47].depends.Count > 0)
                {
                    int dep = Banks[0].samples[47].depends[0];
                    {
                        deps = dep.ToString();
                    }

                }
                this.B0_S48_Dep.Text = deps;
                this.B0_S48_Off.Text = "0x" + Banks[0].samples[47].offset.ToString("x");
                this.B0_S48_Len.Text = "0x" + Banks[0].samples[47].length.ToString("x");
            }
            if (Banks[0].samples[48].enabled == true)
            {
                this.B0_S49_Enable.Enabled = true;
                this.B0_S49_Enable.Checked = true;
                this.B0_S49_Export.Enabled = true;

                if (Banks[0].samples[48].common == true)
                {
                    this.B0_S49_Import.Enabled = false;
                    this.B0_S49_Common.Checked = true;
                }
                else
                {
                    this.B0_S49_Import.Enabled = true;
                    this.B0_S49_Common.Checked = false;
                }

                int start = Banks[0].samples[48].start;
                int id = Banks[0].samples[48].id;
                for (int i = 0; i < 127; i++)
                {
                    Sample smp = Banks[0].samples[i];
                    if (smp.enabled == true)
                    {
                        if (IsBetween(start, smp.start, smp.end))
                        {
                            if (Banks[0].samples[48].id > smp.id)
                            {
                                Banks[0].samples[smp.id].parents.Add(id);
                                Banks[0].samples[48].depends.Add(smp.id);
                                if (Banks[0].samples[48].depends.Count == 1)
                                {
                                    //find offset
                                    Banks[0].samples[48].offset = start - smp.start;
                                }
                            }
                        }
                    }
                }
                string deps = "";
                if (Banks[0].samples[48].common == true)
                {
                    Banks[0].samples[48].depends.Clear();
                    Banks[0].samples[48].offset = Banks[0].samples[48].start - 0x20000;
                }
                if (Banks[0].samples[48].depends.Count > 0)
                {
                    int dep = Banks[0].samples[48].depends[0];
                    {
                        deps = dep.ToString();
                    }

                }
                this.B0_S49_Dep.Text = deps;
                this.B0_S49_Off.Text = "0x" + Banks[0].samples[48].offset.ToString("x");
                this.B0_S49_Len.Text = "0x" + Banks[0].samples[48].length.ToString("x");
            }
            if (Banks[0].samples[49].enabled == true)
            {
                this.B0_S50_Enable.Enabled = true;
                this.B0_S50_Enable.Checked = true;
                this.B0_S50_Export.Enabled = true;

                if (Banks[0].samples[49].common == true)
                {
                    this.B0_S50_Import.Enabled = false;
                    this.B0_S50_Common.Checked = true;
                }
                else
                {
                    this.B0_S50_Import.Enabled = true;
                    this.B0_S50_Common.Checked = false;
                }

                int start = Banks[0].samples[49].start;
                int id = Banks[0].samples[49].id;
                for (int i = 0; i < 127; i++)
                {
                    Sample smp = Banks[0].samples[i];
                    if (smp.enabled == true)
                    {
                        if (IsBetween(start, smp.start, smp.end))
                        {
                            if (Banks[0].samples[49].id > smp.id)
                            {
                                Banks[0].samples[smp.id].parents.Add(id);
                                Banks[0].samples[49].depends.Add(smp.id);
                                if (Banks[0].samples[49].depends.Count == 1)
                                {
                                    //find offset
                                    Banks[0].samples[49].offset = start - smp.start;
                                }
                            }
                        }
                    }
                }
                string deps = "";
                if (Banks[0].samples[49].common == true)
                {
                    Banks[0].samples[49].depends.Clear();
                    Banks[0].samples[49].offset = Banks[0].samples[49].start - 0x20000;
                }
                if (Banks[0].samples[49].depends.Count > 0)
                {
                    int dep = Banks[0].samples[49].depends[0];
                    {
                        deps = dep.ToString();
                    }

                }
                this.B0_S50_Dep.Text = deps;
                this.B0_S50_Off.Text = "0x" + Banks[0].samples[49].offset.ToString("x");
                this.B0_S50_Len.Text = "0x" + Banks[0].samples[49].length.ToString("x");
            }
            if (Banks[0].samples[50].enabled == true)
            {
                this.B0_S51_Enable.Enabled = true;
                this.B0_S51_Enable.Checked = true;
                this.B0_S51_Export.Enabled = true;

                if (Banks[0].samples[50].common == true)
                {
                    this.B0_S51_Import.Enabled = false;
                    this.B0_S51_Common.Checked = true;
                }
                else
                {
                    this.B0_S51_Import.Enabled = true;
                    this.B0_S51_Common.Checked = false;
                }

                int start = Banks[0].samples[50].start;
                int id = Banks[0].samples[50].id;
                for (int i = 0; i < 127; i++)
                {
                    Sample smp = Banks[0].samples[i];
                    if (smp.enabled == true)
                    {
                        if (IsBetween(start, smp.start, smp.end))
                        {
                            if (Banks[0].samples[50].id > smp.id)
                            {
                                Banks[0].samples[smp.id].parents.Add(id);
                                Banks[0].samples[50].depends.Add(smp.id);
                                if (Banks[0].samples[50].depends.Count == 1)
                                {
                                    //find offset
                                    Banks[0].samples[50].offset = start - smp.start;
                                }
                            }
                        }
                    }
                }
                string deps = "";
                if (Banks[0].samples[50].common == true)
                {
                    Banks[0].samples[50].depends.Clear();
                    Banks[0].samples[50].offset = Banks[0].samples[50].start - 0x20000;
                }
                if (Banks[0].samples[50].depends.Count > 0)
                {
                    int dep = Banks[0].samples[50].depends[0];
                    {
                        deps = dep.ToString();
                    }
                }
                this.B0_S51_Dep.Text = deps;
                this.B0_S51_Off.Text = "0x" + Banks[0].samples[50].offset.ToString("x");
                this.B0_S51_Len.Text = "0x" + Banks[0].samples[50].length.ToString("x");
            }
            if (Banks[0].samples[51].enabled == true)
            {
                this.B0_S52_Enable.Enabled = true;
                this.B0_S52_Enable.Checked = true;
                this.B0_S52_Export.Enabled = true;

                if (Banks[0].samples[51].common == true)
                {
                    this.B0_S52_Import.Enabled = false;
                    this.B0_S52_Common.Checked = true;
                }
                else
                {
                    this.B0_S52_Import.Enabled = true;
                    this.B0_S52_Common.Checked = false;
                }

                int start = Banks[0].samples[51].start;
                int id = Banks[0].samples[51].id;
                for (int i = 0; i < 127; i++)
                {
                    Sample smp = Banks[0].samples[i];
                    if (smp.enabled == true)
                    {
                        if (IsBetween(start, smp.start, smp.end))
                        {
                            if (Banks[0].samples[51].id > smp.id)
                            {
                                Banks[0].samples[smp.id].parents.Add(id);
                                Banks[0].samples[51].depends.Add(smp.id);
                                if (Banks[0].samples[51].depends.Count == 1)
                                {
                                    //find offset
                                    Banks[0].samples[51].offset = start - smp.start;
                                }
                            }
                        }
                    }
                }
                string deps = "";
                if (Banks[0].samples[51].common == true)
                {
                    Banks[0].samples[51].depends.Clear();
                    Banks[0].samples[51].offset = Banks[0].samples[51].start - 0x20000;
                }
                if (Banks[0].samples[51].depends.Count > 0)
                {
                    int dep = Banks[0].samples[51].depends[0];
                    {
                        deps = dep.ToString();
                    }
                }
                this.B0_S52_Dep.Text = deps;
                this.B0_S52_Off.Text = "0x" + Banks[0].samples[51].offset.ToString("x");
                this.B0_S52_Len.Text = "0x" + Banks[0].samples[51].length.ToString("x");
            }
            if (Banks[0].samples[52].enabled == true)
            {
                this.B0_S53_Enable.Enabled = true;
                this.B0_S53_Enable.Checked = true;
                this.B0_S53_Export.Enabled = true;

                if (Banks[0].samples[52].common == true)
                {
                    this.B0_S53_Import.Enabled = false;
                    this.B0_S53_Common.Checked = true;
                }
                else
                {
                    this.B0_S53_Import.Enabled = true;
                    this.B0_S53_Common.Checked = false;
                }

                int start = Banks[0].samples[52].start;
                int id = Banks[0].samples[52].id;
                for (int i = 0; i < 127; i++)
                {
                    Sample smp = Banks[0].samples[i];
                    if (smp.enabled == true)
                    {
                        if (IsBetween(start, smp.start, smp.end))
                        {
                            if (Banks[0].samples[52].id > smp.id)
                            {
                                Banks[0].samples[smp.id].parents.Add(id);
                                Banks[0].samples[52].depends.Add(smp.id);
                                if (Banks[0].samples[52].depends.Count == 1)
                                {
                                    //find offset
                                    Banks[0].samples[52].offset = start - smp.start;
                                }
                            }
                        }
                    }
                }
                string deps = "";
                if (Banks[0].samples[52].common == true)
                {
                    Banks[0].samples[52].depends.Clear();
                    Banks[0].samples[52].offset = Banks[0].samples[52].start - 0x20000;
                }

                if (Banks[0].samples[52].depends.Count > 0)
                {
                    int dep = Banks[0].samples[52].depends[0];
                    {
                        deps = dep.ToString();
                    }

                }
                this.B0_S53_Dep.Text = deps;
                this.B0_S53_Off.Text = "0x" + Banks[0].samples[52].offset.ToString("x");
                this.B0_S53_Len.Text = "0x" + Banks[0].samples[52].length.ToString("x");
            }
            if (Banks[0].samples[53].enabled == true)
            {
                this.B0_S54_Enable.Enabled = true;
                this.B0_S54_Enable.Checked = true;
                this.B0_S54_Export.Enabled = true;

                if (Banks[0].samples[53].common == true)
                {
                    this.B0_S54_Import.Enabled = false;
                    this.B0_S54_Common.Checked = true;
                }
                else
                {
                    this.B0_S54_Import.Enabled = true;
                    this.B0_S54_Common.Checked = false;
                }

                int start = Banks[0].samples[53].start;
                int id = Banks[0].samples[53].id;
                for (int i = 0; i < 127; i++)
                {
                    Sample smp = Banks[0].samples[i];
                    if (smp.enabled == true)
                    {
                        if (IsBetween(start, smp.start, smp.end))
                        {
                            if (Banks[0].samples[53].id > smp.id)
                            {
                                Banks[0].samples[smp.id].parents.Add(id);
                                Banks[0].samples[53].depends.Add(smp.id);
                                if (Banks[0].samples[53].depends.Count == 1)
                                {
                                    //find offset
                                    Banks[0].samples[53].offset = start - smp.start;
                                }
                            }
                        }
                    }
                }
                string deps = "";
                if (Banks[0].samples[53].common == true)
                {
                    Banks[0].samples[53].depends.Clear();
                    Banks[0].samples[53].offset = Banks[0].samples[53].start - 0x20000;
                }
                if (Banks[0].samples[53].depends.Count > 0)
                {
                    int dep = Banks[0].samples[53].depends[0];
                    {
                        deps = dep.ToString();
                    }

                }
                this.B0_S54_Dep.Text = deps;
                this.B0_S54_Off.Text = "0x" + Banks[0].samples[53].offset.ToString("x");
                this.B0_S54_Len.Text = "0x" + Banks[0].samples[53].length.ToString("x");
            }
            if (Banks[0].samples[54].enabled == true)
            {
                this.B0_S55_Enable.Enabled = true;
                this.B0_S55_Enable.Checked = true;
                this.B0_S55_Export.Enabled = true;

                if (Banks[0].samples[54].common == true)
                {
                    this.B0_S55_Import.Enabled = false;
                    this.B0_S55_Common.Checked = true;
                }
                else
                {
                    this.B0_S55_Import.Enabled = true;
                    this.B0_S55_Common.Checked = false;
                }

                int start = Banks[0].samples[54].start;
                int id = Banks[0].samples[54].id;
                for (int i = 0; i < 127; i++)
                {
                    Sample smp = Banks[0].samples[i];
                    if (smp.enabled == true)
                    {
                        if (IsBetween(start, smp.start, smp.end))
                        {
                            if (Banks[0].samples[54].id > smp.id)
                            {
                                Banks[0].samples[smp.id].parents.Add(id);
                                Banks[0].samples[54].depends.Add(smp.id);
                                if (Banks[0].samples[54].depends.Count == 1)
                                {
                                    //find offset
                                    Banks[0].samples[54].offset = start - smp.start;
                                }
                            }
                        }
                    }
                }
                string deps = "";
                if (Banks[0].samples[54].common == true)
                {
                    Banks[0].samples[54].depends.Clear();
                    Banks[0].samples[54].offset = Banks[0].samples[54].start - 0x20000;
                }
                if (Banks[0].samples[54].depends.Count > 0)
                {
                    int dep = Banks[0].samples[54].depends[0];
                    {
                        deps = dep.ToString();
                    }

                }
                this.B0_S55_Dep.Text = deps;
                this.B0_S55_Off.Text = "0x" + Banks[0].samples[54].offset.ToString("x");
                this.B0_S55_Len.Text = "0x" + Banks[0].samples[54].length.ToString("x");
            }
            if (Banks[0].samples[55].enabled == true)
            {
                this.B0_S56_Enable.Enabled = true;
                this.B0_S56_Enable.Checked = true;
                this.B0_S56_Export.Enabled = true;

                if (Banks[0].samples[55].common == true)
                {
                    this.B0_S56_Import.Enabled = false;
                    this.B0_S56_Common.Checked = true;
                }
                else
                {
                    this.B0_S56_Import.Enabled = true;
                    this.B0_S56_Common.Checked = false;
                }

                int start = Banks[0].samples[55].start;
                int id = Banks[0].samples[55].id;
                for (int i = 0; i < 127; i++)
                {
                    Sample smp = Banks[0].samples[i];
                    if (smp.enabled == true)
                    {
                        if (IsBetween(start, smp.start, smp.end))
                        {
                            if (Banks[0].samples[55].id > smp.id)
                            {
                                Banks[0].samples[smp.id].parents.Add(id);
                                Banks[0].samples[55].depends.Add(smp.id);
                                if (Banks[0].samples[55].depends.Count == 1)
                                {
                                    //find offset
                                    Banks[0].samples[55].offset = start - smp.start;
                                }
                            }
                        }
                    }
                }
                string deps = "";
                if (Banks[0].samples[55].common == true)
                {
                    Banks[0].samples[55].depends.Clear();
                    Banks[0].samples[55].offset = Banks[0].samples[55].start - 0x20000;
                }
                if (Banks[0].samples[55].depends.Count > 0)
                {
                    int dep = Banks[0].samples[55].depends[0];
                    {
                        deps = dep.ToString();
                    }

                }
                this.B0_S56_Dep.Text = deps;
                this.B0_S56_Off.Text = "0x" + Banks[0].samples[55].offset.ToString("x");
                this.B0_S56_Len.Text = "0x" + Banks[0].samples[55].length.ToString("x");
            }
            if (Banks[0].samples[56].enabled == true)
            {
                this.B0_S57_Enable.Enabled = true;
                this.B0_S57_Enable.Checked = true;
                this.B0_S57_Export.Enabled = true;

                if (Banks[0].samples[56].common == true)
                {
                    this.B0_S57_Import.Enabled = false;
                    this.B0_S57_Common.Checked = true;
                }
                else
                {
                    this.B0_S57_Import.Enabled = true;
                    this.B0_S57_Common.Checked = false;
                }

                int start = Banks[0].samples[56].start;
                int id = Banks[0].samples[56].id;
                for (int i = 0; i < 127; i++)
                {
                    Sample smp = Banks[0].samples[i];
                    if (smp.enabled == true)
                    {
                        if (IsBetween(start, smp.start, smp.end))
                        {
                            if (Banks[0].samples[56].id > smp.id)
                            {
                                Banks[0].samples[smp.id].parents.Add(id);
                                Banks[0].samples[56].depends.Add(smp.id);
                                if (Banks[0].samples[56].depends.Count == 1)
                                {
                                    //find offset
                                    Banks[0].samples[56].offset = start - smp.start;
                                }
                            }
                        }
                    }
                }
                string deps = "";
                if (Banks[0].samples[56].common == true)
                {
                    Banks[0].samples[56].depends.Clear();
                    Banks[0].samples[56].offset = Banks[0].samples[56].start - 0x20000;
                }
                if (Banks[0].samples[56].depends.Count > 0)
                {
                    int dep = Banks[0].samples[56].depends[0];
                    {
                        deps = dep.ToString();
                    }

                }
                this.B0_S57_Dep.Text = deps;
                this.B0_S57_Off.Text = "0x" + Banks[0].samples[56].offset.ToString("x");
                this.B0_S57_Len.Text = "0x" + Banks[0].samples[56].length.ToString("x");
            }
            if (Banks[0].samples[57].enabled == true)
            {
                this.B0_S58_Enable.Enabled = true;
                this.B0_S58_Enable.Checked = true;
                this.B0_S58_Export.Enabled = true;

                if (Banks[0].samples[57].common == true)
                {
                    this.B0_S58_Import.Enabled = false;
                    this.B0_S58_Common.Checked = true;
                }
                else
                {
                    this.B0_S58_Import.Enabled = true;
                    this.B0_S58_Common.Checked = false;
                }

                int start = Banks[0].samples[57].start;
                int id = Banks[0].samples[57].id;
                for (int i = 0; i < 127; i++)
                {
                    Sample smp = Banks[0].samples[i];
                    if (smp.enabled == true)
                    {
                        if (IsBetween(start, smp.start, smp.end))
                        {
                            if (Banks[0].samples[57].id > smp.id)
                            {
                                Banks[0].samples[smp.id].parents.Add(id);
                                Banks[0].samples[57].depends.Add(smp.id);
                                if (Banks[0].samples[57].depends.Count == 1)
                                {
                                    //find offset
                                    Banks[0].samples[57].offset = start - smp.start;
                                }
                            }
                        }
                    }
                }
                string deps = "";
                if (Banks[0].samples[57].common == true)
                {
                    Banks[0].samples[57].depends.Clear();
                    Banks[0].samples[57].offset = Banks[0].samples[57].start - 0x20000;
                }
                if (Banks[0].samples[57].depends.Count > 0)
                {
                    int dep = Banks[0].samples[57].depends[0];
                    {
                        deps = dep.ToString();
                    }

                }
                this.B0_S58_Dep.Text = deps;
                this.B0_S58_Off.Text = "0x" + Banks[0].samples[57].offset.ToString("x");
                this.B0_S58_Len.Text = "0x" + Banks[0].samples[57].length.ToString("x");
            }
            if (Banks[0].samples[58].enabled == true)
            {
                this.B0_S59_Enable.Enabled = true;
                this.B0_S59_Enable.Checked = true;
                this.B0_S59_Export.Enabled = true;

                if (Banks[0].samples[58].common == true)
                {
                    this.B0_S59_Import.Enabled = false;
                    this.B0_S59_Common.Checked = true;
                }
                else
                {
                    this.B0_S59_Import.Enabled = true;
                    this.B0_S59_Common.Checked = false;
                }

                int start = Banks[0].samples[58].start;
                int id = Banks[0].samples[58].id;
                for (int i = 0; i < 127; i++)
                {
                    Sample smp = Banks[0].samples[i];
                    if (smp.enabled == true)
                    {
                        if (IsBetween(start, smp.start, smp.end))
                        {
                            if (Banks[0].samples[58].id > smp.id)
                            {
                                Banks[0].samples[smp.id].parents.Add(id);
                                Banks[0].samples[58].depends.Add(smp.id);
                                if (Banks[0].samples[58].depends.Count == 1)
                                {
                                    //find offset
                                    Banks[0].samples[58].offset = start - smp.start;
                                }
                            }
                        }
                    }
                }
                string deps = "";
                if (Banks[0].samples[58].common == true)
                {
                    Banks[0].samples[58].depends.Clear();
                    Banks[0].samples[58].offset = Banks[0].samples[58].start - 0x20000;
                }
                if (Banks[0].samples[58].depends.Count > 0)
                {
                    int dep = Banks[0].samples[58].depends[0];
                    {
                        deps = dep.ToString();
                    }

                }
                this.B0_S59_Dep.Text = deps;
                this.B0_S59_Off.Text = "0x" + Banks[0].samples[58].offset.ToString("x");
                this.B0_S59_Len.Text = "0x" + Banks[0].samples[58].length.ToString("x");
            }
            if (Banks[0].samples[59].enabled == true)
            {
                this.B0_S60_Enable.Enabled = true;
                this.B0_S60_Enable.Checked = true;
                this.B0_S60_Export.Enabled = true;

                if (Banks[0].samples[59].common == true)
                {
                    this.B0_S60_Import.Enabled = false;
                    this.B0_S60_Common.Checked = true;
                }
                else
                {
                    this.B0_S60_Import.Enabled = true;
                    this.B0_S60_Common.Checked = false;
                }

                int start = Banks[0].samples[59].start;
                int id = Banks[0].samples[59].id;
                for (int i = 0; i < 127; i++)
                {
                    Sample smp = Banks[0].samples[i];
                    if (smp.enabled == true)
                    {
                        if (IsBetween(start, smp.start, smp.end))
                        {
                            if (Banks[0].samples[59].id > smp.id)
                            {
                                Banks[0].samples[smp.id].parents.Add(id);
                                Banks[0].samples[59].depends.Add(smp.id);
                                if (Banks[0].samples[59].depends.Count == 1)
                                {
                                    //find offset
                                    Banks[0].samples[59].offset = start - smp.start;
                                }
                            }
                        }
                    }
                }
                string deps = "";
                if (Banks[0].samples[59].common == true)
                {
                    Banks[0].samples[59].depends.Clear();
                    Banks[0].samples[59].offset = Banks[0].samples[59].start - 0x20000;
                }
                if (Banks[0].samples[59].depends.Count > 0)
                {
                    int dep = Banks[0].samples[59].depends[0];
                    {
                        deps = dep.ToString();
                    }

                }
                this.B0_S60_Dep.Text = deps;
                this.B0_S60_Off.Text = "0x" + Banks[0].samples[59].offset.ToString("x");
                this.B0_S60_Len.Text = "0x" + Banks[0].samples[59].length.ToString("x");
            }
            if (Banks[0].samples[60].enabled == true)
            {
                this.B0_S61_Enable.Enabled = true;
                this.B0_S61_Enable.Checked = true;
                this.B0_S61_Export.Enabled = true;

                if (Banks[0].samples[60].common == true)
                {
                    this.B0_S61_Import.Enabled = false;
                    this.B0_S61_Common.Checked = true;
                }
                else
                {
                    this.B0_S61_Import.Enabled = true;
                    this.B0_S61_Common.Checked = false;
                }

                int start = Banks[0].samples[60].start;
                int id = Banks[0].samples[60].id;
                for (int i = 0; i < 127; i++)
                {
                    Sample smp = Banks[0].samples[i];
                    if (smp.enabled == true)
                    {
                        if (IsBetween(start, smp.start, smp.end))
                        {
                            if (Banks[0].samples[60].id > smp.id)
                            {
                                Banks[0].samples[smp.id].parents.Add(id);
                                Banks[0].samples[60].depends.Add(smp.id);
                                if (Banks[0].samples[60].depends.Count == 1)
                                {
                                    //find offset
                                    Banks[0].samples[60].offset = start - smp.start;
                                }
                            }
                        }
                    }
                }
                string deps = "";
                if (Banks[0].samples[60].common == true)
                {
                    Banks[0].samples[60].depends.Clear();
                    Banks[0].samples[60].offset = Banks[0].samples[60].start - 0x20000;
                }
                if (Banks[0].samples[60].depends.Count > 0)
                {
                    int dep = Banks[0].samples[60].depends[0];
                    {
                        deps = dep.ToString();
                    }
                }
                this.B0_S61_Dep.Text = deps;
                this.B0_S61_Off.Text = "0x" + Banks[0].samples[60].offset.ToString("x");
                this.B0_S61_Len.Text = "0x" + Banks[0].samples[60].length.ToString("x");
            }
            if (Banks[0].samples[61].enabled == true)
            {
                this.B0_S62_Enable.Enabled = true;
                this.B0_S62_Enable.Checked = true;
                this.B0_S62_Export.Enabled = true;

                if (Banks[0].samples[61].common == true)
                {
                    this.B0_S62_Import.Enabled = false;
                    this.B0_S62_Common.Checked = true;
                }
                else
                {
                    this.B0_S62_Import.Enabled = true;
                    this.B0_S62_Common.Checked = false;
                }

                int start = Banks[0].samples[61].start;
                int id = Banks[0].samples[61].id;
                for (int i = 0; i < 127; i++)
                {
                    Sample smp = Banks[0].samples[i];
                    if (smp.enabled == true)
                    {
                        if (IsBetween(start, smp.start, smp.end))
                        {
                            if (Banks[0].samples[61].id > smp.id)
                            {
                                Banks[0].samples[smp.id].parents.Add(id);
                                Banks[0].samples[61].depends.Add(smp.id);
                                if (Banks[0].samples[61].depends.Count == 1)
                                {
                                    //find offset
                                    Banks[0].samples[61].offset = start - smp.start;
                                }
                            }
                        }
                    }
                }
                string deps = "";
                if (Banks[0].samples[61].common == true)
                {
                    Banks[0].samples[61].depends.Clear();
                    Banks[0].samples[61].offset = Banks[0].samples[61].start - 0x20000;
                }
                if (Banks[0].samples[61].depends.Count > 0)
                {
                    int dep = Banks[0].samples[61].depends[0];
                    {
                        deps = dep.ToString();
                    }
                }
                this.B0_S62_Dep.Text = deps;
                this.B0_S62_Off.Text = "0x" + Banks[0].samples[61].offset.ToString("x");
                this.B0_S62_Len.Text = "0x" + Banks[0].samples[61].length.ToString("x");
            }
            if (Banks[0].samples[62].enabled == true)
            {
                this.B0_S63_Enable.Enabled = true;
                this.B0_S63_Enable.Checked = true;
                this.B0_S63_Export.Enabled = true;

                if (Banks[0].samples[62].common == true)
                {
                    this.B0_S63_Import.Enabled = false;
                    this.B0_S63_Common.Checked = true;
                }
                else
                {
                    this.B0_S63_Import.Enabled = true;
                    this.B0_S63_Common.Checked = false;
                }

                int start = Banks[0].samples[62].start;
                int id = Banks[0].samples[62].id;
                for (int i = 0; i < 127; i++)
                {
                    Sample smp = Banks[0].samples[i];
                    if (smp.enabled == true)
                    {
                        if (IsBetween(start, smp.start, smp.end))
                        {
                            if (Banks[0].samples[62].id > smp.id)
                            {
                                Banks[0].samples[smp.id].parents.Add(id);
                                Banks[0].samples[62].depends.Add(smp.id);
                                if (Banks[0].samples[62].depends.Count == 1)
                                {
                                    //find offset
                                    Banks[0].samples[62].offset = start - smp.start;
                                }
                            }
                        }
                    }
                }
                string deps = "";
                if (Banks[0].samples[62].common == true)
                {
                    Banks[0].samples[62].depends.Clear();
                    Banks[0].samples[62].offset = Banks[0].samples[62].start - 0x20000;
                }

                if (Banks[0].samples[62].depends.Count > 0)
                {
                    int dep = Banks[0].samples[62].depends[0];
                    {
                        deps = dep.ToString();
                    }

                }
                this.B0_S63_Dep.Text = deps;
                this.B0_S63_Off.Text = "0x" + Banks[0].samples[62].offset.ToString("x");
                this.B0_S63_Len.Text = "0x" + Banks[0].samples[62].length.ToString("x");
            }
            if (Banks[0].samples[63].enabled == true)
            {
                this.B0_S64_Enable.Enabled = true;
                this.B0_S64_Enable.Checked = true;
                this.B0_S64_Export.Enabled = true;

                if (Banks[0].samples[63].common == true)
                {
                    this.B0_S64_Import.Enabled = false;
                    this.B0_S64_Common.Checked = true;
                }
                else
                {
                    this.B0_S64_Import.Enabled = true;
                    this.B0_S64_Common.Checked = false;
                }

                int start = Banks[0].samples[63].start;
                int id = Banks[0].samples[63].id;
                for (int i = 0; i < 127; i++)
                {
                    Sample smp = Banks[0].samples[i];
                    if (smp.enabled == true)
                    {
                        if (IsBetween(start, smp.start, smp.end))
                        {
                            if (Banks[0].samples[63].id > smp.id)
                            {
                                Banks[0].samples[smp.id].parents.Add(id);
                                Banks[0].samples[63].depends.Add(smp.id);
                                if (Banks[0].samples[63].depends.Count == 1)
                                {
                                    //find offset
                                    Banks[0].samples[63].offset = start - smp.start;
                                }
                            }
                        }
                    }
                }
                string deps = "";
                if (Banks[0].samples[63].common == true)
                {
                    Banks[0].samples[63].depends.Clear();
                    Banks[0].samples[63].offset = Banks[0].samples[63].start - 0x20000;
                }
                if (Banks[0].samples[63].depends.Count > 0)
                {
                    int dep = Banks[0].samples[63].depends[0];
                    {
                        deps = dep.ToString();
                    }

                }
                this.B0_S64_Dep.Text = deps;
                this.B0_S64_Off.Text = "0x" + Banks[0].samples[63].offset.ToString("x");
                this.B0_S64_Len.Text = "0x" + Banks[0].samples[63].length.ToString("x");
            }
            if (Banks[0].samples[64].enabled == true)
            {
                this.B0_S65_Enable.Enabled = true;
                this.B0_S65_Enable.Checked = true;
                this.B0_S65_Export.Enabled = true;

                if (Banks[0].samples[64].common == true)
                {
                    this.B0_S65_Import.Enabled = false;
                    this.B0_S65_Common.Checked = true;
                }
                else
                {
                    this.B0_S65_Import.Enabled = true;
                    this.B0_S65_Common.Checked = false;
                }

                int start = Banks[0].samples[64].start;
                int id = Banks[0].samples[64].id;
                for (int i = 0; i < 127; i++)
                {
                    Sample smp = Banks[0].samples[i];
                    if (smp.enabled == true)
                    {
                        if (IsBetween(start, smp.start, smp.end))
                        {
                            if (Banks[0].samples[64].id > smp.id)
                            {
                                Banks[0].samples[smp.id].parents.Add(id);
                                Banks[0].samples[64].depends.Add(smp.id);
                                if (Banks[0].samples[64].depends.Count == 1)
                                {
                                    //find offset
                                    Banks[0].samples[64].offset = start - smp.start;
                                }
                            }
                        }
                    }
                }
                string deps = "";
                if (Banks[0].samples[64].common == true)
                {
                    Banks[0].samples[64].depends.Clear();
                    Banks[0].samples[64].offset = Banks[0].samples[64].start - 0x20000;
                }
                if (Banks[0].samples[64].depends.Count > 0)
                {
                    int dep = Banks[0].samples[64].depends[0];
                    {
                        deps = dep.ToString();
                    }

                }
                this.B0_S65_Dep.Text = deps;
                this.B0_S65_Off.Text = "0x" + Banks[0].samples[64].offset.ToString("x");
                this.B0_S65_Len.Text = "0x" + Banks[0].samples[64].length.ToString("x");
            }
            if (Banks[0].samples[65].enabled == true)
            {
                this.B0_S66_Enable.Enabled = true;
                this.B0_S66_Enable.Checked = true;
                this.B0_S66_Export.Enabled = true;

                if (Banks[0].samples[65].common == true)
                {
                    this.B0_S66_Import.Enabled = false;
                    this.B0_S66_Common.Checked = true;
                }
                else
                {
                    this.B0_S66_Import.Enabled = true;
                    this.B0_S66_Common.Checked = false;
                }

                int start = Banks[0].samples[65].start;
                int id = Banks[0].samples[65].id;
                for (int i = 0; i < 127; i++)
                {
                    Sample smp = Banks[0].samples[i];
                    if (smp.enabled == true)
                    {
                        if (IsBetween(start, smp.start, smp.end))
                        {
                            if (Banks[0].samples[65].id > smp.id)
                            {
                                Banks[0].samples[smp.id].parents.Add(id);
                                Banks[0].samples[65].depends.Add(smp.id);
                                if (Banks[0].samples[65].depends.Count == 1)
                                {
                                    //find offset
                                    Banks[0].samples[65].offset = start - smp.start;
                                }
                            }
                        }
                    }
                }
                string deps = "";
                if (Banks[0].samples[65].common == true)
                {
                    Banks[0].samples[65].depends.Clear();
                    Banks[0].samples[65].offset = Banks[0].samples[65].start - 0x20000;
                }
                if (Banks[0].samples[65].depends.Count > 0)
                {
                    int dep = Banks[0].samples[65].depends[0];
                    {
                        deps = dep.ToString();
                    }

                }
                this.B0_S66_Dep.Text = deps;
                this.B0_S66_Off.Text = "0x" + Banks[0].samples[65].offset.ToString("x");
                this.B0_S66_Len.Text = "0x" + Banks[0].samples[65].length.ToString("x");
            }
            if (Banks[0].samples[66].enabled == true)
            {
                this.B0_S67_Enable.Enabled = true;
                this.B0_S67_Enable.Checked = true;
                this.B0_S67_Export.Enabled = true;

                if (Banks[0].samples[66].common == true)
                {
                    this.B0_S67_Import.Enabled = false;
                    this.B0_S67_Common.Checked = true;
                }
                else
                {
                    this.B0_S67_Import.Enabled = true;
                    this.B0_S67_Common.Checked = false;
                }

                int start = Banks[0].samples[66].start;
                int id = Banks[0].samples[66].id;
                for (int i = 0; i < 127; i++)
                {
                    Sample smp = Banks[0].samples[i];
                    if (smp.enabled == true)
                    {
                        if (IsBetween(start, smp.start, smp.end))
                        {
                            if (Banks[0].samples[66].id > smp.id)
                            {
                                Banks[0].samples[smp.id].parents.Add(id);
                                Banks[0].samples[66].depends.Add(smp.id);
                                if (Banks[0].samples[66].depends.Count == 1)
                                {
                                    //find offset
                                    Banks[0].samples[66].offset = start - smp.start;
                                }
                            }
                        }
                    }
                }
                string deps = "";
                if (Banks[0].samples[66].common == true)
                {
                    Banks[0].samples[66].depends.Clear();
                    Banks[0].samples[66].offset = Banks[0].samples[66].start - 0x20000;
                }
                if (Banks[0].samples[66].depends.Count > 0)
                {
                    int dep = Banks[0].samples[66].depends[0];
                    {
                        deps = dep.ToString();
                    }

                }
                this.B0_S67_Dep.Text = deps;
                this.B0_S67_Off.Text = "0x" + Banks[0].samples[66].offset.ToString("x");
                this.B0_S67_Len.Text = "0x" + Banks[0].samples[66].length.ToString("x");
            }
            if (Banks[0].samples[67].enabled == true)
            {
                this.B0_S68_Enable.Enabled = true;
                this.B0_S68_Enable.Checked = true;
                this.B0_S68_Export.Enabled = true;

                if (Banks[0].samples[67].common == true)
                {
                    this.B0_S68_Import.Enabled = false;
                    this.B0_S68_Common.Checked = true;
                }
                else
                {
                    this.B0_S68_Import.Enabled = true;
                    this.B0_S68_Common.Checked = false;
                }

                int start = Banks[0].samples[67].start;
                int id = Banks[0].samples[67].id;
                for (int i = 0; i < 127; i++)
                {
                    Sample smp = Banks[0].samples[i];
                    if (smp.enabled == true)
                    {
                        if (IsBetween(start, smp.start, smp.end))
                        {
                            if (Banks[0].samples[67].id > smp.id)
                            {
                                Banks[0].samples[smp.id].parents.Add(id);
                                Banks[0].samples[67].depends.Add(smp.id);
                                if (Banks[0].samples[67].depends.Count == 1)
                                {
                                    //find offset
                                    Banks[0].samples[67].offset = start - smp.start;
                                }
                            }
                        }
                    }
                }
                string deps = "";
                if (Banks[0].samples[67].common == true)
                {
                    Banks[0].samples[67].depends.Clear();
                    Banks[0].samples[67].offset = Banks[0].samples[67].start - 0x20000;
                }
                if (Banks[0].samples[67].depends.Count > 0)
                {
                    int dep = Banks[0].samples[67].depends[0];
                    {
                        deps = dep.ToString();
                    }

                }
                this.B0_S68_Dep.Text = deps;
                this.B0_S68_Off.Text = "0x" + Banks[0].samples[67].offset.ToString("x");
                this.B0_S68_Len.Text = "0x" + Banks[0].samples[67].length.ToString("x");
            }
            if (Banks[0].samples[68].enabled == true)
            {
                this.B0_S69_Enable.Enabled = true;
                this.B0_S69_Enable.Checked = true;
                this.B0_S69_Export.Enabled = true;

                if (Banks[0].samples[68].common == true)
                {
                    this.B0_S69_Import.Enabled = false;
                    this.B0_S69_Common.Checked = true;
                }
                else
                {
                    this.B0_S69_Import.Enabled = true;
                    this.B0_S69_Common.Checked = false;
                }

                int start = Banks[0].samples[68].start;
                int id = Banks[0].samples[68].id;
                for (int i = 0; i < 127; i++)
                {
                    Sample smp = Banks[0].samples[i];
                    if (smp.enabled == true)
                    {
                        if (IsBetween(start, smp.start, smp.end))
                        {
                            if (Banks[0].samples[68].id > smp.id)
                            {
                                Banks[0].samples[smp.id].parents.Add(id);
                                Banks[0].samples[68].depends.Add(smp.id);
                                if (Banks[0].samples[68].depends.Count == 1)
                                {
                                    //find offset
                                    Banks[0].samples[68].offset = start - smp.start;
                                }
                            }
                        }
                    }
                }
                string deps = "";
                if (Banks[0].samples[68].common == true)
                {
                    Banks[0].samples[68].depends.Clear();
                    Banks[0].samples[68].offset = Banks[0].samples[68].start - 0x20000;
                }
                if (Banks[0].samples[68].depends.Count > 0)
                {
                    int dep = Banks[0].samples[68].depends[0];
                    {
                        deps = dep.ToString();
                    }

                }
                this.B0_S69_Dep.Text = deps;
                this.B0_S69_Off.Text = "0x" + Banks[0].samples[68].offset.ToString("x");
                this.B0_S69_Len.Text = "0x" + Banks[0].samples[68].length.ToString("x");
            }
            if (Banks[0].samples[69].enabled == true)
            {
                this.B0_S70_Enable.Enabled = true;
                this.B0_S70_Enable.Checked = true;
                this.B0_S70_Export.Enabled = true;

                if (Banks[0].samples[69].common == true)
                {
                    this.B0_S70_Import.Enabled = false;
                    this.B0_S70_Common.Checked = true;
                }
                else
                {
                    this.B0_S70_Import.Enabled = true;
                    this.B0_S70_Common.Checked = false;
                }

                int start = Banks[0].samples[69].start;
                int id = Banks[0].samples[69].id;
                for (int i = 0; i < 127; i++)
                {
                    Sample smp = Banks[0].samples[i];
                    if (smp.enabled == true)
                    {
                        if (IsBetween(start, smp.start, smp.end))
                        {
                            if (Banks[0].samples[69].id > smp.id)
                            {
                                Banks[0].samples[smp.id].parents.Add(id);
                                Banks[0].samples[69].depends.Add(smp.id);
                                if (Banks[0].samples[69].depends.Count == 1)
                                {
                                    //find offset
                                    Banks[0].samples[69].offset = start - smp.start;
                                }
                            }
                        }
                    }
                }
                string deps = "";
                if (Banks[0].samples[69].common == true)
                {
                    Banks[0].samples[69].depends.Clear();
                    Banks[0].samples[69].offset = Banks[0].samples[69].start - 0x20000;
                }
                if (Banks[0].samples[69].depends.Count > 0)
                {
                    int dep = Banks[0].samples[69].depends[0];
                    {
                        deps = dep.ToString();
                    }

                }
                this.B0_S70_Dep.Text = deps;
                this.B0_S70_Off.Text = "0x" + Banks[0].samples[69].offset.ToString("x");
                this.B0_S70_Len.Text = "0x" + Banks[0].samples[69].length.ToString("x");
            }
            if (Banks[0].samples[70].enabled == true)
            {
                this.B0_S71_Enable.Enabled = true;
                this.B0_S71_Enable.Checked = true;
                this.B0_S71_Export.Enabled = true;

                if (Banks[0].samples[70].common == true)
                {
                    this.B0_S71_Import.Enabled = false;
                    this.B0_S71_Common.Checked = true;
                }
                else
                {
                    this.B0_S71_Import.Enabled = true;
                    this.B0_S71_Common.Checked = false;
                }

                int start = Banks[0].samples[70].start;
                int id = Banks[0].samples[70].id;
                for (int i = 0; i < 127; i++)
                {
                    Sample smp = Banks[0].samples[i];
                    if (smp.enabled == true)
                    {
                        if (IsBetween(start, smp.start, smp.end))
                        {
                            if (Banks[0].samples[70].id > smp.id)
                            {
                                Banks[0].samples[smp.id].parents.Add(id);
                                Banks[0].samples[70].depends.Add(smp.id);
                                if (Banks[0].samples[70].depends.Count == 1)
                                {
                                    //find offset
                                    Banks[0].samples[70].offset = start - smp.start;
                                }
                            }
                        }
                    }
                }
                string deps = "";
                if (Banks[0].samples[70].common == true)
                {
                    Banks[0].samples[70].depends.Clear();
                    Banks[0].samples[70].offset = Banks[0].samples[70].start - 0x20000;
                }
                if (Banks[0].samples[70].depends.Count > 0)
                {
                    int dep = Banks[0].samples[70].depends[0];
                    {
                        deps = dep.ToString();
                    }
                }
                this.B0_S71_Dep.Text = deps;
                this.B0_S71_Off.Text = "0x" + Banks[0].samples[70].offset.ToString("x");
                this.B0_S71_Len.Text = "0x" + Banks[0].samples[70].length.ToString("x");
            }
            if (Banks[0].samples[71].enabled == true)
            {
                this.B0_S72_Enable.Enabled = true;
                this.B0_S72_Enable.Checked = true;
                this.B0_S72_Export.Enabled = true;

                if (Banks[0].samples[71].common == true)
                {
                    this.B0_S72_Import.Enabled = false;
                    this.B0_S72_Common.Checked = true;
                }
                else
                {
                    this.B0_S72_Import.Enabled = true;
                    this.B0_S72_Common.Checked = false;
                }

                int start = Banks[0].samples[71].start;
                int id = Banks[0].samples[71].id;
                for (int i = 0; i < 127; i++)
                {
                    Sample smp = Banks[0].samples[i];
                    if (smp.enabled == true)
                    {
                        if (IsBetween(start, smp.start, smp.end))
                        {
                            if (Banks[0].samples[71].id > smp.id)
                            {
                                Banks[0].samples[smp.id].parents.Add(id);
                                Banks[0].samples[71].depends.Add(smp.id);
                                if (Banks[0].samples[71].depends.Count == 1)
                                {
                                    //find offset
                                    Banks[0].samples[71].offset = start - smp.start;
                                }
                            }
                        }
                    }
                }
                string deps = "";
                if (Banks[0].samples[71].common == true)
                {
                    Banks[0].samples[71].depends.Clear();
                    Banks[0].samples[71].offset = Banks[0].samples[71].start - 0x20000;
                }
                if (Banks[0].samples[71].depends.Count > 0)
                {
                    int dep = Banks[0].samples[71].depends[0];
                    {
                        deps = dep.ToString();
                    }
                }
                this.B0_S72_Dep.Text = deps;
                this.B0_S72_Off.Text = "0x" + Banks[0].samples[71].offset.ToString("x");
                this.B0_S72_Len.Text = "0x" + Banks[0].samples[71].length.ToString("x");
            }
            if (Banks[0].samples[72].enabled == true)
            {
                this.B0_S73_Enable.Enabled = true;
                this.B0_S73_Enable.Checked = true;
                this.B0_S73_Export.Enabled = true;

                if (Banks[0].samples[72].common == true)
                {
                    this.B0_S73_Import.Enabled = false;
                    this.B0_S73_Common.Checked = true;
                }
                else
                {
                    this.B0_S73_Import.Enabled = true;
                    this.B0_S73_Common.Checked = false;
                }

                int start = Banks[0].samples[72].start;
                int id = Banks[0].samples[72].id;
                for (int i = 0; i < 127; i++)
                {
                    Sample smp = Banks[0].samples[i];
                    if (smp.enabled == true)
                    {
                        if (IsBetween(start, smp.start, smp.end))
                        {
                            if (Banks[0].samples[72].id > smp.id)
                            {
                                Banks[0].samples[smp.id].parents.Add(id);
                                Banks[0].samples[72].depends.Add(smp.id);
                                if (Banks[0].samples[72].depends.Count == 1)
                                {
                                    //find offset
                                    Banks[0].samples[72].offset = start - smp.start;
                                }
                            }
                        }
                    }
                }
                string deps = "";
                if (Banks[0].samples[72].common == true)
                {
                    Banks[0].samples[72].depends.Clear();
                    Banks[0].samples[72].offset = Banks[0].samples[72].start - 0x20000;
                }

                if (Banks[0].samples[72].depends.Count > 0)
                {
                    int dep = Banks[0].samples[72].depends[0];
                    {
                        deps = dep.ToString();
                    }

                }
                this.B0_S73_Dep.Text = deps;
                this.B0_S73_Off.Text = "0x" + Banks[0].samples[72].offset.ToString("x");
                this.B0_S73_Len.Text = "0x" + Banks[0].samples[72].length.ToString("x");
            }
            if (Banks[0].samples[73].enabled == true)
            {
                this.B0_S74_Enable.Enabled = true;
                this.B0_S74_Enable.Checked = true;
                this.B0_S74_Export.Enabled = true;

                if (Banks[0].samples[73].common == true)
                {
                    this.B0_S74_Import.Enabled = false;
                    this.B0_S74_Common.Checked = true;
                }
                else
                {
                    this.B0_S74_Import.Enabled = true;
                    this.B0_S74_Common.Checked = false;
                }

                int start = Banks[0].samples[73].start;
                int id = Banks[0].samples[73].id;
                for (int i = 0; i < 127; i++)
                {
                    Sample smp = Banks[0].samples[i];
                    if (smp.enabled == true)
                    {
                        if (IsBetween(start, smp.start, smp.end))
                        {
                            if (Banks[0].samples[73].id > smp.id)
                            {
                                Banks[0].samples[smp.id].parents.Add(id);
                                Banks[0].samples[73].depends.Add(smp.id);
                                if (Banks[0].samples[73].depends.Count == 1)
                                {
                                    //find offset
                                    Banks[0].samples[73].offset = start - smp.start;
                                }
                            }
                        }
                    }
                }
                string deps = "";
                if (Banks[0].samples[73].common == true)
                {
                    Banks[0].samples[73].depends.Clear();
                    Banks[0].samples[73].offset = Banks[0].samples[73].start - 0x20000;
                }
                if (Banks[0].samples[73].depends.Count > 0)
                {
                    int dep = Banks[0].samples[73].depends[0];
                    {
                        deps = dep.ToString();
                    }

                }
                this.B0_S74_Dep.Text = deps;
                this.B0_S74_Off.Text = "0x" + Banks[0].samples[73].offset.ToString("x");
                this.B0_S74_Len.Text = "0x" + Banks[0].samples[73].length.ToString("x");
            }
            if (Banks[0].samples[74].enabled == true)
            {
                this.B0_S75_Enable.Enabled = true;
                this.B0_S75_Enable.Checked = true;
                this.B0_S75_Export.Enabled = true;

                if (Banks[0].samples[74].common == true)
                {
                    this.B0_S75_Import.Enabled = false;
                    this.B0_S75_Common.Checked = true;
                }
                else
                {
                    this.B0_S75_Import.Enabled = true;
                    this.B0_S75_Common.Checked = false;
                }

                int start = Banks[0].samples[74].start;
                int id = Banks[0].samples[74].id;
                for (int i = 0; i < 127; i++)
                {
                    Sample smp = Banks[0].samples[i];
                    if (smp.enabled == true)
                    {
                        if (IsBetween(start, smp.start, smp.end))
                        {
                            if (Banks[0].samples[74].id > smp.id)
                            {
                                Banks[0].samples[smp.id].parents.Add(id);
                                Banks[0].samples[74].depends.Add(smp.id);
                                if (Banks[0].samples[74].depends.Count == 1)
                                {
                                    //find offset
                                    Banks[0].samples[74].offset = start - smp.start;
                                }
                            }
                        }
                    }
                }
                string deps = "";
                if (Banks[0].samples[74].common == true)
                {
                    Banks[0].samples[74].depends.Clear();
                    Banks[0].samples[74].offset = Banks[0].samples[74].start - 0x20000;
                }
                if (Banks[0].samples[74].depends.Count > 0)
                {
                    int dep = Banks[0].samples[74].depends[0];
                    {
                        deps = dep.ToString();
                    }

                }
                this.B0_S75_Dep.Text = deps;
                this.B0_S75_Off.Text = "0x" + Banks[0].samples[74].offset.ToString("x");
                this.B0_S75_Len.Text = "0x" + Banks[0].samples[74].length.ToString("x");
            }
            if (Banks[0].samples[75].enabled == true)
            {
                this.B0_S76_Enable.Enabled = true;
                this.B0_S76_Enable.Checked = true;
                this.B0_S76_Export.Enabled = true;

                if (Banks[0].samples[75].common == true)
                {
                    this.B0_S76_Import.Enabled = false;
                    this.B0_S76_Common.Checked = true;
                }
                else
                {
                    this.B0_S76_Import.Enabled = true;
                    this.B0_S76_Common.Checked = false;
                }

                int start = Banks[0].samples[75].start;
                int id = Banks[0].samples[75].id;
                for (int i = 0; i < 127; i++)
                {
                    Sample smp = Banks[0].samples[i];
                    if (smp.enabled == true)
                    {
                        if (IsBetween(start, smp.start, smp.end))
                        {
                            if (Banks[0].samples[75].id > smp.id)
                            {
                                Banks[0].samples[smp.id].parents.Add(id);
                                Banks[0].samples[75].depends.Add(smp.id);
                                if (Banks[0].samples[75].depends.Count == 1)
                                {
                                    //find offset
                                    Banks[0].samples[75].offset = start - smp.start;
                                }
                            }
                        }
                    }
                }
                string deps = "";
                if (Banks[0].samples[75].common == true)
                {
                    Banks[0].samples[75].depends.Clear();
                    Banks[0].samples[75].offset = Banks[0].samples[75].start - 0x20000;
                }
                if (Banks[0].samples[75].depends.Count > 0)
                {
                    int dep = Banks[0].samples[75].depends[0];
                    {
                        deps = dep.ToString();
                    }

                }
                this.B0_S76_Dep.Text = deps;
                this.B0_S76_Off.Text = "0x" + Banks[0].samples[75].offset.ToString("x");
                this.B0_S76_Len.Text = "0x" + Banks[0].samples[75].length.ToString("x");
            }
            if (Banks[0].samples[76].enabled == true)
            {
                this.B0_S77_Enable.Enabled = true;
                this.B0_S77_Enable.Checked = true;
                this.B0_S77_Export.Enabled = true;

                if (Banks[0].samples[76].common == true)
                {
                    this.B0_S77_Import.Enabled = false;
                    this.B0_S77_Common.Checked = true;
                }
                else
                {
                    this.B0_S77_Import.Enabled = true;
                    this.B0_S77_Common.Checked = false;
                }

                int start = Banks[0].samples[76].start;
                int id = Banks[0].samples[76].id;
                for (int i = 0; i < 127; i++)
                {
                    Sample smp = Banks[0].samples[i];
                    if (smp.enabled == true)
                    {
                        if (IsBetween(start, smp.start, smp.end))
                        {
                            if (Banks[0].samples[76].id > smp.id)
                            {
                                Banks[0].samples[smp.id].parents.Add(id);
                                Banks[0].samples[76].depends.Add(smp.id);
                                if (Banks[0].samples[76].depends.Count == 1)
                                {
                                    //find offset
                                    Banks[0].samples[76].offset = start - smp.start;
                                }
                            }
                        }
                    }
                }
                string deps = "";
                if (Banks[0].samples[76].common == true)
                {
                    Banks[0].samples[76].depends.Clear();
                    Banks[0].samples[76].offset = Banks[0].samples[76].start - 0x20000;
                }
                if (Banks[0].samples[76].depends.Count > 0)
                {
                    int dep = Banks[0].samples[76].depends[0];
                    {
                        deps = dep.ToString();
                    }

                }
                this.B0_S77_Dep.Text = deps;
                this.B0_S77_Off.Text = "0x" + Banks[0].samples[76].offset.ToString("x");
                this.B0_S77_Len.Text = "0x" + Banks[0].samples[76].length.ToString("x");
            }
            if (Banks[0].samples[77].enabled == true)
            {
                this.B0_S78_Enable.Enabled = true;
                this.B0_S78_Enable.Checked = true;
                this.B0_S78_Export.Enabled = true;

                if (Banks[0].samples[77].common == true)
                {
                    this.B0_S78_Import.Enabled = false;
                    this.B0_S78_Common.Checked = true;
                }
                else
                {
                    this.B0_S78_Import.Enabled = true;
                    this.B0_S78_Common.Checked = false;
                }

                int start = Banks[0].samples[77].start;
                int id = Banks[0].samples[77].id;
                for (int i = 0; i < 127; i++)
                {
                    Sample smp = Banks[0].samples[i];
                    if (smp.enabled == true)
                    {
                        if (IsBetween(start, smp.start, smp.end))
                        {
                            if (Banks[0].samples[77].id > smp.id)
                            {
                                Banks[0].samples[smp.id].parents.Add(id);
                                Banks[0].samples[77].depends.Add(smp.id);
                                if (Banks[0].samples[77].depends.Count == 1)
                                {
                                    //find offset
                                    Banks[0].samples[77].offset = start - smp.start;
                                }
                            }
                        }
                    }
                }
                string deps = "";
                if (Banks[0].samples[77].common == true)
                {
                    Banks[0].samples[77].depends.Clear();
                    Banks[0].samples[77].offset = Banks[0].samples[77].start - 0x20000;
                }
                if (Banks[0].samples[77].depends.Count > 0)
                {
                    int dep = Banks[0].samples[77].depends[0];
                    {
                        deps = dep.ToString();
                    }

                }
                this.B0_S78_Dep.Text = deps;
                this.B0_S78_Off.Text = "0x" + Banks[0].samples[77].offset.ToString("x");
                this.B0_S78_Len.Text = "0x" + Banks[0].samples[77].length.ToString("x");
            }
            if (Banks[0].samples[78].enabled == true)
            {
                this.B0_S79_Enable.Enabled = true;
                this.B0_S79_Enable.Checked = true;
                this.B0_S79_Export.Enabled = true;

                if (Banks[0].samples[78].common == true)
                {
                    this.B0_S79_Import.Enabled = false;
                    this.B0_S79_Common.Checked = true;
                }
                else
                {
                    this.B0_S79_Import.Enabled = true;
                    this.B0_S79_Common.Checked = false;
                }

                int start = Banks[0].samples[78].start;
                int id = Banks[0].samples[78].id;
                for (int i = 0; i < 127; i++)
                {
                    Sample smp = Banks[0].samples[i];
                    if (smp.enabled == true)
                    {
                        if (IsBetween(start, smp.start, smp.end))
                        {
                            if (Banks[0].samples[78].id > smp.id)
                            {
                                Banks[0].samples[smp.id].parents.Add(id);
                                Banks[0].samples[78].depends.Add(smp.id);
                                if (Banks[0].samples[78].depends.Count == 1)
                                {
                                    //find offset
                                    Banks[0].samples[78].offset = start - smp.start;
                                }
                            }
                        }
                    }
                }
                string deps = "";
                if (Banks[0].samples[78].common == true)
                {
                    Banks[0].samples[78].depends.Clear();
                    Banks[0].samples[78].offset = Banks[0].samples[78].start - 0x20000;
                }
                if (Banks[0].samples[78].depends.Count > 0)
                {
                    int dep = Banks[0].samples[78].depends[0];
                    {
                        deps = dep.ToString();
                    }

                }
                this.B0_S79_Dep.Text = deps;
                this.B0_S79_Off.Text = "0x" + Banks[0].samples[78].offset.ToString("x");
                this.B0_S79_Len.Text = "0x" + Banks[0].samples[78].length.ToString("x");
            }
            if (Banks[0].samples[79].enabled == true)
            {
                this.B0_S80_Enable.Enabled = true;
                this.B0_S80_Enable.Checked = true;
                this.B0_S80_Export.Enabled = true;

                if (Banks[0].samples[79].common == true)
                {
                    this.B0_S80_Import.Enabled = false;
                    this.B0_S80_Common.Checked = true;
                }
                else
                {
                    this.B0_S80_Import.Enabled = true;
                    this.B0_S80_Common.Checked = false;
                }

                int start = Banks[0].samples[79].start;
                int id = Banks[0].samples[79].id;
                for (int i = 0; i < 127; i++)
                {
                    Sample smp = Banks[0].samples[i];
                    if (smp.enabled == true)
                    {
                        if (IsBetween(start, smp.start, smp.end))
                        {
                            if (Banks[0].samples[79].id > smp.id)
                            {
                                Banks[0].samples[smp.id].parents.Add(id);
                                Banks[0].samples[79].depends.Add(smp.id);
                                if (Banks[0].samples[79].depends.Count == 1)
                                {
                                    //find offset
                                    Banks[0].samples[79].offset = start - smp.start;
                                }
                            }
                        }
                    }
                }
                string deps = "";
                if (Banks[0].samples[79].common == true)
                {
                    Banks[0].samples[79].depends.Clear();
                    Banks[0].samples[79].offset = Banks[0].samples[79].start - 0x20000;
                }
                if (Banks[0].samples[79].depends.Count > 0)
                {
                    int dep = Banks[0].samples[79].depends[0];
                    {
                        deps = dep.ToString();
                    }

                }
                this.B0_S80_Dep.Text = deps;
                this.B0_S80_Off.Text = "0x" + Banks[0].samples[79].offset.ToString("x");
                this.B0_S80_Len.Text = "0x" + Banks[0].samples[79].length.ToString("x");
            }
            if (Banks[0].samples[80].enabled == true)
            {
                this.B0_S81_Enable.Enabled = true;
                this.B0_S81_Enable.Checked = true;
                this.B0_S81_Export.Enabled = true;

                if (Banks[0].samples[80].common == true)
                {
                    this.B0_S81_Import.Enabled = false;
                    this.B0_S81_Common.Checked = true;
                }
                else
                {
                    this.B0_S81_Import.Enabled = true;
                    this.B0_S81_Common.Checked = false;
                }

                int start = Banks[0].samples[80].start;
                int id = Banks[0].samples[80].id;
                for (int i = 0; i < 127; i++)
                {
                    Sample smp = Banks[0].samples[i];
                    if (smp.enabled == true)
                    {
                        if (IsBetween(start, smp.start, smp.end))
                        {
                            if (Banks[0].samples[80].id > smp.id)
                            {
                                Banks[0].samples[smp.id].parents.Add(id);
                                Banks[0].samples[80].depends.Add(smp.id);
                                if (Banks[0].samples[80].depends.Count == 1)
                                {
                                    //find offset
                                    Banks[0].samples[80].offset = start - smp.start;
                                }
                            }
                        }
                    }
                }
                string deps = "";
                if (Banks[0].samples[80].common == true)
                {
                    Banks[0].samples[80].depends.Clear();
                    Banks[0].samples[80].offset = Banks[0].samples[80].start - 0x20000;
                }
                if (Banks[0].samples[80].depends.Count > 0)
                {
                    int dep = Banks[0].samples[80].depends[0];
                    {
                        deps = dep.ToString();
                    }
                }
                this.B0_S81_Dep.Text = deps;
                this.B0_S81_Off.Text = "0x" + Banks[0].samples[80].offset.ToString("x");
                this.B0_S81_Len.Text = "0x" + Banks[0].samples[80].length.ToString("x");
            }
            if (Banks[0].samples[81].enabled == true)
            {
                this.B0_S82_Enable.Enabled = true;
                this.B0_S82_Enable.Checked = true;
                this.B0_S82_Export.Enabled = true;

                if (Banks[0].samples[81].common == true)
                {
                    this.B0_S82_Import.Enabled = false;
                    this.B0_S82_Common.Checked = true;
                }
                else
                {
                    this.B0_S82_Import.Enabled = true;
                    this.B0_S82_Common.Checked = false;
                }

                int start = Banks[0].samples[81].start;
                int id = Banks[0].samples[81].id;
                for (int i = 0; i < 127; i++)
                {
                    Sample smp = Banks[0].samples[i];
                    if (smp.enabled == true)
                    {
                        if (IsBetween(start, smp.start, smp.end))
                        {
                            if (Banks[0].samples[81].id > smp.id)
                            {
                                Banks[0].samples[smp.id].parents.Add(id);
                                Banks[0].samples[81].depends.Add(smp.id);
                                if (Banks[0].samples[81].depends.Count == 1)
                                {
                                    //find offset
                                    Banks[0].samples[81].offset = start - smp.start;
                                }
                            }
                        }
                    }
                }
                string deps = "";
                if (Banks[0].samples[81].common == true)
                {
                    Banks[0].samples[81].depends.Clear();
                    Banks[0].samples[81].offset = Banks[0].samples[81].start - 0x20000;
                }
                if (Banks[0].samples[81].depends.Count > 0)
                {
                    int dep = Banks[0].samples[81].depends[0];
                    {
                        deps = dep.ToString();
                    }
                }
                this.B0_S82_Dep.Text = deps;
                this.B0_S82_Off.Text = "0x" + Banks[0].samples[81].offset.ToString("x");
                this.B0_S82_Len.Text = "0x" + Banks[0].samples[81].length.ToString("x");
            }
            if (Banks[0].samples[82].enabled == true)
            {
                this.B0_S83_Enable.Enabled = true;
                this.B0_S83_Enable.Checked = true;
                this.B0_S83_Export.Enabled = true;

                if (Banks[0].samples[82].common == true)
                {
                    this.B0_S83_Import.Enabled = false;
                    this.B0_S83_Common.Checked = true;
                }
                else
                {
                    this.B0_S83_Import.Enabled = true;
                    this.B0_S83_Common.Checked = false;
                }

                int start = Banks[0].samples[82].start;
                int id = Banks[0].samples[82].id;
                for (int i = 0; i < 127; i++)
                {
                    Sample smp = Banks[0].samples[i];
                    if (smp.enabled == true)
                    {
                        if (IsBetween(start, smp.start, smp.end))
                        {
                            if (Banks[0].samples[82].id > smp.id)
                            {
                                Banks[0].samples[smp.id].parents.Add(id);
                                Banks[0].samples[82].depends.Add(smp.id);
                                if (Banks[0].samples[82].depends.Count == 1)
                                {
                                    //find offset
                                    Banks[0].samples[82].offset = start - smp.start;
                                }
                            }
                        }
                    }
                }
                string deps = "";
                if (Banks[0].samples[82].common == true)
                {
                    Banks[0].samples[82].depends.Clear();
                    Banks[0].samples[82].offset = Banks[0].samples[82].start - 0x20000;
                }

                if (Banks[0].samples[82].depends.Count > 0)
                {
                    int dep = Banks[0].samples[82].depends[0];
                    {
                        deps = dep.ToString();
                    }

                }
                this.B0_S83_Dep.Text = deps;
                this.B0_S83_Off.Text = "0x" + Banks[0].samples[82].offset.ToString("x");
                this.B0_S83_Len.Text = "0x" + Banks[0].samples[82].length.ToString("x");
            }
            if (Banks[0].samples[83].enabled == true)
            {
                this.B0_S84_Enable.Enabled = true;
                this.B0_S84_Enable.Checked = true;
                this.B0_S84_Export.Enabled = true;

                if (Banks[0].samples[83].common == true)
                {
                    this.B0_S84_Import.Enabled = false;
                    this.B0_S84_Common.Checked = true;
                }
                else
                {
                    this.B0_S84_Import.Enabled = true;
                    this.B0_S84_Common.Checked = false;
                }

                int start = Banks[0].samples[83].start;
                int id = Banks[0].samples[83].id;
                for (int i = 0; i < 127; i++)
                {
                    Sample smp = Banks[0].samples[i];
                    if (smp.enabled == true)
                    {
                        if (IsBetween(start, smp.start, smp.end))
                        {
                            if (Banks[0].samples[83].id > smp.id)
                            {
                                Banks[0].samples[smp.id].parents.Add(id);
                                Banks[0].samples[83].depends.Add(smp.id);
                                if (Banks[0].samples[83].depends.Count == 1)
                                {
                                    //find offset
                                    Banks[0].samples[83].offset = start - smp.start;
                                }
                            }
                        }
                    }
                }
                string deps = "";
                if (Banks[0].samples[83].common == true)
                {
                    Banks[0].samples[83].depends.Clear();
                    Banks[0].samples[83].offset = Banks[0].samples[83].start - 0x20000;
                }
                if (Banks[0].samples[83].depends.Count > 0)
                {
                    int dep = Banks[0].samples[83].depends[0];
                    {
                        deps = dep.ToString();
                    }

                }
                this.B0_S84_Dep.Text = deps;
                this.B0_S84_Off.Text = "0x" + Banks[0].samples[83].offset.ToString("x");
                this.B0_S84_Len.Text = "0x" + Banks[0].samples[83].length.ToString("x");
            }
            if (Banks[0].samples[84].enabled == true)
            {
                this.B0_S85_Enable.Enabled = true;
                this.B0_S85_Enable.Checked = true;
                this.B0_S85_Export.Enabled = true;

                if (Banks[0].samples[84].common == true)
                {
                    this.B0_S85_Import.Enabled = false;
                    this.B0_S85_Common.Checked = true;
                }
                else
                {
                    this.B0_S85_Import.Enabled = true;
                    this.B0_S85_Common.Checked = false;
                }

                int start = Banks[0].samples[84].start;
                int id = Banks[0].samples[84].id;
                for (int i = 0; i < 127; i++)
                {
                    Sample smp = Banks[0].samples[i];
                    if (smp.enabled == true)
                    {
                        if (IsBetween(start, smp.start, smp.end))
                        {
                            if (Banks[0].samples[84].id > smp.id)
                            {
                                Banks[0].samples[smp.id].parents.Add(id);
                                Banks[0].samples[84].depends.Add(smp.id);
                                if (Banks[0].samples[84].depends.Count == 1)
                                {
                                    //find offset
                                    Banks[0].samples[84].offset = start - smp.start;
                                }
                            }
                        }
                    }
                }
                string deps = "";
                if (Banks[0].samples[84].common == true)
                {
                    Banks[0].samples[84].depends.Clear();
                    Banks[0].samples[84].offset = Banks[0].samples[84].start - 0x20000;
                }
                if (Banks[0].samples[84].depends.Count > 0)
                {
                    int dep = Banks[0].samples[84].depends[0];
                    {
                        deps = dep.ToString();
                    }

                }
                this.B0_S85_Dep.Text = deps;
                this.B0_S85_Off.Text = "0x" + Banks[0].samples[84].offset.ToString("x");
                this.B0_S85_Len.Text = "0x" + Banks[0].samples[84].length.ToString("x");
            }
            if (Banks[0].samples[85].enabled == true)
            {
                this.B0_S86_Enable.Enabled = true;
                this.B0_S86_Enable.Checked = true;
                this.B0_S86_Export.Enabled = true;

                if (Banks[0].samples[85].common == true)
                {
                    this.B0_S86_Import.Enabled = false;
                    this.B0_S86_Common.Checked = true;
                }
                else
                {
                    this.B0_S86_Import.Enabled = true;
                    this.B0_S86_Common.Checked = false;
                }

                int start = Banks[0].samples[85].start;
                int id = Banks[0].samples[85].id;
                for (int i = 0; i < 127; i++)
                {
                    Sample smp = Banks[0].samples[i];
                    if (smp.enabled == true)
                    {
                        if (IsBetween(start, smp.start, smp.end))
                        {
                            if (Banks[0].samples[85].id > smp.id)
                            {
                                Banks[0].samples[smp.id].parents.Add(id);
                                Banks[0].samples[85].depends.Add(smp.id);
                                if (Banks[0].samples[85].depends.Count == 1)
                                {
                                    //find offset
                                    Banks[0].samples[85].offset = start - smp.start;
                                }
                            }
                        }
                    }
                }
                string deps = "";
                if (Banks[0].samples[85].common == true)
                {
                    Banks[0].samples[85].depends.Clear();
                    Banks[0].samples[85].offset = Banks[0].samples[85].start - 0x20000;
                }
                if (Banks[0].samples[85].depends.Count > 0)
                {
                    int dep = Banks[0].samples[85].depends[0];
                    {
                        deps = dep.ToString();
                    }

                }
                this.B0_S86_Dep.Text = deps;
                this.B0_S86_Off.Text = "0x" + Banks[0].samples[85].offset.ToString("x");
                this.B0_S86_Len.Text = "0x" + Banks[0].samples[85].length.ToString("x");
            }
            if (Banks[0].samples[86].enabled == true)
            {
                this.B0_S87_Enable.Enabled = true;
                this.B0_S87_Enable.Checked = true;
                this.B0_S87_Export.Enabled = true;

                if (Banks[0].samples[86].common == true)
                {
                    this.B0_S87_Import.Enabled = false;
                    this.B0_S87_Common.Checked = true;
                }
                else
                {
                    this.B0_S87_Import.Enabled = true;
                    this.B0_S87_Common.Checked = false;
                }

                int start = Banks[0].samples[86].start;
                int id = Banks[0].samples[86].id;
                for (int i = 0; i < 127; i++)
                {
                    Sample smp = Banks[0].samples[i];
                    if (smp.enabled == true)
                    {
                        if (IsBetween(start, smp.start, smp.end))
                        {
                            if (Banks[0].samples[86].id > smp.id)
                            {
                                Banks[0].samples[smp.id].parents.Add(id);
                                Banks[0].samples[86].depends.Add(smp.id);
                                if (Banks[0].samples[86].depends.Count == 1)
                                {
                                    //find offset
                                    Banks[0].samples[86].offset = start - smp.start;
                                }
                            }
                        }
                    }
                }
                string deps = "";
                if (Banks[0].samples[86].common == true)
                {
                    Banks[0].samples[86].depends.Clear();
                    Banks[0].samples[86].offset = Banks[0].samples[86].start - 0x20000;
                }
                if (Banks[0].samples[86].depends.Count > 0)
                {
                    int dep = Banks[0].samples[86].depends[0];
                    {
                        deps = dep.ToString();
                    }

                }
                this.B0_S87_Dep.Text = deps;
                this.B0_S87_Off.Text = "0x" + Banks[0].samples[86].offset.ToString("x");
                this.B0_S87_Len.Text = "0x" + Banks[0].samples[86].length.ToString("x");
            }
            if (Banks[0].samples[87].enabled == true)
            {
                this.B0_S88_Enable.Enabled = true;
                this.B0_S88_Enable.Checked = true;
                this.B0_S88_Export.Enabled = true;

                if (Banks[0].samples[87].common == true)
                {
                    this.B0_S88_Import.Enabled = false;
                    this.B0_S88_Common.Checked = true;
                }
                else
                {
                    this.B0_S88_Import.Enabled = true;
                    this.B0_S88_Common.Checked = false;
                }

                int start = Banks[0].samples[87].start;
                int id = Banks[0].samples[87].id;
                for (int i = 0; i < 127; i++)
                {
                    Sample smp = Banks[0].samples[i];
                    if (smp.enabled == true)
                    {
                        if (IsBetween(start, smp.start, smp.end))
                        {
                            if (Banks[0].samples[87].id > smp.id)
                            {
                                Banks[0].samples[smp.id].parents.Add(id);
                                Banks[0].samples[87].depends.Add(smp.id);
                                if (Banks[0].samples[87].depends.Count == 1)
                                {
                                    //find offset
                                    Banks[0].samples[87].offset = start - smp.start;
                                }
                            }
                        }
                    }
                }
                string deps = "";
                if (Banks[0].samples[87].common == true)
                {
                    Banks[0].samples[87].depends.Clear();
                    Banks[0].samples[87].offset = Banks[0].samples[87].start - 0x20000;
                }
                if (Banks[0].samples[87].depends.Count > 0)
                {
                    int dep = Banks[0].samples[87].depends[0];
                    {
                        deps = dep.ToString();
                    }

                }
                this.B0_S88_Dep.Text = deps;
                this.B0_S88_Off.Text = "0x" + Banks[0].samples[87].offset.ToString("x");
                this.B0_S88_Len.Text = "0x" + Banks[0].samples[87].length.ToString("x");
            }
            if (Banks[0].samples[88].enabled == true)
            {
                this.B0_S89_Enable.Enabled = true;
                this.B0_S89_Enable.Checked = true;
                this.B0_S89_Export.Enabled = true;

                if (Banks[0].samples[88].common == true)
                {
                    this.B0_S89_Import.Enabled = false;
                    this.B0_S89_Common.Checked = true;
                }
                else
                {
                    this.B0_S89_Import.Enabled = true;
                    this.B0_S89_Common.Checked = false;
                }

                int start = Banks[0].samples[88].start;
                int id = Banks[0].samples[88].id;
                for (int i = 0; i < 127; i++)
                {
                    Sample smp = Banks[0].samples[i];
                    if (smp.enabled == true)
                    {
                        if (IsBetween(start, smp.start, smp.end))
                        {
                            if (Banks[0].samples[88].id > smp.id)
                            {
                                Banks[0].samples[smp.id].parents.Add(id);
                                Banks[0].samples[88].depends.Add(smp.id);
                                if (Banks[0].samples[88].depends.Count == 1)
                                {
                                    //find offset
                                    Banks[0].samples[88].offset = start - smp.start;
                                }
                            }
                        }
                    }
                }
                string deps = "";
                if (Banks[0].samples[88].common == true)
                {
                    Banks[0].samples[88].depends.Clear();
                    Banks[0].samples[88].offset = Banks[0].samples[88].start - 0x20000;
                }
                if (Banks[0].samples[88].depends.Count > 0)
                {
                    int dep = Banks[0].samples[88].depends[0];
                    {
                        deps = dep.ToString();
                    }

                }
                this.B0_S89_Dep.Text = deps;
                this.B0_S89_Off.Text = "0x" + Banks[0].samples[88].offset.ToString("x");
                this.B0_S89_Len.Text = "0x" + Banks[0].samples[88].length.ToString("x");
            }
            if (Banks[0].samples[89].enabled == true)
            {
                this.B0_S90_Enable.Enabled = true;
                this.B0_S90_Enable.Checked = true;
                this.B0_S90_Export.Enabled = true;

                if (Banks[0].samples[89].common == true)
                {
                    this.B0_S90_Import.Enabled = false;
                    this.B0_S90_Common.Checked = true;
                }
                else
                {
                    this.B0_S90_Import.Enabled = true;
                    this.B0_S90_Common.Checked = false;
                }

                int start = Banks[0].samples[89].start;
                int id = Banks[0].samples[89].id;
                for (int i = 0; i < 127; i++)
                {
                    Sample smp = Banks[0].samples[i];
                    if (smp.enabled == true)
                    {
                        if (IsBetween(start, smp.start, smp.end))
                        {
                            if (Banks[0].samples[89].id > smp.id)
                            {
                                Banks[0].samples[smp.id].parents.Add(id);
                                Banks[0].samples[89].depends.Add(smp.id);
                                if (Banks[0].samples[89].depends.Count == 1)
                                {
                                    //find offset
                                    Banks[0].samples[89].offset = start - smp.start;
                                }
                            }
                        }
                    }
                }
                string deps = "";
                if (Banks[0].samples[89].common == true)
                {
                    Banks[0].samples[89].depends.Clear();
                    Banks[0].samples[89].offset = Banks[0].samples[89].start - 0x20000;
                }
                if (Banks[0].samples[89].depends.Count > 0)
                {
                    int dep = Banks[0].samples[89].depends[0];
                    {
                        deps = dep.ToString();
                    }

                }
                this.B0_S90_Dep.Text = deps;
                this.B0_S90_Off.Text = "0x" + Banks[0].samples[89].offset.ToString("x");
                this.B0_S90_Len.Text = "0x" + Banks[0].samples[89].length.ToString("x");
            }
            if (Banks[0].samples[90].enabled == true)
            {
                this.B0_S91_Enable.Enabled = true;
                this.B0_S91_Enable.Checked = true;
                this.B0_S91_Export.Enabled = true;

                if (Banks[0].samples[90].common == true)
                {
                    this.B0_S91_Import.Enabled = false;
                    this.B0_S91_Common.Checked = true;
                }
                else
                {
                    this.B0_S91_Import.Enabled = true;
                    this.B0_S91_Common.Checked = false;
                }

                int start = Banks[0].samples[90].start;
                int id = Banks[0].samples[90].id;
                for (int i = 0; i < 127; i++)
                {
                    Sample smp = Banks[0].samples[i];
                    if (smp.enabled == true)
                    {
                        if (IsBetween(start, smp.start, smp.end))
                        {
                            if (Banks[0].samples[90].id > smp.id)
                            {
                                Banks[0].samples[smp.id].parents.Add(id);
                                Banks[0].samples[90].depends.Add(smp.id);
                                if (Banks[0].samples[90].depends.Count == 1)
                                {
                                    //find offset
                                    Banks[0].samples[90].offset = start - smp.start;
                                }
                            }
                        }
                    }
                }
                string deps = "";
                if (Banks[0].samples[90].common == true)
                {
                    Banks[0].samples[90].depends.Clear();
                    Banks[0].samples[90].offset = Banks[0].samples[90].start - 0x20000;
                }
                if (Banks[0].samples[90].depends.Count > 0)
                {
                    int dep = Banks[0].samples[90].depends[0];
                    {
                        deps = dep.ToString();
                    }
                }
                this.B0_S91_Dep.Text = deps;
                this.B0_S91_Off.Text = "0x" + Banks[0].samples[90].offset.ToString("x");
                this.B0_S91_Len.Text = "0x" + Banks[0].samples[90].length.ToString("x");
            }
            if (Banks[0].samples[91].enabled == true)
            {
                this.B0_S92_Enable.Enabled = true;
                this.B0_S92_Enable.Checked = true;
                this.B0_S92_Export.Enabled = true;

                if (Banks[0].samples[91].common == true)
                {
                    this.B0_S92_Import.Enabled = false;
                    this.B0_S92_Common.Checked = true;
                }
                else
                {
                    this.B0_S92_Import.Enabled = true;
                    this.B0_S92_Common.Checked = false;
                }

                int start = Banks[0].samples[91].start;
                int id = Banks[0].samples[91].id;
                for (int i = 0; i < 127; i++)
                {
                    Sample smp = Banks[0].samples[i];
                    if (smp.enabled == true)
                    {
                        if (IsBetween(start, smp.start, smp.end))
                        {
                            if (Banks[0].samples[91].id > smp.id)
                            {
                                Banks[0].samples[smp.id].parents.Add(id);
                                Banks[0].samples[91].depends.Add(smp.id);
                                if (Banks[0].samples[91].depends.Count == 1)
                                {
                                    //find offset
                                    Banks[0].samples[91].offset = start - smp.start;
                                }
                            }
                        }
                    }
                }
                string deps = "";
                if (Banks[0].samples[91].common == true)
                {
                    Banks[0].samples[91].depends.Clear();
                    Banks[0].samples[91].offset = Banks[0].samples[91].start - 0x20000;
                }
                if (Banks[0].samples[91].depends.Count > 0)
                {
                    int dep = Banks[0].samples[91].depends[0];
                    {
                        deps = dep.ToString();
                    }
                }
                this.B0_S92_Dep.Text = deps;
                this.B0_S92_Off.Text = "0x" + Banks[0].samples[91].offset.ToString("x");
                this.B0_S92_Len.Text = "0x" + Banks[0].samples[91].length.ToString("x");
            }
            if (Banks[0].samples[92].enabled == true)
            {
                this.B0_S93_Enable.Enabled = true;
                this.B0_S93_Enable.Checked = true;
                this.B0_S93_Export.Enabled = true;

                if (Banks[0].samples[92].common == true)
                {
                    this.B0_S93_Import.Enabled = false;
                    this.B0_S93_Common.Checked = true;
                }
                else
                {
                    this.B0_S93_Import.Enabled = true;
                    this.B0_S93_Common.Checked = false;
                }

                int start = Banks[0].samples[92].start;
                int id = Banks[0].samples[92].id;
                for (int i = 0; i < 127; i++)
                {
                    Sample smp = Banks[0].samples[i];
                    if (smp.enabled == true)
                    {
                        if (IsBetween(start, smp.start, smp.end))
                        {
                            if (Banks[0].samples[92].id > smp.id)
                            {
                                Banks[0].samples[smp.id].parents.Add(id);
                                Banks[0].samples[92].depends.Add(smp.id);
                                if (Banks[0].samples[92].depends.Count == 1)
                                {
                                    //find offset
                                    Banks[0].samples[92].offset = start - smp.start;
                                }
                            }
                        }
                    }
                }
                string deps = "";
                if (Banks[0].samples[92].common == true)
                {
                    Banks[0].samples[92].depends.Clear();
                    Banks[0].samples[92].offset = Banks[0].samples[92].start - 0x20000;
                }

                if (Banks[0].samples[92].depends.Count > 0)
                {
                    int dep = Banks[0].samples[92].depends[0];
                    {
                        deps = dep.ToString();
                    }

                }
                this.B0_S93_Dep.Text = deps;
                this.B0_S93_Off.Text = "0x" + Banks[0].samples[92].offset.ToString("x");
                this.B0_S93_Len.Text = "0x" + Banks[0].samples[92].length.ToString("x");
            }
            if (Banks[0].samples[93].enabled == true)
            {
                this.B0_S94_Enable.Enabled = true;
                this.B0_S94_Enable.Checked = true;
                this.B0_S94_Export.Enabled = true;

                if (Banks[0].samples[93].common == true)
                {
                    this.B0_S94_Import.Enabled = false;
                    this.B0_S94_Common.Checked = true;
                }
                else
                {
                    this.B0_S94_Import.Enabled = true;
                    this.B0_S94_Common.Checked = false;
                }

                int start = Banks[0].samples[93].start;
                int id = Banks[0].samples[93].id;
                for (int i = 0; i < 127; i++)
                {
                    Sample smp = Banks[0].samples[i];
                    if (smp.enabled == true)
                    {
                        if (IsBetween(start, smp.start, smp.end))
                        {
                            if (Banks[0].samples[93].id > smp.id)
                            {
                                Banks[0].samples[smp.id].parents.Add(id);
                                Banks[0].samples[93].depends.Add(smp.id);
                                if (Banks[0].samples[93].depends.Count == 1)
                                {
                                    //find offset
                                    Banks[0].samples[93].offset = start - smp.start;
                                }
                            }
                        }
                    }
                }
                string deps = "";
                if (Banks[0].samples[93].common == true)
                {
                    Banks[0].samples[93].depends.Clear();
                    Banks[0].samples[93].offset = Banks[0].samples[93].start - 0x20000;
                }
                if (Banks[0].samples[93].depends.Count > 0)
                {
                    int dep = Banks[0].samples[93].depends[0];
                    {
                        deps = dep.ToString();
                    }

                }
                this.B0_S94_Dep.Text = deps;
                this.B0_S94_Off.Text = "0x" + Banks[0].samples[93].offset.ToString("x");
                this.B0_S94_Len.Text = "0x" + Banks[0].samples[93].length.ToString("x");
            }
            if (Banks[0].samples[94].enabled == true)
            {
                this.B0_S95_Enable.Enabled = true;
                this.B0_S95_Enable.Checked = true;
                this.B0_S95_Export.Enabled = true;

                if (Banks[0].samples[94].common == true)
                {
                    this.B0_S95_Import.Enabled = false;
                    this.B0_S95_Common.Checked = true;
                }
                else
                {
                    this.B0_S95_Import.Enabled = true;
                    this.B0_S95_Common.Checked = false;
                }

                int start = Banks[0].samples[94].start;
                int id = Banks[0].samples[94].id;
                for (int i = 0; i < 127; i++)
                {
                    Sample smp = Banks[0].samples[i];
                    if (smp.enabled == true)
                    {
                        if (IsBetween(start, smp.start, smp.end))
                        {
                            if (Banks[0].samples[94].id > smp.id)
                            {
                                Banks[0].samples[smp.id].parents.Add(id);
                                Banks[0].samples[94].depends.Add(smp.id);
                                if (Banks[0].samples[94].depends.Count == 1)
                                {
                                    //find offset
                                    Banks[0].samples[94].offset = start - smp.start;
                                }
                            }
                        }
                    }
                }
                string deps = "";
                if (Banks[0].samples[94].common == true)
                {
                    Banks[0].samples[94].depends.Clear();
                    Banks[0].samples[94].offset = Banks[0].samples[94].start - 0x20000;
                }
                if (Banks[0].samples[94].depends.Count > 0)
                {
                    int dep = Banks[0].samples[94].depends[0];
                    {
                        deps = dep.ToString();
                    }

                }
                this.B0_S95_Dep.Text = deps;
                this.B0_S95_Off.Text = "0x" + Banks[0].samples[94].offset.ToString("x");
                this.B0_S95_Len.Text = "0x" + Banks[0].samples[94].length.ToString("x");
            }
            if (Banks[0].samples[95].enabled == true)
            {
                this.B0_S96_Enable.Enabled = true;
                this.B0_S96_Enable.Checked = true;
                this.B0_S96_Export.Enabled = true;

                if (Banks[0].samples[95].common == true)
                {
                    this.B0_S96_Import.Enabled = false;
                    this.B0_S96_Common.Checked = true;
                }
                else
                {
                    this.B0_S96_Import.Enabled = true;
                    this.B0_S96_Common.Checked = false;
                }

                int start = Banks[0].samples[95].start;
                int id = Banks[0].samples[95].id;
                for (int i = 0; i < 127; i++)
                {
                    Sample smp = Banks[0].samples[i];
                    if (smp.enabled == true)
                    {
                        if (IsBetween(start, smp.start, smp.end))
                        {
                            if (Banks[0].samples[95].id > smp.id)
                            {
                                Banks[0].samples[smp.id].parents.Add(id);
                                Banks[0].samples[95].depends.Add(smp.id);
                                if (Banks[0].samples[95].depends.Count == 1)
                                {
                                    //find offset
                                    Banks[0].samples[95].offset = start - smp.start;
                                }
                            }
                        }
                    }
                }
                string deps = "";
                if (Banks[0].samples[95].common == true)
                {
                    Banks[0].samples[95].depends.Clear();
                    Banks[0].samples[95].offset = Banks[0].samples[95].start - 0x20000;
                }
                if (Banks[0].samples[95].depends.Count > 0)
                {
                    int dep = Banks[0].samples[95].depends[0];
                    {
                        deps = dep.ToString();
                    }

                }
                this.B0_S96_Dep.Text = deps;
                this.B0_S96_Off.Text = "0x" + Banks[0].samples[95].offset.ToString("x");
                this.B0_S96_Len.Text = "0x" + Banks[0].samples[95].length.ToString("x");
            }
            if (Banks[0].samples[96].enabled == true)
            {
                this.B0_S97_Enable.Enabled = true;
                this.B0_S97_Enable.Checked = true;
                this.B0_S97_Export.Enabled = true;

                if (Banks[0].samples[96].common == true)
                {
                    this.B0_S97_Import.Enabled = false;
                    this.B0_S97_Common.Checked = true;
                }
                else
                {
                    this.B0_S97_Import.Enabled = true;
                    this.B0_S97_Common.Checked = false;
                }

                int start = Banks[0].samples[96].start;
                int id = Banks[0].samples[96].id;
                for (int i = 0; i < 127; i++)
                {
                    Sample smp = Banks[0].samples[i];
                    if (smp.enabled == true)
                    {
                        if (IsBetween(start, smp.start, smp.end))
                        {
                            if (Banks[0].samples[96].id > smp.id)
                            {
                                Banks[0].samples[smp.id].parents.Add(id);
                                Banks[0].samples[96].depends.Add(smp.id);
                                if (Banks[0].samples[96].depends.Count == 1)
                                {
                                    //find offset
                                    Banks[0].samples[96].offset = start - smp.start;
                                }
                            }
                        }
                    }
                }
                string deps = "";
                if (Banks[0].samples[96].common == true)
                {
                    Banks[0].samples[96].depends.Clear();
                    Banks[0].samples[96].offset = Banks[0].samples[96].start - 0x20000;
                }
                if (Banks[0].samples[96].depends.Count > 0)
                {
                    int dep = Banks[0].samples[96].depends[0];
                    {
                        deps = dep.ToString();
                    }

                }
                this.B0_S97_Dep.Text = deps;
                this.B0_S97_Off.Text = "0x" + Banks[0].samples[96].offset.ToString("x");
                this.B0_S97_Len.Text = "0x" + Banks[0].samples[96].length.ToString("x");
            }
            if (Banks[0].samples[97].enabled == true)
            {
                this.B0_S98_Enable.Enabled = true;
                this.B0_S98_Enable.Checked = true;
                this.B0_S98_Export.Enabled = true;

                if (Banks[0].samples[97].common == true)
                {
                    this.B0_S98_Import.Enabled = false;
                    this.B0_S98_Common.Checked = true;
                }
                else
                {
                    this.B0_S98_Import.Enabled = true;
                    this.B0_S98_Common.Checked = false;
                }

                int start = Banks[0].samples[97].start;
                int id = Banks[0].samples[97].id;
                for (int i = 0; i < 127; i++)
                {
                    Sample smp = Banks[0].samples[i];
                    if (smp.enabled == true)
                    {
                        if (IsBetween(start, smp.start, smp.end))
                        {
                            if (Banks[0].samples[97].id > smp.id)
                            {
                                Banks[0].samples[smp.id].parents.Add(id);
                                Banks[0].samples[97].depends.Add(smp.id);
                                if (Banks[0].samples[97].depends.Count == 1)
                                {
                                    //find offset
                                    Banks[0].samples[97].offset = start - smp.start;
                                }
                            }
                        }
                    }
                }
                string deps = "";
                if (Banks[0].samples[97].common == true)
                {
                    Banks[0].samples[97].depends.Clear();
                    Banks[0].samples[97].offset = Banks[0].samples[97].start - 0x20000;
                }
                if (Banks[0].samples[97].depends.Count > 0)
                {
                    int dep = Banks[0].samples[97].depends[0];
                    {
                        deps = dep.ToString();
                    }

                }
                this.B0_S98_Dep.Text = deps;
                this.B0_S98_Off.Text = "0x" + Banks[0].samples[97].offset.ToString("x");
                this.B0_S98_Len.Text = "0x" + Banks[0].samples[97].length.ToString("x");
            }
            if (Banks[0].samples[98].enabled == true)
            {
                this.B0_S99_Enable.Enabled = true;
                this.B0_S99_Enable.Checked = true;
                this.B0_S99_Export.Enabled = true;

                if (Banks[0].samples[98].common == true)
                {
                    this.B0_S99_Import.Enabled = false;
                    this.B0_S99_Common.Checked = true;
                }
                else
                {
                    this.B0_S99_Import.Enabled = true;
                    this.B0_S99_Common.Checked = false;
                }

                int start = Banks[0].samples[98].start;
                int id = Banks[0].samples[98].id;
                for (int i = 0; i < 127; i++)
                {
                    Sample smp = Banks[0].samples[i];
                    if (smp.enabled == true)
                    {
                        if (IsBetween(start, smp.start, smp.end))
                        {
                            if (Banks[0].samples[98].id > smp.id)
                            {
                                Banks[0].samples[smp.id].parents.Add(id);
                                Banks[0].samples[98].depends.Add(smp.id);
                                if (Banks[0].samples[98].depends.Count == 1)
                                {
                                    //find offset
                                    Banks[0].samples[98].offset = start - smp.start;
                                }
                            }
                        }
                    }
                }
                string deps = "";
                if (Banks[0].samples[98].common == true)
                {
                    Banks[0].samples[98].depends.Clear();
                    Banks[0].samples[98].offset = Banks[0].samples[98].start - 0x20000;
                }
                if (Banks[0].samples[98].depends.Count > 0)
                {
                    int dep = Banks[0].samples[98].depends[0];
                    {
                        deps = dep.ToString();
                    }

                }
                this.B0_S99_Dep.Text = deps;
                this.B0_S99_Off.Text = "0x" + Banks[0].samples[98].offset.ToString("x");
                this.B0_S99_Len.Text = "0x" + Banks[0].samples[98].length.ToString("x");
            }
            if (Banks[0].samples[99].enabled == true)
            {
                this.B0_S100_Enable.Enabled = true;
                this.B0_S100_Enable.Checked = true;
                this.B0_S100_Export.Enabled = true;

                if (Banks[0].samples[99].common == true)
                {
                    this.B0_S100_Import.Enabled = false;
                    this.B0_S100_Common.Checked = true;
                }
                else
                {
                    this.B0_S100_Import.Enabled = true;
                    this.B0_S100_Common.Checked = false;
                }

                int start = Banks[0].samples[99].start;
                int id = Banks[0].samples[99].id;
                for (int i = 0; i < 127; i++)
                {
                    Sample smp = Banks[0].samples[i];
                    if (smp.enabled == true)
                    {
                        if (IsBetween(start, smp.start, smp.end))
                        {
                            if (Banks[0].samples[99].id > smp.id)
                            {
                                Banks[0].samples[smp.id].parents.Add(id);
                                Banks[0].samples[99].depends.Add(smp.id);
                                if (Banks[0].samples[99].depends.Count == 1)
                                {
                                    //find offset
                                    Banks[0].samples[99].offset = start - smp.start;
                                }
                            }
                        }
                    }
                }
                string deps = "";
                if (Banks[0].samples[99].common == true)
                {
                    Banks[0].samples[99].depends.Clear();
                    Banks[0].samples[99].offset = Banks[0].samples[99].start - 0x20000;
                }
                if (Banks[0].samples[99].depends.Count > 0)
                {
                    int dep = Banks[0].samples[99].depends[0];
                    {
                        deps = dep.ToString();
                    }

                }
                this.B0_S100_Dep.Text = deps;
                this.B0_S100_Off.Text = "0x" + Banks[0].samples[99].offset.ToString("x");
                this.B0_S100_Len.Text = "0x" + Banks[0].samples[99].length.ToString("x");
            }
            if (Banks[0].samples[100].enabled == true)
            {
                this.B0_S101_Enable.Enabled = true;
                this.B0_S101_Enable.Checked = true;
                this.B0_S101_Export.Enabled = true;

                if (Banks[0].samples[100].common == true)
                {
                    this.B0_S101_Import.Enabled = false;
                    this.B0_S101_Common.Checked = true;
                }
                else
                {
                    this.B0_S101_Import.Enabled = true;
                    this.B0_S101_Common.Checked = false;
                }

                int start = Banks[0].samples[100].start;
                int id = Banks[0].samples[100].id;
                for (int i = 0; i < 127; i++)
                {
                    Sample smp = Banks[0].samples[i];
                    if (smp.enabled == true)
                    {
                        if (IsBetween(start, smp.start, smp.end))
                        {
                            if (Banks[0].samples[100].id > smp.id)
                            {
                                Banks[0].samples[smp.id].parents.Add(id);
                                Banks[0].samples[100].depends.Add(smp.id);
                                if (Banks[0].samples[100].depends.Count == 1)
                                {
                                    //find offset
                                    Banks[0].samples[100].offset = start - smp.start;
                                }
                            }
                        }
                    }
                }
                string deps = "";
                if (Banks[0].samples[100].common == true)
                {
                    Banks[0].samples[100].depends.Clear();
                    Banks[0].samples[100].offset = Banks[0].samples[100].start - 0x20000;
                }
                if (Banks[0].samples[100].depends.Count > 0)
                {
                    int dep = Banks[0].samples[100].depends[0];
                    {
                        deps = dep.ToString();
                    }
                }
                this.B0_S101_Dep.Text = deps;
                this.B0_S101_Off.Text = "0x" + Banks[0].samples[100].offset.ToString("x");
                this.B0_S101_Len.Text = "0x" + Banks[0].samples[100].length.ToString("x");
            }
            if (Banks[0].samples[101].enabled == true)
            {
                this.B0_S102_Enable.Enabled = true;
                this.B0_S102_Enable.Checked = true;
                this.B0_S102_Export.Enabled = true;

                if (Banks[0].samples[101].common == true)
                {
                    this.B0_S102_Import.Enabled = false;
                    this.B0_S102_Common.Checked = true;
                }
                else
                {
                    this.B0_S102_Import.Enabled = true;
                    this.B0_S102_Common.Checked = false;
                }

                int start = Banks[0].samples[101].start;
                int id = Banks[0].samples[101].id;
                for (int i = 0; i < 127; i++)
                {
                    Sample smp = Banks[0].samples[i];
                    if (smp.enabled == true)
                    {
                        if (IsBetween(start, smp.start, smp.end))
                        {
                            if (Banks[0].samples[101].id > smp.id)
                            {
                                Banks[0].samples[smp.id].parents.Add(id);
                                Banks[0].samples[101].depends.Add(smp.id);
                                if (Banks[0].samples[101].depends.Count == 1)
                                {
                                    //find offset
                                    Banks[0].samples[101].offset = start - smp.start;
                                }
                            }
                        }
                    }
                }
                string deps = "";
                if (Banks[0].samples[101].common == true)
                {
                    Banks[0].samples[101].depends.Clear();
                    Banks[0].samples[101].offset = Banks[0].samples[101].start - 0x20000;
                }
                if (Banks[0].samples[101].depends.Count > 0)
                {
                    int dep = Banks[0].samples[101].depends[0];
                    {
                        deps = dep.ToString();
                    }
                }
                this.B0_S102_Dep.Text = deps;
                this.B0_S102_Off.Text = "0x" + Banks[0].samples[101].offset.ToString("x");
                this.B0_S102_Len.Text = "0x" + Banks[0].samples[101].length.ToString("x");
            }
            if (Banks[0].samples[102].enabled == true)
            {
                this.B0_S103_Enable.Enabled = true;
                this.B0_S103_Enable.Checked = true;
                this.B0_S103_Export.Enabled = true;

                if (Banks[0].samples[102].common == true)
                {
                    this.B0_S103_Import.Enabled = false;
                    this.B0_S103_Common.Checked = true;
                }
                else
                {
                    this.B0_S103_Import.Enabled = true;
                    this.B0_S103_Common.Checked = false;
                }

                int start = Banks[0].samples[102].start;
                int id = Banks[0].samples[102].id;
                for (int i = 0; i < 127; i++)
                {
                    Sample smp = Banks[0].samples[i];
                    if (smp.enabled == true)
                    {
                        if (IsBetween(start, smp.start, smp.end))
                        {
                            if (Banks[0].samples[102].id > smp.id)
                            {
                                Banks[0].samples[smp.id].parents.Add(id);
                                Banks[0].samples[102].depends.Add(smp.id);
                                if (Banks[0].samples[102].depends.Count == 1)
                                {
                                    //find offset
                                    Banks[0].samples[102].offset = start - smp.start;
                                }
                            }
                        }
                    }
                }
                string deps = "";
                if (Banks[0].samples[102].common == true)
                {
                    Banks[0].samples[102].depends.Clear();
                    Banks[0].samples[102].offset = Banks[0].samples[102].start - 0x20000;
                }

                if (Banks[0].samples[102].depends.Count > 0)
                {
                    int dep = Banks[0].samples[102].depends[0];
                    {
                        deps = dep.ToString();
                    }

                }
                this.B0_S103_Dep.Text = deps;
                this.B0_S103_Off.Text = "0x" + Banks[0].samples[102].offset.ToString("x");
                this.B0_S103_Len.Text = "0x" + Banks[0].samples[102].length.ToString("x");
            }
            if (Banks[0].samples[103].enabled == true)
            {
                this.B0_S104_Enable.Enabled = true;
                this.B0_S104_Enable.Checked = true;
                this.B0_S104_Export.Enabled = true;

                if (Banks[0].samples[103].common == true)
                {
                    this.B0_S104_Import.Enabled = false;
                    this.B0_S104_Common.Checked = true;
                }
                else
                {
                    this.B0_S104_Import.Enabled = true;
                    this.B0_S104_Common.Checked = false;
                }

                int start = Banks[0].samples[103].start;
                int id = Banks[0].samples[103].id;
                for (int i = 0; i < 127; i++)
                {
                    Sample smp = Banks[0].samples[i];
                    if (smp.enabled == true)
                    {
                        if (IsBetween(start, smp.start, smp.end))
                        {
                            if (Banks[0].samples[103].id > smp.id)
                            {
                                Banks[0].samples[smp.id].parents.Add(id);
                                Banks[0].samples[103].depends.Add(smp.id);
                                if (Banks[0].samples[103].depends.Count == 1)
                                {
                                    //find offset
                                    Banks[0].samples[103].offset = start - smp.start;
                                }
                            }
                        }
                    }
                }
                string deps = "";
                if (Banks[0].samples[103].common == true)
                {
                    Banks[0].samples[103].depends.Clear();
                    Banks[0].samples[103].offset = Banks[0].samples[103].start - 0x20000;
                }
                if (Banks[0].samples[103].depends.Count > 0)
                {
                    int dep = Banks[0].samples[103].depends[0];
                    {
                        deps = dep.ToString();
                    }

                }
                this.B0_S104_Dep.Text = deps;
                this.B0_S104_Off.Text = "0x" + Banks[0].samples[103].offset.ToString("x");
                this.B0_S104_Len.Text = "0x" + Banks[0].samples[103].length.ToString("x");
            }
            if (Banks[0].samples[104].enabled == true)
            {
                this.B0_S105_Enable.Enabled = true;
                this.B0_S105_Enable.Checked = true;
                this.B0_S105_Export.Enabled = true;

                if (Banks[0].samples[104].common == true)
                {
                    this.B0_S105_Import.Enabled = false;
                    this.B0_S105_Common.Checked = true;
                }
                else
                {
                    this.B0_S105_Import.Enabled = true;
                    this.B0_S105_Common.Checked = false;
                }

                int start = Banks[0].samples[104].start;
                int id = Banks[0].samples[104].id;
                for (int i = 0; i < 127; i++)
                {
                    Sample smp = Banks[0].samples[i];
                    if (smp.enabled == true)
                    {
                        if (IsBetween(start, smp.start, smp.end))
                        {
                            if (Banks[0].samples[104].id > smp.id)
                            {
                                Banks[0].samples[smp.id].parents.Add(id);
                                Banks[0].samples[104].depends.Add(smp.id);
                                if (Banks[0].samples[104].depends.Count == 1)
                                {
                                    //find offset
                                    Banks[0].samples[104].offset = start - smp.start;
                                }
                            }
                        }
                    }
                }
                string deps = "";
                if (Banks[0].samples[104].common == true)
                {
                    Banks[0].samples[104].depends.Clear();
                    Banks[0].samples[104].offset = Banks[0].samples[104].start - 0x20000;
                }
                if (Banks[0].samples[104].depends.Count > 0)
                {
                    int dep = Banks[0].samples[104].depends[0];
                    {
                        deps = dep.ToString();
                    }

                }
                this.B0_S105_Dep.Text = deps;
                this.B0_S105_Off.Text = "0x" + Banks[0].samples[104].offset.ToString("x");
                this.B0_S105_Len.Text = "0x" + Banks[0].samples[104].length.ToString("x");
            }
            if (Banks[0].samples[105].enabled == true)
            {
                this.B0_S106_Enable.Enabled = true;
                this.B0_S106_Enable.Checked = true;
                this.B0_S106_Export.Enabled = true;

                if (Banks[0].samples[105].common == true)
                {
                    this.B0_S106_Import.Enabled = false;
                    this.B0_S106_Common.Checked = true;
                }
                else
                {
                    this.B0_S106_Import.Enabled = true;
                    this.B0_S106_Common.Checked = false;
                }

                int start = Banks[0].samples[105].start;
                int id = Banks[0].samples[105].id;
                for (int i = 0; i < 127; i++)
                {
                    Sample smp = Banks[0].samples[i];
                    if (smp.enabled == true)
                    {
                        if (IsBetween(start, smp.start, smp.end))
                        {
                            if (Banks[0].samples[105].id > smp.id)
                            {
                                Banks[0].samples[smp.id].parents.Add(id);
                                Banks[0].samples[105].depends.Add(smp.id);
                                if (Banks[0].samples[105].depends.Count == 1)
                                {
                                    //find offset
                                    Banks[0].samples[105].offset = start - smp.start;
                                }
                            }
                        }
                    }
                }
                string deps = "";
                if (Banks[0].samples[105].common == true)
                {
                    Banks[0].samples[105].depends.Clear();
                    Banks[0].samples[105].offset = Banks[0].samples[105].start - 0x20000;
                }
                if (Banks[0].samples[105].depends.Count > 0)
                {
                    int dep = Banks[0].samples[105].depends[0];
                    {
                        deps = dep.ToString();
                    }

                }
                this.B0_S106_Dep.Text = deps;
                this.B0_S106_Off.Text = "0x" + Banks[0].samples[105].offset.ToString("x");
                this.B0_S106_Len.Text = "0x" + Banks[0].samples[105].length.ToString("x");
            }
            if (Banks[0].samples[106].enabled == true)
            {
                this.B0_S107_Enable.Enabled = true;
                this.B0_S107_Enable.Checked = true;
                this.B0_S107_Export.Enabled = true;

                if (Banks[0].samples[106].common == true)
                {
                    this.B0_S107_Import.Enabled = false;
                    this.B0_S107_Common.Checked = true;
                }
                else
                {
                    this.B0_S107_Import.Enabled = true;
                    this.B0_S107_Common.Checked = false;
                }

                int start = Banks[0].samples[106].start;
                int id = Banks[0].samples[106].id;
                for (int i = 0; i < 127; i++)
                {
                    Sample smp = Banks[0].samples[i];
                    if (smp.enabled == true)
                    {
                        if (IsBetween(start, smp.start, smp.end))
                        {
                            if (Banks[0].samples[106].id > smp.id)
                            {
                                Banks[0].samples[smp.id].parents.Add(id);
                                Banks[0].samples[106].depends.Add(smp.id);
                                if (Banks[0].samples[106].depends.Count == 1)
                                {
                                    //find offset
                                    Banks[0].samples[106].offset = start - smp.start;
                                }
                            }
                        }
                    }
                }
                string deps = "";
                if (Banks[0].samples[106].common == true)
                {
                    Banks[0].samples[106].depends.Clear();
                    Banks[0].samples[106].offset = Banks[0].samples[106].start - 0x20000;
                }
                if (Banks[0].samples[106].depends.Count > 0)
                {
                    int dep = Banks[0].samples[106].depends[0];
                    {
                        deps = dep.ToString();
                    }

                }
                this.B0_S107_Dep.Text = deps;
                this.B0_S107_Off.Text = "0x" + Banks[0].samples[106].offset.ToString("x");
                this.B0_S107_Len.Text = "0x" + Banks[0].samples[106].length.ToString("x");
            }
            if (Banks[0].samples[107].enabled == true)
            {
                this.B0_S108_Enable.Enabled = true;
                this.B0_S108_Enable.Checked = true;
                this.B0_S108_Export.Enabled = true;

                if (Banks[0].samples[107].common == true)
                {
                    this.B0_S108_Import.Enabled = false;
                    this.B0_S108_Common.Checked = true;
                }
                else
                {
                    this.B0_S108_Import.Enabled = true;
                    this.B0_S108_Common.Checked = false;
                }

                int start = Banks[0].samples[107].start;
                int id = Banks[0].samples[107].id;
                for (int i = 0; i < 127; i++)
                {
                    Sample smp = Banks[0].samples[i];
                    if (smp.enabled == true)
                    {
                        if (IsBetween(start, smp.start, smp.end))
                        {
                            if (Banks[0].samples[107].id > smp.id)
                            {
                                Banks[0].samples[smp.id].parents.Add(id);
                                Banks[0].samples[107].depends.Add(smp.id);
                                if (Banks[0].samples[107].depends.Count == 1)
                                {
                                    //find offset
                                    Banks[0].samples[107].offset = start - smp.start;
                                }
                            }
                        }
                    }
                }
                string deps = "";
                if (Banks[0].samples[107].common == true)
                {
                    Banks[0].samples[107].depends.Clear();
                    Banks[0].samples[107].offset = Banks[0].samples[107].start - 0x20000;
                }
                if (Banks[0].samples[107].depends.Count > 0)
                {
                    int dep = Banks[0].samples[107].depends[0];
                    {
                        deps = dep.ToString();
                    }

                }
                this.B0_S108_Dep.Text = deps;
                this.B0_S108_Off.Text = "0x" + Banks[0].samples[107].offset.ToString("x");
                this.B0_S108_Len.Text = "0x" + Banks[0].samples[107].length.ToString("x");
            }
            if (Banks[0].samples[108].enabled == true)
            {
                this.B0_S109_Enable.Enabled = true;
                this.B0_S109_Enable.Checked = true;
                this.B0_S109_Export.Enabled = true;

                if (Banks[0].samples[108].common == true)
                {
                    this.B0_S109_Import.Enabled = false;
                    this.B0_S109_Common.Checked = true;
                }
                else
                {
                    this.B0_S109_Import.Enabled = true;
                    this.B0_S109_Common.Checked = false;
                }

                int start = Banks[0].samples[108].start;
                int id = Banks[0].samples[108].id;
                for (int i = 0; i < 127; i++)
                {
                    Sample smp = Banks[0].samples[i];
                    if (smp.enabled == true)
                    {
                        if (IsBetween(start, smp.start, smp.end))
                        {
                            if (Banks[0].samples[108].id > smp.id)
                            {
                                Banks[0].samples[smp.id].parents.Add(id);
                                Banks[0].samples[108].depends.Add(smp.id);
                                if (Banks[0].samples[108].depends.Count == 1)
                                {
                                    //find offset
                                    Banks[0].samples[108].offset = start - smp.start;
                                }
                            }
                        }
                    }
                }
                string deps = "";
                if (Banks[0].samples[108].common == true)
                {
                    Banks[0].samples[108].depends.Clear();
                    Banks[0].samples[108].offset = Banks[0].samples[108].start - 0x20000;
                }
                if (Banks[0].samples[108].depends.Count > 0)
                {
                    int dep = Banks[0].samples[108].depends[0];
                    {
                        deps = dep.ToString();
                    }

                }
                this.B0_S109_Dep.Text = deps;
                this.B0_S109_Off.Text = "0x" + Banks[0].samples[108].offset.ToString("x");
                this.B0_S109_Len.Text = "0x" + Banks[0].samples[108].length.ToString("x");
            }
            if (Banks[0].samples[109].enabled == true)
            {
                this.B0_S110_Enable.Enabled = true;
                this.B0_S110_Enable.Checked = true;
                this.B0_S110_Export.Enabled = true;

                if (Banks[0].samples[109].common == true)
                {
                    this.B0_S110_Import.Enabled = false;
                    this.B0_S110_Common.Checked = true;
                }
                else
                {
                    this.B0_S110_Import.Enabled = true;
                    this.B0_S110_Common.Checked = false;
                }

                int start = Banks[0].samples[109].start;
                int id = Banks[0].samples[109].id;
                for (int i = 0; i < 127; i++)
                {
                    Sample smp = Banks[0].samples[i];
                    if (smp.enabled == true)
                    {
                        if (IsBetween(start, smp.start, smp.end))
                        {
                            if (Banks[0].samples[109].id > smp.id)
                            {
                                Banks[0].samples[smp.id].parents.Add(id);
                                Banks[0].samples[109].depends.Add(smp.id);
                                if (Banks[0].samples[109].depends.Count == 1)
                                {
                                    //find offset
                                    Banks[0].samples[109].offset = start - smp.start;
                                }
                            }
                        }
                    }
                }
                string deps = "";
                if (Banks[0].samples[109].common == true)
                {
                    Banks[0].samples[109].depends.Clear();
                    Banks[0].samples[109].offset = Banks[0].samples[109].start - 0x20000;
                }
                if (Banks[0].samples[109].depends.Count > 0)
                {
                    int dep = Banks[0].samples[109].depends[0];
                    {
                        deps = dep.ToString();
                    }

                }
                this.B0_S110_Dep.Text = deps;
                this.B0_S110_Off.Text = "0x" + Banks[0].samples[109].offset.ToString("x");
                this.B0_S110_Len.Text = "0x" + Banks[0].samples[109].length.ToString("x");
            }
            if (Banks[0].samples[110].enabled == true)
            {
                this.B0_S111_Enable.Enabled = true;
                this.B0_S111_Enable.Checked = true;
                this.B0_S111_Export.Enabled = true;

                if (Banks[0].samples[110].common == true)
                {
                    this.B0_S111_Import.Enabled = false;
                    this.B0_S111_Common.Checked = true;
                }
                else
                {
                    this.B0_S111_Import.Enabled = true;
                    this.B0_S111_Common.Checked = false;
                }

                int start = Banks[0].samples[110].start;
                int id = Banks[0].samples[110].id;
                for (int i = 0; i < 127; i++)
                {
                    Sample smp = Banks[0].samples[i];
                    if (smp.enabled == true)
                    {
                        if (IsBetween(start, smp.start, smp.end))
                        {
                            if (Banks[0].samples[110].id > smp.id)
                            {
                                Banks[0].samples[smp.id].parents.Add(id);
                                Banks[0].samples[110].depends.Add(smp.id);
                                if (Banks[0].samples[110].depends.Count == 1)
                                {
                                    //find offset
                                    Banks[0].samples[110].offset = start - smp.start;
                                }
                            }
                        }
                    }
                }
                string deps = "";
                if (Banks[0].samples[110].common == true)
                {
                    Banks[0].samples[110].depends.Clear();
                    Banks[0].samples[110].offset = Banks[0].samples[110].start - 0x20000;
                }
                if (Banks[0].samples[110].depends.Count > 0)
                {
                    int dep = Banks[0].samples[110].depends[0];
                    {
                        deps = dep.ToString();
                    }
                }
                this.B0_S111_Dep.Text = deps;
                this.B0_S111_Off.Text = "0x" + Banks[0].samples[110].offset.ToString("x");
                this.B0_S111_Len.Text = "0x" + Banks[0].samples[110].length.ToString("x");
            }
            if (Banks[0].samples[111].enabled == true)
            {
                this.B0_S112_Enable.Enabled = true;
                this.B0_S112_Enable.Checked = true;
                this.B0_S112_Export.Enabled = true;

                if (Banks[0].samples[111].common == true)
                {
                    this.B0_S112_Import.Enabled = false;
                    this.B0_S112_Common.Checked = true;
                }
                else
                {
                    this.B0_S112_Import.Enabled = true;
                    this.B0_S112_Common.Checked = false;
                }

                int start = Banks[0].samples[111].start;
                int id = Banks[0].samples[111].id;
                for (int i = 0; i < 127; i++)
                {
                    Sample smp = Banks[0].samples[i];
                    if (smp.enabled == true)
                    {
                        if (IsBetween(start, smp.start, smp.end))
                        {
                            if (Banks[0].samples[111].id > smp.id)
                            {
                                Banks[0].samples[smp.id].parents.Add(id);
                                Banks[0].samples[111].depends.Add(smp.id);
                                if (Banks[0].samples[111].depends.Count == 1)
                                {
                                    //find offset
                                    Banks[0].samples[111].offset = start - smp.start;
                                }
                            }
                        }
                    }
                }
                string deps = "";
                if (Banks[0].samples[111].common == true)
                {
                    Banks[0].samples[111].depends.Clear();
                    Banks[0].samples[111].offset = Banks[0].samples[111].start - 0x20000;
                }
                if (Banks[0].samples[111].depends.Count > 0)
                {
                    int dep = Banks[0].samples[111].depends[0];
                    {
                        deps = dep.ToString();
                    }
                }
                this.B0_S112_Dep.Text = deps;
                this.B0_S112_Off.Text = "0x" + Banks[0].samples[111].offset.ToString("x");
                this.B0_S112_Len.Text = "0x" + Banks[0].samples[111].length.ToString("x");
            }
            if (Banks[0].samples[112].enabled == true)
            {
                this.B0_S113_Enable.Enabled = true;
                this.B0_S113_Enable.Checked = true;
                this.B0_S113_Export.Enabled = true;

                if (Banks[0].samples[112].common == true)
                {
                    this.B0_S113_Import.Enabled = false;
                    this.B0_S113_Common.Checked = true;
                }
                else
                {
                    this.B0_S113_Import.Enabled = true;
                    this.B0_S113_Common.Checked = false;
                }

                int start = Banks[0].samples[112].start;
                int id = Banks[0].samples[112].id;
                for (int i = 0; i < 127; i++)
                {
                    Sample smp = Banks[0].samples[i];
                    if (smp.enabled == true)
                    {
                        if (IsBetween(start, smp.start, smp.end))
                        {
                            if (Banks[0].samples[112].id > smp.id)
                            {
                                Banks[0].samples[smp.id].parents.Add(id);
                                Banks[0].samples[112].depends.Add(smp.id);
                                if (Banks[0].samples[112].depends.Count == 1)
                                {
                                    //find offset
                                    Banks[0].samples[112].offset = start - smp.start;
                                }
                            }
                        }
                    }
                }
                string deps = "";
                if (Banks[0].samples[112].common == true)
                {
                    Banks[0].samples[112].depends.Clear();
                    Banks[0].samples[112].offset = Banks[0].samples[112].start - 0x20000;
                }

                if (Banks[0].samples[112].depends.Count > 0)
                {
                    int dep = Banks[0].samples[112].depends[0];
                    {
                        deps = dep.ToString();
                    }

                }
                this.B0_S113_Dep.Text = deps;
                this.B0_S113_Off.Text = "0x" + Banks[0].samples[112].offset.ToString("x");
                this.B0_S113_Len.Text = "0x" + Banks[0].samples[112].length.ToString("x");
            }
            if (Banks[0].samples[113].enabled == true)
            {
                this.B0_S114_Enable.Enabled = true;
                this.B0_S114_Enable.Checked = true;
                this.B0_S114_Export.Enabled = true;

                if (Banks[0].samples[113].common == true)
                {
                    this.B0_S114_Import.Enabled = false;
                    this.B0_S114_Common.Checked = true;
                }
                else
                {
                    this.B0_S114_Import.Enabled = true;
                    this.B0_S114_Common.Checked = false;
                }

                int start = Banks[0].samples[113].start;
                int id = Banks[0].samples[113].id;
                for (int i = 0; i < 127; i++)
                {
                    Sample smp = Banks[0].samples[i];
                    if (smp.enabled == true)
                    {
                        if (IsBetween(start, smp.start, smp.end))
                        {
                            if (Banks[0].samples[113].id > smp.id)
                            {
                                Banks[0].samples[smp.id].parents.Add(id);
                                Banks[0].samples[113].depends.Add(smp.id);
                                if (Banks[0].samples[113].depends.Count == 1)
                                {
                                    //find offset
                                    Banks[0].samples[113].offset = start - smp.start;
                                }
                            }
                        }
                    }
                }
                string deps = "";
                if (Banks[0].samples[113].common == true)
                {
                    Banks[0].samples[113].depends.Clear();
                    Banks[0].samples[113].offset = Banks[0].samples[113].start - 0x20000;
                }
                if (Banks[0].samples[113].depends.Count > 0)
                {
                    int dep = Banks[0].samples[113].depends[0];
                    {
                        deps = dep.ToString();
                    }

                }
                this.B0_S114_Dep.Text = deps;
                this.B0_S114_Off.Text = "0x" + Banks[0].samples[113].offset.ToString("x");
                this.B0_S114_Len.Text = "0x" + Banks[0].samples[113].length.ToString("x");
            }
            if (Banks[0].samples[114].enabled == true)
            {
                this.B0_S115_Enable.Enabled = true;
                this.B0_S115_Enable.Checked = true;
                this.B0_S115_Export.Enabled = true;

                if (Banks[0].samples[114].common == true)
                {
                    this.B0_S115_Import.Enabled = false;
                    this.B0_S115_Common.Checked = true;
                }
                else
                {
                    this.B0_S115_Import.Enabled = true;
                    this.B0_S115_Common.Checked = false;
                }

                int start = Banks[0].samples[114].start;
                int id = Banks[0].samples[114].id;
                for (int i = 0; i < 127; i++)
                {
                    Sample smp = Banks[0].samples[i];
                    if (smp.enabled == true)
                    {
                        if (IsBetween(start, smp.start, smp.end))
                        {
                            if (Banks[0].samples[114].id > smp.id)
                            {
                                Banks[0].samples[smp.id].parents.Add(id);
                                Banks[0].samples[114].depends.Add(smp.id);
                                if (Banks[0].samples[114].depends.Count == 1)
                                {
                                    //find offset
                                    Banks[0].samples[114].offset = start - smp.start;
                                }
                            }
                        }
                    }
                }
                string deps = "";
                if (Banks[0].samples[114].common == true)
                {
                    Banks[0].samples[114].depends.Clear();
                    Banks[0].samples[114].offset = Banks[0].samples[114].start - 0x20000;
                }
                if (Banks[0].samples[114].depends.Count > 0)
                {
                    int dep = Banks[0].samples[114].depends[0];
                    {
                        deps = dep.ToString();
                    }

                }
                this.B0_S115_Dep.Text = deps;
                this.B0_S115_Off.Text = "0x" + Banks[0].samples[114].offset.ToString("x");
                this.B0_S115_Len.Text = "0x" + Banks[0].samples[114].length.ToString("x");
            }
            if (Banks[0].samples[115].enabled == true)
            {
                this.B0_S116_Enable.Enabled = true;
                this.B0_S116_Enable.Checked = true;
                this.B0_S116_Export.Enabled = true;

                if (Banks[0].samples[115].common == true)
                {
                    this.B0_S116_Import.Enabled = false;
                    this.B0_S116_Common.Checked = true;
                }
                else
                {
                    this.B0_S116_Import.Enabled = true;
                    this.B0_S116_Common.Checked = false;
                }

                int start = Banks[0].samples[115].start;
                int id = Banks[0].samples[115].id;
                for (int i = 0; i < 127; i++)
                {
                    Sample smp = Banks[0].samples[i];
                    if (smp.enabled == true)
                    {
                        if (IsBetween(start, smp.start, smp.end))
                        {
                            if (Banks[0].samples[115].id > smp.id)
                            {
                                Banks[0].samples[smp.id].parents.Add(id);
                                Banks[0].samples[115].depends.Add(smp.id);
                                if (Banks[0].samples[115].depends.Count == 1)
                                {
                                    //find offset
                                    Banks[0].samples[115].offset = start - smp.start;
                                }
                            }
                        }
                    }
                }
                string deps = "";
                if (Banks[0].samples[115].common == true)
                {
                    Banks[0].samples[115].depends.Clear();
                    Banks[0].samples[115].offset = Banks[0].samples[115].start - 0x20000;
                }
                if (Banks[0].samples[115].depends.Count > 0)
                {
                    int dep = Banks[0].samples[115].depends[0];
                    {
                        deps = dep.ToString();
                    }

                }
                this.B0_S116_Dep.Text = deps;
                this.B0_S116_Off.Text = "0x" + Banks[0].samples[115].offset.ToString("x");
                this.B0_S116_Len.Text = "0x" + Banks[0].samples[115].length.ToString("x");
            }
            if (Banks[0].samples[116].enabled == true)
            {
                this.B0_S117_Enable.Enabled = true;
                this.B0_S117_Enable.Checked = true;
                this.B0_S117_Export.Enabled = true;

                if (Banks[0].samples[116].common == true)
                {
                    this.B0_S117_Import.Enabled = false;
                    this.B0_S117_Common.Checked = true;
                }
                else
                {
                    this.B0_S117_Import.Enabled = true;
                    this.B0_S117_Common.Checked = false;
                }

                int start = Banks[0].samples[116].start;
                int id = Banks[0].samples[116].id;
                for (int i = 0; i < 127; i++)
                {
                    Sample smp = Banks[0].samples[i];
                    if (smp.enabled == true)
                    {
                        if (IsBetween(start, smp.start, smp.end))
                        {
                            if (Banks[0].samples[116].id > smp.id)
                            {
                                Banks[0].samples[smp.id].parents.Add(id);
                                Banks[0].samples[116].depends.Add(smp.id);
                                if (Banks[0].samples[116].depends.Count == 1)
                                {
                                    //find offset
                                    Banks[0].samples[116].offset = start - smp.start;
                                }
                            }
                        }
                    }
                }
                string deps = "";
                if (Banks[0].samples[116].common == true)
                {
                    Banks[0].samples[116].depends.Clear();
                    Banks[0].samples[116].offset = Banks[0].samples[116].start - 0x20000;
                }
                if (Banks[0].samples[116].depends.Count > 0)
                {
                    int dep = Banks[0].samples[116].depends[0];
                    {
                        deps = dep.ToString();
                    }

                }
                this.B0_S117_Dep.Text = deps;
                this.B0_S117_Off.Text = "0x" + Banks[0].samples[116].offset.ToString("x");
                this.B0_S117_Len.Text = "0x" + Banks[0].samples[116].length.ToString("x");
            }
            if (Banks[0].samples[117].enabled == true)
            {
                this.B0_S118_Enable.Enabled = true;
                this.B0_S118_Enable.Checked = true;
                this.B0_S118_Export.Enabled = true;

                if (Banks[0].samples[117].common == true)
                {
                    this.B0_S118_Import.Enabled = false;
                    this.B0_S118_Common.Checked = true;
                }
                else
                {
                    this.B0_S118_Import.Enabled = true;
                    this.B0_S118_Common.Checked = false;
                }

                int start = Banks[0].samples[117].start;
                int id = Banks[0].samples[117].id;
                for (int i = 0; i < 127; i++)
                {
                    Sample smp = Banks[0].samples[i];
                    if (smp.enabled == true)
                    {
                        if (IsBetween(start, smp.start, smp.end))
                        {
                            if (Banks[0].samples[117].id > smp.id)
                            {
                                Banks[0].samples[smp.id].parents.Add(id);
                                Banks[0].samples[117].depends.Add(smp.id);
                                if (Banks[0].samples[117].depends.Count == 1)
                                {
                                    //find offset
                                    Banks[0].samples[117].offset = start - smp.start;
                                }
                            }
                        }
                    }
                }
                string deps = "";
                if (Banks[0].samples[117].common == true)
                {
                    Banks[0].samples[117].depends.Clear();
                    Banks[0].samples[117].offset = Banks[0].samples[117].start - 0x20000;
                }
                if (Banks[0].samples[117].depends.Count > 0)
                {
                    int dep = Banks[0].samples[117].depends[0];
                    {
                        deps = dep.ToString();
                    }

                }
                this.B0_S118_Dep.Text = deps;
                this.B0_S118_Off.Text = "0x" + Banks[0].samples[117].offset.ToString("x");
                this.B0_S118_Len.Text = "0x" + Banks[0].samples[117].length.ToString("x");
            }
            if (Banks[0].samples[118].enabled == true)
            {
                this.B0_S119_Enable.Enabled = true;
                this.B0_S119_Enable.Checked = true;
                this.B0_S119_Export.Enabled = true;

                if (Banks[0].samples[118].common == true)
                {
                    this.B0_S119_Import.Enabled = false;
                    this.B0_S119_Common.Checked = true;
                }
                else
                {
                    this.B0_S119_Import.Enabled = true;
                    this.B0_S119_Common.Checked = false;
                }

                int start = Banks[0].samples[118].start;
                int id = Banks[0].samples[118].id;
                for (int i = 0; i < 127; i++)
                {
                    Sample smp = Banks[0].samples[i];
                    if (smp.enabled == true)
                    {
                        if (IsBetween(start, smp.start, smp.end))
                        {
                            if (Banks[0].samples[118].id > smp.id)
                            {
                                Banks[0].samples[smp.id].parents.Add(id);
                                Banks[0].samples[118].depends.Add(smp.id);
                                if (Banks[0].samples[118].depends.Count == 1)
                                {
                                    //find offset
                                    Banks[0].samples[118].offset = start - smp.start;
                                }
                            }
                        }
                    }
                }
                string deps = "";
                if (Banks[0].samples[118].common == true)
                {
                    Banks[0].samples[118].depends.Clear();
                    Banks[0].samples[118].offset = Banks[0].samples[118].start - 0x20000;
                }
                if (Banks[0].samples[118].depends.Count > 0)
                {
                    int dep = Banks[0].samples[118].depends[0];
                    {
                        deps = dep.ToString();
                    }

                }
                this.B0_S119_Dep.Text = deps;
                this.B0_S119_Off.Text = "0x" + Banks[0].samples[118].offset.ToString("x");
                this.B0_S119_Len.Text = "0x" + Banks[0].samples[118].length.ToString("x");
            }
            if (Banks[0].samples[119].enabled == true)
            {
                this.B0_S120_Enable.Enabled = true;
                this.B0_S120_Enable.Checked = true;
                this.B0_S120_Export.Enabled = true;

                if (Banks[0].samples[119].common == true)
                {
                    this.B0_S120_Import.Enabled = false;
                    this.B0_S120_Common.Checked = true;
                }
                else
                {
                    this.B0_S120_Import.Enabled = true;
                    this.B0_S120_Common.Checked = false;
                }

                int start = Banks[0].samples[119].start;
                int id = Banks[0].samples[119].id;
                for (int i = 0; i < 127; i++)
                {
                    Sample smp = Banks[0].samples[i];
                    if (smp.enabled == true)
                    {
                        if (IsBetween(start, smp.start, smp.end))
                        {
                            if (Banks[0].samples[119].id > smp.id)
                            {
                                Banks[0].samples[smp.id].parents.Add(id);
                                Banks[0].samples[119].depends.Add(smp.id);
                                if (Banks[0].samples[119].depends.Count == 1)
                                {
                                    //find offset
                                    Banks[0].samples[119].offset = start - smp.start;
                                }
                            }
                        }
                    }
                }
                string deps = "";
                if (Banks[0].samples[119].common == true)
                {
                    Banks[0].samples[119].depends.Clear();
                    Banks[0].samples[119].offset = Banks[0].samples[119].start - 0x20000;
                }
                if (Banks[0].samples[119].depends.Count > 0)
                {
                    int dep = Banks[0].samples[119].depends[0];
                    {
                        deps = dep.ToString();
                    }

                }
                this.B0_S120_Dep.Text = deps;
                this.B0_S120_Off.Text = "0x" + Banks[0].samples[119].offset.ToString("x");
                this.B0_S120_Len.Text = "0x" + Banks[0].samples[119].length.ToString("x");
            }
            if (Banks[0].samples[120].enabled == true)
            {
                this.B0_S121_Enable.Enabled = true;
                this.B0_S121_Enable.Checked = true;
                this.B0_S121_Export.Enabled = true;

                if (Banks[0].samples[120].common == true)
                {
                    this.B0_S121_Import.Enabled = false;
                    this.B0_S121_Common.Checked = true;
                }
                else
                {
                    this.B0_S121_Import.Enabled = true;
                    this.B0_S121_Common.Checked = false;
                }

                int start = Banks[0].samples[120].start;
                int id = Banks[0].samples[120].id;
                for (int i = 0; i < 127; i++)
                {
                    Sample smp = Banks[0].samples[i];
                    if (smp.enabled == true)
                    {
                        if (IsBetween(start, smp.start, smp.end))
                        {
                            if (Banks[0].samples[120].id > smp.id)
                            {
                                Banks[0].samples[smp.id].parents.Add(id);
                                Banks[0].samples[120].depends.Add(smp.id);
                                if (Banks[0].samples[120].depends.Count == 1)
                                {
                                    //find offset
                                    Banks[0].samples[120].offset = start - smp.start;
                                }
                            }
                        }
                    }
                }
                string deps = "";
                if (Banks[0].samples[120].common == true)
                {
                    Banks[0].samples[120].depends.Clear();
                    Banks[0].samples[120].offset = Banks[0].samples[120].start - 0x20000;
                }
                if (Banks[0].samples[120].depends.Count > 0)
                {
                    int dep = Banks[0].samples[120].depends[0];
                    {
                        deps = dep.ToString();
                    }
                }
                this.B0_S121_Dep.Text = deps;
                this.B0_S121_Off.Text = "0x" + Banks[0].samples[120].offset.ToString("x");
                this.B0_S121_Len.Text = "0x" + Banks[0].samples[120].length.ToString("x");
            }
            if (Banks[0].samples[121].enabled == true)
            {
                this.B0_S122_Enable.Enabled = true;
                this.B0_S122_Enable.Checked = true;
                this.B0_S122_Export.Enabled = true;

                if (Banks[0].samples[121].common == true)
                {
                    this.B0_S122_Import.Enabled = false;
                    this.B0_S122_Common.Checked = true;
                }
                else
                {
                    this.B0_S122_Import.Enabled = true;
                    this.B0_S122_Common.Checked = false;
                }

                int start = Banks[0].samples[121].start;
                int id = Banks[0].samples[121].id;
                for (int i = 0; i < 127; i++)
                {
                    Sample smp = Banks[0].samples[i];
                    if (smp.enabled == true)
                    {
                        if (IsBetween(start, smp.start, smp.end))
                        {
                            if (Banks[0].samples[121].id > smp.id)
                            {
                                Banks[0].samples[smp.id].parents.Add(id);
                                Banks[0].samples[121].depends.Add(smp.id);
                                if (Banks[0].samples[121].depends.Count == 1)
                                {
                                    //find offset
                                    Banks[0].samples[121].offset = start - smp.start;
                                }
                            }
                        }
                    }
                }
                string deps = "";
                if (Banks[0].samples[121].common == true)
                {
                    Banks[0].samples[121].depends.Clear();
                    Banks[0].samples[121].offset = Banks[0].samples[121].start - 0x20000;
                }
                if (Banks[0].samples[121].depends.Count > 0)
                {
                    int dep = Banks[0].samples[121].depends[0];
                    {
                        deps = dep.ToString();
                    }
                }
                this.B0_S122_Dep.Text = deps;
                this.B0_S122_Off.Text = "0x" + Banks[0].samples[121].offset.ToString("x");
                this.B0_S122_Len.Text = "0x" + Banks[0].samples[121].length.ToString("x");
            }
            if (Banks[0].samples[122].enabled == true)
            {
                this.B0_S123_Enable.Enabled = true;
                this.B0_S123_Enable.Checked = true;
                this.B0_S123_Export.Enabled = true;

                if (Banks[0].samples[122].common == true)
                {
                    this.B0_S123_Import.Enabled = false;
                    this.B0_S123_Common.Checked = true;
                }
                else
                {
                    this.B0_S123_Import.Enabled = true;
                    this.B0_S123_Common.Checked = false;
                }

                int start = Banks[0].samples[122].start;
                int id = Banks[0].samples[122].id;
                for (int i = 0; i < 127; i++)
                {
                    Sample smp = Banks[0].samples[i];
                    if (smp.enabled == true)
                    {
                        if (IsBetween(start, smp.start, smp.end))
                        {
                            if (Banks[0].samples[122].id > smp.id)
                            {
                                Banks[0].samples[smp.id].parents.Add(id);
                                Banks[0].samples[122].depends.Add(smp.id);
                                if (Banks[0].samples[122].depends.Count == 1)
                                {
                                    //find offset
                                    Banks[0].samples[122].offset = start - smp.start;
                                }
                            }
                        }
                    }
                }
                string deps = "";
                if (Banks[0].samples[122].common == true)
                {
                    Banks[0].samples[122].depends.Clear();
                    Banks[0].samples[122].offset = Banks[0].samples[122].start - 0x20000;
                }

                if (Banks[0].samples[122].depends.Count > 0)
                {
                    int dep = Banks[0].samples[122].depends[0];
                    {
                        deps = dep.ToString();
                    }

                }
                this.B0_S123_Dep.Text = deps;
                this.B0_S123_Off.Text = "0x" + Banks[0].samples[122].offset.ToString("x");
                this.B0_S123_Len.Text = "0x" + Banks[0].samples[122].length.ToString("x");
            }
            if (Banks[0].samples[123].enabled == true)
            {
                this.B0_S124_Enable.Enabled = true;
                this.B0_S124_Enable.Checked = true;
                this.B0_S124_Export.Enabled = true;

                if (Banks[0].samples[123].common == true)
                {
                    this.B0_S124_Import.Enabled = false;
                    this.B0_S124_Common.Checked = true;
                }
                else
                {
                    this.B0_S124_Import.Enabled = true;
                    this.B0_S124_Common.Checked = false;
                }

                int start = Banks[0].samples[123].start;
                int id = Banks[0].samples[123].id;
                for (int i = 0; i < 127; i++)
                {
                    Sample smp = Banks[0].samples[i];
                    if (smp.enabled == true)
                    {
                        if (IsBetween(start, smp.start, smp.end))
                        {
                            if (Banks[0].samples[123].id > smp.id)
                            {
                                Banks[0].samples[smp.id].parents.Add(id);
                                Banks[0].samples[123].depends.Add(smp.id);
                                if (Banks[0].samples[123].depends.Count == 1)
                                {
                                    //find offset
                                    Banks[0].samples[123].offset = start - smp.start;
                                }
                            }
                        }
                    }
                }
                string deps = "";
                if (Banks[0].samples[123].common == true)
                {
                    Banks[0].samples[123].depends.Clear();
                    Banks[0].samples[123].offset = Banks[0].samples[123].start - 0x20000;
                }
                if (Banks[0].samples[123].depends.Count > 0)
                {
                    int dep = Banks[0].samples[123].depends[0];
                    {
                        deps = dep.ToString();
                    }

                }
                this.B0_S124_Dep.Text = deps;
                this.B0_S124_Off.Text = "0x" + Banks[0].samples[123].offset.ToString("x");
                this.B0_S124_Len.Text = "0x" + Banks[0].samples[123].length.ToString("x");
            }
            if (Banks[0].samples[124].enabled == true)
            {
                this.B0_S125_Enable.Enabled = true;
                this.B0_S125_Enable.Checked = true;
                this.B0_S125_Export.Enabled = true;

                if (Banks[0].samples[124].common == true)
                {
                    this.B0_S125_Import.Enabled = false;
                    this.B0_S125_Common.Checked = true;
                }
                else
                {
                    this.B0_S125_Import.Enabled = true;
                    this.B0_S125_Common.Checked = false;
                }

                int start = Banks[0].samples[124].start;
                int id = Banks[0].samples[124].id;
                for (int i = 0; i < 127; i++)
                {
                    Sample smp = Banks[0].samples[i];
                    if (smp.enabled == true)
                    {
                        if (IsBetween(start, smp.start, smp.end))
                        {
                            if (Banks[0].samples[124].id > smp.id)
                            {
                                Banks[0].samples[smp.id].parents.Add(id);
                                Banks[0].samples[124].depends.Add(smp.id);
                                if (Banks[0].samples[124].depends.Count == 1)
                                {
                                    //find offset
                                    Banks[0].samples[124].offset = start - smp.start;
                                }
                            }
                        }
                    }
                }
                string deps = "";
                if (Banks[0].samples[124].common == true)
                {
                    Banks[0].samples[124].depends.Clear();
                    Banks[0].samples[124].offset = Banks[0].samples[124].start - 0x20000;
                }
                if (Banks[0].samples[124].depends.Count > 0)
                {
                    int dep = Banks[0].samples[124].depends[0];
                    {
                        deps = dep.ToString();
                    }

                }
                this.B0_S125_Dep.Text = deps;
                this.B0_S125_Off.Text = "0x" + Banks[0].samples[124].offset.ToString("x");
                this.B0_S125_Len.Text = "0x" + Banks[0].samples[124].length.ToString("x");
            }
            if (Banks[0].samples[125].enabled == true)
            {
                this.B0_S126_Enable.Enabled = true;
                this.B0_S126_Enable.Checked = true;
                this.B0_S126_Export.Enabled = true;

                if (Banks[0].samples[125].common == true)
                {
                    this.B0_S126_Import.Enabled = false;
                    this.B0_S126_Common.Checked = true;
                }
                else
                {
                    this.B0_S126_Import.Enabled = true;
                    this.B0_S126_Common.Checked = false;
                }

                int start = Banks[0].samples[125].start;
                int id = Banks[0].samples[125].id;
                for (int i = 0; i < 127; i++)
                {
                    Sample smp = Banks[0].samples[i];
                    if (smp.enabled == true)
                    {
                        if (IsBetween(start, smp.start, smp.end))
                        {
                            if (Banks[0].samples[125].id > smp.id)
                            {
                                Banks[0].samples[smp.id].parents.Add(id);
                                Banks[0].samples[125].depends.Add(smp.id);
                                if (Banks[0].samples[125].depends.Count == 1)
                                {
                                    //find offset
                                    Banks[0].samples[125].offset = start - smp.start;
                                }
                            }
                        }
                    }
                }
                string deps = "";
                if (Banks[0].samples[125].common == true)
                {
                    Banks[0].samples[125].depends.Clear();
                    Banks[0].samples[125].offset = Banks[0].samples[125].start - 0x20000;
                }
                if (Banks[0].samples[125].depends.Count > 0)
                {
                    int dep = Banks[0].samples[125].depends[0];
                    {
                        deps = dep.ToString();
                    }

                }
                this.B0_S126_Dep.Text = deps;
                this.B0_S126_Off.Text = "0x" + Banks[0].samples[125].offset.ToString("x");
                this.B0_S126_Len.Text = "0x" + Banks[0].samples[125].length.ToString("x");
            }
            if (Banks[0].samples[126].enabled == true)
            {
                this.B0_S127_Enable.Enabled = true;
                this.B0_S127_Enable.Checked = true;
                this.B0_S127_Export.Enabled = true;

                if (Banks[0].samples[126].common == true)
                {
                    this.B0_S127_Import.Enabled = false;
                    this.B0_S127_Common.Checked = true;
                }
                else
                {
                    this.B0_S127_Import.Enabled = true;
                    this.B0_S127_Common.Checked = false;
                }

                int start = Banks[0].samples[126].start;
                int id = Banks[0].samples[126].id;
                for (int i = 0; i < 127; i++)
                {
                    Sample smp = Banks[0].samples[i];
                    if (smp.enabled == true)
                    {
                        if (IsBetween(start, smp.start, smp.end))
                        {
                            if (Banks[0].samples[126].id > smp.id)
                            {
                                Banks[0].samples[smp.id].parents.Add(id);
                                Banks[0].samples[126].depends.Add(smp.id);
                                if (Banks[0].samples[126].depends.Count == 1)
                                {
                                    //find offset
                                    Banks[0].samples[126].offset = start - smp.start;
                                }
                            }
                        }
                    }
                }
                string deps = "";
                if (Banks[0].samples[126].common == true)
                {
                    Banks[0].samples[126].depends.Clear();
                    Banks[0].samples[126].offset = Banks[0].samples[126].start - 0x20000;
                }
                if (Banks[0].samples[126].depends.Count > 0)
                {
                    int dep = Banks[0].samples[126].depends[0];
                    {
                        deps = dep.ToString();
                    }

                }
                this.B0_S127_Dep.Text = deps;
                this.B0_S127_Off.Text = "0x" + Banks[0].samples[126].offset.ToString("x");
                this.B0_S127_Len.Text = "0x" + Banks[0].samples[126].length.ToString("x");
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
            Banks[0].sparespace = totalsize;

            if (totalsize < 0)
            {
                bank1bytes.Text = "-0x" + Math.Abs(totalsize).ToString("x");
            }
            else
            {
                bank1bytes.Text = "0x" + totalsize.ToString("x");
            }
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
        private void B0_S2_Export_Click(object sender, EventArgs e)
        {
            exportRAWfile(0, 1);
        }
        private void B0_S3_Export_Click(object sender, EventArgs e)
        {
            exportRAWfile(0, 2);
        }
        private void B0_S4_Export_Click(object sender, EventArgs e)
        {
            exportRAWfile(0, 3);
        }
        private void B0_S5_Export_Click(object sender, EventArgs e)
        {
            exportRAWfile(0, 4);
        }
        private void B0_S6_Export_Click(object sender, EventArgs e)
        {
            exportRAWfile(0, 5);
        }
        private void B0_S7_Export_Click(object sender, EventArgs e)
        {
            exportRAWfile(0, 6);
        }
        private void B0_S8_Export_Click(object sender, EventArgs e)
        {
            exportRAWfile(0, 7);
        }
        private void B0_S9_Export_Click(object sender, EventArgs e)
        {
            exportRAWfile(0, 8);
        }
        private void B0_S10_Export_Click(object sender, EventArgs e)
        {
            exportRAWfile(0, 9);
        }
        private void B0_S11_Export_Click(object sender, EventArgs e)
        {
            exportRAWfile(0, 10);
        }
        private void B0_S12_Export_Click(object sender, EventArgs e)
        {
            exportRAWfile(0, 11);
        }
        private void B0_S13_Export_Click(object sender, EventArgs e)
        {
            exportRAWfile(0, 12);
        }
        private void B0_S14_Export_Click(object sender, EventArgs e)
        {
            exportRAWfile(0, 13);
        }
        private void B0_S15_Export_Click(object sender, EventArgs e)
        {
            exportRAWfile(0, 14);
        }
        private void B0_S16_Export_Click(object sender, EventArgs e)
        {
            exportRAWfile(0, 15);
        }
        private void B0_S17_Export_Click(object sender, EventArgs e)
        {
            exportRAWfile(0, 16);
        }
        private void B0_S18_Export_Click(object sender, EventArgs e)
        {
            exportRAWfile(0, 17);
        }
        private void B0_S19_Export_Click(object sender, EventArgs e)
        {
            exportRAWfile(0, 18);
        }
        private void B0_S20_Export_Click(object sender, EventArgs e)
        {
            exportRAWfile(0, 19);
        }
        private void B0_S21_Export_Click(object sender, EventArgs e)
        {
            exportRAWfile(0, 20);
        }
        private void B0_S22_Export_Click(object sender, EventArgs e)
        {
            exportRAWfile(0, 21);
        }
        private void B0_S23_Export_Click(object sender, EventArgs e)
        {
            exportRAWfile(0, 22);
        }
        private void B0_S24_Export_Click(object sender, EventArgs e)
        {
            exportRAWfile(0, 23);
        }
        private void B0_S25_Export_Click(object sender, EventArgs e)
        {
            exportRAWfile(0, 24);
        }
        private void B0_S26_Export_Click(object sender, EventArgs e)
        {
            exportRAWfile(0, 25);
        }
        private void B0_S27_Export_Click(object sender, EventArgs e)
        {
            exportRAWfile(0, 26);
        }
        private void B0_S28_Export_Click(object sender, EventArgs e)
        {
            exportRAWfile(0, 27);
        }
        private void B0_S29_Export_Click(object sender, EventArgs e)
        {
            exportRAWfile(0, 28);
        }
        private void B0_S30_Export_Click(object sender, EventArgs e)
        {
            exportRAWfile(0, 29);
        }
        private void B0_S31_Export_Click(object sender, EventArgs e)
        {
            exportRAWfile(0, 30);
        }
        private void B0_S32_Export_Click(object sender, EventArgs e)
        {
            exportRAWfile(0, 31);
        }
        private void B0_S33_Export_Click(object sender, EventArgs e)
        {
            exportRAWfile(0, 32);
        }
        private void B0_S34_Export_Click(object sender, EventArgs e)
        {
            exportRAWfile(0, 33);
        }
        private void B0_S35_Export_Click(object sender, EventArgs e)
        {
            exportRAWfile(0, 34);
        }
        private void B0_S36_Export_Click(object sender, EventArgs e)
        {
            exportRAWfile(0, 35);
        }
        private void B0_S37_Export_Click(object sender, EventArgs e)
        {
            exportRAWfile(0, 36);
        }
        private void B0_S38_Export_Click(object sender, EventArgs e)
        {
            exportRAWfile(0, 37);
        }
        private void B0_S39_Export_Click(object sender, EventArgs e)
        {
            exportRAWfile(0, 38);
        }
        private void B0_S40_Export_Click(object sender, EventArgs e)
        {
            exportRAWfile(0, 39);
        }
        private void B0_S41_Export_Click(object sender, EventArgs e)
        {
            exportRAWfile(0, 40);
        }
        private void B0_S42_Export_Click(object sender, EventArgs e)
        {
            exportRAWfile(0, 41);
        }
        private void B0_S43_Export_Click(object sender, EventArgs e)
        {
            exportRAWfile(0, 42);
        }
        private void B0_S44_Export_Click(object sender, EventArgs e)
        {
            exportRAWfile(0, 43);
        }
        private void B0_S45_Export_Click(object sender, EventArgs e)
        {
            exportRAWfile(0, 44);
        }
        private void B0_S46_Export_Click(object sender, EventArgs e)
        {
            exportRAWfile(0, 45);
        }
        private void B0_S47_Export_Click(object sender, EventArgs e)
        {
            exportRAWfile(0, 46);
        }
        private void B0_S48_Export_Click(object sender, EventArgs e)
        {
            exportRAWfile(0, 47);
        }
        private void B0_S49_Export_Click(object sender, EventArgs e)
        {
            exportRAWfile(0, 48);
        }
        private void B0_S50_Export_Click(object sender, EventArgs e)
        {
            exportRAWfile(0, 49);
        }
        private void B0_S51_Export_Click(object sender, EventArgs e)
        {
            exportRAWfile(0, 50);
        }
        private void B0_S52_Export_Click(object sender, EventArgs e)
        {
            exportRAWfile(0, 51);
        }
        private void B0_S53_Export_Click(object sender, EventArgs e)
        {
            exportRAWfile(0, 52);
        }
        private void B0_S54_Export_Click(object sender, EventArgs e)
        {
            exportRAWfile(0, 53);
        }
        private void B0_S55_Export_Click(object sender, EventArgs e)
        {
            exportRAWfile(0, 54);
        }
        private void B0_S56_Export_Click(object sender, EventArgs e)
        {
            exportRAWfile(0, 55);
        }
        private void B0_S57_Export_Click(object sender, EventArgs e)
        {
            exportRAWfile(0, 56);
        }
        private void B0_S58_Export_Click(object sender, EventArgs e)
        {
            exportRAWfile(0, 57);
        }
        private void B0_S59_Export_Click(object sender, EventArgs e)
        {
            exportRAWfile(0, 58);
        }
        private void B0_S60_Export_Click(object sender, EventArgs e)
        {
            exportRAWfile(0, 59);
        }
        private void B0_S61_Export_Click(object sender, EventArgs e)
        {
            exportRAWfile(0, 60);
        }
        private void B0_S62_Export_Click(object sender, EventArgs e)
        {
            exportRAWfile(0, 61);
        }
        private void B0_S63_Export_Click(object sender, EventArgs e)
        {
            exportRAWfile(0, 62);
        }
        private void B0_S64_Export_Click(object sender, EventArgs e)
        {
            exportRAWfile(0, 63);
        }
        private void B0_S65_Export_Click(object sender, EventArgs e)
        {
            exportRAWfile(0, 64);
        }
        private void B0_S66_Export_Click(object sender, EventArgs e)
        {
            exportRAWfile(0, 65);
        }
        private void B0_S67_Export_Click(object sender, EventArgs e)
        {
            exportRAWfile(0, 66);
        }
        private void B0_S68_Export_Click(object sender, EventArgs e)
        {
            exportRAWfile(0, 67);
        }
        private void B0_S69_Export_Click(object sender, EventArgs e)
        {
            exportRAWfile(0, 68);
        }
        private void B0_S70_Export_Click(object sender, EventArgs e)
        {
            exportRAWfile(0, 69);
        }
        private void B0_S71_Export_Click(object sender, EventArgs e)
        {
            exportRAWfile(0, 70);
        }
        private void B0_S72_Export_Click(object sender, EventArgs e)
        {
            exportRAWfile(0, 71);
        }
        private void B0_S73_Export_Click(object sender, EventArgs e)
        {
            exportRAWfile(0, 72);
        }
        private void B0_S74_Export_Click(object sender, EventArgs e)
        {
            exportRAWfile(0, 73);
        }
        private void B0_S75_Export_Click(object sender, EventArgs e)
        {
            exportRAWfile(0, 74);
        }
        private void B0_S76_Export_Click(object sender, EventArgs e)
        {
            exportRAWfile(0, 75);
        }
        private void B0_S77_Export_Click(object sender, EventArgs e)
        {
            exportRAWfile(0, 76);
        }
        private void B0_S78_Export_Click(object sender, EventArgs e)
        {
            exportRAWfile(0, 77);
        }
        private void B0_S79_Export_Click(object sender, EventArgs e)
        {
            exportRAWfile(0, 78);
        }
        private void B0_S80_Export_Click(object sender, EventArgs e)
        {
            exportRAWfile(0, 79);
        }
        private void B0_S81_Export_Click(object sender, EventArgs e)
        {
            exportRAWfile(0, 80);
        }
        private void B0_S82_Export_Click(object sender, EventArgs e)
        {
            exportRAWfile(0, 81);
        }
        private void B0_S83_Export_Click(object sender, EventArgs e)
        {
            exportRAWfile(0, 82);
        }
        private void B0_S84_Export_Click(object sender, EventArgs e)
        {
            exportRAWfile(0, 83);
        }
        private void B0_S85_Export_Click(object sender, EventArgs e)
        {
            exportRAWfile(0, 84);
        }
        private void B0_S86_Export_Click(object sender, EventArgs e)
        {
            exportRAWfile(0, 85);
        }
        private void B0_S87_Export_Click(object sender, EventArgs e)
        {
            exportRAWfile(0, 86);
        }
        private void B0_S88_Export_Click(object sender, EventArgs e)
        {
            exportRAWfile(0, 87);
        }
        private void B0_S89_Export_Click(object sender, EventArgs e)
        {
            exportRAWfile(0, 88);
        }
        private void B0_S90_Export_Click(object sender, EventArgs e)
        {
            exportRAWfile(0, 89);
        }
        private void B0_S91_Export_Click(object sender, EventArgs e)
        {
            exportRAWfile(0, 90);
        }
        private void B0_S92_Export_Click(object sender, EventArgs e)
        {
            exportRAWfile(0, 91);
        }
        private void B0_S93_Export_Click(object sender, EventArgs e)
        {
            exportRAWfile(0, 92);
        }
        private void B0_S94_Export_Click(object sender, EventArgs e)
        {
            exportRAWfile(0, 93);
        }
        private void B0_S95_Export_Click(object sender, EventArgs e)
        {
            exportRAWfile(0, 94);
        }
        private void B0_S96_Export_Click(object sender, EventArgs e)
        {
            exportRAWfile(0, 95);
        }
        private void B0_S97_Export_Click(object sender, EventArgs e)
        {
            exportRAWfile(0, 96);
        }
        private void B0_S98_Export_Click(object sender, EventArgs e)
        {
            exportRAWfile(0, 97);
        }
        private void B0_S99_Export_Click(object sender, EventArgs e)
        {
            exportRAWfile(0, 98);
        }
        private void B0_S100_Export_Click(object sender, EventArgs e)
        {
            exportRAWfile(0, 99);
        }
        private void B0_S101_Export_Click(object sender, EventArgs e)
        {
            exportRAWfile(0, 100);
        }
        private void B0_S102_Export_Click(object sender, EventArgs e)
        {
            exportRAWfile(0, 101);
        }
        private void B0_S103_Export_Click(object sender, EventArgs e)
        {
            exportRAWfile(0, 102);
        }
        private void B0_S104_Export_Click(object sender, EventArgs e)
        {
            exportRAWfile(0, 103);
        }
        private void B0_S105_Export_Click(object sender, EventArgs e)
        {
            exportRAWfile(0, 104);
        }
        private void B0_S106_Export_Click(object sender, EventArgs e)
        {
            exportRAWfile(0, 105);
        }
        private void B0_S107_Export_Click(object sender, EventArgs e)
        {
            exportRAWfile(0, 106);
        }
        private void B0_S108_Export_Click(object sender, EventArgs e)
        {
            exportRAWfile(0, 107);
        }
        private void B0_S109_Export_Click(object sender, EventArgs e)
        {
            exportRAWfile(0, 108);
        }
        private void B0_S110_Export_Click(object sender, EventArgs e)
        {
            exportRAWfile(0, 109);
        }
        private void B0_S111_Export_Click(object sender, EventArgs e)
        {
            exportRAWfile(0, 110);
        }
        private void B0_S112_Export_Click(object sender, EventArgs e)
        {
            exportRAWfile(0, 111);
        }
        private void B0_S113_Export_Click(object sender, EventArgs e)
        {
            exportRAWfile(0, 112);
        }
        private void B0_S114_Export_Click(object sender, EventArgs e)
        {
            exportRAWfile(0, 113);
        }
        private void B0_S115_Export_Click(object sender, EventArgs e)
        {
            exportRAWfile(0, 114);
        }
        private void B0_S116_Export_Click(object sender, EventArgs e)
        {
            exportRAWfile(0, 115);
        }
        private void B0_S117_Export_Click(object sender, EventArgs e)
        {
            exportRAWfile(0, 116);
        }
        private void B0_S118_Export_Click(object sender, EventArgs e)
        {
            exportRAWfile(0, 117);
        }
        private void B0_S119_Export_Click(object sender, EventArgs e)
        {
            exportRAWfile(0, 118);
        }
        private void B0_S120_Export_Click(object sender, EventArgs e)
        {
            exportRAWfile(0, 119);
        }
        private void B0_S121_Export_Click(object sender, EventArgs e)
        {
            exportRAWfile(0, 120);
        }
        private void B0_S122_Export_Click(object sender, EventArgs e)
        {
            exportRAWfile(0, 121);
        }
        private void B0_S123_Export_Click(object sender, EventArgs e)
        {
            exportRAWfile(0, 122);
        }
        private void B0_S124_Export_Click(object sender, EventArgs e)
        {
            exportRAWfile(0, 123);
        }
        private void B0_S125_Export_Click(object sender, EventArgs e)
        {
            exportRAWfile(0, 124);
        }
        private void B0_S126_Export_Click(object sender, EventArgs e)
        {
            exportRAWfile(0, 125);
        }
        private void B0_S127_Export_Click(object sender, EventArgs e)
        {
            exportRAWfile(0, 126);
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
                Sample smp = Banks[bank].samples[sample];

                if (smp.depends.Count > 0)
                {
                    int StartPosition = smp.offset;
                    int EndPosition = StartPosition + smp.length;
                    byte[] tmp = new byte[smp.length];

                    Array.Copy(smp.RAW, smp.offset, tmp, 0, smp.length);
                    File.WriteAllBytes(SF.FileName, tmp);
                }
                else
                {
                    File.WriteAllBytes(SF.FileName, Banks[bank].samples[sample].RAW);
                }
            }

        }

        private void B0_S1_Import_Click(object sender, EventArgs e)
        {
            importRAWfile(0, 0);
        }
        private void B0_S2_Import_Click(object sender, EventArgs e)
        {
            importRAWfile(0, 1);
        }
        private void B0_S3_Import_Click(object sender, EventArgs e)
        {
            importRAWfile(0, 2);
        }
        private void B0_S4_Import_Click(object sender, EventArgs e)
        {
            importRAWfile(0, 3);
        }
        private void B0_S5_Import_Click(object sender, EventArgs e)
        {
            importRAWfile(0, 4);
        }
        private void B0_S6_Import_Click(object sender, EventArgs e)
        {
            importRAWfile(0, 5);
        }
        private void B0_S7_Import_Click(object sender, EventArgs e)
        {
            importRAWfile(0, 6);
        }
        private void B0_S8_Import_Click(object sender, EventArgs e)
        {
            importRAWfile(0, 7);
        }
        private void B0_S9_Import_Click(object sender, EventArgs e)
        {
            importRAWfile(0, 8);
        }
        private void B0_S10_Import_Click(object sender, EventArgs e)
        {
            importRAWfile(0, 9);
        }
        private void B0_S11_Import_Click(object sender, EventArgs e)
        {
            importRAWfile(0, 10);
        }
        private void B0_S12_Import_Click(object sender, EventArgs e)
        {
            importRAWfile(0, 11);
        }
        private void B0_S13_Import_Click(object sender, EventArgs e)
        {
            importRAWfile(0, 12);
        }
        private void B0_S14_Import_Click(object sender, EventArgs e)
        {
            importRAWfile(0, 13);
        }
        private void B0_S15_Import_Click(object sender, EventArgs e)
        {
            importRAWfile(0, 14);
        }
        private void B0_S16_Import_Click(object sender, EventArgs e)
        {
            importRAWfile(0, 15);
        }
        private void B0_S17_Import_Click(object sender, EventArgs e)
        {
            importRAWfile(0, 16);
        }
        private void B0_S18_Import_Click(object sender, EventArgs e)
        {
            importRAWfile(0, 17);
        }
        private void B0_S19_Import_Click(object sender, EventArgs e)
        {
            importRAWfile(0, 18);
        }
        private void B0_S20_Import_Click(object sender, EventArgs e)
        {
            importRAWfile(0, 19);
        }
        private void B0_S21_Import_Click(object sender, EventArgs e)
        {
            importRAWfile(0, 20);
        }
        private void B0_S22_Import_Click(object sender, EventArgs e)
        {
            importRAWfile(0, 21);
        }
        private void B0_S23_Import_Click(object sender, EventArgs e)
        {
            importRAWfile(0, 22);
        }
        private void B0_S24_Import_Click(object sender, EventArgs e)
        {
            importRAWfile(0, 23);
        }
        private void B0_S25_Import_Click(object sender, EventArgs e)
        {
            importRAWfile(0, 24);
        }
        private void B0_S26_Import_Click(object sender, EventArgs e)
        {
            importRAWfile(0, 25);
        }
        private void B0_S27_Import_Click(object sender, EventArgs e)
        {
            importRAWfile(0, 26);
        }
        private void B0_S28_Import_Click(object sender, EventArgs e)
        {
            importRAWfile(0, 27);
        }
        private void B0_S29_Import_Click(object sender, EventArgs e)
        {
            importRAWfile(0, 28);
        }
        private void B0_S30_Import_Click(object sender, EventArgs e)
        {
            importRAWfile(0, 29);
        }
        private void B0_S31_Import_Click(object sender, EventArgs e)
        {
            importRAWfile(0, 30);
        }
        private void B0_S32_Import_Click(object sender, EventArgs e)
        {
            importRAWfile(0, 31);
        }
        private void B0_S33_Import_Click(object sender, EventArgs e)
        {
            importRAWfile(0, 32);
        }
        private void B0_S34_Import_Click(object sender, EventArgs e)
        {
            importRAWfile(0, 33);
        }
        private void B0_S35_Import_Click(object sender, EventArgs e)
        {
            importRAWfile(0, 34);
        }
        private void B0_S36_Import_Click(object sender, EventArgs e)
        {
            importRAWfile(0, 35);
        }
        private void B0_S37_Import_Click(object sender, EventArgs e)
        {
            importRAWfile(0, 36);
        }
        private void B0_S38_Import_Click(object sender, EventArgs e)
        {
            importRAWfile(0, 37);
        }
        private void B0_S39_Import_Click(object sender, EventArgs e)
        {
            importRAWfile(0, 38);
        }
        private void B0_S40_Import_Click(object sender, EventArgs e)
        {
            importRAWfile(0, 39);
        }
        private void B0_S41_Import_Click(object sender, EventArgs e)
        {
            importRAWfile(0, 40);
        }
        private void B0_S42_Import_Click(object sender, EventArgs e)
        {
            importRAWfile(0, 41);
        }
        private void B0_S43_Import_Click(object sender, EventArgs e)
        {
            importRAWfile(0, 42);
        }
        private void B0_S44_Import_Click(object sender, EventArgs e)
        {
            importRAWfile(0, 43);
        }
        private void B0_S45_Import_Click(object sender, EventArgs e)
        {
            importRAWfile(0, 44);
        }
        private void B0_S46_Import_Click(object sender, EventArgs e)
        {
            importRAWfile(0, 45);
        }
        private void B0_S47_Import_Click(object sender, EventArgs e)
        {
            importRAWfile(0, 46);
        }
        private void B0_S48_Import_Click(object sender, EventArgs e)
        {
            importRAWfile(0, 47);
        }
        private void B0_S49_Import_Click(object sender, EventArgs e)
        {
            importRAWfile(0, 48);
        }
        private void B0_S50_Import_Click(object sender, EventArgs e)
        {
            importRAWfile(0, 49);
        }
        private void B0_S51_Import_Click(object sender, EventArgs e)
        {
            importRAWfile(0, 50);
        }
        private void B0_S52_Import_Click(object sender, EventArgs e)
        {
            importRAWfile(0, 51);
        }
        private void B0_S53_Import_Click(object sender, EventArgs e)
        {
            importRAWfile(0, 52);
        }
        private void B0_S54_Import_Click(object sender, EventArgs e)
        {
            importRAWfile(0, 53);
        }
        private void B0_S55_Import_Click(object sender, EventArgs e)
        {
            importRAWfile(0, 54);
        }
        private void B0_S56_Import_Click(object sender, EventArgs e)
        {
            importRAWfile(0, 55);
        }
        private void B0_S57_Import_Click(object sender, EventArgs e)
        {
            importRAWfile(0, 56);
        }
        private void B0_S58_Import_Click(object sender, EventArgs e)
        {
            importRAWfile(0, 57);
        }
        private void B0_S59_Import_Click(object sender, EventArgs e)
        {
            importRAWfile(0, 58);
        }
        private void B0_S60_Import_Click(object sender, EventArgs e)
        {
            importRAWfile(0, 59);
        }
        private void B0_S61_Import_Click(object sender, EventArgs e)
        {
            importRAWfile(0, 60);
        }
        private void B0_S62_Import_Click(object sender, EventArgs e)
        {
            importRAWfile(0, 61);
        }
        private void B0_S63_Import_Click(object sender, EventArgs e)
        {
            importRAWfile(0, 62);
        }
        private void B0_S64_Import_Click(object sender, EventArgs e)
        {
            importRAWfile(0, 63);
        }
        private void B0_S65_Import_Click(object sender, EventArgs e)
        {
            importRAWfile(0, 64);
        }
        private void B0_S66_Import_Click(object sender, EventArgs e)
        {
            importRAWfile(0, 65);
        }
        private void B0_S67_Import_Click(object sender, EventArgs e)
        {
            importRAWfile(0, 66);
        }
        private void B0_S68_Import_Click(object sender, EventArgs e)
        {
            importRAWfile(0, 67);
        }
        private void B0_S69_Import_Click(object sender, EventArgs e)
        {
            importRAWfile(0, 68);
        }
        private void B0_S70_Import_Click(object sender, EventArgs e)
        {
            importRAWfile(0, 69);
        }
        private void B0_S71_Import_Click(object sender, EventArgs e)
        {
            importRAWfile(0, 70);
        }
        private void B0_S72_Import_Click(object sender, EventArgs e)
        {
            importRAWfile(0, 71);
        }
        private void B0_S73_Import_Click(object sender, EventArgs e)
        {
            importRAWfile(0, 72);
        }
        private void B0_S74_Import_Click(object sender, EventArgs e)
        {
            importRAWfile(0, 73);
        }
        private void B0_S75_Import_Click(object sender, EventArgs e)
        {
            importRAWfile(0, 74);
        }
        private void B0_S76_Import_Click(object sender, EventArgs e)
        {
            importRAWfile(0, 75);
        }
        private void B0_S77_Import_Click(object sender, EventArgs e)
        {
            importRAWfile(0, 76);
        }
        private void B0_S78_Import_Click(object sender, EventArgs e)
        {
            importRAWfile(0, 77);
        }
        private void B0_S79_Import_Click(object sender, EventArgs e)
        {
            importRAWfile(0, 78);
        }
        private void B0_S80_Import_Click(object sender, EventArgs e)
        {
            importRAWfile(0, 79);
        }
        private void B0_S81_Import_Click(object sender, EventArgs e)
        {
            importRAWfile(0, 80);
        }
        private void B0_S82_Import_Click(object sender, EventArgs e)
        {
            importRAWfile(0, 81);
        }
        private void B0_S83_Import_Click(object sender, EventArgs e)
        {
            importRAWfile(0, 82);
        }
        private void B0_S84_Import_Click(object sender, EventArgs e)
        {
            importRAWfile(0, 83);
        }
        private void B0_S85_Import_Click(object sender, EventArgs e)
        {
            importRAWfile(0, 84);
        }
        private void B0_S86_Import_Click(object sender, EventArgs e)
        {
            importRAWfile(0, 85);
        }
        private void B0_S87_Import_Click(object sender, EventArgs e)
        {
            importRAWfile(0, 86);
        }
        private void B0_S88_Import_Click(object sender, EventArgs e)
        {
            importRAWfile(0, 87);
        }
        private void B0_S89_Import_Click(object sender, EventArgs e)
        {
            importRAWfile(0, 88);
        }
        private void B0_S90_Import_Click(object sender, EventArgs e)
        {
            importRAWfile(0, 89);
        }
        private void B0_S91_Import_Click(object sender, EventArgs e)
        {
            importRAWfile(0, 90);
        }
        private void B0_S92_Import_Click(object sender, EventArgs e)
        {
            importRAWfile(0, 91);
        }
        private void B0_S93_Import_Click(object sender, EventArgs e)
        {
            importRAWfile(0, 92);
        }
        private void B0_S94_Import_Click(object sender, EventArgs e)
        {
            importRAWfile(0, 93);
        }
        private void B0_S95_Import_Click(object sender, EventArgs e)
        {
            importRAWfile(0, 94);
        }
        private void B0_S96_Import_Click(object sender, EventArgs e)
        {
            importRAWfile(0, 95);
        }
        private void B0_S97_Import_Click(object sender, EventArgs e)
        {
            importRAWfile(0, 96);
        }
        private void B0_S98_Import_Click(object sender, EventArgs e)
        {
            importRAWfile(0, 97);
        }
        private void B0_S99_Import_Click(object sender, EventArgs e)
        {
            importRAWfile(0, 98);
        }
        private void B0_S100_Import_Click(object sender, EventArgs e)
        {
            importRAWfile(0, 99);
        }
        private void B0_S101_Import_Click(object sender, EventArgs e)
        {
            importRAWfile(0, 100);
        }
        private void B0_S102_Import_Click(object sender, EventArgs e)
        {
            importRAWfile(0, 101);
        }
        private void B0_S103_Import_Click(object sender, EventArgs e)
        {
            importRAWfile(0, 102);
        }
        private void B0_S104_Import_Click(object sender, EventArgs e)
        {
            importRAWfile(0, 103);
        }
        private void B0_S105_Import_Click(object sender, EventArgs e)
        {
            importRAWfile(0, 104);
        }
        private void B0_S106_Import_Click(object sender, EventArgs e)
        {
            importRAWfile(0, 105);
        }
        private void B0_S107_Import_Click(object sender, EventArgs e)
        {
            importRAWfile(0, 106);
        }
        private void B0_S108_Import_Click(object sender, EventArgs e)
        {
            importRAWfile(0, 107);
        }
        private void B0_S109_Import_Click(object sender, EventArgs e)
        {
            importRAWfile(0, 108);
        }
        private void B0_S110_Import_Click(object sender, EventArgs e)
        {
            importRAWfile(0, 109);
        }
        private void B0_S111_Import_Click(object sender, EventArgs e)
        {
            importRAWfile(0, 110);
        }
        private void B0_S112_Import_Click(object sender, EventArgs e)
        {
            importRAWfile(0, 111);
        }
        private void B0_S113_Import_Click(object sender, EventArgs e)
        {
            importRAWfile(0, 112);
        }
        private void B0_S114_Import_Click(object sender, EventArgs e)
        {
            importRAWfile(0, 113);
        }
        private void B0_S115_Import_Click(object sender, EventArgs e)
        {
            importRAWfile(0, 114);
        }
        private void B0_S116_Import_Click(object sender, EventArgs e)
        {
            importRAWfile(0, 115);
        }
        private void B0_S117_Import_Click(object sender, EventArgs e)
        {
            importRAWfile(0, 116);
        }
        private void B0_S118_Import_Click(object sender, EventArgs e)
        {
            importRAWfile(0, 117);
        }
        private void B0_S119_Import_Click(object sender, EventArgs e)
        {
            importRAWfile(0, 118);
        }
        private void B0_S120_Import_Click(object sender, EventArgs e)
        {
            importRAWfile(0, 119);
        }
        private void B0_S121_Import_Click(object sender, EventArgs e)
        {
            importRAWfile(0, 120);
        }
        private void B0_S122_Import_Click(object sender, EventArgs e)
        {
            importRAWfile(0, 121);
        }
        private void B0_S123_Import_Click(object sender, EventArgs e)
        {
            importRAWfile(0, 122);
        }
        private void B0_S124_Import_Click(object sender, EventArgs e)
        {
            importRAWfile(0, 123);
        }
        private void B0_S125_Import_Click(object sender, EventArgs e)
        {
            importRAWfile(0, 124);
        }
        private void B0_S126_Import_Click(object sender, EventArgs e)
        {
            importRAWfile(0, 125);
        }
        private void B0_S127_Import_Click(object sender, EventArgs e)
        {
            importRAWfile(0, 126);
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
                byte[] tmp = File.ReadAllBytes(OF.FileName);

                int newspace = 0;
                if (Banks[bank].samples[sample].depends.Count > 0 && Banks[bank].samples[sample].depends.Count > 0)
                {
                    newspace = Banks[bank].sparespace;
                }
                else
                {
                    newspace = Banks[bank].sparespace - Banks[bank].samples[sample].RAW.Length;
                }

                int calcspace = newspace - tmp.Length;
                if (calcspace < 0)
                {
                    DialogResult confirmResult = MessageBox.Show("Importing this file will exceed the available space by 0x" +
                    Math.Abs(calcspace).ToString("x") + " bytes, proceed?", "Space Warning",
                                                         MessageBoxButtons.OKCancel);
                    if (confirmResult == DialogResult.OK)
                    {
                        Banks[bank].samples[sample].RAW = tmp;
                        Banks[bank].samples[sample].depends.Clear();
                        Banks[bank].samples[sample].common = false;
                        Banks[bank].samples[sample].offset = 0;
                        Banks[bank].samples[sample].start = sample * 0x40000;
                        Banks[bank].samples[sample].length = Banks[bank].samples[sample].RAW.Length;

                        switch (bank)
                        {
                            case 0:
                                setCtrl0();
                                break;
                                //case 2:
                                //    setCtrl2();
                                //    break;
                                //case 3:
                                //    setCtrl3();
                                //    break;
                                //case 4:
                                //    setCtrl4();
                                //    break;
                                //case 5:
                                //    setCtrl5();
                                //    break;
                                //case 6:
                                //    setCtrl6();
                                //    break;
                                //case 7:
                                //    setCtrl7();
                                //    break;
                                //case 8:
                                //    setCtrlCom();
                                //    break;
                        }
                    }
                }
                else
                {
                    Banks[bank].samples[sample].RAW = tmp;
                    Banks[bank].samples[sample].depends.Clear();
                    Banks[bank].samples[sample].common = false;
                    Banks[bank].samples[sample].offset = 0;
                    Banks[bank].samples[sample].start = sample * 0x40000;
                    Banks[bank].samples[sample].length = Banks[bank].samples[sample].RAW.Length;
                    switch (bank)
                    {
                        case 0:
                            setCtrl0();
                            break;
                            //case 2:
                            //    setCtrl2();
                            //    break;
                            //case 3:
                            //    setCtrl3();
                            //    break;
                            //case 4:
                            //    setCtrl4();
                            //    break;
                            //case 5:
                            //    setCtrl5();
                            //    break;
                            //case 6:
                            //    setCtrl6();
                            //    break;
                            //case 7:
                            //    setCtrl7();
                            //    break;
                            //case 8:
                            //    setCtrlCom();
                            //    break;
                    }
                }
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

        private void B0_S1_Len_Leave(object sender, EventArgs e)
        {
            updateLength(0, 1, B0_S1_Len.Text);
        }
        private void B0_S2_Len_Leave(object sender, EventArgs e)
        {
            updateLength(0, 2, B0_S2_Len.Text);
        }
        private void B0_S3_Len_Leave(object sender, EventArgs e)
        {
            updateLength(0, 3, B0_S3_Len.Text);
        }
        private void B0_S4_Len_Leave(object sender, EventArgs e)
        {
            updateLength(0, 4, B0_S4_Len.Text);
        }
        private void B0_S5_Len_Leave(object sender, EventArgs e)
        {
            updateLength(0, 5, B0_S5_Len.Text);
        }
        private void B0_S6_Len_Leave(object sender, EventArgs e)
        {
            updateLength(0, 6, B0_S6_Len.Text);
        }
        private void B0_S7_Len_Leave(object sender, EventArgs e)
        {
            updateLength(0, 7, B0_S7_Len.Text);
        }
        private void B0_S8_Len_Leave(object sender, EventArgs e)
        {
            updateLength(0, 8, B0_S8_Len.Text);
        }
        private void B0_S9_Len_Leave(object sender, EventArgs e)
        {
            updateLength(0, 9, B0_S9_Len.Text);
        }
        private void B0_S10_Len_Leave(object sender, EventArgs e)
        {
            updateLength(0, 10, B0_S10_Len.Text);
        }
        private void B0_S11_Len_Leave(object sender, EventArgs e)
        {
            updateLength(0, 11, B0_S11_Len.Text);
        }
        private void B0_S12_Len_Leave(object sender, EventArgs e)
        {
            updateLength(0, 12, B0_S12_Len.Text);
        }
        private void B0_S13_Len_Leave(object sender, EventArgs e)
        {
            updateLength(0, 13, B0_S13_Len.Text);
        }
        private void B0_S14_Len_Leave(object sender, EventArgs e)
        {
            updateLength(0, 14, B0_S14_Len.Text);
        }
        private void B0_S15_Len_Leave(object sender, EventArgs e)
        {
            updateLength(0, 15, B0_S15_Len.Text);
        }
        private void B0_S16_Len_Leave(object sender, EventArgs e)
        {
            updateLength(0, 16, B0_S16_Len.Text);
        }
        private void B0_S17_Len_Leave(object sender, EventArgs e)
        {
            updateLength(0, 17, B0_S17_Len.Text);
        }
        private void B0_S18_Len_Leave(object sender, EventArgs e)
        {
            updateLength(0, 18, B0_S18_Len.Text);
        }
        private void B0_S19_Len_Leave(object sender, EventArgs e)
        {
            updateLength(0, 19, B0_S19_Len.Text);
        }
        private void B0_S20_Len_Leave(object sender, EventArgs e)
        {
            updateLength(0, 20, B0_S20_Len.Text);
        }
        private void B0_S21_Len_Leave(object sender, EventArgs e)
        {
            updateLength(0, 21, B0_S21_Len.Text);
        }
        private void B0_S22_Len_Leave(object sender, EventArgs e)
        {
            updateLength(0, 22, B0_S22_Len.Text);
        }
        private void B0_S23_Len_Leave(object sender, EventArgs e)
        {
            updateLength(0, 23, B0_S23_Len.Text);
        }
        private void B0_S24_Len_Leave(object sender, EventArgs e)
        {
            updateLength(0, 24, B0_S24_Len.Text);
        }
        private void B0_S25_Len_Leave(object sender, EventArgs e)
        {
            updateLength(0, 25, B0_S25_Len.Text);
        }
        private void B0_S26_Len_Leave(object sender, EventArgs e)
        {
            updateLength(0, 26, B0_S26_Len.Text);
        }
        private void B0_S27_Len_Leave(object sender, EventArgs e)
        {
            updateLength(0, 27, B0_S27_Len.Text);
        }
        private void B0_S28_Len_Leave(object sender, EventArgs e)
        {
            updateLength(0, 28, B0_S28_Len.Text);
        }
        private void B0_S29_Len_Leave(object sender, EventArgs e)
        {
            updateLength(0, 29, B0_S29_Len.Text);
        }
        private void B0_S30_Len_Leave(object sender, EventArgs e)
        {
            updateLength(0, 30, B0_S30_Len.Text);
        }
        private void B0_S31_Len_Leave(object sender, EventArgs e)
        {
            updateLength(0, 31, B0_S31_Len.Text);
        }
        private void B0_S32_Len_Leave(object sender, EventArgs e)
        {
            updateLength(0, 32, B0_S32_Len.Text);
        }
        private void B0_S33_Len_Leave(object sender, EventArgs e)
        {
            updateLength(0, 33, B0_S33_Len.Text);
        }
        private void B0_S34_Len_Leave(object sender, EventArgs e)
        {
            updateLength(0, 34, B0_S34_Len.Text);
        }
        private void B0_S35_Len_Leave(object sender, EventArgs e)
        {
            updateLength(0, 35, B0_S35_Len.Text);
        }
        private void B0_S36_Len_Leave(object sender, EventArgs e)
        {
            updateLength(0, 36, B0_S36_Len.Text);
        }
        private void B0_S37_Len_Leave(object sender, EventArgs e)
        {
            updateLength(0, 37, B0_S37_Len.Text);
        }
        private void B0_S38_Len_Leave(object sender, EventArgs e)
        {
            updateLength(0, 38, B0_S38_Len.Text);
        }
        private void B0_S39_Len_Leave(object sender, EventArgs e)
        {
            updateLength(0, 39, B0_S39_Len.Text);
        }
        private void B0_S40_Len_Leave(object sender, EventArgs e)
        {
            updateLength(0, 40, B0_S40_Len.Text);
        }
        private void B0_S41_Len_Leave(object sender, EventArgs e)
        {
            updateLength(0, 41, B0_S41_Len.Text);
        }
        private void B0_S42_Len_Leave(object sender, EventArgs e)
        {
            updateLength(0, 42, B0_S42_Len.Text);
        }
        private void B0_S43_Len_Leave(object sender, EventArgs e)
        {
            updateLength(0, 43, B0_S43_Len.Text);
        }
        private void B0_S44_Len_Leave(object sender, EventArgs e)
        {
            updateLength(0, 44, B0_S44_Len.Text);
        }
        private void B0_S45_Len_Leave(object sender, EventArgs e)
        {
            updateLength(0, 45, B0_S45_Len.Text);
        }
        private void B0_S46_Len_Leave(object sender, EventArgs e)
        {
            updateLength(0, 46, B0_S46_Len.Text);
        }
        private void B0_S47_Len_Leave(object sender, EventArgs e)
        {
            updateLength(0, 47, B0_S47_Len.Text);
        }
        private void B0_S48_Len_Leave(object sender, EventArgs e)
        {
            updateLength(0, 48, B0_S48_Len.Text);
        }
        private void B0_S49_Len_Leave(object sender, EventArgs e)
        {
            updateLength(0, 49, B0_S49_Len.Text);
        }
        private void B0_S50_Len_Leave(object sender, EventArgs e)
        {
            updateLength(0, 50, B0_S50_Len.Text);
        }
        private void B0_S51_Len_Leave(object sender, EventArgs e)
        {
            updateLength(0, 51, B0_S51_Len.Text);
        }
        private void B0_S52_Len_Leave(object sender, EventArgs e)
        {
            updateLength(0, 52, B0_S52_Len.Text);
        }
        private void B0_S53_Len_Leave(object sender, EventArgs e)
        {
            updateLength(0, 53, B0_S53_Len.Text);
        }
        private void B0_S54_Len_Leave(object sender, EventArgs e)
        {
            updateLength(0, 54, B0_S54_Len.Text);
        }
        private void B0_S55_Len_Leave(object sender, EventArgs e)
        {
            updateLength(0, 55, B0_S55_Len.Text);
        }
        private void B0_S56_Len_Leave(object sender, EventArgs e)
        {
            updateLength(0, 56, B0_S56_Len.Text);
        }
        private void B0_S57_Len_Leave(object sender, EventArgs e)
        {
            updateLength(0, 57, B0_S57_Len.Text);
        }
        private void B0_S58_Len_Leave(object sender, EventArgs e)
        {
            updateLength(0, 58, B0_S58_Len.Text);
        }
        private void B0_S59_Len_Leave(object sender, EventArgs e)
        {
            updateLength(0, 59, B0_S59_Len.Text);
        }
        private void B0_S60_Len_Leave(object sender, EventArgs e)
        {
            updateLength(0, 60, B0_S60_Len.Text);
        }
        private void B0_S61_Len_Leave(object sender, EventArgs e)
        {
            updateLength(0, 61, B0_S61_Len.Text);
        }
        private void B0_S62_Len_Leave(object sender, EventArgs e)
        {
            updateLength(0, 62, B0_S62_Len.Text);
        }
        private void B0_S63_Len_Leave(object sender, EventArgs e)
        {
            updateLength(0, 63, B0_S63_Len.Text);
        }
        private void B0_S64_Len_Leave(object sender, EventArgs e)
        {
            updateLength(0, 64, B0_S64_Len.Text);
        }
        private void B0_S65_Len_Leave(object sender, EventArgs e)
        {
            updateLength(0, 65, B0_S65_Len.Text);
        }
        private void B0_S66_Len_Leave(object sender, EventArgs e)
        {
            updateLength(0, 66, B0_S66_Len.Text);
        }
        private void B0_S67_Len_Leave(object sender, EventArgs e)
        {
            updateLength(0, 67, B0_S67_Len.Text);
        }
        private void B0_S68_Len_Leave(object sender, EventArgs e)
        {
            updateLength(0, 68, B0_S68_Len.Text);
        }
        private void B0_S69_Len_Leave(object sender, EventArgs e)
        {
            updateLength(0, 69, B0_S69_Len.Text);
        }
        private void B0_S70_Len_Leave(object sender, EventArgs e)
        {
            updateLength(0, 70, B0_S70_Len.Text);
        }
        private void B0_S71_Len_Leave(object sender, EventArgs e)
        {
            updateLength(0, 71, B0_S71_Len.Text);
        }
        private void B0_S72_Len_Leave(object sender, EventArgs e)
        {
            updateLength(0, 72, B0_S72_Len.Text);
        }
        private void B0_S73_Len_Leave(object sender, EventArgs e)
        {
            updateLength(0, 73, B0_S73_Len.Text);
        }
        private void B0_S74_Len_Leave(object sender, EventArgs e)
        {
            updateLength(0, 74, B0_S74_Len.Text);
        }
        private void B0_S75_Len_Leave(object sender, EventArgs e)
        {
            updateLength(0, 75, B0_S75_Len.Text);
        }
        private void B0_S76_Len_Leave(object sender, EventArgs e)
        {
            updateLength(0, 76, B0_S76_Len.Text);
        }
        private void B0_S77_Len_Leave(object sender, EventArgs e)
        {
            updateLength(0, 77, B0_S77_Len.Text);
        }
        private void B0_S78_Len_Leave(object sender, EventArgs e)
        {
            updateLength(0, 78, B0_S78_Len.Text);
        }
        private void B0_S79_Len_Leave(object sender, EventArgs e)
        {
            updateLength(0, 79, B0_S79_Len.Text);
        }
        private void B0_S80_Len_Leave(object sender, EventArgs e)
        {
            updateLength(0, 80, B0_S80_Len.Text);
        }
        private void B0_S81_Len_Leave(object sender, EventArgs e)
        {
            updateLength(0, 81, B0_S81_Len.Text);
        }
        private void B0_S82_Len_Leave(object sender, EventArgs e)
        {
            updateLength(0, 82, B0_S82_Len.Text);
        }
        private void B0_S83_Len_Leave(object sender, EventArgs e)
        {
            updateLength(0, 83, B0_S83_Len.Text);
        }
        private void B0_S84_Len_Leave(object sender, EventArgs e)
        {
            updateLength(0, 84, B0_S84_Len.Text);
        }
        private void B0_S85_Len_Leave(object sender, EventArgs e)
        {
            updateLength(0, 85, B0_S85_Len.Text);
        }
        private void B0_S86_Len_Leave(object sender, EventArgs e)
        {
            updateLength(0, 86, B0_S86_Len.Text);
        }
        private void B0_S87_Len_Leave(object sender, EventArgs e)
        {
            updateLength(0, 87, B0_S87_Len.Text);
        }
        private void B0_S88_Len_Leave(object sender, EventArgs e)
        {
            updateLength(0, 88, B0_S88_Len.Text);
        }
        private void B0_S89_Len_Leave(object sender, EventArgs e)
        {
            updateLength(0, 89, B0_S89_Len.Text);
        }
        private void B0_S90_Len_Leave(object sender, EventArgs e)
        {
            updateLength(0, 90, B0_S90_Len.Text);
        }
        private void B0_S91_Len_Leave(object sender, EventArgs e)
        {
            updateLength(0, 91, B0_S91_Len.Text);
        }
        private void B0_S92_Len_Leave(object sender, EventArgs e)
        {
            updateLength(0, 92, B0_S92_Len.Text);
        }
        private void B0_S93_Len_Leave(object sender, EventArgs e)
        {
            updateLength(0, 93, B0_S93_Len.Text);
        }
        private void B0_S94_Len_Leave(object sender, EventArgs e)
        {
            updateLength(0, 94, B0_S94_Len.Text);
        }
        private void B0_S95_Len_Leave(object sender, EventArgs e)
        {
            updateLength(0, 95, B0_S95_Len.Text);
        }
        private void B0_S96_Len_Leave(object sender, EventArgs e)
        {
            updateLength(0, 96, B0_S96_Len.Text);
        }
        private void B0_S97_Len_Leave(object sender, EventArgs e)
        {
            updateLength(0, 97, B0_S97_Len.Text);
        }
        private void B0_S98_Len_Leave(object sender, EventArgs e)
        {
            updateLength(0, 98, B0_S98_Len.Text);
        }
        private void B0_S99_Len_Leave(object sender, EventArgs e)
        {
            updateLength(0, 99, B0_S99_Len.Text);
        }
        private void B0_S100_Len_Leave(object sender, EventArgs e)
        {
            updateLength(0, 100, B0_S100_Len.Text);
        }
        private void B0_S101_Len_Leave(object sender, EventArgs e)
        {
            updateLength(0, 101, B0_S101_Len.Text);
        }
        private void B0_S102_Len_Leave(object sender, EventArgs e)
        {
            updateLength(0, 102, B0_S102_Len.Text);
        }
        private void B0_S103_Len_Leave(object sender, EventArgs e)
        {
            updateLength(0, 103, B0_S103_Len.Text);
        }
        private void B0_S104_Len_Leave(object sender, EventArgs e)
        {
            updateLength(0, 104, B0_S104_Len.Text);
        }
        private void B0_S105_Len_Leave(object sender, EventArgs e)
        {
            updateLength(0, 105, B0_S105_Len.Text);
        }
        private void B0_S106_Len_Leave(object sender, EventArgs e)
        {
            updateLength(0, 106, B0_S106_Len.Text);
        }
        private void B0_S107_Len_Leave(object sender, EventArgs e)
        {
            updateLength(0, 107, B0_S107_Len.Text);
        }
        private void B0_S108_Len_Leave(object sender, EventArgs e)
        {
            updateLength(0, 108, B0_S108_Len.Text);
        }
        private void B0_S109_Len_Leave(object sender, EventArgs e)
        {
            updateLength(0, 109, B0_S109_Len.Text);
        }
        private void B0_S110_Len_Leave(object sender, EventArgs e)
        {
            updateLength(0, 110, B0_S110_Len.Text);
        }
        private void B0_S111_Len_Leave(object sender, EventArgs e)
        {
            updateLength(0, 111, B0_S111_Len.Text);
        }
        private void B0_S112_Len_Leave(object sender, EventArgs e)
        {
            updateLength(0, 112, B0_S112_Len.Text);
        }
        private void B0_S113_Len_Leave(object sender, EventArgs e)
        {
            updateLength(0, 113, B0_S113_Len.Text);
        }
        private void B0_S114_Len_Leave(object sender, EventArgs e)
        {
            updateLength(0, 114, B0_S114_Len.Text);
        }
        private void B0_S115_Len_Leave(object sender, EventArgs e)
        {
            updateLength(0, 115, B0_S115_Len.Text);
        }
        private void B0_S116_Len_Leave(object sender, EventArgs e)
        {
            updateLength(0, 116, B0_S116_Len.Text);
        }
        private void B0_S117_Len_Leave(object sender, EventArgs e)
        {
            updateLength(0, 117, B0_S117_Len.Text);
        }
        private void B0_S118_Len_Leave(object sender, EventArgs e)
        {
            updateLength(0, 118, B0_S118_Len.Text);
        }
        private void B0_S119_Len_Leave(object sender, EventArgs e)
        {
            updateLength(0, 119, B0_S119_Len.Text);
        }
        private void B0_S120_Len_Leave(object sender, EventArgs e)
        {
            updateLength(0, 120, B0_S120_Len.Text);
        }
        private void B0_S121_Len_Leave(object sender, EventArgs e)
        {
            updateLength(0, 121, B0_S121_Len.Text);
        }
        private void B0_S122_Len_Leave(object sender, EventArgs e)
        {
            updateLength(0, 122, B0_S122_Len.Text);
        }
        private void B0_S123_Len_Leave(object sender, EventArgs e)
        {
            updateLength(0, 123, B0_S123_Len.Text);
        }
        private void B0_S124_Len_Leave(object sender, EventArgs e)
        {
            updateLength(0, 124, B0_S124_Len.Text);
        }
        private void B0_S125_Len_Leave(object sender, EventArgs e)
        {
            updateLength(0, 125, B0_S125_Len.Text);
        }
        private void B0_S126_Len_Leave(object sender, EventArgs e)
        {
            updateLength(0, 126, B0_S126_Len.Text);
        }
        private void B0_S127_Len_Leave(object sender, EventArgs e)
        {
            updateLength(0, 127, B0_S127_Len.Text);
        }

        private void updateLength(int bank, int sample, String text)
        {
            Banks[bank].samples[sample].length = int.Parse(text, NumberStyles.HexNumber);
            switch (bank)
            {
                case 0:
                    setCtrl0();
                    break;
                    //case 2:
                    //    setCtrl2();
                    //    break;
                    //case 3:
                    //    setCtrl3();
                    //    break;
                    //case 4:
                    //    setCtrl4();
                    //    break;
                    //case 5:
                    //    setCtrl5();
                    //    break;
                    //case 6:
                    //    setCtrl6();
                    //    break;
                    //case 7:
                    //    setCtrl7();
                    //    break;
                    //case 8:
                    //    setCtrlCom();
                    //    break;
            }

        }

        private void B0_S1_Off_Leave(object sender, EventArgs e)
        {
            updateOffset(0, 1, B0_S1_Off.Text);
        }
        private void B0_S2_Off_Leave(object sender, EventArgs e)
        {
            updateOffset(0, 2, B0_S2_Off.Text);
        }
        private void B0_S3_Off_Leave(object sender, EventArgs e)
        {
            updateOffset(0, 3, B0_S3_Off.Text);
        }
        private void B0_S4_Off_Leave(object sender, EventArgs e)
        {
            updateOffset(0, 4, B0_S4_Off.Text);
        }
        private void B0_S5_Off_Leave(object sender, EventArgs e)
        {
            updateOffset(0, 5, B0_S5_Off.Text);
        }
        private void B0_S6_Off_Leave(object sender, EventArgs e)
        {
            updateOffset(0, 6, B0_S6_Off.Text);
        }
        private void B0_S7_Off_Leave(object sender, EventArgs e)
        {
            updateOffset(0, 7, B0_S7_Off.Text);
        }
        private void B0_S8_Off_Leave(object sender, EventArgs e)
        {
            updateOffset(0, 8, B0_S8_Off.Text);
        }
        private void B0_S9_Off_Leave(object sender, EventArgs e)
        {
            updateOffset(0, 9, B0_S9_Off.Text);
        }
        private void B0_S10_Off_Leave(object sender, EventArgs e)
        {
            updateOffset(0, 10, B0_S10_Off.Text);
        }
        private void B0_S11_Off_Leave(object sender, EventArgs e)
        {
            updateOffset(0, 11, B0_S11_Off.Text);
        }
        private void B0_S12_Off_Leave(object sender, EventArgs e)
        {
            updateOffset(0, 12, B0_S12_Off.Text);
        }
        private void B0_S13_Off_Leave(object sender, EventArgs e)
        {
            updateOffset(0, 13, B0_S13_Off.Text);
        }
        private void B0_S14_Off_Leave(object sender, EventArgs e)
        {
            updateOffset(0, 14, B0_S14_Off.Text);
        }
        private void B0_S15_Off_Leave(object sender, EventArgs e)
        {
            updateOffset(0, 15, B0_S15_Off.Text);
        }
        private void B0_S16_Off_Leave(object sender, EventArgs e)
        {
            updateOffset(0, 16, B0_S16_Off.Text);
        }
        private void B0_S17_Off_Leave(object sender, EventArgs e)
        {
            updateOffset(0, 17, B0_S17_Off.Text);
        }
        private void B0_S18_Off_Leave(object sender, EventArgs e)
        {
            updateOffset(0, 18, B0_S18_Off.Text);
        }
        private void B0_S19_Off_Leave(object sender, EventArgs e)
        {
            updateOffset(0, 19, B0_S19_Off.Text);
        }
        private void B0_S20_Off_Leave(object sender, EventArgs e)
        {
            updateOffset(0, 20, B0_S20_Off.Text);
        }
        private void B0_S21_Off_Leave(object sender, EventArgs e)
        {
            updateOffset(0, 21, B0_S21_Off.Text);
        }
        private void B0_S22_Off_Leave(object sender, EventArgs e)
        {
            updateOffset(0, 22, B0_S22_Off.Text);
        }
        private void B0_S23_Off_Leave(object sender, EventArgs e)
        {
            updateOffset(0, 23, B0_S23_Off.Text);
        }
        private void B0_S24_Off_Leave(object sender, EventArgs e)
        {
            updateOffset(0, 24, B0_S24_Off.Text);
        }
        private void B0_S25_Off_Leave(object sender, EventArgs e)
        {
            updateOffset(0, 25, B0_S25_Off.Text);
        }
        private void B0_S26_Off_Leave(object sender, EventArgs e)
        {
            updateOffset(0, 26, B0_S26_Off.Text);
        }
        private void B0_S27_Off_Leave(object sender, EventArgs e)
        {
            updateOffset(0, 27, B0_S27_Off.Text);
        }
        private void B0_S28_Off_Leave(object sender, EventArgs e)
        {
            updateOffset(0, 28, B0_S28_Off.Text);
        }
        private void B0_S29_Off_Leave(object sender, EventArgs e)
        {
            updateOffset(0, 29, B0_S29_Off.Text);
        }
        private void B0_S30_Off_Leave(object sender, EventArgs e)
        {
            updateOffset(0, 30, B0_S30_Off.Text);
        }
        private void B0_S31_Off_Leave(object sender, EventArgs e)
        {
            updateOffset(0, 31, B0_S31_Off.Text);
        }
        private void B0_S32_Off_Leave(object sender, EventArgs e)
        {
            updateOffset(0, 32, B0_S32_Off.Text);
        }
        private void B0_S33_Off_Leave(object sender, EventArgs e)
        {
            updateOffset(0, 33, B0_S33_Off.Text);
        }
        private void B0_S34_Off_Leave(object sender, EventArgs e)
        {
            updateOffset(0, 34, B0_S34_Off.Text);
        }
        private void B0_S35_Off_Leave(object sender, EventArgs e)
        {
            updateOffset(0, 35, B0_S35_Off.Text);
        }
        private void B0_S36_Off_Leave(object sender, EventArgs e)
        {
            updateOffset(0, 36, B0_S36_Off.Text);
        }
        private void B0_S37_Off_Leave(object sender, EventArgs e)
        {
            updateOffset(0, 37, B0_S37_Off.Text);
        }
        private void B0_S38_Off_Leave(object sender, EventArgs e)
        {
            updateOffset(0, 38, B0_S38_Off.Text);
        }
        private void B0_S39_Off_Leave(object sender, EventArgs e)
        {
            updateOffset(0, 39, B0_S39_Off.Text);
        }
        private void B0_S40_Off_Leave(object sender, EventArgs e)
        {
            updateOffset(0, 40, B0_S40_Off.Text);
        }
        private void B0_S41_Off_Leave(object sender, EventArgs e)
        {
            updateOffset(0, 41, B0_S41_Off.Text);
        }
        private void B0_S42_Off_Leave(object sender, EventArgs e)
        {
            updateOffset(0, 42, B0_S42_Off.Text);
        }
        private void B0_S43_Off_Leave(object sender, EventArgs e)
        {
            updateOffset(0, 43, B0_S43_Off.Text);
        }
        private void B0_S44_Off_Leave(object sender, EventArgs e)
        {
            updateOffset(0, 44, B0_S44_Off.Text);
        }
        private void B0_S45_Off_Leave(object sender, EventArgs e)
        {
            updateOffset(0, 45, B0_S45_Off.Text);
        }
        private void B0_S46_Off_Leave(object sender, EventArgs e)
        {
            updateOffset(0, 46, B0_S46_Off.Text);
        }
        private void B0_S47_Off_Leave(object sender, EventArgs e)
        {
            updateOffset(0, 47, B0_S47_Off.Text);
        }
        private void B0_S48_Off_Leave(object sender, EventArgs e)
        {
            updateOffset(0, 48, B0_S48_Off.Text);
        }
        private void B0_S49_Off_Leave(object sender, EventArgs e)
        {
            updateOffset(0, 49, B0_S49_Off.Text);
        }
        private void B0_S50_Off_Leave(object sender, EventArgs e)
        {
            updateOffset(0, 50, B0_S50_Off.Text);
        }
        private void B0_S51_Off_Leave(object sender, EventArgs e)
        {
            updateOffset(0, 51, B0_S51_Off.Text);
        }
        private void B0_S52_Off_Leave(object sender, EventArgs e)
        {
            updateOffset(0, 52, B0_S52_Off.Text);
        }
        private void B0_S53_Off_Leave(object sender, EventArgs e)
        {
            updateOffset(0, 53, B0_S53_Off.Text);
        }
        private void B0_S54_Off_Leave(object sender, EventArgs e)
        {
            updateOffset(0, 54, B0_S54_Off.Text);
        }
        private void B0_S55_Off_Leave(object sender, EventArgs e)
        {
            updateOffset(0, 55, B0_S55_Off.Text);
        }
        private void B0_S56_Off_Leave(object sender, EventArgs e)
        {
            updateOffset(0, 56, B0_S56_Off.Text);
        }
        private void B0_S57_Off_Leave(object sender, EventArgs e)
        {
            updateOffset(0, 57, B0_S57_Off.Text);
        }
        private void B0_S58_Off_Leave(object sender, EventArgs e)
        {
            updateOffset(0, 58, B0_S58_Off.Text);
        }
        private void B0_S59_Off_Leave(object sender, EventArgs e)
        {
            updateOffset(0, 59, B0_S59_Off.Text);
        }
        private void B0_S60_Off_Leave(object sender, EventArgs e)
        {
            updateOffset(0, 60, B0_S60_Off.Text);
        }
        private void B0_S61_Off_Leave(object sender, EventArgs e)
        {
            updateOffset(0, 61, B0_S61_Off.Text);
        }
        private void B0_S62_Off_Leave(object sender, EventArgs e)
        {
            updateOffset(0, 62, B0_S62_Off.Text);
        }
        private void B0_S63_Off_Leave(object sender, EventArgs e)
        {
            updateOffset(0, 63, B0_S63_Off.Text);
        }
        private void B0_S64_Off_Leave(object sender, EventArgs e)
        {
            updateOffset(0, 64, B0_S64_Off.Text);
        }
        private void B0_S65_Off_Leave(object sender, EventArgs e)
        {
            updateOffset(0, 65, B0_S65_Off.Text);
        }
        private void B0_S66_Off_Leave(object sender, EventArgs e)
        {
            updateOffset(0, 66, B0_S66_Off.Text);
        }
        private void B0_S67_Off_Leave(object sender, EventArgs e)
        {
            updateOffset(0, 67, B0_S67_Off.Text);
        }
        private void B0_S68_Off_Leave(object sender, EventArgs e)
        {
            updateOffset(0, 68, B0_S68_Off.Text);
        }
        private void B0_S69_Off_Leave(object sender, EventArgs e)
        {
            updateOffset(0, 69, B0_S69_Off.Text);
        }
        private void B0_S70_Off_Leave(object sender, EventArgs e)
        {
            updateOffset(0, 70, B0_S70_Off.Text);
        }
        private void B0_S71_Off_Leave(object sender, EventArgs e)
        {
            updateOffset(0, 71, B0_S71_Off.Text);
        }
        private void B0_S72_Off_Leave(object sender, EventArgs e)
        {
            updateOffset(0, 72, B0_S72_Off.Text);
        }
        private void B0_S73_Off_Leave(object sender, EventArgs e)
        {
            updateOffset(0, 73, B0_S73_Off.Text);
        }
        private void B0_S74_Off_Leave(object sender, EventArgs e)
        {
            updateOffset(0, 74, B0_S74_Off.Text);
        }
        private void B0_S75_Off_Leave(object sender, EventArgs e)
        {
            updateOffset(0, 75, B0_S75_Off.Text);
        }
        private void B0_S76_Off_Leave(object sender, EventArgs e)
        {
            updateOffset(0, 76, B0_S76_Off.Text);
        }
        private void B0_S77_Off_Leave(object sender, EventArgs e)
        {
            updateOffset(0, 77, B0_S77_Off.Text);
        }
        private void B0_S78_Off_Leave(object sender, EventArgs e)
        {
            updateOffset(0, 78, B0_S78_Off.Text);
        }
        private void B0_S79_Off_Leave(object sender, EventArgs e)
        {
            updateOffset(0, 79, B0_S79_Off.Text);
        }
        private void B0_S80_Off_Leave(object sender, EventArgs e)
        {
            updateOffset(0, 80, B0_S80_Off.Text);
        }
        private void B0_S81_Off_Leave(object sender, EventArgs e)
        {
            updateOffset(0, 81, B0_S81_Off.Text);
        }
        private void B0_S82_Off_Leave(object sender, EventArgs e)
        {
            updateOffset(0, 82, B0_S82_Off.Text);
        }
        private void B0_S83_Off_Leave(object sender, EventArgs e)
        {
            updateOffset(0, 83, B0_S83_Off.Text);
        }
        private void B0_S84_Off_Leave(object sender, EventArgs e)
        {
            updateOffset(0, 84, B0_S84_Off.Text);
        }
        private void B0_S85_Off_Leave(object sender, EventArgs e)
        {
            updateOffset(0, 85, B0_S85_Off.Text);
        }
        private void B0_S86_Off_Leave(object sender, EventArgs e)
        {
            updateOffset(0, 86, B0_S86_Off.Text);
        }
        private void B0_S87_Off_Leave(object sender, EventArgs e)
        {
            updateOffset(0, 87, B0_S87_Off.Text);
        }
        private void B0_S88_Off_Leave(object sender, EventArgs e)
        {
            updateOffset(0, 88, B0_S88_Off.Text);
        }
        private void B0_S89_Off_Leave(object sender, EventArgs e)
        {
            updateOffset(0, 89, B0_S89_Off.Text);
        }
        private void B0_S90_Off_Leave(object sender, EventArgs e)
        {
            updateOffset(0, 90, B0_S90_Off.Text);
        }
        private void B0_S91_Off_Leave(object sender, EventArgs e)
        {
            updateOffset(0, 91, B0_S91_Off.Text);
        }
        private void B0_S92_Off_Leave(object sender, EventArgs e)
        {
            updateOffset(0, 92, B0_S92_Off.Text);
        }
        private void B0_S93_Off_Leave(object sender, EventArgs e)
        {
            updateOffset(0, 93, B0_S93_Off.Text);
        }
        private void B0_S94_Off_Leave(object sender, EventArgs e)
        {
            updateOffset(0, 94, B0_S94_Off.Text);
        }
        private void B0_S95_Off_Leave(object sender, EventArgs e)
        {
            updateOffset(0, 95, B0_S95_Off.Text);
        }
        private void B0_S96_Off_Leave(object sender, EventArgs e)
        {
            updateOffset(0, 96, B0_S96_Off.Text);
        }
        private void B0_S97_Off_Leave(object sender, EventArgs e)
        {
            updateOffset(0, 97, B0_S97_Off.Text);
        }
        private void B0_S98_Off_Leave(object sender, EventArgs e)
        {
            updateOffset(0, 98, B0_S98_Off.Text);
        }
        private void B0_S99_Off_Leave(object sender, EventArgs e)
        {
            updateOffset(0, 99, B0_S99_Off.Text);
        }
        private void B0_S100_Off_Leave(object sender, EventArgs e)
        {
            updateOffset(0, 100, B0_S100_Off.Text);
        }
        private void B0_S101_Off_Leave(object sender, EventArgs e)
        {
            updateOffset(0, 101, B0_S101_Off.Text);
        }
        private void B0_S102_Off_Leave(object sender, EventArgs e)
        {
            updateOffset(0, 102, B0_S102_Off.Text);
        }
        private void B0_S103_Off_Leave(object sender, EventArgs e)
        {
            updateOffset(0, 103, B0_S103_Off.Text);
        }
        private void B0_S104_Off_Leave(object sender, EventArgs e)
        {
            updateOffset(0, 104, B0_S104_Off.Text);
        }
        private void B0_S105_Off_Leave(object sender, EventArgs e)
        {
            updateOffset(0, 105, B0_S105_Off.Text);
        }
        private void B0_S106_Off_Leave(object sender, EventArgs e)
        {
            updateOffset(0, 106, B0_S106_Off.Text);
        }
        private void B0_S107_Off_Leave(object sender, EventArgs e)
        {
            updateOffset(0, 107, B0_S107_Off.Text);
        }
        private void B0_S108_Off_Leave(object sender, EventArgs e)
        {
            updateOffset(0, 108, B0_S108_Off.Text);
        }
        private void B0_S109_Off_Leave(object sender, EventArgs e)
        {
            updateOffset(0, 109, B0_S109_Off.Text);
        }
        private void B0_S110_Off_Leave(object sender, EventArgs e)
        {
            updateOffset(0, 110, B0_S110_Off.Text);
        }
        private void B0_S111_Off_Leave(object sender, EventArgs e)
        {
            updateOffset(0, 111, B0_S111_Off.Text);
        }
        private void B0_S112_Off_Leave(object sender, EventArgs e)
        {
            updateOffset(0, 112, B0_S112_Off.Text);
        }
        private void B0_S113_Off_Leave(object sender, EventArgs e)
        {
            updateOffset(0, 113, B0_S113_Off.Text);
        }
        private void B0_S114_Off_Leave(object sender, EventArgs e)
        {
            updateOffset(0, 114, B0_S114_Off.Text);
        }
        private void B0_S115_Off_Leave(object sender, EventArgs e)
        {
            updateOffset(0, 115, B0_S115_Off.Text);
        }
        private void B0_S116_Off_Leave(object sender, EventArgs e)
        {
            updateOffset(0, 116, B0_S116_Off.Text);
        }
        private void B0_S117_Off_Leave(object sender, EventArgs e)
        {
            updateOffset(0, 117, B0_S117_Off.Text);
        }
        private void B0_S118_Off_Leave(object sender, EventArgs e)
        {
            updateOffset(0, 118, B0_S118_Off.Text);
        }
        private void B0_S119_Off_Leave(object sender, EventArgs e)
        {
            updateOffset(0, 119, B0_S119_Off.Text);
        }
        private void B0_S120_Off_Leave(object sender, EventArgs e)
        {
            updateOffset(0, 120, B0_S120_Off.Text);
        }
        private void B0_S121_Off_Leave(object sender, EventArgs e)
        {
            updateOffset(0, 121, B0_S121_Off.Text);
        }
        private void B0_S122_Off_Leave(object sender, EventArgs e)
        {
            updateOffset(0, 122, B0_S122_Off.Text);
        }
        private void B0_S123_Off_Leave(object sender, EventArgs e)
        {
            updateOffset(0, 123, B0_S123_Off.Text);
        }
        private void B0_S124_Off_Leave(object sender, EventArgs e)
        {
            updateOffset(0, 124, B0_S124_Off.Text);
        }
        private void B0_S125_Off_Leave(object sender, EventArgs e)
        {
            updateOffset(0, 125, B0_S125_Off.Text);
        }
        private void B0_S126_Off_Leave(object sender, EventArgs e)
        {
            updateOffset(0, 126, B0_S126_Off.Text);
        }
        private void B0_S127_Off_Leave(object sender, EventArgs e)
        {
            updateOffset(0, 127, B0_S127_Off.Text);
        }
        private void updateOffset(int bank, int sample, String text)
        {
            Banks[bank].samples[sample].offset = int.Parse(text, NumberStyles.HexNumber);
            switch (bank)
            {
                case 0:
                    setCtrl0();
                    break;
                    //case 2:
                    //    setCtrl2();
                    //    break;
                    //case 3:
                    //    setCtrl3();
                    //    break;
                    //case 4:
                    //    setCtrl4();
                    //    break;
                    //case 5:
                    //    setCtrl5();
                    //    break;
                    //case 6:
                    //    setCtrl6();
                    //    break;
                    //case 7:
                    //    setCtrl7();
                    //    break;
                    //case 8:
                    //    setCtrlCom();
                    //    break;
            }

        }

        private void B0_S1_Dep_Leave(object sender, EventArgs e)
        {
            updateDepend(0, 1, B0_S1_Dep.Text);
        }
        private void B0_S2_Dep_Leave(object sender, EventArgs e)
        {
            updateDepend(0, 2, B0_S2_Dep.Text);
        }
        private void B0_S3_Dep_Leave(object sender, EventArgs e)
        {
            updateDepend(0, 3, B0_S3_Dep.Text);
        }
        private void B0_S4_Dep_Leave(object sender, EventArgs e)
        {
            updateDepend(0, 4, B0_S4_Dep.Text);
        }
        private void B0_S5_Dep_Leave(object sender, EventArgs e)
        {
            updateDepend(0, 5, B0_S5_Dep.Text);
        }
        private void B0_S6_Dep_Leave(object sender, EventArgs e)
        {
            updateDepend(0, 6, B0_S6_Dep.Text);
        }
        private void B0_S7_Dep_Leave(object sender, EventArgs e)
        {
            updateDepend(0, 7, B0_S7_Dep.Text);
        }
        private void B0_S8_Dep_Leave(object sender, EventArgs e)
        {
            updateDepend(0, 8, B0_S8_Dep.Text);
        }
        private void B0_S9_Dep_Leave(object sender, EventArgs e)
        {
            updateDepend(0, 9, B0_S9_Dep.Text);
        }
        private void B0_S10_Dep_Leave(object sender, EventArgs e)
        {
            updateDepend(0, 10, B0_S10_Dep.Text);
        }
        private void B0_S11_Dep_Leave(object sender, EventArgs e)
        {
            updateDepend(0, 11, B0_S11_Dep.Text);
        }
        private void B0_S12_Dep_Leave(object sender, EventArgs e)
        {
            updateDepend(0, 12, B0_S12_Dep.Text);
        }
        private void B0_S13_Dep_Leave(object sender, EventArgs e)
        {
            updateDepend(0, 13, B0_S13_Dep.Text);
        }
        private void B0_S14_Dep_Leave(object sender, EventArgs e)
        {
            updateDepend(0, 14, B0_S14_Dep.Text);
        }
        private void B0_S15_Dep_Leave(object sender, EventArgs e)
        {
            updateDepend(0, 15, B0_S15_Dep.Text);
        }
        private void B0_S16_Dep_Leave(object sender, EventArgs e)
        {
            updateDepend(0, 16, B0_S16_Dep.Text);
        }
        private void B0_S17_Dep_Leave(object sender, EventArgs e)
        {
            updateDepend(0, 17, B0_S17_Dep.Text);
        }
        private void B0_S18_Dep_Leave(object sender, EventArgs e)
        {
            updateDepend(0, 18, B0_S18_Dep.Text);
        }
        private void B0_S19_Dep_Leave(object sender, EventArgs e)
        {
            updateDepend(0, 19, B0_S19_Dep.Text);
        }
        private void B0_S20_Dep_Leave(object sender, EventArgs e)
        {
            updateDepend(0, 20, B0_S20_Dep.Text);
        }
        private void B0_S21_Dep_Leave(object sender, EventArgs e)
        {
            updateDepend(0, 21, B0_S21_Dep.Text);
        }
        private void B0_S22_Dep_Leave(object sender, EventArgs e)
        {
            updateDepend(0, 22, B0_S22_Dep.Text);
        }
        private void B0_S23_Dep_Leave(object sender, EventArgs e)
        {
            updateDepend(0, 23, B0_S23_Dep.Text);
        }
        private void B0_S24_Dep_Leave(object sender, EventArgs e)
        {
            updateDepend(0, 24, B0_S24_Dep.Text);
        }
        private void B0_S25_Dep_Leave(object sender, EventArgs e)
        {
            updateDepend(0, 25, B0_S25_Dep.Text);
        }
        private void B0_S26_Dep_Leave(object sender, EventArgs e)
        {
            updateDepend(0, 26, B0_S26_Dep.Text);
        }
        private void B0_S27_Dep_Leave(object sender, EventArgs e)
        {
            updateDepend(0, 27, B0_S27_Dep.Text);
        }
        private void B0_S28_Dep_Leave(object sender, EventArgs e)
        {
            updateDepend(0, 28, B0_S28_Dep.Text);
        }
        private void B0_S29_Dep_Leave(object sender, EventArgs e)
        {
            updateDepend(0, 29, B0_S29_Dep.Text);
        }
        private void B0_S30_Dep_Leave(object sender, EventArgs e)
        {
            updateDepend(0, 30, B0_S30_Dep.Text);
        }
        private void B0_S31_Dep_Leave(object sender, EventArgs e)
        {
            updateDepend(0, 31, B0_S31_Dep.Text);
        }
        private void B0_S32_Dep_Leave(object sender, EventArgs e)
        {
            updateDepend(0, 32, B0_S32_Dep.Text);
        }
        private void B0_S33_Dep_Leave(object sender, EventArgs e)
        {
            updateDepend(0, 33, B0_S33_Dep.Text);
        }
        private void B0_S34_Dep_Leave(object sender, EventArgs e)
        {
            updateDepend(0, 34, B0_S34_Dep.Text);
        }
        private void B0_S35_Dep_Leave(object sender, EventArgs e)
        {
            updateDepend(0, 35, B0_S35_Dep.Text);
        }
        private void B0_S36_Dep_Leave(object sender, EventArgs e)
        {
            updateDepend(0, 36, B0_S36_Dep.Text);
        }
        private void B0_S37_Dep_Leave(object sender, EventArgs e)
        {
            updateDepend(0, 37, B0_S37_Dep.Text);
        }
        private void B0_S38_Dep_Leave(object sender, EventArgs e)
        {
            updateDepend(0, 38, B0_S38_Dep.Text);
        }
        private void B0_S39_Dep_Leave(object sender, EventArgs e)
        {
            updateDepend(0, 39, B0_S39_Dep.Text);
        }
        private void B0_S40_Dep_Leave(object sender, EventArgs e)
        {
            updateDepend(0, 40, B0_S40_Dep.Text);
        }
        private void B0_S41_Dep_Leave(object sender, EventArgs e)
        {
            updateDepend(0, 41, B0_S41_Dep.Text);
        }
        private void B0_S42_Dep_Leave(object sender, EventArgs e)
        {
            updateDepend(0, 42, B0_S42_Dep.Text);
        }
        private void B0_S43_Dep_Leave(object sender, EventArgs e)
        {
            updateDepend(0, 43, B0_S43_Dep.Text);
        }
        private void B0_S44_Dep_Leave(object sender, EventArgs e)
        {
            updateDepend(0, 44, B0_S44_Dep.Text);
        }
        private void B0_S45_Dep_Leave(object sender, EventArgs e)
        {
            updateDepend(0, 45, B0_S45_Dep.Text);
        }
        private void B0_S46_Dep_Leave(object sender, EventArgs e)
        {
            updateDepend(0, 46, B0_S46_Dep.Text);
        }
        private void B0_S47_Dep_Leave(object sender, EventArgs e)
        {
            updateDepend(0, 47, B0_S47_Dep.Text);
        }
        private void B0_S48_Dep_Leave(object sender, EventArgs e)
        {
            updateDepend(0, 48, B0_S48_Dep.Text);
        }
        private void B0_S49_Dep_Leave(object sender, EventArgs e)
        {
            updateDepend(0, 49, B0_S49_Dep.Text);
        }
        private void B0_S50_Dep_Leave(object sender, EventArgs e)
        {
            updateDepend(0, 50, B0_S50_Dep.Text);
        }
        private void B0_S51_Dep_Leave(object sender, EventArgs e)
        {
            updateDepend(0, 51, B0_S51_Dep.Text);
        }
        private void B0_S52_Dep_Leave(object sender, EventArgs e)
        {
            updateDepend(0, 52, B0_S52_Dep.Text);
        }
        private void B0_S53_Dep_Leave(object sender, EventArgs e)
        {
            updateDepend(0, 53, B0_S53_Dep.Text);
        }
        private void B0_S54_Dep_Leave(object sender, EventArgs e)
        {
            updateDepend(0, 54, B0_S54_Dep.Text);
        }
        private void B0_S55_Dep_Leave(object sender, EventArgs e)
        {
            updateDepend(0, 55, B0_S55_Dep.Text);
        }
        private void B0_S56_Dep_Leave(object sender, EventArgs e)
        {
            updateDepend(0, 56, B0_S56_Dep.Text);
        }
        private void B0_S57_Dep_Leave(object sender, EventArgs e)
        {
            updateDepend(0, 57, B0_S57_Dep.Text);
        }
        private void B0_S58_Dep_Leave(object sender, EventArgs e)
        {
            updateDepend(0, 58, B0_S58_Dep.Text);
        }
        private void B0_S59_Dep_Leave(object sender, EventArgs e)
        {
            updateDepend(0, 59, B0_S59_Dep.Text);
        }
        private void B0_S60_Dep_Leave(object sender, EventArgs e)
        {
            updateDepend(0, 60, B0_S60_Dep.Text);
        }
        private void B0_S61_Dep_Leave(object sender, EventArgs e)
        {
            updateDepend(0, 61, B0_S61_Dep.Text);
        }
        private void B0_S62_Dep_Leave(object sender, EventArgs e)
        {
            updateDepend(0, 62, B0_S62_Dep.Text);
        }
        private void B0_S63_Dep_Leave(object sender, EventArgs e)
        {
            updateDepend(0, 63, B0_S63_Dep.Text);
        }
        private void B0_S64_Dep_Leave(object sender, EventArgs e)
        {
            updateDepend(0, 64, B0_S64_Dep.Text);
        }
        private void B0_S65_Dep_Leave(object sender, EventArgs e)
        {
            updateDepend(0, 65, B0_S65_Dep.Text);
        }
        private void B0_S66_Dep_Leave(object sender, EventArgs e)
        {
            updateDepend(0, 66, B0_S66_Dep.Text);
        }
        private void B0_S67_Dep_Leave(object sender, EventArgs e)
        {
            updateDepend(0, 67, B0_S67_Dep.Text);
        }
        private void B0_S68_Dep_Leave(object sender, EventArgs e)
        {
            updateDepend(0, 68, B0_S68_Dep.Text);
        }
        private void B0_S69_Dep_Leave(object sender, EventArgs e)
        {
            updateDepend(0, 69, B0_S69_Dep.Text);
        }
        private void B0_S70_Dep_Leave(object sender, EventArgs e)
        {
            updateDepend(0, 70, B0_S70_Dep.Text);
        }
        private void B0_S71_Dep_Leave(object sender, EventArgs e)
        {
            updateDepend(0, 71, B0_S71_Dep.Text);
        }
        private void B0_S72_Dep_Leave(object sender, EventArgs e)
        {
            updateDepend(0, 72, B0_S72_Dep.Text);
        }
        private void B0_S73_Dep_Leave(object sender, EventArgs e)
        {
            updateDepend(0, 73, B0_S73_Dep.Text);
        }
        private void B0_S74_Dep_Leave(object sender, EventArgs e)
        {
            updateDepend(0, 74, B0_S74_Dep.Text);
        }
        private void B0_S75_Dep_Leave(object sender, EventArgs e)
        {
            updateDepend(0, 75, B0_S75_Dep.Text);
        }
        private void B0_S76_Dep_Leave(object sender, EventArgs e)
        {
            updateDepend(0, 76, B0_S76_Dep.Text);
        }
        private void B0_S77_Dep_Leave(object sender, EventArgs e)
        {
            updateDepend(0, 77, B0_S77_Dep.Text);
        }
        private void B0_S78_Dep_Leave(object sender, EventArgs e)
        {
            updateDepend(0, 78, B0_S78_Dep.Text);
        }
        private void B0_S79_Dep_Leave(object sender, EventArgs e)
        {
            updateDepend(0, 79, B0_S79_Dep.Text);
        }
        private void B0_S80_Dep_Leave(object sender, EventArgs e)
        {
            updateDepend(0, 80, B0_S80_Dep.Text);
        }
        private void B0_S81_Dep_Leave(object sender, EventArgs e)
        {
            updateDepend(0, 81, B0_S81_Dep.Text);
        }
        private void B0_S82_Dep_Leave(object sender, EventArgs e)
        {
            updateDepend(0, 82, B0_S82_Dep.Text);
        }
        private void B0_S83_Dep_Leave(object sender, EventArgs e)
        {
            updateDepend(0, 83, B0_S83_Dep.Text);
        }
        private void B0_S84_Dep_Leave(object sender, EventArgs e)
        {
            updateDepend(0, 84, B0_S84_Dep.Text);
        }
        private void B0_S85_Dep_Leave(object sender, EventArgs e)
        {
            updateDepend(0, 85, B0_S85_Dep.Text);
        }
        private void B0_S86_Dep_Leave(object sender, EventArgs e)
        {
            updateDepend(0, 86, B0_S86_Dep.Text);
        }
        private void B0_S87_Dep_Leave(object sender, EventArgs e)
        {
            updateDepend(0, 87, B0_S87_Dep.Text);
        }
        private void B0_S88_Dep_Leave(object sender, EventArgs e)
        {
            updateDepend(0, 88, B0_S88_Dep.Text);
        }
        private void B0_S89_Dep_Leave(object sender, EventArgs e)
        {
            updateDepend(0, 89, B0_S89_Dep.Text);
        }
        private void B0_S90_Dep_Leave(object sender, EventArgs e)
        {
            updateDepend(0, 90, B0_S90_Dep.Text);
        }
        private void B0_S91_Dep_Leave(object sender, EventArgs e)
        {
            updateDepend(0, 91, B0_S91_Dep.Text);
        }
        private void B0_S92_Dep_Leave(object sender, EventArgs e)
        {
            updateDepend(0, 92, B0_S92_Dep.Text);
        }
        private void B0_S93_Dep_Leave(object sender, EventArgs e)
        {
            updateDepend(0, 93, B0_S93_Dep.Text);
        }
        private void B0_S94_Dep_Leave(object sender, EventArgs e)
        {
            updateDepend(0, 94, B0_S94_Dep.Text);
        }
        private void B0_S95_Dep_Leave(object sender, EventArgs e)
        {
            updateDepend(0, 95, B0_S95_Dep.Text);
        }
        private void B0_S96_Dep_Leave(object sender, EventArgs e)
        {
            updateDepend(0, 96, B0_S96_Dep.Text);
        }
        private void B0_S97_Dep_Leave(object sender, EventArgs e)
        {
            updateDepend(0, 97, B0_S97_Dep.Text);
        }
        private void B0_S98_Dep_Leave(object sender, EventArgs e)
        {
            updateDepend(0, 98, B0_S98_Dep.Text);
        }
        private void B0_S99_Dep_Leave(object sender, EventArgs e)
        {
            updateDepend(0, 99, B0_S99_Dep.Text);
        }
        private void B0_S100_Dep_Leave(object sender, EventArgs e)
        {
            updateDepend(0, 100, B0_S100_Dep.Text);
        }
        private void B0_S101_Dep_Leave(object sender, EventArgs e)
        {
            updateDepend(0, 101, B0_S101_Dep.Text);
        }
        private void B0_S102_Dep_Leave(object sender, EventArgs e)
        {
            updateDepend(0, 102, B0_S102_Dep.Text);
        }
        private void B0_S103_Dep_Leave(object sender, EventArgs e)
        {
            updateDepend(0, 103, B0_S103_Dep.Text);
        }
        private void B0_S104_Dep_Leave(object sender, EventArgs e)
        {
            updateDepend(0, 104, B0_S104_Dep.Text);
        }
        private void B0_S105_Dep_Leave(object sender, EventArgs e)
        {
            updateDepend(0, 105, B0_S105_Dep.Text);
        }
        private void B0_S106_Dep_Leave(object sender, EventArgs e)
        {
            updateDepend(0, 106, B0_S106_Dep.Text);
        }
        private void B0_S107_Dep_Leave(object sender, EventArgs e)
        {
            updateDepend(0, 107, B0_S107_Dep.Text);
        }
        private void B0_S108_Dep_Leave(object sender, EventArgs e)
        {
            updateDepend(0, 108, B0_S108_Dep.Text);
        }
        private void B0_S109_Dep_Leave(object sender, EventArgs e)
        {
            updateDepend(0, 109, B0_S109_Dep.Text);
        }
        private void B0_S110_Dep_Leave(object sender, EventArgs e)
        {
            updateDepend(0, 110, B0_S110_Dep.Text);
        }
        private void B0_S111_Dep_Leave(object sender, EventArgs e)
        {
            updateDepend(0, 111, B0_S111_Dep.Text);
        }
        private void B0_S112_Dep_Leave(object sender, EventArgs e)
        {
            updateDepend(0, 112, B0_S112_Dep.Text);
        }
        private void B0_S113_Dep_Leave(object sender, EventArgs e)
        {
            updateDepend(0, 113, B0_S113_Dep.Text);
        }
        private void B0_S114_Dep_Leave(object sender, EventArgs e)
        {
            updateDepend(0, 114, B0_S114_Dep.Text);
        }
        private void B0_S115_Dep_Leave(object sender, EventArgs e)
        {
            updateDepend(0, 115, B0_S115_Dep.Text);
        }
        private void B0_S116_Dep_Leave(object sender, EventArgs e)
        {
            updateDepend(0, 116, B0_S116_Dep.Text);
        }
        private void B0_S117_Dep_Leave(object sender, EventArgs e)
        {
            updateDepend(0, 117, B0_S117_Dep.Text);
        }
        private void B0_S118_Dep_Leave(object sender, EventArgs e)
        {
            updateDepend(0, 118, B0_S118_Dep.Text);
        }
        private void B0_S119_Dep_Leave(object sender, EventArgs e)
        {
            updateDepend(0, 119, B0_S119_Dep.Text);
        }
        private void B0_S120_Dep_Leave(object sender, EventArgs e)
        {
            updateDepend(0, 120, B0_S120_Dep.Text);
        }
        private void B0_S121_Dep_Leave(object sender, EventArgs e)
        {
            updateDepend(0, 121, B0_S121_Dep.Text);
        }
        private void B0_S122_Dep_Leave(object sender, EventArgs e)
        {
            updateDepend(0, 122, B0_S122_Dep.Text);
        }
        private void B0_S123_Dep_Leave(object sender, EventArgs e)
        {
            updateDepend(0, 123, B0_S123_Dep.Text);
        }
        private void B0_S124_Dep_Leave(object sender, EventArgs e)
        {
            updateDepend(0, 124, B0_S124_Dep.Text);
        }
        private void B0_S125_Dep_Leave(object sender, EventArgs e)
        {
            updateDepend(0, 125, B0_S125_Dep.Text);
        }
        private void B0_S126_Dep_Leave(object sender, EventArgs e)
        {
            updateDepend(0, 126, B0_S126_Dep.Text);
        }
        private void B0_S127_Dep_Leave(object sender, EventArgs e)
        {
            updateDepend(0, 127, B0_S127_Dep.Text);
        }
        private void updateDepend(int bank, int sample, String text)
        {
            if (text.Contains("0x"))
            {
                Banks[bank].samples[sample].depends[0] = int.Parse(text, NumberStyles.HexNumber);
            }
            else
            {
                Banks[bank].samples[sample].depends[0] = int.Parse(text);
            }
            switch (bank)
            {
                case 0:
                    setCtrl0();
                    break;
                    //case 2:
                    //    setCtrl2();
                    //    break;
                    //case 3:
                    //    setCtrl3();
                    //    break;
                    //case 4:
                    //    setCtrl4();
                    //    break;
                    //case 5:
                    //    setCtrl5();
                    //    break;
                    //case 6:
                    //    setCtrl6();
                    //    break;
                    //case 7:
                    //    setCtrl7();
                    //    break;
                    //case 8:
                    //    setCtrlCom();
                    //    break;
            }

        }
    }
    }
