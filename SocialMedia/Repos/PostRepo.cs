using Microsoft.EntityFrameworkCore;
using SocialMedia.Data;
using SocialMedia.DTOs;
using SocialMedia.Models;
using SocialMedia.Repositories;

namespace SocialMedia.Repos
{
    public class PostRepo : IPostRepo
    {
        private readonly SocialMediaDbContext _context;

        public PostRepo(SocialMediaDbContext context)
        {
            _context = context;
        }

        public async Task<PostDto?> GetPostWithDetailsByIdAsync(int postId)
        {
            return await _context.Posts
            .Where(p => p.PostId == postId)
            .Include(p => p.CreatedBy)
            .Include(p => p.Likes)
                .ThenInclude(l => l.User)
            .Include(p => p.Comments)
                .ThenInclude(c => c.CommentedBy)
            .Include(p => p.Comments)
                .ThenInclude(c => c.Reactions)
            .Select(p => new PostDto
            {
                PostId = p.PostId,
                Content = p.PostContent,
                CreatedBy = new UserDto
                {
                    UserId = p.CreatedBy.UserId,
                    UserName = p.CreatedBy.UserName
                },
                TotalComments = p.Comments.Count(),
                Comments = p.Comments.Select(c => new CommentDto
                {
                    CommentId = c.CommentId,
                    Text = c.Text,
                    CommentedBy = c.CommentedBy.UserName,
                    ReactionsCount = c.Reactions.Count()
                }).ToList(),
                Likes = p.Likes.Select(l => new PostLikeDto
                {
                    UserName = l.User.UserName,
                    LikedAt = l.LikedAt
                }).ToList()
            })
            .FirstOrDefaultAsync();
        }

        public async Task<List<PostDto>> GetPostsWithDetailsAsync()
        {
            return await _context.Posts
            .Include(p => p.CreatedBy)
            .Include(p => p.Likes)
                .ThenInclude(l => l.User)
            .Include(p => p.Comments)
                .ThenInclude(c => c.CommentedBy)
            .Include(p => p.Comments)
                .ThenInclude(c => c.Reactions)
            .Select(p => new PostDto
            {
                PostId = p.PostId,
                Content = p.PostContent,
                CreatedBy = new UserDto
                {
                    UserId = p.CreatedBy.UserId,
                    UserName = p.CreatedBy.UserName
                },
                TotalComments = p.Comments.Count(),
                Comments = p.Comments.Select(c => new CommentDto
                {
                    CommentId = c.CommentId,
                    Text = c.Text,
                    CommentedBy = c.CommentedBy.UserName,
                    ReactionsCount = c.Reactions.Count()
                }).ToList(),
                Likes = p.Likes.Select(l => new PostLikeDto
                {
                    UserName = l.User.UserName,
                    LikedAt = l.LikedAt
                }).ToList()
            })
            .ToListAsync();
        }
    }
}
