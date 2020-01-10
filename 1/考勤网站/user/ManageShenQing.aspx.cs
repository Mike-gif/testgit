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

public partial class user_ManageShenQing : System.Web.UI.Page
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

            GridViewDataBind();
        }

    }
    /// 绑定数据
    /// </summary>
    /// 

    public void GridViewDataBind()
    {

        string sql2 = "select * from [qingjia] where q_number IN (select number from [userinfo] where shangji='" + Session["number"] + "') ORDER BY q_statue asc,q_enddate DESC";
        DataSet ds2 = SqlHelper.ExecuteDataSet(sql2);
        Session["Table"] = ds2.Tables[0];
        gvShow.DataSource = ds2;
        gvShow.DataBind();

        foreach (GridViewRow row in gvShow.Rows)
        {
            LinkButton ChaKan = row.Cells[7].FindControl("lbChaKan") as LinkButton;

            ChaKan.Visible = false;
            string opervalue = row.Cells[0].Text;
            //  System.Diagnostics.Debug.Write("opervalue =" + opervalue);
            //System.Diagnostics.Debug.Assert(false, opervalue);//打印调试信息
            String sql10 = "SELECT ImageUrl FROM [qingjia] where id='" + opervalue + "'";
            //             System.Diagnostics.Debug.Assert(false, sql10);//打印调试信息
            DataTable dt_Url = SqlHelper.ExecuteDataTable(sql10);
            int i_all = dt_Url.Rows.Count;
            //  string Url = dt_Url.Rows[0][0].ToString();
            // System.Diagnostics.Debug.Write("dt_Url =" + Url);
            if (dt_Url.Rows[0][0].ToString() != "") //判断读到的ImageUrl不为空时，出现查看凭证按钮
            {
                ChaKan.Visible = true;
            }
            string str = row.Cells[9].Text;
            LinkButton lb = row.Cells[10].FindControl("lbEdit") as LinkButton;
            LinkButton lt = row.Cells[10].FindControl("lbDelete") as LinkButton;
            LinkButton le = row.Cells[10].FindControl("lbxiugai") as LinkButton;
            if (str == "2" || str == "3" || str == "0" || str == "1")
            {

                lb.Visible = true;
                lt.Visible = true;
                le.Visible = true;
                if (str == "3")
                {
                    row.Cells[9].Text = "不同意";
                }
                if(str=="2")
                {
                    row.Cells[9].Text = "重新修改";
                }
                if (str == "1")
                {
                    row.Cells[9].Text = "同意";
                }
                if (str == "0")
                {
                    row.Cells[9].Text = "未审核";
                }
            }
            else
            {
                lb.Visible = false;
                lt.Visible = false;
                le.Visible = false;
                if (str == "4")
                {
                    row.Cells[9].Text = "已批准";
                }

            }
        }


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





        }
    }

    /// <summary>
    /// 单击某行的操作时
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvShow_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        string operUrl = null;
        string opername = e.CommandName;
        string opervalue = e.CommandArgument.ToString();
        if (opername == "Delete")   //不同意
        {

            string sql2 = "update [qingjia] set q_statue=@q_statue where id=@id";
            SqlParameter[] sps2 = new SqlParameter[] { 
            new SqlParameter("@id", opervalue),
              new SqlParameter("@q_statue","3"),
            };

            int result1 = SqlHelper.ExecuteNonQuery(sql2, sps2);

            string sql20 = "update [ShenQingShenBao] set s_statue=@s_statue where id=@id";
            SqlParameter[] sps20 = new SqlParameter[] { 
            new SqlParameter("@id", opervalue),
              new SqlParameter("@s_statue","3"),
            };

            int result2 = SqlHelper.ExecuteNonQuery(sql20, sps20);
            if (result1 > 0 && result2 > 0)

                Response.Redirect("ManageShenQing.aspx");

        }
        else if (opername == "Edit")   //同意
        {
            string sql3 = "update [qingjia] set q_statue=@q_statue where id=@id";
            SqlParameter[] sps3 = new SqlParameter[] { 
            new SqlParameter("@id",opervalue),
              new SqlParameter("@q_statue","1"),
            };

            int result3 = SqlHelper.ExecuteNonQuery(sql3, sps3);

            string sql21 = "update [ShenQingShenBao] set s_statue=@s_statue where id=@id";
            SqlParameter[] sps21 = new SqlParameter[] { 
            new SqlParameter("@id",opervalue),
              new SqlParameter("@s_statue","1"),
            };

            int result4 = SqlHelper.ExecuteNonQuery(sql21, sps21);
            if (result3 > 0 && result4 > 0)
                Response.Redirect("ManageShenQing.aspx");


        }
        else if (opername == "Xiugai") //重新修改
        {
            string sql4 = "update [qingjia] set q_statue=@q_statue where id=@id";
            SqlParameter[] sps4 = new SqlParameter[] { 
            new SqlParameter("@id", opervalue),
              new SqlParameter("@q_statue","2"),
            };

            int result5 = SqlHelper.ExecuteNonQuery(sql4, sps4);
            string sql22 = "update [ShenQingShenBao] set s_statue=@s_statue where id=@id";
            SqlParameter[] sps22 = new SqlParameter[] { 
            new SqlParameter("@id", opervalue),
              new SqlParameter("@s_statue","2"),
            };

            int result6 = SqlHelper.ExecuteNonQuery(sql22, sps22);
            if (result5 > 0 && result6 > 0)
                Response.Redirect("ManageShenQing.aspx");


        }
        else if (opername == "ChaKan")
        {
            String sql23 = "SELECT ImageUrl FROM [qingjia] where id='" + opervalue + "'";
            //             System.Diagnostics.Debug.Assert(false, sql10);//打印调试信息
            DataTable dt_Url = SqlHelper.ExecuteDataTable(sql23);
            int i_all = dt_Url.Rows.Count;

            if (i_all > 0)
            {
                //ChaKan.Visible = true;


                operUrl = dt_Url.Rows[0][0].ToString();
                Response.Redirect("~/images/" + operUrl);
            }


            //Response.Redirect("~/images/QQ图片20200107153621.png?operfun=edit&operid=" + opervalue);
            //  Response.Redirect("<script>window.open('~/images/QQ图片20200107153621.png','_blank')</script>");
            //  Response.Write("<script>window.open('images/QQ图片20200107153621.png','_blank')</script>");
            // Response.Write("<script>window.location='~/images/QQ图片20200107153621.png'</script>"); 路径有问题，暂时不采用打开新窗口
        }

    }

    /// <summary>
    /// 排序
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
 /*   protected void gvShow_Sorting(object sender, GridViewSortEventArgs e)
    {
        DataTable tb = Session["Table"] as DataTable;
        tb.DefaultView.Sort = e.SortExpression;
        gvShow.DataSource = tb;
        gvShow.DataBind();
    }
*/

    public SortDirection GridViewSortDirection
    {

        get
        {

            if (ViewState["sortDirection"] == null)

                ViewState["sortDirection"] = SortDirection.Ascending;

            return (SortDirection)ViewState["sortDirection"];

        }

        set { ViewState["sortDirection"] = value; }

    }

    protected void gvShow_Sorting(object sender, GridViewSortEventArgs e)
    {
        // DataTable tb = Session["Table"] as DataTable;
        // tb.DefaultView.Sort = e.SortExpression;

        string sortExpression = e.SortExpression;
        if (GridViewSortDirection == SortDirection.Ascending)
        {

            GridViewSortDirection = SortDirection.Descending;
            SortGridView(sortExpression, " DESC");
        }
        else
        {

            GridViewSortDirection = SortDirection.Ascending;

            SortGridView(sortExpression, " ASC");

        }
        //  gvShow.DataSource = tb;
        //  gvShow.DataBind();
    }

    private void SortGridView(string sortExpression, string direction)
    {

        DataTable tb = Session["Table"] as DataTable;

        tb.DefaultView.Sort = sortExpression + direction;

        gvShow.DataSource = tb;
        gvShow.DataBind();

    }
 



}