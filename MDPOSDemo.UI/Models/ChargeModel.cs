using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MDPOSDemo.UI.Models
{
    public class ChargeModel
    {
        public decimal Amount { get; set; }
    }

    public class RefundModel
    {
        public string TransactionID { get; set; }
        public decimal Amount { get; set; }
    }

    public class POSResultModel
    {
        public decimal AmountProcessed { get; set; }
        public string TransactionID { get; set; }
        public string Message { get; set; }
        public string Status { get; set; }
    }
}