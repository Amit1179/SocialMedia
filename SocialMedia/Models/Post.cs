namespace SocialMedia.Models
{
    public class Post
    {
        public int PostId { get; set; }
        public string PostContent { get; set; } = string.Empty;

        public int CreatedById { get; set; }

        public User CreatedBy { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public ICollection<Like> Likes { get; set; }  
    }
}
