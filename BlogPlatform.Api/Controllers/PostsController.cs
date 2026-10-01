using BlogPlatform.Api.Data;
using BlogPlatform.Api.DTOs;
using BlogPlatform.Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlogPlatform.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly BlogContext _context;

        public PostsController(BlogContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetPosts(string? term)
        {
            // New thing I learned :)
            IQueryable<Post> query = _context.Posts;

            if (!string.IsNullOrEmpty(term))
            {
                string lowercaseTerm = term.ToLower();
                query = query.Where(post => post.Title.ToLower().Contains(lowercaseTerm) || post.Content.ToLower().Contains(lowercaseTerm) || post.Category.ToLower().Contains(lowercaseTerm));
            }

            List<PostSummaryDto> posts = await query.Select(post => new PostSummaryDto
            {
                Id = post.Id,
                Title = post.Title,
                Content = post.Content,
                Category = post.Category,
                Tags = post.Tags,
                CreatedAt = post.CreatedAt,
                UpdatedAt = post.UpdatedAt,

            }).ToListAsync();

            return Ok(posts);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPost(int id)
        {
            Post? post = await _context.Posts.FindAsync(id);

            if (post is null)
            {
                return NotFound();
            }

            PostDetailsDto PostDetails = new PostDetailsDto()
            {
                Id = post.Id,
                Title = post.Title,
                Content = post.Content,
                Category = post.Category,
                Tags = post.Tags,
                CreatedAt = post.CreatedAt,
                UpdatedAt = post.UpdatedAt
            };

            return Ok(PostDetails);
        }

        [HttpPost]
        public async Task<ActionResult> PostBlog(CreatePostDto newPostItemDto)
        {
            Post newPost = new Post()
            {
                Title = newPostItemDto.Title,
                Content = newPostItemDto.Content,
                Category = newPostItemDto.Category,
                Tags = newPostItemDto.Tags,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
            };

            _context.Posts.Add(newPost);
            await _context.SaveChangesAsync();

            CreatePostResponseDto responseDto = new CreatePostResponseDto()
            {
                Id = newPost.Id,
                Title = newPostItemDto.Title,
                Content = newPostItemDto.Content,
                Category = newPostItemDto.Category,
                Tags = newPostItemDto.Tags,
                CreatedAt = newPost.CreatedAt,
                UpdatedAt = newPost.UpdatedAt,
            };


            return CreatedAtAction(
                nameof(GetPost),
                new { Id = newPost.Id },
                responseDto
                );
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutPost(int id, UpdatePost updatingPost)
        {
            Post? requestedPost = await _context.Posts.FindAsync(id);

            if (requestedPost is null)
            {
                return NotFound();
            }

            requestedPost.Title = updatingPost.Title;
            requestedPost.Content = updatingPost.Content;
            requestedPost.Category = updatingPost.Category;
            requestedPost.Tags = updatingPost.Tags;
            requestedPost.UpdatedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync();

            return Ok(requestedPost);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePost(int id)
        {
            Post? requestedPost = await _context.Posts.FindAsync(id);

            if (requestedPost is null)
            {
                return NotFound();
            }

            _context.Posts.Remove(requestedPost);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
