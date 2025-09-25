namespace SocialMedia.Models
{
    public class Reaction
    {
        public int ReactionId { get; set; }
        public int CommentId { get; set; }
        public Comment Comment { get; set; }
    }
}
