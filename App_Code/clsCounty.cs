using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for clsACounty
/// </summary>
public class clsCounty
{

    //private data members
    private Int32 countyNo;
    private string county;

    //public property for CountyNo
    public Int32 CountyNo
    {
        get
        {
            return countyNo;
        }
        set
        {
            countyNo = value;
        }
    }

    //public property for County
    public string County
    {
        get
        {
            return county;
        }
        set
        {
            county = value;
        }
    }
}