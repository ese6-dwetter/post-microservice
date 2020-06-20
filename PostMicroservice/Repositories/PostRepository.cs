using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;
using PostMicroservice.Entities;
using PostMicroservice.Settings;

namespace PostMicroservice.Repositories
{
    public class PostRepository : BaseRepository<Post>, IPostRepository
    {
        public PostRepository(IDatabaseSettings databaseSettings) : base(databaseSettings)
        {
        }

        public async Task<List<Post>> ReadByUserIdAsync(Guid userId)
        {
            return await Collection.Find(post => post.User.Id == userId).ToListAsync();
        }

        public async Task<List<Post>> ReadByUserIds(IEnumerable<Guid> userIds)
        {
            var posts = new List<Post>();
            
            foreach (var userId in userIds)
            {
                posts.AddRange(await Collection.Find(post => post.User.Id == userId).ToListAsync());
            }

            return posts;
        }
    }
}
