using System;

namespace PostMicroservice.Exceptions
{
    [Serializable]
    public class PostNotFoundException : Exception
    {
        public PostNotFoundException()
            : base("This post was not found.")
        {
        }
    }
}
