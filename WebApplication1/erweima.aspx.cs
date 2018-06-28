using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using ThoughtWorks;
using ThoughtWorks.QRCode;
using ThoughtWorks.QRCode.Codec;
using ThoughtWorks.QRCode.Codec.Data;
using System.Drawing;
using System.IO;
using System.Drawing.Imaging;

namespace WebApplication1
{
    public partial class erweima : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            create_two("http://www.4399.com");
        }
        private void create_two(string nr)

        {

            Bitmap bt;

            string enCodeString = nr;

            QRCodeEncoder qrCodeEncoder = new QRCodeEncoder();

            bt = qrCodeEncoder.Encode(enCodeString, Encoding.UTF8); 

            MemoryStream ms = new MemoryStream();
            //Bitmap bmp = new Bitmap(70, 24);
            //Graphics g = Graphics.FromImage(bmp); 
            //g.Clear(Color.White);    //清除该页输出缓存，设置该页无缓存
            Response.Buffer = true;

            Response.ExpiresAbsolute = System.DateTime.Now.AddMilliseconds(0);

            Response.Expires = 0;

            Response.CacheControl = "no-cache";

            Response.AppendHeader("Pragma", "No-Cache");

            //将验证码图片写入内存流，并将其以"image/Png" 格式输出
            

            try
            {
                bt.Save(ms, ImageFormat.Png);
                Response.ClearContent();
                Response.ContentType = "image/Png";
                Response.BinaryWrite(ms.ToArray());
            }
            finally
            {
                //显式释放资源
                bt.Dispose();
                //g.Dispose();
            }
            //string filename = string.Format(DateTime.Now.ToString(), "yyyymmddhhmmss")

            // ;

            //filename = filename.Replace(" ", "");

            //filename = filename.Replace(":", "");

            //filename = filename.Replace("-", "");

            //filename = filename.Replace(".", "");
            //filename = filename.Replace("/", "");

            //bt.Save(Server.MapPath("/images/") + filename + ".jpg");

            //this.Image1.ImageUrl = "/images/" + filename + ".jpg";

        }
    }
}