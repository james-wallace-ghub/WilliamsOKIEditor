using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OKI_Editor
{
    public partial class ROMLoader : Form
    {
        public ROMLoader()
        {
            InitializeComponent();
        }

        private void U12AddClick(object sender, EventArgs e)
        {
            OpenFileDialog OF = new OpenFileDialog
            {
                Title = "Load a U12 ROM",
                InitialDirectory = "C:\\adpcm\\roms",
                Filter = "All files (*) | *.*"
            };

            if (OF.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                OF.FilterIndex = 0;
                OF.RestoreDirectory = true;
                U12List.Nodes.Add(OF.FileName);
                U12List.EndUpdate();
            }
        }

        private void U12ClearClick(object sender, EventArgs e)
        {
            U12List.Nodes.Clear();
            U12List.EndUpdate();
        }

        private void U13Click(object sender, EventArgs e)
        {
            OpenFileDialog OF = new OpenFileDialog
            {
                Title = "Load a U13 ROM",
                InitialDirectory = "C:\\adpcm\\roms",
                Filter = "All files (*) | *.*"
            };

            if (OF.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                OF.FilterIndex = 0;
                OF.RestoreDirectory = true;
                U13List.Nodes.Add(OF.FileName);
                U13List.EndUpdate();
            }
        }

        private void U13ClearClick(object sender, EventArgs e)
        {
            U13List.Nodes.Clear();
            U13List.EndUpdate();
        }

        private void DoImport(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
