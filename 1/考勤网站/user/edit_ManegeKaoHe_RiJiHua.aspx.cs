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

public partial class user_edit_ManegeKaoHe_RiJiHua : System.Web.UI.Page
{

    ZhouJiHua person1 = null;
    RiJiHua person2 = null;
    qingjia person3 = null;
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
            z_time.Text = DateTime.Now.ToString("yyyy-MM-dd");

            Calendar2.Visible = false;
            r_time.Text = DateTime.Now.ToString("yyyy-MM-dd");

            Calendar3.Visible = false;
            startdate.Text = DateTime.Now.ToString("yyyy-MM-dd");

            Calendar4.Visible = false;
            enddate.Text = DateTime.Now.ToString("yyyy-MM-dd");


            string fun = Request.QueryString["operfun"];
            string operid = Request.QueryString["operid"];
            string operleibie = null;
            String sql10 = "SELECT s_leibie FROM [ShenQingShenBao] where id='" + operid + "'";
            //             System.Diagnostics.Debug.Assert(false, sql10);//打印调试信息
            DataTable dt_leibie = SqlHelper.ExecuteDataTable(sql10);
            int i_all = dt_leibie.Rows.Count;

            if (i_all > 0)
            {
                operleibie = dt_leibie.Rows[0][0].ToString();
            }

            if (fun == "edit" && operleibie == "周计划")
            {

                string sql = "select * from [ZhouJiHua] where id='" + operid + "'";
                //   System.Diagnostics.Debug.Assert(false, sql);
                using (SqlDataReader dr = SqlHelper.ExecuteReader(CommandType.Text, sql))
                {
                    if (dr.Read())  //读入需要的内容
                    {
                        person1 = new ZhouJiHua();
                        _ID.Text = dr["id"].ToString();
                        z_time.Text = dr["z_time"].ToString();
                        z_jihua.Text = dr["z_jihua"].ToString();
                        z_mubiao.Text = dr["z_mubiao"].ToString();
                        z_zhanbi.Text = dr["z_zhanbi"].ToString();
                        z_shishiqingkuang.Text = dr["z_shishiqingkuang"].ToString();
                        z_jieguo.Text = dr["z_jieguo"].ToString();
                        z_pingyu.Text = dr["z_pingyu"].ToString();
                        TextBox1.Text = dr["z_name"].ToString();
                    }

                }
            }

            if (fun == "edit" && operleibie == "日计划")
            {

                string sql = "select * from [RiJiHua] where id='" + operid + "'";
                //   System.Diagnostics.Debug.Assert(false, sql);
                using (SqlDataReader dr = SqlHelper.ExecuteReader(CommandType.Text, sql))
                {
                    if (dr.Read())  //读入需要修改的内容
                    {
                        person2 = new RiJiHua();
                        _ID.Text = dr["id"].ToString();
                        r_time.Text = dr["r_time"].ToString();
                        r_jihua.Text = dr["r_jihua"].ToString();
                        r_mubiao.Text = dr["r_mubiao"].ToString();
                        r_gongshi.Text = dr["r_gongshi"].ToString();
                        r_neirong.Text = dr["r_neirong"].ToString();
                        r_jieguo.Text = dr["r_jieguo"].ToString();
                       r_pingyu.Text = dr["r_pingyu"].ToString();
                       r_pingyu.Text = dr["r_defen"].ToString();
                        TextBox1.Text = dr["r_name"].ToString();
                    }

                }
            }

