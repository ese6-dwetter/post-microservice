using System;
using System.ComponentModel.DataAnnotations;

namespace PostMicroservice.Models
{
    public class RemoveLikeFromPostModel
    {
        [Required] public Guid PostId { get; set; }
        [Required] public Guid UserId { get; set; }
    }
}
