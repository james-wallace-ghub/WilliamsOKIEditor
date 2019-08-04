using System.Drawing;
using System.Windows.Forms;

namespace OKI_Editor
{
    partial class MainDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileLoadingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.Bank0_1 = new System.Windows.Forms.TabPage();
            this.B0_splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.ALabel_Common = new System.Windows.Forms.Label();
            this.ALabel_Enabled = new System.Windows.Forms.Label();
            this.ALabel_RAW = new System.Windows.Forms.Label();
            this.ALabel_Length = new System.Windows.Forms.Label();
            this.ALabel_Offset = new System.Windows.Forms.Label();
            this.ALabel_Depends = new System.Windows.Forms.Label();
            this.ALabel_ID = new System.Windows.Forms.Label();
            this.ABytes_Label = new System.Windows.Forms.Label();
            this.ASeconds_Label = new System.Windows.Forms.Label();
            this.B0_Table = new System.Windows.Forms.TableLayoutPanel();
            this.B0_Seconds = new System.Windows.Forms.TextBox();
            this.B0_Bytes = new System.Windows.Forms.TextBox();
            this.Bank2 = new System.Windows.Forms.TabPage();
            this.B2_splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.B2_Seconds = new System.Windows.Forms.TextBox();
            this.B2_Bytes = new System.Windows.Forms.TextBox();
            this.B2_Table = new System.Windows.Forms.TableLayoutPanel();
            this.BLabel_Common = new System.Windows.Forms.Label();
            this.BLabel_Enabled = new System.Windows.Forms.Label();
            this.BLabel_RAW = new System.Windows.Forms.Label();
            this.BLabel_Length = new System.Windows.Forms.Label();
            this.BLabel_Offset = new System.Windows.Forms.Label();
            this.BLabel_Depends = new System.Windows.Forms.Label();
            this.BLabel_ID = new System.Windows.Forms.Label();
            this.BBytes_Label = new System.Windows.Forms.Label();
            this.BSeconds_Label = new System.Windows.Forms.Label();
            this.Bank3 = new System.Windows.Forms.TabPage();
            this.B3_splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.B3_Seconds = new System.Windows.Forms.TextBox();
            this.B3_Bytes = new System.Windows.Forms.TextBox();
            this.CLabel_Common = new System.Windows.Forms.Label();
            this.CLabel_Enabled = new System.Windows.Forms.Label();
            this.CLabel_RAW = new System.Windows.Forms.Label();
            this.CLabel_Length = new System.Windows.Forms.Label();
            this.CLabel_Offset = new System.Windows.Forms.Label();
            this.CLabel_Depends = new System.Windows.Forms.Label();
            this.CLabel_ID = new System.Windows.Forms.Label();
            this.CBytes_Label = new System.Windows.Forms.Label();
            this.CSeconds_Label = new System.Windows.Forms.Label();
            this.B3_Table = new System.Windows.Forms.TableLayoutPanel();
            this.Bank4 = new System.Windows.Forms.TabPage();
            this.B4_splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.B4_Seconds = new System.Windows.Forms.TextBox();
            this.B4_Bytes = new System.Windows.Forms.TextBox();
            this.DLabel_Common = new System.Windows.Forms.Label();
            this.DLabel_Enabled = new System.Windows.Forms.Label();
            this.DLabel_RAW = new System.Windows.Forms.Label();
            this.DLabel_Length = new System.Windows.Forms.Label();
            this.DLabel_Offset = new System.Windows.Forms.Label();
            this.DLabel_Depends = new System.Windows.Forms.Label();
            this.DLabel_ID = new System.Windows.Forms.Label();
            this.DBytes_Label = new System.Windows.Forms.Label();
            this.DSeconds_Label = new System.Windows.Forms.Label();
            this.B4_Table = new System.Windows.Forms.TableLayoutPanel();
            this.Bank5 = new System.Windows.Forms.TabPage();
            this.B5_splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.B5_Seconds = new System.Windows.Forms.TextBox();
            this.B5_Bytes = new System.Windows.Forms.TextBox();
            this.ELabel_Common = new System.Windows.Forms.Label();
            this.ELabel_Enabled = new System.Windows.Forms.Label();
            this.ELabel_RAW = new System.Windows.Forms.Label();
            this.ELabel_Length = new System.Windows.Forms.Label();
            this.ELabel_Offset = new System.Windows.Forms.Label();
            this.ELabel_Depends = new System.Windows.Forms.Label();
            this.ELabel_ID = new System.Windows.Forms.Label();
            this.EBytes_Label = new System.Windows.Forms.Label();
            this.ESeconds_Label = new System.Windows.Forms.Label();
            this.B5_Table = new System.Windows.Forms.TableLayoutPanel();
            this.Bank6 = new System.Windows.Forms.TabPage();
            this.B6_splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.B6_Seconds = new System.Windows.Forms.TextBox();
            this.B6_Bytes = new System.Windows.Forms.TextBox();
            this.FLabel_Common = new System.Windows.Forms.Label();
            this.FLabel_Enabled = new System.Windows.Forms.Label();
            this.FLabel_RAW = new System.Windows.Forms.Label();
            this.FLabel_Length = new System.Windows.Forms.Label();
            this.FLabel_Offset = new System.Windows.Forms.Label();
            this.FLabel_Depends = new System.Windows.Forms.Label();
            this.FLabel_ID = new System.Windows.Forms.Label();
            this.FBytes_Label = new System.Windows.Forms.Label();
            this.FSeconds_Label = new System.Windows.Forms.Label();
            this.B6_Table = new System.Windows.Forms.TableLayoutPanel();
            this.Bank7 = new System.Windows.Forms.TabPage();
            this.B7_splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.Label_Common = new System.Windows.Forms.Label();
            this.Label_Enabled = new System.Windows.Forms.Label();
            this.Label_RAW = new System.Windows.Forms.Label();
            this.Label_Length = new System.Windows.Forms.Label();
            this.Label_Offset = new System.Windows.Forms.Label();
            this.Label_Depends = new System.Windows.Forms.Label();
            this.Label_ID = new System.Windows.Forms.Label();
            this.Bytes_Label = new System.Windows.Forms.Label();
            this.Seconds_Label = new System.Windows.Forms.Label();
            this.B7_Seconds = new System.Windows.Forms.TextBox();
            this.B7_Bytes = new System.Windows.Forms.TextBox();
            this.B7_Table = new System.Windows.Forms.TableLayoutPanel();
            this.BankCOM = new System.Windows.Forms.TabPage();
            this.BCOM_splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.COMLabel_Common = new System.Windows.Forms.Label();
            this.COMLabel_Enabled = new System.Windows.Forms.Label();
            this.COMLabel_RAW = new System.Windows.Forms.Label();
            this.COMLabel_Length = new System.Windows.Forms.Label();
            this.COMLabel_Offset = new System.Windows.Forms.Label();
            this.COMLabel_Depends = new System.Windows.Forms.Label();
            this.COMLabel_ID = new System.Windows.Forms.Label();
            this.COMBytes_Label = new System.Windows.Forms.Label();
            this.COMSeconds_Label = new System.Windows.Forms.Label();
            this.BCOM_Seconds = new System.Windows.Forms.TextBox();
            this.BCOM_Bytes = new System.Windows.Forms.TextBox();
            this.BCOM_Table = new System.Windows.Forms.TableLayoutPanel();

