using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    public class BankAccount : Entity
    {
        const decimal MAX_AMOUNT_DEPOSIT = 100000;

        const decimal MIN_AMOUNT_WITHDRAW = 10;

        const decimal MIN_AMOUNT_STATE_BANK_ACCOUNT = 1;

        private readonly int userId;

        private decimal balance;

        private bool isDelete;

        private int bonusPoints;

        private EnumTypeAccount typeAccount;

        /// <summary>
        /// Get or set type bank account
        /// </summary>
        public EnumTypeAccount TypeAccount { get; set; }

        /// <summary>
        /// Get number bank account
        /// </summary>
        public string NumberBankAccount { get; }

        /// <summary>
        /// Get or set is delete
        /// </summary>
        public bool IsDelete { get; set; }

        /// <summary>
        /// Get or set bonus points
        /// </summary>
        public int BonusPoints { get; set; }

        /// <summary>
        /// Get balance BankAccount
        /// </summary>
        public decimal Balance
        {
            get { return balance; }
        }

        /// <summary>
        /// Get identificator owner bancAccount
        /// </summary>
        public int UserId
        {
            get { return userId; }
        }

        /// <summary>
        /// Create instance banc account
        /// </summary>
        /// <param name="userAccount">user account</param>
        /// <param name="numberBankAccountService">service for get number banc account</param>
        /// <param name="typeBankAccountService">service for get type banc account service</param>
        /// <param name="bonusPointService">service for get bonus point</param>
        /// <param name="startAmount">start value amount</param>
        public BankAccount(UserAccount userAccount, NumberBankAccountService numberBankAccountService, decimal startAmount)
        {
            //???? can I throw new Exceptions in constructor. I think this is very bad, but I now that I would chack input reference arguments on null?

            this.NumberBankAccount = numberBankAccountService.GetNextNumberBankAccount();

            this.userId = userAccount.Id;

            this.BonusPoints = BonusPointService.CalcBonusPointDepositMoneyOnStart(startAmount);

            this.TypeAccount = TypeBankAccountService.VeryfyTypeBankAccount(startAmount);

            this.balance = startAmount;
        }

        /// <summary>
        /// Method for delete banc account
        /// </summary>
        /// <returns>true if account mark as delete and false if he doesn`t mark as delete</returns>
        public bool DeleteBancAccount()
        {
            this.IsDelete = true;

            return this.IsDelete;
        }

        /// <summary>
        /// Method for deposit money on the bank account
        /// </summary>
        /// <param name="Amount">value for deposit money</param>
        /// <param name="userId">user`s identificator</param>
        /// <returns>state balance of bank account</returns>
        public decimal DepositMoney(decimal amount, int userId)
        {
            if (this.UserId != userId)
            {
                throw new AccessExceptions($"Access to the operation is prohibited");
            }

            if (amount > MAX_AMOUNT_DEPOSIT)
            {
                throw new ArgumentOutOfRangeException($"Deposit summ {amount} is very big for that operation");
            }

            // Verify that real money add in bank

            this.balance += amount;

            this.BonusPoints += BonusPointService.CalcBonusPointDepositMoney(this.BonusPoints, this.Balance);

            this.TypeAccount = TypeBankAccountService.VeryfyTypeBankAccount(this.Balance);

            return this.Balance;
        }

        /// <summary>
        /// Method for withdraw money on the bank account
        /// </summary>
        /// <param name="amount">value for withdraw money</param>
        /// <param name="userId">user`s identificator</param>
        /// <returns>state balance of bank account</returns>
        public decimal WithDrawMoney(decimal amount, int userId)
        {
            if(this.UserId != userId)
            {
                throw new AccessExceptions($"Access to the operation is prohibited");
            }

            if(amount > this.Balance)
            {
                throw new ArgumentOutOfRangeException($"WithDraw amount {nameof(amount)} less than balance");
            }

            if ((this.Balance - amount) < MIN_AMOUNT_STATE_BANK_ACCOUNT)
            {
                throw new ArgumentOutOfRangeException($"Remainder in BankAccount after operation expected is not valid");
            }

            // Verify that real money bank may pay user

            this.balance -= amount;

            this.BonusPoints = BonusPointService.CalcBonusPointWithDrawMoney(this.BonusPoints, this.Balance);

            this.TypeAccount = TypeBankAccountService.VeryfyTypeBankAccount(this.Balance);

            return this.Balance;
        }
    }
}
