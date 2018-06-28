using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
//using System.Web.UI.WebControls;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text;



namespace WebApplication1.小程序
{
    public partial class tupian : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //GetImageToString(@"C:\Users\Administrator\Desktop\demo2.jpg", @"C:\Users\Administrator\Desktop\新建文件夹 (2)\1.txt");
            GetImageFromString(@"C:\Users\Administrator\Desktop\新建文件夹 (2)\1.txt");
            //GetPictureTostring();
        }
      
        /// <summary>
        /// 把图片转换到文本信息
        /// </summary>
        /// <param name="imagePath">图片的路径</param>
        /// <param name="savePath">文本存储路径</param> 

        public void GetImageToString(string imagePath, string savePath)
        {
            Stream s = File.Open(imagePath, FileMode.Open);
          
            int leng = 0;
            if (s.Length < Int32.MaxValue)     //防止图片太大了
                leng = (int)s.Length;
            
            byte[] by = new byte[leng];        //声明字节数组

            //MemoryStream ms = new MemoryStream();    //内存中声明一个流       
            s.Read(by, 0, by.Length);
            //ms.Read(by, 0, (int)s.Length);//把图片读到字节数组中  

            //ms.Close(); 
            string str = Convert.ToBase64String(by);//把字节数组转换成字符串
            StreamWriter sw = File.CreateText(savePath);//存入savePath文件
            sw.Write(str);
            sw.Close();
            sw.Dispose();
            s.Close();
        }

        //已经成功
        protected void FileToStream(object sender, EventArgs e)
        {
            //将JPG图片转化成字节数组
            Image image = Image.FromFile(@"C:\Users\Administrator\Desktop\新建文件夹 (2)\20150221100214078.Jpeg"); //或者使用Server.MapPath
            MemoryStream ms = new MemoryStream();
            image.Save(ms, ImageFormat.Jpeg);
            ms.Flush();
            ms.Seek(0, SeekOrigin.Begin);
            byte[] buffer = new byte[ms.Length];
            ms.Read(buffer, 0, (int)ms.Length);

            //遍历字节数组
            //for (int i = 0; i < buffer.LongLength; i++)
            //{ 
            //        message.Text += buffer[i].ToString(); 
            //}
            ////遍历字节数组
            for (int i = 0; i < buffer.LongLength; i++)
            {
                if (i == int.Parse(buffer.LongLength.ToString()) - 1)
                {
                    message.Text += buffer[i].ToString();
                    continue;
                }

                message.Text += buffer[i].ToString() + ".";
            }
            g();
            //将字节数组转化成图像文件（自定义格式）并保存
            //MemoryStream ms2 = new MemoryStream(buffer, 0, buffer.Length);
            //ms2.Seek(0, SeekOrigin.Begin);
            //Image image2 = Image.FromStream(ms2);
            //image2.Save(@"C:\Users\Administrator\Desktop\新建文件夹 (2)\2.gif", ImageFormat.Gif);
        }


        public void   g()
        { 
            string[] aa =message.Text.Split('.');
            byte[] by = new byte[aa.Length]; 
            for (int i = 0; i < aa.Length; i++)
            {
                by[i] = (byte)Convert.ToInt32(aa[i]);
            }

            MemoryStream ms2 = new MemoryStream(by, 0, by.Length);
            ms2.Seek(0, SeekOrigin.Begin);
            Image image2 = Image.FromStream(ms2);
            image2.Save(ms2, ImageFormat.Png);
            Response.ClearContent();
            Response.ContentType = "image/Png";
            Response.BinaryWrite(ms2.ToArray());


            //image2.Save(@"C:\Users\Administrator\Desktop\新建文件夹 (2)\2.gif", ImageFormat.Gif);

            //a.CopyTo(b, 0);

            //by.CopyTo(,i)
            //for (int i = 0; i < aa.Length; i++)
            //{
            //    char[] tem
            //        d.Add(i, Convert.FromBase64String(aa[i]));//按照指定编码将string编程字节数组


            //}


            //MemoryStream ms2 = new MemoryStream(buffer, 0, buffer.Length);
            //ms2.Seek(0, SeekOrigin.Begin);
            //Image image2 = Image.FromStream(ms2);
            //image2.Save(@"C:\Users\Administrator\Desktop\新建文件夹 (2)\2.gif", ImageFormat.Gif);

        }
        /// <summary>
        /// 把字符串还原成图片
        /// </summary>
        /// <param name="path"></param>
        /// <returns>图片</returns>

        public void GetImageFromString(string stringPath)
        {
            pStreamReader sr = new StreamReader(stringPath);
            string s = sr.ReadToEnd();
            sr.Close();
            byte[] buffer = Convert.FromBase64String(s);

            using (MemoryStream ms = new MemoryStream(buffer, 0, buffer.Length))
            {
                ms.Write(buffer, 0, buffer.Length);
                Image img = Image.FromStream(ms);
                img.Save(ms, ImageFormat.Png);
                Response.ClearContent();
                Response.ContentType = "image/Png";
                Response.BinaryWrite(ms.ToArray());
                //img.Save(@"C: \Users\Administrator\Desktop\新建文件夹(2)\2.Jpeg", ImageFormat.Jpeg);
            }

            //MemoryStream ms2 = new MemoryStream(buffer, 0, buffer.Length);
            //ms2.Seek(0, SeekOrigin.Begin);
            //Image image2 = Image.FromStream(ms2);
            //image2.Save(@"C: \Users\Administrator\Desktop\新建文件夹(2)\2.gif", ImageFormat.Gif);



            // //读入MemoryStream对象
            // MemoryStream ms = new MemoryStream(btu);
            // ms.Position = 0;
            //Image img = Image.FromStream(ms); 
            // ms.Close();
            // //二进制转成图片保存

            //Bitmap bmpt = new Bitmap(ms);

            ////System.Drawing.Image img = System.Drawing.Image.FromStream(ms);
            ////img.Save("12.gif", System.Drawing.Imaging.ImageFormat.Gif);  //保存成图片

            //bmpt.Save(ms, ImageFormat.Png); 
            //ms.Close();
            //ms.Dispose();
            //Response.ClearContent();
            //Response.ContentType = "image/Png";
            //Response.BinaryWrite(ms.ToArray());
            //return bmpt;

        }
        public void GetPictureTostring()

        {

            //把图片转成字节

            FileStream fs = new FileStream(@"C:\Users\Administrator\Desktop\demo2.jpg", FileMode.Open, FileAccess.Read);

            Byte[] b = new Byte[fs.Length];

            fs.Read(b, 0, b.Length);

            fs.Close();

            //再把字节转成图片，输出

            MemoryStream ms = new MemoryStream(b);

            Bitmap bmpt = new Bitmap(ms);

            bmpt.Save(ms, ImageFormat.Png);
            Response.ClearContent();
            Response.ContentType = "image/Png";
            Response.BinaryWrite(ms.ToArray());

        }
    }
  
}