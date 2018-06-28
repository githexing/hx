using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Model
{
    public class caidan
    {
        public caidan() { }
        private string _yingyong;
        private string _bianhao;
        private string _xuhao;
        private string _fuxuhao;
        private string _mingcheng;
        private string _jiancheng;
        private string _url;
        private string _image;

        public string Yingyong
        {
            get { return _yingyong; }
            set { _yingyong = value; }
        }
        public string Bianhao
        {
            get { return _bianhao; }
            set { _bianhao = value; }
        }
        public string Xuhao
        {
            get { return _xuhao; }
            set { _xuhao = value; }
        }
        public string Fuxuhao
        {
            get { return _fuxuhao; }
            set { _fuxuhao = value; }
        }
        public string Mingcheng
        {
            get { return _mingcheng; }
            set { _mingcheng = value; }
        }
        public string Jiancheng
        {
            get { return _jiancheng; }
            set { _jiancheng = value; }
        }
        public string Url
        {
            get { return _url; }
            set { _url = value; }
        }
        public string Image
        {
            get { return _image; }
            set { _image = value; }
        }
    }
}
