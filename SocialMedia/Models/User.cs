using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Microsoft.Extensions.Hosting;

namespace SocialMedia.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; } = string.Empty;
        public ICollection<Post> Posts { get; set; }
        public ICollection<Like> Likes { get; set; }
        public ICollection<Comment> Comments { get; set; }
    }

}