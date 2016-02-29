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
        public string A_Name;
        public string A_PIN;
        public string A_Theme;

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



        /* public Advisor()
         {
         A_ID1 = 0;
         A_Name = " ";
         A_PIN = " ";
         A_Theme = " ";

         }
         */

    }