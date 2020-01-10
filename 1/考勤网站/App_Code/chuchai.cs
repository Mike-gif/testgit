using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// chuchai 的摘要说明
/// </summary>
public class chuchai
{
	public chuchai()
	{
		//
		// TODO: 在此处添加构造函数逻辑
		//
	}
    private int C_ID;               //主键ID
    private string c_number;
    private string c_name;
    private string c_startdate;
    private string c_enddate;
    private string c_things;




    public int Id
    {
        get { return C_ID; }
        set { C_ID = value; }
    }
    public string number
    {
        get { return c_number; }
        set { c_number = value; }
    }
    public string name
    {
        get { return c_name; }
        set { c_name = value; }
    }

    public string Starttime
    {
        get { return c_startdate; }
        set { c_startdate = value; }
    }

    public string Endate
    {
        get { return c_enddate; }
        set { c_enddate = value; }
    }
    public string Thing
    {
        get { return c_things; }
        set { c_things = value; }
    }

}