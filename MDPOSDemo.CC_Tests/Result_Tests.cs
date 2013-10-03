using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MDPOSDemo.CC;
using NUnit.Framework;

namespace MDPOSDemo.CC_Tests
{
    [TestFixture]
    public class Result_Tests
    {
        private Result _result;

        [SetUp]
        public void SetUp()
        {
            _result = new Result();
        }

        [Test]
        public void AddError_AddsErrorWithoutFormat_Test()
        {
            var expected = "This is an error without a format";
            _result.AddError(expected);
            Assert.IsTrue(_result.Errors.Any(x => x.Message.Equals(expected)));
        }

        [Test]
        public void AddError_AddsErrorWithFormat_Test()
        {
            var format = "This is an {0} without a format";
            var param = "error";
            
            var expected = string.Format(format, param);
            _result.AddError(format, "error");
            Assert.IsTrue(_result.Errors.Any(x => x.Message.Equals(expected)));
        }

        [Test]
        public void IsValid_ReturnsFalseIfErrors_Test()
        {
            var expected = "This is an error without a format";
            _result.AddError(expected);
            Assert.IsFalse(_result.IsValid);
        }

        [Test]
        public void IsValid_ReturnsTrueIfNoErrors_Test()
        {
            _result.Errors = new List<Error>();
            Assert.IsTrue(_result.IsValid);
        }
    }
}
