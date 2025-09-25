using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SocialMedia.Models;
using SocialMedia.Services;

namespace SocialMedia.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly IPostService _postService;

        public PostsController(IPostService postService)
        {
            _postService = postService;
        }

        [ServiceFilter(typeof(ExecutionTimeFilter))]
        [HttpGet]
        public async Task<IActionResult> GetAllPosts()
        {
            var posts = await _postService.GetAllPostsWithDetailsAsync();
            return Ok(posts);
        }
        [ServiceFilter(typeof(ExecutionTimeFilter))]
        [HttpGet ("{id}")]
        public async Task<IActionResult> GetPost(int id)
        {
            var post = await _postService.GetSinglePostWithDetailsAsync(id);
            if (post == null) return NotFound();
            return Ok(post);
        }
    }
}
