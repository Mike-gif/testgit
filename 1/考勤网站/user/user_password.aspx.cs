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

public partial class user_user_password : System.Web.UI.Page
{
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Session["number"] == null)
            {
                Response.Write("<script>alert('登录时间过期，请重新登录');window.location='../login.aspx';</script>");
                return;
            }
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (Session["number"] == null)
        {
            Response.Write("<script>alert('登录时间过期，请重新登录');window.location='../login.aspx';</script>");
            return;
        }

        string password = "";
        String sql = "SELECT password FROM [userinfo] where number='" + Session["number"] + "'";

        SqlDataReader dr = SqlHelper.ExecuteReader(CommandType.Text, sql);
        if (dr.Read())
        {
            password = dr.GetString(dr.GetOrdinal("password"));
        }
        SqlHelper.Close();

        if (GetMD5(password1.Text) == password && password2.Text == password3.Text)
        {

            string sql1 = "update [userinfo] set password=@password where number='" + Session["number"] + "'";
            SqlParameter[] sps1 = new SqlParameter[]
            {
                new SqlParameter("@password", GetMD5(password2.Text)),
            };
            int a = SqlHelper.ExecuteNonQuery(sql1, sps1);
            if (a > 0)
            {

                Response.Write("<script>alert('修改成功');window.location='user_password.aspx';</script>");
            }



        }
        else if (GetMD5(password1.Text) != password)
        {
            Response.Write("<script>alert('初始密码输入错误');</script>");
        }
        else if (password2.Text != password3.Text)
        { Response.Write("<script>alert('两次新密码输入不一致');</script>"); };



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
