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

using System.Web.Security;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.IO;
using System.Text;
using System.Web.Configuration;



public partial class user_KaoHe : System.Web.UI.Page
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
            
          
           
            tb_nian.Text = DateTime.Now.Year.ToString();
            DateTime dt_firte = DateTime.Now;
            //本月第一天时间   
            DateTime dt_First = dt_firte.AddDays(-(dt_firte.Day) + 1);
            startime.Text = dt_First.ToString("yyyy-MM-dd");
            endtime.Text = DateTime.Now.ToString("yyyy-MM-dd");
            Calendar1.Visible = false;
            Calendar2.Visible = false;
            GridViewDataBind_zhou();
                GridViewDataBind_ri();
            GridViewDataBind_qing();
        }
        gvShow_zhou.Style.Add("table-layout", "fixed");
    }
    public string getweek(string dt)
    {
        string week="";
        
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
/*
    protected void Calendar1_SelectionChanged(object sender, EventArgs e)
    {
        startdate.Text = Calendar1.SelectedDate.ToString();
        if (!(startdate.Text == ""))
        {
            Calendar1.Visible = false;
           
         
            startdate.Text = Calendar1.SelectedDate.ToString("yyyy-MM-dd");
            
            //System.DateTime newDate = new DateTime();
            //Response.Write(newDate.DayOfWeek);
        }
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        Calendar1.Visible = true;

    }
 */
    /// 绑定数据
    /// </summary>
    /// 

    public void GridViewDataBind_zhou()
    {

        string timestr1 = "", timestr3 = "", timestr2 = "";
        timestr1 = startime.Text;
        timestr2 = endtime.Text;
        DateTime time1 = Convert.ToDateTime(timestr1);
        DateTime time2 = Convert.ToDateTime(timestr2);
        DateTime sunday = time1.AddDays(Convert.ToDouble((0 - Convert.ToInt16(time1.DayOfWeek)))); //得到一周的第一天是yyyy/MM/dd，第一天从周日开始
        timestr3 = sunday.AddDays(1).ToString("yyyy-MM-dd");//得到一周的周一是yyyy-MM-dd
      
      

        System.TimeSpan ND = time2 - time1;
        int n = ND.Days;   //天数差
        if (time1 > time2)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('开始时间大于结束时间，请重新选择')</script>");
            return;
        }
        else
        {
            if (n > 31)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('只能查询31天以内的记录，请重新选择')</script>");
                return;

            }
        }
    
      string sql = "SELECT * FROM [userinfo] WHERE number ='" + Session["number"] + "'";
        DataTable dt = SqlHelper.ExecuteDataTable(sql);
        int i_all = dt.Rows.Count;
        for (int i = 0; i < i_all; i++)
        {
            TextBox1.Text = dt.Rows[i]["name"].ToString();
            TextBox2.Text = dt.Rows[i]["number"].ToString();
            TextBox3.Text = dt.Rows[i]["jibie"].ToString();
            TextBox4.Text = dt.Rows[i]["bumen"].ToString();
            TextBox6.Text = dt.Rows[i]["ruzhi"].ToString();
            string a= dt.Rows[i]["shangji"].ToString();
            string sql_name = "SELECT * FROM [userinfo] WHERE number ='"+a+"'";
            DataTable dt2 = SqlHelper.ExecuteDataTable(sql_name);
            int i_all2 = dt2.Rows.Count;
            if (i_all2 > 0)
            {
                TextBox5.Text = dt2.Rows[0]["name"].ToString();
            
            }
          
        }
        string sql2 = "select * from [ZhouJiHua] where z_number='" + Session["number"] + "' and z_time>='" + timestr3 + "' and z_time<='" + timestr2 + "' order by z_time desc";
        DataSet ds2 = SqlHelper.ExecuteDataSet(sql2);
       
       Session["Table"] = ds2.Tables[0];
       
        gvShow_zhou.DataSource = ds2;
        gvShow_zhou.DataBind();

        foreach (GridViewRow row in gvShow_zhou.Rows)
        {
            string gettime = row.Cells[0].Text;
             string[] s_th1 = gettime.Split('-');
           int i = 0;
           string  year="", month="", sec="";
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
           System.Diagnostics.Debug.Write("newDate=" + newDate.ToString());
           row.Cells[0].Text += " "+getweek(newDate.DayOfWeek.ToString());
           LinkButton lb = row.Cells[7].FindControl("lbEdit_zhou") as LinkButton;
           LinkButton lt = row.Cells[8].FindControl("lbDelete_zhou") as LinkButton;
            string str = row.Cells[6].Text;

        
            if (str == "1" )
            {
                lb.Visible = false;
                lt.Visible = false;

                row.Cells[6].Text = "已批阅";
               
            }
            else
            {
              
                lb.Visible = true;
                lt.Visible = true;
                row.Cells[6].Text = "未批阅";
            }
        }


    }



    public void GridViewDataBind_ri()
    {
        string timestr1 = "", timestr2 = "";
        timestr1 = startime.Text;
        timestr2 = endtime.Text;
       DateTime time1 = Convert.ToDateTime(timestr1);
        DateTime time2 = Convert.ToDateTime(timestr2);
        System.TimeSpan ND = time2 - time1;
        int n = ND.Days;   //天数差
        if (time1 > time2)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('开始时间大于结束时间，请重新选择')</script>");
            return;
        }
        else
        {
            if (n > 31)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('只能查询31天以内的记录，请重新选择')</script>");
                return;

            }
        }
      

        string sql4 = "select * from [RiJiHua] where r_number='" + Session["number"] + "' and r_time>='" + timestr1 + "' and r_time<='" + timestr2 + "' order by r_time desc";
        DataSet ds4 = SqlHelper.ExecuteDataSet(sql4);
        Session["Table"] = ds4.Tables[0];
        gvShow_ri.DataSource = ds4;
        gvShow_ri.DataBind();

        foreach (GridViewRow row in gvShow_ri.Rows)
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
           // System.Diagnostics.Debug.Write("newDate=" + newDate.ToString());
            row.Cells[0].Text += " " + getweek(newDate.DayOfWeek.ToString());
            LinkButton lb = row.Cells[7].FindControl("lbEdit_ri") as LinkButton;
            LinkButton lt = row.Cells[8].FindControl("lbDelete_ri") as LinkButton;
            string str = row.Cells[6].Text;

            lb.Visible = false;
            lt.Visible = false;
            if (str == "1")
            {
                lb.Visible = false;
                lt.Visible = false;

                row.Cells[6].Text = "已批阅";

            }
            else
            {

                lb.Visible = true;
                lt.Visible = true;
                row.Cells[6].Text = "未批阅";
            }
            
        }


    }



    public void GridViewDataBind_qing()
    {

        string timestr1 = "", timestr2 = "";
        timestr1 = startime.Text;
        timestr2 = endtime.Text;


        string sql6 = "select * from [qingjia] where q_number='" + Session["number"] + "' and q_time>='" + timestr1 + "' and q_time<='" + timestr2 + "' order by q_time desc";
        DataSet ds6 = SqlHelper.ExecuteDataSet(sql6);
        Session["Table"] = ds6.Tables[0];
        gvShow_qing.DataSource = ds6;
        gvShow_qing.DataBind();

        foreach (GridViewRow row in gvShow_qing.Rows)
        {
            string gettime = row.Cells[1].Text;
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
           // System.Diagnostics.Debug.Write("newDate=" + newDate.ToString());
            row.Cells[1].Text += " " + getweek(newDate.DayOfWeek.ToString());
            LinkButton ChaKan = row.Cells[6].FindControl("lbChaKan") as LinkButton;
            LinkButton lb = row.Cells[8].FindControl("lbEdit_qing") as LinkButton;
            LinkButton lt = row.Cells[9].FindControl("lbDelete_qing") as LinkButton;

          

            ChaKan.Visible = false;
            string opervalue = row.Cells[0].Text;
            System.Diagnostics.Debug.Write("opervalue =" + opervalue);
            //System.Diagnostics.Debug.Assert(false, opervalue);//打印调试信息
          String sql10 = "SELECT ImageUrl FROM [qingjia] where id='" + opervalue + "'";
            //             System.Diagnostics.Debug.Assert(false, sql10);//打印调试信息
            DataTable dt_Url = SqlHelper.ExecuteDataTable(sql10);
            int i_all = dt_Url.Rows.Count;
          //  string Url = dt_Url.Rows[0][0].ToString();
           // System.Diagnostics.Debug.Write("dt_Url =" + Url);
            if (dt_Url.Rows[0][0].ToString() != "") //判断读到的ImageUrl不为空时，出现查看凭证按钮
            {
                ChaKan.Visible = true;
            }

            string str = row.Cells[8].Text;
            if (str == "1")
            {


                row.Cells[8].Text = "上级已同意";

            }
            else if (str == "2")
            {


                row.Cells[8].Text = "重新修改";

            }
            else if (str == "3")
            {


                row.Cells[8].Text = "不同意";

            }
            else if (str == "4")
            {


                row.Cells[8].Text = "已批准";

            }
            else
            {


                row.Cells[8].Text = "未批阅";
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
    protected void gvShow_zhou_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvShow_zhou.PageIndex = e.NewPageIndex;
        GridViewDataBind_zhou();
    }
    protected void gvShow_ri_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
       gvShow_ri.PageIndex = e.NewPageIndex;
        GridViewDataBind_ri();
    }

    protected void gvShow_qing_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvShow_qing.PageIndex = e.NewPageIndex;
        GridViewDataBind_qing();
    }
  
    /// <summary>
    /// 显示高亮效果
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvShow_zhou_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes.Add("onmouseover", "currentcolor=this.style.backgroundColor;this.style.backgroundColor='lightblue'");
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=currentcolor");


            LinkButton btn = e.Row.FindControl("lbDelete_zhou") as LinkButton;
            btn.Attributes.Add("onclick", "return confirm('确定要删除该工作记录吗？')");


        }
    }

    protected void gvShow_ri_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes.Add("onmouseover", "currentcolor=this.style.backgroundColor;this.style.backgroundColor='lightblue'");
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=currentcolor");


            LinkButton btn = e.Row.FindControl("lbDelete_ri") as LinkButton;
            btn.Attributes.Add("onclick", "return confirm('确定要删除该工作记录吗？')");


        }
    }

    protected void gvShow_qing_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes.Add("onmouseover", "currentcolor=this.style.backgroundColor;this.style.backgroundColor='lightblue'");
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=currentcolor");


            LinkButton btn = e.Row.FindControl("lbDelete_qing") as LinkButton;
            btn.Attributes.Add("onclick", "return confirm('确定要删除该工作记录吗？')");
        }
    }

    /// <summary>
    /// 单击某行的操作时
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvShow_zhou_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        string opername = e.CommandName;
        string opervalue = e.CommandArgument.ToString();
        if (opername == "Delete")
        {

            string sql3 = "delete from [ZhouJiHua] where id=@id";
            SqlParameter[] sps3 = new SqlParameter[] { 
           // new SqlParameter("@id", Convert.ToInt32(opervalue)),
           new SqlParameter("@id", opervalue),
            };

            int result_zhou = SqlHelper.ExecuteNonQuery(sql3, sps3);

            string sql11 = "delete from [ShenQingShenBao] where id=@id";
            SqlParameter[] sps11 = new SqlParameter[] { 
           // new SqlParameter("@id", Convert.ToInt32(opervalue)),
           new SqlParameter("@id", opervalue),
            };

            int result_sheng = SqlHelper.ExecuteNonQuery(sql11, sps11);

            if (result_zhou > 0 && result_sheng > 0)
                Response.Redirect("KaoHe.aspx");
            else if (result_sheng > 0 && result_zhou == 0)
            {
                while (result_zhou == 0)
                {
                    string sql12 = "delete from [ZhouJiHua] where id=@id";
                    SqlParameter[] sps12 = new SqlParameter[] { 
                              new SqlParameter("@id", opervalue),
                                };
                    result_zhou = SqlHelper.ExecuteNonQuery(sql12, sps12);
                }
            }
            else if (result_sheng == 0 && result_zhou > 0)
            {
                while (result_sheng == 0)
                {
                    string sql13 = "delete from [ShenQingShenBao] where id=@id";
                    SqlParameter[] sps13 = new SqlParameter[] { 
                     
                                 new SqlParameter("@id", opervalue),
                                 };
                    result_sheng = SqlHelper.ExecuteNonQuery(sql13, sps13);
                }
            }
        }
        else if (opername == "Edit")
            Response.Redirect("edit_ShenQingShenBao_ZhouJiHua.aspx?operfun=edit&operid=" + opervalue);

    }

     protected void gvShow_ri_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        string opername = e.CommandName;
        string opervalue = e.CommandArgument.ToString();
        if (opername == "Delete")
        {

            string sql5 = "delete from [RiJiHua] where id=@id";
            SqlParameter[] sps5 = new SqlParameter[] { 
           // new SqlParameter("@id", Convert.ToInt32(opervalue)),
           new SqlParameter("@id", opervalue),
            };

            int result_ri = SqlHelper.ExecuteNonQuery(sql5, sps5);

            string sql14 = "delete from [ShenQingShenBao] where id=@id";
            SqlParameter[] sps14 = new SqlParameter[] { 
           // new SqlParameter("@id", Convert.ToInt32(opervalue)),
           new SqlParameter("@id", opervalue),
            };

            int result_sheng = SqlHelper.ExecuteNonQuery(sql14, sps14);

            if (result_ri > 0 && result_sheng > 0)
                Response.Redirect("KaoHe.aspx");
            else if (result_sheng > 0 && result_ri == 0)
            {
                while (result_ri == 0)
                {
                    string sql15 = "delete from [RiJiHua] where id=@id";
                    SqlParameter[] sps15 = new SqlParameter[] { 
                              new SqlParameter("@id", opervalue),
                                };
                    result_ri = SqlHelper.ExecuteNonQuery(sql15, sps15);
                }

            }
            else if (result_sheng == 0 && result_ri > 0)
            {
                while (result_sheng == 0)
                {
                    string sql16 = "delete from [ShenQingShenBao] where id=@id";
                    SqlParameter[] sps16 = new SqlParameter[] { 
                     
                                new SqlParameter("@id", opervalue),
                                 };
                    result_sheng = SqlHelper.ExecuteNonQuery(sql16, sps16);
                }
            }
        }
        else if (opername == "Edit")
           Response.Redirect("edit_ShenQingShenBao_RiJiHua.aspx?operfun=edit&operid=" + opervalue);
        //    Response.Redirect("~/images/QQ图片20200107153621.png?operfun=edit&operid=" + opervalue);
         
    }

     protected void gvShow_qing_RowCommand(object sender, GridViewCommandEventArgs e)
     {
         string opername = e.CommandName;
         string opervalue = e.CommandArgument.ToString();
         string operUrl = null;
        

             if (opername == "Delete")
             {

                 string sql7 = "delete from [qingjia] where id=@id";
                 SqlParameter[] sps7 = new SqlParameter[] { 
           // new SqlParameter("@id", Convert.ToInt32(opervalue)),
           new SqlParameter("@id", opervalue),
            };

                 int result_qingjia = SqlHelper.ExecuteNonQuery(sql7, sps7);

                 string sql17 = "delete from [ShenQingShenBao] where id=@id";
                 SqlParameter[] sps17 = new SqlParameter[] { 
           // new SqlParameter("@id", Convert.ToInt32(opervalue)),
           new SqlParameter("@id", opervalue),
            };

                 int result_sheng = SqlHelper.ExecuteNonQuery(sql17, sps17);
                 if (result_qingjia > 0 && result_sheng > 0)
                     Response.Redirect("KaoHe.aspx");
                 else if (result_sheng > 0 && result_qingjia == 0)
                 {
                     while (result_qingjia == 0)
                     {
                         string sql18 = "delete from [qingjia] where id=@id";
                         SqlParameter[] sps18 = new SqlParameter[] { 
                                new SqlParameter("@id", opervalue),
                                  };
                         result_qingjia = SqlHelper.ExecuteNonQuery(sql18, sps18);
                     }
                 }
                 else if (result_sheng == 0 && result_qingjia > 0)
                 {
                     while (result_sheng == 0)
                     {
                         string sql19 = "delete from [ShenQingShenBao] where id=@id";
                         SqlParameter[] sps19 = new SqlParameter[] { 
                     
                                 new SqlParameter("@id", opervalue),
                                };
                         result_sheng = SqlHelper.ExecuteNonQuery(sql19, sps19);
                     }
                 }
             }
             else if (opername == "Edit")
                 Response.Redirect("edit_ShenQingShenBao_qingjia.aspx?operfun=edit&operid=" + opervalue);
             else if (opername == "ChaKan")
             {
                 String sql10 = "SELECT ImageUrl FROM [qingjia] where id='" + opervalue + "'";
                 //             System.Diagnostics.Debug.Assert(false, sql10);//打印调试信息
                 DataTable dt_Url = SqlHelper.ExecuteDataTable(sql10);
                 int i_all = dt_Url.Rows.Count;

                 if (i_all > 0)
                 {
                     //ChaKan.Visible = true;


                     operUrl = dt_Url.Rows[0][0].ToString();
                     Response.Redirect("~/images/" + operUrl);
                 }
                 

                 //Response.Redirect("~/images/QQ图片20200107153621.png?operfun=edit&operid=" + opervalue);
                 //  Response.Redirect("<script>window.open('~/images/QQ图片20200107153621.png','_blank')</script>");
                 //  Response.Write("<script>window.open('images/QQ图片20200107153621.png','_blank')</script>");
                 // Response.Write("<script>window.location='~/images/QQ图片20200107153621.png'</script>"); 路径有问题，暂时不采用打开新窗口
             }
         
     }

    /// <summary>
    /// 排序
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
 /*   protected void gvShow_zhou_Sorting(object sender, GridViewSortEventArgs e)
    {
        string timestr1 = "", timestr3 = "", timestr2 = "";
        timestr1 = startime.Text;
        timestr2 = endtime.Text;
        DateTime time1 = Convert.ToDateTime(timestr1);
        DateTime time2 = Convert.ToDateTime(timestr2);
        DateTime sunday = time1.AddDays(Convert.ToDouble((0 - Convert.ToInt16(time1.DayOfWeek)))); //得到一周的第一天是yyyy/MM/dd，第一天从周日开始
        timestr3 = sunday.AddDays(1).ToString("yyyy-MM-dd");//得到一周的周一是yyyy-MM-dd

        string sql2 = "select * from [ZhouJiHua] where z_number='" + Session["number"] + "' and z_time>='" + timestr3 + "' and z_time<='" + timestr2 + "' order by z_time desc";
        DataSet ds2 = SqlHelper.ExecuteDataSet(sql2);

        Session["Table"] = ds2.Tables[0];
       
      //  DataTable dtSource = GetData();
        //  System.Diagnostics.Debug.Assert(false, "Table");//打印调试信息
       // System.Diagnostics.Debug.Write("Table=" + Session["Table"].ToString());
       DataTable tb = Session["Table"] as DataTable;
      //  DataTable tb = [ZhouJiHua] as DataTable;
       // DataTable tb = GetData().Tables[0];
        tb.DefaultView.Sort = e.SortExpression;
        gvShow_zhou.DataSource = tb;
        gvShow_zhou.DataBind();
    }
*/


     public SortDirection GridViewSortDirection_zhou
     {

         get
         {

             if (ViewState["sortDirection"] == null)

                 ViewState["sortDirection"] = SortDirection.Ascending;

             return (SortDirection)ViewState["sortDirection"];

         }

         set { ViewState["sortDirection"] = value; }

     }

     protected void gvShow_zhou_Sorting(object sender, GridViewSortEventArgs e)
     {
         // DataTable tb = Session["Table"] as DataTable;
         // tb.DefaultView.Sort = e.SortExpression;

         string sortExpression = e.SortExpression;
         if (GridViewSortDirection_zhou == SortDirection.Ascending)
         {

             GridViewSortDirection_zhou = SortDirection.Descending;
             SortGridView_zhou(sortExpression, " DESC");
         }
         else
         {

             GridViewSortDirection_zhou = SortDirection.Ascending;

             SortGridView_zhou(sortExpression, " ASC");

         }
         //  gvShow.DataSource = tb;
         //  gvShow.DataBind();
     }

     private void SortGridView_zhou(string sortExpression, string direction)
     {
         string timestr1 = "", timestr2 = "", timestr3 = "";
         timestr1 = startime.Text;
         timestr2 = endtime.Text;
         DateTime time1 = Convert.ToDateTime(timestr1);
         DateTime time2 = Convert.ToDateTime(timestr2);

         DateTime sunday = time1.AddDays(Convert.ToDouble((0 - Convert.ToInt16(time1.DayOfWeek)))); //得到一周的第一天是yyyy/MM/dd，第一天从周日开始
         timestr3 = sunday.AddDays(1).ToString("yyyy-MM-dd");//得到一周的周一是yyyy-MM-dd
         
       
         string sql2 = "select * from [ZhouJiHua] where z_number='" + Session["number"] + "' and z_time>='" + timestr3 + "' and z_time<='" + timestr2 + "' order by z_time desc";

         DataSet ds2 = SqlHelper.ExecuteDataSet(sql2);

         ds2 = SqlHelper.ExecuteDataSet(sql2);
         Session["Table"] = ds2.Tables[0];


         System.Diagnostics.Debug.Write("Table=" + Session["Table"].ToString());
         DataTable tb = Session["Table"] as DataTable;

         tb.DefaultView.Sort = sortExpression + direction;

         gvShow_zhou.DataSource = tb;
         gvShow_zhou.DataBind();

     }

