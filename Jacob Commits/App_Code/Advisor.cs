using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Advisor
/// </summary>
public class Advisor
{
    private int A_ID1;
    private string a_Name1;
    private string a_PIN1;
    private string a_Theme1;


    public int A_ID
    {
        get
        {
            return A_ID1;
        }

        set
        {
            A_ID1 = value;
        }
    }

    public string A_Name
    {
        get
        {
            return a_Name1;
        }

        set
        {
            a_Name1 = value;
        }
    }

    public string A_PIN
    {
        get
        {
            return a_PIN1;
        }

        set
        {
            a_PIN1 = value;
        }
    }

    public string A_Theme
    {
        get
        {
            return a_Theme1;
        }

        set
        {
            a_Theme1 = value;
        }
    }

}