            if (fun == "edit" && operleibie == "请假")
            {

                string sql = "select * from [qingjia] where id='" + operid + "'";
                //   System.Diagnostics.Debug.Assert(false, sql);
                using (SqlDataReader dr = SqlHelper.ExecuteReader(CommandType.Text, sql))
                {
                    if (dr.Read())  //读入需要修改的内容
                    {
                        person3 = new qingjia();
                        _ID.Text = dr["Q_ID"].ToString();
                        ddl_shixiang.Text = dr["q_shixiang"].ToString();
                        string str2 = dr.GetString(dr.GetOrdinal("q_startdate"));
                        string[] sArray = str2.Split(' ');
                        startdate.Text = sArray[0];
                        string[] time1 = sArray[1].Split(':');
                        time11_d1.Text = time1[0];
                        time11_d2.Text = time1[1];
                        string str1 = dr.GetString(dr.GetOrdinal("q_enddate"));
                        string[] sArray1 = str1.Split(' ');
                        enddate.Text = sArray1[0];
                        string[] time2 = sArray1[1].Split(':');
                        time12_d1.Text = time2[0];
                        time12_d2.Text = time2[1];
                        thing.Text = dr["q_things"].ToString();
                        tianall.Text = dr["q_all"].ToString();

                    }

                }
            }

            GridViewDataBind();


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

        gvShow.Style.Add("table-layout", "fixed");
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
    protected void Calendar1_SelectionChanged(object sender, EventArgs e)
    {
        z_time.Text = Calendar1.SelectedDate.ToString();
        if (!(z_time.Text == ""))
        {
            Calendar1.Visible = false;


            z_time.Text = Calendar1.SelectedDate.ToString("yyyy-MM-dd");

            //  System.DateTime newDate = new DateTime();
            //  Response.Write(newDate.DayOfWeek);
        }
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        Calendar1.Visible = true;
        Calendar2.Visible = false;
        Calendar3.Visible = false;
        Calendar4.Visible = false;
    }

