using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDPOSDemo.CC.Extenders
{
    public static class CleanupStackExtenders
    {
        public static T CleanupBy<T>(this INeedsCleanup<T> input, ICleanupStack cleanupStack)
        {
            cleanupStack.Add(input.CleanupAction);
            return input.ReturnValue;
        }
    }
}