            for (int i=0; i <127; i++)
            {
                B0_Play[i] = new System.Windows.Forms.Button();
                B0_Export[i] = new System.Windows.Forms.Button();
                B0_Length[i] = new System.Windows.Forms.TextBox();
				B0_Offset[i] = new System.Windows.Forms.TextBox();
			   B0_Depends[i] = new System.Windows.Forms.TextBox();
                B0_ID[i] = new System.Windows.Forms.TextBox();
                B0_Import[i] = new System.Windows.Forms.Button();
				B0_Enable[i] = new System.Windows.Forms.CheckBox();
				B0_Common[i] = new System.Windows.Forms.CheckBox();
                B0_Play[i].Enabled = false;
                B0_Export[i].Enabled = false;
                B0_Import[i].Enabled = false;
                B0_ID[i].Enabled = false;				
                B2_Play[i] = new System.Windows.Forms.Button();
                B2_Export[i] = new System.Windows.Forms.Button();
                B2_Length[i] = new System.Windows.Forms.TextBox();
                B2_Offset[i] = new System.Windows.Forms.TextBox();
                B2_Depends[i] = new System.Windows.Forms.TextBox();
                B2_ID[i] = new System.Windows.Forms.TextBox();
                B2_Import[i] = new System.Windows.Forms.Button();
                B2_Enable[i] = new System.Windows.Forms.CheckBox();
                B2_Common[i] = new System.Windows.Forms.CheckBox();
                B2_Play[i].Enabled = false;
                B2_Export[i].Enabled = false;
                B2_Import[i].Enabled = false;
                B2_ID[i].Enabled = false;				
                B3_Play[i] = new System.Windows.Forms.Button();
                B3_Export[i] = new System.Windows.Forms.Button();
                B3_Length[i] = new System.Windows.Forms.TextBox();
                B3_Offset[i] = new System.Windows.Forms.TextBox();
                B3_Depends[i] = new System.Windows.Forms.TextBox();
                B3_ID[i] = new System.Windows.Forms.TextBox();
                B3_Import[i] = new System.Windows.Forms.Button();
                B3_Enable[i] = new System.Windows.Forms.CheckBox();
                B3_Common[i] = new System.Windows.Forms.CheckBox();
                B3_Play[i].Enabled = false;
                B3_Export[i].Enabled = false;
                B3_Import[i].Enabled = false;
                B3_ID[i].Enabled = false;				
                B4_Play[i] = new System.Windows.Forms.Button();
                B4_Export[i] = new System.Windows.Forms.Button();
                B4_Length[i] = new System.Windows.Forms.TextBox();
                B4_Offset[i] = new System.Windows.Forms.TextBox();
                B4_Depends[i] = new System.Windows.Forms.TextBox();
                B4_ID[i] = new System.Windows.Forms.TextBox();
                B4_Import[i] = new System.Windows.Forms.Button();
                B4_Enable[i] = new System.Windows.Forms.CheckBox();
                B4_Common[i] = new System.Windows.Forms.CheckBox();
                B4_Play[i].Enabled = false;
                B4_Export[i].Enabled = false;
                B4_Import[i].Enabled = false;
                B4_ID[i].Enabled = false;				
                B5_Play[i] = new System.Windows.Forms.Button();
                B5_Export[i] = new System.Windows.Forms.Button();
                B5_Length[i] = new System.Windows.Forms.TextBox();
                B5_Offset[i] = new System.Windows.Forms.TextBox();
                B5_Depends[i] = new System.Windows.Forms.TextBox();
                B5_ID[i] = new System.Windows.Forms.TextBox();
                B5_Import[i] = new System.Windows.Forms.Button();
                B5_Enable[i] = new System.Windows.Forms.CheckBox();
                B5_Common[i] = new System.Windows.Forms.CheckBox();
                B5_Play[i].Enabled = false;
                B5_Export[i].Enabled = false;
                B5_Import[i].Enabled = false;
                B5_ID[i].Enabled = false;				
                B6_Play[i] = new System.Windows.Forms.Button();
                B6_Export[i] = new System.Windows.Forms.Button();
                B6_Length[i] = new System.Windows.Forms.TextBox();
                B6_Offset[i] = new System.Windows.Forms.TextBox();
                B6_Depends[i] = new System.Windows.Forms.TextBox();
                B6_ID[i] = new System.Windows.Forms.TextBox();
                B6_Import[i] = new System.Windows.Forms.Button();
                B6_Enable[i] = new System.Windows.Forms.CheckBox();
                B6_Common[i] = new System.Windows.Forms.CheckBox();
                B6_Play[i].Enabled = false;
                B6_Export[i].Enabled = false;
                B6_Import[i].Enabled = false;
                B6_ID[i].Enabled = false;				
                B7_Play[i] = new System.Windows.Forms.Button();
                B7_Export[i] = new System.Windows.Forms.Button();
                B7_Length[i] = new System.Windows.Forms.TextBox();
                B7_Offset[i] = new System.Windows.Forms.TextBox();
                B7_Depends[i] = new System.Windows.Forms.TextBox();
                B7_ID[i] = new System.Windows.Forms.TextBox();
                B7_Import[i] = new System.Windows.Forms.Button();
                B7_Enable[i] = new System.Windows.Forms.CheckBox();
                B7_Common[i] = new System.Windows.Forms.CheckBox();
                B7_Play[i].Enabled = false;
                B7_Export[i].Enabled = false;
                B7_Import[i].Enabled = false;
                B7_ID[i].Enabled = false;				
                BCOM_Play[i] = new System.Windows.Forms.Button();
                BCOM_Export[i] = new System.Windows.Forms.Button();
                BCOM_Length[i] = new System.Windows.Forms.TextBox();
                BCOM_Offset[i] = new System.Windows.Forms.TextBox();
                BCOM_Depends[i] = new System.Windows.Forms.TextBox();
                BCOM_ID[i] = new System.Windows.Forms.TextBox();
                BCOM_Import[i] = new System.Windows.Forms.Button();
                BCOM_Enable[i] = new System.Windows.Forms.CheckBox();
                BCOM_Common[i] = new System.Windows.Forms.CheckBox();
                BCOM_Play[i].Enabled = false;
                BCOM_Export[i].Enabled = false;
                BCOM_Import[i].Enabled = false;
                BCOM_ID[i].Enabled = false;				

            }
            this.label1 = new System.Windows.Forms.Label();
            this.samprate = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.Bank0_1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.B0_splitContainer1)).BeginInit();
            this.B0_splitContainer1.Panel1.SuspendLayout();
            this.B0_splitContainer1.Panel2.SuspendLayout();
            this.B0_splitContainer1.SuspendLayout();
            this.B0_Table.SuspendLayout();
            this.Bank2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.B2_splitContainer1)).BeginInit();
            this.B2_splitContainer1.Panel1.SuspendLayout();
            this.B2_splitContainer1.Panel2.SuspendLayout();
            this.B2_splitContainer1.SuspendLayout();
            this.B2_Table.SuspendLayout();
            this.Bank3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.B3_splitContainer1)).BeginInit();
            this.B3_splitContainer1.Panel1.SuspendLayout();
            this.B3_splitContainer1.Panel2.SuspendLayout();
            this.B3_splitContainer1.SuspendLayout();
            this.B3_Table.SuspendLayout();
            this.Bank4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.B4_splitContainer1)).BeginInit();
            this.B4_splitContainer1.Panel1.SuspendLayout();
            this.B4_splitContainer1.Panel2.SuspendLayout();
            this.B4_splitContainer1.SuspendLayout();
            this.B4_Table.SuspendLayout();
            this.Bank5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.B5_splitContainer1)).BeginInit();
            this.B5_splitContainer1.Panel1.SuspendLayout();
            this.B5_splitContainer1.Panel2.SuspendLayout();
            this.B5_splitContainer1.SuspendLayout();
            this.B5_Table.SuspendLayout();
            this.Bank6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.B6_splitContainer1)).BeginInit();
            this.B6_splitContainer1.Panel1.SuspendLayout();
            this.B6_splitContainer1.Panel2.SuspendLayout();
            this.B6_splitContainer1.SuspendLayout();
            this.B6_Table.SuspendLayout();
            this.Bank7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.B7_splitContainer1)).BeginInit();
            this.B7_splitContainer1.Panel1.SuspendLayout();
            this.B7_splitContainer1.Panel2.SuspendLayout();
            this.B7_splitContainer1.SuspendLayout();
            this.B7_Table.SuspendLayout();
            this.BankCOM.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BCOM_splitContainer1)).BeginInit();
            this.BCOM_splitContainer1.Panel1.SuspendLayout();
            this.BCOM_splitContainer1.Panel2.SuspendLayout();
            this.BCOM_splitContainer1.SuspendLayout();
            this.BCOM_Table.SuspendLayout();
            this.Icon = OKI_Editor.Properties.Resources.icon;

            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileLoadingToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(662, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileLoadingToolStripMenuItem
            // 
            this.fileLoadingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem});
            this.fileLoadingToolStripMenuItem.Name = "fileLoadingToolStripMenuItem";
            this.fileLoadingToolStripMenuItem.Size = new System.Drawing.Size(83, 20);
            this.fileLoadingToolStripMenuItem.Text = "File Loading";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.openToolStripMenuItem.Text = "Import ROMs";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.ImportLoad);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.AboutLoad);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.Bank0_1);
            this.tabControl1.Controls.Add(this.Bank2);
            this.tabControl1.Controls.Add(this.Bank3);
            this.tabControl1.Controls.Add(this.Bank4);
            this.tabControl1.Controls.Add(this.Bank5);
            this.tabControl1.Controls.Add(this.Bank6);
            this.tabControl1.Controls.Add(this.Bank7);
            this.tabControl1.Controls.Add(this.BankCOM);
            this.tabControl1.Location = new System.Drawing.Point(2, 46);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(720, 683);
            this.tabControl1.TabIndex = 1;
            // 
            // Bank0_1
            // 
            this.Bank0_1.AutoScroll = true;
            this.Bank0_1.Controls.Add(this.B0_splitContainer1);
            this.Bank0_1.Location = new System.Drawing.Point(4, 22);
            this.Bank0_1.Name = "Bank0_1";
            this.Bank0_1.Padding = new System.Windows.Forms.Padding(3);
            this.Bank0_1.Size = new System.Drawing.Size(720, 657);
            this.Bank0_1.TabIndex = 0;
            this.Bank0_1.Text = "Bank 0 and 1";
            this.Bank0_1.UseVisualStyleBackColor = true;
            // 
            // B0_splitContainer1
            // 
            this.B0_splitContainer1.Location = new System.Drawing.Point(1, 3);
            this.B0_splitContainer1.Name = "B0_splitContainer1";
            this.B0_splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // B0_splitContainer1.Panel1
            // 
            this.B0_splitContainer1.Panel1.Controls.Add(this.B0_Seconds);
            this.B0_splitContainer1.Panel1.Controls.Add(this.B0_Bytes);
            this.B0_splitContainer1.Panel1.Controls.Add(this.ALabel_Common);
            this.B0_splitContainer1.Panel1.Controls.Add(this.ALabel_Enabled);
            this.B0_splitContainer1.Panel1.Controls.Add(this.ALabel_RAW);
            this.B0_splitContainer1.Panel1.Controls.Add(this.ALabel_Length);
            this.B0_splitContainer1.Panel1.Controls.Add(this.ALabel_Offset);
            this.B0_splitContainer1.Panel1.Controls.Add(this.ALabel_Depends);
            this.B0_splitContainer1.Panel1.Controls.Add(this.ALabel_ID);
            this.B0_splitContainer1.Panel1.Controls.Add(this.ABytes_Label);
            this.B0_splitContainer1.Panel1.Controls.Add(this.ASeconds_Label);
            this.B0_splitContainer1.Panel1MinSize = 5;
            // 
            // B0_splitContainer1.Panel2
            // 
            this.B0_splitContainer1.Panel2.AutoScroll = true;
            this.B0_splitContainer1.Panel2.Controls.Add(this.B0_Table);
            this.B0_splitContainer1.Size = new System.Drawing.Size(710, 543);
            this.B0_splitContainer1.SplitterDistance = 37;
            this.B0_splitContainer1.TabIndex = 5;
            // 
            // B0_Seconds
            // 
            this.B0_Seconds.Location = new System.Drawing.Point(279, 0);
            this.B0_Seconds.Name = "B0_Seconds";
            this.B0_Seconds.ReadOnly = true;
            this.B0_Seconds.Size = new System.Drawing.Size(99, 20);
            this.B0_Seconds.TabIndex = 4;
            // 
            // B0_Bytes
            // 
            this.B0_Bytes.Location = new System.Drawing.Point(58, 0);
            this.B0_Bytes.Name = "B0_Bytes";
            this.B0_Bytes.ReadOnly = true;
            this.B0_Bytes.Size = new System.Drawing.Size(99, 20);
            this.B0_Bytes.TabIndex = 2;
            // 
            // ALabel_Common
            // 
            this.ALabel_Common.AutoSize = true;
            this.ALabel_Common.Location = new System.Drawing.Point(78, 23);
            this.ALabel_Common.Name = "ALabel_Common";
            this.ALabel_Common.Size = new System.Drawing.Size(54, 13);
            this.ALabel_Common.TabIndex = 11;
            this.ALabel_Common.Text = "Common?";
            // 
            // ALabel_Enabled
            // 
            this.ALabel_Enabled.AutoSize = true;
            this.ALabel_Enabled.Location = new System.Drawing.Point(-1, 23);
            this.ALabel_Enabled.Name = "ALabel_Enabled";
            this.ALabel_Enabled.Size = new System.Drawing.Size(46, 13);
            this.ALabel_Enabled.TabIndex = 10;
            this.ALabel_Enabled.Text = "Enabled";
            // 
            // ALabel_RAW
            // 
            this.ALabel_RAW.AutoSize = true;
            this.ALabel_RAW.Location = new System.Drawing.Point(473, 23);
            this.ALabel_RAW.Name = "ALabel_RAW";
            this.ALabel_RAW.Size = new System.Drawing.Size(100, 13);
            this.ALabel_RAW.TabIndex = 9;
            this.ALabel_RAW.Text = "RAW ADPCM Data";
            // 
            // ALabel_Length
            // 
            this.ALabel_Length.AutoSize = true;
            this.ALabel_Length.Location = new System.Drawing.Point(376, 23);
            this.ALabel_Length.Name = "ALabel_Length";
            this.ALabel_Length.Size = new System.Drawing.Size(40, 13);
            this.ALabel_Length.TabIndex = 8;
            this.ALabel_Length.Text = "Length";
            // 
            // ALabel_Offset
            // 
            this.ALabel_Offset.AutoSize = true;
            this.ALabel_Offset.Location = new System.Drawing.Point(270, 23);
            this.ALabel_Offset.Name = "ALabel_Offset";
            this.ALabel_Offset.Size = new System.Drawing.Size(35, 13);
            this.ALabel_Offset.TabIndex = 7;
            this.ALabel_Offset.Text = "Offset";
            // 
            // ALabel_Depends
            // 
            this.ALabel_Depends.AutoSize = true;
            this.ALabel_Depends.Location = new System.Drawing.Point(153, 23);
            this.ALabel_Depends.Name = "ALabel_Depends";
            this.ALabel_Depends.Size = new System.Drawing.Size(67, 13);
            this.ALabel_Depends.TabIndex = 6;
            this.ALabel_Depends.Text = "Depends On";
            // 
            // ALabel_ID
            // 
            this.ALabel_ID.AutoSize = true;
            this.ALabel_ID.Location = new System.Drawing.Point(48, 23);
            this.ALabel_ID.Name = "ALabel_ID";
            this.ALabel_ID.Size = new System.Drawing.Size(18, 13);
            this.ALabel_ID.TabIndex = 5;
            this.ALabel_ID.Text = "ID";
            // 
            // ABytes_Label
            // 
            this.ABytes_Label.AutoSize = true;
            this.ABytes_Label.Location = new System.Drawing.Point(3, 3);
            this.ABytes_Label.Name = "ABytes_Label";
            this.ABytes_Label.Size = new System.Drawing.Size(54, 13);
            this.ABytes_Label.TabIndex = 1;
            this.ABytes_Label.Text = "Bytes free";
            // 
            // ASeconds_Label
            // 
            this.ASeconds_Label.AutoSize = true;
            this.ASeconds_Label.Location = new System.Drawing.Point(203, 0);
            this.ASeconds_Label.Name = "ASeconds_Label";
            this.ASeconds_Label.Size = new System.Drawing.Size(70, 13);
            this.ASeconds_Label.TabIndex = 3;
            this.ASeconds_Label.Text = "Seconds free";
            // 
            // B0_Table
            // 
            this.B0_Table.AutoSize = true;
            this.B0_Table.ColumnCount = 9;
            this.B0_Table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.B0_Table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.B0_Table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.B0_Table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.B0_Table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.B0_Table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.B0_Table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.B0_Table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.B0_Table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.B0_Table.Location = new System.Drawing.Point(0, 0);
            this.B0_Table.Name = "B0_Table";
            this.B0_Table.RowCount = 127;
            this.B0_Table.Size = new System.Drawing.Size(720, 2540);
            this.B0_Table.TabIndex = 2;
            for (int i=0; i < 127; i++ )
            {
                this.B0_Table.Controls.Add(B0_Play[i], 8, i);
                this.B0_Table.Controls.Add(B0_Import[i], 7, i);
                this.B0_Table.Controls.Add(B0_Export[i], 6, i);
                this.B0_Table.Controls.Add(B0_Length[i], 5, i);
                this.B0_Table.Controls.Add(B0_Offset[i], 4, i);
                this.B0_Table.Controls.Add(B0_Depends[i], 3, i);
				this.B0_Table.Controls.Add(B0_Common[i], 2, i);
				this.B0_Table.Controls.Add(B0_ID[i], 1, i);
				this.B0_Table.Controls.Add(B0_Enable[i], 0, i);
            }
            for (int i=0; i <127; i++)
            {
				this.B0_Table.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
                int index = i;

                B0_Play[i].Location = new System.Drawing.Point(600, (i * 20));
                B0_Play[i].Margin = new System.Windows.Forms.Padding(0);
                B0_Play[i].Size = new System.Drawing.Size(75, 20);
                B0_Play[i].TabIndex = 14;
                B0_Play[i].Text = "Play";
                B0_Play[i].Click += (sender, e) => playRAWfile(0, index);

                B0_Import[i].Location = new System.Drawing.Point(525, (i*20));
				B0_Import[i].Margin = new System.Windows.Forms.Padding(0);
				B0_Import[i].Size = new System.Drawing.Size(75, 20);
				B0_Import[i].TabIndex = 14;
				B0_Import[i].Text = "Import";
                B0_Import[i].Click += (sender, e) =>importRAWfile(0, index); 

                B0_Export[i].Anchor = System.Windows.Forms.AnchorStyles.None;
                B0_Export[i].Location = new System.Drawing.Point(450, (i*20));
                B0_Export[i].Margin = new System.Windows.Forms.Padding(0);
                B0_Export[i].Size = new System.Drawing.Size(75, 20);
                B0_Export[i].TabIndex = 13;
                B0_Export[i].Text = "Export";
                B0_Export[i].UseVisualStyleBackColor = true;
                B0_Export[i].Click += (sender, e) =>exportRAWfile(0, index); 

				B0_Length[i].Anchor = System.Windows.Forms.AnchorStyles.None;
				B0_Length[i].Location = new System.Drawing.Point(347, (i*20));
				B0_Length[i].Margin = new System.Windows.Forms.Padding(0);
				B0_Length[i].Size = new System.Drawing.Size(100, 20);
				B0_Length[i].TabIndex = 12;
				B0_Length[i].Leave += (sender, e) => UpdateLength(0, index, B0_Length[index].Text);

				B0_Offset[i].Location = new System.Drawing.Point(241,(i*20)+ 3);
				B0_Offset[i].Size = new System.Drawing.Size(100, 20);
				B0_Offset[i].TabIndex = 11;
				B0_Offset[i].Leave += (sender, e) => UpdateOffset(0, index, B0_Offset[index].Text);

				B0_Depends[i].Location = new System.Drawing.Point(135, (i*20) +3);
				B0_Depends[i].Size = new System.Drawing.Size(100, 20);
				B0_Depends[i].TabIndex = 392;
				B0_Depends[i].Leave += (sender, e) => UpdateDepend(0, index, B0_Depends[index].Text);

				B0_ID[i].Location = new System.Drawing.Point(43, (i*20));
				B0_ID[i].Size = new System.Drawing.Size(32, 20);
				B0_ID[i].TabIndex = 518;
				B0_ID[i].Text = i.ToString().PadLeft(3, '0');
				B0_ID[i].Enabled = false;
                B0_ID[i].Leave += (sender, e) => UpdateID(0, index, B0_ID[index].Text);

				B0_Enable[i].Location = new System.Drawing.Point(3, (i*20)+3);
				B0_Enable[i].Size = new System.Drawing.Size(15, 14);
				B0_Enable[i].TabIndex = 770;
				B0_Enable[i].Click += (sender, e) => UpdateEnable(0, index, B0_Enable[index].Checked);

				B0_Common[i].Anchor = System.Windows.Forms.AnchorStyles.None;
				B0_Common[i].AutoSize = true;
				B0_Common[i].Enabled = false;
				B0_Common[i].Location = new System.Drawing.Point(94, (i*20)+3);
				B0_Common[i].Size = new System.Drawing.Size(15, 14);
				B0_Common[i].TabIndex = 897;
				B0_Common[i].UseVisualStyleBackColor = true;

            }
            // 
            // Bank2
            // 
            this.Bank2.AutoScroll = true;
            this.Bank2.Controls.Add(this.B2_splitContainer1);
            this.Bank2.Location = new System.Drawing.Point(4, 22);
            this.Bank2.Name = "Bank2";
            this.Bank2.Padding = new System.Windows.Forms.Padding(3);
            this.Bank2.Size = new System.Drawing.Size(720, 657);
            this.Bank2.TabIndex = 1;
            this.Bank2.Text = "Bank 2";
            this.Bank2.UseVisualStyleBackColor = true;
            // 
            // B2_splitContainer1
            // 
            this.B2_splitContainer1.Location = new System.Drawing.Point(1, 3);
            this.B2_splitContainer1.Name = "B2_splitContainer1";
            this.B2_splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // B2_splitContainer1.Panel1
            // 
            this.B2_splitContainer1.Panel1.Controls.Add(this.B2_Seconds);
            this.B2_splitContainer1.Panel1.Controls.Add(this.B2_Bytes);
            this.B2_splitContainer1.Panel1.Controls.Add(this.BLabel_Common);
            this.B2_splitContainer1.Panel1.Controls.Add(this.BLabel_Enabled);
            this.B2_splitContainer1.Panel1.Controls.Add(this.BLabel_RAW);
            this.B2_splitContainer1.Panel1.Controls.Add(this.BLabel_Length);
            this.B2_splitContainer1.Panel1.Controls.Add(this.BLabel_Offset);
            this.B2_splitContainer1.Panel1.Controls.Add(this.BLabel_Depends);
            this.B2_splitContainer1.Panel1.Controls.Add(this.BLabel_ID);
            this.B2_splitContainer1.Panel1.Controls.Add(this.BBytes_Label);
            this.B2_splitContainer1.Panel1.Controls.Add(this.BSeconds_Label);
            this.B2_splitContainer1.Panel1MinSize = 5;
            // 
            // B2_splitContainer1.Panel2
            // 
            this.B2_splitContainer1.Panel2.AutoScroll = true;
            this.B2_splitContainer1.Panel2.Controls.Add(this.B2_Table);
            this.B2_splitContainer1.Size = new System.Drawing.Size(710, 543);
            this.B2_splitContainer1.SplitterDistance = 37;
            this.B2_splitContainer1.TabIndex = 5;
            // 
            // B2_Seconds
            // 
            this.B2_Seconds.Location = new System.Drawing.Point(279, 0);
            this.B2_Seconds.Name = "B2_Seconds";
            this.B2_Seconds.ReadOnly = true;
            this.B2_Seconds.Size = new System.Drawing.Size(99, 20);
            this.B2_Seconds.TabIndex = 4;
            // 
            // B2_Bytes
            // 
            this.B2_Bytes.Location = new System.Drawing.Point(58, 0);
            this.B2_Bytes.Name = "B2_Bytes";
            this.B2_Bytes.ReadOnly = true;
            this.B2_Bytes.Size = new System.Drawing.Size(99, 20);
            this.B2_Bytes.TabIndex = 2;
            // 
            // BLabel_Common
            // 
            this.BLabel_Common.AutoSize = true;
            this.BLabel_Common.Location = new System.Drawing.Point(78, 23);
            this.BLabel_Common.Name = "BLabel_Common";
            this.BLabel_Common.Size = new System.Drawing.Size(54, 13);
            this.BLabel_Common.TabIndex = 11;
            this.BLabel_Common.Text = "Common?";
            // 
            // BLabel_Enabled
            // 
            this.BLabel_Enabled.AutoSize = true;
            this.BLabel_Enabled.Location = new System.Drawing.Point(-1, 23);
            this.BLabel_Enabled.Name = "BLabel_Enabled";
            this.BLabel_Enabled.Size = new System.Drawing.Size(46, 13);
            this.BLabel_Enabled.TabIndex = 10;
            this.BLabel_Enabled.Text = "Enabled";
            // 
            // BLabel_RAW
            // 
            this.BLabel_RAW.AutoSize = true;
            this.BLabel_RAW.Location = new System.Drawing.Point(473, 23);
            this.BLabel_RAW.Name = "BLabel_RAW";
            this.BLabel_RAW.Size = new System.Drawing.Size(100, 13);
            this.BLabel_RAW.TabIndex = 9;
            this.BLabel_RAW.Text = "RAW ADPCM Data";
            // 
            // BLabel_Length
            // 
            this.BLabel_Length.AutoSize = true;
            this.BLabel_Length.Location = new System.Drawing.Point(376, 23);
            this.BLabel_Length.Name = "BLabel_Length";
            this.BLabel_Length.Size = new System.Drawing.Size(40, 13);
            this.BLabel_Length.TabIndex = 8;
            this.BLabel_Length.Text = "Length";
            // 
            // BLabel_Offset
            // 
            this.BLabel_Offset.AutoSize = true;
            this.BLabel_Offset.Location = new System.Drawing.Point(270, 23);
            this.BLabel_Offset.Name = "BLabel_Offset";
            this.BLabel_Offset.Size = new System.Drawing.Size(35, 13);
            this.BLabel_Offset.TabIndex = 7;
            this.BLabel_Offset.Text = "Offset";
            // 
            // BLabel_Depends
            // 
            this.BLabel_Depends.AutoSize = true;
            this.BLabel_Depends.Location = new System.Drawing.Point(153, 23);
            this.BLabel_Depends.Name = "BLabel_Depends";
            this.BLabel_Depends.Size = new System.Drawing.Size(67, 13);
            this.BLabel_Depends.TabIndex = 6;
            this.BLabel_Depends.Text = "Depends On";
            // 
            // BLabel_ID
            // 
            this.BLabel_ID.AutoSize = true;
            this.BLabel_ID.Location = new System.Drawing.Point(48, 23);
            this.BLabel_ID.Name = "BLabel_ID";
            this.BLabel_ID.Size = new System.Drawing.Size(18, 13);
            this.BLabel_ID.TabIndex = 5;
            this.BLabel_ID.Text = "ID";
            // 
            // BBytes_Label
            // 
            this.BBytes_Label.AutoSize = true;
            this.BBytes_Label.Location = new System.Drawing.Point(3, 3);
            this.BBytes_Label.Name = "BBytes_Label";
            this.BBytes_Label.Size = new System.Drawing.Size(54, 13);
            this.BBytes_Label.TabIndex = 1;
            this.BBytes_Label.Text = "Bytes free";
            // 
            // BSeconds_Label
            // 
            this.BSeconds_Label.AutoSize = true;
            this.BSeconds_Label.Location = new System.Drawing.Point(203, 0);
            this.BSeconds_Label.Name = "BSeconds_Label";
            this.BSeconds_Label.Size = new System.Drawing.Size(70, 13);
            this.BSeconds_Label.TabIndex = 3;
            this.BSeconds_Label.Text = "Seconds free";
            // 
            // B2_Table
            // 
            this.B2_Table.AutoSize = true;
            this.B2_Table.ColumnCount = 9;
            this.B2_Table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.B2_Table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.B2_Table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.B2_Table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.B2_Table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.B2_Table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.B2_Table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.B2_Table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.B2_Table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.B2_Table.Location = new System.Drawing.Point(0, 0);
            this.B2_Table.Name = "B2_Table";
            this.B2_Table.RowCount = 127;
            this.B2_Table.Size = new System.Drawing.Size(720, 2540);

            for (int i = 0; i < 127; i++)
            {
                this.B2_Table.Controls.Add(B2_Play[i], 8, i);
                this.B2_Table.Controls.Add(B2_Import[i], 7, i);
                this.B2_Table.Controls.Add(B2_Export[i], 6, i);
                this.B2_Table.Controls.Add(B2_Length[i], 5, i);
                this.B2_Table.Controls.Add(B2_Offset[i], 4, i);
                this.B2_Table.Controls.Add(B2_Depends[i], 3, i);
                this.B2_Table.Controls.Add(B2_Common[i], 2, i);
                this.B2_Table.Controls.Add(B2_ID[i], 1, i);
                this.B2_Table.Controls.Add(B2_Enable[i], 0, i);
            }
            for (int i = 0; i < 127; i++)
            {
                this.B2_Table.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
                int index = i;

                B2_Play[i].Location = new System.Drawing.Point(600, (i * 20));
                B2_Play[i].Margin = new System.Windows.Forms.Padding(0);
                B2_Play[i].Size = new System.Drawing.Size(75, 20);
                B2_Play[i].TabIndex = 14;
                B2_Play[i].Text = "Play";
                B2_Play[i].Click += (sender, e) => playRAWfile(2, index);

                B2_Import[i].Location = new System.Drawing.Point(525, (i * 20));
                B2_Import[i].Margin = new System.Windows.Forms.Padding(0);
                B2_Import[i].Size = new System.Drawing.Size(75, 20);
                B2_Import[i].TabIndex = 14;
                B2_Import[i].Text = "Import";
                B2_Import[i].Click += (sender, e) => importRAWfile(2, index);

                B2_Export[i].Anchor = System.Windows.Forms.AnchorStyles.None;
                B2_Export[i].Location = new System.Drawing.Point(450, (i * 20));
                B2_Export[i].Margin = new System.Windows.Forms.Padding(0);
                B2_Export[i].Size = new System.Drawing.Size(75, 20);
                B2_Export[i].TabIndex = 13;
                B2_Export[i].Text = "Export";
                B2_Export[i].UseVisualStyleBackColor = true;
                B2_Export[i].Click += (sender, e) => exportRAWfile(2, index);

                B2_Length[i].Anchor = System.Windows.Forms.AnchorStyles.None;
                B2_Length[i].Location = new System.Drawing.Point(347, (i * 20));
                B2_Length[i].Margin = new System.Windows.Forms.Padding(0);
                B2_Length[i].Size = new System.Drawing.Size(100, 20);
                B2_Length[i].TabIndex = 12;
                B2_Length[i].Leave += (sender, e) => UpdateLength(2, index, B2_Length[index].Text);

                B2_Offset[i].Location = new System.Drawing.Point(241, (i * 20) + 3);
                B2_Offset[i].Size = new System.Drawing.Size(100, 20);
                B2_Offset[i].TabIndex = 11;
                B2_Offset[i].Leave += (sender, e) => UpdateOffset(2, index, B2_Offset[index].Text);

                B2_Depends[i].Location = new System.Drawing.Point(135, (i * 20) + 3);
                B2_Depends[i].Size = new System.Drawing.Size(100, 20);
                B2_Depends[i].TabIndex = 392;
                B2_Depends[i].Leave += (sender, e) => UpdateDepend(2, index, B2_Depends[index].Text);

                B2_ID[i].Location = new System.Drawing.Point(43, (i * 20));
                B2_ID[i].Size = new System.Drawing.Size(32, 20);
                B2_ID[i].TabIndex = 518;
                B2_ID[i].Text = i.ToString().PadLeft(3, '0');
                B2_ID[i].Enabled = false;
                B2_ID[i].Leave += (sender, e) => UpdateID(2, index, B2_ID[index].Text);

                B2_Enable[i].Location = new System.Drawing.Point(3, (i * 20) + 3);
                B2_Enable[i].Size = new System.Drawing.Size(15, 14);
                B2_Enable[i].TabIndex = 770;
                B2_Enable[i].Click += (sender, e) => UpdateEnable(2, index, B2_Enable[index].Checked);

                B2_Common[i].Anchor = System.Windows.Forms.AnchorStyles.None;
                B2_Common[i].AutoSize = true;
                B2_Common[i].Enabled = false;
                B2_Common[i].Location = new System.Drawing.Point(94, (i * 20) + 3);
                B2_Common[i].Size = new System.Drawing.Size(15, 14);
                B2_Common[i].TabIndex = 897;
                B2_Common[i].UseVisualStyleBackColor = true;

            }
            // 
            // Bank3
            // 
            this.Bank3.AutoScroll = true;
            this.Bank3.Controls.Add(this.B3_splitContainer1);
            this.Bank3.Location = new System.Drawing.Point(4, 22);
            this.Bank3.Name = "Bank3";
            this.Bank3.Padding = new System.Windows.Forms.Padding(3);
            this.Bank3.Size = new System.Drawing.Size(720, 657);
            this.Bank3.TabIndex = 2;
            this.Bank3.Text = "Bank 3";
            this.Bank3.UseVisualStyleBackColor = true;
            // 
            // B3_splitContainer1
            // 
            this.B3_splitContainer1.Location = new System.Drawing.Point(1, 3);
            this.B3_splitContainer1.Name = "B3_splitContainer1";
            this.B3_splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // B3_splitContainer1.Panel1
            // 
            this.B3_splitContainer1.Panel1.Controls.Add(this.B3_Seconds);
            this.B3_splitContainer1.Panel1.Controls.Add(this.B3_Bytes);
            this.B3_splitContainer1.Panel1.Controls.Add(this.CLabel_Common);
            this.B3_splitContainer1.Panel1.Controls.Add(this.CLabel_Enabled);
            this.B3_splitContainer1.Panel1.Controls.Add(this.CLabel_RAW);
            this.B3_splitContainer1.Panel1.Controls.Add(this.CLabel_Length);
            this.B3_splitContainer1.Panel1.Controls.Add(this.CLabel_Offset);
            this.B3_splitContainer1.Panel1.Controls.Add(this.CLabel_Depends);
            this.B3_splitContainer1.Panel1.Controls.Add(this.CLabel_ID);
            this.B3_splitContainer1.Panel1.Controls.Add(this.CBytes_Label);
            this.B3_splitContainer1.Panel1.Controls.Add(this.CSeconds_Label);
            this.B3_splitContainer1.Panel1MinSize = 5;
            // 
            // B3_splitContainer1.Panel2
            // 
            this.B3_splitContainer1.Panel2.AutoScroll = true;
            this.B3_splitContainer1.Panel2.Controls.Add(this.B3_Table);
            this.B3_splitContainer1.Size = new System.Drawing.Size(710, 543);
            this.B3_splitContainer1.SplitterDistance = 37;
            this.B3_splitContainer1.TabIndex = 5;
            // 
            // B3_Seconds
            // 
            this.B3_Seconds.Location = new System.Drawing.Point(279, 0);
            this.B3_Seconds.Name = "B3_Seconds";
            this.B3_Seconds.ReadOnly = true;
            this.B3_Seconds.Size = new System.Drawing.Size(99, 20);
            this.B3_Seconds.TabIndex = 4;
            // 
            // B3_Bytes
            // 
            this.B3_Bytes.Location = new System.Drawing.Point(58, 0);
            this.B3_Bytes.Name = "B3_Bytes";
            this.B3_Bytes.ReadOnly = true;
            this.B3_Bytes.Size = new System.Drawing.Size(99, 20);
            this.B3_Bytes.TabIndex = 2;
            // 
            // CLabel_Common
            // 
            this.CLabel_Common.AutoSize = true;
            this.CLabel_Common.Location = new System.Drawing.Point(78, 23);
            this.CLabel_Common.Name = "CLabel_Common";
            this.CLabel_Common.Size = new System.Drawing.Size(54, 13);
            this.CLabel_Common.TabIndex = 11;
            this.CLabel_Common.Text = "Common?";
            // 
            // CLabel_Enabled
            // 
            this.CLabel_Enabled.AutoSize = true;
            this.CLabel_Enabled.Location = new System.Drawing.Point(-1, 23);
            this.CLabel_Enabled.Name = "CLabel_Enabled";
            this.CLabel_Enabled.Size = new System.Drawing.Size(46, 13);
            this.CLabel_Enabled.TabIndex = 10;
            this.CLabel_Enabled.Text = "Enabled";
            // 
            // CLabel_RAW
            // 
            this.CLabel_RAW.AutoSize = true;
            this.CLabel_RAW.Location = new System.Drawing.Point(473, 23);
            this.CLabel_RAW.Name = "CLabel_RAW";
            this.CLabel_RAW.Size = new System.Drawing.Size(100, 13);
            this.CLabel_RAW.TabIndex = 9;
            this.CLabel_RAW.Text = "RAW ADPCM Data";
            // 
            // CLabel_Length
            // 
            this.CLabel_Length.AutoSize = true;
            this.CLabel_Length.Location = new System.Drawing.Point(376, 23);
            this.CLabel_Length.Name = "CLabel_Length";
            this.CLabel_Length.Size = new System.Drawing.Size(40, 13);
            this.CLabel_Length.TabIndex = 8;
            this.CLabel_Length.Text = "Length";
            // 
            // CLabel_Offset
            // 
            this.CLabel_Offset.AutoSize = true;
            this.CLabel_Offset.Location = new System.Drawing.Point(270, 23);
            this.CLabel_Offset.Name = "CLabel_Offset";
            this.CLabel_Offset.Size = new System.Drawing.Size(35, 13);
            this.CLabel_Offset.TabIndex = 7;
            this.CLabel_Offset.Text = "Offset";
            // 
            // CLabel_Depends
            // 
            this.CLabel_Depends.AutoSize = true;
            this.CLabel_Depends.Location = new System.Drawing.Point(153, 23);
            this.CLabel_Depends.Name = "CLabel_Depends";
            this.CLabel_Depends.Size = new System.Drawing.Size(67, 13);
            this.CLabel_Depends.TabIndex = 6;
            this.CLabel_Depends.Text = "Depends On";
            // 
            // CLabel_ID
            // 
            this.CLabel_ID.AutoSize = true;
            this.CLabel_ID.Location = new System.Drawing.Point(48, 23);
            this.CLabel_ID.Name = "CLabel_ID";
            this.CLabel_ID.Size = new System.Drawing.Size(18, 13);
            this.CLabel_ID.TabIndex = 5;
            this.CLabel_ID.Text = "ID";
            // 
            // CBytes_Label
            // 
            this.CBytes_Label.AutoSize = true;
            this.CBytes_Label.Location = new System.Drawing.Point(3, 3);
            this.CBytes_Label.Name = "CBytes_Label";
            this.CBytes_Label.Size = new System.Drawing.Size(54, 13);
            this.CBytes_Label.TabIndex = 1;
            this.CBytes_Label.Text = "Bytes free";
            // 
            // CSeconds_Label
            // 
            this.CSeconds_Label.AutoSize = true;
            this.CSeconds_Label.Location = new System.Drawing.Point(203, 0);
            this.CSeconds_Label.Name = "CSeconds_Label";
            this.CSeconds_Label.Size = new System.Drawing.Size(70, 13);
            this.CSeconds_Label.TabIndex = 3;
            this.CSeconds_Label.Text = "Seconds free";
            // 
            // B3_Table
            // 
            this.B3_Table.AutoSize = true;
            this.B3_Table.ColumnCount = 9;
            this.B3_Table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.B3_Table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.B3_Table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.B3_Table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.B3_Table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.B3_Table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.B3_Table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.B3_Table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.B3_Table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.B3_Table.Location = new System.Drawing.Point(0, 0);
            this.B3_Table.Name = "B3_Table";
            this.B3_Table.RowCount = 127;
            this.B3_Table.Size = new System.Drawing.Size(720, 2540);

            for (int i = 0; i < 127; i++)
            {
                this.B3_Table.Controls.Add(B3_Play[i], 8, i);
                this.B3_Table.Controls.Add(B3_Import[i], 7, i);
                this.B3_Table.Controls.Add(B3_Export[i], 6, i);
                this.B3_Table.Controls.Add(B3_Length[i], 5, i);
                this.B3_Table.Controls.Add(B3_Offset[i], 4, i);
                this.B3_Table.Controls.Add(B3_Depends[i], 3, i);
                this.B3_Table.Controls.Add(B3_Common[i], 2, i);
                this.B3_Table.Controls.Add(B3_ID[i], 1, i);
                this.B3_Table.Controls.Add(B3_Enable[i], 0, i);
            }
            for (int i = 0; i < 127; i++)
            {
                this.B3_Table.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
                int index = i;

                B3_Play[i].Location = new System.Drawing.Point(600, (i * 20));
                B3_Play[i].Margin = new System.Windows.Forms.Padding(0);
                B3_Play[i].Size = new System.Drawing.Size(75, 20);
                B3_Play[i].TabIndex = 14;
                B3_Play[i].Text = "Play";
                B3_Play[i].Click += (sender, e) => playRAWfile(3, index);

                B3_Import[i].Location = new System.Drawing.Point(525, (i * 20));
                B3_Import[i].Margin = new System.Windows.Forms.Padding(0);
                B3_Import[i].Size = new System.Drawing.Size(75, 20);
                B3_Import[i].TabIndex = 14;
                B3_Import[i].Text = "Import";
                B3_Import[i].Click += (sender, e) => importRAWfile(3, index);

                B3_Export[i].Anchor = System.Windows.Forms.AnchorStyles.None;
                B3_Export[i].Location = new System.Drawing.Point(450, (i * 20));
                B3_Export[i].Margin = new System.Windows.Forms.Padding(0);
                B3_Export[i].Size = new System.Drawing.Size(75, 20);
                B3_Export[i].TabIndex = 13;
                B3_Export[i].Text = "Export";
                B3_Export[i].UseVisualStyleBackColor = true;
                B3_Export[i].Click += (sender, e) => exportRAWfile(3, index);

                B3_Length[i].Anchor = System.Windows.Forms.AnchorStyles.None;
                B3_Length[i].Location = new System.Drawing.Point(347, (i * 20));
                B3_Length[i].Margin = new System.Windows.Forms.Padding(0);
                B3_Length[i].Size = new System.Drawing.Size(100, 20);
                B3_Length[i].TabIndex = 12;
                B3_Length[i].Leave += (sender, e) => UpdateLength(3, index, B3_Length[index].Text);

                B3_Offset[i].Location = new System.Drawing.Point(241, (i * 20) + 3);
                B3_Offset[i].Size = new System.Drawing.Size(100, 20);
                B3_Offset[i].TabIndex = 11;
                B3_Offset[i].Leave += (sender, e) => UpdateOffset(3, index, B3_Offset[index].Text);

                B3_Depends[i].Location = new System.Drawing.Point(135, (i * 20) + 3);
                B3_Depends[i].Size = new System.Drawing.Size(100, 20);
                B3_Depends[i].TabIndex = 392;
                B3_Depends[i].Leave += (sender, e) => UpdateDepend(3, index, B3_Depends[index].Text);

                B3_ID[i].Location = new System.Drawing.Point(43, (i * 20));
                B3_ID[i].Size = new System.Drawing.Size(32, 20);
                B3_ID[i].TabIndex = 518;
                B3_ID[i].Text = i.ToString().PadLeft(3, '0');
                B3_ID[i].Enabled = false;
                B3_ID[i].Leave += (sender, e) => UpdateID(3, index, B3_ID[index].Text);

                B3_Enable[i].Location = new System.Drawing.Point(3, (i * 20) + 3);
                B3_Enable[i].Size = new System.Drawing.Size(15, 14);
                B3_Enable[i].TabIndex = 770;
                B3_Enable[i].Click += (sender, e) => UpdateEnable(3, index, B3_Enable[index].Checked);

                B3_Common[i].Anchor = System.Windows.Forms.AnchorStyles.None;
                B3_Common[i].AutoSize = true;
                B3_Common[i].Enabled = false;
                B3_Common[i].Location = new System.Drawing.Point(94, (i * 20) + 3);
                B3_Common[i].Size = new System.Drawing.Size(15, 14);
                B3_Common[i].TabIndex = 897;
                B3_Common[i].UseVisualStyleBackColor = true;

            }
            // 
            // Bank4
            // 
            this.Bank4.AutoScroll = true;
            this.Bank4.Controls.Add(this.B4_splitContainer1);
            this.Bank4.Location = new System.Drawing.Point(4, 22);
            this.Bank4.Name = "Bank4";
            this.Bank4.Padding = new System.Windows.Forms.Padding(3);
            this.Bank4.Size = new System.Drawing.Size(720, 657);
            this.Bank4.TabIndex = 3;
            this.Bank4.Text = "Bank 4";
            this.Bank4.UseVisualStyleBackColor = true;
            // 
            // B4_splitContainer1
            // 
            this.B4_splitContainer1.Location = new System.Drawing.Point(1, 3);
            this.B4_splitContainer1.Name = "B4_splitContainer1";
            this.B4_splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // B4_splitContainer1.Panel1
            // 
            this.B4_splitContainer1.Panel1.Controls.Add(this.B4_Seconds);
            this.B4_splitContainer1.Panel1.Controls.Add(this.B4_Bytes);
            this.B4_splitContainer1.Panel1.Controls.Add(this.DLabel_Common);
            this.B4_splitContainer1.Panel1.Controls.Add(this.DLabel_Enabled);
            this.B4_splitContainer1.Panel1.Controls.Add(this.DLabel_RAW);
            this.B4_splitContainer1.Panel1.Controls.Add(this.DLabel_Length);
            this.B4_splitContainer1.Panel1.Controls.Add(this.DLabel_Offset);
            this.B4_splitContainer1.Panel1.Controls.Add(this.DLabel_Depends);
            this.B4_splitContainer1.Panel1.Controls.Add(this.DLabel_ID);
            this.B4_splitContainer1.Panel1.Controls.Add(this.DBytes_Label);
            this.B4_splitContainer1.Panel1.Controls.Add(this.DSeconds_Label);
            this.B4_splitContainer1.Panel1MinSize = 5;
            // 
            // B4_splitContainer1.Panel2
            // 
            this.B4_splitContainer1.Panel2.AutoScroll = true;
            this.B4_splitContainer1.Panel2.Controls.Add(this.B4_Table);
            this.B4_splitContainer1.Size = new System.Drawing.Size(710, 543);
            this.B4_splitContainer1.SplitterDistance = 37;
            this.B4_splitContainer1.TabIndex = 5;
            // 
            // B4_Seconds
            // 
            this.B4_Seconds.Location = new System.Drawing.Point(279, 0);
            this.B4_Seconds.Name = "B4_Seconds";
            this.B4_Seconds.ReadOnly = true;
            this.B4_Seconds.Size = new System.Drawing.Size(99, 20);
            this.B4_Seconds.TabIndex = 4;
            // 
            // B4_Bytes
            // 
            this.B4_Bytes.Location = new System.Drawing.Point(58, 0);
            this.B4_Bytes.Name = "B4_Bytes";
            this.B4_Bytes.ReadOnly = true;
            this.B4_Bytes.Size = new System.Drawing.Size(99, 20);
            this.B4_Bytes.TabIndex = 2;
            // 
            // DLabel_Common
            // 
            this.DLabel_Common.AutoSize = true;
            this.DLabel_Common.Location = new System.Drawing.Point(78, 23);
            this.DLabel_Common.Name = "DLabel_Common";
            this.DLabel_Common.Size = new System.Drawing.Size(54, 13);
            this.DLabel_Common.TabIndex = 11;
            this.DLabel_Common.Text = "Common?";
            // 
            // DLabel_Enabled
            // 
            this.DLabel_Enabled.AutoSize = true;
            this.DLabel_Enabled.Location = new System.Drawing.Point(-1, 23);
            this.DLabel_Enabled.Name = "DLabel_Enabled";
            this.DLabel_Enabled.Size = new System.Drawing.Size(46, 13);
            this.DLabel_Enabled.TabIndex = 10;
            this.DLabel_Enabled.Text = "Enabled";
            // 
            // DLabel_RAW
            // 
            this.DLabel_RAW.AutoSize = true;
            this.DLabel_RAW.Location = new System.Drawing.Point(473, 23);
            this.DLabel_RAW.Name = "DLabel_RAW";
            this.DLabel_RAW.Size = new System.Drawing.Size(100, 13);
            this.DLabel_RAW.TabIndex = 9;
            this.DLabel_RAW.Text = "RAW ADPCM Data";
            // 
            // DLabel_Length
            // 
            this.DLabel_Length.AutoSize = true;
            this.DLabel_Length.Location = new System.Drawing.Point(376, 23);
            this.DLabel_Length.Name = "DLabel_Length";
            this.DLabel_Length.Size = new System.Drawing.Size(40, 13);
            this.DLabel_Length.TabIndex = 8;
            this.DLabel_Length.Text = "Length";
            // 
            // DLabel_Offset
            // 
            this.DLabel_Offset.AutoSize = true;
            this.DLabel_Offset.Location = new System.Drawing.Point(270, 23);
            this.DLabel_Offset.Name = "DLabel_Offset";
            this.DLabel_Offset.Size = new System.Drawing.Size(35, 13);
            this.DLabel_Offset.TabIndex = 7;
            this.DLabel_Offset.Text = "Offset";
            // 
            // DLabel_Depends
            // 
            this.DLabel_Depends.AutoSize = true;
            this.DLabel_Depends.Location = new System.Drawing.Point(153, 23);
            this.DLabel_Depends.Name = "DLabel_Depends";
            this.DLabel_Depends.Size = new System.Drawing.Size(67, 13);
            this.DLabel_Depends.TabIndex = 6;
            this.DLabel_Depends.Text = "Depends On";
            // 
            // DLabel_ID
            // 
            this.DLabel_ID.AutoSize = true;
            this.DLabel_ID.Location = new System.Drawing.Point(48, 23);
            this.DLabel_ID.Name = "DLabel_ID";
            this.DLabel_ID.Size = new System.Drawing.Size(18, 13);
            this.DLabel_ID.TabIndex = 5;
            this.DLabel_ID.Text = "ID";
            // 
            // DBytes_Label
            // 
            this.DBytes_Label.AutoSize = true;
            this.DBytes_Label.Location = new System.Drawing.Point(3, 3);
            this.DBytes_Label.Name = "DBytes_Label";
            this.DBytes_Label.Size = new System.Drawing.Size(54, 13);
            this.DBytes_Label.TabIndex = 1;
            this.DBytes_Label.Text = "Bytes free";
            // 
            // DSeconds_Label
            // 
            this.DSeconds_Label.AutoSize = true;
            this.DSeconds_Label.Location = new System.Drawing.Point(203, 0);
            this.DSeconds_Label.Name = "DSeconds_Label";
            this.DSeconds_Label.Size = new System.Drawing.Size(70, 13);
            this.DSeconds_Label.TabIndex = 3;
            this.DSeconds_Label.Text = "Seconds free";
            // 
            // B4_Table
            // 
            this.B4_Table.AutoSize = true;
            this.B4_Table.ColumnCount = 9;
            this.B4_Table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.B4_Table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.B4_Table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.B4_Table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.B4_Table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.B4_Table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.B4_Table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.B4_Table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.B4_Table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.B4_Table.Location = new System.Drawing.Point(0, 0);
            this.B4_Table.Name = "B4_Table";
            this.B4_Table.RowCount = 127;
            this.B4_Table.Size = new System.Drawing.Size(720, 2540);
            for (int i = 0; i < 127; i++)
            {
                this.B4_Table.Controls.Add(B4_Play[i], 8, i);
                this.B4_Table.Controls.Add(B4_Import[i], 7, i);
                this.B4_Table.Controls.Add(B4_Export[i], 6, i);
                this.B4_Table.Controls.Add(B4_Length[i], 5, i);
                this.B4_Table.Controls.Add(B4_Offset[i], 4, i);
                this.B4_Table.Controls.Add(B4_Depends[i], 3, i);
                this.B4_Table.Controls.Add(B4_Common[i], 2, i);
                this.B4_Table.Controls.Add(B4_ID[i], 1, i);
                this.B4_Table.Controls.Add(B4_Enable[i], 0, i);
            }
            for (int i = 0; i < 127; i++)
            {
                this.B4_Table.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
                int index = i;

                B4_Play[i].Location = new System.Drawing.Point(600, (i * 20));
                B4_Play[i].Margin = new System.Windows.Forms.Padding(0);
                B4_Play[i].Size = new System.Drawing.Size(75, 20);
                B4_Play[i].TabIndex = 14;
                B4_Play[i].Text = "Play";
                B4_Play[i].Click += (sender, e) => playRAWfile(4, index);

                B4_Import[i].Location = new System.Drawing.Point(525, (i * 20));
                B4_Import[i].Margin = new System.Windows.Forms.Padding(0);
                B4_Import[i].Size = new System.Drawing.Size(75, 20);
                B4_Import[i].TabIndex = 14;
                B4_Import[i].Text = "Import";
                B4_Import[i].Click += (sender, e) => importRAWfile(4, index);

                B4_Export[i].Anchor = System.Windows.Forms.AnchorStyles.None;
                B4_Export[i].Location = new System.Drawing.Point(450, (i * 20));
                B4_Export[i].Margin = new System.Windows.Forms.Padding(0);
                B4_Export[i].Size = new System.Drawing.Size(75, 20);
                B4_Export[i].TabIndex = 13;
                B4_Export[i].Text = "Export";
                B4_Export[i].UseVisualStyleBackColor = true;
                B4_Export[i].Click += (sender, e) => exportRAWfile(4, index);

                B4_Length[i].Anchor = System.Windows.Forms.AnchorStyles.None;
                B4_Length[i].Location = new System.Drawing.Point(347, (i * 20));
                B4_Length[i].Margin = new System.Windows.Forms.Padding(0);
                B4_Length[i].Size = new System.Drawing.Size(100, 20);
                B4_Length[i].TabIndex = 12;
                B4_Length[i].Leave += (sender, e) => UpdateLength(4, index, B4_Length[index].Text);

                B4_Offset[i].Location = new System.Drawing.Point(241, (i * 20) + 3);
                B4_Offset[i].Size = new System.Drawing.Size(100, 20);
                B4_Offset[i].TabIndex = 11;
                B4_Offset[i].Leave += (sender, e) => UpdateOffset(4, index, B4_Offset[index].Text);

                B4_Depends[i].Location = new System.Drawing.Point(135, (i * 20) + 3);
                B4_Depends[i].Size = new System.Drawing.Size(100, 20);
                B4_Depends[i].TabIndex = 392;
                B4_Depends[i].Leave += (sender, e) => UpdateDepend(4, index, B4_Depends[index].Text);

                B4_ID[i].Location = new System.Drawing.Point(43, (i * 20));
                B4_ID[i].Size = new System.Drawing.Size(32, 20);
                B4_ID[i].TabIndex = 518;
                B4_ID[i].Text = i.ToString().PadLeft(3, '0');
                B4_ID[i].Enabled = false;
                B4_ID[i].Leave += (sender, e) => UpdateID(4, index, B4_ID[index].Text);

                B4_Enable[i].Location = new System.Drawing.Point(3, (i * 20) + 3);
                B4_Enable[i].Size = new System.Drawing.Size(15, 14);
                B4_Enable[i].TabIndex = 770;
                B4_Enable[i].Click += (sender, e) => UpdateEnable(4, index, B4_Enable[index].Checked);

                B4_Common[i].Anchor = System.Windows.Forms.AnchorStyles.None;
                B4_Common[i].AutoSize = true;
                B4_Common[i].Enabled = false;
                B4_Common[i].Location = new System.Drawing.Point(94, (i * 20) + 3);
                B4_Common[i].Size = new System.Drawing.Size(15, 14);
                B4_Common[i].TabIndex = 897;
                B4_Common[i].UseVisualStyleBackColor = true;

            }
            // 
            // Bank5
            // 
            this.Bank5.AutoScroll = true;
            this.Bank5.Controls.Add(this.B5_splitContainer1);
            this.Bank5.Location = new System.Drawing.Point(4, 22);
            this.Bank5.Name = "Bank5";
            this.Bank5.Padding = new System.Windows.Forms.Padding(3);
            this.Bank5.Size = new System.Drawing.Size(720, 657);
            this.Bank5.TabIndex = 4;
            this.Bank5.Text = "Bank 5";
            this.Bank5.UseVisualStyleBackColor = true;
            // 
            // B5_splitContainer1
            // 
            this.B5_splitContainer1.Location = new System.Drawing.Point(1, 3);
            this.B5_splitContainer1.Name = "B5_splitContainer1";
            this.B5_splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // B5_splitContainer1.Panel1
            // 
            this.B5_splitContainer1.Panel1.Controls.Add(this.B5_Seconds);
            this.B5_splitContainer1.Panel1.Controls.Add(this.B5_Bytes);
            this.B5_splitContainer1.Panel1.Controls.Add(this.ELabel_Common);
            this.B5_splitContainer1.Panel1.Controls.Add(this.ELabel_Enabled);
            this.B5_splitContainer1.Panel1.Controls.Add(this.ELabel_RAW);
            this.B5_splitContainer1.Panel1.Controls.Add(this.ELabel_Length);
            this.B5_splitContainer1.Panel1.Controls.Add(this.ELabel_Offset);
            this.B5_splitContainer1.Panel1.Controls.Add(this.ELabel_Depends);
            this.B5_splitContainer1.Panel1.Controls.Add(this.ELabel_ID);
            this.B5_splitContainer1.Panel1.Controls.Add(this.EBytes_Label);
            this.B5_splitContainer1.Panel1.Controls.Add(this.ESeconds_Label);
            this.B5_splitContainer1.Panel1MinSize = 5;
            // 
            // B5_splitContainer1.Panel2
            // 
            this.B5_splitContainer1.Panel2.AutoScroll = true;
            this.B5_splitContainer1.Panel2.Controls.Add(this.B5_Table);
            this.B5_splitContainer1.Size = new System.Drawing.Size(710, 543);
            this.B5_splitContainer1.SplitterDistance = 37;
            this.B5_splitContainer1.TabIndex = 5;
            // 
            // B5_Seconds
            // 
            this.B5_Seconds.Location = new System.Drawing.Point(279, 0);
            this.B5_Seconds.Name = "B5_Seconds";
            this.B5_Seconds.ReadOnly = true;
            this.B5_Seconds.Size = new System.Drawing.Size(99, 20);
            this.B5_Seconds.TabIndex = 4;
            // 
            // B5_Bytes
            // 
            this.B5_Bytes.Location = new System.Drawing.Point(58, 0);
            this.B5_Bytes.Name = "B5_Bytes";
            this.B5_Bytes.ReadOnly = true;
            this.B5_Bytes.Size = new System.Drawing.Size(99, 20);
            this.B5_Bytes.TabIndex = 2;
            // 
            // ELabel_Common
            // 
            this.ELabel_Common.AutoSize = true;
            this.ELabel_Common.Location = new System.Drawing.Point(78, 23);
            this.ELabel_Common.Name = "ELabel_Common";
            this.ELabel_Common.Size = new System.Drawing.Size(54, 13);
            this.ELabel_Common.TabIndex = 11;
            this.ELabel_Common.Text = "Common?";
            // 
            // ELabel_Enabled
            // 
            this.ELabel_Enabled.AutoSize = true;
            this.ELabel_Enabled.Location = new System.Drawing.Point(-1, 23);
            this.ELabel_Enabled.Name = "ELabel_Enabled";
            this.ELabel_Enabled.Size = new System.Drawing.Size(46, 13);
            this.ELabel_Enabled.TabIndex = 10;
            this.ELabel_Enabled.Text = "Enabled";
            // 
            // ELabel_RAW
            // 
            this.ELabel_RAW.AutoSize = true;
            this.ELabel_RAW.Location = new System.Drawing.Point(473, 23);
            this.ELabel_RAW.Name = "ELabel_RAW";
            this.ELabel_RAW.Size = new System.Drawing.Size(100, 13);
            this.ELabel_RAW.TabIndex = 9;
            this.ELabel_RAW.Text = "RAW ADPCM Data";
            // 
            // ELabel_Length
            // 
            this.ELabel_Length.AutoSize = true;
            this.ELabel_Length.Location = new System.Drawing.Point(376, 23);
            this.ELabel_Length.Name = "ELabel_Length";
            this.ELabel_Length.Size = new System.Drawing.Size(40, 13);
            this.ELabel_Length.TabIndex = 8;
            this.ELabel_Length.Text = "Length";
            // 
            // ELabel_Offset
            // 
            this.ELabel_Offset.AutoSize = true;
            this.ELabel_Offset.Location = new System.Drawing.Point(270, 23);
            this.ELabel_Offset.Name = "ELabel_Offset";
            this.ELabel_Offset.Size = new System.Drawing.Size(35, 13);
            this.ELabel_Offset.TabIndex = 7;
            this.ELabel_Offset.Text = "Offset";
            // 
            // ELabel_Depends
            // 
            this.ELabel_Depends.AutoSize = true;
            this.ELabel_Depends.Location = new System.Drawing.Point(153, 23);
            this.ELabel_Depends.Name = "ELabel_Depends";
            this.ELabel_Depends.Size = new System.Drawing.Size(67, 13);
            this.ELabel_Depends.TabIndex = 6;
            this.ELabel_Depends.Text = "Depends On";
            // 
            // ELabel_ID
            // 
            this.ELabel_ID.AutoSize = true;
            this.ELabel_ID.Location = new System.Drawing.Point(48, 23);
            this.ELabel_ID.Name = "ELabel_ID";
            this.ELabel_ID.Size = new System.Drawing.Size(18, 13);
            this.ELabel_ID.TabIndex = 5;
            this.ELabel_ID.Text = "ID";
            // 
            // EBytes_Label
            // 
            this.EBytes_Label.AutoSize = true;
            this.EBytes_Label.Location = new System.Drawing.Point(3, 3);
            this.EBytes_Label.Name = "EBytes_Label";
            this.EBytes_Label.Size = new System.Drawing.Size(54, 13);
            this.EBytes_Label.TabIndex = 1;
            this.EBytes_Label.Text = "Bytes free";
            // 
            // ESeconds_Label
            // 
            this.ESeconds_Label.AutoSize = true;
            this.ESeconds_Label.Location = new System.Drawing.Point(203, 0);
            this.ESeconds_Label.Name = "ESeconds_Label";
            this.ESeconds_Label.Size = new System.Drawing.Size(70, 13);
            this.ESeconds_Label.TabIndex = 3;
            this.ESeconds_Label.Text = "Seconds free";
            // 
            // B5_Table
            // 
            this.B5_Table.AutoSize = true;
            this.B5_Table.ColumnCount = 9;
            this.B5_Table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.B5_Table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.B5_Table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.B5_Table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.B5_Table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.B5_Table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.B5_Table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.B5_Table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.B5_Table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.B5_Table.Location = new System.Drawing.Point(0, 0);
            this.B5_Table.Name = "B5_Table";
            this.B5_Table.RowCount = 127;
            this.B5_Table.Size = new System.Drawing.Size(720, 2540);
            this.B5_Table.TabIndex = 2;
            for (int i = 0; i < 127; i++)
            {
                this.B5_Table.Controls.Add(B5_Play[i], 8, i);
                this.B5_Table.Controls.Add(B5_Import[i], 7, i);
                this.B5_Table.Controls.Add(B5_Export[i], 6, i);
                this.B5_Table.Controls.Add(B5_Length[i], 5, i);
                this.B5_Table.Controls.Add(B5_Offset[i], 4, i);
                this.B5_Table.Controls.Add(B5_Depends[i], 3, i);
                this.B5_Table.Controls.Add(B5_Common[i], 2, i);
                this.B5_Table.Controls.Add(B5_ID[i], 1, i);
                this.B5_Table.Controls.Add(B5_Enable[i], 0, i);
            }
            for (int i = 0; i < 127; i++)
            {
                this.B5_Table.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
                int index = i;

                B5_Play[i].Location = new System.Drawing.Point(600, (i * 20));
                B5_Play[i].Margin = new System.Windows.Forms.Padding(0);
                B5_Play[i].Size = new System.Drawing.Size(75, 20);
                B5_Play[i].TabIndex = 14;
                B5_Play[i].Text = "Play";
                B5_Play[i].Click += (sender, e) => playRAWfile(5, index);

                B5_Import[i].Location = new System.Drawing.Point(525, (i * 20));
                B5_Import[i].Margin = new System.Windows.Forms.Padding(0);
                B5_Import[i].Size = new System.Drawing.Size(75, 20);
                B5_Import[i].TabIndex = 14;
                B5_Import[i].Text = "Import";
                B5_Import[i].Click += (sender, e) => importRAWfile(5, index);

                B5_Export[i].Anchor = System.Windows.Forms.AnchorStyles.None;
                B5_Export[i].Location = new System.Drawing.Point(450, (i * 20));
                B5_Export[i].Margin = new System.Windows.Forms.Padding(0);
                B5_Export[i].Size = new System.Drawing.Size(75, 20);
                B5_Export[i].TabIndex = 13;
                B5_Export[i].Text = "Export";
                B5_Export[i].UseVisualStyleBackColor = true;
                B5_Export[i].Click += (sender, e) => exportRAWfile(5, index);

                B5_Length[i].Anchor = System.Windows.Forms.AnchorStyles.None;
                B5_Length[i].Location = new System.Drawing.Point(347, (i * 20));
                B5_Length[i].Margin = new System.Windows.Forms.Padding(0);
                B5_Length[i].Size = new System.Drawing.Size(100, 20);
                B5_Length[i].TabIndex = 12;
                B5_Length[i].Leave += (sender, e) => UpdateLength(5, index, B5_Length[index].Text);

                B5_Offset[i].Location = new System.Drawing.Point(241, (i * 20) + 3);
                B5_Offset[i].Size = new System.Drawing.Size(100, 20);
                B5_Offset[i].TabIndex = 11;
                B5_Offset[i].Leave += (sender, e) => UpdateOffset(5, index, B5_Offset[index].Text);

                B5_Depends[i].Location = new System.Drawing.Point(135, (i * 20) + 3);
                B5_Depends[i].Size = new System.Drawing.Size(100, 20);
                B5_Depends[i].TabIndex = 392;
                B5_Depends[i].Leave += (sender, e) => UpdateDepend(5, index, B5_Depends[index].Text);

                B5_ID[i].Location = new System.Drawing.Point(43, (i * 20));
                B5_ID[i].Size = new System.Drawing.Size(32, 20);
                B5_ID[i].TabIndex = 518;
                B5_ID[i].Text = i.ToString().PadLeft(3, '0');
                B5_ID[i].Enabled = false;
                B5_ID[i].Leave += (sender, e) => UpdateID(5, index, B5_ID[index].Text);

                B5_Enable[i].Location = new System.Drawing.Point(3, (i * 20) + 3);
                B5_Enable[i].Size = new System.Drawing.Size(15, 14);
                B5_Enable[i].TabIndex = 770;
                B5_Enable[i].Click += (sender, e) => UpdateEnable(5, index, B5_Enable[index].Checked);

                B5_Common[i].Anchor = System.Windows.Forms.AnchorStyles.None;
                B5_Common[i].AutoSize = true;
                B5_Common[i].Enabled = false;
                B5_Common[i].Location = new System.Drawing.Point(94, (i * 20) + 3);
                B5_Common[i].Size = new System.Drawing.Size(15, 14);
                B5_Common[i].TabIndex = 897;
                B5_Common[i].UseVisualStyleBackColor = true;

            }
            // 
            // Bank6
            // 
            this.Bank6.AutoScroll = true;
            this.Bank6.Controls.Add(this.B6_splitContainer1);
            this.Bank6.Location = new System.Drawing.Point(4, 22);
            this.Bank6.Name = "Bank6";
            this.Bank6.Padding = new System.Windows.Forms.Padding(3);
            this.Bank6.Size = new System.Drawing.Size(720, 657);
            this.Bank6.TabIndex = 5;
            this.Bank6.Text = "Bank 6";
            this.Bank6.UseVisualStyleBackColor = true;
            // 
            // B6_splitContainer1
            // 
            this.B6_splitContainer1.Location = new System.Drawing.Point(1, 3);
            this.B6_splitContainer1.Name = "B6_splitContainer1";
            this.B6_splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // B6_splitContainer1.Panel1
            // 
            this.B6_splitContainer1.Panel1.Controls.Add(this.B6_Seconds);
            this.B6_splitContainer1.Panel1.Controls.Add(this.B6_Bytes);
            this.B6_splitContainer1.Panel1.Controls.Add(this.FLabel_Common);
            this.B6_splitContainer1.Panel1.Controls.Add(this.FLabel_Enabled);
            this.B6_splitContainer1.Panel1.Controls.Add(this.FLabel_RAW);
            this.B6_splitContainer1.Panel1.Controls.Add(this.FLabel_Length);
            this.B6_splitContainer1.Panel1.Controls.Add(this.FLabel_Offset);
            this.B6_splitContainer1.Panel1.Controls.Add(this.FLabel_Depends);
            this.B6_splitContainer1.Panel1.Controls.Add(this.FLabel_ID);
            this.B6_splitContainer1.Panel1.Controls.Add(this.FBytes_Label);
            this.B6_splitContainer1.Panel1.Controls.Add(this.FSeconds_Label);
            this.B6_splitContainer1.Panel1MinSize = 5;
            // 
            // B6_splitContainer1.Panel2
            // 
            this.B6_splitContainer1.Panel2.AutoScroll = true;
            this.B6_splitContainer1.Panel2.Controls.Add(this.B6_Table);
            this.B6_splitContainer1.Size = new System.Drawing.Size(710, 543);
            this.B6_splitContainer1.SplitterDistance = 37;
            this.B6_splitContainer1.TabIndex = 5;
            // 
            // B6_Seconds
            // 
            this.B6_Seconds.Location = new System.Drawing.Point(279, 0);
            this.B6_Seconds.Name = "B6_Seconds";
            this.B6_Seconds.ReadOnly = true;
            this.B6_Seconds.Size = new System.Drawing.Size(99, 20);
            this.B6_Seconds.TabIndex = 4;
            // 
            // B6_Bytes
            // 
            this.B6_Bytes.Location = new System.Drawing.Point(58, 0);
            this.B6_Bytes.Name = "B6_Bytes";
            this.B6_Bytes.ReadOnly = true;
            this.B6_Bytes.Size = new System.Drawing.Size(99, 20);
            this.B6_Bytes.TabIndex = 2;
            // 
            // FLabel_Common
            // 
            this.FLabel_Common.AutoSize = true;
            this.FLabel_Common.Location = new System.Drawing.Point(78, 23);
            this.FLabel_Common.Name = "FLabel_Common";
            this.FLabel_Common.Size = new System.Drawing.Size(54, 13);
            this.FLabel_Common.TabIndex = 11;
            this.FLabel_Common.Text = "Common?";
            // 
            // FLabel_Enabled
            // 
            this.FLabel_Enabled.AutoSize = true;
            this.FLabel_Enabled.Location = new System.Drawing.Point(-1, 23);
            this.FLabel_Enabled.Name = "FLabel_Enabled";
            this.FLabel_Enabled.Size = new System.Drawing.Size(46, 13);
            this.FLabel_Enabled.TabIndex = 10;
            this.FLabel_Enabled.Text = "Enabled";
            // 
            // FLabel_RAW
            // 
            this.FLabel_RAW.AutoSize = true;
            this.FLabel_RAW.Location = new System.Drawing.Point(473, 23);
            this.FLabel_RAW.Name = "FLabel_RAW";
            this.FLabel_RAW.Size = new System.Drawing.Size(100, 13);
            this.FLabel_RAW.TabIndex = 9;
            this.FLabel_RAW.Text = "RAW ADPCM Data";
            // 
            // FLabel_Length
            // 
            this.FLabel_Length.AutoSize = true;
            this.FLabel_Length.Location = new System.Drawing.Point(376, 23);
            this.FLabel_Length.Name = "FLabel_Length";
            this.FLabel_Length.Size = new System.Drawing.Size(40, 13);
            this.FLabel_Length.TabIndex = 8;
            this.FLabel_Length.Text = "Length";
            // 
            // FLabel_Offset
            // 
            this.FLabel_Offset.AutoSize = true;
            this.FLabel_Offset.Location = new System.Drawing.Point(270, 23);
            this.FLabel_Offset.Name = "FLabel_Offset";
            this.FLabel_Offset.Size = new System.Drawing.Size(35, 13);
            this.FLabel_Offset.TabIndex = 7;
            this.FLabel_Offset.Text = "Offset";
            // 
            // FLabel_Depends
            // 
            this.FLabel_Depends.AutoSize = true;
            this.FLabel_Depends.Location = new System.Drawing.Point(153, 23);
            this.FLabel_Depends.Name = "FLabel_Depends";
            this.FLabel_Depends.Size = new System.Drawing.Size(67, 13);
            this.FLabel_Depends.TabIndex = 6;
            this.FLabel_Depends.Text = "Depends On";
            // 
            // FLabel_ID
            // 
            this.FLabel_ID.AutoSize = true;
            this.FLabel_ID.Location = new System.Drawing.Point(48, 23);
            this.FLabel_ID.Name = "FLabel_ID";
            this.FLabel_ID.Size = new System.Drawing.Size(18, 13);
            this.FLabel_ID.TabIndex = 5;
            this.FLabel_ID.Text = "ID";
            // 
            // FBytes_Label
            // 
            this.FBytes_Label.AutoSize = true;
            this.FBytes_Label.Location = new System.Drawing.Point(3, 3);
            this.FBytes_Label.Name = "FBytes_Label";
            this.FBytes_Label.Size = new System.Drawing.Size(54, 13);
            this.FBytes_Label.TabIndex = 1;
            this.FBytes_Label.Text = "Bytes free";
            // 
            // FSeconds_Label
            // 
            this.FSeconds_Label.AutoSize = true;
            this.FSeconds_Label.Location = new System.Drawing.Point(203, 0);
            this.FSeconds_Label.Name = "FSeconds_Label";
            this.FSeconds_Label.Size = new System.Drawing.Size(70, 13);
            this.FSeconds_Label.TabIndex = 3;
            this.FSeconds_Label.Text = "Seconds free";
            // 
            // B6_Table
            // 
            this.B6_Table.AutoSize = true;
            this.B6_Table.ColumnCount = 9;
            this.B6_Table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.B6_Table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.B6_Table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.B6_Table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.B6_Table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.B6_Table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.B6_Table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.B6_Table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.B6_Table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.B6_Table.Location = new System.Drawing.Point(0, 0);
            this.B6_Table.Name = "B6_Table";
            this.B6_Table.RowCount = 127;
            this.B6_Table.Size = new System.Drawing.Size(720, 2540);
            this.B6_Table.TabIndex = 2;
            for (int i = 0; i < 127; i++)
            {
                this.B6_Table.Controls.Add(B6_Play[i], 8, i);
                this.B6_Table.Controls.Add(B6_Import[i], 7, i);
                this.B6_Table.Controls.Add(B6_Export[i], 6, i);
                this.B6_Table.Controls.Add(B6_Length[i], 5, i);
                this.B6_Table.Controls.Add(B6_Offset[i], 4, i);
                this.B6_Table.Controls.Add(B6_Depends[i], 3, i);
                this.B6_Table.Controls.Add(B6_Common[i], 2, i);
                this.B6_Table.Controls.Add(B6_ID[i], 1, i);
                this.B6_Table.Controls.Add(B6_Enable[i], 0, i);
            }
            for (int i = 0; i < 127; i++)
            {
                this.B6_Table.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
                int index = i;

                B6_Play[i].Location = new System.Drawing.Point(600, (i * 20));
                B6_Play[i].Margin = new System.Windows.Forms.Padding(0);
                B6_Play[i].Size = new System.Drawing.Size(75, 20);
                B6_Play[i].TabIndex = 14;
                B6_Play[i].Text = "Play";
                B6_Play[i].Click += (sender, e) => playRAWfile(6, index);

                B6_Import[i].Location = new System.Drawing.Point(525, (i * 20));
                B6_Import[i].Margin = new System.Windows.Forms.Padding(0);
                B6_Import[i].Size = new System.Drawing.Size(75, 20);
                B6_Import[i].TabIndex = 14;
                B6_Import[i].Text = "Import";
                B6_Import[i].Click += (sender, e) => importRAWfile(6, index);

                B6_Export[i].Anchor = System.Windows.Forms.AnchorStyles.None;
                B6_Export[i].Location = new System.Drawing.Point(450, (i * 20));
                B6_Export[i].Margin = new System.Windows.Forms.Padding(0);
                B6_Export[i].Size = new System.Drawing.Size(75, 20);
                B6_Export[i].TabIndex = 13;
                B6_Export[i].Text = "Export";
                B6_Export[i].UseVisualStyleBackColor = true;
                B6_Export[i].Click += (sender, e) => exportRAWfile(6, index);

                B6_Length[i].Anchor = System.Windows.Forms.AnchorStyles.None;
                B6_Length[i].Location = new System.Drawing.Point(347, (i * 20));
                B6_Length[i].Margin = new System.Windows.Forms.Padding(0);
                B6_Length[i].Size = new System.Drawing.Size(100, 20);
                B6_Length[i].TabIndex = 12;
                B6_Length[i].Leave += (sender, e) => UpdateLength(6, index, B6_Length[index].Text);

                B6_Offset[i].Location = new System.Drawing.Point(241, (i * 20) + 3);
                B6_Offset[i].Size = new System.Drawing.Size(100, 20);
                B6_Offset[i].TabIndex = 11;
                B6_Offset[i].Leave += (sender, e) => UpdateOffset(6, index, B6_Offset[index].Text);

                B6_Depends[i].Location = new System.Drawing.Point(135, (i * 20) + 3);
                B6_Depends[i].Size = new System.Drawing.Size(100, 20);
                B6_Depends[i].TabIndex = 392;
                B6_Depends[i].Leave += (sender, e) => UpdateDepend(6, index, B6_Depends[index].Text);

                B6_ID[i].Location = new System.Drawing.Point(43, (i * 20));
                B6_ID[i].Size = new System.Drawing.Size(32, 20);
                B6_ID[i].TabIndex = 518;
                B6_ID[i].Text = i.ToString().PadLeft(3, '0');
                B6_ID[i].Enabled = false;
                B6_ID[i].Leave += (sender, e) => UpdateID(6, index, B6_ID[index].Text);

                B6_Enable[i].Location = new System.Drawing.Point(3, (i * 20) + 3);
                B6_Enable[i].Size = new System.Drawing.Size(15, 14);
                B6_Enable[i].TabIndex = 770;
                B6_Enable[i].Click += (sender, e) => UpdateEnable(6, index, B6_Enable[index].Checked);

                B6_Common[i].Anchor = System.Windows.Forms.AnchorStyles.None;
                B6_Common[i].AutoSize = true;
                B6_Common[i].Enabled = false;
                B6_Common[i].Location = new System.Drawing.Point(94, (i * 20) + 3);
                B6_Common[i].Size = new System.Drawing.Size(15, 14);
                B6_Common[i].TabIndex = 897;
                B6_Common[i].UseVisualStyleBackColor = true;

            }
            // 
            // Bank7
            // 
            this.Bank7.AutoScroll = true;
            this.Bank7.Controls.Add(this.B7_splitContainer1);
            this.Bank7.Location = new System.Drawing.Point(4, 22);
            this.Bank7.Name = "Bank7";
            this.Bank7.Padding = new System.Windows.Forms.Padding(3);
            this.Bank7.Size = new System.Drawing.Size(720, 657);
            this.Bank7.TabIndex = 6;
            this.Bank7.Text = "Bank 7";
            this.Bank7.UseVisualStyleBackColor = true;
            // 
            // B7_splitContainer1
            // 
            this.B7_splitContainer1.Location = new System.Drawing.Point(1, 3);
            this.B7_splitContainer1.Name = "B7_splitContainer1";
            this.B7_splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // B7_splitContainer1.Panel1
            // 
            this.B7_splitContainer1.Panel1.Controls.Add(this.Label_Common);
            this.B7_splitContainer1.Panel1.Controls.Add(this.Label_Enabled);
            this.B7_splitContainer1.Panel1.Controls.Add(this.Label_RAW);
            this.B7_splitContainer1.Panel1.Controls.Add(this.Label_Length);
            this.B7_splitContainer1.Panel1.Controls.Add(this.Label_Offset);
            this.B7_splitContainer1.Panel1.Controls.Add(this.Label_Depends);
            this.B7_splitContainer1.Panel1.Controls.Add(this.Label_ID);
            this.B7_splitContainer1.Panel1.Controls.Add(this.Bytes_Label);
            this.B7_splitContainer1.Panel1.Controls.Add(this.Seconds_Label);
            this.B7_splitContainer1.Panel1.Controls.Add(this.B7_Seconds);
            this.B7_splitContainer1.Panel1.Controls.Add(this.B7_Bytes);
            this.B7_splitContainer1.Panel1MinSize = 5;
            // 
            // B7_splitContainer1.Panel2
            // 
            this.B7_splitContainer1.Panel2.AutoScroll = true;
            this.B7_splitContainer1.Panel2.Controls.Add(this.B7_Table);
            this.B7_splitContainer1.Size = new System.Drawing.Size(710, 543);
            this.B7_splitContainer1.SplitterDistance = 37;
            this.B7_splitContainer1.TabIndex = 5;
            // 
            // Label_Common
            // 
            this.Label_Common.AutoSize = true;
            this.Label_Common.Location = new System.Drawing.Point(78, 23);
            this.Label_Common.Name = "Label_Common";
            this.Label_Common.Size = new System.Drawing.Size(54, 13);
            this.Label_Common.TabIndex = 11;
            this.Label_Common.Text = "Common?";
            // 
            // Label_Enabled
            // 
            this.Label_Enabled.AutoSize = true;
            this.Label_Enabled.Location = new System.Drawing.Point(-1, 23);
            this.Label_Enabled.Name = "Label_Enabled";
            this.Label_Enabled.Size = new System.Drawing.Size(46, 13);
            this.Label_Enabled.TabIndex = 10;
            this.Label_Enabled.Text = "Enabled";
            // 
            // Label_RAW
            // 
            this.Label_RAW.AutoSize = true;
            this.Label_RAW.Location = new System.Drawing.Point(473, 23);
            this.Label_RAW.Name = "Label_RAW";
            this.Label_RAW.Size = new System.Drawing.Size(100, 13);
            this.Label_RAW.TabIndex = 9;
            this.Label_RAW.Text = "RAW ADPCM Data";
            // 
            // Label_Length
            // 
            this.Label_Length.AutoSize = true;
            this.Label_Length.Location = new System.Drawing.Point(376, 23);
            this.Label_Length.Name = "Label_Length";
            this.Label_Length.Size = new System.Drawing.Size(40, 13);
            this.Label_Length.TabIndex = 8;
            this.Label_Length.Text = "Length";
            // 
            // Label_Offset
            // 
            this.Label_Offset.AutoSize = true;
            this.Label_Offset.Location = new System.Drawing.Point(270, 23);
            this.Label_Offset.Name = "Label_Offset";
            this.Label_Offset.Size = new System.Drawing.Size(35, 13);
            this.Label_Offset.TabIndex = 7;
            this.Label_Offset.Text = "Offset";
            // 
            // Label_Depends
            // 
            this.Label_Depends.AutoSize = true;
            this.Label_Depends.Location = new System.Drawing.Point(153, 23);
            this.Label_Depends.Name = "Label_Depends";
            this.Label_Depends.Size = new System.Drawing.Size(67, 13);
            this.Label_Depends.TabIndex = 6;
            this.Label_Depends.Text = "Depends On";
            // 
            // Label_ID
            // 
            this.Label_ID.AutoSize = true;
            this.Label_ID.Location = new System.Drawing.Point(48, 23);
            this.Label_ID.Name = "Label_ID";
            this.Label_ID.Size = new System.Drawing.Size(18, 13);
            this.Label_ID.TabIndex = 5;
            this.Label_ID.Text = "ID";
            // 
            // Bytes_Label
            // 
            this.Bytes_Label.AutoSize = true;
            this.Bytes_Label.Location = new System.Drawing.Point(3, 3);
            this.Bytes_Label.Name = "Bytes_Label";
            this.Bytes_Label.Size = new System.Drawing.Size(54, 13);
            this.Bytes_Label.TabIndex = 1;
            this.Bytes_Label.Text = "Bytes free";
            // 
            // Seconds_Label
            // 
            this.Seconds_Label.AutoSize = true;
            this.Seconds_Label.Location = new System.Drawing.Point(203, 0);
            this.Seconds_Label.Name = "Seconds_Label";
            this.Seconds_Label.Size = new System.Drawing.Size(70, 13);
            this.Seconds_Label.TabIndex = 3;
            this.Seconds_Label.Text = "Seconds free";
            // 
            // B7_Seconds
            // 
            this.B7_Seconds.Location = new System.Drawing.Point(279, 0);
            this.B7_Seconds.Name = "B7_Seconds";
            this.B7_Seconds.ReadOnly = true;
            this.B7_Seconds.Size = new System.Drawing.Size(99, 20);
            this.B7_Seconds.TabIndex = 4;
            // 
            // B7_Bytes
            // 
            this.B7_Bytes.Location = new System.Drawing.Point(58, 0);
            this.B7_Bytes.Name = "B7_Bytes";
            this.B7_Bytes.ReadOnly = true;
            this.B7_Bytes.Size = new System.Drawing.Size(99, 20);
            this.B7_Bytes.TabIndex = 2;
            // 
            // B7_Table
            // 
            this.B7_Table.AutoSize = true;
            this.B7_Table.ColumnCount = 9;
            this.B7_Table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.B7_Table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.B7_Table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.B7_Table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.B7_Table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.B7_Table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.B7_Table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.B7_Table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.B7_Table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.B7_Table.Location = new System.Drawing.Point(0, 0);
            this.B7_Table.Name = "B7_Table";
            this.B7_Table.RowCount = 127;
            this.B7_Table.Size = new System.Drawing.Size(720, 2540);
            this.B7_Table.TabIndex = 2;
            for (int i = 0; i < 127; i++)
            {
                this.B7_Table.Controls.Add(B7_Play[i], 8, i);
                this.B7_Table.Controls.Add(B7_Import[i], 7, i);
                this.B7_Table.Controls.Add(B7_Export[i], 6, i);
                this.B7_Table.Controls.Add(B7_Length[i], 5, i);
                this.B7_Table.Controls.Add(B7_Offset[i], 4, i);
                this.B7_Table.Controls.Add(B7_Depends[i], 3, i);
                this.B7_Table.Controls.Add(B7_Common[i], 2, i);
                this.B7_Table.Controls.Add(B7_ID[i], 1, i);
                this.B7_Table.Controls.Add(B7_Enable[i], 0, i);
            }
            for (int i = 0; i < 127; i++)
            {
                this.B7_Table.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
                int index = i;

                B7_Play[i].Location = new System.Drawing.Point(600, (i * 20));
                B7_Play[i].Margin = new System.Windows.Forms.Padding(0);
                B7_Play[i].Size = new System.Drawing.Size(75, 20);
                B7_Play[i].TabIndex = 14;
                B7_Play[i].Text = "Play";
                B7_Play[i].Click += (sender, e) => playRAWfile(7, index);

                B7_Import[i].Location = new System.Drawing.Point(525, (i * 20));
                B7_Import[i].Margin = new System.Windows.Forms.Padding(0);
                B7_Import[i].Size = new System.Drawing.Size(75, 20);
                B7_Import[i].TabIndex = 14;
                B7_Import[i].Text = "Import";
                B7_Import[i].Click += (sender, e) => importRAWfile(6, index);

                B7_Export[i].Anchor = System.Windows.Forms.AnchorStyles.None;
                B7_Export[i].Location = new System.Drawing.Point(450, (i * 20));
                B7_Export[i].Margin = new System.Windows.Forms.Padding(0);
                B7_Export[i].Size = new System.Drawing.Size(75, 20);
                B7_Export[i].TabIndex = 13;
                B7_Export[i].Text = "Export";
                B7_Export[i].UseVisualStyleBackColor = true;
                B7_Export[i].Click += (sender, e) => exportRAWfile(7, index);

                B7_Length[i].Anchor = System.Windows.Forms.AnchorStyles.None;
                B7_Length[i].Location = new System.Drawing.Point(347, (i * 20));
                B7_Length[i].Margin = new System.Windows.Forms.Padding(0);
                B7_Length[i].Size = new System.Drawing.Size(100, 20);
                B7_Length[i].TabIndex = 12;
                B7_Length[i].Leave += (sender, e) => UpdateLength(7, index, B7_Length[index].Text);

                B7_Offset[i].Location = new System.Drawing.Point(241, (i * 20) + 3);
                B7_Offset[i].Size = new System.Drawing.Size(100, 20);
                B7_Offset[i].TabIndex = 11;
                B7_Offset[i].Leave += (sender, e) => UpdateOffset(7, index, B7_Offset[index].Text);

                B7_Depends[i].Location = new System.Drawing.Point(135, (i * 20) + 3);
                B7_Depends[i].Size = new System.Drawing.Size(100, 20);
                B7_Depends[i].TabIndex = 392;
                B7_Depends[i].Leave += (sender, e) => UpdateDepend(7, index, B7_Depends[index].Text);

                B7_ID[i].Location = new System.Drawing.Point(43, (i * 20));
                B7_ID[i].Size = new System.Drawing.Size(32, 20);
                B7_ID[i].TabIndex = 518;
                B7_ID[i].Text = i.ToString().PadLeft(3, '0');
                B7_ID[i].Enabled = false;
                B7_ID[i].Leave += (sender, e) => UpdateID(7, index, B7_ID[index].Text);

                B7_Enable[i].Location = new System.Drawing.Point(3, (i * 20) + 3);
                B7_Enable[i].Size = new System.Drawing.Size(15, 14);
                B7_Enable[i].TabIndex = 770;
                B7_Enable[i].Click += (sender, e) => UpdateEnable(7, index, B7_Enable[index].Checked);

                B7_Common[i].Anchor = System.Windows.Forms.AnchorStyles.None;
                B7_Common[i].AutoSize = true;
                B7_Common[i].Enabled = false;
                B7_Common[i].Location = new System.Drawing.Point(94, (i * 20) + 3);
                B7_Common[i].Size = new System.Drawing.Size(15, 14);
                B7_Common[i].TabIndex = 897;
                B7_Common[i].UseVisualStyleBackColor = true;

            }


            // 
            // BankCOM
            // 
            this.BankCOM.AutoScroll = true;
            this.BankCOM.Controls.Add(this.BCOM_splitContainer1);
            this.BankCOM.Location = new System.Drawing.Point(4, 22);
            this.BankCOM.Padding = new System.Windows.Forms.Padding(3);
            this.BankCOM.Size = new System.Drawing.Size(720, 657);
            this.BankCOM.TabIndex = 6;
            this.BankCOM.Text = "Common";
            this.BankCOM.UseVisualStyleBackColor = true;
            // 
            // BCOM_splitContainer1
            // 
            this.BCOM_splitContainer1.Location = new System.Drawing.Point(1, 3);
            this.BCOM_splitContainer1.Name = "BCOM_splitContainer1";
            this.BCOM_splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // BCOM_splitContainer1.Panel1
            // 
            this.BCOM_splitContainer1.Panel1.Controls.Add(this.COMLabel_Common);
            this.BCOM_splitContainer1.Panel1.Controls.Add(this.COMLabel_Enabled);
            this.BCOM_splitContainer1.Panel1.Controls.Add(this.COMLabel_RAW);
            this.BCOM_splitContainer1.Panel1.Controls.Add(this.COMLabel_Length);
            this.BCOM_splitContainer1.Panel1.Controls.Add(this.COMLabel_Offset);
            this.BCOM_splitContainer1.Panel1.Controls.Add(this.COMLabel_Depends);
            this.BCOM_splitContainer1.Panel1.Controls.Add(this.COMLabel_ID);
            this.BCOM_splitContainer1.Panel1.Controls.Add(this.COMBytes_Label);
            this.BCOM_splitContainer1.Panel1.Controls.Add(this.COMSeconds_Label);
            this.BCOM_splitContainer1.Panel1.Controls.Add(this.BCOM_Seconds);
            this.BCOM_splitContainer1.Panel1.Controls.Add(this.BCOM_Bytes);
            this.BCOM_splitContainer1.Panel1MinSize = 5;
            // 
            // BCOM_splitContainer1.Panel2
            // 
            this.BCOM_splitContainer1.Panel2.AutoScroll = true;
            this.BCOM_splitContainer1.Panel2.Controls.Add(this.BCOM_Table);
            this.BCOM_splitContainer1.Size = new System.Drawing.Size(710, 543);
            this.BCOM_splitContainer1.SplitterDistance = 37;
            this.BCOM_splitContainer1.TabIndex = 5;
            // 
            // Label_Common
            // 
            this.COMLabel_Common.AutoSize = true;
            this.COMLabel_Common.Location = new System.Drawing.Point(78, 23);
            this.COMLabel_Common.Name = "Label_Common";
            this.COMLabel_Common.Size = new System.Drawing.Size(54, 13);
            this.COMLabel_Common.TabIndex = 11;
            this.COMLabel_Common.Text = "";
            // 
            // Label_Enabled
            // 
            this.COMLabel_Enabled.AutoSize = true;
            this.COMLabel_Enabled.Location = new System.Drawing.Point(-1, 23);
            this.COMLabel_Enabled.Name = "Label_Enabled";
            this.COMLabel_Enabled.Size = new System.Drawing.Size(46, 13);
            this.COMLabel_Enabled.TabIndex = 10;
            this.COMLabel_Enabled.Text = "Enabled";
            // 
            // Label_RAW
            // 
            this.COMLabel_RAW.AutoSize = true;
            this.COMLabel_RAW.Location = new System.Drawing.Point(473, 23);
            this.COMLabel_RAW.Name = "Label_RAW";
            this.COMLabel_RAW.Size = new System.Drawing.Size(100, 13);
            this.COMLabel_RAW.TabIndex = 9;
            this.COMLabel_RAW.Text = "RAW ADPCM Data";
            // 
            // Label_Length
            // 
            this.COMLabel_Length.AutoSize = true;
            this.COMLabel_Length.Location = new System.Drawing.Point(376, 23);
            this.COMLabel_Length.Name = "Label_Length";
            this.COMLabel_Length.Size = new System.Drawing.Size(40, 13);
            this.COMLabel_Length.TabIndex = 8;
            this.COMLabel_Length.Text = "Length";
            // 
            // Label_Offset
            // 
            this.COMLabel_Offset.AutoSize = true;
            this.COMLabel_Offset.Location = new System.Drawing.Point(270, 23);
            this.COMLabel_Offset.Name = "Label_Offset";
            this.COMLabel_Offset.Size = new System.Drawing.Size(35, 13);
            this.COMLabel_Offset.TabIndex = 7;
            this.COMLabel_Offset.Text = "Offset";
            // 
            // Label_Depends
            // 
            this.COMLabel_Depends.AutoSize = true;
            this.COMLabel_Depends.Location = new System.Drawing.Point(153, 23);
            this.COMLabel_Depends.Name = "Label_Depends";
            this.COMLabel_Depends.Size = new System.Drawing.Size(67, 13);
            this.COMLabel_Depends.TabIndex = 6;
            this.COMLabel_Depends.Text = "Depends On";
            // 
            // Label_ID
            // 
            this.COMLabel_ID.AutoSize = true;
            this.COMLabel_ID.Location = new System.Drawing.Point(48, 23);
            this.COMLabel_ID.Name = "Label_ID";
            this.COMLabel_ID.Size = new System.Drawing.Size(18, 13);
            this.COMLabel_ID.TabIndex = 5;
            this.COMLabel_ID.Text = "ID";
            // 
            // Bytes_Label
            // 
            this.COMBytes_Label.AutoSize = true;
            this.COMBytes_Label.Location = new System.Drawing.Point(3, 3);
            this.COMBytes_Label.Name = "Bytes_Label";
            this.COMBytes_Label.Size = new System.Drawing.Size(54, 13);
            this.COMBytes_Label.TabIndex = 1;
            this.COMBytes_Label.Text = "Bytes free";
            // 
            // Seconds_Label
            // 
            this.COMSeconds_Label.AutoSize = true;
            this.COMSeconds_Label.Location = new System.Drawing.Point(203, 0);
            this.COMSeconds_Label.Name = "Seconds_Label";
            this.COMSeconds_Label.Size = new System.Drawing.Size(70, 13);
            this.COMSeconds_Label.TabIndex = 3;
            this.COMSeconds_Label.Text = "Seconds free";
            // 
            // BCOM_Seconds
            // 
            this.BCOM_Seconds.Location = new System.Drawing.Point(279, 0);
            this.BCOM_Seconds.Name = "BCOM_Seconds";
            this.BCOM_Seconds.ReadOnly = true;
            this.BCOM_Seconds.Size = new System.Drawing.Size(99, 20);
            this.BCOM_Seconds.TabIndex = 4;
            // 
            // BCOM_Bytes
            // 
            this.BCOM_Bytes.Location = new System.Drawing.Point(58, 0);
            this.BCOM_Bytes.Name = "BCOM_Bytes";
            this.BCOM_Bytes.ReadOnly = true;
            this.BCOM_Bytes.Size = new System.Drawing.Size(99, 20);
            this.BCOM_Bytes.TabIndex = 2;
            // 
            // BCOM_Table
            // 
            this.BCOM_Table.AutoSize = true;
            this.BCOM_Table.ColumnCount = 9;
            this.BCOM_Table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.BCOM_Table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.BCOM_Table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.BCOM_Table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.BCOM_Table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.BCOM_Table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.BCOM_Table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.BCOM_Table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.BCOM_Table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.BCOM_Table.Location = new System.Drawing.Point(0, 0);
            this.BCOM_Table.Name = "BCOM_Table";
            this.BCOM_Table.RowCount = 127;
            this.BCOM_Table.Size = new System.Drawing.Size(720, 2540);
            this.BCOM_Table.TabIndex = 2;
            for (int i = 0; i < 127; i++)
            {
                this.BCOM_Table.Controls.Add(BCOM_Play[i], 8, i);
                this.BCOM_Table.Controls.Add(BCOM_Import[i], 7, i);
                this.BCOM_Table.Controls.Add(BCOM_Export[i], 6, i);
                this.BCOM_Table.Controls.Add(BCOM_Length[i], 5, i);
                this.BCOM_Table.Controls.Add(BCOM_Offset[i], 4, i);
                this.BCOM_Table.Controls.Add(BCOM_Depends[i], 3, i);
                this.BCOM_Table.Controls.Add(BCOM_ID[i], 1, i);
                this.BCOM_Table.Controls.Add(BCOM_Enable[i], 0, i);
            }
            for (int i = 0; i < 127; i++)
            {
                this.BCOM_Table.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
                int index = i;

                BCOM_Play[i].Location = new System.Drawing.Point(600, (i * 20));
                BCOM_Play[i].Margin = new System.Windows.Forms.Padding(0);
                BCOM_Play[i].Size = new System.Drawing.Size(75, 20);
                BCOM_Play[i].TabIndex = 14;
                BCOM_Play[i].Text = "Play";
                BCOM_Play[i].Click += (sender, e) => playRAWfile(8, index);

                BCOM_Import[i].Location = new System.Drawing.Point(525, (i * 20));
                BCOM_Import[i].Margin = new System.Windows.Forms.Padding(0);
                BCOM_Import[i].Size = new System.Drawing.Size(75, 20);
                BCOM_Import[i].TabIndex = 14;
                BCOM_Import[i].Text = "Import";
                BCOM_Import[i].Click += (sender, e) => importRAWfile(8, index);

                BCOM_Export[i].Anchor = System.Windows.Forms.AnchorStyles.None;
                BCOM_Export[i].Location = new System.Drawing.Point(450, (i * 20));
                BCOM_Export[i].Margin = new System.Windows.Forms.Padding(0);
                BCOM_Export[i].Size = new System.Drawing.Size(75, 20);
                BCOM_Export[i].TabIndex = 13;
                BCOM_Export[i].Text = "Export";
                BCOM_Export[i].UseVisualStyleBackColor = true;
                BCOM_Export[i].Click += (sender, e) => exportRAWfile(8, index);

                BCOM_Length[i].Anchor = System.Windows.Forms.AnchorStyles.None;
                BCOM_Length[i].Location = new System.Drawing.Point(347, (i * 20));
                BCOM_Length[i].Margin = new System.Windows.Forms.Padding(0);
                BCOM_Length[i].Size = new System.Drawing.Size(100, 20);
                BCOM_Length[i].TabIndex = 12;
                BCOM_Length[i].Leave += (sender, e) => UpdateLength(8, index, BCOM_Length[index].Text);

                BCOM_Offset[i].Location = new System.Drawing.Point(241, (i * 20) + 3);
                BCOM_Offset[i].Size = new System.Drawing.Size(100, 20);
                BCOM_Offset[i].TabIndex = 11;
                BCOM_Offset[i].Leave += (sender, e) => UpdateOffset(8, index, BCOM_Offset[index].Text);

                BCOM_Depends[i].Location = new System.Drawing.Point(135, (i * 20) + 3);
                BCOM_Depends[i].Size = new System.Drawing.Size(100, 20);
                BCOM_Depends[i].TabIndex = 392;
                BCOM_Depends[i].Leave += (sender, e) => UpdateDepend(8, index, BCOM_Depends[index].Text);

                BCOM_ID[i].Location = new System.Drawing.Point(43, (i * 20));
                BCOM_ID[i].Size = new System.Drawing.Size(32, 20);
                BCOM_ID[i].TabIndex = 518;
                BCOM_ID[i].Text = "C"+ (i.ToString().PadLeft(3, '0'));
                BCOM_ID[i].Enabled = false;

                BCOM_Enable[i].Location = new System.Drawing.Point(3, (i * 20) + 3);
                BCOM_Enable[i].Size = new System.Drawing.Size(15, 14);
                BCOM_Enable[i].TabIndex = 770;
                BCOM_Enable[i].Click += (sender, e) => UpdateEnable(8, index, BCOM_Enable[index].Checked);

                BCOM_Common[i].Anchor = System.Windows.Forms.AnchorStyles.None;
                BCOM_Common[i].AutoSize = true;
                BCOM_Common[i].Enabled = false;
                BCOM_Common[i].Location = new System.Drawing.Point(94, (i * 20) + 3);
                BCOM_Common[i].Size = new System.Drawing.Size(15, 14);
                BCOM_Common[i].TabIndex = 897;
                BCOM_Common[i].UseVisualStyleBackColor = true;

            }


            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(165, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Sample Rate (for time calculation)";
            // 
            // samprate
            // 
            this.samprate.Location = new System.Drawing.Point(174, 27);
            this.samprate.Name = "samprate";
            this.samprate.Size = new System.Drawing.Size(96, 20);
            this.samprate.TabIndex = 3;
            this.samprate.Text = "7575.75";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(538, 25);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(109, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Export ROMs";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.GenerateROMs);
            // 
            // MainDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(720, 741);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.samprate);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainDialog";
            this.Text = "Williams ADPCM Editor";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.Bank0_1.ResumeLayout(false);
            this.B0_splitContainer1.Panel1.ResumeLayout(false);
            this.B0_splitContainer1.Panel1.PerformLayout();
            this.B0_splitContainer1.Panel2.ResumeLayout(false);
            this.B0_splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.B0_splitContainer1)).EndInit();
            this.B0_splitContainer1.ResumeLayout(false);
            this.B0_Table.ResumeLayout(false);
            this.B0_Table.PerformLayout();
            this.Bank2.ResumeLayout(false);
            this.B2_splitContainer1.Panel1.ResumeLayout(false);
            this.B2_splitContainer1.Panel1.PerformLayout();
            this.B2_splitContainer1.Panel2.ResumeLayout(false);
            this.B2_splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.B2_splitContainer1)).EndInit();
            this.B2_splitContainer1.ResumeLayout(false);
            this.B2_Table.ResumeLayout(false);
            this.B2_Table.PerformLayout();
            this.Bank3.ResumeLayout(false);
            this.B3_splitContainer1.Panel1.ResumeLayout(false);
            this.B3_splitContainer1.Panel1.PerformLayout();
            this.B3_splitContainer1.Panel2.ResumeLayout(false);
            this.B3_splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.B3_splitContainer1)).EndInit();
            this.B3_splitContainer1.ResumeLayout(false);
            this.B3_Table.ResumeLayout(false);
            this.B3_Table.PerformLayout();
            this.Bank4.ResumeLayout(false);
            this.B4_splitContainer1.Panel1.ResumeLayout(false);
            this.B4_splitContainer1.Panel1.PerformLayout();
            this.B4_splitContainer1.Panel2.ResumeLayout(false);
            this.B4_splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.B4_splitContainer1)).EndInit();
            this.B4_splitContainer1.ResumeLayout(false);
            this.B4_Table.ResumeLayout(false);
            this.B4_Table.PerformLayout();
            this.Bank5.ResumeLayout(false);
            this.B5_splitContainer1.Panel1.ResumeLayout(false);
            this.B5_splitContainer1.Panel1.PerformLayout();
            this.B5_splitContainer1.Panel2.ResumeLayout(false);
            this.B5_splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.B5_splitContainer1)).EndInit();
            this.B5_splitContainer1.ResumeLayout(false);
            this.B5_Table.ResumeLayout(false);
            this.B5_Table.PerformLayout();
            this.Bank6.ResumeLayout(false);
            this.B6_splitContainer1.Panel1.ResumeLayout(false);
            this.B6_splitContainer1.Panel1.PerformLayout();
            this.B6_splitContainer1.Panel2.ResumeLayout(false);
            this.B6_splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.B6_splitContainer1)).EndInit();
            this.B6_splitContainer1.ResumeLayout(false);
            this.B6_Table.ResumeLayout(false);
            this.B6_Table.PerformLayout();
            this.Bank7.ResumeLayout(false);
            this.B7_splitContainer1.Panel1.ResumeLayout(false);
            this.B7_splitContainer1.Panel1.PerformLayout();
            this.B7_splitContainer1.Panel2.ResumeLayout(false);
            this.B7_splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.B7_splitContainer1)).EndInit();
            this.B7_splitContainer1.ResumeLayout(false);
            this.B7_Table.ResumeLayout(false);
            this.B7_Table.PerformLayout();
            this.BankCOM.ResumeLayout(false);
            this.BCOM_splitContainer1.Panel1.ResumeLayout(false);
            this.BCOM_splitContainer1.Panel1.PerformLayout();
            this.BCOM_splitContainer1.Panel2.ResumeLayout(false);
            this.BCOM_splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BCOM_splitContainer1)).EndInit();
            this.BCOM_splitContainer1.ResumeLayout(false);
            this.BCOM_Table.ResumeLayout(false);
            this.BCOM_Table.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private NotifyIcon trayIcon;

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileLoadingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage Bank0_1;
        private System.Windows.Forms.TextBox B0_Seconds;
        private System.Windows.Forms.TextBox B0_Bytes;
        private System.Windows.Forms.TextBox B2_Seconds;
        private System.Windows.Forms.TextBox B2_Bytes;
        private System.Windows.Forms.TextBox B3_Seconds;
        private System.Windows.Forms.TextBox B3_Bytes;
        private System.Windows.Forms.TextBox B4_Seconds;
        private System.Windows.Forms.TextBox B4_Bytes;
        private System.Windows.Forms.TextBox B5_Seconds;
        private System.Windows.Forms.TextBox B5_Bytes;
        private System.Windows.Forms.TextBox B6_Seconds;
        private System.Windows.Forms.TextBox B6_Bytes;
        private System.Windows.Forms.TextBox B7_Seconds;
        private System.Windows.Forms.TextBox B7_Bytes;
        private System.Windows.Forms.TextBox BCOM_Seconds;
        private System.Windows.Forms.TextBox BCOM_Bytes;
        private System.Windows.Forms.TabPage Bank2;
        private System.Windows.Forms.TabPage Bank3;
        private System.Windows.Forms.TabPage Bank4;
        private System.Windows.Forms.TabPage Bank5;
        private System.Windows.Forms.TabPage Bank6;
        private System.Windows.Forms.TabPage Bank7;
        private System.Windows.Forms.TabPage BankCOM;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox samprate;
        private System.Windows.Forms.SplitContainer B0_splitContainer1;
        private System.Windows.Forms.SplitContainer B2_splitContainer1;
        private System.Windows.Forms.SplitContainer B3_splitContainer1;
        private System.Windows.Forms.SplitContainer B4_splitContainer1;
        private System.Windows.Forms.SplitContainer B5_splitContainer1;
        private System.Windows.Forms.SplitContainer B6_splitContainer1;
        private System.Windows.Forms.SplitContainer B7_splitContainer1;
        private System.Windows.Forms.SplitContainer BCOM_splitContainer1;
        private System.Windows.Forms.Label Label_Enabled;
        private System.Windows.Forms.Label Seconds_Label;
        private System.Windows.Forms.Label Bytes_Label;
        private System.Windows.Forms.Label Label_RAW;
        private System.Windows.Forms.Label Label_Length;
        private System.Windows.Forms.Label Label_Offset;
        private System.Windows.Forms.Label Label_Depends;
        private System.Windows.Forms.Label Label_ID;
        private System.Windows.Forms.Label Label_Common;
        private System.Windows.Forms.Label ALabel_Enabled;
        private System.Windows.Forms.Label ASeconds_Label;
        private System.Windows.Forms.Label ABytes_Label;
        private System.Windows.Forms.Label ALabel_RAW;
        private System.Windows.Forms.Label ALabel_Length;
        private System.Windows.Forms.Label ALabel_Offset;
        private System.Windows.Forms.Label ALabel_Depends;
        private System.Windows.Forms.Label ALabel_ID;
        private System.Windows.Forms.Label ALabel_Common;
        private System.Windows.Forms.Label BLabel_Enabled;
        private System.Windows.Forms.Label BSeconds_Label;
        private System.Windows.Forms.Label BBytes_Label;
        private System.Windows.Forms.Label BLabel_RAW;
        private System.Windows.Forms.Label BLabel_Length;
        private System.Windows.Forms.Label BLabel_Offset;
        private System.Windows.Forms.Label BLabel_Depends;
        private System.Windows.Forms.Label BLabel_ID;
        private System.Windows.Forms.Label BLabel_Common;
        private System.Windows.Forms.Label CLabel_Enabled;
        private System.Windows.Forms.Label CSeconds_Label;
        private System.Windows.Forms.Label CBytes_Label;
        private System.Windows.Forms.Label CLabel_RAW;
        private System.Windows.Forms.Label CLabel_Length;
        private System.Windows.Forms.Label CLabel_Offset;
        private System.Windows.Forms.Label CLabel_Depends;
        private System.Windows.Forms.Label CLabel_ID;
        private System.Windows.Forms.Label CLabel_Common;
        private System.Windows.Forms.Label DLabel_Enabled;
        private System.Windows.Forms.Label DSeconds_Label;
        private System.Windows.Forms.Label DBytes_Label;
        private System.Windows.Forms.Label DLabel_RAW;
        private System.Windows.Forms.Label DLabel_Length;
        private System.Windows.Forms.Label DLabel_Offset;
        private System.Windows.Forms.Label DLabel_Depends;
        private System.Windows.Forms.Label DLabel_ID;
        private System.Windows.Forms.Label DLabel_Common;
        private System.Windows.Forms.Label ELabel_Enabled;
        private System.Windows.Forms.Label ESeconds_Label;
        private System.Windows.Forms.Label EBytes_Label;
        private System.Windows.Forms.Label ELabel_RAW;
        private System.Windows.Forms.Label ELabel_Length;
        private System.Windows.Forms.Label ELabel_Offset;
        private System.Windows.Forms.Label ELabel_Depends;
        private System.Windows.Forms.Label ELabel_ID;
        private System.Windows.Forms.Label ELabel_Common;
        private System.Windows.Forms.Label FLabel_Enabled;
        private System.Windows.Forms.Label FSeconds_Label;
        private System.Windows.Forms.Label FBytes_Label;
        private System.Windows.Forms.Label FLabel_RAW;
        private System.Windows.Forms.Label FLabel_Length;
        private System.Windows.Forms.Label FLabel_Offset;
        private System.Windows.Forms.Label FLabel_Depends;
        private System.Windows.Forms.Label FLabel_ID;
        private System.Windows.Forms.Label FLabel_Common;
        private System.Windows.Forms.Label COMLabel_Enabled;
        private System.Windows.Forms.Label COMSeconds_Label;
        private System.Windows.Forms.Label COMBytes_Label;
        private System.Windows.Forms.Label COMLabel_RAW;
        private System.Windows.Forms.Label COMLabel_Length;
        private System.Windows.Forms.Label COMLabel_Offset;
        private System.Windows.Forms.Label COMLabel_Depends;
        private System.Windows.Forms.Label COMLabel_ID;
        private System.Windows.Forms.Label COMLabel_Common;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TableLayoutPanel B0_Table;
        private System.Windows.Forms.TableLayoutPanel B2_Table;
        private System.Windows.Forms.TableLayoutPanel B3_Table;
        private System.Windows.Forms.TableLayoutPanel B4_Table;
        private System.Windows.Forms.TableLayoutPanel B5_Table;
        private System.Windows.Forms.TableLayoutPanel B6_Table;
        private System.Windows.Forms.TableLayoutPanel B7_Table;
        private System.Windows.Forms.TableLayoutPanel BCOM_Table;
    }
}

