using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task6.Entities;

namespace Task6.Interfaces
{
    /// <summary>
    /// Defines methods to manipulate collection of class Award instances at data access layer (DAL).
    /// </summary>
    public interface IAwardDaoInterface
    {
        /// <summary>
        /// Adds the award to the collection. 
        /// </summary>
        /// <param name="award"> Intance of class Award. </param>
        /// <returns> Intance of class Award. </returns>
        Award Add(Award award);

        /// <summary>
        /// Removes the award with corresponding id from the collection.
        /// </summary>
        /// <param name="id"> Award's id. </param>
        void Remove(int id);

        /// <summary>
        /// Returns contained in the collection instance of class Award with specified id.
        /// </summary>
        /// <param name="id"> Award's id. </param>
        /// <returns> The award specified by the id. </returns>
        Award GetById(int id);

        /// <summary>
        /// Adds users to the collection of users in the corresponding to the id instance of class Award.
        /// </summary>
        /// <param name="awardId"> Id of award to which users are added. </param>
        /// <param name="userIds"> Users added. </param>
        void AddUsers(int awardId, int[] userIds);

        /// <summary>
        /// Removes users from the collection of users in the corresponding to the id instance of class Award.
        /// </summary>
        /// <param name="awardId"> Id of award to which users are added. </param>
        /// <param name="userIds"> Users added. </param>
        void RemoveUsers(int awardId, int[] userIds);

        void ChangeTitle(int id, string newTitle);

        void ChangeImageLink(int id, string newImageLink);

        string GetImageLink(int id);

        /// <summary>
        /// Returns all awards which are contained in the collection.
        /// </summary>
        /// <returns> Enumerable set of awards. </returns>
        IEnumerable<Award> GetAll();
    }
}
