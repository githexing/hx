<%@ WebHandler Language="C#" Class="test" Debug=true %>

using System;
using System.Web;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text;
using System.Text.RegularExpressions;

using ThoughtWorks.QRCode.Codec;
using ThoughtWorks.QRCode.Codec.Data;
using ThoughtWorks.QRCode.Codec.Util;
public class test : IHttpHandler
{

    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "text/plain";
        string cmd = context.Request["cmd"] == null ? "get" : context.Request["cmd"].ToString();
        string filename = string.Empty;
        string filepath = string.Empty;
        switch (cmd)
        {
            case "get":
                if (context.Request.Files.Count > 0)
                {
                    for (int j = 0; j < context.Request.Files.Count; j++)
                    {
                        filename = Guid.NewGuid().ToString() + "_tmp.jpg";
                        filepath = context.Server.MapPath(@"~\upload") + "\\" + filename;
                        string qrdecode = string.Empty;
                        HttpPostedFile uploadFile = context.Request.Files[j];
                        uploadFile.SaveAs(filepath);

                        QRCodeDecoder decoder = new QRCodeDecoder();
                        Bitmap bm = new Bitmap(filepath);
                        qrdecode = decoder.decode(new QRCodeBitmapImage(bm));
                        bm.Dispose();

                        context.Response.Write("[{\"count\":1,\"list\":[{\"imgurl\":\"upload/" + filename + "\",\"qrtext\":\"" + qrdecode + "\"}]}]");
                    }
                }
                else
                {
                    context.Response.Write("[{\"count\":0,\"list\":[{\"error\":\"没有上传文件\"}]}]");
                }
                break;
            case "set":
                string txt_qr = ConverToGB(context.Request["txt_qr"].ToString().Trim(), 16);
                string qrEncoding = context.Request["qrEncoding"].ToString();
                string Level = context.Request["Level"].ToString();
                string txt_ver = context.Request["txt_ver"].ToString();
                string txt_size = context.Request["txt_size"].ToString();

                QRCodeEncoder qrCodeEncoder = new QRCodeEncoder();
                String encoding = qrEncoding;
                if (encoding == "Byte")
                {
                    qrCodeEncoder.QRCodeEncodeMode = QRCodeEncoder.ENCODE_MODE.BYTE;
                }
                else if (encoding == "AlphaNumeric")
                {
                    qrCodeEncoder.QRCodeEncodeMode = QRCodeEncoder.ENCODE_MODE.ALPHA_NUMERIC;
                }
                else if (encoding == "Numeric")
                {
                    qrCodeEncoder.QRCodeEncodeMode = QRCodeEncoder.ENCODE_MODE.NUMERIC;
                }
                try
                {
                    int scale = Convert.ToInt16(txt_size);
                    qrCodeEncoder.QRCodeScale = scale;
                }
                catch (Exception ex)
                {
                    return;
                }
                try
                {
                    int version = Convert.ToInt16(txt_ver);
                    qrCodeEncoder.QRCodeVersion = version;
                }
                catch (Exception ex)
                {
                    return;
                }
                string errorCorrect = Level;
                if (errorCorrect == "L")
                    qrCodeEncoder.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.L;
                else if (errorCorrect == "M")
                    qrCodeEncoder.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.M;
                else if (errorCorrect == "Q")
                    qrCodeEncoder.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.Q;
                else if (errorCorrect == "H")
                    qrCodeEncoder.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.H;

                Image image;
                String data = txt_qr;
                image = qrCodeEncoder.Encode(data);
                filename = Guid.NewGuid().ToString() + ".jpg";
                filepath = context.Server.MapPath(@"~\upload") + "\\" + filename;
                System.IO.FileStream fs = new System.IO.FileStream(filepath, System.IO.FileMode.OpenOrCreate, System.IO.FileAccess.Write);
                image.Save(fs, System.Drawing.Imaging.ImageFormat.Jpeg);
                fs.Close();
                image.Dispose();
                context.Response.Write("[{\"count\":1,\"list\":[{\"imgurl\":\"upload/" + filename + "\"}]}]");

                //context.Response.Write(@"upload\" + filename);  
                break;
        }

    }
    /// <summary>  
    /// 10进制或16进制转换为中文  
    /// </summary>  
    /// <param name="name">要转换的字符串</param>  
    /// <param name="fromBase">进制（10或16）</param>  
    /// <returns></returns>  
    public string ConverToGB(string text, int fromBase)
    {
        string value = text;
        MatchCollection mc;
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        switch (fromBase)
        {
            case 10:

                MatchCollection mc1 = Regex.Matches(text, @"&#([\d]{5})", RegexOptions.Compiled | RegexOptions.IgnoreCase);
                foreach (Match _v in mc1)
                {
                    string w = _v.Value.Substring(2);
                    w = Convert.ToString(int.Parse(w), 16);
                    byte[] c = new byte[2];
                    string ss = w.Substring(0, 2);
                    int c1 = Convert.ToInt32(w.Substring(0, 2), 16);
                    int c2 = Convert.ToInt32(w.Substring(2), 16);
                    c[0] = (byte)c2;
                    c[1] = (byte)c1;
                    sb.Append(Encoding.Unicode.GetString(c));
                }
                value = sb.ToString();

                break;
            case 16:
                mc = Regex.Matches(text, @"\\u([\w]{2})([\w]{2})", RegexOptions.Compiled | RegexOptions.IgnoreCase);
                if (mc != null && mc.Count > 0)
                {

                    foreach (Match m2 in mc)
                    {
                        string v = m2.Value;
                        string w = v.Substring(2);
                        byte[] c = new byte[2];
                        int c1 = Convert.ToInt32(w.Substring(0, 2), 16);
                        int c2 = Convert.ToInt32(w.Substring(2), 16);
                        c[0] = (byte)c2;
                        c[1] = (byte)c1;
                        sb.Append(Encoding.Unicode.GetString(c));
                    }
                    value = sb.ToString();
                }
                break;
        }
        return value;
    }
    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

} 