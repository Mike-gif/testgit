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
using System.Security.Authentication;
public partial class login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            DataTable dt_allgongzuori = SqlHelper.Read_TABLE("kaoqinnameprc");
            int i_all = dt_allgongzuori.Rows.Count;

            if (i_all > 0)
            {
                //setkaoqinName.Text = dr.GetString(dr.GetOrdinal("kaoqinName"));
                setkaoqinName.Text = dt_allgongzuori.Rows[0]["kaoqinName"].ToString();
            }


        }

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string str = _login.Text;
        int index = str.IndexOf("'");
        int  index2=str.IndexOf("\"");
        if (index > -1||index2 > -1)
        {
            Response.Write("<script>alert('不能包含英文单(双)引号！');location='login.aspx'</script>");
            return;
        }
           DataTable dt_allgongzuori = SqlHelper.Read_TABLE("userinflogin", _login.Text, GetMD5(_password.Text),"number","password");
           int i = dt_allgongzuori.Rows.Count;
            if (i > 0)
            {

                Session["number"] = _login.Text;
                Session["name"]= dt_allgongzuori.Rows[0]["name"].ToString();
                Response.Redirect("~/user/ChuQin.aspx");
            }
            else
            {

                String sql_admin = "select * from [user] where username='" + _login.Text + "' and password='" + GetMD5(_password.Text) + "' and type='网站'";
                DataTable dt_userlogin = SqlHelper.ExecuteDataTable(sql_admin);
                int a = dt_userlogin.Rows.Count;
                if (a > 0)
                {
                    Response.Redirect("~/admin/SeekChuQin.aspx");

                }

                else 
                {
                    String sql1 = "select * from [user] where username='" + _login.Text + "' and password='" + GetMD5(_password.Text) + "' and type='HR'";
                    DataTable dt_hr = SqlHelper.ExecuteDataTable(sql1);
                    int i_all = dt_hr.Rows.Count;

                    if (i_all > 0)
                    {
                        Response.Redirect("~/HR/YuanGongInf.aspx");

                    }
                    else
                    {
                        Response.Write("<script>alert('密码或用户名密码不正确！');location='login.aspx'</script>");
                    }
                }

            }
        }

    public static string GetMD5(string str)
    {
        byte[] b = System.Text.Encoding.Default.GetBytes(str);
        b = new System.Security.Cryptography.MD5CryptoServiceProvider().ComputeHash(b);
        string ret = " ";
        for (int i = 0; i < b.Length; i++)
        {
            ret += b[i].ToString("x").PadLeft(2, '0');
        }
        return ret;
    }
}
