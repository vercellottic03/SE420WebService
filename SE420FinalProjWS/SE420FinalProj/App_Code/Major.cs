using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Major
/// </summary>
public class Major
{
    private int M_ID1;
    private string M_Name1;
    private string R_Type;

    public int M_ID11
    {
        get
        {
            return M_ID1;
        }   

        set
        {
            M_ID1 = value;
        }
    }

    public string M_Name11
    {
        get
        {
            return M_Name1;
        }

        set
        {
            M_Name1 = value;
        }
    }

    public string R_Type1
    {
        get
        {
            return R_Type;
        }

        set
        {
            R_Type = value;
        }
    }
}
