using System;

namespace PostMicroservice.Exceptions
{
    [Serializable]
    public class AlreadyLikedException : Exception
    {
        public AlreadyLikedException()
            : base("This post is already liked.")
        {
        }
    }
}
