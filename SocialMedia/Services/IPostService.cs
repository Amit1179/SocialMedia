using SocialMedia.DTOs;
using SocialMedia.Models;

namespace SocialMedia.Services
{
    public interface IPostService
    {
        Task<List<PostDto>> GetAllPostsWithDetailsAsync();
        Task<PostDto?> GetSinglePostWithDetailsAsync(int postId);
    }
}
