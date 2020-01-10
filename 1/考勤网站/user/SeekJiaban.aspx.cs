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

public partial class user_SeekJiaban : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Session["number"] == null)
            {
                Response.Write("<script>alert('登录时间过期，请重新登录');window.location='../login.aspx';</script>");
                return;
            }
            Calendar1.Visible = false;
            Calendar2.Visible = false;
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
    protected void Calendar2_SelectionChanged(object sender, EventArgs e)
    {
        endtime.Text = Calendar1.SelectedDate.ToString();
        if (!(endtime.Text == ""))
        {
            Calendar2.Visible = false;

            endtime.Text = Calendar2.SelectedDate.ToString("yyyy-MM-dd");
        }
    }
    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        Calendar2.Visible = true;
        Calendar1.Visible = false;
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        Calendar1.Visible = true;
        Calendar2.Visible = false;
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
    protected void gvShow1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvShow1.PageIndex = e.NewPageIndex;
        GridViewDataBind(1);
    }
    protected void gvShow2_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvShow2.PageIndex = e.NewPageIndex;
        GridViewDataBind(2);
    }
    protected void gvShow3_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvShow3.PageIndex = e.NewPageIndex;
        GridViewDataBind(3);
    }
    protected void gvShow4_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvShow4.PageIndex = e.NewPageIndex;
        GridViewDataBind(4);
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





        }
    }


    protected void gvShow1_Sorting(object sender, GridViewSortEventArgs e)
    {
        DataTable tb = Session["Table"] as DataTable;
        tb.DefaultView.Sort = e.SortExpression;
        gvShow1.DataSource = tb;
        gvShow1.DataBind();
    }
    protected void gvShow2_Sorting(object sender, GridViewSortEventArgs e)
    {
        DataTable tb = Session["Table"] as DataTable;
        tb.DefaultView.Sort = e.SortExpression;
        gvShow2.DataSource = tb;
        gvShow2.DataBind();
    }
    protected void gvShow3_Sorting(object sender, GridViewSortEventArgs e)
    {
        DataTable tb = Session["Table"] as DataTable;
        tb.DefaultView.Sort = e.SortExpression;
        gvShow3.DataSource = tb;
        gvShow3.DataBind();
    }
    protected void gvShow4_Sorting(object sender, GridViewSortEventArgs e)
    {
        DataTable tb = Session["Table"] as DataTable;
        tb.DefaultView.Sort = e.SortExpression;
        gvShow4.DataSource = tb;
        gvShow4.DataBind();
    }
    public void checktime(int i)
    {
        DateTime time1 = Convert.ToDateTime(startime.Text);
        DateTime time2 = Convert.ToDateTime(endtime.Text);
        if (time1 > time2)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('开始时间大于结束时间，请重新选择')</script>");


        }
        else
        {
            System.TimeSpan ND = time2 - time1;
            int n = ND.Days;   //天数差
            if (n > 31)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('只能查询31天以内的记录，请重新选择')</script>");

            }
            else
            {
                GridViewDataBind(i);

            }
        }
    
    }
   
    public void GridViewDataBind(int i)
    {
        if (i == 1)
        {
            gvShow1.Visible = true;
            gvShow2.Visible = false;
            gvShow3.Visible = false;
            gvShow4.Visible = false;
            string sql;
            sql = makesql_table1(1);

            DataSet ds = SqlHelper.ExecuteDataSet(sql);
            Session["Table"] = ds.Tables[0];
            gvShow1.DataSource = ds;
            gvShow1.DataBind();
        }
        if (i == 2)
        {
            gvShow1.Visible = false;
            gvShow2.Visible = true;
            gvShow3.Visible = false;
            gvShow4.Visible = false;
            string sql;
            sql = makesql_table1(2);

            DataSet ds = SqlHelper.ExecuteDataSet(sql);
            Session["Table"] = ds.Tables[0];
            gvShow2.DataSource = ds;
            gvShow2.DataBind();
        }
        if (i == 3)
        {
            gvShow1.Visible = false;
            gvShow2.Visible = false;
            gvShow3.Visible = true;
            gvShow4.Visible = false;
            string sql;
            sql = makesql_table1(3);

            DataSet ds = SqlHelper.ExecuteDataSet(sql);
            Session["Table"] = ds.Tables[0];
            gvShow3.DataSource = ds;
            gvShow3.DataBind();
        }
        if (i == 4)
        {
            gvShow1.Visible = false;
            gvShow2.Visible = false;
            gvShow3.Visible = false;
            gvShow4.Visible = true;
            string sql;
            sql = makesql_table1(4);

            DataSet ds = SqlHelper.ExecuteDataSet(sql);
            Session["Table"] = ds.Tables[0];
            gvShow4.DataSource = ds;
            gvShow4.DataBind();
        }

    }
    protected string makesql_table1(int i)
    {
        string _result = "";
        if (startime.Text != "" && endtime.Text != "")
        {
            if (i == 1)
            {
                _result = "select * from [jiaban] where u_jiadate>'" + startime.Text + "'and u_number='" + Session["number"] + "' ";
            }
            if (i ==2)
            {
                _result = "select * from [chuchai] where c_startdate>'" + startime.Text + "' and c_number='" + Session["number"] + "' ";
            }
            if (i == 3)
            {
                _result = "select * from [qingjia] where q_startdate>'" + startime.Text + "' and q_number='" + Session["number"] + "' ";
            }
            if (i == 4)
            {
                _result = "select * from [cardinf] where c_time>'" + startime.Text + "' and  c_time<'" + Calendar2.SelectedDate.AddDays(1).ToString("yyyy-MM-dd") + "' and c_id='" + Session["number"] + "' ";
            }

        }

        return _result;
    }
    protected void jiaban_Click(object sender, EventArgs e)
    {

        checktime(1);

    }
   
    protected void chuchai_Click(object sender, EventArgs e)
    {
        if (Session["number"] == null)
        {
            Response.Write("<script>alert('登录时间过期，请重新登录');window.location='../login.aspx';</script>");
            return;
        }
        checktime(2);
    }
    protected void qingjia_Click(object sender, EventArgs e)
    {
        if (Session["number"] == null)
        {
            Response.Write("<script>alert('登录时间过期，请重新登录');window.location='../login.aspx';</script>");
            return;
        }
        checktime(3);
    }
    protected void shuaka_Click(object sender, EventArgs e)
    {
        if (Session["number"] == null)
        {
            Response.Write("<script>alert('登录时间过期，请重新登录');window.location='../login.aspx';</script>");
            return;
        }
        checktime(4);

    }
}