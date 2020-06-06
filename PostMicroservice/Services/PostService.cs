using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PostMicroservice.Entities;
using PostMicroservice.Exceptions;
using PostMicroservice.Repositories;

namespace PostMicroservice.Services
{
    public class PostService : IPostService
    {
        private readonly IPostRepository _repository;

        public PostService(IPostRepository repository)
        {
            _repository = repository;
        }

        public async Task<Post> GetPostByIdAsync(Guid id)
        {
            var post = await _repository.ReadByIdAsync(id)
                       ?? throw new PostNotFoundException();

            return post;
        }

        public async Task<List<Post>> GetPostsAsync()
        {
            return await _repository.ReadAsync();
        }

        public async Task<Post> CreatePostAsync(string content, Guid userId, string username)
        {
            var post = await _repository.CreateAsync(new Post
            {
                Content = content,
                DateTime = DateTime.Now,
                User = new User
                {
                    Id = userId,
                    Username = username
                }
            });

            return post;
        }

        public async Task DeletePostByIdAsync(Guid id)
        {
            await _repository.DeleteByIdAsync(id);
        }

        public async Task<List<Post>> GetPostsByUserIdAsync(Guid userId)
        {
            var posts = await _repository.ReadByUserIdAsync(userId)
                        ?? throw new PostNotFoundException();

            return posts;
        }

        public async Task<Post> AddLikeToPostAsync(Guid postId, Guid userId, string username)
        {
            var post = await _repository.ReadByIdAsync(postId)
                       ?? throw new PostNotFoundException();

            post.Likes.ToList().Add(new Like
            {
                DateTime = DateTime.Now,
                User = new User
                {
                    Id = userId,
                    Username = username
                }
            });

            return await _repository.UpdateAsync(postId, post);
        }

        public async Task<Post> RemoveLikeFromPostAsync(Guid postId, Guid userId)
        {
            var post = await _repository.ReadByIdAsync(postId)
                       ?? throw new PostNotFoundException();

            post.Likes.ToList().RemoveAll(x => x.User.Id == userId);

            return await _repository.UpdateAsync(postId, post);
        }
    }
}
