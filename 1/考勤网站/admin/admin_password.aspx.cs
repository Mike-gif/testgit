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

public partial class admin_admin_password : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {

        string password = "";
        DataTable dt_allgongzuori = SqlHelper.Read_TABLE("userpassword");
        int i_all = dt_allgongzuori.Rows.Count;

        if (i_all > 0)
        {
            password = dt_allgongzuori.Rows[0]["password"].ToString();
        }
      

        if (GetMD5(password1.Text) == password && password2.Text == password3.Text)
        {


            string sql1 = "update [user] set password=@password where type='admin'";
            SqlParameter[] sps1 = new SqlParameter[]
            {
                new SqlParameter("@password", GetMD5(password2.Text)),
            };
            int a = SqlHelper.ExecuteNonQuery(sql1, sps1);
            if (a > 0)
            {

                Response.Write("<script>alert('修改成功');window.location='admin_password.aspx';</script>");
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
