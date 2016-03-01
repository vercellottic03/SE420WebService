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
    private string R_Type1;
    private string Error1;

    public int M_ID
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

    public string M_Name
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

    public string R_Type
    {
        get
        {
            return R_Type1;
        }

        set
        {
            R_Type1 = value;
        }
    }

    public string Error
    {
        get
        {
            return Error1;
        }

        set
        {
            Error1 = value;
        }
    }
}
