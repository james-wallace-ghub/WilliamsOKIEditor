namespace OKI_Editor
{
    partial class ROMLoader
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.U12List = new System.Windows.Forms.TreeView();
            this.U12Clear = new System.Windows.Forms.Button();
            this.U12Add = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.U13List = new System.Windows.Forms.TreeView();
            this.button1 = new System.Windows.Forms.Button();
            this.U13Clear = new System.Windows.Forms.Button();
            this.U13Add = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.U12List);
            this.splitContainer1.Panel1.Controls.Add(this.U12Clear);
            this.splitContainer1.Panel1.Controls.Add(this.U12Add);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.U13List);
            this.splitContainer1.Panel2.Controls.Add(this.button1);
            this.splitContainer1.Panel2.Controls.Add(this.U13Clear);
            this.splitContainer1.Panel2.Controls.Add(this.U13Add);
            this.splitContainer1.Panel2.Controls.Add(this.label2);
            this.splitContainer1.Size = new System.Drawing.Size(365, 295);
            this.splitContainer1.SplitterDistance = 119;
            this.splitContainer1.TabIndex = 0;
            // 
            // U12List
            // 
            this.U12List.Location = new System.Drawing.Point(5, 17);
            this.U12List.Name = "U12List";
            this.U12List.Size = new System.Drawing.Size(359, 81);
            this.U12List.TabIndex = 5;
            // 
            // U12Clear
            // 
            this.U12Clear.Location = new System.Drawing.Point(0, 98);
            this.U12Clear.Name = "U12Clear";
            this.U12Clear.Size = new System.Drawing.Size(66, 21);
            this.U12Clear.TabIndex = 4;
            this.U12Clear.Text = "Clear";
            this.U12Clear.UseVisualStyleBackColor = true;
            this.U12Clear.Click += new System.EventHandler(this.U12ClearClick);
            // 
            // U12Add
            // 
            this.U12Add.Location = new System.Drawing.Point(298, 98);
            this.U12Add.Name = "U12Add";
            this.U12Add.Size = new System.Drawing.Size(66, 21);
            this.U12Add.TabIndex = 1;
            this.U12Add.Text = "Add";
            this.U12Add.UseVisualStyleBackColor = true;
            this.U12Add.Click += new System.EventHandler(this.U12AddClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "U12";
            // 
            // U13List
            // 
            this.U13List.Location = new System.Drawing.Point(2, 16);
            this.U13List.Name = "U13List";
            this.U13List.Size = new System.Drawing.Size(362, 99);
            this.U13List.TabIndex = 5;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(140, 149);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(82, 20);
            this.button1.TabIndex = 4;
            this.button1.Text = "Import";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.DoImport);
            // 
            // U13Clear
            // 
            this.U13Clear.Location = new System.Drawing.Point(0, 115);
            this.U13Clear.Name = "U13Clear";
            this.U13Clear.Size = new System.Drawing.Size(66, 21);
            this.U13Clear.TabIndex = 3;
            this.U13Clear.Text = "Clear";
            this.U13Clear.UseVisualStyleBackColor = true;
            this.U13Clear.Click += new System.EventHandler(this.U13ClearClick);
            // 
            // U13Add
            // 
            this.U13Add.Location = new System.Drawing.Point(299, 115);
            this.U13Add.Name = "U13Add";
            this.U13Add.Size = new System.Drawing.Size(66, 21);
            this.U13Add.TabIndex = 2;
            this.U13Add.Text = "Add";
            this.U13Add.UseVisualStyleBackColor = true;
            this.U13Add.Click += new System.EventHandler(this.U13Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "U13";
            // 
            // ROMLoader
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(365, 295);
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "ROMLoader";
            this.Text = "Rom Loader";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        public System.Windows.Forms.TreeView U12List;
        private System.Windows.Forms.Button U12Clear;
        private System.Windows.Forms.Button U12Add;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TreeView U13List;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button U13Clear;
        private System.Windows.Forms.Button U13Add;
        private System.Windows.Forms.Label label2;
    }
}