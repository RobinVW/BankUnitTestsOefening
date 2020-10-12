using System;

namespace BankAccountNs
{
    /// <summary>
    /// Bank account demo class.
    /// </summary>
    public class BankAccount
    {
        private readonly string m_costomersName;
        private double m_balance;

        public const string DebetAmountExceedsBalanceMessage = "Debet amount exceeds balance";
        public const string DebetAmountLessThanZeroMessage = "Debet amount is less than zero";
        public const string CreditAmountLessThanZeroMessage = "Credot amount is less than zero";

        private BankAccount() { }

        public BankAccount(string costomersName, double balance)
        {
            m_costomersName = costomersName;
            m_balance = balance;
        }

        public string CustomersName
        {
            get { return m_costomersName; }
        }

        /// <summary>
        /// Debet function for the BankAccount class.
        /// </summary>
        /// <param name="amount"></param>
        public void Debet(double amount)
        {
            if (amount > m_balance)
            {
                throw new ArgumentOutOfRangeException("amount",amount,DebetAmountExceedsBalanceMessage);
            }

            if(amount < 0)
            {
                throw new ArgumentOutOfRangeException("amount",amount,DebetAmountLessThanZeroMessage);
            }

            m_balance -= amount;
        }

        public double Balance
        {
            get { return m_balance; }
        }

        public void Credit(double amount)
        {
            if(amount < 0)
            {
                throw new ArgumentOutOfRangeException("amount");
            }

            m_balance += amount;
        }
    }


}
