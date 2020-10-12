using Microsoft.VisualStudio.TestTools.UnitTesting;
using BankAccountNs;
using System;


namespace BankTests
{
    [TestClass]
    public class BankAccountTests
    {
        [TestMethod]
        public void Debet_WithValidAmount_UpdatesBalance()
        {
            // Arrange
            double beginningBalance = 11.99;
            double debetAmount = 4.55;
            double expected = 7.44;
            BankAccount account = new BankAccount("Mr. Robin Van Welden", beginningBalance);

            // Act
            account.Debet(debetAmount);

            // Assert
            double actual = account.Balance;
            Assert.AreEqual(expected, actual, 0.001, "Account not debeted correctly");
        }

        [TestMethod]
        public void Debet_WhenAmountIsLessThanZero_ShouldThrowArgumentOutOfRange()
        {
            //Arrange
            double beginningBalance = 11.99;
            double debetAmount = -100.00;
            BankAccount account = new BankAccount("Robin Van Welden", beginningBalance);

            //Act
            try
            {
                account.Debet(debetAmount);
            }
            catch (System.ArgumentOutOfRangeException e)
            {
                //Assert
                StringAssert.Contains(e.Message, BankAccount.DebetAmountLessThanZeroMessage);
                return;
            }

            Assert.Fail("The expected exception was not thrown.");
        }

        [TestMethod]
        public void Debet_WhenAmountIsMoreThanBalance_ShouldThrowArgumentOutOfRange()
        {
            //Arrange
            double beginningBalance = 11.99;
            double debetAmount = 100.00;
            BankAccount account = new BankAccount("Robin Van Welden", beginningBalance);

            //Act
            try
            {
                account.Debet(debetAmount);
            }
            catch(System.ArgumentOutOfRangeException e)
            {
                //Assert
                StringAssert.Contains(e.Message, BankAccount.DebetAmountExceedsBalanceMessage);
                return;
            }

            Assert.Fail("The expected exception was not thrown.");
        }

        [TestMethod]
        public void Credit_WhenAmountIsLessThanZero_ShouldThrowArgumentOutOfRange()
        {
            //Arrange
            double beginningBalance = 11.99;
            double creditAmount = -100.00;
            BankAccount account = new BankAccount("Robin Van Welden", beginningBalance);

            //Act & Assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(()=>
            account.Credit(creditAmount));
        }
    }
}
