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
using System.Security.Authentication;
public partial class admin_YuanGongInf : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
           // Session["page"] = 0;
            GridViewDataBind();
            Calendar1.Visible = false;
            ruzhi.Text = DateTime.Now.ToString("yyyy-MM-dd");
            int pagecount = gvShow.PageCount;
            if (Session["Page"] != null)
            {
                string str=Session["Page"].ToString();
                int intpageindex = int.Parse(str);
                if (intpageindex == pagecount || intpageindex < pagecount)
                {
                    gvShow.PageIndex = intpageindex;
                    gvShow.DataBind();
                    Session["Page"] = null;
                }
            }
            if (Session["insert"] != null)
            {
                gvShow.PageIndex = gvShow.PageCount;
                gvShow.DataBind();
                Session["insert"] = null;
            
            }
            if (Session["editinf"] != null)
            {
                gvShow.PageIndex = int.Parse(Session["editinf"].ToString());
                gvShow.DataBind();
                Session["editinf"] = null;
            }
           // Session["Page"] = gvShow.PageIndex;

        }
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        u_shangjiname.Text = u_shangji.SelectedValue;
    }
    
    protected void DropDownList3_SelectedIndexChanged(object sender, EventArgs e)
    {
        u_kaoqinadminname.Text = u_kaoqinadmin.SelectedValue;
    }
   
    public void GridViewDataBind()
    {



        string sql1 = "select * from userinfo";

        DataSet ds = SqlHelper.ExecuteDataSet(sql1);
        Session["Table"] = ds.Tables[0];
        gvShow.DataSource = ds;
        gvShow.DataBind();
        
        
       
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
       // Session["Page"] = gvShow.PageIndex.ToString();
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
           btn.Attributes.Add("onclick", "return confirm('确定要删除该联系人记录吗？')");
            //Response.Write("<script> var result=window.prompt('请输入密码','password'); if(result!=null) {document.cookie='name = '+result;}else{}</script>");

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
            

           

            string sql2 = "delete from [userinfo] where id=@ID";
            SqlParameter[] sps2 = new SqlParameter[] { 
            new SqlParameter("@ID", Convert.ToInt32(opervalue)),
            };

            int result = SqlHelper.ExecuteNonQuery(sql2, sps2);
            if (result > 0)
            {
                Session["Page"] = gvShow.PageIndex.ToString();
                 Response.Redirect("YuanGongInf.aspx");

               
            }

        }
        else if (opername == "Edit")
        {
            Session["editinf"] = gvShow.PageIndex.ToString();
            Response.Redirect("edit_YuanGongInf.aspx?operfun=edit&operid=" + Convert.ToInt32(opervalue));
        }

    }

    /// <summary>
    /// 排序
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
 /*   protected void gvShow_Sorting(object sender, GridViewSortEventArgs e)
    {
        DataTable tb = Session["Table"] as DataTable;
        tb.DefaultView.Sort = e.SortExpression;
        gvShow.DataSource = tb;
        gvShow.DataBind();
    }
*/
    public SortDirection GridViewSortDirection
    {

        get
        {

            if (ViewState["sortDirection"] == null)

                ViewState["sortDirection"] = SortDirection.Ascending;

            return (SortDirection)ViewState["sortDirection"];

        }

        set { ViewState["sortDirection"] = value; }

    }

    protected void gvShow_Sorting(object sender, GridViewSortEventArgs e)
    {
        // DataTable tb = Session["Table"] as DataTable;
        // tb.DefaultView.Sort = e.SortExpression;

        string sortExpression = e.SortExpression;
        if (GridViewSortDirection == SortDirection.Ascending)
        {

            GridViewSortDirection = SortDirection.Descending;
            SortGridView(sortExpression, " DESC");
        }
        else
        {

            GridViewSortDirection = SortDirection.Ascending;

            SortGridView(sortExpression, " ASC");

        }
        //  gvShow.DataSource = tb;
        //  gvShow.DataBind();
    }

    private void SortGridView(string sortExpression, string direction)
    {

        DataTable tb = Session["Table"] as DataTable;

        tb.DefaultView.Sort = sortExpression + direction;

        gvShow.DataSource = tb;
        gvShow.DataBind();

    }
    protected void lbDelete_Command(object sender, CommandEventArgs e)
    {
        string oper = e.CommandName;
        if (oper == "delOne")
        {
            string ids = "";
            for (int i = 0; i < this.gvShow.Rows.Count; i++)
            {
                CheckBox cb = (CheckBox)this.gvShow.Rows[i].Cells[0].FindControl("cbCheck");
                if (cb.Checked)
                    ids += cb.Text + ",";
            }
            if (string.IsNullOrEmpty(ids))
                ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('请选择您要删除的一个或多个用户！')</script>");
            else
            {
                string[] delids = ids.Trim(',').Split(',');
                foreach (string item in delids)
                {
                    string sql3 = "delete from [userinfo] where id=@ID";
                    SqlParameter[] sps3 = new SqlParameter[]
                    {new SqlParameter("@ID", Convert.ToInt32(item)),
                    };


                    int result = SqlHelper.ExecuteNonQuery(sql3, sps3);
                    if (result > 0)
                    {

                        GridViewDataBind();
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('删除用户信息失败！')</script>");
                    }

                }

                GridViewDataBind();
            }
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
       
        string str1="";
        if (u_cardid2.Text != "")
        {
            str1+= " or cardid2='" + u_cardid2.Text + "'";
        }
        if (u_cardid3.Text != "")
        {
            str1 += " or cardid3='" + u_cardid3.Text + "'";
        }
        String sql1 = "SELECT * FROM [userinfo] where number='"+u_id.Text+"' or cardid1='"+u_cardid1.Text+"'"+str1;
        SqlDataReader dr = SqlHelper.ExecuteReader(CommandType.Text, sql1);
      
        if (dr.Read())
        {
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "success", "alert(\"该用户信息已经存在\"); ", true);
            SqlHelper.Close();
            return;
        }
        SqlHelper.Close();
        string strpassword = GetMD5(u_id.Text);
        string shangjiinf = "",kaoqinadmininf="";
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
        string sql4 = "insert into [userinfo](cardid1,name,number,zaizhi,Banci,cardid2,cardid3,shangji,kaoqinadmin,jibie,canbu,chebu,password,bumen,ruzhi)values(@cardid1,@name,@number,@zaizhi,@Banci,@cardid2,@cardid3,@shangji,@kaoqinadmin,@jibie,@canbu,@chebu,@password,@bumen,@ruzhi)";
        SqlParameter[] sps4 = new SqlParameter[15];
        sps4[0] = new SqlParameter("@cardid1", u_cardid1.Text);
        sps4[1] = new SqlParameter("@name", u_name.Text);
        sps4[2] = new SqlParameter("@number",u_id.Text);
       // sps4[3] = new SqlParameter("@zaizhi", u_pression.Text);
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
        sps4[12] = new SqlParameter("@password", " 81dc9bdb52d04dc20036dbd8313ed055");
        sps4[13] = new SqlParameter("@bumen", u_bumen.Text);
        sps4[14] = new SqlParameter("@ruzhi", ruzhi.Text);

        int i = SqlHelper.ExecuteNonQuery(sql4, sps4);


        if (i > 0)
        {
            gvShow.DataBind();
            GridViewDataBind();
            Session["insert"] =" 1";
            Response.Redirect("YuanGongInf.aspx");
        }

    }
    public static string GetMD5(string str)
    {
        byte[] b = System.Text.Encoding.Default.GetBytes(str);
        b = new System.Security.Cryptography.MD5CryptoServiceProvider().ComputeHash(b);
        string ret = " ";
        for (int i = 0; i < b.Length; i++)
        {
            ret += b[i].ToString("x").PadLeft(2, '0');
        }
        return ret;
    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        Calendar1.Visible = true;
        
    }
    protected void Calendar1_SelectionChanged(object sender, EventArgs e)
    {
        ruzhi.Text = Calendar1.SelectedDate.ToString();
        if (!(ruzhi.Text == ""))
        {
            Calendar1.Visible = false;

            ruzhi.Text = Calendar1.SelectedDate.ToString("yyyy-MM-dd");
        }
    }
    
}