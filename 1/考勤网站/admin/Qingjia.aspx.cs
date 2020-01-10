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
public partial class admin_Qingjia : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
       
        if (!Page.IsPostBack)
        {
            tb_nian.Text = DateTime.Now.Year.ToString();

        }

    }

    protected void bnt_defen_Click(object sender, EventArgs e)
    {
        qingjia_all();

    }
    public void qingjia_all()
    {

        TableHeaderRow thr = new TableHeaderRow();
        //构建表头
        string[] s_th = "员工编号,员工姓名,事假(天),临时假(天),年假(天),病假(天),累计申报加班(小时),考勤分(扣分)".Split(',');
        foreach (string _s in s_th)
        {
            TableHeaderCell thd = new TableHeaderCell();
            thd.Text = _s;
            thr.Cells.Add(thd);
        }
        tb_result.Rows.Add(thr);
        string  getnianxiu = "", getshijia = "", getlinshijia = "", getbingjia = "";//获取早上考勤时间，允许迟到时间，旷工时间,午休时间,下午下班时间,加班时间,迟到时间，早退时间，旷工时间
        String sql1 = "SELECT * FROM [KaoQinCanShu] where banci=@number";
        SqlParameter[] sps1 = new SqlParameter[]
                    {
                        new SqlParameter("@number",ddr_banci.SelectedItem.Text),
                    };
        using (SqlDataReader dr = SqlHelper.ExecuteReader(CommandType.Text, sql1, sps1))
        {

            if (dr.Read())
            {
                getnianxiu = dr.GetString(dr.GetOrdinal("nianxiu"));
                getshijia = dr.GetString(dr.GetOrdinal("shijia"));
                getlinshijia = dr.GetString(dr.GetOrdinal("linshijia"));
                getbingjia = dr.GetString(dr.GetOrdinal("bingjia"));
                

            }
            SqlHelper.Close();
        }
        string starttime = tb_nian.Text + "-" + tb_yue.SelectedItem.Text + "-01";
        string endtime = tb_nian.Text + "-" + tb_yue.SelectedItem.Text + "-32";
        //读取请假
        string sql_allqingjia = "select * from [qingjia] where q_startdate>='" + starttime + "' and q_enddate<='" + endtime + "' and q_statue='4'";
        DataTable dt_allqingjia = SqlHelper.ExecuteDataTable(sql_allqingjia);
        //读取员工信息
        String sql_all = "SELECT * FROM [userinfo] where zaizhi='在职' ";
        DataTable ds_all = SqlHelper.ExecuteDataTable(sql_all);
        int i_all = ds_all.Rows.Count;
        for (int j_all = 0; j_all < i_all; j_all++)
        {

            string all_number = "", all_name = "";

            all_number = ds_all.Rows[j_all]["number"].ToString();
            all_name = ds_all.Rows[j_all]["name"].ToString();
            TableRow trZ = new TableRow();
            TableCell tdZ1 = new TableCell();
            tdZ1.Text = all_number;
            trZ.Cells.Add(tdZ1);
            TableCell tdZ2 = new TableCell();
            tdZ2.Text = all_name;
            trZ.Cells.Add(tdZ2);
            //事假
            double defenall = 0;
            TableCell tdZ3= new TableCell();
            double intshijiaall=0;
            DataRow[] dr_allqingjia = dt_allqingjia.Select("q_number='" + all_number + "' and q_shixiang='事假'");
            if (dr_allqingjia.Length > 0)
            {
                for (int i = 0; i < dr_allqingjia.Length; i++)
                {
                    string qingjiaall = dr_allqingjia[i]["q_all"].ToString();

                    if (qingjiaall != "" && gettype(qingjiaall) == true)
                        {
                            intshijiaall += double.Parse(qingjiaall);
                            defenall += double.Parse(getshijia) * double.Parse(qingjiaall);
                        }
                }            
            }
            if (intshijiaall != 0)
            {
                tdZ3.Text = intshijiaall.ToString("f1");
                trZ.Cells.Add(tdZ3);
            }
            else {
                tdZ3.Text = " ";
                trZ.Cells.Add(tdZ3);
            }
            //临时假
           
            TableCell tdZ4 = new TableCell();
            double linshijiaall = 0;
            DataRow[] dr_alllinqingjia = dt_allqingjia.Select("q_number='" + all_number + "' and q_shixiang='临时假'");
            if (dr_alllinqingjia.Length > 0)
            {
                for (int i = 0; i < dr_alllinqingjia.Length; i++)
                {
                    string linqingjiaall = dr_alllinqingjia[i]["q_all"].ToString();
                    if (linqingjiaall != "" && gettype(linqingjiaall) == true)
                    {
                        linshijiaall += double.Parse(linqingjiaall);
                        defenall += double.Parse(getlinshijia) * double.Parse(linqingjiaall);
                    }
                }
            }
            if (linshijiaall != 0)
            {
                tdZ4.Text = linshijiaall.ToString("f1");
                trZ.Cells.Add(tdZ4);
            }
            else
            {
                tdZ4.Text = " ";
                trZ.Cells.Add(tdZ4);
            }
            //年假
            TableCell tdZ5 = new TableCell();
            double nianshijiaall = 0;
            DataRow[] dr_nianqingjia = dt_allqingjia.Select("q_number='" + all_number + "' and q_shixiang='年假'");
            if (dr_nianqingjia.Length > 0)
            {
                for (int i = 0; i < dr_nianqingjia.Length; i++)
                {
                    string linqingjiaall = dr_nianqingjia[i]["q_all"].ToString();
                    if (linqingjiaall != "" && gettype(linqingjiaall) == true)
                    {
                        nianshijiaall += double.Parse(linqingjiaall);

                        defenall += double.Parse(getnianxiu) * double.Parse(linqingjiaall);
                    }
                }
            }
            if (nianshijiaall != 0)
            {
                tdZ5.Text = nianshijiaall.ToString("f1");
                trZ.Cells.Add(tdZ5);
            }
            else
            {
                tdZ5.Text = " ";
                trZ.Cells.Add(tdZ5);
            }
           
            //病假
            TableCell tdZ6 = new TableCell();
            double bingshijiaall = 0;
            DataRow[] dr_bingingjia = dt_allqingjia.Select("q_number='" + all_number + "' and q_shixiang='病假'");
            if (dr_bingingjia.Length > 0)
            {
                for (int i = 0; i < dr_bingingjia.Length; i++)
                {
                    string bingqingjiaall = dr_bingingjia[i]["q_all"].ToString();
                    if (bingqingjiaall != "" && gettype(bingqingjiaall) == true)
                    {
                        bingshijiaall += double.Parse(bingqingjiaall);
                        defenall += double.Parse(getbingjia) * double.Parse(bingqingjiaall);
                    }
                }
            }
            if (bingshijiaall != 0)
            {
                tdZ6.Text = bingshijiaall.ToString("f1");
                trZ.Cells.Add(tdZ6);
            }
            else
            {
                tdZ6.Text = " ";
                trZ.Cells.Add(tdZ6);
            }
            //加班
            TableCell tdZ7 = new TableCell();
            double jiashijiaall = 0;
            DataRow[] jiaqingjia = dt_allqingjia.Select("q_number='" + all_number + "' and q_shixiang='加班'");
            if (jiaqingjia.Length > 0)
            {
                for (int i = 0; i < jiaqingjia.Length; i++)
                {
                    string jiaqingjiaall = jiaqingjia[i]["q_all"].ToString();
                    if (jiaqingjiaall != "" && gettype(jiaqingjiaall) == true)
                    {
                        jiashijiaall += double.Parse(jiaqingjiaall);
                    }
                }
            }
            if ((int)jiashijiaall != 0)
            {
                tdZ7.Text = jiashijiaall.ToString("f2");
                trZ.Cells.Add(tdZ7);
                
            }
            else
            {
                tdZ7.Text = " ";
                trZ.Cells.Add(tdZ7);
            }
            //考勤分
            TableCell tdZ8 = new TableCell();
            if ((int)defenall != 0)
            {
                tdZ8.Text = defenall.ToString("f1");
                trZ.Cells.Add(tdZ8);
                
            }
            else
            {
                tdZ8.Text = " ";
                trZ.Cells.Add(tdZ8);
            }
            tb_result.Rows.Add(trZ);
        }
    }
    protected void btn_excel_Click(object sender, EventArgs e)
    {
         qingjia_all();
        if (tb_result.Rows.Count > 1)
        {
      
            string fileName = HttpUtility.UrlEncode("table", Encoding.UTF8).ToString();


            //设置编码格式
            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.Charset = "UTF-8";// "UTF-8"或者"GB2312"
            HttpContext.Current.Response.ContentType = "application/vnd.ms-excel";//text/csv
            HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.UTF8;
            HttpContext.Current.Response.AppendHeader("Content-Disposition", "attachment;filename=" + fileName + ".xls");
            //导出excel
            System.IO.StringWriter oSW = new System.IO.StringWriter();
            HtmlTextWriter oHW = new HtmlTextWriter(oSW);
            tb_result.RenderControl(oHW);



            //输出时加上"<meta http-equiv=\"content-type\" content=\"application/ms-excel; charset=UTF-8\"/>"解决编码问题

            //返回浏览器，
            HttpContext.Current.Response.Write("<meta http-equiv=\"content-type\" content=\"application/ms-excel; charset=UTF-8\"/>" + oSW.ToString());
            HttpContext.Current.Response.End();
        }
    }
    public bool gettype(string typestr)
    {
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
        return intqingalltype;
    }
}
