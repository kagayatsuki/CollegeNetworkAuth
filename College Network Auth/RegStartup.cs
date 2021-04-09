/** 对注册表操作进行了简单封装 **/
/** Author: shinsya **/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using Microsoft.Win32;

namespace College_Network_Auth
{
    class RegStartup
    {
        static RegistryKey startupKey = Registry.LocalMachine;
        RegistryKey thisKey;

        static void SetStartUp()
        {
            Process thisProc = Process.GetCurrentProcess();
            thisProc.StartInfo.UseShellExecute = true;
            thisProc.StartInfo.Verb = "runas";
            thisProc.StartInfo.Arguments = "-setStartup";
            thisProc.Start();
        }

        public RegStartup()
        {
            thisKey = startupKey.OpenSubKey("Software", true);
            thisKey = thisKey.OpenSubKey("Microsoft", true);
            thisKey = thisKey.OpenSubKey("Windows", true);
            thisKey = thisKey.OpenSubKey("CurrentVersion", true);
            thisKey = thisKey.OpenSubKey("Run", true);
        }

        public bool SetStartup(String AppName, String LocalPath)
        {
            if(thisKey == null)
            {
                return false;
            }
            thisKey.SetValue(AppName, LocalPath);
            return true;
        }

    }
}
