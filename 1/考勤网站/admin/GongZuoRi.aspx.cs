using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;
using System.Data.SqlClient;
using System.Data;
using DBHelper;




public partial class admin_GongZuoRi : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
           GridViewDataBind();
            nianfen.Text = DateTime.Now.Year.ToString();
            int intyear = int.Parse(DateTime.Now.Month.ToString());
            string strmoth = intyear.ToString();
            if (1 <= intyear && intyear <= 9)
            {
                strmoth = "0" + intyear.ToString();

            }
           
            DropDownList1.SelectedValue = strmoth;
            DateTime time1 = Convert.ToDateTime(nianfen.Text + "-" + strmoth);
            DateTime d1 = new DateTime(time1.Year, time1.Month, 1);
            DateTime d2 = d1.AddMonths(1).AddDays(-1);
            System.TimeSpan NDkaoqinxiawu = d2 - d1;//下午考勤
            int nTSecondsxiawu = (int)NDkaoqinxiawu.Days;   //天数差
            for (int i = 1; i <= nTSecondsxiawu + 1; i++)
            {
                DateTime d3 = new DateTime(time1.Year, time1.Month, i);
                if (d3.DayOfWeek.ToString() == "Saturday")
                {
                    continue;
                }
                if (d3.DayOfWeek.ToString() == "Sunday")
                {
                    continue;
                }
                TextBox1.Text += d3.ToString("yyyy-MM-dd") + "," + "\n";
            }

        }
      
    }

    protected void Calendar2_SelectionChanged(object sender, EventArgs e)
    {
        string setmonth = "",selectmoth="";
        string ddl_month = DropDownList1.SelectedItem.Value;
        if (nianfen.Text == "")
        {
            ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('年份不能为空')</script>");
            return;
        }
        setmonth = nianfen.Text + "-" + ddl_month;
        selectmoth = Calendar2.SelectedDate.ToString("yyyy-MM");
        int intyear = int.Parse(nianfen.Text);
        if (intyear < 2000 || intyear > 9999)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('请年份格式错误')</script>");
            return;
        }
        DateTime time1 = Convert.ToDateTime(setmonth);
        DateTime time2 = Convert.ToDateTime(selectmoth);
        if (time1 != time2)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('日历月份和已选择月份不一致,请重新选择')</script>");
        }
        else 
        {

            string strgongz = TextBox1.Text;
            bool gongzuoritf = false;
            string selectdate= Calendar2.SelectedDate.ToString("yyyy-MM-dd");
              strgongz = strgongz.Replace("\n", string.Empty).Replace("\r", string.Empty);
              string[] s_th = strgongz.Split(',');
            foreach (string _s in s_th)
            {
                if (_s == selectdate)
                {
                    gongzuoritf = true;
                    break;
                }
            }
            if (gongzuoritf)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('该工作日已经存在,请重新选择')</script>");
            }
            else
            { 
                TextBox1.Text +=Calendar2.SelectedDate.ToString("yyyy-MM-dd")+","+"\n";            
            }    
        }


    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        string setmonth = "";
        TextBox1.Text = "";
        string ddl_month = DropDownList1.SelectedItem.Value;
        setmonth = nianfen.Text + "-" + ddl_month;
        int intyear = int.Parse(nianfen.Text);
        if (intyear < 2000 || intyear > 9999)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('请年份格式错误')</script>");
            return;
        }
        DateTime time1 = Convert.ToDateTime(setmonth);
        DateTime d1 = new DateTime(time1.Year, time1.Month, 1);
        DateTime d2 = d1.AddMonths(1).AddDays(-1);
        System.TimeSpan NDkaoqinxiawu = d2 - d1;//下午考勤
        int nTSecondsxiawu = (int)NDkaoqinxiawu.Days;   //天数差
        for (int i = 1; i <= nTSecondsxiawu+1; i++)
        {
            DateTime d3 = new DateTime(time1.Year, time1.Month, i);
            if (d3.DayOfWeek.ToString() == "Saturday")
            {
                continue;
            }
            if (d3.DayOfWeek.ToString() == "Sunday")
            {
                continue;
            }
            TextBox1.Text += d3.ToString("yyyy-MM-dd") + "," + "\n"; 
        }
     //   Calendar2.SelectedDate = "2017-1-1";

    }
    public void GridViewDataBind()
    {



        string sql1 = "select * from [gongzuori] ORDER BY YearMon DESC";

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
            btn.Attributes.Add("onclick", "return confirm('确定要删除该条记录吗？')");


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

            string sql2 = "delete from [gongzuori] where id=@ID";
            SqlParameter[] sps2 = new SqlParameter[] { 
            new SqlParameter("@ID", Convert.ToInt32(opervalue)),
            };

            int result = SqlHelper.ExecuteNonQuery(sql2, sps2);
            if (result > 0)
                Response.Redirect("GongZuoRi.aspx");

        }
        else if (opername == "Edit")
            Response.Redirect("edit_GongZuoRi.aspx?operfun=edit&operid=" + Convert.ToInt32(opervalue));

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
                ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('请选择您要删除的一个或多个记录！')</script>");
            else
            {
                string[] delids = ids.Trim(',').Split(',');
                foreach (string item in delids)
                {
                    string sql3 = "delete from [gongzuori] where id=@ID";
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
                        ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('删除失败！')</script>");
                    }

                }

                GridViewDataBind();
            }
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        int intyear = int.Parse(nianfen.Text);
        if (intyear < 2000 || intyear > 9999)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('请年份格式错误')</script>");
            return;
        }
        String sql1 = "SELECT * FROM [gongzuori] where YearMon='" + nianfen.Text + "-" + DropDownList1.SelectedItem.Value + "'";
        SqlDataReader dr = SqlHelper.ExecuteReader(CommandType.Text, sql1);
      
        if (dr.Read())
        {
            TextBox1.Text = "";
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "success", "alert(\"该年月记录已经存在请重新选择！\"); ", true);
            SqlHelper.Close();
            return;
        }
      

        string strgongzuori = TextBox1.Text;
        strgongzuori.Remove('\n');
        strgongzuori.Replace(" ", "");
        

        string sql4 = "insert into [gongzuori](YearMon,gongzuodate)values(@YearMon,@gongzuodate)";
        SqlParameter[] sps4 = new SqlParameter[2];
        sps4[0] = new SqlParameter("@YearMon", nianfen.Text + "-" + DropDownList1.SelectedItem.Value);
        sps4[1] = new SqlParameter("@gongzuodate", strgongzuori);
      

        int i = SqlHelper.ExecuteNonQuery(sql4, sps4);


        if (i > 0)
        {
            gvShow.DataBind();
            GridViewDataBind();
            Response.Redirect("GongZuoRi.aspx");
        }

    }



    protected void Button2_Click(object sender, EventArgs e)
    {
        TextBox1.Text = "";
    }
    
}