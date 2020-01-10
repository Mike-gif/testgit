using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Security.Cryptography;
using System.IO;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using DBHelper;


public partial class HR_logo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {


        Stream stream = fup1.PostedFile.InputStream;
        System.Drawing.Image image = System.Drawing.Image.FromStream(stream);

       
            if (fup1.HasFile)
            {
                Boolean fileOK = false;//检查文件是否符合要求
                int width;
                int height;
                string _tarPath = MapPath("../upfiles/") + "logo"+ Path.GetExtension(fup1.FileName);
                fup1.SaveAs(_tarPath);
                width = image.Width;
                height = image.Height;
                //if (image.Width == 390&& image.Height == 567)
                fileOK = true;
                if (fileOK)
                {
                    try
                    {

                        Label1.Text = "文件已经上传!";
                        Image1.ImageUrl = "../upfiles/" +"logo"+ Path.GetExtension(fup1.FileName);
                        Image1.Visible = true;
                    }
                    catch (Exception ex)
                    {
                        Label1.Text = "文件不能上传";
                    }
                }
              



            }
       

      

    }
}

