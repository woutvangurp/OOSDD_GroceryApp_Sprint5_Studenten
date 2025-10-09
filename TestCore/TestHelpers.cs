using Grocery.Core.Helpers;
using Grocery.Core.Interfaces.Services;
using Grocery.Core.Models;
using Grocery.Core.Services;
using System;
using Grocery.Core.Helpers;
using Grocery.Core.Interfaces.Services;
using Grocery.Core.Models;
using Grocery.Core.Services;
using Microsoft.VisualBasic.CompilerServices;
using Moq;

namespace TestCore
{
    public class AuthTests {
        [SetUp]
        public void Setup() { }
        //edge cases

        [Test]
        public void TestLoginFailsWithNonExistentUser() {
            //arrange
            Mock<IClientService> mockClientService = new Mock<IClientService>();
            string email = "nonexistent@mail.com";
            string password = "anypassword";

            mockClientService.Setup(x => x.Get(email)).Returns((Client?)null);
            AuthService authService = new AuthService(mockClientService.Object);

            //act
            Client? testClient = authService.Login(email, password);

            //assert
            Assert.IsNull(testClient);
            mockClientService.Verify(x => x.Get("nonexistent@mail.com"), Times.Once);
        }
    }

    public class TestHelpers {
        [SetUp]
        public void Setup() { }

        //Happy flow
        [Test]
        public void TestPasswordHashIsCreated() {
            // Arrange
            string password = "user3";

            // Act
            string passwordHash = PasswordHelper.HashPassword(password);

            // Assert
            Assert.IsNotNull(passwordHash);
            Assert.IsNotEmpty(passwordHash);
            Assert.That(passwordHash.Contains("."), "Hash should contain a dot separator");
        }
        //Happy flow
        [Test]
        public void TestPasswordHelperReturnsTrue() {
            string password = "user3";
            string passwordHash = "sxnIcZdYt8wC8MYWcQVQjQ==.FKd5Z/jwxPv3a63lX+uvQ0+P7EuNYZybvkmdhbnkIHA=";
            Assert.IsTrue(PasswordHelper.VerifyPassword(password, passwordHash));
        }

        [TestCase("user1", "IunRhDKa+fWo8+4/Qfj7Pg==.kDxZnUQHCZun6gLIE6d9oeULLRIuRmxmH2QKJv2IM08=")]
        [TestCase("user3", "sxnIcZdYt8wC8MYWcQVQjQ==.FKd5Z/jwxPv3a63lX+uvQ0+P7EuNYZybvkmdhbnkIHA=")]
        public void TestPasswordHelperReturnsTrue(string password, string passwordHash) {
            Assert.IsTrue(PasswordHelper.VerifyPassword(password, passwordHash));
        }

        //Unhappy flow
        [Test]
        public void TestPasswordHelperReturnsFalse() {
            //arrange
            string password = "wrongpassword";
            string passwordhash = "sxnIcZdYt8wC8MYWcQVQjQ==.FKd5Z/jwxPv3a63lX+uvQ0+P7EuNYZybvkmdhbnkIHA=";
            //act & assert
            Assert.IsFalse(PasswordHelper.VerifyPassword(password, passwordhash));
        }

        [TestCase("user12", "IunRhDKa+fWo8+4/Qfj7Pg==.kDxZnUQHCZun6gLIE6d9oeULLRIuRmxmH2QKJv2IM08=")]
        [TestCase("user32", "sxnIcZdYt8wC8MYWcQVQjQ==.FKd5Z/jwxPv3a63lX+uvQ0+P7EuNYZybvkmdhbnkIHA=")]
        public void TestPasswordHelperReturnsFalse(string password, string passwordHash) {
            Assert.IsFalse(PasswordHelper.VerifyPassword(password, passwordHash));
        }

        [Test]
        public void TestPasswordIsWhiteSpace() {
            //arrange
            string password = "";
            string passwordhash = "sxnIcZdYt8wC8MYWcQVQjQ==.FKd5Z/jwxPv3a63lX+uvQ0+P7EuNYZybvkmdhbnkIHA=";
            //act & assert
            Assert.IsFalse(PasswordHelper.VerifyPassword(password, passwordhash));
        }

        [TestCase("", "IunRhDKa+fWo8+4/Qfj7Pg==.kDxZnUQHCZun6gLIE6d9oeULLRIuRmxmH2QKJv2IM08=")]
        [TestCase(" ", "sxnIcZdYt8wC8MYWcQVQjQ==.FKd5Z/jwxPv3a63lX+uvQ0+P7EuNYZybvkmdhbnkIHA=")]
        public void TestPasswordIsWhiteSpace(string password, string passwordHash) {
            Assert.IsFalse(PasswordHelper.VerifyPassword(password, passwordHash));
        }
    }
}