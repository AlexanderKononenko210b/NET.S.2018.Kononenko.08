using System;
using NUnit.Framework;
using Bank;

namespace Bank.Test
{
    [TestFixture]
    public class BankAccountOperationsTest
    {
        private BankAccount accountBank;

        [SetUp]
        public void Initialize()
        {
            var userAccount = new UserAccount("Ivan", "Ivanov", "+375-(29)-700-77-77");

            var numberBankAccountService = NumberBankAccountService.Instance;

            var startAmount = new Decimal(1000);

            var newBankAccount = new BankAccount(userAccount, numberBankAccountService, startAmount);

            accountBank = newBankAccount;
        }

        /// <summary>
        /// Test create new BankAccount instance
        /// </summary>
        [Test]
        public void Create_BankAccount_With_Valid_Data()
        {
            Assert.AreEqual("40512100790000000001", accountBank.NumberBankAccount);

            Assert.AreEqual(EnumTypeAccount.Base, accountBank.TypeAccount);

            Assert.IsFalse(accountBank.IsDelete);

            Assert.AreEqual(1000, accountBank.BonusPoints);

            Assert.AreEqual(1000, accountBank.Balance);

            Assert.AreEqual(0, accountBank.UserId);
        }

        /// <summary>
        /// Test create new BankAccount instance
        /// </summary>
        [Test]
        public void Delete_BankAccount()
        {
            var assert1 = accountBank.DeleteBancAccount();

            Assert.IsTrue(accountBank.IsDelete);
        }

        /// <summary>
        /// Test DepositMoney with valid data
        /// </summary>
        [Test]
        public void DepositMoney_BankAccount_With_Valid_Data()
        {
            var assert1 = accountBank.DepositMoney(1000, 0);

            Assert.AreEqual(EnumTypeAccount.Silver, accountBank.TypeAccount);

            Assert.AreEqual(2000, accountBank.Balance);
        }

        /// <summary>
        /// Test WithDrawMoney with valid data
        /// </summary>
        [Test]
        public void WithDrawMoney_BankAccount_With_Valid_Data()
        {
            var assert1 = accountBank.DepositMoney(2000, 0);

            var assert2 = accountBank.WithDrawMoney(1000, 0);

            Assert.AreEqual(EnumTypeAccount.Silver, accountBank.TypeAccount);

            Assert.AreEqual(2000, assert2);
        }

        /// <summary>
        /// Test method DepositMoney expected ArgumentOutOfRangeException
        /// </summary>
        /// <param name="amount">amount</param>
        /// <param name="userId">user Id</param>
        [TestCase(100001, 0)]
        public void DepositMoney_Expected_ArgumentOutOfRangeException(decimal amount, int userId)
            => Assert.Throws<ArgumentOutOfRangeException>(() => accountBank.DepositMoney(amount, userId));

        /// <summary>
        /// Test method WithDrawMoney expected ArgumentOutOfRangeException
        /// </summary>
        /// <param name="amount">amount</param>
        /// <param name="userId">user Id</param>
        [TestCase(2001, 0)]
        [TestCase(1999.9, 0)]
        public void WithDrawMoney_Expected_ArgumentOutOfRangeException(decimal amount, int userId)
            => Assert.Throws<ArgumentOutOfRangeException>(() => accountBank.WithDrawMoney(amount, userId));

        /// <summary>
        /// Test method WithDrawMoney expected AccessExceptions
        /// </summary>
        /// <param name="amount">amount</param>
        /// <param name="userId">user Id</param>
        [TestCase(100, 1)]
        public void WithDrawMoney_Expected_AccessExceptions(decimal amount, int userId)
            => Assert.Throws<AccessExceptions>(() => accountBank.WithDrawMoney(amount, userId));

        /// <summary>
        /// Test method DepositMoney expected AccessExceptions
        /// </summary>
        /// <param name="amount">amount</param>
        /// <param name="userId">user Id</param>
        [TestCase(100, 1)]
        public void DepositMoney_Expected_AccessExceptions(decimal amount, int userId)
            => Assert.Throws<AccessExceptions>(() => accountBank.DepositMoney(amount, userId));
    }
}
