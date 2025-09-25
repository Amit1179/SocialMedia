namespace SocialMedia.Models
{
    public class Comment
    {
        public int CommentId { get; set; }
        public string Text { get; set; } = string.Empty;
        public int PostId { get; set; }
        public Post Post { get; set; }
        public int CommentedById { get; set; }
        public User CommentedBy { get; set; }
        public ICollection<Reaction> Reactions { get; set; }
    }
}
