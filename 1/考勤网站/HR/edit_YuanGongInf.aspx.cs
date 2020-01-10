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

public partial class admin_edit_YuanGongInf : System.Web.UI.Page
{
   // userinfo person = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            Calendar1.Visible = false;
            u_ruzhi.Text = DateTime.Now.ToString("yyyy-MM-dd");
            string sql1 = "SELECT * FROM [userinfo] ";
            DataTable dt = SqlHelper.ExecuteDataTable(sql1);
            int i_all = dt.Rows.Count;

            for (int i = 0; i < i_all; i++)
            {
                u_shangji.Items.Add(new ListItem(dt.Rows[i]["number"].ToString(), dt.Rows[i]["number"].ToString()));//增加Item
                u_kaoqinadmin.Items.Add(new ListItem(dt.Rows[i]["number"].ToString(), dt.Rows[i]["number"].ToString()));//增加Item
            }
            string fun = Request.QueryString["operfun"];
            int operid = Convert.ToInt32(Request.QueryString["operid"]);
            if (fun == "edit")
            {

                string sql = "select * from [userinfo] where id=" + operid;
                using (SqlDataReader dr = SqlHelper.ExecuteReader(CommandType.Text, sql))
                {
                    if (dr.Read())
                    {
                        //person = new userinfo();
                        _ID.Text = dr["id"].ToString();
                        u_id.Text = dr["number"].ToString();
                        u_name.Text = dr["name"].ToString();
                       u_ddl_banci.Text = dr["Banci"].ToString();
                        u_cardid1.Text = dr["cardid1"].ToString();
                        u_cardid2.Text = dr["cardid2"].ToString();
                        u_cardid3.Text = dr["cardid3"].ToString();
                        u_bumen.Text = dr["bumen"].ToString();
                        u_ruzhi.Text = dr["ruzhi"].ToString();
                        string st = dr["shangji"].ToString();
                        string tt = dr["kaoqinadmin"].ToString();
                        if (st != "")
                        {
                            if (u_shangji.Items.FindByValue(st) != null)
                            {
                                u_shangji.Text = dr["shangji"].ToString();
                            }
                        }
                        if (tt != "")
                        {
                            if ((u_kaoqinadmin.Items.FindByValue(tt) != null))
                            {
                                u_kaoqinadmin.Text = dr["kaoqinadmin"].ToString();
                            }
                        }
                        u_canbu.Text = dr["canbu"].ToString();
                        u_chebu.Text = dr["chebu"].ToString();
                        u_jibie.Text = dr["jibie"].ToString();
                        string zhichista=dr["zaizhi"].ToString();
                        if (zhichista == "在职")
                        {
                            RadioButton1.Checked = true;

                        }
                        else
                        {
                            RadioButton2.Checked = true;
                        }



                    }
                }
                
            }
        }
    }


    protected void lbSubmitAdd_Click(object sender, EventArgs e)
    {
        String sql2= "SELECT * FROM [userinfo] where id=" + _ID.Text;
        SqlDataReader dr = SqlHelper.ExecuteReader(CommandType.Text, sql2);

        if (dr.Read())
        {
            string str = dr["number"].ToString();
            string yearstr =u_id.Text;
            if (str != yearstr)
            {
                SqlHelper.Close();
                String sql3 = "SELECT * FROM [userinfo] where number='" + u_id.Text + "'";
                SqlDataReader dr2 = SqlHelper.ExecuteReader(CommandType.Text, sql3);
                if (dr2.Read())
                {
                    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "success", "alert(\"该员工号已经存在请重新选择！\"); ", true);
                    SqlHelper.Close();
                    return;
                }
            }

        }
        string shangjiinf = "", kaoqinadmininf = "";
        if (u_shangji.Text == "")
        {
            shangjiinf = "";

        }
        else
        {
            shangjiinf = u_shangji.SelectedItem.Text;
        }
        if (u_kaoqinadmin.Text == "")
        {
            kaoqinadmininf = "";

        }
        else
        {
            kaoqinadmininf = u_kaoqinadmin.SelectedItem.Text;
        }
        string sql1 = "update [userinfo] set cardid1=@cardid1,name=@name,number=@number,zaizhi=@zaizhi,Banci=@Banci,cardid2=@cardid2,cardid3=@cardid3,shangji=@shangji,kaoqinadmin=@kaoqinadmin,jibie=@jibie,canbu=@canbu,chebu=@chebu,bumen=@bumen,ruzhi=@ruzhi where id=" + _ID.Text;

        SqlParameter[] sps4 = new SqlParameter[14];
        sps4[0] = new SqlParameter("@cardid1", u_cardid1.Text);
        sps4[1] = new SqlParameter("@name", u_name.Text);
        sps4[2] = new SqlParameter("@number", u_id.Text);
        if (RadioButton1.Checked)
        {
            sps4[3] = new SqlParameter("@zaizhi", "在职");
        }
        else
        {
            if (RadioButton2.Checked)
            {
                sps4[3] = new SqlParameter("@zaizhi", "离职");
            }
        }
        sps4[4] = new SqlParameter("@Banci", u_ddl_banci.SelectedItem.Text);
        sps4[5] = new SqlParameter("@cardid2", u_cardid2.Text);
        sps4[6] = new SqlParameter("@cardid3", u_cardid3.Text);
        sps4[7] = new SqlParameter("@shangji", shangjiinf);
        sps4[8] = new SqlParameter("@kaoqinadmin", kaoqinadmininf);
        sps4[9] = new SqlParameter("@jibie", u_jibie.Text);
        sps4[10] = new SqlParameter("@canbu", u_canbu.Text);
        sps4[11] = new SqlParameter("@chebu", u_chebu.Text);
        sps4[12] = new SqlParameter("@bumen", u_bumen.Text);
        sps4[13] = new SqlParameter("@ruzhi", u_ruzhi.Text);

        int result = SqlHelper.ExecuteNonQuery(sql1, sps4);

        if (result > 0)
        {
            Response.Write("<script>alert('修改成功');</script>");
            string aa=Session["editinf"].ToString();
            Response.Redirect("YuanGongInf.aspx");
            
        }

    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        Calendar1.Visible = true;

    }
    protected void Calendar1_SelectionChanged(object sender, EventArgs e)
    {
        u_ruzhi.Text = Calendar1.SelectedDate.ToString();
        if (!(u_ruzhi.Text == ""))
        {
            Calendar1.Visible = false;

            u_ruzhi.Text = Calendar1.SelectedDate.ToString("yyyy-MM-dd");
        }
    }
   
}