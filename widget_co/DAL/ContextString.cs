using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    //return connnection string
    internal class ContextString
    {
        private static string ConnString { get => "place here your connection string"; }
        protected string getString()
        {
            return ConnString;
        }
    }
}
