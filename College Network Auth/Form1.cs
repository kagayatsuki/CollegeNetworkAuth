/** Author: shinsya **/

using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Diagnostics;

namespace College_Network_Auth
{
    delegate void SetVisible(bool hideState);
    public partial class Form1 : Form
    {
        static Loginer loginer;
        Thread sleepThread;
        static bool loginOnLaunch = false;      //自动登录标识
        static bool errorIgnore = false;            //错误忽视标识

        static SetVisible setVisible;       //用于在线程中改变主窗口的显示或隐藏状态的委托

        static String studID, passWD;

        public static String GetMessage = "GET / HTTP/1.1\r\n\r\n";
        public Form1()
        {
            Process[] processcollection = Process.GetProcessesByName(Process.GetCurrentProcess().ProcessName);
            if (processcollection.Length > 1)
            {
                MessageBox.Show("当登录成功后，会留下后台进程检查并维持登录，如果出现问题您可以尝试使用任务管理器终止", "程序已经在运行");
                System.Environment.Exit(0);
            }
            if (File.Exists(Application.StartupPath + "\\IP.txt"))
            {
                try
                {
                    using(StreamReader IPconf = new StreamReader(Application.StartupPath + "\\IP.txt"))
                    {
                        String IPset = IPconf.ReadToEnd();
                        loginer = new Loginer(IPset);
                    }
                }
                catch
                {
                    MessageBox.Show("您的 \"IP.txt\" 文件存在问题，请删除或修正");
                }
            }
            else
            {
                loginer = new Loginer("");
            }
            setVisible = Hide;
            Control.CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
        }

        void Hide(bool hideState)
        {
            this.Visible = hideState;
        }

        static void SleepThread()
        {
            setVisible(false);
            while (true)
            {
                Thread.Sleep(15000);    //15秒一次检查
                if (loginer.CheckLogin() == false)
                {
                    if (loginer.TryToLogin(studID, passWD) == false)
                    {
                        if (!errorIgnore)   //不忽视错误则跳出提示窗口
                        {
                            MessageBox.Show("与校园网的持续认证出现异常");
                            setVisible(true);
                            break;
                        }
                    }
                }
            }

        }

        void LoadConfigure()        //获取本地配置
        {
            try
            {
                using (StreamReader reader = new StreamReader(Application.StartupPath + "\\config"))
                {
                    string lineTemp;
                    string origin;
                    lineTemp = reader.ReadLine();
                    origin = Base64Helper.Base64Decode(Encoding.ASCII, lineTemp);
                    studentID.Text = origin;
                    lineTemp = reader.ReadLine();
                    origin = Base64Helper.Base64Decode(Encoding.ASCII, lineTemp);
                    pwd_text.Text = origin;
                    lineTemp = reader.ReadLine();
                    string ignore_string = reader.ReadLine();
                    if (ignore_string == "Yes")
                    {
                        errorIgnore = true;
                        checkBox_ErrorIgnore.Checked = true;
                    }
                    if(lineTemp == "Yes")
                    {
                        loginOnLaunch = true;
                        checkBox1.Checked = true;
                        login();
                    }
                    
                }
            }
            catch
            {
                this.Text += " 无法读入配置";
                MessageBox.Show(Application.StartupPath);
            }
        }

        void WriteConfigure(String stuID, String passwd, bool loginOnLaunch)      //保存配置
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(Application.StartupPath + "\\config"))
                {
                    writer.WriteLine(Base64Helper.Base64Encode(Encoding.ASCII, stuID));
                    writer.WriteLine(Base64Helper.Base64Encode(Encoding.ASCII, passwd));
                    if (loginOnLaunch)
                        writer.WriteLine("Yes");
                    else
                        writer.WriteLine("No");
                    if (errorIgnore)
                        writer.WriteLine("Yes");
                    else
                        writer.WriteLine("No");
                }
            }
            catch
            {}
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadConfigure();
        }

        void TestOut(string s)
        {}

        void SetWidgetEnable(bool enable)
        {
            studentID.Enabled = enable;
            pwd_text.Enabled = enable;
            login_button.Enabled = enable;
        }

        static void SetStartUp()
        {
            Process thisProc = Process.GetCurrentProcess();
            thisProc.StartInfo.UseShellExecute = true;
            thisProc.StartInfo.Verb = "runas";
            thisProc.StartInfo.Arguments = "-setStartup";
            thisProc.StartInfo.FileName = Application.ExecutablePath;
            thisProc.Start();
        }

        void login()
        {
            SetWidgetEnable(false);
            if (loginer.TryToConnectServer() == false)
            {
                MessageBox.Show("无法连接到服务器");
                SetWidgetEnable(true);
                return;
            }
            for(int i = 0; i < 2; i++)  //不知从何时起有时候登录就算密码是对的也会报密码错误，所以如果错误则歇一会再试一下
            {
                if (loginer.TryToLogin(studentID.Text, pwd_text.Text) == false)
                {
                    MessageBox.Show("尝试登录失败");
                    loginOnLaunch = false;
                    SetWidgetEnable(true);
                    return;
                }
                if (loginer.CheckLogin() == true)
                    break;
                Thread.Sleep(4000);
                if(i == 1)
                {
                    MessageBox.Show("登录未成功，可能密码或学号错误");
                    SetWidgetEnable(true);
                    loginOnLaunch = false;
                    return;
                }
            }
            if(loginOnLaunch == false)
                MessageBox.Show("登录成功");
            if(loginOnLaunch == false)  //写入正确的账号数据
            {
                if (checkBox1.Checked)
                {
                    SetStartUp();
                }
                Encoding encoding = Encoding.ASCII;
                WriteConfigure(encoding.GetString(encoding.GetBytes(studentID.Text)), encoding.GetString(encoding.GetBytes(pwd_text.Text)), checkBox1.Checked);
            }
            SetWidgetEnable(true);
            studID = studentID.Text;
            passWD = pwd_text.Text;
            ThreadStart childThread = new ThreadStart(SleepThread);     //后台侦测线程
            sleepThread = new Thread(childThread);
            sleepThread.Start();
        }

        private void login_button_Click(object sender, EventArgs e)
        {
            login();
        }

        private void checkBox_ErrorIgnore_CheckedChanged(object sender, EventArgs e)
        {
            errorIgnore = checkBox_ErrorIgnore.Checked;
        }

        private void pwd_text_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                login();
            }
        }
    }
}
