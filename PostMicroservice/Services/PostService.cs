﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PostMicroservice.Entities;
using PostMicroservice.Exceptions;
using PostMicroservice.Helpers;
using PostMicroservice.Repositories;

namespace PostMicroservice.Services
{
    public class PostService : IPostService
    {
        private readonly IPostRepository _repository;
        private readonly ITokenGenerator _tokenGenerator;

        public PostService(IPostRepository repository, ITokenGenerator tokenGenerator)
        {
            _repository = repository;
            _tokenGenerator = tokenGenerator;
        }

        public async Task<Post> GetPostByIdAsync(Guid id)
        {
            var post = await _repository.ReadByIdAsync(id)
                       ?? throw new PostNotFoundException();

            return post;
        }

        public async Task<IEnumerable<Post>> GetPostsAsync()
        {
            return await _repository.ReadAsync();
        }

        public async Task<Post> CreatePostAsync(string content, string token)
        {
            var id = Guid.Parse(_tokenGenerator.GetJwtClaim(token, "nameid"));
            var username = _tokenGenerator.GetJwtClaim(token, "unique_name");

            if (id == null || username == null)
                throw new UnauthorizedAccessException();

            var post = await _repository.CreateAsync(new Post
            {
                Content = content,
                DateTime = DateTime.UtcNow,
                User = new User
                {
                    Id = id,
                    Username = username
                }
            });

            return post;
        }

        public async Task DeletePostByIdAsync(Guid id)
        {
            await _repository.DeleteByIdAsync(id);
        }

        public async Task<IEnumerable<Post>> GetPostsByUserIdAsync(Guid userId)
        {
            var posts = await _repository.ReadByUserIdAsync(userId)
                        ?? throw new PostNotFoundException();

            return posts;
        }

        public async Task<Post> LikePostByIdAsync(Guid postId, string token)
        {
            var id = Guid.Parse(_tokenGenerator.GetJwtClaim(token, "nameid"));
            var username = _tokenGenerator.GetJwtClaim(token, "unique_name");

            if (id == null || username == null)
                throw new UnauthorizedAccessException();

            var post = await _repository.ReadByIdAsync(postId)
                       ?? throw new PostNotFoundException();

            if (post.Likes.ToList().Find(x => x.User.Id == id) != null)
                throw new AlreadyLikedException();

            post.Likes.ToList().Add(new Like
            {
                DateTime = DateTime.UtcNow,
                User = new User
                {
                    Id = id,
                    Username = username
                }
            });

            return await _repository.UpdateAsync(postId, post);
        }

        public async Task<Post> UnlikePostByIdAsync(Guid postId, string token)
        {
            var id = Guid.Parse(_tokenGenerator.GetJwtClaim(token, "nameid"));

            if (id == null)
                throw new UnauthorizedAccessException();

            var post = await _repository.ReadByIdAsync(postId)
                       ?? throw new PostNotFoundException();

            post.Likes.ToList().RemoveAll(x => x.User.Id == id);

            return await _repository.UpdateAsync(postId, post);
        }
    }
}
