using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDPOSDemo.CC.Extenders
{
    public static class ResultExtenders
    {
        public static void AddErrors(this Result result, IEnumerable<Error> errors)
        {
            foreach (var error in errors)
            {
                result.Errors.Add(error);
            }
        }
    }
}
