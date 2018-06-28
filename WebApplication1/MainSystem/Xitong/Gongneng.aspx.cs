using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using BLL;
using Model;

namespace WebApplication1.MainSystem.Xitong
{
    public partial class Gongneng : System.Web.UI.Page
    {
        protected BLL_Gongneng bGongneng = new BLL_Gongneng();
        protected xt_result result = new xt_result();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                getDaima();
                getData();
            }
           
        }
        /// <summary>
        /// 全选、反选
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void RadioButtonList_canshu_SelectedIndexChanged(object sender, EventArgs e)
        {

            for (int i = 0; i < CheckBoxList_canshu.Items.Count; i++)
            {
                if (RadioButtonList_canshu.SelectedValue == "1")
                {
                    CheckBoxList_canshu.Items[i].Selected = true;
                }
                else
                {
                    CheckBoxList_canshu.Items[i].Selected = CheckBoxList_canshu.Items[i].Selected ? false : true;
                }
            }
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //DataTable dt = bGongneng.chaxun();
            string pZubie = DropDownList_zubie.SelectedValue.ToString();
            DataTable dt = bGongneng.getChaxun(pZubie);
            TreeView3.Nodes.Clear();
            Treeview3_databind(dt);
            treeview1_databind("000");
     
        }

        /// <summary>
        /// 生成菜单树
        /// </summary>
        /// <param name="fenzu"></param>
        protected void treeview1_databind(string fenzu)
        {

            string pYingyong = RadioButtonList_Yingyong.SelectedValue.ToString();
            string pZubie = DropDownList_zubie.SelectedValue;
            //DataTable dt = bZubie.getCaidan(pYingyong, pZubie);
            DataTable dt = bGongneng.getDataCaidan(pYingyong);
            getCaidanTree(dt, TreeView1, null);
            TreeView1.CollapseAll();

        }


        protected void Button_save_Click(object sender, EventArgs e)
        {
              gongneng mGongneng = new gongneng();
            mGongneng.Yingyong = RadioButtonList_Yingyong.SelectedValue;
            string pCanshu;

            // 取参数
            for (int j = 0; j < CheckBoxList_canshu.Items.Count; j++)
            {
                if (CheckBoxList_canshu.Items[j].Selected)
                    pCanshu = "1";
                else
                    pCanshu = "0";

                switch (j)
                {
                    case 0:
                        mGongneng.Canshu0 = pCanshu;
                        break;
                    case 1:
                        mGongneng.Canshu1 = pCanshu;
                        break;

                    case 2:
                        mGongneng.Canshu2 = pCanshu;
                        break;
                    case 3:
                        mGongneng.Canshu3 = pCanshu;
                        break;
                    case 4:
                        mGongneng.Canshu4 = pCanshu;
                        break;
                    case 5:
                        mGongneng.Canshu5 = pCanshu;
                        break;
                    case 6:
                        mGongneng.Canshu6 = pCanshu;
                        break;
                    case 7:
                        mGongneng.Canshu7 = pCanshu;
                        break;
                    case 8:
                        mGongneng.Canshu8 = pCanshu;
                        break;
                    case 9:
                        mGongneng.Canshu9 = pCanshu;
                        break;
                }
            }

            //   循环取treeview3 父节点的数据 
            for (int j = 0; j < TreeView3.Nodes.Count; j++)
            {
                if (TreeView3.Nodes[j].Checked)
                {

                    mGongneng.Daihao = TreeView3.Nodes[j].Value.ToString();

                    for (int i = 0; i < TreeView1.Nodes.Count; i++)
                    {
                        if (TreeView1.Nodes[i].Checked)
                        {
                            mGongneng.Xuhao = TreeView1.Nodes[i].Value.ToString();
                            mGongneng.Bianhao = TreeView1.Nodes[i].Value.ToString();
                            mGongneng.Mingcheng = TreeView1.Nodes[i].Text.ToString();
                            if (checkgongnengcanshu(mGongneng) == 1)
                            {
                                result = bGongneng.DelGongneng(mGongneng);
                                if (result.ReturnInt < 0)
                                {
                                    ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "<script>alert('用户功能权限分配失败，请联系管理员！')</script>", false);
                                    break;
                                }
                            }
                            else
                            {
                                result = bGongneng.DelGongneng(mGongneng);
                                result = bGongneng.InsertGongneng(mGongneng);
                            }
                            // 循环取父节点 下子节点的数据
                            getChildNodevalue(TreeView1.Nodes[i], mGongneng);

                        }
                        else
                            // 在不经过父节点的情况下  取子节点数据
                            getChildNodevalue(TreeView1.Nodes[i], mGongneng);
                    }

                }
            }
            ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "<script>alert('用户功能权限分配成功！')</script>", false);
        }
        /// <summary>
        /// 取父节点下子节点的数据，进行删除！
        /// </summary>
        /// <param name="tn"></param>
        /// <param name="mGongneng"></param>
        protected void getChildNodevalue(TreeNode tn, gongneng mGongneng)
        {
            for (int i = 0; i < tn.ChildNodes.Count; i++)
            {
                if (tn.ChildNodes[i].Checked)
                {
                    mGongneng.Xuhao = tn.ChildNodes[i].Value.ToString();
                    mGongneng.Bianhao = tn.ChildNodes[i].Value.ToString();
                    mGongneng.Mingcheng = tn.ChildNodes[i].Text.ToString();

                    if (checkgongnengcanshu(mGongneng) == 1)
                    {
                        //如果没有功能则直接删除数据库当中的对应列
                        result = bGongneng.DelGongneng(mGongneng);
                        if (result.ReturnInt < 0)
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "<script>alert('用户功能权限分配失败，请联系管理员！')</script>", false);
                            break;
                        }


                    }
                    else
                    {
                        //如果有功能权限，则先删在增加
                        result = bGongneng.DelGongneng(mGongneng);
                        result = bGongneng.InsertGongneng(mGongneng);

                        if (result.ReturnInt < 0)
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "<script>alert('用户功能权限分配失败，请联系管理员！')</script>", false);
                            break;
                        }

                    }
                }
            }

        }
        
        /// <summary>
        /// 代码表
        /// </summary>
        protected void getDaima()
        {
            DataTable dt = bGongneng.chaxun("yonghu");
            setDropDownList(DropDownList_zubie, dt, "mingcheng", "daihao", "--请选择--", "");
        }
        protected void getData()
        {
            DataTable dt = bGongneng.chaxun();
            setRadioButtonList(RadioButtonList_Yingyong, dt, "yingyong", "", "", "");
        }


        /// <summary>
        /// 设置DropDownList
        /// </summary>
        /// <param name="pDropDownList">DropDownList</param>
        /// <param name="dt">数据源</param>
        /// <param name="pText">文本</param>
        /// <param name="pValue">值</param>
        /// <param name="pNewItemText">新增项文本</param>
        /// <param name="pNewItemValue">新增项值</param>
        public void setDropDownList(DropDownList pDropDownList, DataTable dt, string pText, string pValue, string pNewItemText, string pNewItemValue)
        {
            pDropDownList.DataSource = dt;
            pDropDownList.DataTextField = pText;
            pDropDownList.DataValueField = pValue;
            pDropDownList.DataBind();
            if (pNewItemText != "")
            {
                pDropDownList.Items.Insert(0, new ListItem(pNewItemText, pNewItemValue));
            }
        }


        /// <summary>
        /// 设置RadioButtonList
        /// </summary>
        /// <param name="pRadioButtonList">RadioButtonList</param>
        /// <param name="dt">数据源</param>
        /// <param name="pText">文本</param>
        /// <param name="pValue">值</param>
        /// <param name="pNewItemText">新增项文本</param>
        /// <param name="pNewItemValue">新增项值</param>
        public void setRadioButtonList(RadioButtonList pRadioButtonList, DataTable dt, string pText, string pValue, string pNewItemText, string pNewItemValue)
        {
            pRadioButtonList.DataSource = dt;
            pRadioButtonList.DataTextField = pText;
            pRadioButtonList.DataValueField = pValue;
            pRadioButtonList.DataBind();
            if (pNewItemText != "")
            {
                pRadioButtonList.Items.Insert(0, new ListItem(pNewItemText, pNewItemValue));
            }
        }
 /// <summary>
        ///  判断功能是否存在
        /// </summary>
        /// <param name="mGongneng"></param>
        /// <returns></returns>
        protected int checkgongnengcanshu(gongneng mGongneng)
        {
            if (mGongneng.Canshu0 == "0")
            {
                return 1;

            }
            else
            {
                return 0;
            }
        }
        /// <summary>
        /// 点中父类，展开子类
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void TreeView1_SelectedNodeChanged(object sender, EventArgs e)
        {
            //点击根节点
            if (TreeView1.SelectedValue.Substring(2, 4).Equals("0000"))
            {
                TreeView1.CollapseAll();
                TreeView1.SelectedNode.Expanded = true;
            }
            bool bCheck = TreeView1.SelectedNode.Checked;
            for (int i = 0; i < TreeView1.SelectedNode.ChildNodes.Count; i++)
            {
                TreeView1.SelectedNode.ChildNodes[i].Checked = bCheck;

            }
        }
        /// <summary>
        /// 点中父类，展开子类
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void TreeView2_SelectedNodeChanged(object sender, EventArgs e)
        {
            //点击根节点
            if (TreeView2.SelectedValue.Substring(2, 4).Equals("0000"))
            {
                TreeView2.CollapseAll();
                TreeView2.SelectedNode.Expanded = true;
                return;
            }
            //当前用户当前菜单功能分配
            gongneng mGongneng = new gongneng();
            string pBianhao = TreeView2.SelectedValue;
            mGongneng.Daihao = yonghuLabel.Text;
            mGongneng.Yingyong = RadioButtonList_Yingyong.SelectedValue.ToString();
            mGongneng.Bianhao = TreeView2.SelectedValue;
            DataTable dt = bGongneng.getGongneng_Bianhao(mGongneng);
            if (dt.Rows.Count < 1)
            {
                return;
            }

            for (int i = 0; i < 10; i++)
            {
                if (dt.Rows[0]["canshu" + i.ToString()].ToString().Equals("1"))
                    CheckBoxList_canshu.Items[i].Selected = true;
                else
                    CheckBoxList_canshu.Items[i].Selected = false;
            }
        }

        protected void getCaidanTree(DataTable dt1, TreeView pTreeView, DataTable dt2)
        {
            //dt1.Columns.Add("fuxuhao");
            //增加父菜单列
            int a = dt1.Rows.Count;
            foreach (DataRow row in dt1.Rows)
            {
                string str_xh = row["bianhao"].ToString();
                if (str_xh == "000000")//根菜单
                {
                    row["fuxuhao"] = null;
                }
                else if (str_xh.Substring(2) == "0000" && str_xh != "000000")//一级菜单
                {
                    row["fuxuhao"] = "000000";
                }
                else if (str_xh.Substring(0, 2) != "00" && str_xh.Substring(2, 2) != "00" && str_xh != "000000" && str_xh.Substring(4) == "00")//二级菜单
                {
                    row["fuxuhao"] = str_xh.Substring(0, 2) + "0000";
                }
                else if (str_xh.Substring(0, 2) != "00" && str_xh.Substring(2, 2) != "00" && str_xh.Substring(4) != "00")//三级菜单
                {
                    row["fuxuhao"] = str_xh.Substring(0, 4) + "00";
                }
            }

            //绑定根菜单
            bindtree(dt1, pTreeView, dt2);
        }
        private void bindtree(DataTable dt1, TreeView pTreeView, DataTable dt2)
        {
            pTreeView.Nodes.Clear();
            AddTree("000000", (TreeNode)null, dt1, pTreeView, dt2);

        }

        //递归绑定树菜单
        protected void AddTree(string ParentXuHao, TreeNode pNode, DataTable dt1, TreeView pTreeView, DataTable dt2)
        {

            DataView dvTree = new DataView(dt1);
            //过滤ParentID,得到当前的所有子节点 
            dvTree.RowFilter = "fuxuhao = " + ParentXuHao;

            foreach (DataRowView Row in dvTree)
            {
                Random random = new Random();
                TreeNode Node = new TreeNode();
                if (pNode == null)
                { //添加根节点 
                    Node.Text = Row["mingcheng"].ToString();
                    Node.Value = Row["bianhao"].ToString();
                    if (dt2 != null)
                    {
                        DataRow dRow = dt2.Rows.Find(Row["bianhao"].ToString());
                        if (dRow != null)
                        {
                            if (dRow["canshu0"].ToString().Equals("1"))
                                Node.Checked = true;
                            else
                                Node.Checked = false;
                        }
                    }
                    pTreeView.Nodes.Add(Node);

                    AddTree(Row["bianhao"].ToString(), Node, dt1, pTreeView, dt2); //再次递归 
                }
                else
                { //添加当前节点的子节点 
                    Node.Text = Row["mingcheng"].ToString();
                    Node.Value = Row["bianhao"].ToString();
                    if (dt2 != null)
                    {
                        DataRow dRow = dt2.Rows.Find(Row["bianhao"].ToString());
                        if (dRow != null)
                        {
                            if (dRow["canshu0"].ToString().Equals("1"))
                                Node.Checked = true;
                            else
                                Node.Checked = false;
                        }
                    }
                    pNode.ChildNodes.Add(Node);
                    AddTree(Row["bianhao"].ToString(), Node, dt1, pTreeView, dt2); //再次递归 
                }
            }
        }


        /// <summary>
        /// 查看用户功能 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void RadioButtonList_shouquan_SelectedIndexChanged(object sender, EventArgs e)
        {
            gongneng mGongneng = new gongneng();
            mGongneng.Daihao = yonghuLabel.Text;
            mGongneng.Yingyong = RadioButtonList_Yingyong.SelectedValue;
            mGongneng.Canshu0 = RadioButtonList_shouquan.SelectedValue;
            DataTable dt = bGongneng.getGongneng_Yonghu(mGongneng);
            dt.PrimaryKey = new DataColumn[] { dt.Columns["bianhao"] };
            TreeView2.Nodes.Clear();
            getCaidanTree(dt, TreeView2, null);
        }

        /// <summary>
        /// 取子节点的数据
        /// </summary>
        /// <param name="tn"></param>
        /// <param name="mZubie_gongneng"></param>
        protected void TreeView3_SelectedNodeChanged(object sender, EventArgs e)
        {
            string pYonghu = TreeView3.SelectedValue;
            yonghuLabel.Text = pYonghu;
        }



        /// <summary>
        /// 绑定treeview3的数据
        /// </summary>
        /// <param name="dt"></param>
        protected void Treeview3_databind(DataTable dt)
        {
            DataView dvTree = new DataView(dt);
            //过滤ParentID,得到当前的所有子节点 

            foreach (DataRowView Row in dvTree)
            {
                Random random = new Random();
                TreeNode Node = new TreeNode();

                Node.Text = Row["daihao"].ToString() + "." + Row["mingcheng"].ToString();
                Node.Value = Row["daihao"].ToString();
                TreeView3.Nodes.Add(Node);

                //    AddTree(Row["daihao"].ToString(), Node, dt1, pTreeView); //再次递归 
            }
        }

        protected void RadioButtonList_Yingyong_SelectedIndexChanged(object sender, EventArgs e)
        {
            treeview1_databind("000");
        }
    }
}