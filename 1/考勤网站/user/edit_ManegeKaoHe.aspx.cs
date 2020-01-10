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

public partial class user_edit_ManegeKaoHe : System.Web.UI.Page
{
    kaohe person = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            

            string fun = Request.QueryString["operfun"];
           // int operid = Convert.ToInt32(Request.QueryString["operid"]);
            string operid = Request.QueryString["operid"];
            if (fun == "edit")
            {

                string sql = "select * from [kaohe] where k_id=" + operid;
                using (SqlDataReader dr = SqlHelper.ExecuteReader(CommandType.Text, sql))
                {
                    if (dr.Read())
                    {
                        person = new kaohe();
                        _ID.Text = dr["k_id"].ToString();
                        _name.Text = dr["k_name"].ToString();
                        startdate.Text = dr["k_time"].ToString();
                        jihua.Text = dr["k_jihua "].ToString();
                        wancheng.Text = dr["k_wancheng"].ToString();
                        pingyu.Text = dr["k_pingyu"].ToString();
                        defen.Text = dr["k_defen"].ToString();



                    }

                }
            }
        }
    }

   
    protected void lbSubmitAdd_Click(object sender, EventArgs e)
    {
        if (Session["number"] == null)
        {
            Response.Write("<script>alert('登录时间过期，请重新登录');window.location='../login.aspx';</script>");
            return;
        }
        string typestr = defen.Text;
        bool intqingalltype = true;
        char[] ch = new char[typestr.Length];
        ch = typestr.ToCharArray();
        for (int j = 0; j < typestr.Length; j++)
        {
            // byte tempbype = Convert.ToByte(typestr[j]);

            if (((ch[j] < 48) || (ch[j] > 57)) && ch[j] != 46)
            {
                intqingalltype = false;
                break;
            }

        }
        if (intqingalltype == false)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('只能输入数值')</script>");

            return;

        }
        float a = 0;
        if (float.TryParse(typestr, out a) == false && typestr != "")
        {
            ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('得分大于等于0')</script>");

            return;
        }

        string sql4 = "update [kaohe] set k_jihua =@k_jihua ,k_wancheng=@k_wancheng,k_pingyu=@k_pingyu,k_defen=@k_defen,k_statue=@k_statue  where k_id=" + _ID.Text;
        SqlParameter[] sps4 = new SqlParameter[5];
        sps4[0] = new SqlParameter("@k_jihua ", jihua.Text);
        sps4[1] = new SqlParameter("@k_wancheng", wancheng.Text);
        sps4[2] = new SqlParameter("@k_pingyu", pingyu.Text);
        sps4[3] = new SqlParameter("@k_defen", defen.Text);
        if (RadioButton1.Checked)
        {
            sps4[4] = new SqlParameter("@k_statue", "0");
        }
        else 
        {
            if (RadioButton2.Checked)
            { 
                sps4[4] = new SqlParameter("@k_statue","1"); 
            }
        }
   



        int result = SqlHelper.ExecuteNonQuery(sql4, sps4);

        if (result > 0)
        {
            Session["name1"] = _name.Text;
            string time = Session["time1"].ToString();
            string time2 = Session["time2"].ToString();

            Response.Redirect("ManegeKaoHe.aspx");

        }
    }





}