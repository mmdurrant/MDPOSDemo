using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MDPOSDemo.DAL;
using MDPOSDemo.Model;
using NUnit.Framework;

namespace MDPOSDemo.DAL_Tests
{
    [TestFixture]
    public class LoginData_Tests
    {
        private LoginData _target; 

        [SetUp]
        public void SetUp()
        {
            _target = new LoginData();
        }

        [Test]
        public void Login_ReturnsResultWhenUserExists_Test()
        {
            var actual = _target.Login(new LoginRequest());
        }

        
    }
}
