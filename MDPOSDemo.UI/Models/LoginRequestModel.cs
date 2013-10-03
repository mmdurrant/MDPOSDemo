using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MDPOSDemo.CC;

namespace MDPOSDemo.UI.Models
{
    public class LoginRequestModel
    {
        private ICollection<Error> _errors;
        public string Username { get; set; }
        public string Password { get; set; }
        public ICollection<Error> Errors
        {
            get { return _errors ?? (_errors = new List<Error>()); }
            set { _errors = value; }
        }
    }
}