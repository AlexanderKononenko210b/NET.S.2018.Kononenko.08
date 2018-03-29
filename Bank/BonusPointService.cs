using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    /// <summary>
    /// Class for calculate bonus point
    /// </summary>
    public static class BonusPointService
    {
        /// <summary>
        /// Method calculate bonus point when bank account create
        /// </summary>
        /// <param name="depositValue">amount deposit</param>
        /// <returns>new bonus point</returns>
        public static int CalcBonusPointDepositMoneyOnStart(decimal depositValue)
        {
            var resultBonusPoint = (int)depositValue;

            return resultBonusPoint;
        }

        /// <summary>
        /// Method calculate bonus point when DepositMoney
        /// </summary>
        /// <param name="oldPoint">old point</param>
        /// <param name="depositValue">amount deposit</param>
        /// <returns>new bonus point</returns>
        public static int CalcBonusPointDepositMoney(int oldPoint, decimal depositValue)
        {
            var resultBonusPoint = oldPoint + (int)depositValue;

            return resultBonusPoint;
        }

        /// <summary>
        /// Method calculate bonus point when WithDrawMoney
        /// </summary>
        /// <param name="oldPoint">old point</param>
        /// <param name="depositValue">amount deposit</param>
        /// <returns>new bonus point</returns>
        public static int CalcBonusPointWithDrawMoney(int oldPoint, decimal depositValue)
        {
            var newBonusPoint = oldPoint - (int)(depositValue / 2);

            var resultBonusPoint = (newBonusPoint >= 0) ? newBonusPoint : 0;

            return resultBonusPoint;
        }
    }
}
