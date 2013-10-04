using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MDPOSDemo.UI.Models
{
    public class LoginResultModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string MerchantName { get; set; }
        public string MerchantKey { get; set; }
        public string ConfigurationID { get; set; }
    }
}