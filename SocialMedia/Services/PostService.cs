using SocialMedia.DTOs;
using SocialMedia.Models;
using SocialMedia.Repositories;

namespace SocialMedia.Services
{
    public class PostService : IPostService
    {
        private readonly IPostRepo _postRepo;

        public PostService(IPostRepo postRepo)
        {
            _postRepo = postRepo;
        }

        public async Task<List<PostDto>> GetAllPostsWithDetailsAsync()
        {
            return await _postRepo.GetPostsWithDetailsAsync();
        }

        public async Task<PostDto?> GetSinglePostWithDetailsAsync(int postId)
        {
            return await _postRepo.GetPostWithDetailsByIdAsync(postId);
        }
    }
}
