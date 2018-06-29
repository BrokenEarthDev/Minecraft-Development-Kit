using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Threading;

namespace Minecraft_Development_Kit__MDK_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void OnExtractClick(object sender, EventArgs e)
        {
            if (Extractor.CanEnd())
            {
                this.Close();
            }
            using (var folderDialog = new FolderBrowserDialog())
            {
                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    string selectedpath = folderDialog.SelectedPath;
                    Extractor.Extract(selectedpath, progressBar1, button1, this);
                }
            }
        }

    }
}
