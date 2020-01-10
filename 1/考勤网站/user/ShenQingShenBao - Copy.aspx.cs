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

public partial class user_ShenQingShenBao : System.Web.UI.Page
{
   // int q = 0;

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
            z_time.Text = DateTime.Now.ToString("yyyy-MM-dd");

            Calendar2.Visible = false;
            r_time.Text = DateTime.Now.ToString("yyyy-MM-dd");

            Calendar3.Visible = false;
            startdate.Text = DateTime.Now.ToString("yyyy-MM-dd");

            Calendar4.Visible = false;
            enddate.Text = DateTime.Now.ToString("yyyy-MM-dd");


            GridViewDataBind();
            
            
             for (int i = 0; i <= 23; i++)
            {

                if (i < 10)
                {

                    time11_d1.Items.Add('0' + i.ToString());
                    time12_d1.Items.Add('0' + i.ToString());

                }
                else
                {
                    time11_d1.Items.Add(i.ToString());
                    time12_d1.Items.Add(i.ToString());


                }
            }
            for (int i = 0; i < 60; i++)
            {

                if (i < 10)
                {
                    time11_d2.Items.Add('0' + i.ToString());

                    time12_d2.Items.Add('0' + i.ToString());

                }
                else
                {
                    time11_d2.Items.Add(i.ToString());

                    time12_d2.Items.Add(i.ToString());

                }

            }
            
