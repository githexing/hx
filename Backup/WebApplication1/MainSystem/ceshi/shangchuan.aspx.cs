using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AppCommon;
using BLL;
using System.Data;

namespace WebApplication1.MainSystem.ceshi
{
    public partial class shangchuan : System.Web.UI.Page
    {
        BLL_Yonghu bYonghu = new BLL_Yonghu();
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
      
        
        protected void Button2_Click(object sender, EventArgs e)
        {
            bool fileOK = false;
            //判断upload是否有文件
            if (FileUpload1.HasFile)
            {
                String fileExtension = System.IO.Path.GetExtension(FileUpload1.FileName).ToLower();
                String[] allowedExtensions = { ".gif", ".png", ".jpeg", ".jpg" }; //防止垃圾上传
                for (int i = 0; i < allowedExtensions.Length; i++)
                    if (fileExtension == allowedExtensions[i])
                    { fileOK = true; }
            }
            else if (FileUpload1.HasFile == false)
            {//upload有文件但是垃圾文件不是图片
                ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "<script>alert('请选择要上传的文件！ ')</script>", false);
            }
            if (fileOK)
            { //有文件且是图片
                string path = Server.MapPath("~/images/");
                string postaddpath = DateTime.Now.ToString("yyyyMMddhhmmss");
                FileUpload1.PostedFile.SaveAs(path + postaddpath + ".jpg");
                //FileUpload1.SaveAs(path);
                FileUpload1.Dispose();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "<script>alert('上传成功！ ')</script>", false);
                //allpath = "image/BBspost/" + postaddpath + ".jpg";
                //write();
              
                
            }

        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            string pSavePath = Server.MapPath("~/XLS/");
            if (!FileUpload1.HasFile)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "<script>alert('请选择要上传的文件！ ')</script>", false);
                return;
            }
            string pFileName = FileUpload1.FileName;
            pSavePath += pFileName;
            FileUpload1.SaveAs(pSavePath);
            FileUpload1.Dispose();
            int i = pFileName.Length - 4;
            if (pFileName.Substring(i) == ".zip")
            {
                CompresssFiles.UnZip(pSavePath, Server.MapPath("~/XLS/"));
            }
            ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "<script>alert('上传成功！ 文件名为：" + FileUpload1.FileName + "  文件类型为：" + FileUpload1.PostedFile.ContentType + "  文件大小为：" + FileUpload1.PostedFile.ContentLength + "')</script>", false);

        }

    }
}