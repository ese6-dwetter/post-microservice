using PostMicroservice.Entities;
using PostMicroservice.Settings;

namespace PostMicroservice.Repositories
{
    public class PostRepository : BaseRepository<Post>, IPostRepository
    {
        public PostRepository(IDatabaseSettings databaseSettings) : base(databaseSettings)
        {
        }
    }
}
