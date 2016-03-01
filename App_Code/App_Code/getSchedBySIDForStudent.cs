using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for getSchedBySIDForStudent
/// </summary>
public class getSchedBySIDForStudent
{
    private string c_name1;
    private string c_code1;
    private int c_credits1;
    private int s_year1;
    private int s_term1;
    private string error1;

    public string C_name
    {
        get
        {
            return c_name1;
        }

        set
        {
            c_name1 = value;
        }
    }

    public string C_code
    {
        get
        {
            return c_code1;
        }

        set
        {
            c_code1 = value;
        }
    }

    public int C_credits
    {
        get
        {
            return c_credits1;
        }

        set
        {
            c_credits1 = value;
        }
    }

    public int S_year
    {
        get
        {
            return s_year1;
        }

        set
        {
            s_year1 = value;
        }
    }

    public int S_term
    {
        get
        {
            return s_term1;
        }

        set
        {
            s_term1 = value;
        }
    }

    public string Error
    {
        get
        {
            return error1;
        }

        set
        {
            error1 = value;
        }
    }
}