/*
    protected void gvShow_ri_Sorting(object sender, GridViewSortEventArgs e)
    {
        string timestr1 = "", timestr2 = "";
        timestr1 = startime.Text;
        timestr2 = endtime.Text;
        string sql4 = "select * from [RiJiHua] where r_number='" + Session["number"] + "' and r_time>='" + timestr1 + "' and r_time<='" + timestr2 + "' order by r_time desc";
        DataSet ds4 = SqlHelper.ExecuteDataSet(sql4);
        Session["Table"] = ds4.Tables[0];


        DataTable tb = Session["Table"] as DataTable;
        tb.DefaultView.Sort = e.SortExpression;
        gvShow_ri.DataSource = tb;
        gvShow_ri.DataBind();
    }
*/

     public SortDirection GridViewSortDirection_ri
     {

         get
         {

             if (ViewState["sortDirection"] == null)

                 ViewState["sortDirection"] = SortDirection.Ascending;

             return (SortDirection)ViewState["sortDirection"];

         }

         set { ViewState["sortDirection"] = value; }

     }

     protected void gvShow_ri_Sorting(object sender, GridViewSortEventArgs e)
     {
         // DataTable tb = Session["Table"] as DataTable;
         // tb.DefaultView.Sort = e.SortExpression;

         string sortExpression = e.SortExpression;
         if (GridViewSortDirection_ri == SortDirection.Ascending)
         {

             GridViewSortDirection_ri = SortDirection.Descending;
             SortGridView_ri(sortExpression, " DESC");
         }
         else
         {

             GridViewSortDirection_ri = SortDirection.Ascending;

             SortGridView_ri(sortExpression, " ASC");

         }
         //  gvShow.DataSource = tb;
         //  gvShow.DataBind();
     }

     private void SortGridView_ri(string sortExpression, string direction)
     {
         string timestr1 = "", timestr2 = "";
         timestr1 = startime.Text;
         timestr2 = endtime.Text;

         string sql2 = "select * from [RiJiHua] where r_number='" + Session["number"] + "' and r_time>='" + timestr1 + "' and r_time<='" + timestr2 + "' order by r_time desc";

         DataSet ds2 = SqlHelper.ExecuteDataSet(sql2);

         ds2 = SqlHelper.ExecuteDataSet(sql2);
         Session["Table"] = ds2.Tables[0];


         System.Diagnostics.Debug.Write("Table=" + Session["Table"].ToString());
         DataTable tb = Session["Table"] as DataTable;

         tb.DefaultView.Sort = sortExpression + direction;

         gvShow_ri.DataSource = tb;
         gvShow_ri.DataBind();

     }



