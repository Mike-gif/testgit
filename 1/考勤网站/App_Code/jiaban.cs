using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// jiaban 的摘要说明
/// </summary>
public class jiaban
{
	public jiaban()
	{
		//
		// TODO: 在此处添加构造函数逻辑
		//
    }
    private int ID;               //主键ID
    private string u_number;
    private string u_name;
    private string u_jiatime;
    private string u_jiadate;




    public int Id
    {
        get { return ID; }
        set { ID = value; }
    }
    public string number
    {
        get { return u_number; }
        set { u_number = value; }
    }
    public string name
    {
        get { return u_name; }
        set { u_name = value; }
    }

    public string jiatime
    {
        get { return u_jiatime; }
        set { u_jiatime= value; }
    }

    public string jiadate
    {
        get { return u_jiadate; }
        set { u_jiadate = value; }
    }

}