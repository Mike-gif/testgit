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

public partial class admin_edit_GongZuoRi : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            string fun = Request.QueryString["operfun"];
            int operid = Convert.ToInt32(Request.QueryString["operid"]);
            if (fun == "edit")
            {

                string sql = "select * from [gongzuori] where id=" + operid;
                using (SqlDataReader dr = SqlHelper.ExecuteReader(CommandType.Text, sql))
                {
                    if (dr.Read())
                    {
                        id.Text =dr["id"].ToString();
                        string str = dr["YearMon"].ToString();
                        string[] sArray = str.Split('-');
                        nianfen.Text = sArray[0];
                        DropDownList1.SelectedValue = sArray[1];
                        TextBox1.Text = dr["gongzuodate"].ToString();
                    }
                }

            }
        }
    }
    protected void Calendar2_SelectionChanged(object sender, EventArgs e)
    {
        string setmonth = "", selectmoth = "";
        string ddl_month = DropDownList1.SelectedItem.Value;

        setmonth = nianfen.Text + "-" + ddl_month;
        selectmoth = Calendar2.SelectedDate.ToString("yyyy-MM");
        int intyear = int.Parse(nianfen.Text);
        if (intyear < 2000 || intyear > 9999)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('请年份格式错误')</script>");
            return;
        }
        DateTime time1 = Convert.ToDateTime(setmonth);
        DateTime time2 = Convert.ToDateTime(selectmoth);
        if (time1 != time2)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('日历月份和已选择月份不一致,请重新选择')</script>");
        }
        else
        {

            string strgongz = TextBox1.Text;
            bool gongzuoritf = false;
            string selectdate = Calendar2.SelectedDate.ToString("yyyy-MM-dd");
            strgongz = strgongz.Replace("\n", string.Empty).Replace("\r", string.Empty);
            string[] s_th = strgongz.Split(',');
            foreach (string _s in s_th)
            {
                if (_s == selectdate)
                {
                    gongzuoritf = true;


                    break;
                }
            }
            if (gongzuoritf)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('该工作日已经存在,请重新选择')</script>");
            }
            else
            {
                TextBox1.Text += Calendar2.SelectedDate.ToString("yyyy-MM-dd") + "," + "\n";

            }




        }


    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        string setmonth = "";
        TextBox1.Text = "";
        if (nianfen.Text == "")
        {
            ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('年份不能为空')</script>");
            return;
        }
        string ddl_month = DropDownList1.SelectedItem.Value;
        setmonth = nianfen.Text + "-" + ddl_month;
        int intyear = int.Parse(nianfen.Text);
        if (intyear < 2000 || intyear > 9999)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('请年份格式错误')</script>");
            return;
        }
        DateTime time1 = Convert.ToDateTime(setmonth);
        DateTime d1 = new DateTime(time1.Year, time1.Month, 1);
        DateTime d2 = d1.AddMonths(1).AddDays(-1);
        System.TimeSpan NDkaoqinxiawu = d2 - d1;//下午考勤
        int nTSecondsxiawu = (int)NDkaoqinxiawu.Days;   //天数差
        for (int i = 1; i <= nTSecondsxiawu + 1; i++)
        {
            DateTime d3 = new DateTime(time1.Year, time1.Month, i);
            if (d3.DayOfWeek.ToString() == "Saturday")
            {
                continue;
            }
            if (d3.DayOfWeek.ToString() == "Sunday")
            {
                continue;
            }
            TextBox1.Text += d3.ToString("yyyy-MM-dd") + "," + "\n";
        }
        //   Calendar2.SelectedDate = "2017-1-1";

    }
    protected void Button1_Click(object sender, EventArgs e)
    {

        int intyear = int.Parse(nianfen.Text);
        if (intyear < 2000 || intyear > 9999)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('请年份格式错误')</script>");
            return;
        }
        String sql1 = "SELECT * FROM [gongzuori] where id=" + id.Text;
        SqlDataReader dr = SqlHelper.ExecuteReader(CommandType.Text, sql1);

        if (dr.Read())
        {
            string str = dr["YearMon"].ToString();
            string yearstr = nianfen.Text + "-" + DropDownList1.SelectedItem.Value;
            if(str!=yearstr)
            {
                SqlHelper.Close();
                String sql2 = "SELECT * FROM [gongzuori] where YearMon='" + nianfen.Text + "-" + DropDownList1.SelectedItem.Value + "'";
                SqlDataReader dr2 = SqlHelper.ExecuteReader(CommandType.Text, sql2);
                if (dr2.Read())
                {
                    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "success", "alert(\"该年月记录已经存在请重新选择！\"); ", true);
                    SqlHelper.Close();
                    return;
                }
            }
           
        }


        string strgongzuori = TextBox1.Text;
        strgongzuori.Remove('\n');
        strgongzuori.Replace(" ", "");
        string sql4 = "update [gongzuori] set YearMon=@YearMon,gongzuodate=@gongzuodate where id=" + id.Text;

        SqlParameter[] sps4 = new SqlParameter[2];
        sps4[0] = new SqlParameter("@YearMon", nianfen.Text + "-" + DropDownList1.SelectedItem.Value);
        sps4[1] = new SqlParameter("@gongzuodate", strgongzuori);


        int i = SqlHelper.ExecuteNonQuery(sql4, sps4);


        if (i > 0)
        {
            Response.Write("<script>alert('修改成功');</script>");
            Response.Redirect("GongZuoRi.aspx");
        }


    }
    
}