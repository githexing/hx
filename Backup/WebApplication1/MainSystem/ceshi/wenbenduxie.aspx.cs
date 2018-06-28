using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace WebApplication1.MainSystem.ceshi
{
    public partial class wenbenduxie : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            {
                try
                {
                    // 创建一个 StreamReader 的实例来读取文件 
                    // using 语句也能关闭 StreamReader
                    using (StreamReader sr = new StreamReader("d:/names.txt"))
                    {
                        string line;

                        // 从文件读取并显示行，直到文件的末尾 
                        while ((line = sr.ReadLine()) != null)
                        {
                            Console.WriteLine(line.ToString()); 
                        }
                    }
                }
                catch (Exception ex)
                {
                    // 向用户显示出错消息
                    Console.WriteLine("The file could not be read:");
                    Console.WriteLine(ex.Message);
                }
                //Console.ReadKey();
                Console.Read();
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string[] names = new string[] { "Zara Ali", "Nuha Ali" };
            using (StreamWriter sw = new StreamWriter("d:/names.txt"))
            {
                foreach (string s in names)
                {
                    sw.WriteLine(s);

                }
            }
                
            // 从文件中读取并显示每行
            string line = "";
            List<string> list = new List<string>();
            using (StreamReader sr = new StreamReader("d:/names.txt"))
            {
                while ((line = sr.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                    list.Add(line); 
                }
                Label2.Text = "";
                TextBox1.Text = "";
                for (int i = 0; i < list.Count; i++)
                {
                    Label2.Text += list[i]+" ";
                    TextBox1.Text += list[i] + " ";
                }
               
            }
            //Console.ReadKey();
        }
    }
}