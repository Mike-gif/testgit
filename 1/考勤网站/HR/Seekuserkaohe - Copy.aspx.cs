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

public partial class HR_Seekuserkaohe : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        { 
            Calendar1.Visible = false;
            Calendar2.Visible = false;
          
            string sql = "SELECT * FROM [userinfo] where zaizhi='在职'";
            DataTable dt = SqlHelper.ExecuteDataTable(sql);
            int i_all = dt.Rows.Count;

            for (int i = 0; i < i_all; i++)
            {
                DropDownList1.Items.Add(new ListItem(dt.Rows[i]["name"].ToString(), dt.Rows[i]["name"].ToString()));//增加Item
                
            }
         
                DateTime dt_firte = DateTime.Now;
                //本月第一天时间   
                DateTime dt_First = dt_firte.AddDays(-(dt_firte.Day) + 1);
                startime.Text = dt_First.ToString("yyyy-MM-dd");
                endtime.Text = DateTime.Now.ToString("yyyy-MM-dd");
                tb_nian.Text = DateTime.Now.Year.ToString();
        }

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
        endtime.Text = Calendar1.SelectedDate.ToString();
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
    public void GridViewDataBind()
    {
        string timestr1 = "", timestr2 = "";
        if (Session["name1"] != null)
        {
            timestr1 = Session["time1"].ToString();
            timestr2 = Session["time2"].ToString();


        }
        else
        {
            timestr1 = startime.Text;
            timestr2 = endtime.Text;

        }

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

        string sql2 = "select * from [kaohe] where k_name='" + DropDownList1.SelectedItem.Text+ "' and k_time>='" + timestr1 + "' and k_time<='" + timestr2 + "' order by k_time desc";
        DataSet ds2 = SqlHelper.ExecuteDataSet(sql2);
        Session["Table"] = ds2.Tables[0];
        gvShow.DataSource = ds2;
        gvShow.DataBind();

        foreach (GridViewRow row in gvShow.Rows)
        {

            string str = row.Cells[7].Text;


            if (str == "1")
            {
                row.Cells[7].Text = "已批阅";


            }
            else
            {
                row.Cells[7].Text = "未批阅";


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
        
            string name1 = Session["name1"].ToString();
            GridViewDataBind();
       
      
    }
    protected void gvShow1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvShow.PageIndex = e.NewPageIndex;

       // GridViewDataBind1();

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





        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        GridViewDataBind();
    }
    
    protected void bnt_defen_Click(object sender, EventArgs e)
    {
        kaohe_all();
    }
    public void kaohe_all()
    {

        TableHeaderRow thr = new TableHeaderRow();
        //构建表头
        string[] s_th = "员工编号,员工姓名,年月,总得分".Split(',');
        foreach (string _s in s_th)
        {
            TableHeaderCell thd = new TableHeaderCell();
            thd.Text = _s;
            thr.Cells.Add(thd);
        }

        tb_result.Rows.Add(thr);
        string time = tb_nian.Text + "-" + tb_yue.SelectedItem.Text;
        int time2 = int.Parse(tb_yue.SelectedItem.Text) + 1;

        float in_fen = 0;
        string endtime;
        if (time2 < 10)
        {
            endtime = tb_nian.Text + "-" + "0" + time2.ToString();
        }
        else
        {
            endtime = tb_nian.Text + "-" + time2.ToString();
        }
        //获取下级员工号
        string sql2 = "select * from [userinfo] where zaizhi='在职'";

        DataTable dt_number = SqlHelper.ExecuteDataTable(sql2);
        int i_number = dt_number.Rows.Count;
        if (i_number < 0 || i_number == 0)
        {
            dt_number = SqlHelper.ExecuteDataTable(sql2);
            i_number = dt_number.Rows.Count;

        }
        //获取考核数据
        string sql_all = "select * from [kaohe] where k_time>'" + time + "' and k_time<'" + endtime + "' order by k_time ASC";
        DataTable dt_all = SqlHelper.ExecuteDataTable(sql_all);

        string number = "", name = "";
        for (int j_number = 0; j_number < i_number; j_number++)
        {
            float fen = 0;
            number = dt_number.Rows[j_number]["number"].ToString();
            name = dt_number.Rows[j_number]["name"].ToString();
            TableRow trZ = new TableRow();
            TableCell tdZ1 = new TableCell();
            tdZ1.Text = number;
            trZ.Cells.Add(tdZ1);
            TableCell tdZ2 = new TableCell();
            tdZ2.Text = name;
            trZ.Cells.Add(tdZ2);
            TableCell tdZ3 = new TableCell();
            tdZ3.Text = time;
            trZ.Cells.Add(tdZ3);
            DataRow[] dr_allnumber = dt_all.Select("k_number='" + number + "'");
            int i_all = dr_allnumber.Length;
            for (int j_all = 0; j_all < i_all; j_all++)
            {
                string str = dr_allnumber[j_all]["k_defen"].ToString();
                // bool a = Double.TryParse(str,System.Globalization.NumberStyles ,out in_fen);

                if (dr_allnumber[j_all]["k_defen"].ToString() != "")
                {
                    in_fen = float.Parse(dr_allnumber[j_all]["k_defen"].ToString());
                    fen += in_fen;
                }


            }
            TableCell tdZ4 = new TableCell();
            tdZ4.Text = fen.ToString();
            trZ.Cells.Add(tdZ4);
            tb_result.Rows.Add(trZ);
        }

    }
}