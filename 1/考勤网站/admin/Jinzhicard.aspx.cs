using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Text;
using System.Web.Configuration;
using DBHelper;

public partial class admin_Jinzhicard : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        GridViewDataBind();
    }
    protected void ddl_number_SelectedIndexChanged(object sender, EventArgs e)
    {
        String sql_name = "SELECT * FROM [userinfo] where cardid1=@number";
        SqlParameter[] sps_name = new SqlParameter[]
                    {
                        new SqlParameter("@number",ddl_number.SelectedItem.Text),
                    };
        using (SqlDataReader dr_name = SqlHelper.ExecuteReader(CommandType.Text, sql_name, sps_name))
        {

            if (dr_name.Read())
            {
                txt_name.Text = dr_name.GetString(dr_name.GetOrdinal("name"));

            }
            SqlHelper.Close();
        }
    }
    protected void Add_jinzhicard_Click(object sender, EventArgs e)
    {
        String sql1 = "SELECT * FROM [jinzhitab] where jinzhiid='" + ddl_number.SelectedItem.Text + "'";
        DataTable dt_allgongzuori = SqlHelper.ExecuteDataTable(sql1);
        int i_all = dt_allgongzuori.Rows.Count;

        if (i_all > 0)
        {

            ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('该禁止卡已经存在请重新选择')</script>");
            return;
        }
           string sql4 = "insert into [jinzhitab](jinzhiid,status,nowtime)values(@jinzhiid,@status,@nowtime)";
        SqlParameter[] sps4 = new SqlParameter[3];
        sps4[0] = new SqlParameter("@jinzhiid",ddl_number.SelectedItem.Text);
        sps4[1] = new SqlParameter("@status",'0');
        sps4[2] = new SqlParameter("@nowtime", DateTime.Now.ToLocalTime().ToString());   
        int i = SqlHelper.ExecuteNonQuery(sql4, sps4);
        if (i > 0)
        {
            gvShow.DataBind();
            GridViewDataBind();
            Response.Redirect("Jinzhicard.aspx");
        }
    }
    public void GridViewDataBind()
    {

        string sql2 = "select * from [jinzhitab] ";
        DataSet ds2 = SqlHelper.ExecuteDataSet(sql2);
        Session["Table"] = ds2.Tables[0];
        gvShow.DataSource = ds2;
        gvShow.DataBind();

        foreach (GridViewRow row in gvShow.Rows)
        {
            LinkButton lt = row.Cells[3].FindControl("lbDelete") as LinkButton;
            string str = row.Cells[1].Text;
            if (str == "0" )
            {

             row.Cells[1].Text = "未通知";
              
                 
            }
            else
            {
                if (str == "1")
                {
                    row.Cells[1].Text = "已通知";
                }
                else
                {
                    if (str == "3")
                    {
                        row.Cells[1].Text = "撤销中";
                        lt.Visible = false;
                    }
                   
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
            btn.Attributes.Add("onclick", "return confirm('确定要撤销该禁止卡吗？')");


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

            string sql2 = "delete from [jinzhitab] where jinzhiid=@Q_ID and status='0'";
            SqlParameter[] sps2 = new SqlParameter[] { 
            new SqlParameter("@Q_ID", Convert.ToInt32(opervalue)),
            };

            int result = SqlHelper.ExecuteNonQuery(sql2, sps2);
            if (result > 0)
                Response.Redirect("Jinzhicard.aspx");
            else
            {
                string sql4 = "update [jinzhitab] set status=@status where jinzhiid='" + opervalue + "' and status='1' ";
                SqlParameter[] sps4 = new SqlParameter[1];
                sps4[0] = new SqlParameter("@status", "3");

                int result2 = SqlHelper.ExecuteNonQuery(sql4, sps4);

                if (result2 > 0)
                {
                    Response.Redirect("Jinzhicard.aspx");

                }
            
            }

        }
       

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

}