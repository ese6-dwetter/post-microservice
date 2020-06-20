using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PostMicroservice.Entities;

namespace PostMicroservice.Services
{
    public interface IPostService
    {
        
        /// <summary>
        /// Get post by id.
        /// </summary>
        /// <returns>Post by id</returns>
        Task<Post> GetPostByIdAsync(Guid id);

        Task<List<Post>> GetPostsAsync();

        Task<Post> CreatePostAsync(string content, string token);
        
        Task DeletePostByIdAsync(Guid id);
        
        /// <summary>
        /// Get posts from a user by id.
        /// </summary>
        /// <returns>List of posts by user id</returns>
        Task<List<Post>> GetPostsByUserIdAsync(Guid userId);

        Task<Post> AddLikeToPostAsync(Guid postId, string token);
        
        Task<Post> RemoveLikeFromPostAsync(Guid postId, string token);
    }
}