    protected void Calendar2_SelectionChanged(object sender, EventArgs e)
    {
        r_time.Text = Calendar2.SelectedDate.ToString();
        if (!(r_time.Text == ""))
        {
            Calendar2.Visible = false;


            r_time.Text = Calendar2.SelectedDate.ToString("yyyy-MM-dd");
            //  System.DateTime newDate = new DateTime();
            //  Response.Write(newDate.DayOfWeek);
        }
    }
    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        Calendar1.Visible = false;
        Calendar2.Visible = true;
        Calendar3.Visible = false;
        Calendar4.Visible = false;

    }

    protected void Calendar3_SelectionChanged(object sender, EventArgs e)
    {
        startdate.Text = Calendar3.SelectedDate.ToString();
        if (!(startdate.Text == ""))
        {
            Calendar3.Visible = false;

            startdate.Text = Calendar3.SelectedDate.ToString("yyyy-MM-dd");
        }
    }
    protected void LinkButton3_Click(object sender, EventArgs e)
    {
        Calendar1.Visible = false;
        Calendar2.Visible = false;
        Calendar3.Visible = true;
        Calendar4.Visible = false;
    }

    protected void Calendar4_SelectionChanged(object sender, EventArgs e)
    {
        enddate.Text = Calendar4.SelectedDate.ToString();
        if (!(enddate.Text == ""))
        {
            Calendar4.Visible = false;

            enddate.Text = Calendar4.SelectedDate.ToString("yyyy-MM-dd");
        }
    }
    protected void LinkButton4_Click(object sender, EventArgs e)
    {
        Calendar1.Visible = false;
        Calendar2.Visible = false;
        Calendar3.Visible = false;
        Calendar4.Visible = true;
    }
    /// 绑定数据
    /// </summary>
    /// 

    public void GridViewDataBind()
    {
      //string sql = "SELECT * FROM [userinfo] WHERE name =" + TextBox1.Text;
        string sql = "SELECT * FROM [userinfo] WHERE name = '"+ TextBox1.Text +"'";
     //   System.Diagnostics.Debug.Assert(false, sql);
       System.Diagnostics.Debug.Write("sql =" + sql );
      //  string sql = "SELECT * FROM [userinfo] WHERE name = '李四'";
        DataTable dt = SqlHelper.ExecuteDataTable(sql);
        int i_all = dt.Rows.Count;
        for (int i = 0; i < i_all; i++)
        {
           // TextBox1.Text = dt.Rows[i]["name"].ToString();
            TextBox2.Text = dt.Rows[i]["number"].ToString();
            TextBox3.Text = dt.Rows[i]["jibie"].ToString();
            TextBox4.Text = dt.Rows[i]["bumen"].ToString();
            TextBox6.Text = dt.Rows[i]["ruzhi"].ToString();
            string a = dt.Rows[i]["shangji"].ToString();
            string sql_name = "SELECT * FROM [userinfo] WHERE number ='" + a + "'";  //解决部门和入职时间问题
            DataTable dt2 = SqlHelper.ExecuteDataTable(sql_name);
            int i_all2 = dt2.Rows.Count;
            if (i_all2 > 0)
            {
                TextBox5.Text = dt2.Rows[0]["name"].ToString();

            }

        }
        /*
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
         */
        string sql2 = "select * from [ShenQingShenBao] where s_name = '" + TextBox1.Text + "' order by s_statue asc,s_time desc";
        DataSet ds2 = SqlHelper.ExecuteDataSet(sql2);
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
            //    LinkButton lb = row.Cells[2].FindControl("lbEdit") as LinkButton;
            //  LinkButton lt = row.Cells[3].FindControl("lbDelete") as LinkButton;
            string str = row.Cells[2].Text;


            if (str == "1")
            {
                //     lb.Visible = false;
                //      lt.Visible = false;

                row.Cells[2].Text = "已批阅";

            }
            else
            {

                //    lb.Visible = true;
                //    lt.Visible = true;
                row.Cells[2].Text = "未批阅";
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
 

    protected void lbSubmitAddzhou_Click(object sender, EventArgs e)  //周计划
    {

        if (Session["number"] == null)
        {
            Response.Write("<script>alert('登录时间过期，请重新登录');window.location='../login.aspx';</script>");
            return;
        }

        string sql6 = "update [ZhouJiHua] set z_jihua=@z_jihua,z_mubiao=@z_mubiao,z_zhanbi=@z_zhanbi,z_shishiqingkuang=@z_shishiqingkuang,z_jieguo=@z_jieguo,z_time=@z_time,z_pingyu=@z_pingyu,z_statue=@z_statue where id=" + _ID.Text;
        // string sql6 = "update [ZhouJiHua] set z_jihua=@z_jihua,z_mubiao=@z_mubiao,z_zhanbi=@z_zhanbi,z_shishiqingkuang=@z_shishiqingkuang,z_jieguo=@z_jieguo,z_time=@z_time where z_id='14'" ;
        // System.Diagnostics.Debug.Assert(false, sql6);//打印调试信息
        SqlParameter[] sps6 = new SqlParameter[8];
        sps6[0] = new SqlParameter("@z_jihua", z_jihua.Text);
        sps6[1] = new SqlParameter("@z_mubiao", z_mubiao.Text);
        sps6[2] = new SqlParameter("@z_zhanbi", z_zhanbi.Text);
        sps6[3] = new SqlParameter("@z_shishiqingkuang", z_shishiqingkuang.Text);
        sps6[4] = new SqlParameter("@z_jieguo", z_jieguo.Text);
        sps6[5] = new SqlParameter("@z_time", z_time.Text);
        sps6[6] = new SqlParameter("@z_pingyu", z_pingyu.Text);
        sps6[7] = new SqlParameter("@z_statue", "1");
        int i = SqlHelper.ExecuteNonQuery(sql6, sps6);



        string sql7 = "update [ShenQingShenBao] set s_time=@s_time, s_statue=@s_statue where id=" + _ID.Text;
        SqlParameter[] sps7 = new SqlParameter[2];
        sps7[0] = new SqlParameter("@s_time", z_time.Text);
        sps7[1] = new SqlParameter("@s_statue", "1");
        int j = SqlHelper.ExecuteNonQuery(sql7, sps7);

        if (i > 0 && j > 0)
        {

            Response.Redirect("ManegeKaoHe.aspx");
        }

    }




    protected void lbSubmitAddri_Click(object sender, EventArgs e)  //日计划
    {

        if (Session["number"] == null)
        {
            Response.Write("<script>alert('登录时间过期，请重新登录');window.location='../login.aspx';</script>");
            return;
        }
        string typestr = r_defen.Text;
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
            ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('得分大于等于0')</script>");

            return;
        }


        string sql4 = "update [RiJiHua] set r_jihua=@r_jihua,r_mubiao=@r_mubiao,r_gongshi=@r_gongshi,r_neirong=@r_neirong,r_jieguo=@r_jieguo,r_time=@r_time, r_pingyu=@r_pingyu,r_defen=@r_defen,r_statue=@r_statue where id=" + _ID.Text;
        SqlParameter[] sps4 = new SqlParameter[9];

        sps4[0] = new SqlParameter("@r_jihua ", r_jihua.Text);
        sps4[1] = new SqlParameter("@r_mubiao ", r_mubiao.Text);
        sps4[2] = new SqlParameter("@r_gongshi ", r_gongshi.Text);
        sps4[3] = new SqlParameter("@r_neirong ", r_neirong.Text);
        sps4[4] = new SqlParameter("@r_jieguo", r_jieguo.Text);
        sps4[5] = new SqlParameter("@r_time", r_time.Text);
        sps4[6] = new SqlParameter("@r_pingyu", r_pingyu.Text);
        sps4[7] = new SqlParameter("@r_defen", r_defen.Text);
        sps4[8] = new SqlParameter("@r_statue", "1");
        int i = SqlHelper.ExecuteNonQuery(sql4, sps4);


        string sql5 = "update [ShenQingShenBao] set s_time=@s_time,s_statue=@s_statue where id=" + _ID.Text;
        SqlParameter[] sps5 = new SqlParameter[2];
        sps5[0] = new SqlParameter("@s_time", r_time.Text);
        sps5[1] = new SqlParameter("@s_statue", "1");
        int k = SqlHelper.ExecuteNonQuery(sql5, sps5);

        if (i>0 && k > 0)
        {

            Response.Redirect("ManegeKaoHe.aspx");
        }

       // Response.Write("<script>alert('修改成功');window.location='information.aspx';</script>");

    }

    protected void lbSubmitAddshenqing_Click(object sender, EventArgs e)   //请假
    {

        if (Session["number"] == null)
        {
            Response.Write("<script>alert('登录时间过期，请重新登录');window.location='../login.aspx';</script>");
            return;
        }
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
        if (time1 > time2)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('开始时间大于结束时间，请重新选择')</script>");


        }
        string shixiang = ddl_shixiang.SelectedItem.Text;
        if ((shixiang == "事假" || shixiang == "临时假" || shixiang == "病假" || shixiang == "年假" || shixiang == "加班") && tianall.Text == "")
        {
            ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('申请天数不能为空')</script>");

            return;

        }
        else
        {
            string sql8 = "update [qingjia] set q_startdate=@c_startdate,q_enddate=@c_enddate,q_things=@c_things,q_shixiang=@q_shixiang,q_statue=@q_statue,q_all=@q_all where Q_ID=" + _ID.Text;
            SqlParameter[] sps8 = new SqlParameter[6];
            sps8[0] = new SqlParameter("@c_startdate", strtime1);
            sps8[1] = new SqlParameter("@c_enddate", strtime2);
            sps8[2] = new SqlParameter("@c_things", thing.Text);
            sps8[3] = new SqlParameter("@q_shixiang", ddl_shixiang.SelectedItem.Text);
            sps8[4] = new SqlParameter("@q_statue", "3");
            sps8[5] = new SqlParameter("@q_all", tianall.Text);

            int i = SqlHelper.ExecuteNonQuery(sql8, sps8);

            if (i > 0 )
            {
                Response.Redirect("ManegeKaoHe.aspx");

            }

        }
    }

}

