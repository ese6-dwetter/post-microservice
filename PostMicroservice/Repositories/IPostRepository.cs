using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PostMicroservice.Entities;

namespace PostMicroservice.Repositories
{
    public interface IPostRepository : IBaseRepository<Post>
    {
        /// <summary>
        ///     Gets a list of all posts from a user by id.
        /// </summary>
        /// <param name="userId">The id of the user</param>
        /// <returns>Enumerable of all the posts of the user</returns>
        Task<IEnumerable<Post>> ReadByUserIdAsync(Guid userId);
        
        /// <summary>
        ///     Gets a Enumerable of all posts from the users.
        /// </summary>
        /// <param name="userIds">The ids of the users</param>
        /// <returns>Enumerable of all the posts of the users</returns>
        Task<IEnumerable<Post>> ReadByUserIds(IEnumerable<Guid> userIds);
    }
}
