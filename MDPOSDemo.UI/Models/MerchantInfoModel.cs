using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MDPOSDemo.UI.Models
{
    public class MerchantInfoModel
    {
        public string name { get; set; }
        public string merchantName { get; set; }
        public string merchantKey { get; set; }
        public string configurationId { get; set; }
        public string transactionType { get; set; }
    }
}