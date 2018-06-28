using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Model
{
    public class xt_error
    {
        public xt_error() { }
        private int _id;
        private string _application;
        private string _message;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        public string Application
        {
            get { return _application; }
            set { _application = value; }
        }
        public string Message
        {
            get { return _message; }
            set { _message = value; }
        }
    }
}
