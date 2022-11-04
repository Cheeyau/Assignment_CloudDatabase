using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    //return connnection string
    public class ContextString
    {
        //private static string ConnString { get => "Server=tcp:assignmentcloud.database.windows.net,1433;Initial Catalog=assignmentcloudDB;Persist Security Info=False;User ID=645698_student.inholland.nl#EXT#@CheeyauInholland.onmicrosoft.com;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Authentication=\"Active Directory Integrated\";"; }
        private static string ConnString { get => "Server=localhost\\mssqllocaldb;Database=clouddatabase;Trusted_Connection=True;MultipleActiveResultSets=true"; }
        public static string getString()
        {
            return ConnString;
        }
    }
}
