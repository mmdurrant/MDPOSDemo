using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDPOSDemo.DAL.POCOs
{
    public class POSUser
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string MerchantName { get; set; }
        public string MerchantKey { get; set; }
        public string ConfigurationID { get; set; }
    }
}
