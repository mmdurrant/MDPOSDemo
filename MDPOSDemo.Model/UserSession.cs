using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDPOSDemo.Model
{
    public class UserSession
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public int ID { get; set; }
        public string ConfigurationID { get; set; }
        public string MerchantKey { get; set; }
        public string MerchantName { get; set; }
    }
}
