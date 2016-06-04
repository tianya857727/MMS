using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MMS
{
    public class config
    {
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
        private string cellName;

        public string CellName
        {
            get { return cellName; }
            set { cellName = value; }
        }
        private string hgaloadState;

        public string HgaloadState
        {
            get { return hgaloadState; }
            set { hgaloadState = value; }
        }
        private string bseState;

        public string BseState
        {
            get { return bseState; }
            set { bseState = value; }
        }
        private string reflowState;

        public string ReflowState
        {
            get { return reflowState; }
            set { reflowState = value; }
        }
        private string vtaapState;

        public string VtaapState
        {
            get { return vtaapState; }
            set { vtaapState = value; }
        }

        private string ulrtState;


        public string UlrtState
        {
            get { return ulrtState; }
            set { ulrtState = value; }
        }

        private int index;

        public int Index
        {
            get { return index; }
            set { index = value; }
        }

        public config(string ip, int port, string zgu, string zbe, string zrf, string zvt, string zlr, int id )
        {
            Ip = ip;
            Port = port;
            HgaloadState = zgu;
            BseState = zbe;
            ReflowState = zrf;
            VtaapState = zvt;
            UlrtState = zlr;
            Index = id;
        }
        public config() { }

    }
}
