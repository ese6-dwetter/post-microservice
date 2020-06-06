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
    }
}
