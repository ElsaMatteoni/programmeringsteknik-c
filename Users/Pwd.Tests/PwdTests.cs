using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using Users.Common.Services;
using Users.Common;

namespace Pwd.Tests
{
    [TestClass]
    public class PwdTests
    {
        [TestMethod]
        public void password_is_of_lenght()
        {
            var passwordService = new PasswordService();
            var password = passwordService.GeneratePassword(8);

            Assert.AreEqual(8, password.Length);
        }

        [TestMethod]
        public void password_mutates()
        {
            var passwordService = new PasswordService();
            var firstPassword = passwordService.GeneratePassword(6);
            var secondPassword = passwordService.GeneratePassword(6);

            Assert.AreNotEqual(firstPassword, secondPassword);
        }

        [TestMethod]
        public void too_many_parameters_throws_error()
        {
            var passwordService = new PasswordService();

            Assert.ThrowsException<ArgumentOutOfRangeException>
                (() => passwordService.GeneratePassword(3, 2, 2, 2));
        }

        [TestMethod]
        public void correct_amount_of_capital_letters()
        {
            var passwordService = new PasswordService();
            var password = passwordService.GeneratePassword(5, 2);

            var capitalLetterCount = password.Count(x => char.IsUpper(x));
            Assert.AreEqual(2, capitalLetterCount);
        }

        [TestMethod]
        public void correct_amount_of_numbers()
        {
            var passwordService = new PasswordService();
            var password = passwordService.GeneratePassword(5, 1, 2);

            var numberCount = password.Count(x => char.IsDigit(x));
            Assert.AreEqual(2, numberCount);
        }
        [TestMethod]
        public void correct_amout_of_special_characters()
        {
            var passwordService = new PasswordService();
            var password = passwordService.GeneratePassword(8, 1, 1, 3);
            var specialChars = Constants.Passwords.SpecialCharacters;
            var specialCount = password.Count(x => specialChars.Contains(x));

            Assert.AreEqual(3, specialCount);
        }
    }
}
