using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using System.Net.Sockets;
using System.Net;
using System.Threading;

namespace MMS
{
    public partial class MSM : Form
    {
        private  string xmlPath = "..\\..\\config.xml";

        public MSM()
        {

            InitializeComponent();
        }

        private void MSM_Load(object sender, EventArgs e)
        {

        }

        private void butSel_Click(object sender, EventArgs e)
        {
            foreach(Control c in this.gb1.Controls)
            {
                if(c is CheckBox)
                {
                    CheckBox cb = (CheckBox)c;
                    cb.Checked = true;
                }
            }
        }


        private void btnUnsel_Click(object sender, EventArgs e)
        {
            foreach (Control c in this.gb1.Controls)
            {
                if (c is CheckBox)
                {
                    CheckBox cb = (CheckBox)c;
                    cb.Checked = false;
                }
            }
        }

        /// <summary>
        /// 连接选中的Host(通过TCP/IP协议建立socket连接)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCon_Click(object sender, EventArgs e)
        {
            
            #region 获取选中的Host名字
            List<string> cellNames = new List<string>();
            foreach (Control c in this.gb1.Controls)
            {
                if (c is CheckBox)
                {
                    CheckBox cb = (CheckBox)c;
                    if (cb.Checked == true)
                    {
                        cellNames.Add(cb.Text);
                        cb.BackColor = Color.Green;
                    }
                }

            }
            #endregion

            #region smaple 序列化XML
            /* ----------------- 初始化xml文件-------------------
            List<config> cfs = new List<config>(11);
            cfs.Add(new config() { Ip = "127.0.0.1", CellName = "B25", Port = 4909, HgaloadState = "stop", BseState = "stop", ReflowState = "stop", VtaapState = "stop", UlrtState = "stop", Index = 2 });
            cfs.Add(new config() { Ip = "127.0.0.1", CellName = "F29", Port = 4909, HgaloadState = "stop", BseState = "stop", ReflowState = "stop", VtaapState = "stop", UlrtState = "stop", Index = 8 });
            cfs.Add(new config() { Ip = "127.0.0.1", CellName = "F28", Port = 4909, HgaloadState = "stop", BseState = "stop", ReflowState = "stop", VtaapState = "stop", UlrtState = "stop", Index = 23 });
            cfs.Add(new config() { Ip = "127.0.0.1", CellName = "F27", Port = 4909, HgaloadState = "stop", BseState = "stop", ReflowState = "stop", VtaapState = "stop", UlrtState = "stop", Index = 24 });
            cfs.Add(new config() { Ip = "127.0.0.1", CellName = "F20", Port = 4909, HgaloadState = "stop", BseState = "stop", ReflowState = "stop", VtaapState = "stop", UlrtState = "stop", Index = 10 });
            cfs.Add(new config() { Ip = "127.0.0.1", CellName = "F19", Port = 4909, HgaloadState = "stop", BseState = "stop", ReflowState = "stop", VtaapState = "stop", UlrtState = "stop", Index = 16 });
            cfs.Add(new config() { Ip = "127.0.0.1", CellName = "F18", Port = 4909, HgaloadState = "stop", BseState = "stop", ReflowState = "stop", VtaapState = "stop", UlrtState = "stop", Index = 17 });
            cfs.Add(new config() { Ip = "127.0.0.1", CellName = "F17", Port = 4909, HgaloadState = "stop", BseState = "stop", ReflowState = "stop", VtaapState = "stop", UlrtState = "stop", Index = 13 });
            cfs.Add(new config() { Ip = "127.0.0.1", CellName = "B24", Port = 4909, HgaloadState = "stop", BseState = "stop", ReflowState = "stop", VtaapState = "stop", UlrtState = "stop", Index = 30 });
            cfs.Add(new config() { Ip = "127.0.0.1", CellName = "B22", Port = 4909, HgaloadState = "stop", BseState = "stop", ReflowState = "stop", VtaapState = "stop", UlrtState = "stop", Index = 22 });
            cfs.Add(new config() { Ip = "127.0.0.1", CellName = "B13", Port = 4909, HgaloadState = "stop", BseState = "stop", ReflowState = "stop", VtaapState = "stop", UlrtState = "stop", Index = 5 });
            string xml = XmlUtil.Serializer(typeof(List<config>), cfs);
            textBox1.Text = xml;


            File.WriteAllText(xmlPath, xml, Encoding.UTF8);
            */
            #endregion

            
            #region 反序列化, 从Host名字读取IP与Port ,作为客户端建立TCP/IP Socket连接
            //从XML文件中读出所有字符串
            string xml = File.ReadAllText(xmlPath);
            //将XML字符串反序列化成为List<config>
            List<config> cfs = XmlUtil.Deserialize(typeof(List<config>), xml) as List<config>; 
            //判断是否选定线别，并创建TCP/IP Socket线程 （SockeThreads）
            foreach (string cell in cellNames)
            {
                foreach (config cfunit in cfs)
                {
                    //判断是否选定
                    if (cell == cfunit.CellName)
                    {   //创建Socket客户端线程
                        SocketThreads stClient = new SocketThreads(cell, cfunit.Ip, cfunit.Port, SocketThreads.SType.CLIENT, "GET");
                        textBox1.Text = stClient.Info;
                    }
                }
            }
            #endregion
        }

        private void btnDiscon_Click(object sender, EventArgs e)
        {

        }



        
        

    }
}
