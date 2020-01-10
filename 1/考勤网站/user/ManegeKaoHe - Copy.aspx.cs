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
public partial class user_ManegeKaoHe : System.Web.UI.Page
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
            tb_nian.Text = DateTime.Now.Year.ToString();
            Calendar1.Visible = false;
            Calendar2.Visible = false;
            Calendar3.Visible = false;
            addkaohe.Visible = false;  //隐藏添加考核的整个表，等点击“添加下属考核表”按钮以后，再做显示。
            seektab.Visible = false; //隐藏下属部门、级别、工号、入职等信息，等选择具体哪位下属后再做显示。
            defen.Visible = false; //隐藏统计得分的整个表，等点击“工作考核总得分统计”按钮以后，再做显示。
            adddate.Text = DateTime.Now.ToString("yyyy-MM-dd");
            string sql = "SELECT * FROM [userinfo] WHERE shangji ='" + Session["number"] + "' and zaizhi='在职'"; //查找以“我”作为上级的员工，并且在职
            string sqlnum1 = "select * from [userinfo] where zaizhi='在职' and shangji IN(select number from [userinfo] where number IN (select number from [userinfo] where shangji='" + Session["number"] + "' and zaizhi='在职'))";
            DataTable dt = SqlHelper.ExecuteDataTable(sql);
            int i_all = dt.Rows.Count;
            if (i_all < 0 || i_all == 0)
            {
                dt = SqlHelper.ExecuteDataTable(sql);
                 i_all = dt.Rows.Count;
            }
            for (int i = 0; i < i_all; i++)
            {
                DropDownList1.Items.Add(new ListItem(dt.Rows[i]["name"].ToString(), dt.Rows[i]["name"].ToString()));//增加Item 下属下拉列表
                ddl_name2.Items.Add(new ListItem(dt.Rows[i]["name"].ToString(), dt.Rows[i]["number"].ToString()));//增加Item
            }
            if (Session["name1"] != null)
            {
                string name1 = Session["name1"].ToString();
                // DropDownList1.Text= name1;
                if (DropDownList1.Items.FindByText(name1) != null)
                {
                    DropDownList1.Text = name1;
                }
                startime.Text = Session["time1"].ToString();
                endtime.Text = Session["time2"].ToString();
                GridViewDataBind(name1);
                seektab.Visible = true;
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
        }
        gvShow.Style.Add("table-layout", "fixed");
        gvShow1.Style.Add("table-layout", "fixed");
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
    protected void LinkButton3_Click(object sender, EventArgs e)
    {
        Calendar3.Visible = true;

    }
    protected void Calendar3_SelectionChanged(object sender, EventArgs e)
    {
        adddate.Text = Calendar3.SelectedDate.ToString();
        if (!(adddate.Text == ""))
        {
            Calendar3.Visible = false;

            adddate.Text = Calendar3.SelectedDate.ToString("yyyy-MM-dd");
        }
    }
    /// 绑定数据
    /// </summary>
    /// 

    public void GridViewDataBind(string name)
    {
        string sql = "SELECT * FROM [userinfo] WHERE name ='" + name + "'";
        DataTable dt = SqlHelper.ExecuteDataTable(sql);
        int i_all = dt.Rows.Count;
        for (int i = 0; i < i_all; i++)
        {
          
            TextBox2.Text = dt.Rows[i]["number"].ToString();
            TextBox3.Text = dt.Rows[i]["jibie"].ToString();
           // TextBox4.Text = dt.Rows[i]["name"].ToString();
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

        string sql2 = "select * from [kaohe] where k_number IN (select number from [userinfo] where  name='" + name + "') and k_time>='" + timestr1 + "' and k_time<='" + timestr2 + "' order by k_time desc";

        DataSet ds2 = SqlHelper.ExecuteDataSet(sql2);
       
        ds2 = SqlHelper.ExecuteDataSet(sql2);       
        Session["Table"] = ds2.Tables[0];
        gvShow.DataSource = ds2;
        gvShow.DataBind();

        foreach (GridViewRow row in gvShow.Rows)
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
            string str = row.Cells[5].Text;


            if (str == "1")
            {
                row.Cells[5].Text = "已批阅";


            }
            else
            {
                row.Cells[5].Text = "未批阅";


            }
        }

    }

    public void GridViewDataBind1()
    {
        string sql2 = "select * from [kaohe] where k_number='" + ddl_name2.SelectedItem.Value + "' and k_statue='2' order by k_time desc";
        DataSet ds2 = SqlHelper.ExecuteDataSet(sql2);
        Session["Table"] = ds2.Tables[0];
        gvShow1.DataSource = ds2;
        gvShow1.DataBind();

        foreach (GridViewRow row in gvShow1.Rows)
        {

            string str = row.Cells[7].Text;


            if (str == "2")
            {

                row.Cells[7].Text = "未批阅";
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
        if (Session["name1"] != null)
        {
            string name1 = Session["name1"].ToString();
            GridViewDataBind(name1);
        }
        else
        {
            GridViewDataBind(DropDownList1.SelectedItem.Text);
        }
    }
    protected void gvShow1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvShow.PageIndex = e.NewPageIndex;

        GridViewDataBind1();

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
    protected void gvShow1_RowDataBound(object sender, GridViewRowEventArgs e)
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

        string opername = e.CommandName;
        string opervalue = e.CommandArgument.ToString();
        if (opername == "Edit")
        {
            Response.Redirect("edit_ManegeKaoHe.aspx?operfun=edit&operid=" + Convert.ToInt32(opervalue));
        }

    }
    // <summary>
    /// 单击某行的操作时
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvShow1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        string opername = e.CommandName;
        string opervalue = e.CommandArgument.ToString();
        if (opername == "Del")
        {

            string sql2 = "delete from [kaohe] where k_id=@k_id";
            SqlParameter[] sps2 = new SqlParameter[] { 
            new SqlParameter("@k_id", Convert.ToInt32(opervalue)),
            };

            int result = SqlHelper.ExecuteNonQuery(sql2, sps2);
            if (result > 0)
            {

                gvShow1.Visible = true;
                gvShow1.DataBind();
                GridViewDataBind1();
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
    /// <summary>
    /// 排序
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvShow1_Sorting(object sender, GridViewSortEventArgs e)
    {
        DataTable tb = Session["Table"] as DataTable;
        tb.DefaultView.Sort = e.SortExpression;
        gvShow1.DataSource = tb;
        gvShow1.DataBind();
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

    protected void Button1_Click(object sender, EventArgs e)
    {
        if (Session["number"] == null)
        {
            Response.Write("<script>alert('登录时间过期，请重新登录');window.location='../login.aspx';</script>");
            return;
        }
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
        addkaohe.Visible = false;
        gvShow.Visible = true;
        GridViewDataBind(DropDownList1.SelectedItem.Text);


    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        if (Session["number"] == null)
        {
            Response.Write("<script>alert('登录时间过期，请重新登录');window.location='../login.aspx';</script>");
            return;
        }
        string dd = ddl_name2.Text;
        if (dd == "")
        {
            return;
        }
        if (Session["number"] == null)
        {
            Response.Write("<script>alert('登录时间过期，请重新登录');window.location='../login.aspx';</script>");
            return;
        }
        String sql1 = "SELECT * FROM [kaohe] where k_time='" + adddate.Text + "' and k_name='" + ddl_name2.SelectedItem.Text + "'";
        DataTable dt_allgongzuori = SqlHelper.ExecuteDataTable(sql1);
        int i_all = dt_allgongzuori.Rows.Count;

        if (i_all > 0)
        {

            ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('请日期考核已经存在，请重新选择日期添加')</script>");
            return;
        }


        string sql4 = "insert into [kaohe](k_number,k_name,k_jihua,k_wancheng,k_pingyu,k_defen,k_statue,k_time)values(@k_number,@k_name,@k_jihua,@k_wngcheng,@k_pingyu,@k_defen,@k_statue,@k_time)";
        SqlParameter[] sps4 = new SqlParameter[8];
        sps4[0] = new SqlParameter("@k_number", ddl_name2.SelectedItem.Value);
        sps4[1] = new SqlParameter("@k_name", ddl_name2.SelectedItem.Text);
        sps4[2] = new SqlParameter("@k_jihua", jihua.Text);
        sps4[3] = new SqlParameter("@k_wngcheng", wancheng.Text);
        sps4[4] = new SqlParameter("@k_pingyu", "");
        sps4[5] = new SqlParameter("@k_defen", "");
        sps4[6] = new SqlParameter("@k_statue", "2");
        sps4[7] = new SqlParameter("@k_time", adddate.Text);






        int i = SqlHelper.ExecuteNonQuery(sql4, sps4);


        if (i > 0)
        {
            gvShow1.Visible = true;
            gvShow1.DataBind();
            GridViewDataBind1();
            // Response.Redirect("ManegeKaoHe.aspx");
        }
        //Response.Write("<script>alert('添加成功');window.locat

    }

    protected void addtianjia_Click(object sender, EventArgs e) //添加下属考核表
    {
        addkaohe.Visible = true;
        seektab.Visible = false;
        gvShow.Visible = false;
        gvShow1.Visible = true;
        defen.Visible = false;
    }


    protected void seek_Click(object sender, EventArgs e) //批准下属考核表
    {
        addkaohe.Visible = false; ;
        seektab.Visible = true;
        gvShow1.Visible = false;
        gvShow.Visible = true;
        defen.Visible = false;

    }


    protected void seek_fen_Click(object sender, EventArgs e) //工作考核总得分统计
    {
        addkaohe.Visible = false;
        seektab.Visible = false;
        gvShow.Visible = false;
        gvShow1.Visible = false;
        defen.Visible = true;


    }
    protected void bnt_defen_Click(object sender, EventArgs e) //统计按钮
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

        tb_result.Rows.Add(thr);
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
        string sql2 = "select * from [userinfo] where number IN (select number from [userinfo] where shangji='" + Session["number"] + "' and zaizhi='在职')";//一级员工
        string sqlnum1 = "select * from [userinfo] where zaizhi='在职' and shangji IN(select number from [userinfo] where number IN (select number from [userinfo] where shangji='" + Session["number"] + "' and zaizhi='在职'))";

        DataTable dt_number = SqlHelper.ExecuteDataTable(sql2);
        int i_number = dt_number.Rows.Count;
        if (i_number < 0 || i_number == 0)
        {
            dt_number = SqlHelper.ExecuteDataTable(sql2);
            i_number = dt_number.Rows.Count;

        }
        //获取考核数据
        string sql_all = "select * from [kaohe] where k_time>'" + time + "' and k_time<'" + endtime + "' order by k_time ASC";
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
            DataRow[] dr_allnumber = dt_all.Select("k_number='" + number + "'");
            int i_all = dr_allnumber.Length;
            for (int j_all = 0; j_all < i_all; j_all++)
            {
                string str = dr_allnumber[j_all]["k_defen"].ToString();
               // bool a = Double.TryParse(str,System.Globalization.NumberStyles ,out in_fen);

                if (dr_allnumber[j_all]["k_defen"].ToString() != "")
                {
                    in_fen = float.Parse(dr_allnumber[j_all]["k_defen"].ToString());
                    fen += in_fen;
                }


            }
            TableCell tdZ4 = new TableCell();
            tdZ4.Text = fen.ToString();
            trZ.Cells.Add(tdZ4);
            tb_result.Rows.Add(trZ);
        }

    }
    protected void btn_excel_Click(object sender, EventArgs e) //导出到excel
    {
        kaohe_all();
        if (tb_result.Rows.Count > 1)
        {
            //Response.Clear();
            //Response.Buffer = true;
            //HttpContext.Current.Response.Charset = "UTF-8"; // 或UTF-7 以防乱码

            //Response.AppendHeader("Content-Disposition", "attachment;filename=Table.xls");
            //Response.ContentEncoding = System.Text.Encoding.GetEncoding("GB2312");
            //Response.ContentType = "application/ms-excel";//设置输出文件类型为excel文件。
            ////Response.ContentType = "application/vnd.ms-excel";//输出类型
            ////Response.Charset = "";
            ////关闭 ViewState
            //tb_result.EnableViewState = false;
            //System.IO.StringWriter tw = new System.IO.StringWriter();//将信息写入字符串
            //System.Web.UI.HtmlTextWriter hw = new System.Web.UI.HtmlTextWriter(tw);//在WEB窗体页上写出一系列连续的HTML特定字符和文本。
            ////此类提供ASP.NET服务器控件在将HTML内容呈现给客户端时所使用的格式化功能
            ////获取control的HTML

            //tb_result.RenderControl(hw);//将table中的内容输出到HtmlTextWriter对象中

            //// 把HTML写回浏览器
            //Response.Write(tw.ToString());
            //Response.Flush();
            //Response.End();
            string strFileName = "table";
            string fileName = HttpUtility.UrlEncode("JobHistoryList", Encoding.UTF8).ToString();


            //设置编码格式
            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.Charset = "UTF-8";// "UTF-8"或者"GB2312"
            HttpContext.Current.Response.ContentType = "application/vnd.ms-excel";//text/csv
            HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.UTF8;
            HttpContext.Current.Response.AppendHeader("Content-Disposition", "attachment;filename=" + fileName + ".xls");
            //导出excel
            System.IO.StringWriter oSW = new System.IO.StringWriter();
            HtmlTextWriter oHW = new HtmlTextWriter(oSW);
            tb_result.RenderControl(oHW);



            //输出时加上"<meta http-equiv=\"content-type\" content=\"application/ms-excel; charset=UTF-8\"/>"解决编码问题

            //返回浏览器，
            HttpContext.Current.Response.Write("<meta http-equiv=\"content-type\" content=\"application/ms-excel; charset=UTF-8\"/>" + oSW.ToString());
            HttpContext.Current.Response.End();
        }

    }
}