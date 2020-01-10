using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// userinfo 的摘要说明
/// </summary>
public class userinfo
{
	public userinfo()
	{
		//
		// TODO: 在此处添加构造函数逻辑
		//
	}
    private int id;               //主键ID
    private string name;
    private string number;
    private string Permissions;
    private string Banci;
    private string cardid1;
    private string cardid2;
    private string cardid3;
    private string shangji;
    private string kaoqinsdmin;
    private string jibie;
    private string canbu;
    private string chebu;
    private string password;
   




    public int _ID
    {
        get { return id; }
        set { id = value; }
    }
     public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public string Number
    {
        get { return number; }
        set { number= value; }
    }

    public string Permission
    {
        get { return Permissions; }
        set { Permissions = value; }
    }

    public string banci
    {
        get { return Banci; }
        set { Banci = value; }
    }
    public string Cardid1
    {
        get { return cardid1; }
        set { cardid1= value; }
    }
    public string Cardid2
    {
        get { return cardid2; }
        set { cardid2 = value; }
    }

    public string Cardid3
    {
        get { return cardid3; }
        set { cardid3 = value; }
    }

    public string Shangji
    {
        get { return shangji; }
        set { shangji = value; }
    }

    public string Kaoqinadmin
    {
        get { return kaoqinsdmin; }
        set { kaoqinsdmin= value; }
    }
    public string  Jibie
    {
        get { return jibie; }
        set { jibie = value; }
    }
    public string Canbu
    {
        get { return canbu; }
        set { canbu = value; }
    }

    public string Chebu
    {
        get { return chebu; }
        set { chebu = value; }
    }
    public string Password
    {
        get { return password; }
        set { password = value; }
    }
   
   
    


}