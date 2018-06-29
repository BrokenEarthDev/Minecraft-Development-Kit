using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Minecraft_Development_Kit__MDK_
{

    public partial class Form2 : Form
    {
        private Form form;

        public Form2()
        {
            InitializeComponent();
        }

        public void SetText(string text, Form form)
        {
           
                this.form = form;
                form.Hide();
                this.Show();
                label1.Text = text;
        }

        private void OnOKClick(object sender, EventArgs e)
        {
            this.Close();
            form.Show();
        }
    }
}
