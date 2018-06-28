using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Model
{
    public class dm_sheng
    {
        public dm_sheng() { }
        private int _daihao;
        private string _mingcheng;

        public int Daihao
        {
            get { return _daihao; }
            set { _daihao = value; }
        }
        public string Mingcheng
        {
            get { return _mingcheng; }
            set { _mingcheng = value; }
        }
    }
}
