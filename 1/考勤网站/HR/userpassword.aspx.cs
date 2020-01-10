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
public partial class HR_userpassword : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void ddl_number_SelectedIndexChanged(object sender, EventArgs e)
    {
        tb_name.Text = ddl_number.SelectedItem.Value;
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string sql1 = "update [userinfo] set password=@password where number='" +ddl_number.SelectedItem.Text+ "'";
        SqlParameter[] sps1 = new SqlParameter[]
            {
                new SqlParameter("@password", GetMD5("1234")),
            };
        int a = SqlHelper.ExecuteNonQuery(sql1, sps1);
        if (a > 0)
        {

            Response.Write("<script>alert('员工："+ddl_number.SelectedItem.Value+"  密码重置成功');window.location='userpassword.aspx';</script>");
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