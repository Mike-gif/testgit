using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;
using System.Data.SqlClient;
using System.Data;
using DBHelper;

public partial class HR_HRadmin : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {

            DataTable dt_allgongzuori = SqlHelper.Read_TABLE("kaoqinnameprc");
            int i_all = dt_allgongzuori.Rows.Count;

            if (i_all > 0)
            {
                //setkaoqinName.Text = dr.GetString(dr.GetOrdinal("kaoqinName"));
                setkaoqinName.Text = dt_allgongzuori.Rows[0]["kaoqinName"].ToString();
            }

            //SqlHelper.Close();
        }
    }
}
