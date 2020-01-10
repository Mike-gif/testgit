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
 //  DataSet ds1;
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
         //   Calendar3.Visible = false;
         //   addZhouJiHua.Visible = false;  //隐藏添加考核的整个表，等点击“添加下属考核表”按钮以后，再做显示。
        //    addqingjia.Visible = false; 
            seektab.Visible = true; //员工考勤位置、班次、时间选择
            defen.Visible = false; //隐藏统计得分的整个表，等点击“工作考核总得分统计”按钮以后，再做显示。
       /*     zhoujihua.Visible = true;
            rijihua.Visible = true;
            qingjia.Visible = true;
            gvShow_ri.Visible = true;
            gvShow_zhou.Visible = true;
            gvShow_qing.Visible = true; */
         
            //adddate.Text = DateTime.Now.ToString("yyyy-MM-dd");
            Calendar4.Visible = false;
            z_time.Text = DateTime.Now.ToString("yyyy-MM-dd");

            Calendar5.Visible = false;
            r_time.Text = DateTime.Now.ToString("yyyy-MM-dd");

            Calendar6.Visible = false;
            startdate.Text = DateTime.Now.ToString("yyyy-MM-dd");

            Calendar7.Visible = false;
            enddate.Text = DateTime.Now.ToString("yyyy-MM-dd");
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
                //seektab.Visible = true;
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
             // kaoqinhanshu(DropDownList1.SelectedItem.Text);
                
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

     /*   GridViewDataBind_ri(DropDownList1.SelectedItem.Text);
        GridViewDataBind_zhou(DropDownList1.SelectedItem.Text);
        GridViewDataBind_qing(DropDownList1.SelectedItem.Text); */

     /*   string dd = DropDownList1.Text;
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
        gvShow_ri.Visible = true;
        gvShow_zhou.Visible = true;
        gvShow_qing.Visible = true;
        zhoujihua.Visible = true;
        rijihua.Visible = true;
        qingjia.Visible = true;
        GridViewDataBind_ri(DropDownList1.SelectedItem.Text);
        GridViewDataBind_zhou(DropDownList1.SelectedItem.Text);
        GridViewDataBind_qing(DropDownList1.SelectedItem.Text);
     */
       
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
        endtime.Text = Calendar2.SelectedDate.ToString();
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
    /*  protected void LinkButton3_Click(object sender, EventArgs e)
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
     */
    protected void Calendar4_SelectionChanged(object sender, EventArgs e)
    {
        z_time.Text = Calendar4.SelectedDate.ToString();
        if (!(z_time.Text == ""))
        {
            Calendar4.Visible = false;


            z_time.Text = Calendar4.SelectedDate.ToString("yyyy-MM-dd");

           
        }
    }

    /*
      protected void Calendar1_SelectionChanged(object sender, EventArgs e)
         {
             int num = Calendar1.SelectedDates.Count;
             for (int i = 0; i <= num - 1; i++)
             {
                 z_time.Text = Calendar1.SelectedDates[i].ToShortDateString();
             }
         }
     */
    protected void LinkButton4_Click(object sender, EventArgs e)
    {
        Calendar4.Visible = true;
        Calendar5.Visible = false;
        Calendar6.Visible = false;
        Calendar7.Visible = false;
    }

    protected void Calendar5_SelectionChanged(object sender, EventArgs e)
    {
        r_time.Text = Calendar5.SelectedDate.ToString();
        if (!(r_time.Text == ""))
        {
            Calendar5.Visible = false;


            r_time.Text = Calendar5.SelectedDate.ToString("yyyy-MM-dd");
            
        }
    }
    protected void LinkButton5_Click(object sender, EventArgs e)
    {
        Calendar4.Visible = false;
        Calendar5.Visible = true;
        Calendar6.Visible = false;
        Calendar7.Visible = false;

    }

    protected void Calendar6_SelectionChanged(object sender, EventArgs e)
    {
        startdate.Text = Calendar6.SelectedDate.ToString();
        if (!(startdate.Text == ""))
        {
            Calendar6.Visible = false;

            startdate.Text = Calendar6.SelectedDate.ToString("yyyy-MM-dd");
        }
    }
    protected void LinkButton6_Click(object sender, EventArgs e)
    {
        Calendar4.Visible = false;
        Calendar5.Visible = false;
        Calendar6.Visible = true;
        Calendar7.Visible = false;
    }

    protected void Calendar7_SelectionChanged(object sender, EventArgs e)
    {
        enddate.Text = Calendar7.SelectedDate.ToString();
        if (!(enddate.Text == ""))
        {
            Calendar7.Visible = false;

            enddate.Text = Calendar7.SelectedDate.ToString("yyyy-MM-dd");
        }
    }
    protected void LinkButton7_Click(object sender, EventArgs e)
    {
        Calendar4.Visible = false;
        Calendar5.Visible = false;
        Calendar6.Visible = false;
        Calendar7.Visible = true;
    }
    /// 绑定数据
    /// </summary>
    /// 

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

        string sql2 = "select * from [RiJiHua] where r_number IN (select number from [userinfo] where  name='" + name + "') and r_time>='" + timestr1 + "' and r_time<='" + timestr2 + "' order by r_statue asc, r_time desc";

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

        string timestr1 = "", timestr2 = "", timestr3 = "";
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

        DateTime sunday = time1.AddDays(Convert.ToDouble((0 - Convert.ToInt16(time1.DayOfWeek)))); //得到一周的第一天是yyyy/MM/dd，第一天从周日开始
        timestr3 = sunday.AddDays(1).ToString("yyyy-MM-dd");//得到一周的周一是yyyy-MM-dd

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

        string sql2 = "select * from [ZhouJiHua] where z_number IN (select number from [userinfo] where  name='" + name + "') and z_time>='" + timestr3 + "' and z_time<='" + timestr2 + "' order by z_statue asc, z_time desc";

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

        string sql2 = "select * from [qingjia] where q_number IN (select number from [userinfo] where  name='" + name + "') and ((q_startdate>='" + timestr1 + "' and  q_startdate <='" + timestr2 + "') or (q_enddate>='" + timestr1 + "' and  q_enddate <='" + timestr2 + "') or (q_startdate<='" + timestr1 + "' and  q_enddate >='" + timestr2 + "') or (q_time>='" + timestr1 + "' and  q_time <='" + timestr2 + "'))  order by q_statue asc, q_time desc"; //gridview的初始化排序通过此处order by对数据库的排序实现,第一排序字段为q_statue升序，第二排序规则为q_time降序

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

            string str = row.Cells[8].Text;
            LinkButton lb = row.Cells[9].FindControl("lbEdit") as LinkButton;
            LinkButton lt = row.Cells[9].FindControl("lbDelete") as LinkButton;
            LinkButton le = row.Cells[9].FindControl("lbxiugai") as LinkButton;
            if (str == "2" || str == "3" || str == "0" || str == "1")
            {

                lb.Visible = true;
                lt.Visible = true;
                le.Visible = true;
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
                    row.Cells[8].Text = "未批阅";
                }
            }
            else
            {
                lb.Visible = false;
                lt.Visible = false;
                le.Visible = false;
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
    /// <summary>
    /// 单击某行的操作时
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvShow_ri_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        string opername = e.CommandName;
        string opervalue = e.CommandArgument.ToString();
        if (opername == "Edit")
        {
            Response.Redirect("edit_ManegeKaoHe_RiJiHua.aspx?operfun=edit&operid=" + opervalue);
        }

    }
    protected void gvShow_zhou_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        string opername = e.CommandName;
        string opervalue = e.CommandArgument.ToString();
    /*    if (opername == "Delete")
        {

            string sql3 = "delete from [ZhouJiHua] where id=@id";
            SqlParameter[] sps3 = new SqlParameter[] { 
          
           new SqlParameter("@id", opervalue),
            };

            int result = SqlHelper.ExecuteNonQuery(sql3, sps3);
           // if (result > 0)
              //  Response.Redirect("ManegeKaoHe.aspx");

        }
        else 
        */
        if (opername == "Edit")
        {
            Response.Redirect("edit_ManegeKaoHe_Zhoujihua.aspx?operfun=edit&operid=" + opervalue);
        }
    }

   
  

    protected void gvShow_qing_RowCommand(object sender, GridViewCommandEventArgs e)
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
            
                Response.Redirect("ManegeKaoHe.aspx");

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
                     Response.Redirect("ManegeKaoHe.aspx");
                    

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
                            Response.Redirect("ManegeKaoHe.aspx");
                        

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
                    //ddr_address.Text = "大门";
                    //ddr_address.SelectedItem.Text = "路边";
                    ////姓名
                    //TableCell td1 = new TableCell();
                    //td1.Text = Session["name"].ToString();
                    //tr.Cells.Add(td1);
                   // ddr_address.SelectedItem.Text = "大门";
                   //    System.Diagnostics.Debug.Write("ddr_address.SelectedItem.Text=" + ddr_address.SelectedItem.Text); //打印调试信息
                    
                    //   System.Diagnostics.Debug.Write("number=" + Session["number"]);
                    //string sql2 = "select * from [RiJiHua] where r_number IN (select number from [userinfo] where  name='" + name + "') and r_time>='" + timestr1 + "' and r_time<='" + timestr2 + "' order by r_time desc";
                        // string str_sql = "SELECT * FROM [cardinf] where c_id IN (select number from [userinfo] where  name='" + name + "') and c_addr='" + ddr_address.SelectedItem.Text + "'and c_time>'" + strendti + "' and c_time<'" + starttime + "' ORDER BY c_time";
                        string str_sql = "SELECT * FROM [cardinf] where c_id IN (select number from [userinfo] where  name='" + name + "') and c_addr='大门' and c_time>'" + strendti + "' and c_time<'" + starttime + "' ORDER BY c_time"; //ddr_address.SelectedItem.Text 有bug存在，暂时采用直接输入的方式
                    //string str_sql = "SELECT * FROM [cardinf] where c_id='" + Session["number"] + "'and c_addr='" + ddr_address.SelectedItem.Text + "'and c_time>'" + strendti + "' and c_time<'" + starttime + "' ORDER BY c_time";
                    //   System.Diagnostics.Debug.Assert(false, str_sql);//打印调试信息
                        /* 类似如下选择下属，初始化的语句，可解决ddr_address.SelectedItem.Text选择大门进行初始化的问题。
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
                    //seektab.Visible = true;
                    string name1 = Session["name1"].ToString();
                     DropDownList1.Text= name1;
                    if (DropDownList1.Items.FindByText(name1) != null)
                    {
                        DropDownList1.Text = name1;
                    }
                         */
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
    public void  initialization() //页面初始化
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
        seektab.Visible = true;
        addZhouJiHua.Visible = false;  
        addqingjia.Visible = false; 
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
    protected void Button1_Click(object sender, EventArgs e)
    {

        initialization();
       /* if (Session["number"] == null)
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
        gvShow_ri.Visible = true;
        gvShow_zhou.Visible = true;
        gvShow_qing.Visible = true;
        zhoujihua.Visible = true;
        rijihua.Visible = true;
        qingjia.Visible = true;
        GridViewDataBind_ri(DropDownList1.SelectedItem.Text);
        GridViewDataBind_zhou(DropDownList1.SelectedItem.Text);
        GridViewDataBind_qing(DropDownList1.SelectedItem.Text);
        */
    }
 //   protected void Button2_Click(object sender, EventArgs e)
 //   {
      /*  if (Session["number"] == null)
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
        String sql1 = "SELECT * FROM [RiJiHua] where r_time='" + adddate.Text + "' and r_name='" + ddl_name2.SelectedItem.Text + "'";
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
    */
  //  }


    protected void Btnzhou_Click(object sender, EventArgs e)  //周计划
    {
        //  string opername = e.CommandName;                //CommandName和CommandArgument来源于BUTTON的参数传递，CommandName传递命令，CommandArgument传递参数
        //  string opervalue = e.CommandArgument.ToString();


        if (Session["number"] == null)
        {
            Response.Write("<script>alert('登录时间过期，请重新登录');window.location='../login.aspx';</script>");
            return;
        }
       // String sql1 = "SELECT * FROM [ZhouJiHua] where z_time='" + z_time.Text + "' and z_number='" + Session["number"] + "'";
    //    String sql1 = "SELECT * FROM [ZhouJiHua] where z_time='" + z_time.Text + "' and z_name='" + DropDownList1.SelectedItem.Text + "'";
        String sql1 = "SELECT * FROM [ZhouJiHua] where z_time='" + z_time.Text + "' and z_number='" + ddl_name2.SelectedItem.Value + "'";
        DataTable dt_allgongzuori1 = SqlHelper.ExecuteDataTable(sql1);
        int i_all = dt_allgongzuori1.Rows.Count;


       // String sql19 = "SELECT * FROM [ShenQingShenBao] where s_time='" + z_time.Text + "' and s_number='" + Session["number"] + "' and s_leibie='周计划'";
        String sql19 = "SELECT * FROM [ShenQingShenBao] where s_time='" + z_time.Text + "' and s_number='" + ddl_name2.SelectedItem.Value + "' and s_leibie='周计划'";
        // System.Diagnostics.Debug.Assert(false, sql19);//打印调试信息
        DataTable dt_allgongzuori2 = SqlHelper.ExecuteDataTable(sql19);
        int j_all = dt_allgongzuori2.Rows.Count;


        if (i_all > 0 || j_all > 0) //在数据表[ZhouJiHua]中查找 z_time='" + z_time.Text + "' and z_number='" + Session["number"] + "'"（该用户日历选择的时间下） 的记录是否存在，如果已经有记录就返回。
        {

            ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('该日期已经存在，请重新选择')</script>");
            return;
        }

        string opertime = DateTime.Now.ToString("yyyyMMddhhmmss");
        string sql6 = "insert into [ZhouJiHua](z_number,z_name,z_jihua ,z_mubiao,z_zhanbi,z_shishiqingkuang,z_jieguo,z_statue,z_time,id)values(@z_number,@z_name,@z_jihua ,@z_mubiao,@z_zhanbi,@z_shishiqingkuang,@z_jieguo,@z_statue,@z_time,@id)";
        SqlParameter[] sps6 = new SqlParameter[10];
      //  sps6[0] = new SqlParameter("@z_number", Session["number"]);
        sps6[0] = new SqlParameter("@z_number", ddl_name2.SelectedItem.Value);
      //  sps6[1] = new SqlParameter("@z_name", Session["name"]);
        sps6[1] = new SqlParameter("@z_name", ddl_name2.SelectedItem.Text);
        sps6[2] = new SqlParameter("@z_jihua ", z_jihua.Text);
        sps6[3] = new SqlParameter("@z_mubiao ", z_mubiao.Text);
        sps6[4] = new SqlParameter("@z_zhanbi ", z_zhanbi.Text);
        sps6[5] = new SqlParameter("@z_shishiqingkuang ", z_shishiqingkuang.Text);
        sps6[6] = new SqlParameter("@z_jieguo", z_jieguo.Text);
        sps6[7] = new SqlParameter("@z_statue", "0");
        sps6[8] = new SqlParameter("@z_time", z_time.Text);
        sps6[9] = new SqlParameter("@id", opertime);
        int i = SqlHelper.ExecuteNonQuery(sql6, sps6);

        /* if (i > 0)
         {
           
             Response.Redirect("ShenQingShenBao.aspx");
         }
         */
        string sql7 = "insert into [ShenQingShenBao](s_number,s_name,s_time,s_leibie,s_statue,id)values(@s_number,@s_name,@s_time ,@s_leibie,@s_statue,@id)";
        SqlParameter[] sps7 = new SqlParameter[6];
        sps7[0] = new SqlParameter("@s_number", ddl_name2.SelectedItem.Value);
        sps7[1] = new SqlParameter("@s_name", ddl_name2.SelectedItem.Text);
        sps7[2] = new SqlParameter("@s_time", z_time.Text);
        sps7[3] = new SqlParameter("@s_leibie ", "周计划");
        sps7[4] = new SqlParameter("@s_statue", "0");
        sps7[5] = new SqlParameter("@id", opertime);
        int j = SqlHelper.ExecuteNonQuery(sql7, sps7);


        if (i > 0 && j > 0)
        {

            // Response.Redirect("ShenQingShenBao.aspx");
            // Response.Redirect("ShenQingShenBao2.aspx?operfun=Clicked&operid=" + opervalue);
           // Response.Redirect("ShenQingShenBao2.aspx?operfun=Clicked&operid=" + opertime);
            Response.Redirect("ManegeKaoHe.aspx");
        }

        else if (i > 0 && j == 0)
        {
            string sql14 = "delete from [ZhouJiHua] where id=@id";
            SqlParameter[] sps14 = new SqlParameter[] { 
                          new SqlParameter("@id", opertime),
                           };
            int result_ZhouJiHua = SqlHelper.ExecuteNonQuery(sql14, sps14);
        }
        else if (i == 0 && j > 0)
        {
            string sql15 = "delete from [ShenQingShenBao] where id=@id";
            SqlParameter[] sps15 = new SqlParameter[] { 
                          new SqlParameter("@id", opertime),
                           };
            int result_ShenQingShenBao = SqlHelper.ExecuteNonQuery(sql15, sps15);
        }
        //  Response.Write("<script>alert('添加成功');window.location='information.aspx';</script>");
        /*  if (i > 0)
          {
              gvShow.DataBind();
              GridViewDataBind();
              Response.Redirect("KaoHe.aspx");
          }
          Response.Write("<script>alert('添加成功');window.location='information.aspx';</script>")
      */
    }




    protected void Btnri_Click(object sender, EventArgs e)  //日计划
    {

        if (Session["number"] == null)
        {
            Response.Write("<script>alert('登录时间过期，请重新登录');window.location='../login.aspx';</script>");
            return;
        }
        String sql1 = "SELECT * FROM [RiJiHua] where r_time='" + r_time.Text + "' and r_number='" + ddl_name2.SelectedItem.Value + "'";
        DataTable dt_allgongzuori1 = SqlHelper.ExecuteDataTable(sql1);
        int i_all = dt_allgongzuori1.Rows.Count;


        String sql20 = "SELECT * FROM [ShenQingShenBao] where s_time='" + r_time.Text + "' and s_number='" + ddl_name2.SelectedItem.Value + "' and s_leibie='日计划'";
        DataTable dt_allgongzuori2 = SqlHelper.ExecuteDataTable(sql20);
        int j_all = dt_allgongzuori2.Rows.Count;


        if (i_all > 0 || j_all > 0) //在数据表[RiJiHua]中查找 k_time='" + r_time.Text + "' and k_number='" + Session["number"] + "'"（该用户日历选择的时间下） 的记录是否存在，如果已经有记录就返回。
        {

            ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('该日期已经存在，请重新选择')</script>");
            return;
        }

        string opertime = DateTime.Now.ToString("yyyyMMddhhmmss");
        string sql4 = "insert into [RiJiHua](r_number,r_name,r_jihua ,r_mubiao,r_gongshi,r_neirong,r_jieguo,r_pingyu,r_defen,r_statue,r_time,id)values(@r_number,@r_name,@r_jihua ,@r_mubiao,@r_gongshi,@r_neirong,@r_jieguo,@r_pingyu,@r_defen,@r_statue,@r_time,@id)";
        SqlParameter[] sps4 = new SqlParameter[12];
        sps4[0] = new SqlParameter("@r_number", ddl_name2.SelectedItem.Value);
        sps4[1] = new SqlParameter("@r_name", ddl_name2.SelectedItem.Text);
        sps4[2] = new SqlParameter("@r_jihua ", r_jihua.Text);
        sps4[3] = new SqlParameter("@r_mubiao ", r_mubiao.Text);
        sps4[4] = new SqlParameter("@r_gongshi ", r_gongshi.Text);
        sps4[5] = new SqlParameter("@r_neirong ", r_neirong.Text);
        sps4[6] = new SqlParameter("@r_jieguo", r_jieguo.Text);
        sps4[7] = new SqlParameter("@r_pingyu", "");
        sps4[8] = new SqlParameter("@r_defen", "");
        sps4[9] = new SqlParameter("@r_statue", "0");
        sps4[10] = new SqlParameter("@r_time", r_time.Text);
        sps4[11] = new SqlParameter("@id", opertime);
        int i = SqlHelper.ExecuteNonQuery(sql4, sps4);

        /* if (i > 0)
         {
           
             Response.Redirect("ShenQingShenBao.aspx");
         }
         */
        string sql5 = "insert into [ShenQingShenBao](s_number,s_name,s_time,s_leibie,s_statue,id)values(@s_number,@s_name,@s_time ,@s_leibie,@s_statue,@id)";
        SqlParameter[] sps5 = new SqlParameter[6];
        sps5[0] = new SqlParameter("@s_number", ddl_name2.SelectedItem.Value);
        sps5[1] = new SqlParameter("@s_name", ddl_name2.SelectedItem.Text);
        sps5[2] = new SqlParameter("@s_time", r_time.Text);
        sps5[3] = new SqlParameter("@s_leibie ", "日计划");
        sps5[4] = new SqlParameter("@s_statue", "0");
        sps5[5] = new SqlParameter("@id", opertime);
        int j = SqlHelper.ExecuteNonQuery(sql5, sps5);

        if (i > 0 && j > 0)
        {

            Response.Redirect("ManegeKaoHe.aspx");
        }
        else if (i > 0 && j == 0)
        {
            string sql16 = "delete from [RiJiHua] where id=@id";
            SqlParameter[] sps16 = new SqlParameter[] { 
                          new SqlParameter("@id", opertime),
                           };
            int result_RiJiHua = SqlHelper.ExecuteNonQuery(sql16, sps16);
        }
        else if (i == 0 && j > 0)
        {
            string sql17 = "delete from [ShenQingShenBao] where id=@id";
            SqlParameter[] sps17 = new SqlParameter[] { 
                          new SqlParameter("@id", opertime),
                           };
            int result_ShenQingShenBao = SqlHelper.ExecuteNonQuery(sql17, sps17);
        }
        //  Response.Write("<script>alert('添加成功');window.location='information.aspx';</script>");
        /*  if (i > 0)
          {
              gvShow.DataBind();
              GridViewDataBind();
              Response.Redirect("KaoHe.aspx");
          }
          Response.Write("<script>alert('添加成功');window.location='information.aspx';</script>")
      */
    }

    protected void Btnshenqing_Click(object sender, EventArgs e)   //请假
    {

        //  System.Diagnostics.Debug.Write("q="+q.ToString()); //打印调试信息

        string strtime1 = startdate.Text + " " + time11_d1.SelectedItem.Text + ":" + time11_d2.SelectedItem.Text;
        string strtime2 = enddate.Text + " " + time12_d1.SelectedItem.Text + ":" + time12_d2.SelectedItem.Text;
        DateTime time1 = Convert.ToDateTime(strtime1);
        DateTime time2 = Convert.ToDateTime(strtime2);
        DateTime time4 = Convert.ToDateTime(startdate.Text);
        DateTime time5 = Convert.ToDateTime(enddate.Text);
        string strtime4 = time4.ToString("yyyy-MM");
        string strtime5 = time5.ToString("yyyy-MM");
        if (strtime4 != strtime5)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('开始时间和结束时间不在同一个月，请分开填写')</script>");

            return;
        }
        string shixiang = ddl_shixiang.SelectedItem.Text;
        if ((shixiang == "事假" || shixiang == "临时假" || shixiang == "病假" || shixiang == "年假" || shixiang == "加班") && tianall.Text == "")
        {
            ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('申请天数不能为空')</script>");

            return;

        }
        string typestr = tianall.Text;
        bool intqingalltype = true;
        char[] ch = new char[typestr.Length];
        ch = typestr.ToCharArray();
        for (int j = 0; j < typestr.Length; j++)
        {
            // byte tempbype = Convert.ToByte(typestr[j]);

            if (((ch[j] < 48) || (ch[j] > 57)) && ch[j] != 46)
            {
                intqingalltype = false;
                break;
            }

        }
        if (intqingalltype == false)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('只能输入数值')</script>");

            return;

        }
        float a = 0;
        if (float.TryParse(typestr, out a) == false && typestr != "")
        {
            ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('申请天数(小时)大于0')</script>");

            return;
        }

        //if (shixiang == "加班")
        //{
        //    //读取工作日
        //    string sql_allgongzuori = "select * from [gongzuori]";
        //    DataTable dt_allgongzuori = SqlHelper.ExecuteDataTable(sql_allgongzuori);
        //    string strendti = startdate.Text;
        //    string[] sArray = strendti.Split('-');
        //    string nianfen = sArray[0] + "-" + sArray[1];

        //    DateTime t = Convert.ToDateTime(strendti); ;
        //    //SqlHelper.Close();
        //    string getnianfen = "";
        //    DataRow[] dr_allgongzuori = dt_allgongzuori.Select("YearMon='" + nianfen + "'");
        //    if (dr_allgongzuori.Length > 0)
        //    {

        //        getnianfen = dr_allgongzuori[0]["gongzuodate"].ToString();


        //        getnianfen = getnianfen.Replace("\n", string.Empty).Replace("\r", string.Empty);


        //        string[] str_getnianfen = getnianfen.Split(',');
        //        foreach (string _s in str_getnianfen)
        //        {
        //            if (strendti == _s)
        //            {


        //                ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('加班申请只申请非工作日加班的情况,工作日加班根据下班时间自动计算餐补和车补')</script>");
        //                return;

        //            }
        //        }
        //    }

        //}
        if (time1 > time2)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('开始时间大于结束时间，请重新选择')</script>");

            return;
        }
        else
        {

            /*       if(q==0)
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('请确认天数/小时数填写正确：请假(按天计算)、加班(按小时计算)必填,填写数值,如0.5')</script>");
                        q = 1;
                        return ;
                    }
        
        */
            string opertime = DateTime.Now.ToString("yyyyMMddhhmmss");
            string sql8 = "insert into [qingjia](q_number,q_name,q_startdate,q_enddate,q_things,q_shixiang,q_statue,q_all,id,q_time,ImageUrl)values(@c_number,@c_name,@c_startdate,@c_enddate,@c_things,@q_shixiang,@q_statue,@q_all,@id,@q_time,@ImageUrl)";
            SqlParameter[] sps8 = new SqlParameter[11];
            sps8[0] = new SqlParameter("@c_number", ddl_name2.SelectedItem.Value);
            sps8[1] = new SqlParameter("@c_name", ddl_name2.SelectedItem.Text);
            sps8[2] = new SqlParameter("@c_startdate", strtime1);
            sps8[3] = new SqlParameter("@c_enddate", strtime2);
            sps8[4] = new SqlParameter("@c_things", thing.Text);
            sps8[5] = new SqlParameter("@q_shixiang", ddl_shixiang.SelectedItem.Text);
            sps8[6] = new SqlParameter("@q_statue", "3");
            sps8[7] = new SqlParameter("@q_all", tianall.Text);
            sps8[8] = new SqlParameter("@id", opertime);
            sps8[9] = new SqlParameter("@q_time", DateTime.Now.ToString("yyyy-MM-dd"));
            sps8[10] = new SqlParameter("@ImageUrl", this.Label2.Text);


            int i = SqlHelper.ExecuteNonQuery(sql8, sps8);


            /*   if (i > 0)
               {
                  // gvShow.DataBind();
                  // GridViewDataBind();
                   Response.Redirect("ShenQingShenBao.aspx");
               }*/
            //Response.Write("<script>alert('添加成功');window.location='information.aspx';</script>")

            // System.DateTime newDate = new DateTime(int.Parse(year), int.Parse(month), int.Parse(sec));
            string sql9 = "insert into [ShenQingShenBao](s_number,s_name,s_time,s_leibie,s_statue,id)values(@s_number,@s_name,@s_time ,@s_leibie,@s_statue,@id)";
            SqlParameter[] sps9 = new SqlParameter[6];
            sps9[0] = new SqlParameter("@s_number", ddl_name2.SelectedItem.Value);
            sps9[1] = new SqlParameter("@s_name", ddl_name2.SelectedItem.Text);
            sps9[2] = new SqlParameter("@s_time", DateTime.Now.ToString("yyyy-MM-dd"));
            sps9[3] = new SqlParameter("@s_leibie ", "请假");
            sps9[4] = new SqlParameter("@s_statue", "0");
            // sps9[5] = new SqlParameter("@id", DateTime.Now.ToString("yyyyMMddhhmmss"));
            //  sps9[5] = new SqlParameter("@id", DateTime.Now.ToString("hhmmss"));
            //sps9[5] = new SqlParameter("@id", DateTime.Now.ToString("yyyy-MM-dd"));
            sps9[5] = new SqlParameter("@id", opertime);
            int j = SqlHelper.ExecuteNonQuery(sql9, sps9);

            if (i > 0 && j > 0)
            {

                Response.Redirect("ManegeKaoHe.aspx");
            }
            else if (i > 0 && j == 0)
            {
                string sql18 = "delete from [qingjia] where id=@id";
                SqlParameter[] sps18 = new SqlParameter[] { 
                          new SqlParameter("@id", opertime),
                           };
                int result_qingjia = SqlHelper.ExecuteNonQuery(sql18, sps18);
            }
            else if (i == 0 && j > 0)
            {
                string sql19 = "delete from [ShenQingShenBao] where id=@id";
                SqlParameter[] sps19 = new SqlParameter[] { 
                          new SqlParameter("@id", opertime),
                           };
                int result_ShenQingShenBao = SqlHelper.ExecuteNonQuery(sql19, sps19);
            }
        }
    }




    protected void Btn_shangchuan_Click(object sender, EventArgs e)
    {
        bool fileIsValid = false;

        if (this.FileUpload1.HasFile)
        {
            String fileExtension = System.IO.Path.GetExtension(this.FileUpload1.FileName).ToLower();
            String[] restrictExtension = { ".gif", ".jpg", ".bmp", ".png" };
            for (int i = 0; i < restrictExtension.Length; i++)
            {
                if (fileExtension == restrictExtension[i])
                {
                    fileIsValid = true;
                }
            }

            if (fileIsValid == true)
            {
                try
                {
                    string filename = FileUpload1.FileName;
                    //获取上传名字
                    string fileext = System.IO.Path.GetExtension(filename);
                    //返回指定图片的后缀
                    string filenamaes = DateTime.Now.ToString("yyyyMMddHHffss") + fileext;
                    //获取当前时间
                    this.FileUpload1.SaveAs(Server.MapPath("~/images/") + filenamaes);
                    //  this.Image1.ImageUrl = "~/images/" + FileUpload1.FileName;
                    // this.FileUpload1.SaveAs(Server.MapPath("~/images/") + FileUpload1.FileName); //文件保存的路径 D:\1\考勤系统相关\考勤系统v2.0(未完成)\考勤网站\images
                    this.Label1.Text = "文件上传成功";
                    //    this.Label1.Text += "<li>" + "原文件路径：" + this.FileUpload1.PostedFile.FileName;
                    // this.Label2.Text = this.FileUpload1.PostedFile.FileName;
                    this.Label2.Text = filenamaes;
                }
                catch (Exception ex)
                {
                    this.Label1.Text = "无法上传文件" + ex.Message;
                }
            }
            else
            {
                this.Label1.Text = "只能够上传后缀为.gif, .jpg, .bmp, .png的文件夹";
            }
        }
    }


    protected void addtianjia_Click(object sender, EventArgs e) //添加下属考核表
    {
       // addkaohe.Visible = true;
        addZhouJiHua.Visible = true;
        addqingjia.Visible = true;
        seektab.Visible = false;
        gvShow_zhou.Visible = false;
        gvShow_ri.Visible = false;
        gvShow_qing.Visible = false;
        zhoujihua.Visible = false;
        rijihua.Visible = false;
        qingjia.Visible = false;
        kaoqin.Visible = false;
        defen.Visible = false;
        yuangongxinxi.Visible = false;

         for (int i = 0; i <= 23; i++)
            {

                if (i < 10)
                {

                    time11_d1.Items.Add('0' + i.ToString());
                    time12_d1.Items.Add('0' + i.ToString());

                }
                else
                {
                    time11_d1.Items.Add(i.ToString());
                    time12_d1.Items.Add(i.ToString());


                }
            }
            for (int i = 0; i < 60; i++)
            {

                if (i < 10)
                {
                    time11_d2.Items.Add('0' + i.ToString());

                    time12_d2.Items.Add('0' + i.ToString());

                }
                else
                {
                    time11_d2.Items.Add(i.ToString());

                    time12_d2.Items.Add(i.ToString());

                }

            }
            
            time11_d1.Text = "09";
            time12_d1.Text = "18";
      
    }


    protected void seek_Click(object sender, EventArgs e) //批准下属考核表
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
        addZhouJiHua.Visible = false;
        addqingjia.Visible = false; 
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
        addZhouJiHua.Visible = false;
        addqingjia.Visible = false; 
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
    protected void bnt_defen_Click(object sender, EventArgs e) //统计按钮
    {
        addZhouJiHua.Visible = false;
        addqingjia.Visible = false;
        seektab.Visible = false;
        gvShow_ri.Visible = false;
        gvShow_zhou.Visible = false;
        gvShow_qing.Visible = false;
        zhoujihua.Visible = false;
        rijihua.Visible = false;
        qingjia.Visible = false;
        defen.Visible = true;
        kaoqin.Visible = false; 
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
    protected void btn_excel_Click(object sender, EventArgs e) //导出到excel
    {
        kaohe_all();
        if (kaohe_result.Rows.Count > 1)
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
            kaohe_result.RenderControl(oHW);



            //输出时加上"<meta http-equiv=\"content-type\" content=\"application/ms-excel; charset=UTF-8\"/>"解决编码问题

            //返回浏览器，
            HttpContext.Current.Response.Write("<meta http-equiv=\"content-type\" content=\"application/ms-excel; charset=UTF-8\"/>" + oSW.ToString());
            HttpContext.Current.Response.End();
        }

    }
}