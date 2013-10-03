using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDPOSDemo.CC
{
    public class Result<T> : Result
    {
        public T Value { get; set; }
    }

    public class Result
    {
        private IList<Error> _errors;
        public IList<Error> Errors
        {
            get { return _errors ?? (_errors = new List<Error>()); }
            set { _errors = value; }
        }

        public bool IsValid
        {
            get
            {
                return !Errors.Any();
            }
        }

        public void AddError(string format, params object[] paramsObjects)
        {
            var error = new Error();
            var message = string.Format(format, paramsObjects);
            error.Message = message;
            Errors.Add(error);
        }

    }
}