            time11_d1.Text = "09";
            time12_d1.Text = "18";
        }
        
        gvShow.Style.Add("table-layout", "fixed");
    }
    public string getweek(string dt)
    {
        string week = "";

        switch (dt)
        {
            case "Monday":
                week = "星期一";
                break;
            case "Tuesday":
                week = "星期二";
                break;
            case "Wednesday":
                week = "星期三";
                break;
            case "Thursday":
                week = "星期四";
                break;
            case "Friday":
                week = "星期五";
                break;
            case "Saturday":
                week = "星期六";
                break;
            case "Sunday":
                week = "星期日";
                break;
        }

        return week;

    }
      protected void Calendar1_SelectionChanged(object sender, EventArgs e)
       {
           z_time.Text = Calendar1.SelectedDate.ToString();
           if (!(z_time.Text == ""))
           {
               Calendar1.Visible = false;


               z_time.Text = Calendar1.SelectedDate.ToString("yyyy-MM-dd");
           
            //   System.DateTime newDate = new DateTime();
            //   Response.Write(newDate.DayOfWeek);
           }
       }

    /* 
   protected void Calendar1_SelectionChanged(object sender, EventArgs e)
      {
          int num = Calendar1.SelectedDates.Count;
          for (int i = 0; i <= num - 1; i++)
          {
              z_time.Text = Calendar1.SelectedDates[i].ToShortDateString();
          }
      }
    */
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        Calendar1.Visible = true;
        Calendar2.Visible = false;
        Calendar3.Visible = false;
        Calendar4.Visible = false;
    }

    protected void Calendar2_SelectionChanged(object sender, EventArgs e)
    {
        r_time.Text = Calendar2.SelectedDate.ToString();
        if (!(r_time.Text == ""))
        {
            Calendar2.Visible = false;


            r_time.Text = Calendar2.SelectedDate.ToString("yyyy-MM-dd");
         //  System.DateTime newDate = new DateTime();
         //  Response.Write(newDate.DayOfWeek);
        }
    }
    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        Calendar1.Visible = false;
        Calendar2.Visible = true;
        Calendar3.Visible = false;
        Calendar4.Visible = false;

    }

    protected void Calendar3_SelectionChanged(object sender, EventArgs e)
    {
        startdate.Text = Calendar3.SelectedDate.ToString();
        if (!(startdate.Text == ""))
        {
            Calendar3.Visible = false;

            startdate.Text = Calendar3.SelectedDate.ToString("yyyy-MM-dd");
        }
    }
    protected void LinkButton3_Click(object sender, EventArgs e)
    {
        Calendar1.Visible = false;
        Calendar2.Visible = false;
        Calendar3.Visible =  true;
        Calendar4.Visible = false;
    }

    protected void Calendar4_SelectionChanged(object sender, EventArgs e)
    {
        enddate.Text = Calendar4.SelectedDate.ToString();
        if (!(enddate.Text == ""))
        {
            Calendar4.Visible = false;

            enddate.Text = Calendar4.SelectedDate.ToString("yyyy-MM-dd");
        }
    }
    protected void LinkButton4_Click(object sender, EventArgs e)
    {
        Calendar1.Visible = false;
        Calendar2.Visible = false;
        Calendar3.Visible = false;
        Calendar4.Visible = true;
    }
    /// 绑定数据
    /// </summary>
    /// 

   public void GridViewDataBind()
     {
         string sql = "SELECT * FROM [userinfo] WHERE number ='" + Session["number"] + "'";
         DataTable dt = SqlHelper.ExecuteDataTable(sql);
         int i_all = dt.Rows.Count;
         for (int i = 0; i < i_all; i++)
         {
             TextBox1.Text = dt.Rows[i]["name"].ToString();
             TextBox2.Text = dt.Rows[i]["number"].ToString();
             TextBox3.Text = dt.Rows[i]["jibie"].ToString();
             TextBox4.Text = dt.Rows[i]["name"].ToString();
             string a = dt.Rows[i]["shangji"].ToString();
             string sql_name = "SELECT * FROM [userinfo] WHERE number ='" + a + "'";  //解决部门和入职时间问题
             DataTable dt2 = SqlHelper.ExecuteDataTable(sql_name);
             int i_all2 = dt2.Rows.Count;
             if (i_all2 > 0)
             {
                 TextBox5.Text = dt2.Rows[0]["name"].ToString();

             }

         }
         string sql2 = "select * from [ShenQingShenBao] where s_number='" + Session["number"] + "' order by s_time desc";
         DataSet ds2 = SqlHelper.ExecuteDataSet(sql2);
         Session["Table"] = ds2.Tables[0];
         gvShow.DataSource = ds2;
         gvShow.DataBind();

         foreach (GridViewRow row in gvShow.Rows)
         {
             string gettime = row.Cells[0].Text;
             string[] s_th1 = gettime.Split('-');
             int i = 0;
             string year = "", month = "", sec = "";
             foreach (string _s1 in s_th1)
             {
                 if (i == 0)
                     year = _s1;
                 if (i == 1)
                     month = _s1;
                 if (i == 2)
                     sec = _s1;
                 i++;
             }
             System.DateTime newDate = new DateTime(int.Parse(year), int.Parse(month), int.Parse(sec));
         //    System.Diagnostics.Debug.Write("newDate=" + newDate.ToString());
             row.Cells[0].Text += " " + getweek(newDate.DayOfWeek.ToString());
             LinkButton lb = row.Cells[2].FindControl("lbEdit") as LinkButton;
             LinkButton lt = row.Cells[3].FindControl("lbDelete") as LinkButton;
             string str = row.Cells[3].Text;


             if (str == "1")
             {
                 lb.Visible = false;
                 lt.Visible = false;

                 row.Cells[2].Text = "已批阅";

             }
             else
             {

                 lb.Visible = true;
                 lt.Visible = true;
                 row.Cells[2].Text = "未批阅";
             }
         }


     }
    

     /// <summary>
     /// 返回备注信息
     /// </summary>
     /// <param name="obj"></param>
     /// <returns></returns>
     public string returnRemark(object obj)
     {
         if (string.IsNullOrEmpty(obj.ToString()))
             return "默认";
         else
             return obj.ToString();
     }


     /// <summary>
     /// 单击【下一页】按钮
     /// </summary>
     /// <param name="sender"></param>
     /// <param name="e"></param>
     /// <summary>
     /// 单击【下一页】按钮
     /// </summary>
     /// <param name="sender"></param>
     /// <param name="e"></param>
     protected void gvShow_PageIndexChanging(object sender, GridViewPageEventArgs e)
     {
         gvShow.PageIndex = e.NewPageIndex;
         GridViewDataBind();
     }


     /// <summary>
     /// 显示高亮效果
     /// </summary>
     /// <param name="sender"></param>
     /// <param name="e"></param>
     protected void gvShow_RowDataBound(object sender, GridViewRowEventArgs e)
     {
         if (e.Row.RowType == DataControlRowType.DataRow)
         {
             e.Row.Attributes.Add("onmouseover", "currentcolor=this.style.backgroundColor;this.style.backgroundColor='lightblue'");
             e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=currentcolor");


             LinkButton btn = e.Row.FindControl("lbDelete") as LinkButton;
             btn.Attributes.Add("onclick", "return confirm('确定要删除该工作记录吗？')");


         }
     }

     /// <summary>
     /// 单击某行的操作时
     /// </summary>
     /// <param name="sender"></param>
     /// <param name="e"></param>
     protected void gvShow_RowCommand(object sender, GridViewCommandEventArgs e)
     {
         
         string opername = e.CommandName;                //CommandName和CommandArgument来源于LINKBUTTON的参数传递，CommandName传递命令，CommandArgument传递参数
         string opervalue = e.CommandArgument.ToString();
         string operleibie = null;

         String sql10 = "SELECT s_leibie FROM [ShenQingShenBao] where id='" + opervalue + "'";
         //             System.Diagnostics.Debug.Assert(false, sql10);//打印调试信息
         DataTable dt_leibie = SqlHelper.ExecuteDataTable(sql10);
         int i_all = dt_leibie.Rows.Count;

         if (i_all > 0)
         {
              operleibie = dt_leibie.Rows[0][0].ToString();
         }
        
         if (opername == "Delete")
         {
             /*
                       //  string sql2 = "delete from [ShenQingShenBao] where id=@id";
             string sql2 = "delete from [ShenQingShenBao] where s_time='2019-12-03'";
                          SqlParameter[] sps2 = new SqlParameter[] { 
                        //  new SqlParameter("@id", Convert.ToInt32(opervalue)),
                        new SqlParameter("2019-12-03", Convert.ToInt32(opervalue)),
                        
                          };
           
                          int result = SqlHelper.ExecuteNonQuery(sql2, sps2);
        
              */
                 

           /*          String sql10 = "SELECT s_leibie FROM [ShenQingShenBao] where id='" + opervalue + "'";
      //             System.Diagnostics.Debug.Assert(false, sql10);//打印调试信息
                      DataTable dt_leibie = SqlHelper.ExecuteDataTable(sql10);
             */

             if (operleibie == "周计划") //查询结果如果等于周计划
                  {
                         string sql11 = "delete from [ZhouJiHua] where id=@id";
                         SqlParameter[] sps11 = new SqlParameter[] { 
                      new SqlParameter("@id", opervalue),
                        };
                         int result_zhou = SqlHelper.ExecuteNonQuery(sql11, sps11);
                     }
                      // int i_all = dt_leibie.Rows.Count;

                    //   if (i_all > 0)


             else if (operleibie == "日计划")
                     {
                         string sql12 = "delete from [RiJiHua] where id=@id";
                         SqlParameter[] sps12 = new SqlParameter[] { 
                      new SqlParameter("@id", opervalue),
                        };
                         int result_ri= SqlHelper.ExecuteNonQuery(sql12, sps12);
                      }
                         // int i_all = dt_leibie.Rows.Count;

                         //   if (i_all > 0)

             else if (operleibie == "请假")
                       {
                         string sql13 = "delete from [qingjia] where id=@id";
                         SqlParameter[] sps13= new SqlParameter[] { 
                          new SqlParameter("@id", opervalue),
                           };
                         int result_qingjia = SqlHelper.ExecuteNonQuery(sql13, sps13);
                       }
                         // int i_all = dt_leibie.Rows.Count;

                         //   if (i_all > 0)


                       string sql2 = "delete from [ShenQingShenBao] where id=@id";
                       SqlParameter[] sps2 = new SqlParameter[] { 
                      // new SqlParameter("@id", Convert.ToInt32(opervalue)),
                      new SqlParameter("@id", opervalue),
                        };
                       int result_sheng = SqlHelper.ExecuteNonQuery(sql2, sps2);


             /*          string sql2 = "delete from [ShenQingShenBao] where s_id=@s_id";
                                       SqlParameter[] sps2 = new SqlParameter[] { 
                                       new SqlParameter("@s_id", Convert.ToInt32(opervalue)),
                                        };
                                       int result = SqlHelper.ExecuteNonQuery(sql2, sps2);
             */
             /*
                                          string sql2 = "delete from [ShenQingShenBao] where id=@id";
                                            SqlParameter[] sps2 = new SqlParameter[] { 
                                             //  new SqlParameter("@id",convert(varchar（100）,opervalue.format("{0:G}",dt),120) ),
                                               //  new SqlParameter("@id",convert(varchar(100),opervalue.format("{0:G}",dt),120)),
                                               new SqlParameter("@id",Convert(Varchar(100),opervalue.Format("{0:G}",dt),120)),
                                                };
                                            int result = SqlHelper.ExecuteNonQuery(sql2, sps2);
               */
                                         /*      string sql2 = "delete from [ShenQingShenBao] where id=@id";
                                                //  string sql2 = "delete from [ShenQingShenBao] where s_time='2019-12-03'";
                                                               SqlParameter[] sps2 = new SqlParameter[] { 
                                                             new SqlParameter("@id", Convert.ToInt32(opervalue)),
                                                            //   new SqlParameter("2019-12-03", Convert.ToInt32(opervalue)),
                        
                                                               };
                                                              // Response.Write("<script>alert(sps2);window.location='information.aspx';</script>");
                                                             //  System.Diagnostics.Debug.Write("sps2");
                                                               int result = SqlHelper.ExecuteNonQuery(sql2, sps2);
                                                    //  }
                                              */
             /*     String sql2 = "delete from [ShenQingShenBao] where s_id=@s_id";
                DataTable dt_allgongzuori = SqlHelper.ExecuteDataTable(sql2);
                int i_all = dt_allgongzuori.Rows.Count;

                if (i_all > 0)
                {
                    Response.Redirect("ShenQingShenBao.aspx");
                }
        */
          /*   if (@s_leibie == "周计划")
             {
                 string sql10 = "delete from [ZhouJiHua] where z_id=@z_id";
                 SqlParameter[] sps10 = new SqlParameter[] { 
             new SqlParameter("@z_id", Convert.ToInt32(opervalue)),
             };

                 int result1 = SqlHelper.ExecuteNonQuery(sql10, sps10);
             }
          */
           if (result_sheng > 0)
            Response.Redirect("ShenQingShenBao.aspx");

         }
      //   else if (opername == "Edit")
       //      Response.Redirect("edit_ShenQingShenBao.aspx?operfun=edit&operid=" + opervalue);

           else if (opername == "Edit")
         {
             if (operleibie == "周计划")
               Response.Redirect("edit_ShenQingShenBao_ZhouJiHua.aspx?operfun=edit&operid=" + opervalue);
             else if (operleibie == "日计划")
                 Response.Redirect("edit_ShenQingShenBao_RiJiHua.aspx?operfun=edit&operid=" + opervalue);
                 else if (operleibie == "请假")
                 Response.Redirect("edit_ShenQingShenBao_qingjia.aspx?operfun=edit&operid=" + opervalue);
         }
            

     }

     /// <summary>
     /// 排序
     /// </summary>
     /// <param name="sender"></param>
     /// <param name="e"></param>
     protected void gvShow_Sorting(object sender, GridViewSortEventArgs e)
     {
         DataTable tb = Session["Table"] as DataTable;
         tb.DefaultView.Sort = e.SortExpression;
         gvShow.DataSource = tb;
         gvShow.DataBind();
     }

     


     protected void Btnzhou_Click(object sender, EventArgs e)  //周计划
     {

         
         
         if (Session["number"] == null)
         {
             Response.Write("<script>alert('登录时间过期，请重新登录');window.location='../login.aspx';</script>");
             return;
         }
         String sql1 = "SELECT * FROM [ZhouJiHua] where z_time='" + z_time.Text + "' and z_number='" + Session["number"] + "'";
         DataTable dt_allgongzuori = SqlHelper.ExecuteDataTable(sql1);
         int i_all = dt_allgongzuori.Rows.Count;

         if (i_all > 0) //在数据表[ZhouJiHua]中查找 z_time='" + z_time.Text + "' and z_number='" + Session["number"] + "'"（该用户日历选择的时间下） 的记录是否存在，如果已经有记录就返回。
         {

             ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('该日期已经存在，请重新选择')</script>");
             return;
         }


         string sql6 = "insert into [ZhouJiHua](z_number,z_name,z_jihua ,z_mubiao,z_zhanbi,z_shishiqingkuang,z_jieguo,z_statue,z_time,id)values(@z_number,@z_name,@z_jihua ,@z_mubiao,@z_zhanbi,@z_shishiqingkuang,@z_jieguo,@z_statue,@z_time,@id)";
         SqlParameter[] sps6 = new SqlParameter[10];
         sps6[0] = new SqlParameter("@z_number", Session["number"]);
         sps6[1] = new SqlParameter("@z_name", Session["name"]);
         sps6[2] = new SqlParameter("@z_jihua ", z_jihua.Text);
         sps6[3] = new SqlParameter("@z_mubiao ", z_mubiao.Text);
         sps6[4] = new SqlParameter("@z_zhanbi ", z_zhanbi.Text);
         sps6[5] = new SqlParameter("@z_shishiqingkuang ", z_shishiqingkuang.Text);
         sps6[6] = new SqlParameter("@z_jieguo", z_jieguo.Text);
         sps6[7] = new SqlParameter("@z_statue", "0");
         sps6[8] = new SqlParameter("@z_time", z_time.Text);
         sps6[9] = new SqlParameter("@id", DateTime.Now.ToString("yyyyMMddhhmmss"));
         int i = SqlHelper.ExecuteNonQuery(sql6, sps6);

         /* if (i > 0)
          {
           
              Response.Redirect("ShenQingShenBao.aspx");
          }
          */
         string sql7 = "insert into [ShenQingShenBao](s_number,s_name,s_time,s_leibie,s_statue,id)values(@s_number,@s_name,@s_time ,@s_leibie,@s_statue,@id)";
         SqlParameter[] sps7 = new SqlParameter[6];
         sps7[0] = new SqlParameter("@s_number", Session["number"]);
         sps7[1] = new SqlParameter("@s_name", Session["name"]);
         sps7[2] = new SqlParameter("@s_time", r_time.Text);
         sps7[3] = new SqlParameter("@s_leibie ", "周计划");
         sps7[4] = new SqlParameter("@s_statue", "0");
         sps7[5] = new SqlParameter("@id", DateTime.Now.ToString("yyyyMMddhhmmss"));
         int j = SqlHelper.ExecuteNonQuery(sql7, sps7);

         if (j > 0)
         {

             Response.Redirect("ShenQingShenBao.aspx");
         }

       //  Response.Write("<script>alert('添加成功');window.location='information.aspx';</script>");
         /*  if (i > 0)
           {
               gvShow.DataBind();
               GridViewDataBind();
               Response.Redirect("KaoHe.aspx");
           }
           Response.Write("<script>alert('添加成功');window.location='information.aspx';</script>")
       */
     } 




    protected void Btnri_Click(object sender, EventArgs e)  //日计划
    {
        
        if (Session["number"] == null)
        {
            Response.Write("<script>alert('登录时间过期，请重新登录');window.location='../login.aspx';</script>");
            return;
        }
        String sql1 = "SELECT * FROM [RiJiHua] where r_time='" + r_time.Text + "' and r_number='" + Session["number"] + "'";
        DataTable dt_allgongzuori = SqlHelper.ExecuteDataTable(sql1);
        int i_all = dt_allgongzuori.Rows.Count;

        if (i_all > 0) //在数据表[RiJiHua]中查找 k_time='" + r_time.Text + "' and k_number='" + Session["number"] + "'"（该用户日历选择的时间下） 的记录是否存在，如果已经有记录就返回。
        {

            ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('该日期已经存在，请重新选择')</script>");
            return;
        }


        string sql4 = "insert into [RiJiHua](r_number,r_name,r_jihua ,r_mubiao,r_gongshi,r_neirong,r_jieguo,r_pingyu,r_defen,r_statue,r_time,id)values(@r_number,@r_name,@r_jihua ,@r_mubiao,@r_gongshi,@r_neirong,@r_jieguo,@r_pingyu,@r_defen,@r_statue,@r_time,@id)";
        SqlParameter[] sps4 = new SqlParameter[12];
        sps4[0] = new SqlParameter("@r_number", Session["number"]);
        sps4[1] = new SqlParameter("@r_name", Session["name"]);
        sps4[2] = new SqlParameter("@r_jihua ", r_jihua.Text);
        sps4[3] = new SqlParameter("@r_mubiao ", r_mubiao.Text);
        sps4[4] = new SqlParameter("@r_gongshi ", r_gongshi.Text);
        sps4[5] = new SqlParameter("@r_neirong ", r_neirong.Text);
        sps4[6] = new SqlParameter("@r_jieguo", r_jieguo.Text);
        sps4[7] = new SqlParameter("@r_pingyu", "");
        sps4[8] = new SqlParameter("@r_defen", "");
        sps4[9] = new SqlParameter("@r_statue", "0");
        sps4[10] = new SqlParameter("@r_time", r_time.Text);
        sps4[11] = new SqlParameter("@id", DateTime.Now.ToString("yyyyMMddhhmmss"));
        int i = SqlHelper.ExecuteNonQuery(sql4, sps4);

       /* if (i > 0)
        {
           
            Response.Redirect("ShenQingShenBao.aspx");
        }
        */
        string sql5 = "insert into [ShenQingShenBao](s_number,s_name,s_time,s_leibie,s_statue,id)values(@s_number,@s_name,@s_time ,@s_leibie,@s_statue,@id)";
        SqlParameter[] sps5 = new SqlParameter[6];
        sps5[0] = new SqlParameter("@s_number", Session["number"]);
        sps5[1] = new SqlParameter("@s_name", Session["name"]);
        sps5[2] = new SqlParameter("@s_time", r_time.Text);
        sps5[3] = new SqlParameter("@s_leibie ", "日计划");
        sps5[4] = new SqlParameter("@s_statue", "0");
        sps5[5] = new SqlParameter("@id", DateTime.Now.ToString("yyyyMMddhhmmss"));
        int j = SqlHelper.ExecuteNonQuery(sql5, sps5);

       if (j > 0)
        {

            Response.Redirect("ShenQingShenBao.aspx");
        }

      //  Response.Write("<script>alert('添加成功');window.location='information.aspx';</script>");
      /*  if (i > 0)
        {
            gvShow.DataBind();
            GridViewDataBind();
            Response.Redirect("KaoHe.aspx");
        }
        Response.Write("<script>alert('添加成功');window.location='information.aspx';</script>")
    */
    }

    protected void Btnshenqing_Click(object sender, EventArgs e)   //请假
    {
    
        //  System.Diagnostics.Debug.Write("q="+q.ToString()); //打印调试信息
      
        string strtime1 = startdate.Text + " " + time11_d1.SelectedItem.Text + ":" + time11_d2.SelectedItem.Text;
        string strtime2 = enddate.Text + " " + time12_d1.SelectedItem.Text + ":" + time12_d2.SelectedItem.Text;
        DateTime time1 = Convert.ToDateTime(strtime1);
        DateTime time2 = Convert.ToDateTime(strtime2);
        DateTime time4 = Convert.ToDateTime(startdate.Text);
        DateTime time5 = Convert.ToDateTime(enddate.Text);
        string strtime4 = time4.ToString("yyyy-MM");
        string strtime5 = time5.ToString("yyyy-MM");
        if (strtime4 != strtime5)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('开始时间和结束时间不在同一个月，请分开填写')</script>");

            return;
        }
        string shixiang = ddl_shixiang.SelectedItem.Text;
        if ((shixiang == "事假" || shixiang == "临时假" || shixiang == "病假" || shixiang == "年假" || shixiang == "加班") && tianall.Text == "")
        {
            ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('申请天数不能为空')</script>");

            return;

        }
        string typestr = tianall.Text;
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
            ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('申请天数(小时)大于0')</script>");

            return;
        }

        //if (shixiang == "加班")
        //{
        //    //读取工作日
        //    string sql_allgongzuori = "select * from [gongzuori]";
        //    DataTable dt_allgongzuori = SqlHelper.ExecuteDataTable(sql_allgongzuori);
        //    string strendti = startdate.Text;
        //    string[] sArray = strendti.Split('-');
        //    string nianfen = sArray[0] + "-" + sArray[1];

        //    DateTime t = Convert.ToDateTime(strendti); ;
        //    //SqlHelper.Close();
        //    string getnianfen = "";
        //    DataRow[] dr_allgongzuori = dt_allgongzuori.Select("YearMon='" + nianfen + "'");
        //    if (dr_allgongzuori.Length > 0)
        //    {

        //        getnianfen = dr_allgongzuori[0]["gongzuodate"].ToString();


        //        getnianfen = getnianfen.Replace("\n", string.Empty).Replace("\r", string.Empty);


        //        string[] str_getnianfen = getnianfen.Split(',');
        //        foreach (string _s in str_getnianfen)
        //        {
        //            if (strendti == _s)
        //            {


        //                ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('加班申请只申请非工作日加班的情况,工作日加班根据下班时间自动计算餐补和车补')</script>");
        //                return;

        //            }
        //        }
        //    }

        //}
        if (time1 > time2)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('开始时间大于结束时间，请重新选择')</script>");

            return;
        }
        else
        {
           
    /*       if(q==0)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('请确认天数/小时数填写正确：请假(按天计算)、加班(按小时计算)必填,填写数值,如0.5')</script>");
                q = 1;
                return ;
            }
        
*/
            string sql8 = "insert into [qingjia](q_number,q_name,q_startdate,q_enddate,q_things,q_shixiang,q_statue,q_all,id,q_time)values(@c_number,@c_name,@c_startdate,@c_enddate,@c_things,@q_shixiang,@q_statue,@q_all,@id,@q_time)";
            SqlParameter[] sps8 = new SqlParameter[10];
            sps8[0] = new SqlParameter("@c_number", Session["number"]);
            sps8[1] = new SqlParameter("@c_name", Session["name"]);
            sps8[2] = new SqlParameter("@c_startdate", strtime1);
            sps8[3] = new SqlParameter("@c_enddate", strtime2);
            sps8[4] = new SqlParameter("@c_things", thing.Text);
            sps8[5] = new SqlParameter("@q_shixiang", ddl_shixiang.SelectedItem.Text);
            sps8[6] = new SqlParameter("@q_statue", "3");
            sps8[7] = new SqlParameter("@q_all", tianall.Text);
            sps8[8] = new SqlParameter("@id", DateTime.Now.ToString("yyyyMMddhhmmss"));
            sps8[9] = new SqlParameter("@q_time", DateTime.Now.ToString("yyyy-MM-dd"));



            int i = SqlHelper.ExecuteNonQuery(sql8, sps8);


         /*   if (i > 0)
            {
               // gvShow.DataBind();
               // GridViewDataBind();
                Response.Redirect("ShenQingShenBao.aspx");
            }*/
            //Response.Write("<script>alert('添加成功');window.location='information.aspx';</script>")

           // System.DateTime newDate = new DateTime(int.Parse(year), int.Parse(month), int.Parse(sec));
            string sql9 = "insert into [ShenQingShenBao](s_number,s_name,s_time,s_leibie,s_statue,id)values(@s_number,@s_name,@s_time ,@s_leibie,@s_statue,@id)";
            SqlParameter[] sps9 = new SqlParameter[6];
            sps9[0] = new SqlParameter("@s_number", Session["number"]);
            sps9[1] = new SqlParameter("@s_name", Session["name"]);
            sps9[2] = new SqlParameter("@s_time", DateTime.Now.ToString("yyyy-MM-dd"));
            sps9[3] = new SqlParameter("@s_leibie ", "请假");
            sps9[4] = new SqlParameter("@s_statue", "0");
           // sps9[5] = new SqlParameter("@id", DateTime.Now.ToString("yyyyMMddhhmmss"));
            //  sps9[5] = new SqlParameter("@id", DateTime.Now.ToString("hhmmss"));
            //sps9[5] = new SqlParameter("@id", DateTime.Now.ToString("yyyy-MM-dd"));
            sps9[5] = new SqlParameter("@id", DateTime.Now.ToString("yyyyMMddhhmmss"));
            int j = SqlHelper.ExecuteNonQuery(sql9, sps9);

            if (j > 0)
            {

                Response.Redirect("ShenQingShenBao.aspx");
            }

        }
    }




    protected void Btn_shangchuan_Click(object sender, EventArgs e)
    {
        bool fileIsValid = false;
        
        if(this.FileUpload1.HasFile)
        {
            String fileExtension = System.IO.Path.GetExtension(this.FileUpload1.FileName).ToLower();
            String[] restrictExtension = { ".gif",".jpg",".bmp",".png"};
            for(int i=0; i < restrictExtension.Length;i++)
            {
                if(fileExtension == restrictExtension[i])
                {
                    fileIsValid = true;
                }
            }

            if(fileIsValid == true)
            {
                try
                {
                  //  this.Image1.ImageUrl = "~/images/" + FileUpload1.FileName;
                    this.FileUpload1.SaveAs(Server.MapPath("~/images/") + FileUpload1.FileName); //文件保存的路径 D:\1\考勤系统相关\考勤系统v2.0(未完成)\考勤网站\images
                    this.Label1.Text = "文件上传成功";
                /*
                    this.Label1.Text += "<Br/>";
                    this.Label1.Text += "<li>" + "原文件路径：" + this.FileUpload1.PostedFile.FileName;
                    this.Label1.Text += "<Br/>";
                    this.Label1 .Text += "<li>" +"文件大小：" + this.FileUpload1.PostedFile.ContentLength+"字节";
                    this.Label1.Text += "<Br/>";
                    this.Label1.Text += "<li>" + "文件类型：" + this.FileUpload1.PostedFile.ContentType;
                 */
                }
                catch(Exception ex)
                {
                    this.Label1.Text = "无法上传文件" + ex.Message;
                }
            }
            else
            {
                this.Label1.Text = "只能够上传后缀为.gif, .jpg, .bmp, .png的文件夹";
            }
        }
    }

   
}

