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

public partial class admin_Cardaddress : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            Getsetaddr();
           

        }
    }
    public void Getsetaddr()
    {
        string sql1 = "SELECT * FROM [cardaddr] where cardaddr_id='1'";
        DataTable dt = SqlHelper.ExecuteDataTable(sql1);
        int i_all = dt.Rows.Count;

        for (int i = 0; i < i_all; i++)
        {
            if (dt.Rows[i]["cardaddr_jin"].ToString() != "")
            {
                tb_jin.Text = dt.Rows[i]["cardaddr_jin"].ToString();
            
            }
            if (dt.Rows[i]["cardaddr_chu"].ToString() != "")
            {
                tb_chu.Text = dt.Rows[i]["cardaddr_chu"].ToString();

            }
       
        }
    }
    protected void setaddr_Click(object sender, EventArgs e)
    {
        if (tb_chu.Text == "" || tb_jin.Text == "")
        {
            return;
        }
        int in_tbjin= int.Parse(tb_jin.Text);
        int in_tbchu= int.Parse(tb_chu.Text);
        if (in_tbchu < 0 || in_tbchu > 256)
        {
            Response.Write("<script>alert('地址不能大于255,或者小于0');</script>");
            return;
        }
        if (in_tbjin < 0 || in_tbjin> 256)
        {
            Response.Write("<script>alert('地址不能大于255,或者小于0');</script>");
            return;
        }
        bool TFbanci1 = false;
        String sql1 = "SELECT * FROM [cardaddr]";
        DataTable dt = SqlHelper.ExecuteDataTable(sql1);
        int i_all = dt.Rows.Count;
        if (i_all>0)
        {
            TFbanci1 = true;


        }
        if (TFbanci1 == false)
        {
            string sql4 = "insert into [cardaddr](cardaddr_jin,cardaddr_chu,cardaddr_id)values(@cardaddr_jin,@cardaddr_chu,@cardaddr_id)";
            SqlParameter[] sps4 = new SqlParameter[3];
            sps4[0] = new SqlParameter("@cardaddr_jin", tb_jin.Text);
            sps4[1] = new SqlParameter("@cardaddr_chu",tb_chu.Text);
            sps4[2] = new SqlParameter("@cardaddr_id", "1");

            int i = SqlHelper.ExecuteNonQuery(sql4, sps4);


            if (i > 0)
            {
                Response.Write("<script>alert('添加成功');</script>");
            }
        }
        else
        {
            string sql2 = "update [cardaddr] set cardaddr_jin=@cardaddr_jin,cardaddr_chu=@cardaddr_chu where cardaddr_id=@cardaddr_id";
            SqlParameter[] sps2 = new SqlParameter[3];
            sps2[0] = new SqlParameter("@cardaddr_jin", tb_jin.Text);
            sps2[1] = new SqlParameter("@cardaddr_chu", tb_chu.Text);
            sps2[2] = new SqlParameter("@cardaddr_id", "1");

            int i = SqlHelper.ExecuteNonQuery(sql2, sps2);
            if (i > 0)
            {

                Response.Write("<script>alert('修改成功');</script>");
            }

        }

    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Getsetaddr();
    }
}