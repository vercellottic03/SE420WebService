using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Student
/// </summary>
public class Student
{
    private int Stu_ID1;
    private string stu_Name1;
    private int m_ID1;
    private string stu_PIN1;
    private string stu_Theme1;
    private string m_Name1;
    private string r_Type1;
    private string error;
    Error stuError = new Error();

    public int Stu_ID
    {
        get
        {
            return Stu_ID1;
        }

        set
        {
            Stu_ID1 = value;
        }
    }

    public string Stu_Name
    {
        get
        {
            return stu_Name1;
        }

        set
        {
            stu_Name1 = value;
        }
    }

    public int M_ID
    {
        get
        {
            return m_ID1;
        }

        set
        {
            m_ID1 = value;
        }
    }

    public string Stu_PIN
    {
        get
        {
            return stu_PIN1;
        }

        set
        {
            stu_PIN1 = value;
        }
    }

    public string Stu_Theme
    {
        get
        {
            return stu_Theme1;
        }

        set
        {
            stu_Theme1 = value;
        }
    }

    public string Error
    {
        get
        {
            return error;
        }

        set
        {
            error = value;
        }
    }

    public string m_Name
    {
        get
        {
            return m_Name1;
        }

        set
        {
            m_Name1 = value;
        }
    }

    public string R_Type
    {
        get
        {
            return r_Type1;
        }

        set
        {
            r_Type1 = value;
        }
    }
}
