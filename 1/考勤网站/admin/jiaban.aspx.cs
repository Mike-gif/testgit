using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;
using DBHelper;


public partial class admin_jiaban : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Calendar1.Visible = false;
        if (!Page.IsPostBack)
        {
            GridViewDataBind();

        }

    }
    protected void Calendar1_SelectionChanged(object sender, EventArgs e)
    {
        startime.Text = Calendar1.SelectedDate.ToString();
        if (!(startime.Text == ""))
        {
            Calendar1.Visible = false;

            startime.Text = Calendar1.SelectedDate.ToString("yyyy-MM-dd");
        }
    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        Calendar1.Visible = true;
        
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList2.SelectedItem.Text = DropDownList1.SelectedItem.Value;
    }
    protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList1.SelectedItem.Text = DropDownList2.SelectedItem.Value;

    }
    /// 绑定数据
    /// </summary>
    /// 

    public void GridViewDataBind()
    {



        string sql1 = "select * from [jiaban]";

        DataSet ds = SqlHelper.ExecuteDataSet(sql1);
        Session["Table"] = ds.Tables[0];
        gvShow.DataSource = ds;
        gvShow.DataBind();
    }


    /// <summary>
    /// 返回备注信息
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    public string returnRemark(object obj)
    {
        if (string.IsNullOrEmpty(obj.ToString()))
            return "默认";
        else
            return obj.ToString();
    }


    /// <summary>
    /// 单击【下一页】按钮
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvShow_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvShow.PageIndex = e.NewPageIndex;
        GridViewDataBind();
    }

    /// <summary>
    /// 显示高亮效果
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvShow_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes.Add("onmouseover", "currentcolor=this.style.backgroundColor;this.style.backgroundColor='lightblue'");
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=currentcolor");


            LinkButton btn = e.Row.FindControl("lbDelete") as LinkButton;
            btn.Attributes.Add("onclick", "return confirm('确定要删除该联系人记录吗？')");


        }
    }

    /// <summary>
    /// 单击某行的操作时
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvShow_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        string opername = e.CommandName;
        string opervalue = e.CommandArgument.ToString();
        if (opername == "Delete")
        {

            string sql2 = "delete from [jiaban] where ID=@ID";
            SqlParameter[] sps2 = new SqlParameter[] { 
            new SqlParameter("@ID", Convert.ToInt32(opervalue)),
            };

            int result = SqlHelper.ExecuteNonQuery(sql2, sps2);
            if (result > 0)
                Response.Redirect("jiaban.aspx");

        }
        //else if (opername == "Edit")
        //    Response.Redirect("Edit_manage.aspx?operfun=edit&operid=" + Convert.ToInt32(opervalue));

    }

    /// <summary>
    /// 排序
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvShow_Sorting(object sender, GridViewSortEventArgs e)
    {
        DataTable tb = Session["Table"] as DataTable;
        tb.DefaultView.Sort = e.SortExpression;
        gvShow.DataSource = tb;
        gvShow.DataBind();
    }

    protected void lbDelete_Command(object sender, CommandEventArgs e)
    {
        string oper = e.CommandName;
        if (oper == "delOne")
        {
            string ids = "";
            for (int i = 0; i < this.gvShow.Rows.Count; i++)
            {
                CheckBox cb = (CheckBox)this.gvShow.Rows[i].Cells[0].FindControl("cbCheck");
                if (cb.Checked)
                    ids += cb.Text + ",";
            }
            if (string.IsNullOrEmpty(ids))
                ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('请选择您要删除的一个或多个用户！')</script>");
            else
            {
                string[] delids = ids.Trim(',').Split(',');
                foreach (string item in delids)
                {
                    string sql3 = "delete from [jiaban] where ID=@ID";
                    SqlParameter[] sps3 = new SqlParameter[]
                    {new SqlParameter("@ID", Convert.ToInt32(item)),
                    };


                    int result = SqlHelper.ExecuteNonQuery(sql3, sps3);
                    if (result > 0)
                    {

                        GridViewDataBind();
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('删除用户信息失败！')</script>");
                    }

                }

                GridViewDataBind();
            }
        }
    }

 


    protected void Button1_Click1(object sender, EventArgs e)
    {

        string sql4 = "insert into [jiaban](u_number,u_name,u_jiatime,u_jiadate)values(@u_number,@u_name,@u_jiatime,@u_jiadate)";
        SqlParameter[] sps4 = new SqlParameter[4];
        sps4[0] = new SqlParameter("@u_number", DropDownList1.SelectedItem.Text);
        sps4[1] = new SqlParameter("@u_name", DropDownList2.SelectedItem.Text);
        sps4[2] = new SqlParameter("@u_jiatime", time1.Text);
        sps4[3] = new SqlParameter("@u_jiadate", startime.Text);



        int i = SqlHelper.ExecuteNonQuery(sql4, sps4);


        if (i > 0)
        {
            gvShow.DataBind();
            GridViewDataBind();
            Response.Redirect("jiaban.aspx");
        }
        //Response.Write("<script>alert('添加成功');window.location='information.aspx';</script>");
    }
}
