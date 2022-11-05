using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    //return connnection string
    public static class ContextString
    {
        private static string ConnString = "";
        //private static string ConnString { get => "Server=localhost\\sqlexpress;Database=clouddatabase;Trusted_Connection=True"; }
        public static string getString()
        {
            return ConnString;
        }
    }
}

