using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using DBHelper;
using System.Data;

public partial class user_edit_ShenQing : System.Web.UI.Page
{
    qingjia person = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
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
            string fun = Request.QueryString["operfun"];
            int operid = Convert.ToInt32(Request.QueryString["operid"]);
            if (fun == "edit")
            {

                string sql = "select * from [qingjia] where Q_ID=" + operid;
                using (SqlDataReader dr = SqlHelper.ExecuteReader(CommandType.Text, sql))
                {
                    if (dr.Read())
                    {
                        person = new qingjia();
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
        }
        Calendar1.Visible = false;
        Calendar2.Visible = false;
    }
    protected void Calendar1_SelectionChanged(object sender, EventArgs e)
    {
        startdate.Text = Calendar1.SelectedDate.ToString();
        if (!(startdate.Text == ""))
        {
            Calendar1.Visible = false;

            startdate.Text = Calendar1.SelectedDate.ToString("yyyy-MM-dd");
        }
    }
    protected void Calendar2_SelectionChanged(object sender, EventArgs e)
    {
        enddate.Text = Calendar1.SelectedDate.ToString();
        if (!(enddate.Text == ""))
        {
            Calendar2.Visible = false;

            enddate.Text = Calendar2.SelectedDate.ToString("yyyy-MM-dd");
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
    protected void lbSubmitAdd_Click(object sender, EventArgs e)
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
            string sql4 = "update [qingjia] set q_startdate=@c_startdate,q_enddate=@c_enddate,q_things=@c_things,q_shixiang=@q_shixiang,q_statue=@q_statue,q_all=@q_all where Q_ID=" + _ID.Text;
            SqlParameter[] sps4 = new SqlParameter[6];
            sps4[0] = new SqlParameter("@c_startdate", strtime1);
            sps4[1] = new SqlParameter("@c_enddate", strtime2);
            sps4[2] = new SqlParameter("@c_things", thing.Text);
            sps4[3] = new SqlParameter("@q_shixiang", ddl_shixiang.SelectedItem.Text);
            sps4[4] = new SqlParameter("@q_statue", "3");
            sps4[5] = new SqlParameter("@q_all", tianall.Text);

            int result = SqlHelper.ExecuteNonQuery(sql4, sps4);

            if (result > 0)
            {
                Response.Redirect("ShenQing.aspx");

            }

        }
    }


}