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
        private static bool canEnd = false;
        public static bool CanEnd()
        {
            return canEnd;
        }

        public static void Extract(string target, ProgressBar progress, Form form, Button button)
        {
            try
            {
                Thread thread = new Thread(() => CopyToServer(target));
                thread.Start();
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show("'server' already exists");
            }
            catch (Exception ex)
            {
                new Form2("An error has occurred. \nPlease message a developer with:\n " +
                    "ERR_" + ex.Message).Show();
            }
            progress.Value = 20;
            try
            {
                Thread thread = new Thread(() => CopyToProxies(target));
                thread.Start();
            }
            catch (IOException)
            {
                MessageBox.Show("'proxies' already exists");
            }
            catch (Exception ex)
            {
                new Form2("An error has occurred. \nPlease message a developer with:\n " +
                    "ERR_" + ex.Message).Show();
            }
            progress.Value = 40;
            try
            {
                Thread thread = new Thread(() => CopyToMcp(target));
                thread.Start();
            }
            catch (IOException)
            {
                MessageBox.Show("'mcp' already exists");
            }
            catch (Exception ex)
            {
                new Form2("An error has occurred. \nPlease message a developer with:\n " +
                    "ERR_" + ex.Message).Show();
            }
            progress.Value = 60;
            try
            {
                Thread thread = new Thread(() => CopyToForge(target));
                thread.Start();
            }
            catch (IOException)
            {
                MessageBox.Show("'forge' already exists");
            }
            catch (Exception ex)
            {
                new Form2("An error has occurred. \nPlease message a developer with:\n " +
                    "ERR_" + ex.Message).Show();
            }
            progress.Value = 80;
            try
            {
                Thread thread = new Thread(() => CopyToMcpe(target));
                thread.Start();
            }
            catch (IOException)
            {
                MessageBox.Show("'mcpe' already exists");
            }
            catch (Exception ex)
            {
                new Form2("An error has occurred. \nPlease message a developer with:\n " +
                    "ERR_" + ex.Message).Show();
            }
            progress.Value = 100;
            button.Text = "Finish";
            canEnd = true;
        }

        private static void CopyToServer(string target)
        {
            Directory.CreateDirectory(target + "/server/");
            Copy("server", target + "/server/");
        }

        private static void CopyToProxies(string target)
        {
            Directory.CreateDirectory(target + "/proxies/");
            Copy("proxy", target + "/proxies/");
        }

        private static void CopyToMcp(string target)
        {
            Directory.CreateDirectory(target + "/mcp/");
            Copy("mcp", target + "/mcp/");
        }

        private static void CopyToForge(string target)
        {
            Directory.CreateDirectory(target + "/forge/");
            Copy("forge", target + "/forge/");
        }

        private static void CopyToMcpe(string target)
        {
            Directory.CreateDirectory(target + "/mcpe/");
            Copy("mcpe", target + "/mcpe/");
        }

        public static void Copy(string sourceDirectory, string targetDirectory)
        {
            DirectoryInfo diSource = new DirectoryInfo(sourceDirectory);
            DirectoryInfo diTarget = new DirectoryInfo(targetDirectory);

            CopyAll(diSource, diTarget);
        }

        public static void CopyAll(DirectoryInfo source, DirectoryInfo target)
        {
            Directory.CreateDirectory(target.FullName);

            // Copy each file into the new directory.
            try
            {
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
            catch (Exception)
            {
                new Form2("An error has occurred").Show();
            }

            // Copy each subdirectory using recursion.
            
        }
    }
}
