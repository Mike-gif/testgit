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

public partial class admin_CanShuSet : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            String sql1 = "select * from [qingjia] where q_statue='1' ORDER BY q_enddate DESC";
            DataTable dt_allgongzuori = SqlHelper.ExecuteDataTable(sql1);
            int i_all = dt_allgongzuori.Rows.Count;

            if (i_all > 0)
            {
                this.PopupWin1.Message = "你有员工申请申报消息需要处理";
                this.PopupWin1.Font.Size = FontUnit.Point(42);
            }
            else
            {
                PopupWin1.Visible = false;
            }
           
            checkbanci1();
            checkbanci2();
            checkbanci3();

        }
    }
    public void checkbanci1()
    {

        String sql1 = "SELECT * FROM [KaoQinCanShu] where banci='班次1'";
        SqlDataReader dr = SqlHelper.ExecuteReader(CommandType.Text, sql1);
        string str1 = "", str2 = "", str3 = "", str4 = "", str5 = "", str6 = "", str7 = "", str8 = "";
        if (dr.Read())
        {

            if (dr["time1"] != System.DBNull.Value)
             {
                 str1 = dr.GetString(dr.GetOrdinal("time1"));
                 string[] sArray = str1.Split(':');
                 time11_d1.SelectedItem.Text = sArray[0];
                 time11_d2.SelectedItem.Text = sArray[1];

             }

            if (dr["time2"] != System.DBNull.Value)
             {
                 str2 = dr.GetString(dr.GetOrdinal("time2"));
                 string[] sArray = str2.Split(':');
                 time21_d1.SelectedItem.Text = sArray[0];
                 time21_d2.SelectedItem.Text = sArray[1];

             }

            if (dr["time3"] != System.DBNull.Value)
             {
                 str3 = dr.GetString(dr.GetOrdinal("time3"));
                 string[] sArray = str3.Split(':');
                 time31_d1.SelectedItem.Text = sArray[0];
                 time31_d2.SelectedItem.Text = sArray[1];

             }

            if (dr["time4"] != System.DBNull.Value)
             {
                 str4 = dr.GetString(dr.GetOrdinal("time4"));
                 string[] sArray = str4.Split(':');
                 time41_d1.SelectedItem.Text = sArray[0];
                 time41_d2.SelectedItem.Text = sArray[1];

             }

            if (dr["time5"] != System.DBNull.Value)
             {
                 str5 = dr.GetString(dr.GetOrdinal("time5"));
                 string[] sArray = str5.Split(':');
                 time51_d1.SelectedItem.Text = sArray[0];
                 time51_d2.SelectedItem.Text = sArray[1];

             }

            if (dr["time6"] != System.DBNull.Value)
             {
                 str6 = dr.GetString(dr.GetOrdinal("time6"));
                 string[] sArray = str6.Split(':');
                 time61_d1.SelectedItem.Text = sArray[0];
                 time61_d2.SelectedItem.Text = sArray[1];

             }

            if (dr["canbu"] != System.DBNull.Value)
             {
                 str7 = dr.GetString(dr.GetOrdinal("canbu"));
                 string[] sArray = str7.Split(':');
                 time71_d1.SelectedItem.Text = sArray[0];
                 time71_d2.SelectedItem.Text = sArray[1];

             }

            if (dr["chebu"] != System.DBNull.Value)
             {
                 str8 = dr.GetString(dr.GetOrdinal("chebu"));
                 string[] sArray = str8.Split(':');
                 time81_d1.SelectedItem.Text = sArray[0];
                 time81_d2.SelectedItem.Text = sArray[1];

             }
            if (dr["xianshi1"] != System.DBNull.Value)
            {
                xianshi11.Text = dr.GetString(dr.GetOrdinal("xianshi1"));
            
            }
            if (dr["xianshi2"] != System.DBNull.Value)
            {
                xianshi21.Text = dr.GetString(dr.GetOrdinal("xianshi2"));

            }
            if (dr["chidao"] != System.DBNull.Value)
            {
                chidao1.Text = dr.GetString(dr.GetOrdinal("chidao"));

            }
            if (dr["zaotiu"] != System.DBNull.Value)
            {
                zaotiu1.Text = dr.GetString(dr.GetOrdinal("zaotiu"));

            }
            if (dr["queqin"] != System.DBNull.Value)
            {
                queqin1.Text = dr.GetString(dr.GetOrdinal("queqin"));

            }
            if (dr["ligang"] != System.DBNull.Value)
            {
                ligang1.Text = dr.GetString(dr.GetOrdinal("ligang"));

            }
            if (dr["nianxiu"] != System.DBNull.Value)
            {
                nianxiu1.Text = dr.GetString(dr.GetOrdinal("nianxiu"));

            }
            if (dr["shijia"] != System.DBNull.Value)
            {
                shijia1.Text = dr.GetString(dr.GetOrdinal("shijia"));

            }
            if (dr["linshijia"] != System.DBNull.Value)
            {
                linshijia1.Text = dr.GetString(dr.GetOrdinal("linshijia"));

            }
            if (dr["bingjia"] != System.DBNull.Value)
            {
                bingjia1.Text = dr.GetString(dr.GetOrdinal("bingjia"));

            }
            if (dr["kuanggong"] != System.DBNull.Value)
            {
                kuanggong1.Text = dr.GetString(dr.GetOrdinal("kuanggong"));

            }


        }
        SqlHelper.Close();
    
    }
    public void checkbanci2()
    {

        String sql1 = "SELECT * FROM [KaoQinCanShu] where banci='班次2'";
        SqlDataReader dr = SqlHelper.ExecuteReader(CommandType.Text, sql1);
        string str1 = "", str2 = "", str3 = "", str4 = "", str5 = "", str6 = "", str7 = "", str8 = "";
        if (dr.Read())
        {

            if (dr["time1"] != System.DBNull.Value)
            {
                str1 = dr.GetString(dr.GetOrdinal("time1"));
                string[] sArray = str1.Split(':');
                time12_d1.SelectedItem.Text = sArray[0];
                time12_d2.SelectedItem.Text = sArray[1];

            }

            if (dr["time2"] != System.DBNull.Value)
            {
                str2 = dr.GetString(dr.GetOrdinal("time2"));
                string[] sArray = str2.Split(':');
                time22_d1.SelectedItem.Text = sArray[0];
                time22_d2.SelectedItem.Text = sArray[1];

            }

            if (dr["time3"] != System.DBNull.Value)
            {
                str3 = dr.GetString(dr.GetOrdinal("time3"));
                string[] sArray = str3.Split(':');
                time32_d1.SelectedItem.Text = sArray[0];
                time32_d2.SelectedItem.Text = sArray[1];

            }

            if (dr["time4"] != System.DBNull.Value)
            {
                str4 = dr.GetString(dr.GetOrdinal("time4"));
                string[] sArray = str4.Split(':');
                time42_d1.SelectedItem.Text = sArray[0];
                time42_d2.SelectedItem.Text = sArray[1];

            }

            if (dr["time5"] != System.DBNull.Value)
            {
                str5 = dr.GetString(dr.GetOrdinal("time5"));
                string[] sArray = str5.Split(':');
                time52_d1.SelectedItem.Text = sArray[0];
                time52_d2.SelectedItem.Text = sArray[1];

            }

            if (dr["time6"] != System.DBNull.Value)
            {
                str6 = dr.GetString(dr.GetOrdinal("time6"));
                string[] sArray = str6.Split(':');
                time62_d1.SelectedItem.Text = sArray[0];
                time62_d2.SelectedItem.Text = sArray[1];

            }

            if (dr["canbu"] != System.DBNull.Value)
            {
                str7 = dr.GetString(dr.GetOrdinal("canbu"));
                string[] sArray = str7.Split(':');
                time72_d1.SelectedItem.Text = sArray[0];
                time72_d2.SelectedItem.Text = sArray[1];

            }

            if (dr["chebu"] != System.DBNull.Value)
            {
                str8 = dr.GetString(dr.GetOrdinal("chebu"));
                string[] sArray = str8.Split(':');
                time82_d1.SelectedItem.Text = sArray[0];
                time82_d2.SelectedItem.Text = sArray[1];

            }
            if (dr["xianshi1"] != System.DBNull.Value)
            {
                xianshi12.Text = dr.GetString(dr.GetOrdinal("xianshi1"));

            }
            if (dr["xianshi2"] != System.DBNull.Value)
            {
                xianshi22.Text = dr.GetString(dr.GetOrdinal("xianshi2"));

            }
            if (dr["chidao"] != System.DBNull.Value)
            {
                chidao2.Text = dr.GetString(dr.GetOrdinal("chidao"));

            }
            if (dr["zaotiu"] != System.DBNull.Value)
            {
                zaotiu2.Text = dr.GetString(dr.GetOrdinal("zaotiu"));

            }
            if (dr["queqin"] != System.DBNull.Value)
            {
                queqin2.Text = dr.GetString(dr.GetOrdinal("queqin"));

            }
            if (dr["ligang"] != System.DBNull.Value)
            {
                ligang2.Text = dr.GetString(dr.GetOrdinal("ligang"));

            }
            if (dr["nianxiu"] != System.DBNull.Value)
            {
                nianxiu2.Text = dr.GetString(dr.GetOrdinal("nianxiu"));

            }
            if (dr["shijia"] != System.DBNull.Value)
            {
                shijia2.Text = dr.GetString(dr.GetOrdinal("shijia"));

            }
            if (dr["linshijia"] != System.DBNull.Value)
            {
                linshijia2.Text = dr.GetString(dr.GetOrdinal("linshijia"));

            }
            if (dr["bingjia"] != System.DBNull.Value)
            {
                bingjia2.Text = dr.GetString(dr.GetOrdinal("bingjia"));

            }
            if (dr["kuanggong"] != System.DBNull.Value)
            {
                kuanggong2.Text = dr.GetString(dr.GetOrdinal("kuanggong"));

            }


        }
        SqlHelper.Close();

    }
    public void checkbanci3()
    {

        String sql1 = "SELECT * FROM [KaoQinCanShu] where banci='班次3'";
        SqlDataReader dr = SqlHelper.ExecuteReader(CommandType.Text, sql1);
        string str1 = "", str2 = "", str3 = "", str4 = "", str5 = "", str6 = "", str7 = "", str8 = "";
        if (dr.Read())
        {

            if (dr["time1"] != System.DBNull.Value)
            {
                str1 = dr.GetString(dr.GetOrdinal("time1"));
                string[] sArray = str1.Split(':');
                time13_d1.SelectedItem.Text = sArray[0];
                time13_d2.SelectedItem.Text = sArray[1];

            }

            if (dr["time2"] != System.DBNull.Value)
            {
                str2 = dr.GetString(dr.GetOrdinal("time2"));
                string[] sArray = str2.Split(':');
                time23_d1.SelectedItem.Text = sArray[0];
                time23_d2.SelectedItem.Text = sArray[1];

            }

            if (dr["time3"] != System.DBNull.Value)
            {
                str3 = dr.GetString(dr.GetOrdinal("time3"));
                string[] sArray = str3.Split(':');
                time33_d1.SelectedItem.Text = sArray[0];
                time33_d2.SelectedItem.Text = sArray[1];

            }

            if (dr["time4"] != System.DBNull.Value)
            {
                str4 = dr.GetString(dr.GetOrdinal("time4"));
                string[] sArray = str4.Split(':');
                time43_d1.SelectedItem.Text = sArray[0];
                time43_d2.SelectedItem.Text = sArray[1];

            }

            if (dr["time5"] != System.DBNull.Value)
            {
                str5 = dr.GetString(dr.GetOrdinal("time5"));
                string[] sArray = str5.Split(':');
                time53_d1.SelectedItem.Text = sArray[0];
                time53_d2.SelectedItem.Text = sArray[1];

            }

            if (dr["time6"] != System.DBNull.Value)
            {
                str6 = dr.GetString(dr.GetOrdinal("time6"));
                string[] sArray = str6.Split(':');
                time63_d1.SelectedItem.Text = sArray[0];
                time63_d2.SelectedItem.Text = sArray[1];

            }

            if (dr["canbu"] != System.DBNull.Value)
            {
                str7 = dr.GetString(dr.GetOrdinal("canbu"));
                string[] sArray = str7.Split(':');
                time73_d1.SelectedItem.Text = sArray[0];
                time73_d2.SelectedItem.Text = sArray[1];

            }

            if (dr["chebu"] != System.DBNull.Value)
            {
                str8 = dr.GetString(dr.GetOrdinal("chebu"));
                string[] sArray = str8.Split(':');
                time83_d1.SelectedItem.Text = sArray[0];
                time83_d2.SelectedItem.Text = sArray[1];

            }
            if (dr["xianshi1"] != System.DBNull.Value)
            {
                xianshi13.Text = dr.GetString(dr.GetOrdinal("xianshi1"));

            }
            if (dr["xianshi2"] != System.DBNull.Value)
            {
                xianshi23.Text = dr.GetString(dr.GetOrdinal("xianshi2"));

            }
            if (dr["chidao"] != System.DBNull.Value)
            {
                chidao3.Text = dr.GetString(dr.GetOrdinal("chidao"));

            }
            if (dr["zaotiu"] != System.DBNull.Value)
            {
                zaotiu3.Text = dr.GetString(dr.GetOrdinal("zaotiu"));

            }
            if (dr["queqin"] != System.DBNull.Value)
            {
                queqin3.Text = dr.GetString(dr.GetOrdinal("queqin"));

            }
            if (dr["ligang"] != System.DBNull.Value)
            {
                ligang3.Text = dr.GetString(dr.GetOrdinal("ligang"));

            }
            if (dr["nianxiu"] != System.DBNull.Value)
            {
                nianxiu3.Text = dr.GetString(dr.GetOrdinal("nianxiu"));

            }
            if (dr["shijia"] != System.DBNull.Value)
            {
                shijia3.Text = dr.GetString(dr.GetOrdinal("shijia"));

            }
            if (dr["linshijia"] != System.DBNull.Value)
            {
                linshijia3.Text = dr.GetString(dr.GetOrdinal("linshijia"));

            }
            if (dr["bingjia"] != System.DBNull.Value)
            {
                bingjia3.Text = dr.GetString(dr.GetOrdinal("bingjia"));

            }
            if (dr["kuanggong"] != System.DBNull.Value)
            {
                kuanggong3.Text = dr.GetString(dr.GetOrdinal("kuanggong"));

            }


        }
        SqlHelper.Close();

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        bool TFbanci1=false;
         String sql1 = "SELECT * FROM [KaoQinCanShu] where banci='班次1'";
        SqlDataReader dr = SqlHelper.ExecuteReader(CommandType.Text, sql1);
        if(dr.Read())
        {
            TFbanci1=true;

        
        }
        if (TFbanci1 == false)
        {
            string sql4 = "insert into [KaoQinCanShu](banci,time1,time2,time3,time4,time5,time6,xianshi1,xianshi2,canbu,chebu,chidao,zaotiu,queqin,ligang,nianxiu,shijia,linshijia,bingjia,kuanggong)values(@banci,@time1,@time2,@time3,@time4,@time5,@time6,@xianshi1,@xianshi2,@canbu,@chebu,@chidao,@zaotiu,@queqin,@ligang,@nianxiu,@shijia,@linshijia,@bingjia,@kuanggong)";
            SqlParameter[] sps4 = new SqlParameter[20];
            sps4[0] = new SqlParameter("@banci", "班次1");
            sps4[1] = new SqlParameter("@time1", time11_d1.SelectedItem.Text + ":" + time11_d2.SelectedItem.Text);
            sps4[2] = new SqlParameter("@time2", time21_d1.SelectedItem.Text + ":" + time21_d2.SelectedItem.Text);
            sps4[3] = new SqlParameter("@time3", time31_d1.SelectedItem.Text + ":" + time31_d2.SelectedItem.Text);
            sps4[4] = new SqlParameter("@time4", time41_d1.SelectedItem.Text + ":" + time41_d2.SelectedItem.Text);
            sps4[5] = new SqlParameter("@time5", time51_d1.SelectedItem.Text + ":" + time51_d2.SelectedItem.Text);
            sps4[6] = new SqlParameter("@time6", time61_d1.SelectedItem.Text + ":" + time61_d2.SelectedItem.Text);
            sps4[7] = new SqlParameter("@xianshi1", xianshi11.Text);
            sps4[8] = new SqlParameter("@xianshi2", xianshi21.Text);
            sps4[9] = new SqlParameter("@canbu", time71_d1.SelectedItem.Text + ":" + time71_d2.SelectedItem.Text);
            sps4[10] = new SqlParameter("@chebu", time81_d1.SelectedItem.Text + ":" + time81_d2.SelectedItem.Text);
            sps4[11] = new SqlParameter("@chidao", chidao1.Text);
            sps4[12] = new SqlParameter("@zaotiu", zaotiu1.Text);
            sps4[13] = new SqlParameter("@queqin", queqin1.Text);
            sps4[14] = new SqlParameter("@ligang", ligang1.Text);
            sps4[15] = new SqlParameter("@nianxiu", nianxiu1.Text);
            sps4[16] = new SqlParameter("@shijia", shijia1.Text);
            sps4[17] = new SqlParameter("@linshijia", linshijia1.Text);
            sps4[18] = new SqlParameter("@bingjia", bingjia1.Text);
            sps4[19] = new SqlParameter("@kuanggong", kuanggong1.Text);

            int i = SqlHelper.ExecuteNonQuery(sql4, sps4);


            if (i > 0)
            {
                Response.Write("<script>alert('添加成功');</script>");
            }
        }
        else
        {
            string sql2 = "update [KaoQinCanShu] set time1=@time1,time2=@time2,time3=@time3,time4=@time4,time5=@time5,time6=@time6,xianshi1=@xianshi1,xianshi2=@xianshi2,canbu=@canbu,chebu=@chebu,chidao=@chidao,zaotiu=@zaotiu,queqin=@queqin,ligang=@ligang,nianxiu=@nianxiu,shijia=@shijia,linshijia=@linshijia,bingjia=@bingjia,kuanggong=@kuanggong where banci=@banci ";
            SqlParameter[] sps2 = new SqlParameter[20];
            sps2[0] = new SqlParameter("@banci", "班次1");
            sps2[1] = new SqlParameter("@time1", time11_d1.SelectedItem.Text + ":" + time11_d2.SelectedItem.Text);
            sps2[2] = new SqlParameter("@time2", time21_d1.SelectedItem.Text + ":" + time21_d2.SelectedItem.Text);
            sps2[3] = new SqlParameter("@time3", time31_d1.SelectedItem.Text + ":" + time31_d2.SelectedItem.Text);
            sps2[4] = new SqlParameter("@time4", time41_d1.SelectedItem.Text + ":" + time41_d2.SelectedItem.Text);
            sps2[5] = new SqlParameter("@time5", time51_d1.SelectedItem.Text + ":" + time51_d2.SelectedItem.Text);
            sps2[6] = new SqlParameter("@time6", time61_d1.SelectedItem.Text + ":" + time61_d2.SelectedItem.Text);
            sps2[7] = new SqlParameter("@xianshi1", xianshi11.Text);
            sps2[8] = new SqlParameter("@xianshi2", xianshi21.Text);
            sps2[9] = new SqlParameter("@canbu", time71_d1.SelectedItem.Text + ":" + time71_d2.SelectedItem.Text);
            sps2[10] = new SqlParameter("@chebu", time81_d1.SelectedItem.Text + ":" + time81_d2.SelectedItem.Text);
            sps2[11] = new SqlParameter("@chidao", chidao1.Text);
            sps2[12] = new SqlParameter("@zaotiu", zaotiu1.Text);
            sps2[13] = new SqlParameter("@queqin", queqin1.Text);
            sps2[14] = new SqlParameter("@ligang", ligang1.Text);
            sps2[15] = new SqlParameter("@nianxiu", nianxiu1.Text);
            sps2[16] = new SqlParameter("@shijia", shijia1.Text);
            sps2[17] = new SqlParameter("@linshijia", linshijia1.Text);
            sps2[18] = new SqlParameter("@bingjia", bingjia1.Text);
            sps2[19] = new SqlParameter("@kuanggong", kuanggong1.Text);
            int i = SqlHelper.ExecuteNonQuery(sql2, sps2);
            if (i > 0)
            {

                Response.Write("<script>alert('修改成功');</script>");
            }
        
        }


    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        bool TFbanci1 = false;
        String sql1 = "SELECT * FROM [KaoQinCanShu] where banci='班次2'";
        SqlDataReader dr = SqlHelper.ExecuteReader(CommandType.Text, sql1);
        if (dr.Read())
        {
            TFbanci1 = true;


        }
        if (TFbanci1 == false)
        {
            string sql4 = "insert into [KaoQinCanShu](banci,time1,time2,time3,time4,time5,time6,xianshi1,xianshi2,canbu,chebu,chidao,zaotiu,queqin,ligang,nianxiu,shijia,linshijia,bingjia,kuanggong)values(@banci,@time1,@time2,@time3,@time4,@time5,@time6,@xianshi1,@xianshi2,@canbu,@chebu,@chidao,@zaotiu,@queqin,@ligang,@nianxiu,@shijia,@linshijia,@bingjia,@kuanggong)";
            SqlParameter[] sps4 = new SqlParameter[20];
            sps4[0] = new SqlParameter("@banci", "班次2");
            sps4[1] = new SqlParameter("@time1", time12_d1.SelectedItem.Text + ":" + time12_d2.SelectedItem.Text);
            sps4[2] = new SqlParameter("@time2", time22_d1.SelectedItem.Text + ":" + time22_d2.SelectedItem.Text);
            sps4[3] = new SqlParameter("@time3", time32_d1.SelectedItem.Text + ":" + time32_d2.SelectedItem.Text);
            sps4[4] = new SqlParameter("@time4", time42_d1.SelectedItem.Text + ":" + time42_d2.SelectedItem.Text);
            sps4[5] = new SqlParameter("@time5", time52_d1.SelectedItem.Text + ":" + time52_d2.SelectedItem.Text);
            sps4[6] = new SqlParameter("@time6", time62_d1.SelectedItem.Text + ":" + time62_d2.SelectedItem.Text);
            sps4[7] = new SqlParameter("@xianshi1", xianshi12.Text);
            sps4[8] = new SqlParameter("@xianshi2", xianshi22.Text);
            sps4[9] = new SqlParameter("@canbu", time72_d1.SelectedItem.Text + ":" + time72_d2.SelectedItem.Text);
            sps4[10] = new SqlParameter("@chebu", time82_d1.SelectedItem.Text + ":" + time82_d2.SelectedItem.Text);
            sps4[11] = new SqlParameter("@chidao", chidao2.Text);
            sps4[12] = new SqlParameter("@zaotiu", zaotiu2.Text);
            sps4[13] = new SqlParameter("@queqin", queqin2.Text);
            sps4[14] = new SqlParameter("@ligang", ligang2.Text);
            sps4[15] = new SqlParameter("@nianxiu", nianxiu2.Text);
            sps4[16] = new SqlParameter("@shijia", shijia2.Text);
            sps4[17] = new SqlParameter("@linshijia", linshijia2.Text);
            sps4[18] = new SqlParameter("@bingjia", bingjia2.Text);
            sps4[19] = new SqlParameter("@kuanggong", kuanggong2.Text);

            int i = SqlHelper.ExecuteNonQuery(sql4, sps4);


            if (i > 0)
            {
                Response.Write("<script>alert('添加成功');</script>");
            }
        }
        else
        {
            string sql2 = "update [KaoQinCanShu] set time1=@time1,time2=@time2,time3=@time3,time4=@time4,time5=@time5,time6=@time6,xianshi1=@xianshi1,xianshi2=@xianshi2,canbu=@canbu,chebu=@chebu,chidao=@chidao,zaotiu=@zaotiu,queqin=@queqin,ligang=@ligang,nianxiu=@nianxiu,shijia=@shijia,linshijia=@linshijia,bingjia=@bingjia,kuanggong=@kuanggong where banci=@banci ";
            SqlParameter[] sps2 = new SqlParameter[20];
            sps2[0] = new SqlParameter("@banci", "班次2");
            sps2[1] = new SqlParameter("@time1", time12_d1.SelectedItem.Text + ":" + time12_d2.SelectedItem.Text);
            sps2[2] = new SqlParameter("@time2", time22_d1.SelectedItem.Text + ":" + time22_d2.SelectedItem.Text);
            sps2[3] = new SqlParameter("@time3", time32_d1.SelectedItem.Text + ":" + time32_d2.SelectedItem.Text);
            sps2[4] = new SqlParameter("@time4", time42_d1.SelectedItem.Text + ":" + time42_d2.SelectedItem.Text);
            sps2[5] = new SqlParameter("@time5", time52_d1.SelectedItem.Text + ":" + time52_d2.SelectedItem.Text);
            sps2[6] = new SqlParameter("@time6", time62_d1.SelectedItem.Text + ":" + time62_d2.SelectedItem.Text);
            sps2[7] = new SqlParameter("@xianshi1", xianshi12.Text);
            sps2[8] = new SqlParameter("@xianshi2", xianshi22.Text);
            sps2[9] = new SqlParameter("@canbu", time72_d1.SelectedItem.Text + ":" + time72_d2.SelectedItem.Text);
            sps2[10] = new SqlParameter("@chebu", time82_d1.SelectedItem.Text + ":" + time82_d2.SelectedItem.Text);
            sps2[11] = new SqlParameter("@chidao", chidao2.Text);
            sps2[12] = new SqlParameter("@zaotiu", zaotiu2.Text);
            sps2[13] = new SqlParameter("@queqin", queqin2.Text);
            sps2[14] = new SqlParameter("@ligang", ligang2.Text);
            sps2[15] = new SqlParameter("@nianxiu", nianxiu2.Text);
            sps2[16] = new SqlParameter("@shijia", shijia2.Text);
            sps2[17] = new SqlParameter("@linshijia", linshijia2.Text);
            sps2[18] = new SqlParameter("@bingjia", bingjia2.Text);
            sps2[19] = new SqlParameter("@kuanggong", kuanggong2.Text);
            int i = SqlHelper.ExecuteNonQuery(sql2, sps2);
            if (i > 0)
            {

                Response.Write("<script>alert('修改成功');</script>");
            }

        }

    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        bool TFbanci1 = false;
        String sql1 = "SELECT * FROM [KaoQinCanShu] where banci='班次3'";
        SqlDataReader dr = SqlHelper.ExecuteReader(CommandType.Text, sql1);
        if (dr.Read())
        {
            TFbanci1 = true;


        }
        if (TFbanci1 == false)
        {
            string sql4 = "insert into [KaoQinCanShu](banci,time1,time2,time3,time4,time5,time6,xianshi1,xianshi2,canbu,chebu,chidao,zaotiu,queqin,ligang,nianxiu,shijia,linshijia,bingjia,kuanggong)values(@banci,@time1,@time2,@time3,@time4,@time5,@time6,@xianshi1,@xianshi2,@canbu,@chebu,@chidao,@zaotiu,@queqin,@ligang,@nianxiu,@shijia,@linshijia,@bingjia,@kuanggong)";
            SqlParameter[] sps4 = new SqlParameter[20];
            sps4[0] = new SqlParameter("@banci", "班次3");
            sps4[1] = new SqlParameter("@time1", time13_d1.SelectedItem.Text + ":" + time13_d2.SelectedItem.Text);
            sps4[2] = new SqlParameter("@time2", time23_d1.SelectedItem.Text + ":" + time23_d2.SelectedItem.Text);
            sps4[3] = new SqlParameter("@time3", time33_d1.SelectedItem.Text + ":" + time33_d2.SelectedItem.Text);
            sps4[4] = new SqlParameter("@time4", time43_d1.SelectedItem.Text + ":" + time43_d2.SelectedItem.Text);
            sps4[5] = new SqlParameter("@time5", time53_d1.SelectedItem.Text + ":" + time53_d2.SelectedItem.Text);
            sps4[6] = new SqlParameter("@time6", time63_d1.SelectedItem.Text + ":" + time63_d2.SelectedItem.Text);
            sps4[7] = new SqlParameter("@xianshi1", xianshi13.Text);
            sps4[8] = new SqlParameter("@xianshi2", xianshi23.Text);
            sps4[9] = new SqlParameter("@canbu", time73_d1.SelectedItem.Text + ":" + time73_d2.SelectedItem.Text);
            sps4[10] = new SqlParameter("@chebu", time83_d1.SelectedItem.Text + ":" + time83_d2.SelectedItem.Text);
            sps4[11] = new SqlParameter("@chidao", chidao3.Text);
            sps4[12] = new SqlParameter("@zaotiu", zaotiu3.Text);
            sps4[13] = new SqlParameter("@queqin", queqin3.Text);
            sps4[14] = new SqlParameter("@ligang", ligang3.Text);
            sps4[15] = new SqlParameter("@nianxiu", nianxiu3.Text);
            sps4[16] = new SqlParameter("@shijia", shijia3.Text);
            sps4[17] = new SqlParameter("@linshijia", linshijia3.Text);
            sps4[18] = new SqlParameter("@bingjia", bingjia3.Text);
            sps4[19] = new SqlParameter("@kuanggong", kuanggong3.Text);

            int i = SqlHelper.ExecuteNonQuery(sql4, sps4);


            if (i > 0)
            {
                Response.Write("<script>alert('添加成功');</script>");
            }
        }
        else
        {
            string sql2 = "update [KaoQinCanShu] set time1=@time1,time2=@time2,time3=@time3,time4=@time4,time5=@time5,time6=@time6,xianshi1=@xianshi1,xianshi2=@xianshi2,canbu=@canbu,chebu=@chebu,chidao=@chidao,zaotiu=@zaotiu,queqin=@queqin,ligang=@ligang,nianxiu=@nianxiu,shijia=@shijia,linshijia=@linshijia,bingjia=@bingjia,kuanggong=@kuanggong where banci=@banci";
            SqlParameter[] sps2 = new SqlParameter[20];
            sps2[0] = new SqlParameter("@banci", "班次3");
            sps2[1] = new SqlParameter("@time1", time13_d1.SelectedItem.Text + ":" + time13_d2.SelectedItem.Text);
            sps2[2] = new SqlParameter("@time2", time23_d1.SelectedItem.Text + ":" + time23_d2.SelectedItem.Text);
            sps2[3] = new SqlParameter("@time3", time33_d1.SelectedItem.Text + ":" + time33_d2.SelectedItem.Text);
            sps2[4] = new SqlParameter("@time4", time43_d1.SelectedItem.Text + ":" + time43_d2.SelectedItem.Text);
            sps2[5] = new SqlParameter("@time5", time53_d1.SelectedItem.Text + ":" + time53_d2.SelectedItem.Text);
            sps2[6] = new SqlParameter("@time6", time63_d1.SelectedItem.Text + ":" + time63_d2.SelectedItem.Text);
            sps2[7] = new SqlParameter("@xianshi1", xianshi13.Text);
            sps2[8] = new SqlParameter("@xianshi2", xianshi23.Text);
            sps2[9] = new SqlParameter("@canbu", time73_d1.SelectedItem.Text + ":" + time73_d2.SelectedItem.Text);
            sps2[10] = new SqlParameter("@chebu", time83_d1.SelectedItem.Text + ":" + time83_d2.SelectedItem.Text);
            sps2[11] = new SqlParameter("@chidao", chidao3.Text);
            sps2[12] = new SqlParameter("@zaotiu", zaotiu3.Text);
            sps2[13] = new SqlParameter("@queqin", queqin3.Text);
            sps2[14] = new SqlParameter("@ligang", ligang3.Text);
            sps2[15] = new SqlParameter("@nianxiu", nianxiu3.Text);
            sps2[16] = new SqlParameter("@shijia", shijia3.Text);
            sps2[17] = new SqlParameter("@linshijia", linshijia3.Text);
            sps2[18] = new SqlParameter("@bingjia", bingjia3.Text);
            sps2[19] = new SqlParameter("@kuanggong", kuanggong3.Text);
            int i = SqlHelper.ExecuteNonQuery(sql2, sps2);
            if (i > 0)
            {

                Response.Write("<script>alert('修改成功');</script>");
            }

        }

    }
}