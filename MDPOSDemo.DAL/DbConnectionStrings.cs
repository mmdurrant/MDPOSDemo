using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDPOSDemo.DAL
{
    public class DbConnectionStrings
    {
        public static string MDPOSDemoAzure
        {
            get { return GetConnectionString("MDPOSDemo_Azure"); }
        }

        public static string GetConnectionString(string name)
        {
            var result = string.Empty;

            var connString = ConfigurationManager.ConnectionStrings[name];
            if (connString != null && !string.IsNullOrWhiteSpace(connString.ConnectionString))
            {
                result = connString.ConnectionString;
            }
            else
            {
                throw new Exception(string.Format("Could not get connection string {0}", name));
            }

            return result;
        }
    }
}
