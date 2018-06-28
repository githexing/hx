using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
//using System.Web.UI.WebControls;


using System.IO;
using System.Drawing;
using System.Drawing.Imaging;

namespace WebApplication1.MainSystem.shiyong
{
    public partial class Tupian : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// 图片转化为字符串
        /// </summary>
        /// <param name="imagePath"></param>
        /// <param name="savePath"></param>
        public void GetlmageToString(string imagePath, string savePath)
        {
            Stream s = File.Open(imagePath, FileMode.Open);
            int leng = 0;
            if (s.Length < Int32.MaxValue)

                leng = (int)s.Length;
            byte[] by = new byte[leng];

            MemoryStream a = new MemoryStream(by);
            s.Read(by, 0, (int)s.Length);
            s.Close();

            string str = Convert.ToBase64String(by);
            StreamWriter sw = File.CreateText(savePath);
            sw.Write(str);
            sw.Close();
            sw.Dispose();

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string imagePath = "D:\\4.png";
            string savePath = "D:\\1.txt";
            GetlmageToString(imagePath, savePath);
            string stringPath = savePath;
            //GetlmageFromString(stringPath);//暂时不能转化为图片
        }
        public Image GetlmageFromString(string stringPath)
        {
            StreamReader sr = new StreamReader(stringPath);
            string s = sr.ReadToEnd();
            sr.Close();
            byte[] buf = Convert.FromBase64String(s);
            MemoryStream ms = new MemoryStream(buf);
            System.Drawing.Image img = System.Drawing.Image.FromStream(ms);
            img.Save("12.png", System.Drawing.Imaging.ImageFormat.Png);//保存成图片； 
            ms.Close();
            ms.Dispose();
            return img;
        }

       

    }
}