using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;
using DBHelper;


public partial class user_ZhouJH : System.Web.UI.Page
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
            Calendar1.Visible = false;
            if (Session["name"] != null)
                name.Text = Session["name"].ToString();
        }
    }
   
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        Calendar1.Visible = true;
        time1.ReadOnly = false;
    }
    protected void Calendar1_SelectionChanged(object sender, EventArgs e)
    {
      
     
         Calendar1.Visible = false;
         if (time1.ReadOnly == true)
         {
             time1.Text = Calendar1.SelectedDate.ToString("yyyy-MM-dd");
             time1.ReadOnly = false;
         }
         else
         {
             startdate.Text = Calendar1.SelectedDate.ToString("yyyy-MM-dd");
         }

    }
    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        Calendar1.Visible = true;
        time1.ReadOnly = true;
    }
    protected void Button3_Click(object sender, EventArgs e)//查询
    {
        if (Seek())
        {
            Button1.Visible = false;
            Button2.Visible = false;
        
        }
          
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Button1.Visible = true;
        Button2.Visible = true;
        if (Button1.Text == "添加")
        {
            String sql1 = "SELECT * FROM [zhoutab] where z_time='" + time1.Text + "' and z_number='" + Session["number"] + "'";
            DataTable dt_allgongzuori = SqlHelper.ExecuteDataTable(sql1);
            int i_all = dt_allgongzuori.Rows.Count;

            if (i_all > 0)
            {

                ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('该日期周报已经存在，请重新选择')</script>");
                return;
            }
            string sql4 = "insert into [zhoutab](z_number,z_name,z_bumen,z_zhiwu,z_time,z_strtime,z_strwork,z_strwan,z_strbeizhu,z_strbuzu,z_strbanfa,z_shijian,k_jihua ,z_mubiao,z_usetime,z_jianyi)values(@z_number,@z_name,@z_bumen,@z_zhiwu,@z_time,@z_strtime,@z_strwork,@z_strwan,@z_strbeizhu,@z_strbuzu,@z_strbanfa,@z_shijian,@k_jihua ,@z_mubiao,@z_usetime,@z_jianyi)";
            SqlParameter[] sps4 = new SqlParameter[16];
            sps4[0] = new SqlParameter("@z_number", Session["number"]);
            sps4[1] = new SqlParameter("@z_name", Session["name"]);
            sps4[2] = new SqlParameter("@z_bumen", bumen.Text);
            sps4[3] = new SqlParameter("@z_zhiwu", zhiwu.Text);
            sps4[4] = new SqlParameter("@z_time", time1.Text);
            sps4[5] = new SqlParameter("@z_strtime", strtime.Text);
            sps4[6] = new SqlParameter("@z_strwork", strword1.Text + "★" + strword2.Text + "★" + strword3.Text + "★" + strword4.Text + "★" + strword5.Text + "★" + strword6.Text);
            sps4[7] = new SqlParameter("@z_strwan", strwan1.Text + "★" + strwan2.Text + "★" + strwan3.Text + "★" + strwan4.Text + "★" + strwan5.Text + "★" + strwan6.Text);
            sps4[8] = new SqlParameter("@z_strbeizhu", strbeizhu1.Text + "★" + strbeizhu2.Text + "★" + strbeizhu3.Text + "★" + strbeizhu4.Text + "★" + strbeizhu5.Text + "★" + strbeizhu6.Text);
            sps4[9] = new SqlParameter("@z_strbuzu", strbuzu.Text);
            sps4[10] = new SqlParameter("@z_strbanfa", strbanfa.Text);
            sps4[11] = new SqlParameter("@z_shijian", shijian1.Text + "★" + shijian2.Text + "★" + shijian3.Text + "★" + shijian4.Text + "★" + shijian5.Text + "★" + shijian6.Text);
            sps4[12] = new SqlParameter("@k_jihua ", jihua1.Text + "★" + jihua2.Text + "★" + jihua3.Text + "★" + jihua4.Text + "★" + jihua5.Text + "★" + jihua6.Text);
            sps4[13] = new SqlParameter("@z_mubiao", mubiao1.Text + "★" + mubiao2.Text + "★" + mubiao3.Text + "★" + mubiao4.Text + "★" + mubiao5.Text + "★" + mubiao6.Text);
            sps4[14] = new SqlParameter("@z_usetime", usetime1.Text + "★" + usetime2.Text + "★" + usetime3.Text + "★" + usetime4.Text + "★" + usetime5.Text + "★" + usetime6.Text);
            sps4[15] = new SqlParameter("@z_jianyi", jianyi.Text);
            int i = SqlHelper.ExecuteNonQuery(sql4, sps4);


            if (i > 0)
            {
                Response.Write("<script>alert('添加成功');window.location='ZhouJH.aspx';</script>");
                // Response.Redirect("KaoHe.aspx");
            }

        }
        if (Button1.Text == "确定修改")
        {
            String sql2 = "SELECT * FROM [zhoutab] where z_id=" + z_ID.Text;
            SqlDataReader dr = SqlHelper.ExecuteReader(CommandType.Text, sql2);

            if (dr.Read())
            {
                string str = dr["z_time"].ToString();
                string yearstr = time1.Text;
                if (str != yearstr)
                {
                    SqlHelper.Close();
                    String sql3 = "SELECT * FROM [zhoutab] where z_number='" + Session["number"] + "' and z_time='" + time1.Text + "'";
                    SqlDataReader dr2 = SqlHelper.ExecuteReader(CommandType.Text, sql3);
                    if (dr2.Read())
                    {
                        Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "success", "alert(\"该日期已经存在请重新选择！\"); ", true);
                        SqlHelper.Close();
                        return;
                    }
                }
                else {
                    SqlHelper.Close();
                }

            }
            string sql4 = "update [zhoutab] set z_name=@z_name,z_bumen=@z_bumen,z_zhiwu=@z_zhiwu,z_time=@z_time,z_strtime=@z_strtime,z_strwork=@z_strwork,z_strwan=@z_strwan,z_strbeizhu=@z_strbeizhu,z_strbuzu=@z_strbuzu,z_strbanfa=@z_strbanfa,z_shijian=@z_shijian,k_jihua =@k_jihua ,z_mubiao=@z_mubiao,z_usetime=@z_usetime,z_jianyi=@z_jianyi where z_number=@z_number and z_id='" + z_ID .Text+ "'";
            SqlParameter[] sps4 = new SqlParameter[16];
            sps4[0] = new SqlParameter("@z_number", Session["number"]);
            sps4[1] = new SqlParameter("@z_name", Session["name"]);
            sps4[2] = new SqlParameter("@z_bumen", bumen.Text);
            sps4[3] = new SqlParameter("@z_zhiwu", zhiwu.Text);
            sps4[4] = new SqlParameter("@z_time", time1.Text);
            sps4[5] = new SqlParameter("@z_strtime", strtime.Text);
            sps4[6] = new SqlParameter("@z_strwork", strword1.Text + "★" + strword2.Text + "★" + strword3.Text + "★" + strword4.Text + "★" + strword5.Text + "★" + strword6.Text);
            sps4[7] = new SqlParameter("@z_strwan", strwan1.Text + "★" + strwan2.Text + "★" + strwan3.Text + "★" + strwan4.Text + "★" + strwan5.Text + "★" + strwan6.Text);
            sps4[8] = new SqlParameter("@z_strbeizhu", strbeizhu1.Text + "★" + strbeizhu2.Text + "★" + strbeizhu3.Text + "★" + strbeizhu4.Text + "★" + strbeizhu5.Text + "★" + strbeizhu6.Text);
            sps4[9] = new SqlParameter("@z_strbuzu", strbuzu.Text);
            sps4[10] = new SqlParameter("@z_strbanfa", strbanfa.Text);
            sps4[11] = new SqlParameter("@z_shijian", shijian1.Text + "★" + shijian2.Text + "★" + shijian3.Text + "★" + shijian4.Text + "★" + shijian5.Text + "★" + shijian6.Text);
            sps4[12] = new SqlParameter("@k_jihua ", jihua1.Text + "★" + jihua2.Text + "★" + jihua3.Text + "★" + jihua4.Text + "★" + jihua5.Text + "★" + jihua6.Text);
            sps4[13] = new SqlParameter("@z_mubiao", mubiao1.Text + "★" + mubiao2.Text + "★" + mubiao3.Text + "★" + mubiao4.Text + "★" + mubiao5.Text + "★" + mubiao6.Text);
            sps4[14] = new SqlParameter("@z_usetime", usetime1.Text + "★" + usetime2.Text + "★" + usetime3.Text + "★" + usetime4.Text + "★" + usetime5.Text + "★" + usetime6.Text);
            sps4[15] = new SqlParameter("@z_jianyi", jianyi.Text);



            int result = SqlHelper.ExecuteNonQuery(sql4, sps4);

            if (result > 0)
            {

                Response.Write("<script>alert('修改成功');window.location='ZhouJH.aspx';</script>");
               
            }
            else
            {
                Response.Write("<script>alert('修改失败');window.location='ZhouJH.aspx';</script>");
            }
        
        }

    }
   
   protected void Button2_Click(object sender, EventArgs e)//取消
   {
       if (Button1.Text == "确定修改")
       { 
         Seek();
       }
   }
   protected void Button4_Click(object sender, EventArgs e)
   {
       Button1.Visible = true;
       Button2.Visible = true;
       if (Seek())
       {
           Button1.Text = "确定修改";
       }
   }
   public bool Seek()
   {
       if (startdate.Text == "")
           return false;
       string sql = "SELECT * FROM [zhoutab] WHERE z_number ='" + Session["number"] + "' and z_time='" + startdate.Text + "'";
       DataTable dt = SqlHelper.ExecuteDataTable(sql);
       int i_all = dt.Rows.Count;
       if (i_all > 0)
       {
           z_ID.Text = dt.Rows[0]["z_id"].ToString();
           bumen.Text = dt.Rows[0]["z_bumen"].ToString();
           zhiwu.Text = dt.Rows[0]["z_zhiwu"].ToString();
           time1.Text = dt.Rows[0]["z_time"].ToString();
           strtime.Text = dt.Rows[0]["z_strtime"].ToString();
           //主要工作
           string getwork = dt.Rows[0]["z_strwork"].ToString();
           string[] s_th1 = getwork.Split('★');
           int i = 0;
           foreach (string _s1 in s_th1)
           {
               if (i == 0)
                   strword1.Text = _s1;
               if (i == 1)
                   strword2.Text = _s1;
               if (i == 2)
                   strword3.Text = _s1;
               if (i == 3)
                   strword4.Text = _s1;
               if (i == 4)
                   strword5.Text = _s1;
               if (i == 5)
                   strword6.Text = _s1;
               i++;
           }
           //完成情况
           string getwan = dt.Rows[0]["z_strwan"].ToString();
           string[] s_th2 = getwan.Split('★');
           i = 0;
           foreach (string _s2 in s_th2)
           {
               if (i == 0)
                   strwan1.Text = _s2;
               if (i == 1)
                   strwan2.Text = _s2;
               if (i == 2)
                   strwan3.Text = _s2;
               if (i == 3)
                   strwan4.Text = _s2;
               if (i == 4)
                   strwan5.Text = _s2;
               if (i == 5)
                   strwan6.Text = _s2;
               i++;
           } //备注
           string getbeizhu = dt.Rows[0]["z_strbeizhu"].ToString();
           string[] s_th3 = getbeizhu.Split('★');
           i = 0;
           foreach (string _s3 in s_th3)
           {
               if (i == 0)
                   strbeizhu1.Text = _s3;
               if (i == 1)
                   strbeizhu2.Text = _s3;
               if (i == 2)
                   strbeizhu3.Text = _s3;
               if (i == 3)
                   strbeizhu4.Text = _s3;
               if (i == 4)
                   strbeizhu5.Text = _s3;
               if (i == 5)
                   strbeizhu6.Text = _s3;
               i++;
           }
           //时间\事件
           string getshijian = dt.Rows[0]["z_shijian"].ToString();
           string[] s_th4 = getshijian.Split('★');
           i = 0;
           foreach (string _s4 in s_th4)
           {
               if (i == 0)
                   shijian1.Text = _s4;
               if (i == 1)
                   shijian2.Text = _s4;
               if (i == 2)
                   shijian3.Text = _s4;
               if (i == 3)
                   shijian4.Text = _s4;
               if (i == 4)
                   shijian5.Text = _s4;
               if (i == 5)
                   shijian6.Text = _s4;
               i++;
           } //预计计划
           string getjihua = dt.Rows[0]["k_jihua "].ToString();
           string[] s_th5 = getjihua.Split('★');
           i = 0;
           foreach (string _s5 in s_th5)
           {
               if (i == 0)
                   jihua1.Text = _s5;
               if (i == 1)
                   jihua2.Text = _s5;
               if (i == 2)
                   jihua3.Text = _s5;
               if (i == 3)
                   jihua4.Text = _s5;
               if (i == 4)
                   jihua5.Text = _s5;
               if (i == 5)
                   jihua6.Text = _s5;
               i++;
           } //实现目标
           string getmubiao = dt.Rows[0]["z_mubiao"].ToString();
           string[] s_th6 = getmubiao.Split('★');
           i = 0;
           foreach (string _s6 in s_th6)
           {
               if (i == 0)
                   mubiao1.Text = _s6;
               if (i == 1)
                   mubiao2.Text = _s6;
               if (i == 2)
                   mubiao3.Text = _s6;
               if (i == 3)
                   mubiao4.Text = _s6;
               if (i == 4)
                   mubiao5.Text = _s6;
               if (i == 5)
                   mubiao6.Text = _s6;
               i++;
           } //预计耗时
           string getusetime = dt.Rows[0]["z_usetime"].ToString();
           string[] s_th7 = getusetime.Split('★');
           i = 0;
           foreach (string _s7 in s_th7)
           {
               if (i == 0)
                   usetime1.Text = _s7;
               if (i == 1)
                   usetime2.Text = _s7;
               if (i == 2)
                   usetime3.Text = _s7;
               if (i == 3)
                   usetime4.Text = _s7;
               if (i == 4)
                   usetime5.Text = _s7;
               if (i == 5)
                   usetime6.Text = _s7;
               i++;
           }
           jianyi.Text = dt.Rows[0]["z_jianyi"].ToString();
           strbuzu.Text = dt.Rows[0]["z_strbuzu"].ToString();
           strbanfa.Text = dt.Rows[0]["z_strbanfa"].ToString();
           return true;
       }
       else
       {

               return false;
           }

   }
   protected void Button6_Click(object sender, EventArgs e)
   {
       Button1.Visible = true;
       Button2.Visible = true;
       Response.Write("<script>window.location='ZhouJH.aspx';</script>");
   }
}