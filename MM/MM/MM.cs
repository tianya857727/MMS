using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;

namespace MM
{
    public partial class MM : Form
    {
        public MM()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 将txtBefore中的十进制数，转换成二进制数，并显示在txtAfter中
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvert_Click(object sender, EventArgs e)
        {
            int data = Convert.ToInt32(txtBefore.Text);
            
            txtAfter.Text = Convert.ToString(data, 2);
        }

        private void MM_Load(object sender, EventArgs e)
        {
            txtHostIP.Text = GetIPAddress();
        }

        private void btiConvert_Click(object sender, EventArgs e)
        {

            txtBefore.Text = Convert.ToInt32(txtAfter.Text, 2).ToString();

        }


        public static string GetIPAddress()
        {
            IPHostEntry ihe = Dns.GetHostEntry(Dns.GetHostName());

            foreach (IPAddress ip in ihe.AddressList)
            {
                if (ip.ToString().Substring(0, 2) == "10")
                {
                    return ip.ToString();
                }
            }
            return "";
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            SocketThreads sts = new SocketThreads("F29", txtHostIP.Text.Trim(), Convert.ToInt32( txtHostPort.Text.Trim()), SocketThreads.SType.SERVER, txtTest.Text.Trim());
            
        }
    }
}
