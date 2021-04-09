/** 认证进行的主体 **/
/** Author: shinsya **/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace College_Network_Auth
{
    public delegate void Print(String s);
    class Loginer
    {
        String ExtraIP = "";
        static String SucceedFlag = "确定注销?";
        static String SucceedFlag2 = "登录成功";
        static String GetMessage = "GET / HTTP/1.1\r\n\r\n";
        String PostHeader = "POST / HTTP/1.1\r\nHost: {0}\r\nContent-Length: ";
        static String PostFormat = "DDDDD={0:G}&upass={1:G}&v46s=0&v6ip=&f4serip=&0MKKey=";

        Connection server;

        public Loginer(String _IP)
        {
            ExtraIP = _IP;
            ClassSetup();
        }

        void ClassSetup()
        {
            if (ExtraIP != "")   //外部设置的ip
            {
                PostHeader = string.Format(PostHeader, ExtraIP);
            }
            else
            {
                ExtraIP = "192.168.1.252";
                PostHeader = string.Format(PostHeader, ExtraIP);
            }
            server = new Connection(IPAddress.Parse(ExtraIP), 80);
        }
        public bool TryToConnectServer()
        {
            if (server.IsConnected())
                return true;
            return server.TryToConnect();
        }

        public bool TryToLogin(String userid, String pwd)
        {
            if (TryToConnectServer() == false)
                return false;
            string PostMessage = string.Format(PostFormat, userid, pwd);
            string PostData = PostHeader + PostMessage.Length.ToString();
            PostData += "\r\n\r\n";
            PostData += PostMessage;
            int sl = server.Send(Encoding.Default.GetBytes(PostData), PostData.Length);
            server.Disconnect();
            if (sl != PostData.Length)
                return false;
            return true;
        }

        private int ConnectFailedCounter = 0;
        public bool CheckLogin()
        {
            if (server.IsConnected() == false)
            {
                server.TryToConnect();
                if (server.IsConnected() == false)
                {
                    ConnectFailedCounter++;
                    if (ConnectFailedCounter > 20)
                    {
                        Console.WriteLine("无法与服务器连接");
                        return false;
                    }
                    return true;
                }
                ConnectFailedCounter = 0;
            }
            server.Send(Encoding.Default.GetBytes(GetMessage), GetMessage.Length);
            Byte[] recv_data = new Byte[4096];
            server.Recv(recv_data, 4096);       //接收GET请求的返回头
            String checkData = Encoding.Default.GetString(recv_data);
            if(checkData.IndexOf("HTTP/1.1 200 OK") == -1)  //确认返回头表示正确
            {
                server.Disconnect();
                return false;
            }
            server.Recv(recv_data, 4096);   //接收返回数据
            server.Disconnect();
            checkData = Encoding.Default.GetString(recv_data);
            if (checkData.IndexOf(SucceedFlag) == -1)   //寻找注销功能，存在则表示已登录
            {
                if (checkData.IndexOf(SucceedFlag2) == -1)
                {
                    Console.WriteLine(checkData);
                    Console.WriteLine("没有找到注销信息");
                    return false;
                }
            }
            return true;
        }
    }
}
