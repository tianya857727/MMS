using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;


namespace MMS
{
    public class SocketThreads
    {
        public enum SType{SERVER,CLIENT};

        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public Thread thds;

        private string ip;

        public string Ip
        {
            get { return ip; }
            set { ip = value; }
        }
        private int port;

        public int Port
        {
            get { return port; }
            set { port = value; }
        }

        private string info;

        public string Info
        {
            get { return info; }
            set { info = value; }
        }

        private Socket sk;

        public Socket Sk
        {
            get { return sk; }
            set { sk = value; }
        }


        public SocketThreads(string name, string ip, int port, SType st, string information)
        {
            Info = information;
            Ip = ip;
            Port = port;
            if (st.ToString() == "SERVER")
            {
                thds = new Thread(this.SocketServer);
                thds.Name = name;
                thds.Start();
            }
            else
            {
                thds = new Thread(this.SocketClient);
                thds.Name = name;
                thds.Start();
            }
            thds.Name = name;
            thds.Start();
        }

        public void SocketServer()
        {
            IPAddress ipa = IPAddress.Parse(Ip);
            Sk = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint iep = new IPEndPoint(ipa, Port);
            //存储client发过来的数据
            Byte[] byteMessage = new Byte[100];
            //绑定server端IP 与 端口
            sk.Bind(iep);
            while (true)
            {
                try {
                    //监听，最大连接 20
                    sk.Listen(20);
                    //接受请求，并返回套接字
                    Socket skRev = sk.Accept();
                    //套接字处理对话
                    skRev.Receive(byteMessage);
                    string msg = System.Text.Encoding.Default.GetString(byteMessage).Trim();
                    //判断是否是Client端请求数据的命令，并发送对应数据回去
                    if (msg == "GET")
                    { 
                        skRev.Send(System.Text.Encoding.Default.GetBytes(Info));
                    }

                    skRev.Close();
                }
                catch (SocketException e)
                {
                    throw new Exception(e.ToString());
                    
                }
                
            }
        }

        public void SocketClient()
        {
            Byte[] byteMessage = new Byte[100];
            //建立并保持Socket连接
            
            IPAddress ipa = IPAddress.Parse(Ip);
            Sk = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            
            Sk.Connect(Ip, Port);
            
            while (true)
            {
                try
                {
                    //休眠50ms
                    Thread.Sleep(50);

                    //发送命令
                    if (Sk.Connected)
                    {
                        sk.Send(System.Text.Encoding.Default.GetBytes("GET"));

                        //接受Server返回数据，并将其转换为String类型
                        sk.Receive(byteMessage);
                        Info = System.Text.Encoding.Default.GetString(byteMessage).ToString();
                    }
                    
                }
                catch (SocketException ex)
                {
                    throw new Exception(ex.ToString());
                }  
            }
        }

    }
}
