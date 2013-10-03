using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MDPOSDemo.CC.Extenders;

namespace MDPOSDemo.CC
{
    public class CleanupStack : ICleanupStack
    {
        private Stack<Action> _cleanupActions;
        private Stack<Action> CleanupActions
        {
            get { return _cleanupActions ?? (_cleanupActions = new Stack<Action>()); }
            set { _cleanupActions = value; }
        }

        public IEnumerable<Error> Cleanup()
        {
            var result = new List<Error>();
            while (CleanupActions.Any())
            {
                var action = CleanupActions.Pop();

                try
                {
                    action();
                }
                catch (Exception e)
                {
                    result.Add(e.Message);
                }

            }

            return result;
        }

        public void Add(Action action)
        {
            CleanupActions.Push(action);
        }
    }
}
