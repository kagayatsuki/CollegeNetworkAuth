/** Author: shinsya **/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;

namespace College_Network_Auth
{
    static class Program
    {
        static RegistryKey startupKey = Registry.CurrentUser;
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main(string [] Args)
        {
            CheckArgs(Args);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }

        static void SetStartup()
        {
            RegistryKey thisKey = startupKey.OpenSubKey("Software", true);
            thisKey = thisKey.OpenSubKey("Microsoft", true);
            thisKey = thisKey.OpenSubKey("Windows", true);
            thisKey = thisKey.OpenSubKey("CurrentVersion", true);
            thisKey = thisKey.OpenSubKey("Run", true);
            if (thisKey == null)
            {
                MessageBox.Show("设定开机自启动失败");
            }
            else
            {
                thisKey.SetValue("CollegeNetworkAuth", "\"" + Application.ExecutablePath + "\"");
                thisKey.Close();
            }
            System.Environment.Exit(0);

        }

        static void CheckArgs(string [] args)
        {
            foreach (string s in args)
            {
                if (s == "-setStartup")
                    SetStartup();
            }
        }
    }
}
