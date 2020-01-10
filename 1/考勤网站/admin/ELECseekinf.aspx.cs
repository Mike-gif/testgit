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

public partial class admin_ELECseekinf : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        GridViewDataBind();
        cardinf();
    }
    protected void Timer1_Tick(object sender, EventArgs e)
    {
        GridViewDataBind();
    }
    protected void Timer2_Tick(object sender, EventArgs e)
    {
        cardinf();
    }
    public void GridViewDataBind()
    {
        //名字循环赋值
        String sql_all = "SELECT * FROM [userinfo] where zaizhi='在职' ";
        DataTable ds_all = SqlHelper.ExecuteDataTable(sql_all);
        int i_all = ds_all.Rows.Count;
        int top = 0, last = 0;
        top = i_all / 2;
        if (top * 2 == i_all)
        {
            last = top;
        }
        else
            last = top + 1;
        string sql2 = "select top " + last.ToString() + " name,id from userinfo where zaizhi='在职' ORDER BY id desc";
        DataSet ds2 = SqlHelper.ExecuteDataSet(sql2);
        Session["Table"] = ds2.Tables[0];
        gvShow.DataSource = ds2;
        gvShow.DataBind();
        string sql3 = "select top " + top.ToString() + " name,id from  userinfo where zaizhi='在职' ORDER BY id ASC";
        DataTable ds_all3 = SqlHelper.ExecuteDataTable(sql3);
        int i_all3 = ds_all3.Rows.Count;
        int i = 0;
        foreach (GridViewRow row in gvShow.Rows)
        {
            if (i < i_all3)
            {
                row.Cells[3].Text = ds_all3.Rows[i]["name"].ToString();

            }
            if (i == i_all3 && last > top)
            {
                row.Cells[3].Text = " ";

            }
            i++;
        }
        //状态循环赋值
        //读取工作日
        string sql_allgongzuori = "select * from [gongzuori]";
        DataTable dt_allgongzuori = SqlHelper.ExecuteDataTable(sql_allgongzuori);
        //刷卡记录
        String caltime1 = DateTime.Now.ToString("yyyy-MM-dd");//获取当前系统时间
        string caltime2 = DateTime.Now.AddDays(1).ToString("yyyy-MM-dd");
        string sql_allkard = "select  * from [cardinf] where c_time>'" + caltime1 + "' and c_time<'" + caltime2 + "'";
        DataTable dt_akkkard = SqlHelper.ExecuteDataTable(sql_allkard);
        //读取请假
        string sql_allqingjia = "select * from [qingjia]";
        DataTable dt_allqingjia = SqlHelper.ExecuteDataTable(sql_allqingjia);
        //获取考勤参数
        string gettime1 = "", gettime2 = "", gettime3 = "", gettime4 = "", gettime5 = "", getcanbu = "", getchebu = "", getchidao = "", getzaotiu = "", getqueqin = "", getligang = "", getnianxiu = "", getshijia = "", getlinshijia = "", getbingjia = "", getkuanggong = "";//获取早上考勤时间，允许迟到时间，旷工时间,午休时间,下午下班时间,加班时间,迟到时间，早退时间，旷工时间
        String sql1 = "SELECT * FROM [KaoQinCanShu] where banci=@number";
        SqlParameter[] sps1 = new SqlParameter[]
                    {
                        new SqlParameter("@number","班次1"),
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
        //循环遍历第一组
        int i_color = 0;
        foreach (GridViewRow row in gvShow.Rows)
        {
            if (i_color % 2 == 0)
            {
                row.BackColor = System.Drawing.Color.LightGray;
            }
            i_color++;
            DataRow[] dr_allcard = dt_akkkard.Select(" c_name='" + row.Cells[0].Text + "'and c_status='进'", "c_time ASC");
            string firsttime = "", lastime = "";
            if (dr_allcard.Length > 0)
            {
                firsttime = dr_allcard[0]["c_time"].ToString();//获取第一次刷卡记录
            }
            //获取最后一次刷卡记录
            DataRow[] dr_allcard_chu = dt_akkkard.Select(" c_name='" + row.Cells[0].Text + "' and c_status='出'", "c_time desc");

            if (dr_allcard_chu.Length > 0)
            {
                lastime = dr_allcard_chu[0]["c_time"].ToString();//获取第一次刷卡记录
            }
            //
            string qingjiashixiang = "", qingjiashiyou = " ";
            bool kaoqinbool = false;
            DataRow[] dr_allwait = dt_allqingjia.Select("q_name='" + row.Cells[0].Text + "' and q_enddate>='" + caltime1 + " " + gettime1 + "' and q_startdate<='" + caltime2 + " " + gettime4 + "' and q_statue in('1','3')");
            if (dr_allwait.Length > 0)
            {
                qingjiashiyou = "<b style=\"color:red\">待审核</b>"; ;
                row.Cells[2].Text = qingjiashiyou;
            }
            DataRow[] dr_allqingjia = dt_allqingjia.Select("q_name='" + row.Cells[0].Text + "' and q_enddate>='" + caltime1 + " " + gettime1 + "' and q_startdate<='" + caltime2 + " " + gettime4 + "' and q_statue='4'");
            if (dr_allqingjia.Length > 0)
            {
                qingjiashixiang = dr_allqingjia[0]["q_shixiang"].ToString();
                qingjiashiyou = qingjiashixiang;
                kaoqinbool = true;
                row.Cells[2].Text = qingjiashiyou;
                if (qingjiashixiang == "因公外出" || qingjiashixiang == "异常申报")
                {
                    row.Cells[2].ForeColor = System.Drawing.Color.Green;
                }
                else
                {
                    row.Cells[2].ForeColor = System.Drawing.Color.Red;
                }
                //row.Cells[2].Text = qingjiashiyou;
                row.Cells[1].Text = " ";
            }
            else
                if (firsttime == "")
                {
                    string[] sArray = caltime1.Split('-');
                    string nianfen = sArray[0] + "-" + sArray[1];

                    DateTime t = Convert.ToDateTime(caltime1); ;
                    //SqlHelper.Close();
                    string getnianfen = "";
                    bool gongzuoritf = false;
                    DataRow[] dr_allgongzuori = dt_allgongzuori.Select("YearMon='" + nianfen + "'");
                    if (dr_allgongzuori.Length > 0)
                    {
                        getnianfen = dr_allgongzuori[0]["gongzuodate"].ToString();

                        getnianfen = getnianfen.Replace("\n", string.Empty).Replace("\r", string.Empty);


                        string[] str_getnianfen = getnianfen.Split(',');
                        foreach (string _s in str_getnianfen)
                        {
                            if (caltime1 == _s)
                            {
                                gongzuoritf = true;
                                break;

                            }
                        }

                        // SqlHelper.Close();
                    }
                    if (!gongzuoritf)
                    {
                        qingjiashiyou = "休假";
                        row.Cells[1].Text = " ";
                        row.Cells[2].ForeColor = System.Drawing.Color.Red;
                        row.Cells[2].Text = qingjiashiyou;
                    }


                }
            //第一次刷卡不为空的出勤情况
            string td10 = " ";
            DateTime time8 = Convert.ToDateTime(caltime1 + " " + gettime4);//下午下班时间

            string getnowtime = DateTime.Now.ToString();
            DateTime getnowdate = Convert.ToDateTime(getnowtime);//当前时间
            string kaoqintime = caltime1 + " " + gettime1;//获取早上考勤时间
            DateTime DTkaoqintime = Convert.ToDateTime(kaoqintime);
            if (firsttime != "")
            {

                int Intgetchidao = int.Parse(getchidao) * 60;//迟到时间范围
                int Intgetzaot = int.Parse(getzaotiu) * 60;//早退时间范围
                int Intgetqueqin = int.Parse(getqueqin) * 60;//缺勤时间范围，超过为旷工
                td10 = "";
                DateTime DTcardgettime1 = Convert.ToDateTime(firsttime);//获取第一次刷卡时间

                System.TimeSpan NDkaoqin = DTcardgettime1 - DTkaoqintime;//早上考勤
                int nTSeconds = (int)NDkaoqin.TotalSeconds;   //秒数差


                if (DTcardgettime1 > DTkaoqintime)//第一次刷卡时间大于早上考勤时间
                {
                    if (nTSeconds <= Intgetchidao)//迟到时间小于等于迟到考勤时间范围
                    {

                        td10 = "正常,";


                    }
                    else
                        if (nTSeconds >= Intgetchidao && nTSeconds <= Intgetqueqin && (qingjiashiyou == " " || qingjiashiyou == "<b style=\"color:red\">待审核</b>"))
                        {

                            td10 = "<b style=\"color:red\">迟到,</b>";


                        }
                        else
                            if (nTSeconds > Intgetqueqin && (qingjiashiyou == " " || qingjiashiyou == "<b style=\"color:red\">待审核</b>"))
                            {
                                td10 = "<b style=\"color:red\">旷工,</b>";

                            }
                }
                else
                {
                    td10 = "正常,";
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

                            td10 += "正常";
                        }
                        else
                            if (nTSecondsxiawu > Intgetzaot && nTSecondsxiawu <= Intgetqueqin && getnowdate > time8.AddHours(2))
                            {

                                td10 += "<b style=\"color:red\">早退</b>";



                            }
                            else
                                if (nTSecondsxiawu > Intgetqueqin && getnowdate > time8.AddHours(2))
                                {
                                    td10 += "<b style=\"color:red\">旷工</b>";

                                }

                    }
                    if (getnowdate > time8 && timelast1 > time8)
                    {
                        td10 += ",正常";
                    }
                    if (DTcardgettime1 <= DTkaoqintime.AddMinutes(int.Parse(getchidao)) && timelast1 >= time8)
                    {

                        td10 = "正常,正常";

                    }

                }
                else
                {
                    if (getnowdate > time8.AddHours(2))
                    {
                        td10 += "<b style=\"color:red\">旷工</b>";

                    }

                }

            }
            else
            {
                if (qingjiashixiang != "休假")
                {
                    if (getnowdate > DTkaoqintime.AddMinutes(int.Parse(getchidao)))
                    {
                        td10 = "<b style=\"color:red\">缺勤</b>";
                    }
                }

            }
            row.Cells[1].Text = td10;
            row.Cells[2].Text = qingjiashiyou;



        }
        //循环遍历第二组
        foreach (GridViewRow row in gvShow.Rows)
        {
            string getnametwo = "";
            getnametwo = row.Cells[3].Text;
            if (getnametwo == " ")
            {
                row.Cells[4].Text = " ";
                row.Cells[5].Text = " ";
                continue;
            }

            DataRow[] dr_allcard = dt_akkkard.Select(" c_name='" + row.Cells[3].Text + "' and c_status='进'", "c_time ASC");
            string firsttime = "", lastime = "";
            if (dr_allcard.Length > 0)
            {
                firsttime = dr_allcard[0]["c_time"].ToString();//获取第一次刷卡记录
            }
            //获取最后一次刷卡记录
            DataRow[] dr_allcard_chu = dt_akkkard.Select(" c_name='" + row.Cells[3].Text + "' and c_status='出'", "c_time desc");

            if (dr_allcard_chu.Length > 0)
            {
                lastime = dr_allcard_chu[0]["c_time"].ToString();//获取第一次刷卡记录
            }
            //
            string qingjiashixiang = " ", qingjiashiyou = " ";
            bool kaoqinbool = false;
            DataRow[] dr_allwait = dt_allqingjia.Select("q_name='" + row.Cells[3].Text + "' and q_enddate>='" + caltime1 + " " + gettime1 + "' and q_startdate<='" + caltime1 + " " + gettime4 + "' and q_statue in('1','3')");
            if (dr_allwait.Length > 0)
            {
                qingjiashiyou = "<b style=\"color:red\">待审核</b>";
                row.Cells[5].Text = qingjiashiyou;
            }
            DataRow[] dr_allqingjia = dt_allqingjia.Select("q_name='" + row.Cells[3].Text + "' and q_enddate>='" + caltime1 + " " + gettime1 + "' and q_startdate<='" + caltime2 + " " + gettime4 + "' and q_statue='4'");
            if (dr_allqingjia.Length > 0)
            {
                qingjiashixiang = dr_allqingjia[0]["q_shixiang"].ToString();
                qingjiashiyou = qingjiashixiang;
                kaoqinbool = true;
                //row.Cells[4].Text = qingjiashixiang;
                if (qingjiashiyou == "因公外出" || qingjiashiyou == "异常申报")
                {
                    row.Cells[5].ForeColor = System.Drawing.Color.Green;
                }
                else
                {
                    row.Cells[5].ForeColor = System.Drawing.Color.Red;
                }
                row.Cells[5].Text = qingjiashiyou;
                row.Cells[4].Text = " ";
            }

            else if (firsttime == "")
            {
                string[] sArray = caltime1.Split('-');
                string nianfen = sArray[0] + "-" + sArray[1];

                DateTime t = Convert.ToDateTime(caltime1); ;
                //SqlHelper.Close();
                string getnianfen = "";
                bool gongzuoritf = false;
                DataRow[] dr_allgongzuori = dt_allgongzuori.Select("YearMon='" + nianfen + "'");
                if (dr_allgongzuori.Length > 0)
                {
                    getnianfen = dr_allgongzuori[0]["gongzuodate"].ToString();

                    getnianfen = getnianfen.Replace("\n", string.Empty).Replace("\r", string.Empty);


                    string[] str_getnianfen = getnianfen.Split(',');
                    foreach (string _s in str_getnianfen)
                    {
                        if (caltime1 == _s)
                        {
                            gongzuoritf = true;
                            break;

                        }
                    }

                    // SqlHelper.Close();
                }
                if (!gongzuoritf)
                {
                    qingjiashiyou = "休假";
                    row.Cells[4].Text = " ";
                    row.Cells[5].Text = qingjiashiyou;
                    row.Cells[5].BackColor = System.Drawing.Color.Red; ;
                }

            }
            //第一次刷卡不为空的出勤情况

            DateTime time8 = Convert.ToDateTime(caltime1 + " " + gettime4);//下午下班时间

            string td10 = "";
            int Intgetzaot = int.Parse(getzaotiu) * 60;//早退时间范围
            string getnowtime = DateTime.Now.ToString();
            DateTime getnowdate = Convert.ToDateTime(getnowtime);//当前时间
            string kaoqintime = caltime1 + " " + gettime1;//获取早上考勤时间
            DateTime DTkaoqintime = Convert.ToDateTime(kaoqintime);
            int Intgetchidao = int.Parse(getchidao) * 60;//迟到时间范围
            if (firsttime != "")
            {



                int Intgetqueqin = int.Parse(getqueqin) * 60;//缺勤时间范围，超过为旷工
                td10 = "";
                DateTime DTcardgettime1 = Convert.ToDateTime(firsttime);//获取第一次刷卡时间

                System.TimeSpan NDkaoqin = DTcardgettime1 - DTkaoqintime;//早上考勤
                int nTSeconds = (int)NDkaoqin.TotalSeconds;   //秒数差


                if (DTcardgettime1 > DTkaoqintime)//第一次刷卡时间大于早上考勤时间
                {
                    if (nTSeconds <= Intgetchidao)//迟到时间小于等于迟到考勤时间范围
                    {

                        td10 = "正常,";


                    }
                    else
                        if (nTSeconds >= Intgetchidao && nTSeconds <= Intgetqueqin && (qingjiashiyou == " " || qingjiashiyou == "<b style=\"color:red\">待审核</b>"))
                        {

                            td10 = "<b style=\"color:red\">迟到,</b>";


                        }
                        else
                            if (nTSeconds > Intgetqueqin && (qingjiashiyou == " " || qingjiashiyou == "<b style=\"color:red\">待审核</b>"))
                            {
                                td10 = "<b style=\"color:red\">旷工,</b>";

                            }
                }
                else
                {
                    td10 = "正常,";
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

                            td10 += "正常";
                        }
                        else
                            if (nTSecondsxiawu > Intgetzaot && nTSecondsxiawu <= Intgetqueqin && getnowdate > time8.AddHours(2))
                            {

                                td10 += "<b style=\"color:red\">早退</b>";



                            }
                            else
                                if (nTSecondsxiawu > Intgetqueqin && getnowdate > time8.AddHours(2))
                                {

                                    td10 += "<b style=\"color:red\">旷工</b>";

                                }

                    }
                    if (getnowdate >= time8 && timelast1 >= time8)
                    {
                        td10 += ",正常";
                    }
                    if (DTcardgettime1 <= DTkaoqintime && timelast1 >= time8)
                    {

                        td10 = "正常,正常";

                    }

                }
                else
                {
                    if (getnowdate > time8.AddHours(2))////当前时间>下午下班时间
                    {
                        td10 += "<b style=\"color:red\">旷工</b>";

                    }

                }

            }
            else
            {
                if (qingjiashixiang != "休假")
                {
                    if (getnowdate > DTkaoqintime.AddMinutes(int.Parse(getchidao)))
                    {
                        td10 = "<b style=\"color:red\">缺勤</b>";
                    }
                }

            }
            row.Cells[4].Text = td10;
            row.Cells[5].Text = qingjiashiyou;



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

    public void cardinf()
    {
        String caltime1 = DateTime.Now.ToString("yyyy-MM-dd");//获取当前系统时间
        string sql2 = "select top 3  c_name,c_time,ID from cardinf where c_status='出' and c_time>'"+caltime1+"' ORDER BY c_time desc";
        DataSet ds2 = SqlHelper.ExecuteDataSet(sql2);
        Session["Table"] = ds2.Tables[0];
        GridView1.DataSource = ds2;
        GridView1.DataBind();
        int i = 0;
        string sql_cardinf = "select top 3  c_name,c_time,ID from cardinf where c_status='进' and c_time>'" + caltime1 + "' ORDER BY c_time desc";
        DataTable dt_allgongzuori = SqlHelper.ExecuteDataTable(sql_cardinf);
        int i_all = dt_allgongzuori.Rows.Count;
        foreach (GridViewRow row in GridView1.Rows)
        {
            if (i % 2 != 0)
            {
                row.BackColor = System.Drawing.Color.LightGray;
            }
            if (i == 0)
            {
                row.Cells[0].Text="最后一次刷卡";
            }
            if (i == 1)
            {
                row.Cells[0].Text = "倒数第二次刷卡";
            }
            if (i == 2)
            {
                row.Cells[0].Text = "倒数第三次刷卡";
            }
            if (i < i_all)
            {
                row.Cells[3].Text = dt_allgongzuori.Rows[i]["c_name"].ToString();
                row.Cells[4].Text = dt_allgongzuori.Rows[i]["c_time"].ToString();
            
            }
            i++;
        }


    }

    protected void gvShow_PageIndexChanging1(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        cardinf();
    }








}