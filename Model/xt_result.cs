using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Model
{
    [Serializable]
    public class xt_result
    {
        private string returnString="";
        private int returnValue = 0;
        private int returnInt=0;
        private bool returnBool=false;
        private string returnLingpai="";
        private string message="";

        private DataTable returnDataTable;

        public DataTable ReturnDataTable
        {
            get { return returnDataTable; }
            set { returnDataTable = value; }
        }
        public xt_result() { }

        public string ReturnString
        {
            get { return returnString; }
            set { returnString = value; }
        }

        public int ReturnValue
        {
            get { return returnValue; }
            set { returnValue = value; }
        }
        public int ReturnInt
        {
            get { return returnInt; }
            set { returnInt = value; }
        }
        public bool ReturnBool
        {
            get { return returnBool; }
            set { returnBool = value; }
        }
        public string ReturnLingPai
        {
            get { return returnLingpai; }
            set { returnLingpai = value; }
        }
        public string Message
        {
            get { return message; }
            set { message = value; }
        }
    }
}
