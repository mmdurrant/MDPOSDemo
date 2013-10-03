using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MDPOSDemo.CC;
using NUnit.Framework;

namespace MDPOSDemo.CC_Tests
{
    [TestFixture]
    public class CleanupStack_Tests
    {
        private CleanupStack _cleanupStack;
        private int callCount = 0;

        [SetUp]
        public void CleanupStack()
        {
            _cleanupStack = new CleanupStack();
        }

        [Test]
        public void Cleanup_ExecutesNumberOfActions_Test()
        {
            var expected = 4;
            var int1 = 1;
            var int2 = 2;
            var int3 = 3;
            var int4ToBe5 = 4;
            _cleanupStack.Add(() => CleanupAction(null, int1));
            _cleanupStack.Add(() => CleanupAction(null, int2));
            _cleanupStack.Add(() => CleanupAction(null, int3));
            _cleanupStack.Add(() => CleanupAction(() => int4ToBe5++, int4ToBe5));
            _cleanupStack.Cleanup();
            Assert.AreEqual(5, int4ToBe5);
            Assert.AreEqual(callCount, expected);
        }

        [Test]
        public void Cleanup_ReturnsErrors_Test()
        {
            var expected = 2;
            _cleanupStack.Add(() => {throw new Exception("Error 1!");} );
            _cleanupStack.Add(() => { throw new Exception("Error 2!"); });
            var actual = _cleanupStack.Cleanup();
            Assert.AreEqual(expected, actual.Count());
        }

        private void CleanupAction(Action otherAction, int cleanupData)
        {
            if (otherAction != null) otherAction();
            Debug.Print("0", cleanupData);
            ++callCount;
        }
    }
}
