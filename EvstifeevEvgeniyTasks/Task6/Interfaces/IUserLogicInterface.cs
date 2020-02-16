using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task6.Entities;

namespace Task6.Interfaces
{
    /// <summary>
    /// Defines methods to manipulate collection of class User instances at business logic layer (BLL).
    /// </summary>
    public interface IUserLogicInterface
    {
        /// <summary>
        /// Adds the user to the collection. 
        /// </summary>
        /// <param name="user">  </param>
        /// <returns>  </returns>
        User Add(User user);

        /// <summary>
        /// Removes the user with corresponding id from the collection.
        /// </summary>
        /// <param name="id"> User's id. </param>
        void Remove(int id);

        /// <summary>
        /// Returns contained in the collection instance of class Award with specified id.
        /// </summary>
        /// <param name="id"> User's id. </param>
        /// <returns> The award specified by the id. </returns>
        User GetById(int id);

        /// <summary>
        /// Adds awards to the collection of awards in the corresponding to the id instance of class User.
        /// </summary>
        /// <param name="userId"> Id of user to which awards are added. </param>
        /// <param name="awardsIds"> Awards added. </param>
        void AddAwards(int userId, int[] awardsIds);

        /// <summary>
        /// Removes awards from the collection of awards in the corresponding to the id instance of class User.
        /// </summary>
        /// <param name="userId"> Id of user to which awards are added. </param>
        /// <param name="awardsIds"> Awards added. </param>
        void RemoveAwards(int userId, int[] awardsIds);

        void ChangeName(int id, string newName);

        void ChangeDateOfBirth(int id, DateTime newDateOfBirth);

        void ChangeImageLink(int id, string newImageLink);

        string GetImageLink(int id);

        /// <summary>
        /// Returns all users which are contained in the collection.
        /// </summary>
        /// <returns> Enumerable set of users. </returns>
        IEnumerable<User> GetAll();
    }
}