/*
    protected void gvShow_qing_Sorting(object sender, GridViewSortEventArgs e)
    {
        DataTable tb = Session["Table"] as DataTable;
     //   System.Diagnostics.Debug.Write("Table=" + Session["Table"].ToString());
        tb.DefaultView.Sort = e.SortExpression;
        gvShow_qing.DataSource = tb;
        gvShow_qing.DataBind(); 
    }
  */

     public SortDirection GridViewSortDirection_qing
     {

         get
         {

             if (ViewState["sortDirection"] == null)

                 ViewState["sortDirection"] = SortDirection.Ascending;

             return (SortDirection)ViewState["sortDirection"];

         }

         set { ViewState["sortDirection"] = value; }

     }

     protected void gvShow_qing_Sorting(object sender, GridViewSortEventArgs e)
     {
         // DataTable tb = Session["Table"] as DataTable;
         // tb.DefaultView.Sort = e.SortExpression;

         string sortExpression = e.SortExpression;
         if (GridViewSortDirection_qing == SortDirection.Ascending)
         {

             GridViewSortDirection_qing = SortDirection.Descending;
             SortGridView_qing(sortExpression, " DESC");
         }
         else
         {

             GridViewSortDirection_qing = SortDirection.Ascending;

             SortGridView_qing(sortExpression, " ASC");

         }
         //  gvShow.DataSource = tb;
         //  gvShow.DataBind();
     }

     private void SortGridView_qing(string sortExpression, string direction)
     {
         string timestr1 = "", timestr2 = "";
         timestr1 = startime.Text;
         timestr2 = endtime.Text;
         DateTime time1 = Convert.ToDateTime(timestr1);
         DateTime time2 = Convert.ToDateTime(timestr2);



         string sql2 = "select * from [qingjia] where q_number='" + Session["number"] + "' and q_time>='" + timestr1 + "' and q_time<='" + timestr2 + "' order by q_time desc";
         DataSet ds2 = SqlHelper.ExecuteDataSet(sql2);

         ds2 = SqlHelper.ExecuteDataSet(sql2);
         Session["Table"] = ds2.Tables[0];


         System.Diagnostics.Debug.Write("Table=" + Session["Table"].ToString());
         DataTable tb = Session["Table"] as DataTable;

         tb.DefaultView.Sort = sortExpression + direction;

         gvShow_qing.DataSource = tb;
         gvShow_qing.DataBind();

     }



        protected void Button1_Click(object sender, EventArgs e)
        {
              GridViewDataBind_zhou();
              GridViewDataBind_ri();
              GridViewDataBind_qing();

        }
   
    protected void Button2_Click(object sender, EventArgs e)
    {
        string time = tb_nian.Text + "-" + tb_yue.SelectedItem.Text;
        int time2 = int.Parse(tb_yue.SelectedItem.Text)+1;     
        float fen=0;
        float in_fen = 0;
        string endtime;
        if (time2 < 10)
        {
            endtime = tb_nian.Text + "-" + "0" + time2.ToString();
        }
        else 
        {
            endtime = tb_nian.Text + "-"+ time2.ToString();
        }
        string sql_all = "select * from [RiJiHua] where r_time>'" + time + "' and r_time<'" + endtime + "' and r_number='" + Session["number"] + "' order by r_time ASC";
        DataTable dt_all = SqlHelper.ExecuteDataTable(sql_all);
        int i_all = dt_all.Rows.Count;
        for (int j_all = 0; j_all < i_all; j_all++)
        {
            if (dt_all.Rows[j_all]["r_defen"].ToString()!="")
            {
               in_fen = float.Parse(dt_all.Rows[j_all]["r_defen"].ToString());
               fen += in_fen;
            }
        
        }
        tb_all.Text = fen.ToString();
    }


    protected void Calendar1_SelectionChanged(object sender, EventArgs e)
    {
        startime.Text = Calendar1.SelectedDate.ToString();
        if (!(startime.Text == ""))
        {
            Calendar1.Visible = false;

            startime.Text = Calendar1.SelectedDate.ToString("yyyy-MM-dd");
        }
    }
    protected void Calendar2_SelectionChanged(object sender, EventArgs e)
    {
        endtime.Text = Calendar2.SelectedDate.ToString();
        if (!(endtime.Text == ""))
        {
            Calendar2.Visible = false;

            endtime.Text = Calendar2.SelectedDate.ToString("yyyy-MM-dd");
        }
    }
    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        Calendar2.Visible = true;
        Calendar1.Visible = false;
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        Calendar1.Visible = true;
        Calendar2.Visible = false;
    }
}

