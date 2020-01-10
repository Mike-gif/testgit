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
public partial class user_ChaKanRiJiHua : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        PopupWin1.Visible = false;
        if (!Page.IsPostBack)
        {
            if (Session["number"] == null)
            {
                Response.Write("<script>alert('登录时间过期，请重新登录');window.location='../login.aspx';</script>");
                return;
            }
            Calendar1.Visible = false;
            Calendar2.Visible = false;
            String sql1 = "select * from [qingjia] where q_statue='3' and  q_number IN (select number from [userinfo] where shangji='" + Session["number"] + "')";
            DataTable dt_allgongzuori = SqlHelper.ExecuteDataTable(sql1);
            int i_all = dt_allgongzuori.Rows.Count;

            if (i_all > 0)
            {
                PopupWin1.Visible = true;
                this.PopupWin1.Message = "你有下属申请申报消息需要处理";
            }
            else
            {
                PopupWin1.Visible = false;
            }
            seeknowkaoqin();
            startime.Text = DateTime.Now.AddDays(-6).ToString("yyyy-MM-dd");
            endtime.Text = DateTime.Now.ToString("yyyy-MM-dd");
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
    //当日考勤明细
    protected void moning_Click(object sender, EventArgs e)
    {
        seeknowkaoqin();
    }
    public void seeknowkaoqin()
    {
        if (Session["number"] == null)
        {
            Response.Write("<script>alert('登录时间过期，请重新登录');window.location='../login.aspx';</script>");
            return;
        }

        string gettime1 = "", gettime2 = "", gettime3 = "", gettime4 = "", gettime5 = "", getcanbu = "", getchebu = "", getchidao = "", getzaotiu = "", getqueqin = "";//获取早上考勤时间，允许迟到时间，旷工时间,午休时间,下午下班时间,加班时间
        string getbancifirst;
        if (ddr_banci.Text != "")
        {
            getbancifirst = ddr_banci.SelectedItem.Text;
        }
        else
        {
            getbancifirst = "班次1";
        }
        String sql1 = "SELECT * FROM [KaoQinCanShu] where banci=@number";
        SqlParameter[] sps1 = new SqlParameter[]
                    {
                        new SqlParameter("@number",getbancifirst),
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

            }
            SqlHelper.Close();
        }
        TableHeaderRow thr = new TableHeaderRow();
        //构建表头
        string[] s_th = "员工编号,员工姓名,第一次刷卡(到岗)时间,最后一次刷卡(离岗)时间,累计在岗(小时),累计上岗时间(小时),累计离岗时间(小时),累计加班时间(小时),餐补,车补,缺勤,状态(早、晚)".Split(',');
        foreach (string _s in s_th)
        {
            TableHeaderCell thd = new TableHeaderCell();
            thd.Text = _s;
            thr.Cells.Add(thd);
        }

        tb_result.Rows.Add(thr);
        TableRow tr = new TableRow();

        //员工编号
        TableCell td = new TableCell();
        if (Session["number"] == null)
        {
            Response.Write("<script>alert('登录时间过期，请重新登录');window.location='../login.aspx';</script>");

        }
        td.Text = Session["number"].ToString();
        tr.Cells.Add(td);
        //姓名
        TableCell td1 = new TableCell();
        td1.Text = Session["name"].ToString();
        tr.Cells.Add(td1);
        string strendti = DateTime.Now.ToString("yyyy-MM-dd");//获取当前系统时间
        string endtime = DateTime.Now.AddDays(1).ToString("yyyy-MM-dd");
        string str_sql = "SELECT * FROM [cardinf] where c_id='" + Session["number"] + "'and c_time>'" + strendti + "' and c_time<'" + endtime + "' ORDER BY c_time";
        DataSet ds2 = SqlHelper.ExecuteDataSet(str_sql);
        int i = ds2.Tables[0].Rows.Count;
        string firsttime = "", lastime = "", Tjin = "", Tchu = "";
        bool firstcardtime = true;
        double T1 = 0, T2 = 0;
        for (int j = 0; j < i; j++)//进出时间累加计算，获得上岗和离岗的时间总和
        {

            if (ds2.Tables[0].Rows[j]["c_status"].ToString() == "进")
            {
                if (firstcardtime)
                {
                    firsttime = ds2.Tables[0].Rows[j]["c_time"].ToString();

                    firstcardtime = false;
                }
                if (j + 1 < i)
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
                    if (j + 1 < i)
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
                DateTime time1 = Convert.ToDateTime(Tjin);
                DateTime time2 = Convert.ToDateTime(Tchu);
                if (time2 > time1)
                {
                    System.TimeSpan ND = time2 - time1;
                    T1 += (double)ND.TotalSeconds / (60 * 60);   //秒数差
                }
            }
            //累计离岗时间
            if (Tjin != "" && Tchu != "")
            {
                DateTime time1 = Convert.ToDateTime(Tjin);
                DateTime time2 = Convert.ToDateTime(Tchu);
                if (time2 < time1)
                {
                    System.TimeSpan ND = time1 - time2;
                    T2 += (double)ND.TotalSeconds / (60 * 60);   //秒数差
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
        DateTime time8 = Convert.ToDateTime(strendti + " " + gettime4);//下午下班时间
        if (firsttime != "")
        {

            string nowtime2 = DateTime.Now.ToString();
            DateTime time3 = Convert.ToDateTime(nowtime2);//当前时间
            DateTime time4 = Convert.ToDateTime(strendti + " " + gettime3);//下午上班时间
            DateTime time5 = Convert.ToDateTime(strendti + " " + gettime2);//上午下班时间

            DateTime time6 = Convert.ToDateTime(firsttime);//第一次刷卡时间
            DateTime time9 = Convert.ToDateTime(strendti + " " + gettime5);//晚上上班班时间6：30

            System.TimeSpan ND1 = time4 - time5;//中午午休时间
            double wuxiu = (double)ND1.TotalSeconds / (60 * 60);   //秒数差
            System.TimeSpan ND2 = time9 - time8;//下午晚休时间
            double wanxiu = (double)ND2.TotalSeconds / (60 * 60);   //秒数差


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
                if (time3 < time4)//当前系统时间小于下午上班时间
                {
                    System.TimeSpan ND41 = time3 - time6;//当前时间-第一次刷卡时间
                    T3 = (double)ND41.TotalSeconds / (60 * 60);

                }

            }


        }
        if (T3 < 0)
        {
            T3 = 0;
        }
        td3.Text = T3.ToString("f2");
        tr.Cells.Add(td3);
        //累计上岗时间
        if (T1 < 0)
        {
            T1 = 0;
        }
        TableCell td4 = new TableCell();
        td4.Text = T1.ToString("f2");
        tr.Cells.Add(td4);
        //累计离岗
        if (T2 < 0)
        {
            T2 = 0;
        }
        TableCell td5 = new TableCell();
        td5.Text = T2.ToString("f2");
        tr.Cells.Add(td5);


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
        //餐补
        td7.Text = canbu;
        tr.Cells.Add(td7);
        //车补

        td8.Text = chebu;
        tr.Cells.Add(td8);
        //缺勤
        TableCell td9 = new TableCell();
        //获取请假记录
        String sql_qingjia = "SELECT * FROM [qingjia] where q_number='" + Session["number"] + "' and q_enddate>='" + strendti + " " + gettime1 + "' and q_startdate<='" + strendti + " " + gettime4 + "' and q_statue='4'";
        bool gongzuoritf = false;
        bool kaoqinbool = false;
        string qingjiashixiang = "";
        using (SqlDataReader dr_qingjia = SqlHelper.ExecuteReader(CommandType.Text, sql_qingjia))
        {



            if (dr_qingjia.Read())
            {

                qingjiashixiang = dr_qingjia.GetString(dr_qingjia.GetOrdinal("q_shixiang"));
                kaoqinbool = true;
            }
            else
                if (firsttime == "")
                {
                    string[] sArray = strendti.Split('-');
                    string nianfen = sArray[0] + "-" + sArray[1];

                    DateTime t = Convert.ToDateTime(strendti); ;
                    String sql_gongzuo = "SELECT * FROM [gongzuori] where YearMon='" + nianfen + "'";
                    SqlParameter[] sps_gongzuo = new SqlParameter[]
                                  {
                                    new SqlParameter("@number",ddr_banci.SelectedItem.Text),
                                    };
                    using (SqlDataReader dr_gongzuo = SqlHelper.ExecuteReader(CommandType.Text, sql_gongzuo, sps_gongzuo))
                    {
                        string getnianfen = "";

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
            SqlHelper.Close();
        }
        td9.Text = qingjiashixiang;
        tr.Cells.Add(td9);
        //状态
        TableCell td10 = new TableCell();
        if (!kaoqinbool)
        {
            if (firsttime != "")
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


                        }
                        else
                            if (nTSeconds > Intgetqueqin)
                            {
                                td10.Text = "旷工,";
                            }
                }
                else { td10.Text = "正常,"; }
                string getnowtime = DateTime.Now.ToString();
                DateTime getnowdate = Convert.ToDateTime(getnowtime);//当前时间
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

                            }
                            else
                                if (nTSecondsxiawu > Intgetqueqin)
                                {
                                    td10.Text += "旷工";
                                }

                    }
                    if (timelast1 > time8 && getnowdate > time8) { td10.Text += "正常"; }

                    if (DTcardgettime1 <= DTkaoqintime && timelast1 >= time8)
                    {

                        td10.Text = "正常,正常";

                    }
                }
                //if (nTSecondsxiawu + nTSeconds > Intgetqueqin)
                //{
                //    td10.Text = "旷工";
                //}
            }
            else
            {
                if (td9.Text == "休假")
                {
                    td10.Text = "";
                }
                else
                    td10.Text = "旷工";
            }
        }
        else
            td10.Text = "";

        tr.Cells.Add(td10);
        tb_result.Rows.Add(tr);



    }
    protected void afternoon_Click(object sender, EventArgs e)
    {
        if (Session["number"] == null)
        {
            Response.Write("<script>alert('登录时间过期，请重新登录');window.location='../login.aspx';</script>");
            return;
        }
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
                    string str_sql = "SELECT * FROM [cardinf] where c_id='" + Session["number"] + "'and c_addr='" + ddr_address.SelectedItem.Text + "'and c_time>'" + strendti + "' and c_time<'" + starttime + "' ORDER BY c_time";
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


    protected void cardall_Click(object sender, EventArgs e)
    {
        if (Session["number"] == null)
        {
            Response.Write("<script>alert('登录时间过期，请重新登录');window.location='../login.aspx';</script>");
            return;
        }
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
                ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('只能查询31天以内的记录，请重新选择')</script>");

            }
            else
            {
                TableHeaderRow thr = new TableHeaderRow();
                //构建表头
                string[] s_th = "员工号,姓名,刷卡时间,刷卡位置,进出状态".Split(',');
                foreach (string _s in s_th)
                {
                    TableHeaderCell thd = new TableHeaderCell();
                    thd.Text = _s;
                    thr.Cells.Add(thd);
                }
                String strendtimeend = time2.AddDays(1).ToString("yyyy-MM-dd");
                tb_result.Rows.Add(thr);
                string _result = "select * from [cardinf] where c_time>='" + startime.Text + "' and  c_time<='" + strendtimeend + "' and c_id='" + Session["number"] + "' ";
                DataTable ds_all3 = SqlHelper.ExecuteDataTable(_result);
                int i_all3 = ds_all3.Rows.Count;
                for (int j = 0; j < i_all3; j++)
                {
                    TableRow tr = new TableRow();
                    //员工号
                    string number = ds_all3.Rows[j]["c_id"].ToString();
                    TableCell td = new TableCell();
                    td.Text = number;
                    tr.Cells.Add(td);
                    //姓名
                    string name = ds_all3.Rows[j]["c_name"].ToString();
                    TableCell td_name = new TableCell();
                    td_name.Text = name;
                    tr.Cells.Add(td_name);
                    //刷卡时间
                    string gettime = ds_all3.Rows[j]["c_time"].ToString();
                    TableCell td_time = new TableCell();
                    td_time.Text = gettime;
                    tr.Cells.Add(td_time);
                    //刷卡位置
                    string addr = ds_all3.Rows[j]["c_addr"].ToString();
                    TableCell td_addr = new TableCell();
                    td_addr.Text = addr;
                    tr.Cells.Add(td_addr);
                    //进出状态
                    string jin = ds_all3.Rows[j]["c_status"].ToString();
                    TableCell td_jin = new TableCell();
                    td_jin.Text = jin;
                    tr.Cells.Add(td_jin);
                    tb_result.Rows.Add(tr);
                }
            }
        }
    }
}






