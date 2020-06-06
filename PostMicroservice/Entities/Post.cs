using System;
using System.Collections.Generic;

namespace PostMicroservice.Entities
{
    public class Post : BaseEntity
    {
        public string Content { get; set; }
        public DateTime DateTime { get; set; }
        public User User { get; set; }
        public IEnumerable<Like> Likes { get; set; }
    }
}
