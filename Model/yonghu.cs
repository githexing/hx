using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Model
{
    public class yonghu
    {
        public yonghu() { }
        private string _daihao;
        private string _mingcheng;
        private string _zubie;
        private string _images;

        public string Daihao
        {
            get { return _daihao; }
            set { _daihao = value; }
        }
        public string Mingcheng
        {
            get { return _mingcheng; }
            set { _mingcheng = value; }
        }
        public string Zubie
        {
            get { return _zubie; }
            set { _zubie = value; }
        }
        public string Images
        {
            get { return _images; }
            set { _images = value; }
        }
    }
}
