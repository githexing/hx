using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI; 
using System.Web.UI.WebControls;
using Model;

namespace WebApplication1.MainSystem.ceshi
{
    public partial class xt_suiji : System.Web.UI.Page
    {
        Random random = new Random();//生成随机数
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            panduanshuju();
        }
        public void panduanshuju()//处理数据
        {

            List<int> num = new List<int>();
            int max = 0;
            for (int i = 0; i < 2 + max; i++)
            {
                int o = random.Next(2);
                int sa = num.IndexOf(o);
                if (sa <= -1)
                {
                    int a = int.Parse(o.ToString());
                    num.Add(a);
                }
                else
                {
                    max = max + 1;
                }


            }
            Label1.Text = num.Count.ToString();

            //List<int> num = new List<int>();
            //for (int i = 0; i < 8; i++)//生成八个随机数
            //{
            //    num[i] = random.Next(10, 100);//随机数在10—100以内波动
            //}
            //if (num[2] < num[3])//调用类，判断num[2]num[3]大小
            //{
            //    //zhiclass.jiaohuan(ref num[2], ref num[3]);//调用类的交换段，a与num[2] b与num[3]相关联
            //}
            //num[6] = num[6] * num[7];//实现整除
        }
    }
}