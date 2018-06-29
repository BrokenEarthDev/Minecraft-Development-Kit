using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Threading;
namespace Minecraft_Development_Kit__MDK_
{
    class Extractor
    {

        public static bool ended_1v12v2 = false;
        public static bool ended_1v8v9 = false;

        private static readonly int ITEMS = 10;
        private static bool canEnd = false;
        public static bool CanEnd()
        {
            return canEnd;
        }

        public static void Extract(string target, ProgressBar progress, Button button, Form form)
        {
            Thread thread = new Thread(() => V1_1_12_2.Extract(target, progress, form));
            thread.Start();
            progress.Value = 50;
            V1_8_9.Extract(target, progress, form);
            progress.Value = 100;
            canEnd = true;
            button.Text = "Finish";
        }

        public static int GetItems()
        {
            return ITEMS;
        }

        public static void TriggerOnExtract(ProgressBar progress)
        {
            int value = 100 / ITEMS;
            progress.Value += value;
        }

        public static Extractor Copy(string sourceDirectory, string targetDirectory)
        {
            DirectoryInfo diSource = new DirectoryInfo(sourceDirectory);
            DirectoryInfo diTarget = new DirectoryInfo(targetDirectory);

            new Extractor().CopyAll(diSource, diTarget);
            return new Extractor();
        }

        public void CopyAll(DirectoryInfo source, DirectoryInfo target)
        {
            Directory.CreateDirectory(target.FullName);

            // Copy each file into the new directory.

            foreach (FileInfo fi in source.GetFiles())
            {
                Console.WriteLine(@"Copying {0}\{1}", target.FullName, fi.Name);
                fi.CopyTo(Path.Combine(target.FullName, fi.Name), true);
            }
            foreach (DirectoryInfo diSourceSubDir in source.GetDirectories())
            {
                DirectoryInfo nextTargetSubDir =
                    target.CreateSubdirectory(diSourceSubDir.Name);
                CopyAll(diSourceSubDir, nextTargetSubDir);
            }

        }
    }

    internal class V1_1_12_2
    {
        public static void Extract(string target, ProgressBar progress, Form form)
        {
            Directory.CreateDirectory(target + "/mdk_1.12.2");
            target += "/mdk_1.12.2";
            try
            {
                new Thread(() => ExtractMcp(target)).Start();
            }
            catch (Exception e)
            {
                Form2 forms = new Form2();
                forms.SetText("An exception has occurred!\nPlease contact @BrokenEarth with the following token\nERR_" + e.Message, form);
            }

            try
            {
                new Thread(() => ExtractForge(target)).Start();
            }

            catch (Exception e)
            {

                Form2 forms = new Form2();
                forms.SetText("An exception has occurred!\nPlease contact @BrokenEarth with the following token\nERR_" + e.Message, form);
            }

            try
            {
                new Thread(() => ExtractProxy(target)).Start();

            }
            catch (Exception e)
            {
                Form2 forms = new Form2();
                forms.SetText("An exception has occurred!\nPlease contact @BrokenEarth with the following token\nERR_" + e.Message, form);
            }
            try
            {
                new Thread(() => ExtractServer(target)).Start();
            }
            catch (Exception e)
            {
                Form2 forms = new Form2();
                forms.SetText("An exception has occurred!\nPlease contact @BrokenEarth with the following token\nERR_" + e.Message, form);
            }
            Extractor.ended_1v12v2 = true;
        }

        private static void ExtractMcp(string target)
        {
            Directory.CreateDirectory(target + "/mcp");
            Extractor.Copy("mdk_1.12.2/mcp", target + "/mcp");
        }

        private static void ExtractForge(string target)
        {
            Directory.CreateDirectory(target + "/forge");
            Extractor.Copy("mdk_1.12.2/forge", target + "/forge");
        }

        private static void ExtractProxy(string target)
        { 
            Directory.CreateDirectory(target + "/proxy");
            Extractor.Copy("mdk_1.12.2/proxy", target + "/proxy");
        }

        private static void ExtractServer(string target)
        {
            Directory.CreateDirectory(target + "/server");
            Extractor.Copy("mdk_1.12.2/server", target + "/server");
        }
    }

    internal class V1_8_9
    {
        public static void Extract(string target, ProgressBar progress, Form form)
        {
            Directory.CreateDirectory(target + "/mdk_1.8.9");
            target += "/mdk_1.8.9";
            try
            {
                ExtractMcp(target);
            }
            catch (Exception e)
            {
                Form2 forms = new Form2();
                forms.SetText("An exception has occurred!\nPlease contact @BrokenEarth with the following token\nERR_" + e.Message, form);
            }
            Thread thread2 = new Thread(() => ExtractForge(target));
            try
            {
                thread2.Start();
            }
            
            catch (Exception e)
            {
                Form2 forms = new Form2();
                forms.SetText("An exception has occurred!\nPlease contact @BrokenEarth with the following token\nERR_" + e.Message, form);
            }
            try
            {
                ExtractProxy(target);
            }
            
            catch (Exception e)
            {
                Form2 forms = new Form2();
                forms.SetText("An exception has occurred!\nPlease contact @BrokenEarth with the following token\nERR_" + e.Message, form);
            }
            try
            {
                ExtractServer(target);
            }
            
            catch (Exception e)
            {
                Form2 forms = new Form2();
                forms.SetText("An exception has occurred!\nPlease contact @BrokenEarth with the following token\nERR_" + e.Message, form);
            }
            Extractor.ended_1v8v9 = true;
        }

        private static void ExtractMcp(string target)
        {
            Directory.CreateDirectory(target + "/mcp");
            Extractor.Copy("mdk_1.8.9/mcp", target + "/mcp");
        }

        private static void ExtractForge(string target)
        {
            Directory.CreateDirectory(target + "/forge");
            Extractor.Copy("mdk_1.8.9/forge", target + "/forge");
        }

        private static void ExtractProxy(string target)
        {
            Directory.CreateDirectory(target + "/proxy");
            Extractor.Copy("mdk_1.8.9/proxy", target + "/proxy");
        }

        private static void ExtractServer(string target)
        {
            Directory.CreateDirectory(target + "/server");
            Extractor.Copy("mdk_1.8.9/server", target + "/server");
        }
    }
}
