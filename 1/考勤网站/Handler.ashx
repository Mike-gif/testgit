<%@ WebHandler Language="C#" Class="Handler" %>

using System;
using System.Web;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Data;
using System.Data.SqlClient;

public class Handler : IHttpHandler {

    public SqlConnection getcon()
    {
        string M_str_sqlcon = "Data Source=K\\SQL1;Initial Catalog=KaoQin;Integrated Security=True;";
        SqlConnection myCon = new SqlConnection(M_str_sqlcon);
        return myCon;
    }

    DataTable mytable = new DataTable();

    public DataTable gettable(string M_str_sqlstr)
    {
        SqlConnection sqlcon = this.getcon();
        SqlDataAdapter sqlda = new SqlDataAdapter(M_str_sqlstr, sqlcon);
        sqlda.Fill(mytable);
        sqlcon.Close();
        sqlcon.Dispose();
        return mytable;
    }
    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "application/json";
        string number = context.Request.Params["username"];
        string password =context.Request.Params["psw"];  //获取前端传过来的数据
        context.Response.Write(password);
        if (number != null && password != null)
        {
           
            string strsql = "select password from userinfo where number = '" + number + "' and password='" + GetMD5(password) + "'";          //查询数据库
            DataTable dt = gettable(strsql);
            string result = "";//获取DataTable
            if (dt.Rows.Count > 0 && dt != null)
            {

               result = "{\"password\":\"" + dt.Rows[0]["password"].ToString() + "\"}"; ;   //设置字符串result，此处为JavaScript的值，需要前端将这个值转化为json字符串
              
                //给前端传递字符串result
            }
            context.Response.Write(result);
        }
    }
    public static string GetMD5(string str)
    {
        string ret = " ";
        if (str !=null)
        {
            byte[] b = System.Text.Encoding.Default.GetBytes(str);
            b = new System.Security.Cryptography.MD5CryptoServiceProvider().ComputeHash(b);
            
            for (int i = 0; i < b.Length; i++)
            {
                ret += b[i].ToString("x").PadLeft(2, '0');
            }
           
        }
        return ret;
    }
    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

}