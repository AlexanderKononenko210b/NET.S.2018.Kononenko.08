using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    /// <summary>
    /// Service for get new number of bank account
    /// </summary>
    public sealed class NumberBankAccountService
    {
        /// <summary>
        /// Account number in the bank's accounting plan
        /// </summary>
        private const string NUMBER_BANKING_ACCOUNTING = "40512";

        /// <summary>
        /// Check digit of the account
        /// </summary>
        private const int SPECIAL_NUMBER = 1;

        /// <summary>
        /// Number faffliate of bank
        /// </summary>
        private const string NUMBER_FAFFLIATE_BANK = "0079";

        private const int NUMBER_DIGIT_COUNT_BANK_ACCOUNT_IN_FAFFLIATE = 10;

        private int countBankAccountInFaffliate;

        private static NumberBankAccountService instance;

        private static readonly object padlock = new object();

        private NumberBankAccountService() { }
        
        public static NumberBankAccountService Instance
        {
            get
            {
                if(instance == null)
                {
                    lock (padlock)
                    {
                        if (instance == null)
                        {
                            instance = new NumberBankAccountService();
                        }
                    }
                }

                return instance;
            }
        }

        public int CountBankAccountInFaffliate
        {
            get { return countBankAccountInFaffliate; }

            private set
            {
                countBankAccountInFaffliate = value;
            }
        }

        /// <summary>
        /// Method for number bank account
        /// </summary>
        /// <returns></returns>
        public string GetNextNumberBankAccount()
        {
            var result = $"{NUMBER_BANKING_ACCOUNTING}{SPECIAL_NUMBER}" +
                $"{NUMBER_FAFFLIATE_BANK}{GetNumberCountBankAccountInFaffliate(++this.CountBankAccountInFaffliate)}";

            return result;
        }

        /// <summary>
        /// Helper method for generate CountBankAccountInFaffliate in string format
        /// </summary>
        /// <param name="inputNumber"></param>
        /// <returns></returns>
        private string GetNumberCountBankAccountInFaffliate(int inputNumber)
        {
            int number = 0, helperNumber = inputNumber;

            while(helperNumber > 0)
            {
                number++;

                helperNumber /= 10;
            }

            return $"{new String('0', NUMBER_DIGIT_COUNT_BANK_ACCOUNT_IN_FAFFLIATE - number)}{inputNumber}";
        }
    }
}
