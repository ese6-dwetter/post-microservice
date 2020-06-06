using System;
using System.ComponentModel.DataAnnotations;

namespace PostMicroservice.Models
{
    public class CreatePostModel
    {
        [Required] [StringLength(256, MinimumLength = 1)] public string Content { get; set; }
        [Required] public Guid UserId { get; set; }
        [Required] public string Username { get; set; }
    }
}
