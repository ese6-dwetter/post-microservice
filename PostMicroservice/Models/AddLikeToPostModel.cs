using System;
using System.ComponentModel.DataAnnotations;

namespace PostMicroservice.Models
{
    public class AddLikeToPostModel
    {
        [Required] public Guid PostId { get; set; }
        [Required] public Guid UserId { get; set; }
        [Required] public string Username { get; set; }
    }
}
