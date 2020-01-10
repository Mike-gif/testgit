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

public partial class HR_Seekuserkaohe : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            
            Calendar1.Visible = false;
            Calendar2.Visible = false;
           tb_nian.Text = DateTime.Now.Year.ToString();
       
            seektab.Visible = true; 
            defen.Visible = true; //统计得分的整个表显示。

            string sql = "SELECT * FROM [userinfo] where zaizhi='在职'";
            DataTable dt = SqlHelper.ExecuteDataTable(sql);
            int i_all = dt.Rows.Count;

            for (int i = 0; i < i_all; i++)
            {
                DropDownList1.Items.Add(new ListItem(dt.Rows[i]["name"].ToString(), dt.Rows[i]["name"].ToString()));//增加Item
                
            }
         
                if (Session["name1"] != null)
            {
                string name1 = Session["name1"].ToString();
                 DropDownList1.Text= name1;
                if (DropDownList1.Items.FindByText(name1) != null)
                {
                    DropDownList1.Text = name1;
                }
                startime.Text = Session["time1"].ToString();
                endtime.Text = Session["time2"].ToString();
                GridViewDataBind_ri(name1);
               GridViewDataBind_zhou(name1);
               GridViewDataBind_qing(name1);
               kaoqinhanshu(name1);
               
                //GridViewDataBind1();
            }
            else
            {
                DateTime dt_firte = DateTime.Now;
                //本月第一天时间   
                DateTime dt_First = dt_firte.AddDays(-(dt_firte.Day) + 1);
                startime.Text = dt_First.ToString("yyyy-MM-dd");
                endtime.Text = DateTime.Now.ToString("yyyy-MM-dd");
            }
                initialization();
        }
              
                
                gvShow_ri.Style.Add("table-layout", "fixed");
                gvShow_zhou.Style.Add("table-layout", "fixed");
                gvShow_qing.Style.Add("table-layout", "fixed");
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




    public void GridViewDataBind_ri(string name)
    {
        string sql = "SELECT * FROM [userinfo] WHERE name ='" + name + "'";
        DataTable dt = SqlHelper.ExecuteDataTable(sql);
        int i_all = dt.Rows.Count;
        for (int i = 0; i < i_all; i++)
        {
            TextBox1.Text = dt.Rows[i]["ruzhi"].ToString();
            TextBox2.Text = dt.Rows[i]["number"].ToString();
            TextBox3.Text = dt.Rows[i]["jibie"].ToString();
            TextBox4.Text = dt.Rows[i]["bumen"].ToString();
            string a = dt.Rows[i]["shangji"].ToString();
            string sql_name = "SELECT * FROM [userinfo] WHERE number ='" + a + "'";
            DataTable dt2 = SqlHelper.ExecuteDataTable(sql_name);
            int i_all2 = dt2.Rows.Count;
            if (i_all2 > 0)
            {
                TextBox5.Text = dt2.Rows[0]["name"].ToString();

            }

        }
        string timestr1 = "", timestr2 = "";
        if (Session["name1"] != null)
        {
            timestr1 = Session["time1"].ToString();
            timestr2 = Session["time2"].ToString();


        }
        else
        {
            timestr1 = startime.Text;
            timestr2 = endtime.Text;

        }

        DateTime time1 = Convert.ToDateTime(timestr1);
        DateTime time2 = Convert.ToDateTime(timestr2);

        System.TimeSpan ND = time2 - time1;
        int n = ND.Days;   //天数差
        if (time1 > time2)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('开始时间大于结束时间，请重新选择')</script>");
            return;
        }
        else
        {
            if (n > 31)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('只能查询31天以内的记录，请重新选择')</script>");
                return;

            }
        }

        string sql2 = "select * from [RiJiHua] where r_number IN (select number from [userinfo] where  name='" + name + "') and r_time>='" + timestr1 + "' and r_time<='" + timestr2 + "' order by r_time desc";

        DataSet ds2 = SqlHelper.ExecuteDataSet(sql2);

        ds2 = SqlHelper.ExecuteDataSet(sql2);
        Session["Table"] = ds2.Tables[0];
        gvShow_ri.DataSource = ds2;
        gvShow_ri.DataBind();

        foreach (GridViewRow row in gvShow_ri.Rows)
        {

            string gettime = row.Cells[0].Text;
            string[] s_th1 = gettime.Split('-');
            int i = 0;
            string year = "", month = "", sec = "";
            foreach (string _s1 in s_th1)
            {
                if (i == 0)
                    year = _s1;
                if (i == 1)
                    month = _s1;
                if (i == 2)
                    sec = _s1;
                i++;
            }
            System.DateTime newDate = new DateTime(int.Parse(year), int.Parse(month), int.Parse(sec));
            row.Cells[0].Text += " " + getweek(newDate.DayOfWeek.ToString());
            string str = row.Cells[6].Text;


            if (str == "1")
            {
                row.Cells[6].Text = "已批阅";


            }
            else
            {
                row.Cells[6].Text = "未批阅";


            }
        }

    }



    public void GridViewDataBind_zhou(string name)
    {

        string timestr1 = "", timestr2 = "";
        if (Session["name1"] != null)
        {
            timestr1 = Session["time1"].ToString();
            timestr2 = Session["time2"].ToString();


        }
        else
        {
            timestr1 = startime.Text;
            timestr2 = endtime.Text;

        }

        DateTime time1 = Convert.ToDateTime(timestr1);
        DateTime time2 = Convert.ToDateTime(timestr2);

        System.TimeSpan ND = time2 - time1;
        int n = ND.Days;   //天数差
        if (time1 > time2)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('开始时间大于结束时间，请重新选择')</script>");
            return;
        }
        else
        {
            if (n > 31)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('只能查询31天以内的记录，请重新选择')</script>");
                return;

            }
        }

        string sql2 = "select * from [ZhouJiHua] where z_number IN (select number from [userinfo] where  name='" + name + "') and z_time>='" + timestr1 + "' and z_time<='" + timestr2 + "' order by z_time desc";

        DataSet ds2 = SqlHelper.ExecuteDataSet(sql2);

        ds2 = SqlHelper.ExecuteDataSet(sql2);
        Session["Table"] = ds2.Tables[0];
        gvShow_zhou.DataSource = ds2;
        gvShow_zhou.DataBind();

        foreach (GridViewRow row in gvShow_zhou.Rows)
        {

            string gettime = row.Cells[0].Text;
            string[] s_th1 = gettime.Split('-');
            int i = 0;
            string year = "", month = "", sec = "";
            foreach (string _s1 in s_th1)
            {
                if (i == 0)
                    year = _s1;
                if (i == 1)
                    month = _s1;
                if (i == 2)
                    sec = _s1;
                i++;
            }
            System.DateTime newDate = new DateTime(int.Parse(year), int.Parse(month), int.Parse(sec));
            row.Cells[0].Text += " " + getweek(newDate.DayOfWeek.ToString());
            string str = row.Cells[6].Text;


            if (str == "1")
            {
                row.Cells[6].Text = "已批阅";


            }
            else
            {
                row.Cells[6].Text = "未批阅";


            }
        }

    }

    public void GridViewDataBind_qing(string name)
    {

        string timestr1 = "", timestr2 = "";
        if (Session["name1"] != null)
        {
            timestr1 = Session["time1"].ToString();
            timestr2 = Session["time2"].ToString();


        }
        else
        {
            timestr1 = startime.Text;
            timestr2 = endtime.Text;

        }

        DateTime time1 = Convert.ToDateTime(timestr1);
        DateTime time2 = Convert.ToDateTime(timestr2);

        System.TimeSpan ND = time2 - time1;
        int n = ND.Days;   //天数差
        if (time1 > time2)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('开始时间大于结束时间，请重新选择')</script>");
            return;
        }
        else
        {
            if (n > 31)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('只能查询31天以内的记录，请重新选择')</script>");
                return;

            }
        }

        string sql2 = "select * from [qingjia] where q_number IN (select number from [userinfo] where  name='" + name + "') and q_time>='" + timestr1 + "' and q_time<='" + timestr2 + "' order by q_time desc";

        DataSet ds2 = SqlHelper.ExecuteDataSet(sql2);

        ds2 = SqlHelper.ExecuteDataSet(sql2);
        Session["Table"] = ds2.Tables[0];
        gvShow_qing.DataSource = ds2;
        gvShow_qing.DataBind();

        foreach (GridViewRow row in gvShow_qing.Rows)
        {

            string gettime = row.Cells[1].Text;
            string[] s_th1 = gettime.Split('-');
            int i = 0;
            string year = "", month = "", sec = "";
            foreach (string _s1 in s_th1)
            {
                if (i == 0)
                    year = _s1;
                if (i == 1)
                    month = _s1;
                if (i == 2)
                    sec = _s1;
                i++;
            }
            System.DateTime newDate = new DateTime(int.Parse(year), int.Parse(month), int.Parse(sec));
            row.Cells[1].Text += " " + getweek(newDate.DayOfWeek.ToString());
            // string str = row.Cells[6].Text;
            LinkButton ChaKan = row.Cells[6].FindControl("lbChaKan") as LinkButton;

            ChaKan.Visible = false;
            string opervalue = row.Cells[0].Text;
           // System.Diagnostics.Debug.Write("opervalue =" + opervalue);
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


            string str = row.Cells[8].Text;
           
            if (str == "2" || str == "3" || str == "0" || str == "1")
            {

                if (str == "3")
                {
                    row.Cells[8].Text = "不同意";
                }
                if (str == "2")
                {
                    row.Cells[8].Text = "重新修改";
                }
                if (str == "1")
                {
                    row.Cells[8].Text = "上级已同意";
                }
                if (str == "0")
                {
                    row.Cells[8].Text = "未审核";
                }
            }
            else
            {
                
                if (str == "4")
                {
                    row.Cells[8].Text = "已批准";
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
    protected void gvShow_ri_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvShow_ri.PageIndex = e.NewPageIndex;
        if (Session["name1"] != null)  //下拉列表第一个下属名字？
        {
            string name1 = Session["name1"].ToString();
            GridViewDataBind_ri(name1);
        }
        else
        {
            GridViewDataBind_ri(DropDownList1.SelectedItem.Text);
        }
    }

    protected void gvShow_zhou_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvShow_zhou.PageIndex = e.NewPageIndex;
        if (Session["name1"] != null)  //下拉列表第一个下属名字？
        {
            string name1 = Session["name1"].ToString();
            GridViewDataBind_zhou(name1);
        }
        else
        {
            GridViewDataBind_zhou(DropDownList1.SelectedItem.Text);
        }
    }

    protected void gvShow_qing_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvShow_qing.PageIndex = e.NewPageIndex;
        if (Session["name1"] != null)  //下拉列表第一个下属名字？
        {
            string name1 = Session["name1"].ToString();
            GridViewDataBind_qing(name1);
        }
        else
        {
            GridViewDataBind_qing(DropDownList1.SelectedItem.Text);
        }
    }
    /// <summary>
    /// 显示高亮效果
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvShow_ri_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes.Add("onmouseover", "currentcolor=this.style.backgroundColor;this.style.backgroundColor='lightblue'");
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=currentcolor");

        }
    }

    protected void gvShow_zhou_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes.Add("onmouseover", "currentcolor=this.style.backgroundColor;this.style.backgroundColor='lightblue'");
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=currentcolor");

        }
    }

    protected void gvShow_qing_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes.Add("onmouseover", "currentcolor=this.style.backgroundColor;this.style.backgroundColor='lightblue'");
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=currentcolor");

        }
    }
 protected void gvShow_qing_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        string operUrl = null;
        string opername = e.CommandName;
        string opervalue = e.CommandArgument.ToString();
        if (opername == "ChaKan")
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
 /*   protected void gvShow_ri_Sorting(object sender, GridViewSortEventArgs e)
    {
        DataTable tb = Session["Table"] as DataTable;
        tb.DefaultView.Sort = e.SortExpression;
        gvShow_ri.DataSource = tb;
        gvShow_ri.DataBind();
    }
  
    protected void gvShow_zhou_Sorting(object sender, GridViewSortEventArgs e)
    {
        DataTable tb = Session["Table"] as DataTable;
        tb.DefaultView.Sort = e.SortExpression;
        gvShow_zhou.DataSource = tb;
        gvShow_zhou.DataBind();
    }

    protected void gvShow_qing_Sorting(object sender, GridViewSortEventArgs e)
    {
        DataTable tb = Session["Table"] as DataTable;
        tb.DefaultView.Sort = e.SortExpression;
        gvShow_qing.DataSource = tb;
        gvShow_qing.DataBind();
    }
    */
    public SortDirection GridViewSortDirection_ri
    {

        get
        {

            if (ViewState["sortDirection"] == null)

                ViewState["sortDirection"] = SortDirection.Ascending;

            return (SortDirection)ViewState["sortDirection"];

        }

        set { ViewState["sortDirection"] = value; }

    }

    protected void gvShow_ri_Sorting(object sender, GridViewSortEventArgs e)
    {
        // DataTable tb = Session["Table"] as DataTable;
        // tb.DefaultView.Sort = e.SortExpression;

        string sortExpression = e.SortExpression;
        if (GridViewSortDirection_ri == SortDirection.Ascending)
        {

            GridViewSortDirection_ri = SortDirection.Descending;
            SortGridView_ri(sortExpression, " DESC");
        }
        else
        {

            GridViewSortDirection_ri = SortDirection.Ascending;

            SortGridView_ri(sortExpression, " ASC");

        }
        //  gvShow.DataSource = tb;
        //  gvShow.DataBind();
    }

    private void SortGridView_ri(string sortExpression, string direction)
    {
        string timestr1 = "", timestr2 = "";
        timestr1 = startime.Text;
        timestr2 = endtime.Text;
        //   string name1 = Session["name1"].ToString();
        string name1 = DropDownList1.SelectedItem.Text;
        string sql2 = "select * from [RiJiHua] where r_number IN (select number from [userinfo] where  name='" + name1 + "') and r_time>='" + timestr1 + "' and r_time<='" + timestr2 + "' order by r_statue asc, r_time desc";

        DataSet ds2 = SqlHelper.ExecuteDataSet(sql2);

        ds2 = SqlHelper.ExecuteDataSet(sql2);
        Session["Table"] = ds2.Tables[0];


        System.Diagnostics.Debug.Write("Table=" + Session["Table"].ToString());
        DataTable tb = Session["Table"] as DataTable;

        tb.DefaultView.Sort = sortExpression + direction;

        gvShow_ri.DataSource = tb;
        gvShow_ri.DataBind();

    }

    public SortDirection GridViewSortDirection_zhou
    {

        get
        {

            if (ViewState["sortDirection"] == null)

                ViewState["sortDirection"] = SortDirection.Ascending;

            return (SortDirection)ViewState["sortDirection"];

        }

        set { ViewState["sortDirection"] = value; }

    }

    protected void gvShow_zhou_Sorting(object sender, GridViewSortEventArgs e)
    {
        // DataTable tb = Session["Table"] as DataTable;
        // tb.DefaultView.Sort = e.SortExpression;

        string sortExpression = e.SortExpression;
        if (GridViewSortDirection_zhou == SortDirection.Ascending)
        {

            GridViewSortDirection_zhou = SortDirection.Descending;
            SortGridView_zhou(sortExpression, " DESC");
        }
        else
        {

            GridViewSortDirection_zhou = SortDirection.Ascending;

            SortGridView_zhou(sortExpression, " ASC");

        }
        //  gvShow.DataSource = tb;
        //  gvShow.DataBind();
    }

    private void SortGridView_zhou(string sortExpression, string direction)
    {
        string timestr1 = "", timestr2 = "", timestr3 = "";
        timestr1 = startime.Text;
        timestr2 = endtime.Text;
        DateTime time1 = Convert.ToDateTime(timestr1);
        DateTime time2 = Convert.ToDateTime(timestr2);

        DateTime sunday = time1.AddDays(Convert.ToDouble((0 - Convert.ToInt16(time1.DayOfWeek)))); //得到一周的第一天是yyyy/MM/dd，第一天从周日开始
        timestr3 = sunday.AddDays(1).ToString("yyyy-MM-dd");//得到一周的周一是yyyy-MM-dd
        //   string name1 = Session["name1"].ToString();
        string name1 = DropDownList1.SelectedItem.Text;
        string sql2 = "select * from [ZhouJiHua] where z_number IN (select number from [userinfo] where  name='" + name1 + "') and z_time>='" + timestr3 + "' and z_time<='" + timestr2 + "' order by z_statue asc, z_time desc";

        DataSet ds2 = SqlHelper.ExecuteDataSet(sql2);

        ds2 = SqlHelper.ExecuteDataSet(sql2);
        Session["Table"] = ds2.Tables[0];


        System.Diagnostics.Debug.Write("Table=" + Session["Table"].ToString());
        DataTable tb = Session["Table"] as DataTable;

        tb.DefaultView.Sort = sortExpression + direction;

        gvShow_zhou.DataSource = tb;
        gvShow_zhou.DataBind();

    }



    public SortDirection GridViewSortDirection_qing
    {

        get
        {

            if (ViewState["sortDirection"] == null)

                ViewState["sortDirection"] = SortDirection.Ascending;

            return (SortDirection)ViewState["sortDirection"];

        }

        set { ViewState["sortDirection"] = value; }

    }

    protected void gvShow_qing_Sorting(object sender, GridViewSortEventArgs e)
    {
        // DataTable tb = Session["Table"] as DataTable;
        // tb.DefaultView.Sort = e.SortExpression;

        string sortExpression = e.SortExpression;
        if (GridViewSortDirection_qing == SortDirection.Ascending)
        {

            GridViewSortDirection_qing = SortDirection.Descending;
            SortGridView_qing(sortExpression, " DESC");
        }
        else
        {

            GridViewSortDirection_qing = SortDirection.Ascending;

            SortGridView_qing(sortExpression, " ASC");

        }
        //  gvShow.DataSource = tb;
        //  gvShow.DataBind();
    }

    private void SortGridView_qing(string sortExpression, string direction)
    {
        string timestr1 = "", timestr2 = "";
        timestr1 = startime.Text;
        timestr2 = endtime.Text;
        DateTime time1 = Convert.ToDateTime(timestr1);
        DateTime time2 = Convert.ToDateTime(timestr2);


        //   string name1 = Session["name1"].ToString();
        string name1 = DropDownList1.SelectedItem.Text;
        string sql2 = "select * from [qingjia] where q_number IN (select number from [userinfo] where  name='" + name1 + "') and ((q_startdate>='" + timestr1 + "' and  q_startdate <='" + timestr2 + "') or (q_enddate>='" + timestr1 + "' and  q_enddate <='" + timestr2 + "') or (q_startdate<='" + timestr1 + "' and  q_enddate >='" + timestr2 + "') or (q_time>='" + timestr1 + "' and  q_time <='" + timestr2 + "'))  order by q_statue asc, q_time desc"; //gridview的初始化排序通过此处order by对数据库的排序实现,第一排序字段为q_statue升序，第二排序规则为q_time降序

        DataSet ds2 = SqlHelper.ExecuteDataSet(sql2);

        ds2 = SqlHelper.ExecuteDataSet(sql2);
        Session["Table"] = ds2.Tables[0];


        System.Diagnostics.Debug.Write("Table=" + Session["Table"].ToString());
        DataTable tb = Session["Table"] as DataTable;

        tb.DefaultView.Sort = sortExpression + direction;

        gvShow_qing.DataSource = tb;
        gvShow_qing.DataBind();

    }
    public string getweek(string dt)
    {
        string week = "";

        switch (dt)
        {
            case "Monday":
                week = "星期一";
                break;
            case "Tuesday":
                week = "星期二";
                break;
            case "Wednesday":
                week = "星期三";
                break;
            case "Thursday":
                week = "星期四";
                break;
            case "Friday":
                week = "星期五";
                break;
            case "Saturday":
                week = "星期六";
                break;
            case "Sunday":
                week = "星期日";
                break;
        }

        return week;

    }
    public void kaoqinhanshu(string name) //时间段考勤信息汇总
    {



        DateTime time1 = Convert.ToDateTime(startime.Text);
        DateTime time2 = Convert.ToDateTime(endtime.Text);
        System.TimeSpan ND = time2 - time1;
        int n = ND.Days;   //天数差
        if (time1 > time2)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('开始时间大于结束时间，请重新选择')</script>");
        }
        else
        {
            if (n > 31)
            {
                // time2.AddDays(1);
                ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('只能查询31天以内的记录，请重新选择')</script>");

            }
            else
            {
                string gettime1 = "", gettime2 = "", gettime3 = "", gettime4 = "", gettime5 = "", getcanbu = "", getchebu = "", getchidao = "", getzaotiu = "", getqueqin = "", getligang = "", getnianxiu = "", getshijia = "", getlinshijia = "", getbingjia = "", getkuanggong = "";//获取早上考勤时间，允许迟到时间，旷工时间,午休时间,下午下班时间,加班时间,迟到时间，早退时间，旷工时间
                double TADD1 = 0, TADD2 = 0, TADD3 = 0, TADD4 = 0;
                int FADD = 0;
                double CANADD = 0, CHEADD = 0;
                String sql1 = "SELECT * FROM [KaoQinCanShu] where banci=@number";
                SqlParameter[] sps1 = new SqlParameter[]
                    {
                        new SqlParameter("@number",ddr_banci.SelectedItem.Text),
                    };
                using (SqlDataReader dr = SqlHelper.ExecuteReader(CommandType.Text, sql1, sps1))
                {

                    if (dr.Read())
                    {

                        gettime1 = dr.GetString(dr.GetOrdinal("time1"));
                        gettime2 = dr.GetString(dr.GetOrdinal("time2"));
                        gettime3 = dr.GetString(dr.GetOrdinal("time3"));
                        gettime4 = dr.GetString(dr.GetOrdinal("time4"));
                        gettime5 = dr.GetString(dr.GetOrdinal("time5"));//晚班时间
                        getcanbu = dr.GetString(dr.GetOrdinal("canbu"));
                        getchebu = dr.GetString(dr.GetOrdinal("chebu"));
                        getchidao = dr.GetString(dr.GetOrdinal("chidao"));
                        getzaotiu = dr.GetString(dr.GetOrdinal("zaotiu"));
                        getqueqin = dr.GetString(dr.GetOrdinal("queqin"));
                        getligang = dr.GetString(dr.GetOrdinal("ligang"));
                        getnianxiu = dr.GetString(dr.GetOrdinal("nianxiu"));
                        getshijia = dr.GetString(dr.GetOrdinal("shijia"));
                        getlinshijia = dr.GetString(dr.GetOrdinal("linshijia"));
                        getbingjia = dr.GetString(dr.GetOrdinal("bingjia"));
                        getkuanggong = dr.GetString(dr.GetOrdinal("kuanggong"));

                    }
                    SqlHelper.Close();
                }
                TableHeaderRow thr = new TableHeaderRow();
                //构建表头
                string[] s_th = "日期,第一次刷卡(到岗)时间,最后一次刷卡(离岗)时间,累计在岗(小时),累计上岗时间(小时),累计离岗时间(小时),累计加班时间(小时),餐补,车补,缺勤,状态(早、晚),考勤分(扣分)".Split(',');
                foreach (string _s in s_th)
                {
                    TableHeaderCell thd = new TableHeaderCell();
                    thd.Text = _s;
                    thr.Cells.Add(thd);
                }

                tb_result.Rows.Add(thr);
                int i = 0;
                for (i = 0; i <= n; i++)
                {
                    TableRow tr = new TableRow();
                    //日期

                    String strendti = time1.AddDays(i).ToString("yyyy-MM-dd");
                    string starttime = time1.AddDays(1 + i).ToString("yyyy-MM-dd");
                    TableCell td = new TableCell();
                    td.Text = strendti;
                    tr.Cells.Add(td);
                    ////姓名
                    //TableCell td1 = new TableCell();
                    //td1.Text = Session["name"].ToString();
                    //tr.Cells.Add(td1);
                   /* ddr_address.SelectedItem.Text = "大门";
                    System.Diagnostics.Debug.Write("ddr_address.SelectedItem.Text=" + ddr_address.SelectedItem.Text); //打印调试信息
                    System.Diagnostics.Debug.Write("strendti=" + strendti);
                    System.Diagnostics.Debug.Write("starttime=" + starttime);
                    System.Diagnostics.Debug.Write("starttime=" + name);
                    */
                    //   System.Diagnostics.Debug.Write("number=" + Session["number"]);
                    //string sql2 = "select * from [RiJiHua] where r_number IN (select number from [userinfo] where  name='" + name + "') and r_time>='" + timestr1 + "' and r_time<='" + timestr2 + "' order by r_time desc";
               //     string str_sql = "SELECT * FROM [cardinf] where c_id IN (select number from [userinfo] where  name='" + name + "') and c_addr='" + ddr_address.SelectedItem.Text + "'and c_time>'" + strendti + "' and c_time<'" + starttime + "' ORDER BY c_time";
                    string str_sql = "SELECT * FROM [cardinf] where c_id IN (select number from [userinfo] where  name='" + name + "') and c_addr='大门'and c_time>'" + strendti + "' and c_time<'" + starttime + "' ORDER BY c_time";
                    //string str_sql = "SELECT * FROM [cardinf] where c_id='" + Session["number"] + "'and c_addr='" + ddr_address.SelectedItem.Text + "'and c_time>'" + strendti + "' and c_time<'" + starttime + "' ORDER BY c_time";
                    //   System.Diagnostics.Debug.Assert(false, str_sql);//打印调试信息
                    DataSet ds2 = SqlHelper.ExecuteDataSet(str_sql);
                    int i1 = ds2.Tables[0].Rows.Count;
                    string firsttime = "", lastime = "", Tjin = "", Tchu = "";
                    bool firstcardtime = true;
                    double T1 = 0, T2 = 0;
                    for (int j = 0; j < i1; j++)
                    {

                        if (ds2.Tables[0].Rows[j]["c_status"].ToString() == "进")
                        {
                            if (firstcardtime)
                            {
                                firsttime = ds2.Tables[0].Rows[j]["c_time"].ToString();

                                firstcardtime = false;
                            }
                            if (j + 1 < i1)
                            {
                                if (ds2.Tables[0].Rows[j + 1]["c_status"].ToString() == "进")
                                {
                                    continue;
                                }
                                else
                                {

                                    Tjin = ds2.Tables[0].Rows[j]["c_time"].ToString();
                                }
                            }
                            else
                            {
                                Tjin = ds2.Tables[0].Rows[j]["c_time"].ToString();

                            }

                        }
                        else
                            if (ds2.Tables[0].Rows[j]["c_status"].ToString() == "出")
                            {
                                if (j + 1 < i1)
                                {
                                    if (ds2.Tables[0].Rows[j + 1]["c_status"].ToString() == "出")
                                    {
                                        continue;
                                    }
                                    else
                                    {
                                        Tchu = ds2.Tables[0].Rows[j]["c_time"].ToString();
                                    }
                                }
                                else
                                {
                                    Tchu = ds2.Tables[0].Rows[j]["c_time"].ToString();
                                }
                                lastime = ds2.Tables[0].Rows[j]["c_time"].ToString();
                            }
                        //累计在岗时间


                        if (Tjin != "" && Tchu != "")
                        {
                            DateTime time11 = Convert.ToDateTime(Tjin);
                            DateTime time21 = Convert.ToDateTime(Tchu);
                            if (time21 > time11)
                            {
                                System.TimeSpan ND11 = time21 - time11;
                                T1 += (double)ND11.TotalSeconds / (60 * 60);   //秒数差
                            }
                        }
                        if (Tjin != "" && Tchu != "")
                        {
                            DateTime time12 = Convert.ToDateTime(Tjin);
                            DateTime time22 = Convert.ToDateTime(Tchu);
                            if (time22 < time12)
                            {
                                System.TimeSpan ND22 = time12 - time22;
                                T2 += (double)ND22.TotalSeconds / (60 * 60);   //秒数差
                            }
                        }

                    }
                    //到岗时间
                    TableCell td2 = new TableCell();
                    td2.Text = firsttime;
                    tr.Cells.Add(td2);
                    //最后一次刷卡时间
                    TableCell td_last = new TableCell();
                    td_last.Text = lastime;
                    tr.Cells.Add(td_last);
                    //累计在岗
                    double T3 = 0;
                    TableCell td3 = new TableCell();
                    string nowtime2 = DateTime.Now.ToString("yyyy-MM-dd");
                    DateTime timenowtime2 = Convert.ToDateTime(nowtime2);
                    DateTime strendtime2 = Convert.ToDateTime(strendti);
                    DateTime time8 = Convert.ToDateTime(strendti + " " + gettime4);//下午下班时间6：00
                    if (firsttime != "")
                    {
                        DateTime time5 = Convert.ToDateTime(strendti + " " + gettime2);//上午下班时间11：45
                        DateTime time4 = Convert.ToDateTime(strendti + " " + gettime3);//下午上班时间12：45

                        DateTime time9 = Convert.ToDateTime(strendti + " " + gettime5);//晚上上班班时间6：30
                        DateTime time6 = Convert.ToDateTime(firsttime);//第一次刷卡时间

                        System.TimeSpan ND1 = time4 - time5;//中午午休时间
                        double wuxiu = (double)ND1.TotalSeconds / (60 * 60);   //秒数差
                        System.TimeSpan ND2 = time9 - time8;//下午晚休时间
                        double wanxiu = (double)ND2.TotalSeconds / (60 * 60);   //秒数差

                        string nowtim3 = DateTime.Now.ToString();
                        DateTime time3 = Convert.ToDateTime(nowtim3);//当前时间
                        if (timenowtime2 == strendtime2)//如果时间为当前系统的年月日（同当日明细查询）
                        {
                            if (time3 > time8 && lastime != "")//当前系统的时间大于下午下班时间
                            {
                                DateTime time7 = Convert.ToDateTime(lastime);//最后一次刷卡时间
                                if (time7 > time9)//最后一次刷卡时间大于晚上上班时间
                                {
                                    System.TimeSpan ND11 = time7 - time6;//最后一次刷卡时间-第一次刷卡时间
                                    T3 = (double)ND11.TotalSeconds / (60 * 60) - wuxiu - wanxiu;

                                }
                                if (time7 < time9 && time7 > time4)//最后一次刷卡时间小于晚上上班时间，大于下午下班时间12：45<time<6:30
                                {
                                    System.TimeSpan ND1c = time7 - time6;//最后一次刷卡时间-第一次刷卡时间
                                    T3 = (double)ND1c.TotalSeconds / (60 * 60) - wuxiu;
                                }
                                if (time7 < time4)//最后一次刷卡时间小于下午上班时间
                                {
                                    System.TimeSpan ND2c = time7 - time6;
                                    T3 = (double)ND2c.TotalSeconds / (60 * 60);
                                }




                            }
                            if (time3 < time8)//当前系统时间小于下午下班时间
                            {

                                if (time3 > time4)//当前系统大于下午上班时间
                                {
                                    System.TimeSpan ND31 = time3 - time6;//中午午休时间
                                    T3 = (double)ND31.TotalSeconds / (60 * 60) - wuxiu;
                                }
                                if (time3 < time4)
                                {
                                    System.TimeSpan ND41 = time3 - time6;//中午午休时间
                                    T3 = (double)ND41.TotalSeconds / (60 * 60);

                                }

                            }



                        }
                        else if (lastime != "")
                        {
                            DateTime time7 = Convert.ToDateTime(lastime);//最后一次刷卡时间
                            if (time7 > time9)//最后一次刷卡时间大于晚上上班时间
                            {
                                System.TimeSpan ND3 = time7 - time6;
                                T3 = (double)ND3.TotalSeconds / (60 * 60) - wuxiu - wanxiu;

                            }
                            if (time7 > time4 && time7 < time9)//最后一次刷卡时间大于下午上班时间小于晚上上班时间
                            {
                                System.TimeSpan ND4 = time7 - time6;
                                T3 = (double)ND4.TotalSeconds / (60 * 60) - wuxiu;

                            }
                            if (time7 < time4)//最后一次刷卡时间小于下午上班时间
                            {
                                System.TimeSpan ND5 = time7 - time6;
                                T3 = (double)ND5.TotalSeconds / (60 * 60);

                            }
                        }

                    }
                    if (T3 < 0)
                    {
                        T3 = 0;

                    }

                    td3.Text = T3.ToString("f2");
                    tr.Cells.Add(td3);
                    TADD1 += double.Parse(td3.Text);//累加
                    //累计上岗时间
                    TableCell td4 = new TableCell();
                    td4.Text = T1.ToString("f2");
                    tr.Cells.Add(td4);
                    TADD2 += double.Parse(td4.Text);//累计
                    //累计离岗
                    TableCell td5 = new TableCell();
                    td5.Text = T2.ToString("f2");
                    tr.Cells.Add(td5);

                    TADD3 += double.Parse(td5.Text);//累加
                    TableCell td6 = new TableCell();
                    TableCell td7 = new TableCell();
                    TableCell td8 = new TableCell();

                    double T4 = 0; //累计加班
                    string canbu = "", chebu = "";//餐补，车补

                    if (firsttime != "" && lastime != "")
                    {
                        DateTime timelast = Convert.ToDateTime(lastime);//最后一次刷卡时间
                        DateTime timewanban = Convert.ToDateTime(strendti + " " + gettime5);//加班时间
                        if (timelast > timewanban)
                        {
                            System.TimeSpan ND4 = timelast - timewanban;//中午午休时间
                            T4 = (double)ND4.TotalSeconds / (60 * 60);
                        }
                        DateTime timecanbu = Convert.ToDateTime(strendti + " " + getcanbu);//餐补时间
                        DateTime timechebu = Convert.ToDateTime(strendti + " " + getchebu);//车补时间
                        String sql_canbu = "SELECT * FROM [userinfo] where number='" + Session["number"] + "'";
                        using (SqlDataReader dr_canbu = SqlHelper.ExecuteReader(CommandType.Text, sql_canbu))
                        {
                            if (dr_canbu.Read())
                            {
                                if (dr_canbu["canbu"] != System.DBNull.Value)
                                {
                                    canbu = dr_canbu.GetString(dr_canbu.GetOrdinal("canbu"));
                                }
                                if (dr_canbu["chebu"] != System.DBNull.Value)
                                {
                                    chebu = dr_canbu.GetString(dr_canbu.GetOrdinal("chebu"));
                                }

                            }
                            SqlHelper.Close();
                        }
                        if (timelast < timecanbu)
                        {
                            canbu = "";
                        }
                        if (timelast < timechebu)
                        {
                            chebu = "";

                        }
                    }
                    td6.Text = T4.ToString("f2"); ;
                    tr.Cells.Add(td6);
                    TADD4 += double.Parse(td6.Text);//累加
                    //餐补
                    td7.Text = canbu;
                    tr.Cells.Add(td7);
                    if (canbu != "")
                    {
                        CANADD += double.Parse(canbu);
                    }
                    //车补

                    td8.Text = chebu;
                    tr.Cells.Add(td8);
                    if (chebu != "")
                    {
                        CHEADD += double.Parse(chebu);
                    }
                    //缺勤
                    TableCell td9 = new TableCell();
                    //获取请假记录
                    string Fen1 = "", Fen2 = "";//请假打分、出勤打分（迟到、早退、旷工）

                    String sql_qingjia = "SELECT * FROM [qingjia] where q_number='" + Session["number"] + "' and q_enddate>='" + strendti + " " + gettime1 + "' and q_startdate<='" + strendti + " " + gettime4 + "' and q_statue='4'";
                    string qingjiashixiang = "";
                    bool kaoqinbool = false;
                    using (SqlDataReader dr_qingjia = SqlHelper.ExecuteReader(CommandType.Text, sql_qingjia))
                    {


                        if (dr_qingjia.Read())
                        {

                            qingjiashixiang = dr_qingjia.GetString(dr_qingjia.GetOrdinal("q_shixiang"));
                            kaoqinbool = true;
                            if (qingjiashixiang == "事假")
                            {
                                Fen1 = getshijia;
                            }
                            if (qingjiashixiang == "临时假")
                            {
                                Fen1 = getlinshijia;
                            }
                            if (qingjiashixiang == "年假")
                            {
                                Fen1 = getnianxiu;
                            }
                            if (qingjiashixiang == "病假")
                            {
                                Fen1 = getbingjia;
                            }
                            SqlHelper.Close();
                        }
                        else
                            if (firsttime == "")
                            {
                                if (timenowtime2 < strendtime2)
                                {
                                    qingjiashixiang = "暂未记录";
                                }
                                else
                                {
                                    string[] sArray = strendti.Split('-');
                                    string nianfen = sArray[0] + "-" + sArray[1];

                                    DateTime t = Convert.ToDateTime(strendti); ;
                                    String sql_gongzuo = "SELECT * FROM [gongzuori] where YearMon='" + nianfen + "'";
                                    SqlParameter[] sps_gongzuo = new SqlParameter[]
                                  {
                                    new SqlParameter("@number",ddr_banci.SelectedItem.Text),
                                    };
                                    bool gongzuoritf = false;
                                    string getnianfen = "";
                                    using (SqlDataReader dr_gongzuo = SqlHelper.ExecuteReader(CommandType.Text, sql_gongzuo, sps_gongzuo))
                                    {


                                        if (dr_gongzuo.Read())
                                        {
                                            getnianfen = dr_gongzuo.GetString(dr_gongzuo.GetOrdinal("gongzuodate"));


                                            getnianfen = getnianfen.Replace("\n", string.Empty).Replace("\r", string.Empty);


                                            string[] str_getnianfen = getnianfen.Split(',');
                                            foreach (string _s in str_getnianfen)
                                            {
                                                if (strendti == _s)
                                                {
                                                    gongzuoritf = true;
                                                    break;

                                                }
                                            }

                                            SqlHelper.Close();
                                        }
                                    }
                                    if (!gongzuoritf)
                                    {
                                        qingjiashixiang = "休假";

                                    }
                                    else
                                    {
                                        qingjiashixiang = "旷工";
                                    }
                                }





                            }
                        SqlHelper.Close();
                    }
                    td9.Text = qingjiashixiang;
                    tr.Cells.Add(td9);
                    //状态
                    TableCell td10 = new TableCell();
                    td10.Text = " ";
                    if (timenowtime2 < strendtime2)
                    {
                        td10.Text = "暂未记录";
                    }
                    else if (!kaoqinbool)
                    {
                        if (qingjiashixiang == "休假")
                        {
                            td10.Text = "";
                        }
                        else if (firsttime != "")
                        {

                            int Intgetchidao = int.Parse(getchidao) * 60;//迟到时间范围
                            int Intgetzaot = int.Parse(getzaotiu) * 60;//早退时间范围
                            int Intgetqueqin = int.Parse(getqueqin) * 60;//缺勤时间范围，超过为旷工
                            td10.Text = "";
                            DateTime DTcardgettime1 = Convert.ToDateTime(firsttime);//获取第一次刷卡时间
                            string kaoqintime = strendti + " " + gettime1;//获取早上考勤时间
                            DateTime DTkaoqintime = Convert.ToDateTime(kaoqintime);
                            System.TimeSpan NDkaoqin = DTcardgettime1 - DTkaoqintime;//早上考勤
                            int nTSeconds = (int)NDkaoqin.TotalSeconds;   //秒数差

                            string getnowtime = DateTime.Now.ToString();
                            DateTime getnowdate = Convert.ToDateTime(getnowtime);//当前时间

                            if (DTcardgettime1 > DTkaoqintime)//第一次刷卡时间大于早上考勤时间
                            {
                                if (nTSeconds <= Intgetchidao)//迟到时间小于等于迟到考勤时间范围
                                {

                                    td10.Text = "正常,";


                                }
                                else
                                    if (nTSeconds >= Intgetchidao && nTSeconds <= Intgetqueqin)
                                    {

                                        td10.Text = "迟到,";

                                        Fen2 = getligang;
                                    }
                                    else
                                        if (nTSeconds > Intgetqueqin)
                                        {
                                            td10.Text = "旷工,";
                                            Fen2 = getkuanggong;
                                        }
                            }
                            else
                            {

                                td10.Text = "正常,";

                            }

                            if (lastime != "")
                            {
                                DateTime timelast1 = Convert.ToDateTime(lastime);//最后一次刷卡时间
                                System.TimeSpan NDkaoqinxiawu = time8 - timelast1;//下午考勤
                                int nTSecondsxiawu = (int)NDkaoqinxiawu.TotalSeconds;   //秒数差
                                if (timelast1 < time8 && getnowdate > time8)//最后一次刷卡时间小于下午下班时间
                                {
                                    if (nTSecondsxiawu <= Intgetzaot)//迟到时间小于等于迟到考勤时间范围
                                    {
                                        td10.Text += "正常";
                                    }
                                    else
                                        if (nTSecondsxiawu > Intgetzaot && nTSecondsxiawu <= Intgetqueqin)
                                        {
                                            td10.Text += "早退";
                                            if (Fen2 != getkuanggong && Fen2 == getligang)
                                            {
                                                int intligang = int.Parse(getligang) + int.Parse(getligang);
                                                Fen2 = intligang.ToString();
                                            }
                                            if (Fen2 != getkuanggong && Fen2 != getligang)
                                            {
                                                Fen2 = getligang;
                                            }



                                        }
                                        else
                                            if (nTSecondsxiawu > Intgetqueqin)
                                            {
                                                td10.Text += "旷工";
                                                Fen2 = getkuanggong;
                                            }

                                }


                                if (getnowdate > time8 && timelast1 > time8)
                                {
                                    td10.Text += "正常";
                                }

                                if (DTcardgettime1 <= DTkaoqintime && timelast1 >= time8)
                                {

                                    td10.Text = "正常,正常";

                                }
                                if (getnowdate > time8)
                                {
                                    if (nTSecondsxiawu + nTSeconds > Intgetqueqin)
                                    {
                                        Fen2 = getkuanggong;
                                    }
                                }
                            }
                            else
                            {
                                if (getnowdate > time8)
                                {
                                    td10.Text += "旷工";
                                    Fen2 = getkuanggong;
                                }

                            }
                        }
                        else
                        {


                            td10.Text = "缺勤";
                            Fen2 = getkuanggong;

                        }
                    }


                    tr.Cells.Add(td10);
                    TableCell td11 = new TableCell();
                    int intfen1 = 0, intfen2 = 0;
                    if (Fen1 != "")
                    {
                        intfen1 = int.Parse(Fen1);
                    }
                    if (Fen2 != "")
                    {
                        intfen2 = int.Parse(Fen2);
                    }
                    int zongfen = intfen1 + intfen2;
                    FADD += zongfen;
                    td11.Text = zongfen.ToString();
                    tr.Cells.Add(td11);
                    tb_result.Rows.Add(tr);
                }
                TableRow trZ = new TableRow();
                TableCell tdZ1 = new TableCell();
                tdZ1.Text = "累加";
                trZ.Cells.Add(tdZ1);
                TableCell tdZ2 = new TableCell();
                tdZ2.Text = "";
                TableCell tdZ_last = new TableCell();
                tdZ_last.Text = "";
                trZ.Cells.Add(tdZ_last);
                trZ.Cells.Add(tdZ2);
                TableCell tdZ3 = new TableCell();
                tdZ3.Text = TADD1.ToString("f2");
                trZ.Cells.Add(tdZ3);
                TableCell tdZ4 = new TableCell();
                tdZ4.Text = TADD2.ToString("f2");
                trZ.Cells.Add(tdZ4);
                TableCell tdZ5 = new TableCell();
                tdZ5.Text = TADD3.ToString("f2");
                trZ.Cells.Add(tdZ5);
                TableCell tdZ6 = new TableCell();
                tdZ6.Text = TADD4.ToString("f2");
                trZ.Cells.Add(tdZ6);
                //餐补
                TableCell tdZ7 = new TableCell();
                tdZ7.Text = CANADD.ToString("f1");
                trZ.Cells.Add(tdZ7);
                TableCell tdZ8 = new TableCell();
                tdZ8.Text = CHEADD.ToString("f1");
                trZ.Cells.Add(tdZ8);
                TableCell tdZ9 = new TableCell();
                tdZ2.Text = "";
                trZ.Cells.Add(tdZ9);
                TableCell tdZ10 = new TableCell();
                tdZ10.Text = "";
                trZ.Cells.Add(tdZ10);
                //考勤分
                TableCell tdZ11 = new TableCell();
                tdZ11.Text = FADD.ToString();
                trZ.Cells.Add(tdZ11);
                tb_result.Rows.Add(trZ);


            }
        }

    }

    public void initialization() //页面初始化
    {
       
        string dd = DropDownList1.Text;
        if (dd == "")
        {
            return;
        }
        Session["name1"] = null;
        if (Session["time1"] != null)
        {
            Session["time1"] = null;
            Session["time2"] = null;

        }
        Session["time1"] = startime.Text;
        Session["time2"] = endtime.Text;
        // addkaohe.Visible = false;
        defen.Visible = false;
        gvShow_ri.Visible = true;
        gvShow_zhou.Visible = true;
        gvShow_qing.Visible = true;
        zhoujihua.Visible = true;
        rijihua.Visible = true;
        qingjia.Visible = true;
        kaoqin.Visible = true;
        yuangongxinxi.Visible = true;
        GridViewDataBind_ri(DropDownList1.SelectedItem.Text);
        GridViewDataBind_zhou(DropDownList1.SelectedItem.Text);
        GridViewDataBind_qing(DropDownList1.SelectedItem.Text);
          kaoqinhanshu(DropDownList1.SelectedItem.Text);
    }
    protected void seek_Click(object sender, EventArgs e) //查看员工考核表
    {


        string dd = DropDownList1.Text;
        if (dd == "")
        {
            return;
        }
        Session["name1"] = null;
        if (Session["time1"] != null)
        {
            Session["time1"] = null;
            Session["time2"] = null;

        }
        Session["time1"] = startime.Text;
        Session["time2"] = endtime.Text;
        // addkaohe.Visible = false;
       
        defen.Visible = false;
        gvShow_ri.Visible = true;
        gvShow_zhou.Visible = true;
        gvShow_qing.Visible = true;
        zhoujihua.Visible = true;
        rijihua.Visible = true;
        qingjia.Visible = true;
        kaoqin.Visible = true;
        seektab.Visible = true;
        GridViewDataBind_ri(DropDownList1.SelectedItem.Text);
        GridViewDataBind_zhou(DropDownList1.SelectedItem.Text);
        GridViewDataBind_qing(DropDownList1.SelectedItem.Text);
        kaoqinhanshu(DropDownList1.SelectedItem.Text);






        /*   addkaohe.Visible = false; ;
           seektab.Visible = true;
           zhoujihua.Visible = false;
           rijihua.Visible = false;
           qingjia.Visible = false;
           gvShow_ri.Visible = false;
           gvShow_zhou.Visible = false;
           gvShow_qing.Visible = false;
           defen.Visible = false;
         */
    }


    protected void seek_fen_Click(object sender, EventArgs e) //工作考核总得分统计
    {
        // addkaohe.Visible = false;
        
        seektab.Visible = false;
        gvShow_ri.Visible = false;
        gvShow_zhou.Visible = false;
        gvShow_qing.Visible = false;
        zhoujihua.Visible = false;
        rijihua.Visible = false;
        qingjia.Visible = false;
        defen.Visible = true;
        kaoqin.Visible = false;
        yuangongxinxi.Visible = false;




    }

    protected void Button1_Click(object sender, EventArgs e)
    {

        initialization();

    }
















    
    protected void bnt_defen_Click(object sender, EventArgs e)
    {
        kaohe_all();
    }
    public void kaohe_all()
    {

        TableHeaderRow thr = new TableHeaderRow();
        //构建表头
        string[] s_th = "员工编号,员工姓名,年月,总得分".Split(',');
        foreach (string _s in s_th)
        {
            TableHeaderCell thd = new TableHeaderCell();
            thd.Text = _s;
            thr.Cells.Add(thd);
        }

        kaohe_result.Rows.Add(thr);
        string time = tb_nian.Text + "-" + tb_yue.SelectedItem.Text;
        int time2 = int.Parse(tb_yue.SelectedItem.Text) + 1;

        float in_fen = 0;
        string endtime;
        if (time2 < 10)
        {
            endtime = tb_nian.Text + "-" + "0" + time2.ToString();
        }
        else
        {
            endtime = tb_nian.Text + "-" + time2.ToString();
        }
        //获取下级员工号
        string sql2 = "select * from [userinfo] where zaizhi='在职'";

        DataTable dt_number = SqlHelper.ExecuteDataTable(sql2);
        int i_number = dt_number.Rows.Count;
        if (i_number < 0 || i_number == 0)
        {
            dt_number = SqlHelper.ExecuteDataTable(sql2);
            i_number = dt_number.Rows.Count;

        }
        //获取考核数据
        string sql_all = "select * from [RiJiHua] where r_time>'" + time + "' and r_time<'" + endtime + "' order by r_time ASC";
        DataTable dt_all = SqlHelper.ExecuteDataTable(sql_all);

        string number = "", name = "";
        for (int j_number = 0; j_number < i_number; j_number++)
        {
            float fen = 0;
            number = dt_number.Rows[j_number]["number"].ToString();
            name = dt_number.Rows[j_number]["name"].ToString();
            TableRow trZ = new TableRow();
            TableCell tdZ1 = new TableCell();
            tdZ1.Text = number;
            trZ.Cells.Add(tdZ1);
            TableCell tdZ2 = new TableCell();
            tdZ2.Text = name;
            trZ.Cells.Add(tdZ2);
            TableCell tdZ3 = new TableCell();
            tdZ3.Text = time;
            trZ.Cells.Add(tdZ3);
            DataRow[] dr_allnumber = dt_all.Select("r_number='" + number + "'");
            int i_all = dr_allnumber.Length;
            for (int j_all = 0; j_all < i_all; j_all++)
            {
                string str = dr_allnumber[j_all]["r_defen"].ToString();
                // bool a = Double.TryParse(str,System.Globalization.NumberStyles ,out in_fen);

                if (dr_allnumber[j_all]["r_defen"].ToString() != "")
                {
                    in_fen = float.Parse(dr_allnumber[j_all]["r_defen"].ToString());
                    fen += in_fen;
                }


            }
            TableCell tdZ4 = new TableCell();
            tdZ4.Text = fen.ToString();
            trZ.Cells.Add(tdZ4);
            kaohe_result.Rows.Add(trZ);
        }

    }
}