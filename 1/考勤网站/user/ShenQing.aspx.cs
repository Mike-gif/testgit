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

public partial class user_ShenQing : System.Web.UI.Page
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
            Calendar2.Visible = false;
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
            startdate.Text = DateTime.Now.ToString("yyyy-MM-dd");
            enddate.Text = DateTime.Now.ToString("yyyy-MM-dd");
            time11_d1.Text = "09";
            time12_d1.Text = "18";
        }

    }

    protected void Calendar1_SelectionChanged(object sender, EventArgs e)
    {
        startdate.Text = Calendar1.SelectedDate.ToString();
        if (!(startdate.Text == ""))
        {
            Calendar1.Visible = false;

            startdate.Text = Calendar1.SelectedDate.ToString("yyyy-MM-dd");
        }
    }
    protected void Calendar2_SelectionChanged(object sender, EventArgs e)
    {
        enddate.Text = Calendar1.SelectedDate.ToString();
        if (!(enddate.Text == ""))
        {
            Calendar2.Visible = false;

            enddate.Text = Calendar2.SelectedDate.ToString("yyyy-MM-dd");
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
    /// 绑定数据
    /// </summary>
    /// 

    public void GridViewDataBind()
    {

        string sql2 = "select * from [qingjia] where q_number='" + Session["number"] + "'ORDER BY q_enddate DESC";
        DataSet ds2 = SqlHelper.ExecuteDataSet(sql2);
        Session["Table"] = ds2.Tables[0];
        gvShow.DataSource = ds2;
        gvShow.DataBind();

        foreach (GridViewRow row in gvShow.Rows)
        {
            LinkButton lb = row.Cells[7].FindControl("lbEdit") as LinkButton;
            LinkButton lt = row.Cells[8].FindControl("lbDelete") as LinkButton;
            string str = row.Cells[7].Text;
            if (str == "2" || str == "3")
            {

                lb.Visible = true;
                lt.Visible = true;
                if (str == "3")
                {
                    row.Cells[7].Text = "未审核";
                }
                else
                {
                    row.Cells[7].Text = "重新修改";
                }
            }
            else
            {
                lb.Visible = false;
                lt.Visible = false;
                if (str == "0")
                {
                    row.Cells[7].Text = "未通过审核";
                }
                else
                    if (str == "1")
                    {
                        row.Cells[7].Text = "通过审核";
                    }
                    else
                        if(str=="4")
                    {
                        row.Cells[7].Text = "已批准";

                    
                    }
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
            btn.Attributes.Add("onclick", "return confirm('确定要删除该申请记录吗？')");


        }
    }

    /// <summary>
    /// 单击某行的操作时
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvShow_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        string opername = e.CommandName;
        string opervalue = e.CommandArgument.ToString();
        if (opername == "Delete")
        {

            string sql2 = "delete from [qingjia] where Q_ID=@Q_ID";
            SqlParameter[] sps2 = new SqlParameter[] { 
            new SqlParameter("@Q_ID", Convert.ToInt32(opervalue)),
            };

            int result = SqlHelper.ExecuteNonQuery(sql2, sps2);
            if (result > 0)
                Response.Redirect("ShenQing.aspx");

        }
        else if (opername == "Edit")
            Response.Redirect("edit_ShenQing.aspx?operfun=edit&operid=" + Convert.ToInt32(opervalue));

    }

    /// <summary>
    /// 排序
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvShow_Sorting(object sender, GridViewSortEventArgs e)
    {
        DataTable tb = Session["Table"] as DataTable;
    //    System.Diagnostics.Debug.Write("Table=" + Session["Table"].ToString());
        tb.DefaultView.Sort = e.SortExpression;
        gvShow.DataSource = tb;
        gvShow.DataBind();
    }







    protected void Button1_Click(object sender, EventArgs e)
    {
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
        if (float.TryParse(typestr,out a) ==false&& typestr != "")
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
            string sql4 = "insert into [qingjia](q_number,q_name,q_startdate,q_enddate,q_things,q_shixiang,q_statue,q_all)values(@c_number,@c_name,@c_startdate,@c_enddate,@c_things,@q_shixiang,@q_statue,@q_all)";
            SqlParameter[] sps4 = new SqlParameter[8];
            sps4[0] = new SqlParameter("@c_number", Session["number"]);
            sps4[1] = new SqlParameter("@c_name", Session["name"]);
            sps4[2] = new SqlParameter("@c_startdate", strtime1);
            sps4[3] = new SqlParameter("@c_enddate", strtime2);
            sps4[4] = new SqlParameter("@c_things", thing.Text);
            sps4[5] = new SqlParameter("@q_shixiang", ddl_shixiang.SelectedItem.Text);
            sps4[6] = new SqlParameter("@q_statue", "3");
            sps4[7] = new SqlParameter("@q_all", tianall.Text);




            int i = SqlHelper.ExecuteNonQuery(sql4, sps4);


            if (i > 0)
            {
                gvShow.DataBind();
                GridViewDataBind();
                Response.Redirect("ShenQing.aspx");
            }
            //Response.Write("<script>alert('添加成功');window.location='information.aspx';</script>")

        }
    }
}

