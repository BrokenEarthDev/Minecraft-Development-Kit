using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
namespace Minecraft_Development_Kit__MDK_
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Form1());
            }
            catch (Exception ex)
            {
                Form2 form2 = new Form2();
                form2.SetText("An error has occurred!\nPlease contact @BrokenEarth with the following token\nErr_" + ex.Message, new Form1());
            }
            
        }

       
    }
}
