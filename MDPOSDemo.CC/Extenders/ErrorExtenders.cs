using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDPOSDemo.CC.Extenders
{
    public static class ErrorExtenders
    {
        public static void Add(this ICollection<Error> input, string error)
        {
            input.Add(new Error(error));
        }

        public static void AddError(this ICollection<Error> input, string formatString, params object[] parms)
        {
            var errorMessage = string.Format(formatString, parms);
            input.Add(errorMessage);
        }
    }
}
