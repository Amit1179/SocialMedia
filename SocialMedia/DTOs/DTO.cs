namespace SocialMedia.DTOs
{
    public class DTO
    {
    }
    public class PostDto
    {
        public int PostId { get; set; }
        public string Content { get; set; }
        public UserDto CreatedBy { get; set; }
        public int TotalComments { get; set; }
        public List<CommentDto> Comments { get; set; }
        public List<PostLikeDto> Likes { get; set; }
    }

    public class UserDto
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
    }

    public class CommentDto
    {
        public int CommentId { get; set; }
        public string Text { get; set; }
        public string CommentedBy { get; set; }
        public int ReactionsCount { get; set; }
    }

    public class PostLikeDto
    {
        public string UserName { get; set; }
        public DateTime LikedAt { get; set; }
    }

    public class Post
    {
        public int PostId { get; set; }
        public string Content { get; set; }
        public int UserId { get; set; }
        public User CreatedBy { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public ICollection<PostLike> Likes { get; set; }
    }

    public class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
    }

    public class Comment
    {
        public int CommentId { get; set; }
        public string Text { get; set; }
        public int PostId { get; set; }
        public int UserId { get; set; }
        public User CommentedBy { get; set; }
        public ICollection<CommentReaction> Reactions { get; set; }
    }

    public class PostLike
    {
        public int PostLikeId { get; set; }
        public int PostId { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public DateTime LikedAt { get; set; }
    }

    public class CommentReaction
    {
        public int ReactionId { get; set; }
        public int CommentId { get; set; }
    }
}
