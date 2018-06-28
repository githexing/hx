using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Timers;

namespace WebApplication1
{
    public partial class WebForm5 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        private void button2_Click(object sender, EventArgs e)
        {
          
        }

        public void getData()
        {
           

        }
        private void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "<script>alert('上传成功！ ')</script>", false);
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            System.Timers.Timer t = new System.Timers.Timer(5000);//实例化Timer类，设置间隔时间为10000毫秒；   
            t.Elapsed += new System.Timers.ElapsedEventHandler(OnTimedEvent);//到达时间的时候执行事件；   
            t.AutoReset = false;//设置是执行一次（false）还是一直执行(true)；   
            t.Enabled = true;//是否执行System.Timers.Timer.Elapsed事件；  
        }
    }
}