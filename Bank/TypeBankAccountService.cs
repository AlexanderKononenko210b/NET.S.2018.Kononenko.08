using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    /// <summary>
    /// Class verify type bank account
    /// </summary>
    public static class TypeBankAccountService
    {
        private static readonly decimal baseBorder = 1000;

        private static readonly decimal silverBorder = 10000;

        private static readonly decimal goldBorder = 100000;

        /// <summary>
        /// Method for verify type bank account
        /// </summary>
        /// <param name="inputAmount"></param>
        /// <returns>type banc account</returns>
        public static EnumTypeAccount VeryfyTypeBankAccount(decimal inputAmount)
        {
            return (inputAmount <= baseBorder) ? EnumTypeAccount.Base : (inputAmount <= silverBorder) ?
                EnumTypeAccount.Silver : (inputAmount <= goldBorder) ? EnumTypeAccount.Gold : EnumTypeAccount.Platinum;
        }
    }
}
