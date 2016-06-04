using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MMS
{
    public class SocketUnit
    {
        public enum SType{SERVER,CLIENT};

        private string _ip;

        public string Ip
        {
            get { return _ip; }
            set { _ip = value; }
        }
        private int _port;

        public int Port
        {
            get { return _port; }
            set { _port = value; }
        }
        private SType _st;

        public SType St
        {
            get { return _st; }
            set { _st = value; }
        }
        private string _infor;

        public string Infor
        {
            get { return _infor; }
            set { _infor = value; }
        }

    }
}
