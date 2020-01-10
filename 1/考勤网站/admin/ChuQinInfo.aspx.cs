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

public partial class admin_ChuQinInfo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Calendar1.Visible = false;
      //  startime.Text = DateTime.Now.ToString("yyyy-MM-dd");


    }


    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        Calendar1.Visible = true;
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
    //下班考勤查询
    protected void moning_Click(object sender, EventArgs e)
    {
        //获取早上考勤时间，允许迟到时间，旷工时间
        string gettime1 = "", getminute1 = "", getkuanggong = "";

        String sql1 = "SELECT * FROM [Time] where banci=@banci";
        SqlParameter[] sps1 = new SqlParameter[]
                {
                    new SqlParameter("@banci",ddr_banci.SelectedItem.Text),
                };
        SqlDataReader dr = SqlHelper.ExecuteReader(CommandType.Text, sql1, sps1);

        if (dr.Read())
        {

            gettime1 = dr.GetString(dr.GetOrdinal("time1"));
            getminute1 = dr.GetString(dr.GetOrdinal("minute1"));
            getkuanggong = dr.GetString(dr.GetOrdinal("chidaozaotui"));
        }
        SqlHelper.Close();

        TableHeaderRow thr = new TableHeaderRow();
        //构建表头
        string[] s_th = "员工编号,姓名,刷卡位置,进出情况,刷卡时间,状态".Split(',');
        foreach (string _s in s_th)
        {
            TableHeaderCell thd = new TableHeaderCell();
            thd.Text = _s;
            thr.Cells.Add(thd);
        }

        tb_result.Rows.Add(thr);
        //读取员工的姓名、编号
       
        SqlParameter[] sps2 = new SqlParameter[]
                   {
                    new SqlParameter("@banci",ddr_banci.SelectedItem.Text),
                   };
        String sql2 = "SELECT * FROM [userinfo] where Banci=@banci";
        SqlDataReader dr2 = SqlHelper.ExecuteReader(CommandType.Text, sql2, sps2);
        String starttime = Calendar1.SelectedDate.ToString("yyyy-MM-dd");
        while (dr2.Read())
        {
            TableRow tr = new TableRow();
            string  resultsql = "", findnumber = "", findname = "";
            bool select = true;
            if (tb_number.Text != "" || tb_name.Text != "")
            {
                select = false;
                if (tb_name.Text != "")
                {
                    resultsql += " and c_name='" + tb_name.Text + "'";
                    findname += " and name='" + tb_name.Text + "'";

                }
                if (tb_number.Text != "")
                {
                    resultsql += " and c_id='" + tb_number.Text + "'";
                    findnumber += " and number='" + tb_number.Text + "'";
                }
                String sql4 = "SELECT * FROM [userinfo] where Banci=@banci" + findnumber + findname;//获取条件员工号和姓名
                SqlParameter[] sps4 = new SqlParameter[]
                            {
                                new SqlParameter("@banci",ddr_banci.SelectedItem.Text),
                            };
                SqlDataReader dr4 = SqlHelper.ExecuteReader(CommandType.Text, sql4, sps4);
                if (dr4.Read())
                {
                    //员工编号
                    TableCell td = new TableCell();
                    td.Text = dr4.GetString(dr4.GetOrdinal("number"));
                    tr.Cells.Add(td);
                    //姓名
                    TableCell td1 = new TableCell();
                    td1.Text = dr4.GetString(dr4.GetOrdinal("name"));
                    tr.Cells.Add(td1);

                }
                else 
                {
                    Response.Write("<script>alert('该员工不存在，请重新输入');window.location='../admin/ChuQinInfo.aspx';</script>");
                
                }

            }
            else
            {
                resultsql += " and c_id='" + dr2.GetString(dr2.GetOrdinal("number")) + "'";
                //员工编号
                TableCell td = new TableCell();
                td.Text = dr2.GetString(dr2.GetOrdinal("number"));
                tr.Cells.Add(td);
                //姓名
                TableCell td1 = new TableCell();
                td1.Text = dr2.GetString(dr2.GetOrdinal("name"));
                tr.Cells.Add(td1);

            }

            //刷卡时间
            string str_sql = "SELECT min(c_time)as c_time FROM [cardinf] where c_addr='" + ddr_address.SelectedItem.Text + "'and c_status='" + '进' + "' and c_time>'" + startime.Text + "' and c_time<'" + Calendar1.SelectedDate.AddDays(1).ToString("yyyy-MM-dd") + "'" + resultsql;
            SqlDataReader dr3 = SqlHelper.ExecuteReader(CommandType.Text, str_sql);

            int Intminute = int.Parse(getminute1) * 60;
            int Intgetkuanggong = int.Parse(getkuanggong) * 60;
            if (dr3.Read())
            {
                if (dr3["c_time"] != System.DBNull.Value)
                {
                    string cardgettime1 = dr3.GetString(dr3.GetOrdinal("c_time"));//获取最早一次刷卡时间
                    //刷卡位置
                    TableCell td2 = new TableCell();
                    td2.Text = ddr_address.SelectedItem.Text.ToString();
                    tr.Cells.Add(td2);
                    //进出情况
                    TableCell td3 = new TableCell();
                    td3.Text = "进";
                    tr.Cells.Add(td3);
                    //刷卡时间
                    TableCell td4 = new TableCell();
                    td4.Text = cardgettime1;
                    tr.Cells.Add(td4);
                    DateTime DTcardgettime1 = Convert.ToDateTime(cardgettime1);
                    string kaoqintime = starttime + " " + gettime1;//获取早上考勤时间
                    DateTime DTkaoqintime = Convert.ToDateTime(kaoqintime);
                    System.TimeSpan ND1 = DTcardgettime1 - DTkaoqintime;
                    int nTSeconds = (int)ND1.TotalSeconds;   //秒数差
                    if (DTcardgettime1 > DTkaoqintime)
                    {
                        if (nTSeconds <= Intminute)
                        {
                            TableCell td5 = new TableCell();
                            td5.Text = "按时上班";
                            tr.Cells.Add(td5);

                        }
                        else
                            if (nTSeconds > Intminute && nTSeconds <= Intgetkuanggong)
                            {
                                //状态
                                TableCell td5 = new TableCell();
                                td5.Text = "迟到";
                                tr.Cells.Add(td5);

                            }
                            else
                                if (nTSeconds > Intgetkuanggong)
                                {

                                    TableCell td5 = new TableCell();
                                    td5.Text = "旷工";
                                    tr.Cells.Add(td5);
                                }
                    }
                    else
                    {
                        TableCell td5 = new TableCell();
                        td5.Text = "按时上班";
                        tr.Cells.Add(td5);

                    }
                }

                else
                {
                    //刷卡位置
                    TableCell td2 = new TableCell();
                    td2.Text = "";
                    tr.Cells.Add(td2);
                    //进出情况
                    TableCell td3 = new TableCell();
                    td3.Text = "";
                    tr.Cells.Add(td3);
                    //刷卡时间
                    TableCell td4 = new TableCell();
                    td4.Text = "";
                    tr.Cells.Add(td4);
                    TableCell td5 = new TableCell();
                    td5.Text = "缺勤";
                    tr.Cells.Add(td5);

                }
                SqlHelper.Close();
                tb_result.Rows.Add(tr);
                if (select == false)
                {
                    break;
                }
                

            }

        }
    }

    //下班考勤记录查询
    protected void afternoon_Click(object sender, EventArgs e)
    {
        //获取下班规定时间，允许迟到时间，旷工时间
        string gettime1 = "", getminute1 = "", getkuanggong = "";

        String sql1 = "SELECT * FROM [Time] where banci=@banci";
        SqlParameter[] sps1 = new SqlParameter[]
                {
                    new SqlParameter("@banci",ddr_banci.SelectedItem.Text),
                };
        SqlDataReader dr = SqlHelper.ExecuteReader(CommandType.Text, sql1, sps1);

        if (dr.Read())
        {

            gettime1 = dr.GetString(dr.GetOrdinal("time4"));
            getminute1 = dr.GetString(dr.GetOrdinal("minute4"));
            getkuanggong = dr.GetString(dr.GetOrdinal("chidaozaotui"));
        }
        SqlHelper.Close();

        TableHeaderRow thr = new TableHeaderRow();
        //构建表头
        string[] s_th = "员工编号,姓名,刷卡位置,进出情况,刷卡时间,状态".Split(',');
        foreach (string _s in s_th)
        {
            TableHeaderCell thd = new TableHeaderCell();
            thd.Text = _s;
            thr.Cells.Add(thd);
        }

        tb_result.Rows.Add(thr);
        //读取员工的姓名、编号

        SqlParameter[] sps2 = new SqlParameter[]
                   {
                    new SqlParameter("@banci",ddr_banci.SelectedItem.Text),
                   };
        String sql2 = "SELECT * FROM [userinfo] where Banci=@banci";
        SqlDataReader dr2 = SqlHelper.ExecuteReader(CommandType.Text, sql2, sps2);
        String starttime = Calendar1.SelectedDate.ToString("yyyy-MM-dd");
        while (dr2.Read())
        {
            TableRow tr = new TableRow();
            string resultsql = "", findnumber = "", findname = "";
            bool select = true;
            if (tb_number.Text != "" || tb_name.Text != "")
            {
                select = false;
                if (tb_name.Text != "")
                {
                    resultsql += " and c_name='" + tb_name.Text + "'";
                    findname += " and name='" + tb_name.Text + "'";

                }
                if (tb_number.Text != "")
                {
                    resultsql += " and c_id='" + tb_number.Text + "'";
                    findnumber += " and number='" + tb_number.Text + "'";
                }
                String sql4 = "SELECT * FROM [userinfo] where Banci=@banci" + findnumber + findname;//获取条件员工号和姓名
                SqlParameter[] sps4 = new SqlParameter[]
                            {
                                new SqlParameter("@banci",ddr_banci.SelectedItem.Text),
                            };
                SqlDataReader dr4 = SqlHelper.ExecuteReader(CommandType.Text, sql4, sps4);
                if (dr4.Read())
                {
                    //员工编号
                    TableCell td = new TableCell();
                    td.Text = dr4.GetString(dr4.GetOrdinal("number"));
                    tr.Cells.Add(td);
                    //姓名
                    TableCell td1 = new TableCell();
                    td1.Text = dr4.GetString(dr4.GetOrdinal("name"));
                    tr.Cells.Add(td1);

                }
                else
                {
                    Response.Write("<script>alert('该员工不存在，请重新输入');window.location='../admin/ChuQinInfo.aspx';</script>");

                }

            }
            else
            {
                resultsql += " and c_id='" + dr2.GetString(dr2.GetOrdinal("number")) + "'";
                //员工编号
                TableCell td = new TableCell();
                td.Text = dr2.GetString(dr2.GetOrdinal("number"));
                tr.Cells.Add(td);
                //姓名
                TableCell td1 = new TableCell();
                td1.Text = dr2.GetString(dr2.GetOrdinal("name"));
                tr.Cells.Add(td1);

            }

            //刷卡时间
            string str_sql = "SELECT max(c_time)as c_time FROM [cardinf] where c_addr='" + ddr_address.SelectedItem.Text + "'and c_status='" + '出' + "' and c_time>'" + startime.Text + "' and c_time<'" + Calendar1.SelectedDate.AddDays(1).ToString("yyyy-MM-dd") + "'" + resultsql;
            SqlDataReader dr3 = SqlHelper.ExecuteReader(CommandType.Text, str_sql);

            int Intminute = int.Parse(getminute1) * 60;
            int Intgetkuanggong = int.Parse(getkuanggong) * 60;
            if (dr3.Read())
            {
                if (dr3["c_time"] != System.DBNull.Value)
                {
                    string cardgettime1 = dr3.GetString(dr3.GetOrdinal("c_time"));//获取最早一次刷卡时间
                    //刷卡位置
                    TableCell td2 = new TableCell();
                    td2.Text = ddr_address.SelectedItem.Text.ToString();
                    tr.Cells.Add(td2);
                    //进出情况
                    TableCell td3 = new TableCell();
                    td3.Text = "进";
                    tr.Cells.Add(td3);
                    //刷卡时间
                    TableCell td4 = new TableCell();
                    td4.Text = cardgettime1;
                    tr.Cells.Add(td4);
                    DateTime DTcardgettime1 = Convert.ToDateTime(cardgettime1);
                    string kaoqintime = starttime + " " + gettime1;//获取早上考勤时间
                    DateTime DTkaoqintime = Convert.ToDateTime(kaoqintime);
                    System.TimeSpan ND1 = DTkaoqintime - DTcardgettime1;
                    int nTSeconds = (int)ND1.TotalSeconds;   //秒数差
                    if (DTcardgettime1 < DTkaoqintime)
                    {
                        if (nTSeconds <= Intminute)
                        {
                            TableCell td5 = new TableCell();
                            td5.Text = "按时下班";
                            tr.Cells.Add(td5);

                        }
                        else
                            if (nTSeconds > Intminute && nTSeconds <= Intgetkuanggong)
                            {
                                //状态
                                TableCell td5 = new TableCell();
                                td5.Text = "早退";
                                tr.Cells.Add(td5);

                            }
                            else
                                if (nTSeconds > Intgetkuanggong)
                                {

                                    TableCell td5 = new TableCell();
                                    td5.Text = "旷工";
                                    tr.Cells.Add(td5);
                                }
                    }
                    else
                    {
                        TableCell td5 = new TableCell();
                        td5.Text = "按时下班";
                        tr.Cells.Add(td5);

                    }
                }

                else
                {
                    //刷卡位置
                    TableCell td2 = new TableCell();
                    td2.Text = "";
                    tr.Cells.Add(td2);
                    //进出情况
                    TableCell td3 = new TableCell();
                    td3.Text = "";
                    tr.Cells.Add(td3);
                    //刷卡时间
                    TableCell td4 = new TableCell();
                    td4.Text = "";
                    tr.Cells.Add(td4);
                    TableCell td5 = new TableCell();
                    td5.Text = "缺勤";
                    tr.Cells.Add(td5);

                }
                SqlHelper.Close();
                tb_result.Rows.Add(tr);
                if (select == false)
                {
                    break;
                }


            }

        }
    }
}