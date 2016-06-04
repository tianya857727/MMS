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

        private SocketUnit _su;

        public SocketUnit Su
        {
            get { return _su; }
            set { _su = value; }
        }

        private Socket sk;

        public Socket Sk
        {
            get { return sk; }
            set { sk = value; }
        }


        public SocketThreads(string name, SocketUnit su)
        {
            Su = su;
            if (su.St.ToString() == "SERVER")
            {
                //初始化Socket
                IPAddress ipa = IPAddress.Parse(su.Ip);
                Sk = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                IPEndPoint iep = new IPEndPoint(ipa, su.Port);
                //绑定server端IP 与 端口
                sk.Bind(iep);

                thds = new Thread(this.SocketServer);
                thds.Start(su);
            }
            else
            {
                thds = new Thread(this.SocketClient);
                
                thds.Start();
            }
            thds.Name = name;
            
        }

        public void SocketServer(object obj)
        {
            SocketUnit su_temp = (SocketUnit)obj;
            
            while (true)
            {
                try {
                    //监听，最大连接 20
                    sk.Listen(20);
                    //接受请求，并返回套接字
                    Socket skRev = sk.Accept();
                    //套接字处理对话
                    //skRev.Receive(byteMessage);
                    //string msg = System.Text.Encoding.Default.GetString(byteMessage).Trim();
                    //发送PLC传进来的数据
                    skRev.Send(System.Text.Encoding.Default.GetBytes(su_temp.Infor));

                    skRev.Close();
                }
                catch (SocketException e)
                {
                    Sk.Close();
                    throw new Exception(e.ToString());
                    
                }
                
            }
        }

        public void SocketClient()
        {
            
            while (true)
            {
                try
                {
                    //每次循环清空byteMessage
                    Byte[] byteMessage = new Byte[100];
                    //每次循环重新连接，为了符合Server的Accept功能,重新建立连接
                    Sk = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    Sk.Connect(Su.Ip, Su.Port);
                        
                    //休眠50ms
                    Thread.Sleep(50);

                    //接受数据
                    if (sk.Connected)
                    {
                        sk.Receive(byteMessage);
                        Su.Infor = System.Text.Encoding.Default.GetString(byteMessage).ToString();
                    }

                    //关闭本套接字
                    Sk.Close();
                    
                }
                catch (SocketException ex)
                {
                    throw new Exception("Socket连接错误：" + ex.ToString());
                }  
            }
        }

    }
}
