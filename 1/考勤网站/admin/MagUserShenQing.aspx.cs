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

public partial class admin_MagUserShenQing : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        GridViewDataBind();
    }
    public void GridViewDataBind()
    {

        string sql2 = "select * from [qingjia] where q_statue='1' or q_statue='4' ORDER BY q_statue, q_enddate DESC";
        DataSet ds2 = SqlHelper.ExecuteDataSet(sql2);
        Session["Table"] = ds2.Tables[0];
        gvShow.DataSource = ds2;
        gvShow.DataBind();

        foreach (GridViewRow row in gvShow.Rows)
        {

            string str = row.Cells[7].Text;
            LinkButton lb = row.Cells[7].FindControl("lbEdit") as LinkButton;
            LinkButton lbl = row.Cells[7].FindControl("lbDelete") as LinkButton;
            if (str == "1")
            {

                lb.Visible = true;
                lbl.Visible = true;

                if (str == "1")
                {
                    row.Cells[7].Text = "上级已同意";
                }
              
            }
            else
            {
                lb.Visible = true;
                lbl.Visible = true;
                if (str == "4")
                {
                    row.Cells[7].Text = "已确认";
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

            LinkButton btn = e.Row.FindControl("lbDelete") as LinkButton;
            btn.Attributes.Add("onclick", "return confirm('确定要删除该申请记录吗？')");



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
        if (opername == "Edi")
        {
            string sql3 = "update [qingjia] set q_statue=@q_statue where Q_ID=@Q_ID";
            SqlParameter[] sps3 = new SqlParameter[] { 
            new SqlParameter("@Q_ID", Convert.ToInt32(opervalue)),
              new SqlParameter("@q_statue","4"),
            };

            int result = SqlHelper.ExecuteNonQuery(sql3, sps3);
            if (result > 0)
            {
                //string things = "", time1 = "", time2 = "", name = "", number = "";

                //string sql = "select q_things from [qingjia] where Q_ID=@Q_ID";
                //SqlParameter[] sps1 = new SqlParameter[]
                //{
                //     new SqlParameter("@Q_ID", Convert.ToInt32(opervalue)),
                //};
                //SqlDataReader dr = SqlHelper.ExecuteReader(CommandType.Text, sql, sps1);

                //if (dr.Read())
                //{
                //    name = dr.GetString(dr.GetOrdinal("q_name"));
                //    number = dr.GetString(dr.GetOrdinal("q_number"));
                //    things = dr.GetString(dr.GetOrdinal("q_things"));
                //    time1 = dr.GetString(dr.GetOrdinal("q_startdate"));
                //    time2 = dr.GetString(dr.GetOrdinal("q_enddate"));

                //}
                //SqlHelper.Close();
                //if (things == "因公出差")
                //{


                //}
                Response.Redirect("MagUserShenQing.aspx");
            } 

        }
        else if (opername == "Del")
        {

            string sql2 = "delete from [qingjia] where Q_ID=@ID";
            SqlParameter[] sps2 = new SqlParameter[] { 
            new SqlParameter("@ID", Convert.ToInt32(opervalue)),
            };

            int result = SqlHelper.ExecuteNonQuery(sql2, sps2);
            if (result > 0)
                Response.Redirect("MagUserShenQing.aspx");

        }
       

    }

    /// <summary>
    /// 排序
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
  /*  protected void gvShow_Sorting(object sender, GridViewSortEventArgs e)
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