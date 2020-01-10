using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Cardinf_ 的摘要说明
/// </summary>
public class Cardinf_
{
	public Cardinf_()
	{
		//
		// TODO: 在此处添加构造函数逻辑
		//
	}
    private int ID;               //主键ID
    private string c_id;
    private string c_name;
    private string c_addr;
    private string c_time;
    private string c_status;





    public int CpID
    {
        get { return ID; }
        set { ID = value; }
    }
    public string id
    {
        get { return c_id; }
        set { c_id = value; }
    }
    public string Name
    {
        get { return c_name; }
        set { c_name = value; }
    }

    public string address
    {
        get { return c_addr; }
        set { c_addr = value; }
    }

    public string time
    {
        get { return c_time; }
        set { c_time = value; }
    }

    public string Status
    {
        get { return  c_status ; }
        set { c_status = value; }
    }
   


}