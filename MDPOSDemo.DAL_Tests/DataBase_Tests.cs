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
        [SetUp]

        private class TestData : DataBase, ITestData
        {
            public Result<int> TestMethod(int number)
            {
                var result = new Result<int>() {Value = 0};

                var dbResult = Query<int>("SELECT @number");
                
                if (dbResult.IsValid)
                {
                    result.Value = dbResult.Value.FirstOrDefault();
                }
            }
        }
        private interface ITestData
        {
            Result<int> TestMethod(int number);
        }
    }

    
}
