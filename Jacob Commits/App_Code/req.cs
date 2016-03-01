using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for req
/// </summary>
public class req
{
    private int R_ID1;
    private string R_Type1;
    private int C_ID1;
    private int R_isGen1;
    private string Error1;

    public int R_ID
    {
        get
        {
            return R_ID1;
        }

        set
        {
            R_ID1 = value;
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

    public int C_ID
    {
        get
        {
            return C_ID1;
        }

        set
        {
            C_ID1 = value;
        }
    }

    public int R_isGen
    {
        get
        {
            return R_isGen1;
        }

        set
        {
            R_isGen1 = value;
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