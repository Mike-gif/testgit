using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Text;
using System.Web.Configuration;
using DBHelper;

public partial class admin_ChangeName : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {

            String sql1 = "select * from [KaoqinName] where id=1";
            DataTable ds_all = SqlHelper.ExecuteDataTable(sql1);
            int i_all = ds_all.Rows.Count;

            if (i_all > 0)
            {
                tb_name.Text = ds_all.Rows[0]["kaoqinName"].ToString();
            }
        }
      
       
        
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
          bool TFbanci1=false;
          String sql1 = "SELECT * FROM [KaoqinName] ";
          DataTable ds_all = SqlHelper.ExecuteDataTable(sql1);
          int i_all = ds_all.Rows.Count;
          if(i_all > 0)
        {
            TFbanci1=true;

        
        }
        if (TFbanci1 == false)
        {
            string sql4 = "insert into [KaoqinName](id,kaoqinName)values(@id,@kaoqinName)";
            SqlParameter[] sps4 = new SqlParameter[2];
            sps4[0] = new SqlParameter("@id", "1");
            sps4[1] = new SqlParameter("@kaoqinName",tb_name.Text);
      

            int i = SqlHelper.ExecuteNonQuery(sql4, sps4);


            if (i > 0)
            {
                Response.Write("<script>alert('添加成功');</script>");
                Response.Redirect("~/admin/ChangeName.aspx");
            }
        }
        else
        {
            string sql2 = "update [KaoqinName] set kaoqinName=@kaoqinName where id=1 ";
            SqlParameter[] sps2 = new SqlParameter[1];
            sps2[0] = new SqlParameter("@kaoqinName",tb_name.Text );
           
            int i = SqlHelper.ExecuteNonQuery(sql2, sps2);
            if (i > 0)
            {

                Response.Write("<script>alert('修改成功');</script>");
                Response.Redirect("~/admin/ChangeName.aspx");
            }

        }
    }
}