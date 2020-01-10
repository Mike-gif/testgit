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

public partial class admin_CardInfo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            
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

    protected void Button_Click(object sender, EventArgs e)
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
                GridViewDataBind();
              
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


    protected void gvShow_Sorting(object sender, GridViewSortEventArgs e)
    {
        DataTable tb = Session["Table"] as DataTable;
        tb.DefaultView.Sort = e.SortExpression;
        gvShow.DataSource = tb;
        gvShow.DataBind();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        GridViewDataBind();


    }
    public void GridViewDataBind()
    {

        gvShow.Visible = true;
        string sql;
        sql = makesql_table1();

        DataSet ds = SqlHelper.ExecuteDataSet(sql);
        Session["Table"] = ds.Tables[0];
        gvShow.DataSource = ds;
        gvShow.DataBind();
    }
   

    protected string makesql_table1()
    {

        string _result = "",selectname="",selectnumber="";
        if (tb_name.Text != "")
        {
            selectname=" and c_name='"+tb_name.Text+"'";
        }
        if(tb_number.Text!="")
        {
            selectnumber = " and c_id='" + tb_number.Text + "'";
        }



        _result = "select * from [cardinf] where c_time>'" + startime.Text + "' and  c_time<'" + Calendar2.SelectedDate.AddDays(1).ToString("yyyy-MM-dd") + "' and c_addr='" + ddr_address.SelectedItem.Text+ "' "+selectname+selectnumber;

        return _result;
    }




    







}
