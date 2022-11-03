using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    internal class ContextString
    {
        private static string ConnString { get => "Server=tcp:assignmentcloud.database.windows.net,1433;Initial Catalog=assignmentcloudDB;Persist Security Info=False;User ID=645698_student.inholland.nl#EXT#@CheeyauInholland.onmicrosoft.com;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Authentication=\"Active Directory Integrated\";" +
                ""; }
        protected string getString()
        {
            return ConnString;
        }
    }
}
