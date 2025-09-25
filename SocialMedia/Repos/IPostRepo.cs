using SocialMedia.DTOs;
using SocialMedia.Models;

namespace SocialMedia.Repositories
{
    public interface IPostRepo
    {

         Task<List<PostDto>> GetPostsWithDetailsAsync();
         Task<PostDto?> GetPostWithDetailsByIdAsync(int postId);
    }
}
