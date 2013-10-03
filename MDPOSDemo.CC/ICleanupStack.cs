using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace MDPOSDemo.CC
{
    public interface ICleanupStack
    {
        IEnumerable<Error> Cleanup();
        void Add(Action action);
    }

    public interface INeedsCleanup<T>
    {
        Action CleanupAction { get; set; }
        T ReturnValue { get; set; }
    }
}