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

public partial class admin_SeekChuQin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        PopupWin1.Visible = false;
        if (!Page.IsPostBack)
        {
            String sql1 = "select * from [qingjia] where q_statue='1' ORDER BY q_enddate DESC";
            DataTable dt_allgongzuori = SqlHelper.ExecuteDataTable(sql1);
            int i_all = dt_allgongzuori.Rows.Count;

            if (i_all > 0)
            {
                PopupWin1.Visible = true;
                this.PopupWin1.Message = "你有员工申请申报消息需要处理";
                this.PopupWin1.Font.Size = FontUnit.Point(42);
              
            }
            else
            {
                PopupWin1.Visible = false;
            }
            Calendar1.Visible = false;
            Calendar2.Visible = false;
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
    public void seeknowkaoqin()
    {
        TableHeaderRow thr = new TableHeaderRow();
        //构建表头
        string[] s_th = "员工编号,员工姓名,第一次刷卡(到岗)时间,最后一次刷卡(离岗)时间,累计在岗(小时),累计上岗时间(小时),累计离岗时间(小时),累计加班时间(小时),餐补,车补,缺勤,状态(早、晚),考勤分(扣分)".Split(',');
        foreach (string _s in s_th)
        {
            TableHeaderCell thd = new TableHeaderCell();
            thd.Text = _s;
            thr.Cells.Add(thd);
        }

        tb_result.Rows.Add(thr);

        string gettime1 = "", gettime2 = "", gettime3 = "", gettime4 = "", gettime5 = "", getcanbu = "", getchebu = "", getchidao = "", getzaotiu = "", getqueqin = "", getligang = "", getnianxiu = "", getshijia = "", getlinshijia = "", getbingjia = "", getkuanggong = "";//获取早上考勤时间，允许迟到时间，旷工时间,午休时间,下午下班时间,加班时间,迟到时间，早退时间，旷工时间
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
                getligang = dr.GetString(dr.GetOrdinal("ligang"));
                getnianxiu = dr.GetString(dr.GetOrdinal("nianxiu"));
                getshijia = dr.GetString(dr.GetOrdinal("shijia"));
                getlinshijia = dr.GetString(dr.GetOrdinal("linshijia"));
                getbingjia = dr.GetString(dr.GetOrdinal("bingjia"));
                getkuanggong = dr.GetString(dr.GetOrdinal("kuanggong"));

            }
            SqlHelper.Close();
        }
        //循环处理数据
        //读取请假
        string sql_allqingjia = "select * from [qingjia]";
        DataTable dt_allqingjia = SqlHelper.ExecuteDataTable(sql_allqingjia);
        //读取工作日
        string sql_allgongzuori = "select * from [gongzuori]";
        DataTable dt_allgongzuori = SqlHelper.ExecuteDataTable(sql_allgongzuori);
        //读取所有的刷卡数据
        String caltime1 = DateTime.Now.ToString("yyyy-MM-dd");//获取当前系统时间
        string caltime2 = DateTime.Now.AddDays(1).ToString("yyyy-MM-dd");
        string sql_allkard = "select * from [cardinf] where c_time>'" + caltime1 + "' and c_time<'" + caltime2 + "'";
        DataTable dt_akkkard = SqlHelper.ExecuteDataTable(sql_allkard);
        String sql_all = "SELECT * FROM [userinfo] where zaizhi='在职'";

        // SqlDataReader dr_all = SqlHelper.ExecuteReader(CommandType.Text, sql_all);
        string all_number = "", all_name = "";
        DataTable ds_all = SqlHelper.ExecuteDataTable(sql_all);
        int i_all = ds_all.Rows.Count;

        for (int j_all = 0; j_all < i_all; j_all++)
        {

            all_number = ds_all.Rows[j_all]["number"].ToString();
            all_name = ds_all.Rows[j_all]["name"].ToString();



            TableRow tr = new TableRow();

            //员工编号
            TableCell td = new TableCell();
            td.Text = all_number;
            tr.Cells.Add(td);
            //姓名
            TableCell td1 = new TableCell();
            td1.Text = all_name;
            tr.Cells.Add(td1);
            string strendti = DateTime.Now.ToString("yyyy-MM-dd");//获取当前系统时间
            string endtime = DateTime.Now.AddDays(1).ToString("yyyy-MM-dd");

            string firsttime = "", lastime = "", Tjin = "", Tchu = "";
            bool firstcardtime = true;
            double T1 = 0, T2 = 0;
            DataRow[] dr_allcard = dt_akkkard.Select(" c_id='" + all_number + "' and c_time>'" + strendti + "' and c_time<'" + endtime + "'", "c_time ASC");
            int i = 0;
            if (dr_allcard.Length > 0)
            {
                string Name11 = dr_allcard[0]["c_time"].ToString();
                i = dr_allcard.Length;
            }

            for (int j = 0; j < i; j++)//进出时间累加计算，获得上岗和离岗的时间总和
            {


                if (dr_allcard[j]["c_status"].ToString() == "进")
                {
                    if (firstcardtime)
                    {
                        firsttime = dr_allcard[j]["c_time"].ToString();

                        firstcardtime = false;
                    }
                    if (j + 1 < i)
                    {
                        if (dr_allcard[j + 1]["c_status"].ToString() == "进")
                        {
                            continue;
                        }
                        else
                        {
                            Tjin = dr_allcard[j]["c_time"].ToString();
                        }
                    }
                    else
                    {
                        Tjin = dr_allcard[j]["c_time"].ToString();

                    }

                }
                else
                    if (dr_allcard[j]["c_status"].ToString() == "出")
                    {
                        if (j + 1 < i)
                        {
                            if (dr_allcard[j + 1]["c_status"].ToString() == "出")
                            {
                                continue;
                            }
                            else
                            {
                                Tchu = dr_allcard[j]["c_time"].ToString();
                            }
                        }
                        else
                        {
                            Tchu = dr_allcard[j]["c_time"].ToString();
                        }
                        lastime = dr_allcard[j]["c_time"].ToString();
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
                DataRow[] dr_allcanbu = ds_all.Select("number='" + all_number + "'");
                if (dr_allcanbu.Length > 0)
                {
                    chebu = dr_allcanbu[0]["canbu"].ToString();
                    chebu = dr_allcanbu[0]["chebu"].ToString();

                }

                //SqlHelper.Close();

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
            //判断是否是工作日
            bool gongzuoritf = false;
            string[] sArray = strendti.Split('-');
            string nianfen = sArray[0] + "-" + sArray[1];

            DateTime t = Convert.ToDateTime(strendti); ;
            //SqlHelper.Close();
            string getnianfen = "";

            DataRow[] dr_allgongzuori = dt_allgongzuori.Select("YearMon='" + nianfen + "'");
            if (dr_allgongzuori.Length > 0)
            {
                getnianfen = dr_allgongzuori[0]["gongzuodate"].ToString();

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

                // SqlHelper.Close();
            }
            //获取请假记录
            string Fen1 = "", Fen2 = "";//请假打分、出勤打分（迟到、早退、旷工）
            
            string qingjiashixiang = "";
            bool kaoqinbool = false;
            DataRow[] dr_allqingjia = dt_allqingjia.Select("q_number='" + all_number + "' and q_enddate>='" + strendti + " " + gettime1 + "' and q_startdate<='" + strendti + " " + gettime4 + "' and q_statue='4'");
            if (dr_allqingjia.Length > 0)
            {
                qingjiashixiang = dr_allqingjia[0]["q_shixiang"].ToString();
                string strtianall = dr_allqingjia[0]["q_all"].ToString();
                double doutianall=0;
                if (strtianall != "")
                {
                     doutianall = double.Parse(strtianall);
                }
                if (doutianall > 1)
                {
                    doutianall = 1;
                
                }
                kaoqinbool = true;
                double doufen = 0;
                if (qingjiashixiang == "事假")
                {
                     doufen = double.Parse(getshijia) * doutianall;
                   
                }
                if (qingjiashixiang == "临时假")
                {
                    doufen = double.Parse(getlinshijia) * doutianall;
                   // Fen1 = getlinshijia;
                }
                if (qingjiashixiang == "年假")
                {
                    doufen = double.Parse(getnianxiu) * doutianall;
                   // Fen1 = getnianxiu;
                }
                if (qingjiashixiang == "病假")
                {
                    doufen = double.Parse(getbingjia) * doutianall;
                    //Fen1 = getbingjia;
                }
                // SqlHelper.Close();
                Fen1 = doufen.ToString("f1");
            }
            else
                if (firsttime == "")
                {
                   
                    if (!gongzuoritf)
                    {
                        qingjiashixiang = "休假";

                    }
                    else
                    {
                        qingjiashixiang = "旷工";
                    }

                }
            //SqlHelper.Close();
            td9.Text = qingjiashixiang;
            tr.Cells.Add(td9);
            //状态
            TableCell td10 = new TableCell();
            if (!kaoqinbool && gongzuoritf)
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
                    if (td9.Text == "休假")
                    {
                        td10.Text = "";
                    }
                    else
                    {
                        td10.Text = "缺勤";
                        Fen2 = getkuanggong;
                    }
                }
            }
            else
                td10.Text = "";

            tr.Cells.Add(td10);
            //考勤分
            TableCell td11 = new TableCell();
            double intfen1 = 0, intfen2 = 0;
            if (Fen1 != "" && gongzuoritf)
            {
                intfen1 = double.Parse(Fen1);
            }
            if (Fen2 != "" && gongzuoritf)
            {
                intfen2 = double.Parse(Fen2);
            }
            double zongfen = intfen1 + intfen2;
            td11.Text = zongfen.ToString("f1");
            tr.Cells.Add(td11);
            tb_result.Rows.Add(tr);
        }
        SqlHelper.Close();
    }
    protected void moning_Click(object sender, EventArgs e) 
    { 
        seeknowkaoqin(); 
    }



    protected void afternoon_Click(object sender, EventArgs e)
    {
        chuqin();

    }
    public void chuqin()
    {
        if (startime.Text == "" || endtime.Text == "")
        {
            ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('请选择起止时间')</script>");
            return;

        }
        DateTime time1_st = Convert.ToDateTime(startime.Text);
        DateTime time2_en = Convert.ToDateTime(endtime.Text);
        System.TimeSpan ND_start = time2_en - time1_st;
        int n = ND_start.Days;   //天数差
        if (time1_st > time2_en)
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
        TableHeaderRow thr = new TableHeaderRow();
        //构建表头
        string[] s_th = "员工编号,员工姓名,累计在岗(小时),累计上岗时间(小时),累计离岗时间(小时),累计加班时间(小时),餐补,车补,累计在岗(天数),累计休假(天数),旷工次数,迟到次数,早退次数,考勤分(扣分)".Split(',');
        foreach (string _s in s_th)
        {
            TableHeaderCell thd = new TableHeaderCell();
            thd.Text = _s;
            thr.Cells.Add(thd);
        }

        tb_result.Rows.Add(thr);

        string gettime1 = "", gettime2 = "", gettime3 = "", gettime4 = "", gettime5 = "", getcanbu = "", getchebu = "", getchidao = "", getzaotiu = "", getqueqin = "", getligang = "", getnianxiu = "", getshijia = "", getlinshijia = "", getbingjia = "", getkuanggong = "";//获取早上考勤时间，允许迟到时间，旷工时间,午休时间,下午下班时间,加班时间,迟到时间，早退时间，旷工时间
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


        //循环处理数据
        //读取请假
        string sql_allqingjia = "select * from [qingjia]";
        DataTable dt_allqingjia = SqlHelper.ExecuteDataTable(sql_allqingjia);
        //读取工作日
        string sql_allgongzuori = "select * from [gongzuori]";
        DataTable dt_allgongzuori = SqlHelper.ExecuteDataTable(sql_allgongzuori);
        //读取所有的刷卡数据
        String caltime1 = time1_st.ToString("yyyy-MM-dd");
        string caltime2 = time2_en.AddDays(1).ToString("yyyy-MM-dd");
        string sql_allkard = "select * from [cardinf] where c_time>'" + caltime1 + "' and c_time<'" + caltime2 + "'";
        DataTable dt_akkkard = SqlHelper.ExecuteDataTable(sql_allkard);
        //读取员工信息
        String sql_all = "SELECT * FROM [userinfo] where zaizhi='在职' ";
        DataTable ds_all = SqlHelper.ExecuteDataTable(sql_all);
        int i_all = ds_all.Rows.Count;

        for (int j_all = 0; j_all < i_all; j_all++)
        {

            string all_number = "", all_name = "";

            all_number = ds_all.Rows[j_all]["number"].ToString();
            all_name = ds_all.Rows[j_all]["name"].ToString();
            TableRow trZ = new TableRow();
            TableCell tdZ1 = new TableCell();
            tdZ1.Text = all_number;
            trZ.Cells.Add(tdZ1);
            TableCell tdZ2 = new TableCell();
            tdZ2.Text = all_name;
            trZ.Cells.Add(tdZ2);
           // int i_date = 0;
            double TADD1 = 0, TADD2 = 0, TADD3 = 0, TADD4 = 0;
            int FADD = 0;
            double CANADD = 0, CHEADD = 0;
            int queqinADD = 0, chidaoADD = 0, zaotuiADD = 0, kuanggongADD = 0, shanggangADD = 0, xiujiaADD = 0;

            for (int i_date = 0; i_date <= n; i_date++)//日期循环
            {
                String strendti = time1_st.AddDays(i_date).ToString("yyyy-MM-dd");
                string starttime = time1_st.AddDays(1 + i_date).ToString("yyyy-MM-dd");
                ////string str_sql = "SELECT * FROM [cardinf] where c_id='" + all_number + "'and c_addr='" + ddr_address.SelectedItem.Text + "' and c_time>'" + strendti + "' and c_time<'" + starttime + "' ORDER BY c_time";
                ////DataSet ds2 = SqlHelper.ExecuteDataSet(str_sql);
                ////int i11 = SqlHelper.ExecuteDataTable(str_sql)
                ////int i= ds2.Tables[0].Rows.Count;
                string firsttime = "", lastime = "", Tjin = "", Tchu = "";
                bool firstcardtime = true;
                double T1 = 0, T2 = 0;


                DataRow[] dr_allcard = dt_akkkard.Select("c_id='" + all_number + "'and c_addr='" + ddr_address.SelectedItem.Text + "' and c_time>'" + strendti + "' and c_time<'" + starttime + "'", "c_time ASC");
                int i = 0;
                if (dr_allcard.Length > 0)
                {
                    string Name11 = dr_allcard[0]["c_time"].ToString();
                    i = dr_allcard.Length;
                }

                for (int j = 0; j < i; j++)//进出时间累加计算，获得上岗和离岗的时间总和
                {

                    if (dr_allcard[j]["c_status"].ToString() == "进")
                    {
                        if (firstcardtime)
                        {
                            firsttime = dr_allcard[j]["c_time"].ToString();

                            firstcardtime = false;
                        }
                        if (j + 1 < i)
                        {
                            if (dr_allcard[j + 1]["c_status"].ToString() == "进")
                            {
                                continue;
                            }
                            else
                            {

                                Tjin = dr_allcard[j]["c_time"].ToString();
                            }
                        }
                        else
                        {
                            Tjin = dr_allcard[j]["c_time"].ToString();

                        }

                    }
                    else
                        if (dr_allcard[j]["c_status"].ToString() == "出")
                        {
                            if (j + 1 < i)
                            {
                                if (dr_allcard[j + 1]["c_status"].ToString() == "出")
                                {
                                    continue;
                                }
                                else
                                {
                                    Tchu = dr_allcard[j]["c_time"].ToString();
                                }
                            }
                            else
                            {
                                Tchu = dr_allcard[j]["c_time"].ToString();
                            }
                            lastime = dr_allcard[j]["c_time"].ToString();
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

                //累计在岗
                double T3 = 0;
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

                TADD1 += double.Parse(T3.ToString("f2"));//累加
                //累计上岗时间
                if (T1 < 0)
                {
                    T1 = 0;
                }

                TADD2 += double.Parse(T1.ToString("f2"));//累计
                //累计离岗
                if (T2 < 0)
                {
                    T2 = 0;
                }
                TADD3 += double.Parse(T2.ToString("f2"));//累加


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
                    //获取餐补
                    DataRow[] dr_allcanbu = ds_all.Select("number='" + all_number + "'");
                    if (dr_allcanbu.Length > 0)
                    {
                        canbu = dr_allcanbu[0]["canbu"].ToString();
                        chebu = dr_allcanbu[0]["chebu"].ToString();

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
                TADD4 += double.Parse(T4.ToString("f2"));//累加
                //餐补
                if (canbu != "")
                {
                    CANADD += double.Parse(canbu);
                }
                //车补

                if (chebu != "")
                {
                    CHEADD += double.Parse(chebu);
                }
                //缺勤
                //判断是否是工作日
                bool gongzuoritf = false;
                string[] sArray = strendti.Split('-');
                string nianfen = sArray[0] + "-" + sArray[1];

                DateTime t = Convert.ToDateTime(strendti); ;
                //SqlHelper.Close();
                string getnianfen = "";

                DataRow[] dr_allgongzuori = dt_allgongzuori.Select("YearMon='" + nianfen + "'");
                if (dr_allgongzuori.Length > 0)
                {

                    getnianfen = dr_allgongzuori[0]["gongzuodate"].ToString();


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
                }
                //获取请假记录
                string Fen1 = "", Fen2 = "";//请假打分、出勤打分（迟到、早退、旷工）
                string qingjiashixiang = "";
                int getkuanggongci = 0;
                bool kaoqinbool = false;
                string getnowtimer = DateTime.Now.ToString("yyyy-MM-dd");
                DateTime timenowtime2 = Convert.ToDateTime(getnowtimer);
                DateTime strendtime2 = Convert.ToDateTime(strendti);
                DataRow[] dr_allqingjia = dt_allqingjia.Select("q_number='" + all_number + "' and q_enddate>='" + strendti + " " + gettime1 + "' and q_startdate<='" + strendti + " " + gettime4 + "' and q_statue='4'");
                if (dr_allqingjia.Length > 0)
                {
                    qingjiashixiang = dr_allqingjia[0]["q_shixiang"].ToString();
                    //qingjiashixiang = dr_qingjia.GetString(dr_qingjia.GetOrdinal("q_shixiang"));
                    kaoqinbool = true;
                    if (qingjiashixiang == "事假")
                    {
                        //Fen1 = getshijia;
                        xiujiaADD += 1;
                    }
                    if (qingjiashixiang == "临时假")
                    {
                        //Fen1 = getlinshijia;
                        xiujiaADD += 1;
                    }
                    if (qingjiashixiang == "年假")
                    {
                       // Fen1 = getnianxiu;
                        xiujiaADD += 1;
                    }
                    if (qingjiashixiang == "病假")
                    {
                       // Fen1 = getbingjia;
                        xiujiaADD += 1;
                    }
                }
                else
                    if (firsttime == "")
                    {
                        if (timenowtime2 >= strendtime2)
                        {
                           



                            if (!gongzuoritf)
                            {
                                qingjiashixiang = "休假";
                                xiujiaADD += 1;

                            }
                            else
                            {
                                qingjiashixiang = "旷工";
                                getkuanggongci = 1;
                                Fen2 = getkuanggong;

                            }

                        }
                    }

                //SqlHelper.Close();

                //状态

                if (!kaoqinbool && gongzuoritf)
                {
                    if (firsttime != "" )
                    {

                        int Intgetchidao = int.Parse(getchidao) * 60;//迟到时间范围
                        int Intgetzaot = int.Parse(getzaotiu) * 60;//早退时间范围
                        int Intgetqueqin = int.Parse(getqueqin) * 60;//缺勤时间范围，超过为旷工

                        DateTime DTcardgettime1 = Convert.ToDateTime(firsttime);//获取第一次刷卡时间
                        string kaoqintime = strendti + " " + gettime1;//获取早上考勤时间
                        DateTime DTkaoqintime = Convert.ToDateTime(kaoqintime);
                        System.TimeSpan NDkaoqin = DTcardgettime1 - DTkaoqintime;//早上考勤
                        int nTSeconds = (int)NDkaoqin.TotalSeconds;   //秒数差


                        if (DTcardgettime1 > DTkaoqintime)//第一次刷卡时间大于早上考勤时间
                        {

                            if (nTSeconds >= Intgetchidao && nTSeconds <= Intgetqueqin)
                            {
                                Fen2 = getligang;
                                chidaoADD += 1;

                            }
                            else
                                if (nTSeconds > Intgetqueqin)
                                {

                                    Fen2 = getkuanggong;
                                    getkuanggongci = 1;
                                }
                        }

                        string getnowtime = DateTime.Now.ToString();
                        DateTime getnowdate = Convert.ToDateTime(getnowtime);//当前时间
                        if (lastime != "")
                        {
                            DateTime timelast1 = Convert.ToDateTime(lastime);//最后一次刷卡时间
                            System.TimeSpan NDkaoqinxiawu = time8 - timelast1;//下午考勤
                            int nTSecondsxiawu = (int)NDkaoqinxiawu.TotalSeconds;   //秒数差

                            if (timelast1 < time8 && getnowdate > time8)//最后一次刷卡时间小于下午下班时间
                            {

                                if (nTSecondsxiawu > Intgetzaot && nTSecondsxiawu <= Intgetqueqin)
                                {
                                    zaotuiADD += 1;

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
                                        getkuanggongci = 1;
                                        Fen2 = getkuanggong;
                                    }

                            }

                            if (getnowdate > time8)
                            {
                                if (nTSecondsxiawu + nTSeconds > Intgetqueqin)
                                {
                                    Fen2 = getkuanggong;
                                    getkuanggongci = 1;
                                }
                            }
                        }
                        else
                        {
                            if (getnowdate > time8)
                            {

                                Fen2 = getkuanggong;
                                getkuanggongci = 1;
                            }

                        }

                    }

                }

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

                //累计上岗（天数）
                if (firsttime != "")
                {
                    shanggangADD += 1;
                }
                //累计旷工次数
                kuanggongADD += getkuanggongci;
            }
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
            //累计上岗（天数）
            tdZ9.Text = shanggangADD.ToString();
            trZ.Cells.Add(tdZ9);
            //累计休假（天数）
            TableCell tdZ10 = new TableCell();
            tdZ10.Text = xiujiaADD.ToString();
            trZ.Cells.Add(tdZ10);
            //旷工数
            TableCell tdZ11 = new TableCell();
            tdZ11.Text = kuanggongADD.ToString();
            trZ.Cells.Add(tdZ11);
            //累计迟到
            TableCell tdZ12 = new TableCell();
            tdZ12.Text = chidaoADD.ToString();
            trZ.Cells.Add(tdZ12);
            //累计早退
            TableCell tdZ13 = new TableCell();
            tdZ13.Text = zaotuiADD.ToString();
            trZ.Cells.Add(tdZ13);
            //累计扣分
            TableCell tdZ14 = new TableCell();
            tdZ14.Text = FADD.ToString();
            trZ.Cells.Add(tdZ14);
            tb_result.Rows.Add(trZ);

        }
    
    }
    protected void btn_excel_Click(object sender, EventArgs e)
    {
        //
        chuqin();
        if (tb_result.Rows.Count > 1)
        {
           
            //Response.End();
           
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