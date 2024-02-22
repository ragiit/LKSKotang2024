using EsemkaLibrary.Api.Models;
using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Threading;

namespace EsemkaLibrary.Api.Controllers
{
    [Route("api/")]
    [ApiController]
    public class EsemkaLibraryController : ControllerBase
    {
        private readonly EsemkaLibraryContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public EsemkaLibraryController(EsemkaLibraryContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginPost(LoginDto req)
        {
            var user = await _context.Users.AsNoTracking().FirstOrDefaultAsync(x => x.Username == req.Username && x.Password == req.Password);

            if (user is null)
            {
                return NotFound();
            }

            return Ok(new
            {
                Token = GenerateToken(user.Username!, user.Id.ToString()),
                Expires = DateTime.UtcNow.AddHours(1)
            });
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterPost(RegisterDto req)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Username!.ToLower().Trim() == req.Username!.ToLower().Trim());

            if (user is not null)
            {
                return Conflict("Username already exist");
            }

            await _context.Users.AddAsync(req.Adapt<User>());

            await _context.SaveChangesAsync();
            return Ok();
        }

        string GenerateToken(string username, string id)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes("this is my custom Secret key for authentication");
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, username),
                    new Claim(ClaimTypes.NameIdentifier, id),
                }),
                Expires = DateTime.UtcNow.AddHours(1), // token expires in 1 hour
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                Issuer = username
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        [Authorize]
        [HttpGet("me")]
        public async Task<IActionResult> MeGet()
        {
            var userId = Convert.ToInt32(User.Claims.FirstOrDefault(c => c.Type == System.Security.Claims.ClaimTypes.NameIdentifier)?.Value);

            var user = await _context.Users.AsNoTracking().FirstOrDefaultAsync(x => x.Id == userId);

            if (user is null)
            {
                return NotFound();
            }

            return Ok(user);
        }

         

        [Authorize]
        [HttpGet("books")]
        public async Task<IActionResult> BooksGet()
        {
            var books = await _context.Books.AsNoTracking().ToListAsync();

            return Ok(books);
        }

        [Authorize]
        [HttpGet("books/{id:int}/detail")]
        public async Task<IActionResult> BookDetailGet(int id)
        {
            var books = await _context.Books.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

            return Ok(books);
        }

        [Authorize]
        [HttpPost("books/{id:int}/like-book")]
        public async Task<IActionResult> BookLikePost(int id)
        {
            var book = await _context.Books.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
            if (book is null)
                return NotFound();

            var userId = Convert.ToInt32(User.Claims.FirstOrDefault(c => c.Type == System.Security.Claims.ClaimTypes.NameIdentifier)?.Value);

            var check = await _context.BookLikes.FirstOrDefaultAsync(x => x.UserId == userId);
            if (check is null)
                await _context.BookLikes.AddAsync(new BookLike
                {
                    LikeDate = DateTime.Now,
                    BookId = id,
                    UserId = userId,
                });
            else
                _context.BookLikes.Remove(check);

            await _context.SaveChangesAsync();

            return Ok();
        }

        [Authorize]
        [HttpPost("books/{id:int}/bookmark")]
        public async Task<IActionResult> BookmarkPost(int id)
        {
            var book = await _context.Books.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
            if (book is null)
                return NotFound();

            var userId = Convert.ToInt32(User.Claims.FirstOrDefault(c => c.Type == System.Security.Claims.ClaimTypes.NameIdentifier)?.Value);

            var check = await _context.Bookmarks.FirstOrDefaultAsync(x => x.UserId == userId);
            if (check is null)
                await _context.Bookmarks.AddAsync(new Bookmark
                {
                    BookmarkDate = DateTime.Now,
                    BookId = id,
                    UserId = userId,
                });
            else
                _context.Bookmarks.Remove(check);

            await _context.SaveChangesAsync();

            return Ok();
        }

        [Authorize]
        [HttpGet("my-bookmarks")]
        public async Task<IActionResult> BookmarksGet()
        {
            var userId = Convert.ToInt32(User.Claims.FirstOrDefault(c => c.Type == System.Security.Claims.ClaimTypes.NameIdentifier)?.Value);

            var bookmarks = await _context.Bookmarks.AsNoTracking().Where(x => x.UserId == userId).Select(x => x.BookId).ToListAsync();

            var books = await _context.Books.Where(x=> bookmarks.Contains(x.Id)).AsNoTracking().ToListAsync();

            return Ok(books);
        }

        [Authorize]
        [HttpGet("books-popular")]
        public async Task<IActionResult> BookPopularGet()
        {
            var popularBooks = await _context.BookLikes
                 .GroupBy(bl => bl.BookId)
                 .Select(group => new
                 {
                     BookId = group.Key,
                     TotalLikes = group.Count()
                 })
                 .OrderByDescending(x => x.TotalLikes)
                 .Take(3)
                 .ToListAsync();

            var top3BookIds = popularBooks.Select(x => x.BookId).ToList();

            var top3Books = await _context.Books
                .Where(b => top3BookIds.Contains(b.Id))
                .AsNoTracking()
                .ToListAsync();

            return Ok(top3Books);
        }
    }

    public class RegisterDto
    {
        [Required]
        public string? Username { get; set; } = string.Empty;
        [Required]
        public string? Password { get; set; } = string.Empty;
        [Required]
        public string? FullName { get; set; } = string.Empty;

        public string? Signature { get; set; }

    }

    public class LoginDto
    {
        [Required]
        public string Username { get; set; } = string.Empty;

        [Required]
        public string Password { get; set; } = string.Empty;
    }
}
