using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task6.Entities
{
    /// <summary>
    /// Element representing a pair of two integers: user's id and award's id.
    /// </summary>
    public class UserAwardPair
    {
        #region UserAward fields
        public int UserId = 0;
     
        public int AwardId = 0;
        #endregion

        #region UserAward constructor
        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"> User's id. </param>
        /// <param name="awardId"> Award's id. </param>
        public UserAwardPair(int userId, int awardId) 
        {
            this.UserId = userId;
            this.AwardId = awardId;
        }
        #endregion
    }
}
