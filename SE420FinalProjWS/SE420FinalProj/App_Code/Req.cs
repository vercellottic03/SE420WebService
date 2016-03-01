using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for req
/// </summary>
public class Req
{
    private string R_Type1;
    private string Error1;

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