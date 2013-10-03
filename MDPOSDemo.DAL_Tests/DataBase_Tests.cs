using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MDPOSDemo.CC;
using MDPOSDemo.DAL;
using NUnit.Framework;

namespace MDPOSDemo.DAL_Tests
{
    [TestFixture]
    public class DataBase_Tests
    {
        private TestData _target;

        [SetUp]
        public void SetUp()
        {
            _target = new TestData() {};
        }

        [TestCase(1)]
        [TestCase(2)]
        public void TestMethod_ReturnsResultPassed_Test(int expected)
        {
            var actual = _target.TestMethod(expected);
            Assert.AreEqual(expected, actual.Value);
        }


        private class TestData : DataBase, ITestData
        {
            public TestData()
            {
                ConnectionString = DbConnectionStrings.MDPOSDemoAzure;
            }

            public Result<int> TestMethod(int number)
            {
                var result = new Result<int>() {Value = 0};

                var dbResult = Query<int>("SELECT @number", new {@number = number});
                
                if (dbResult.IsValid)
                {
                    result.Value = dbResult.Value.FirstOrDefault();
                }

                return result;
            }
        }
        private interface ITestData
        {
            Result<int> TestMethod(int number);
        }
    }

    
}
