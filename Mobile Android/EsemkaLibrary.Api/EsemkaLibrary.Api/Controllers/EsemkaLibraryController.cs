using EsemkaLibrary.Api.Models;
using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

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
                Expires = DateTime.UtcNow.AddMinutes(2)
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

        [HttpGet("users")]
        public async Task<IActionResult> UsersGet()
        {
            var userId = Convert.ToInt32(User.Claims.FirstOrDefault(c => c.Type == System.Security.Claims.ClaimTypes.NameIdentifier)?.Value);

            var users = await _context.Users
                .OrderByDescending(x => x.Id == userId)
                .Select(x => new
                {
                    x.Id,
                    x.Username,
                    x.FullName,
                    DateOfBirth = x.DateOfBirth.GetValueOrDefault().ToString("ddd, MMM yyyy"),
                    x.Motto,
                    JoinDate = x.JoinDate.ToString("ddd, MMMM yyyy")
                }).AsNoTracking().ToListAsync();

            return Ok(users);
        }

        [Authorize]
        [HttpPost("books/{id:int}/like-book")]
        public async Task<IActionResult> BookLikePost(int id)
        {
            var book = await _context.Books.Include(x => x.Categories).Include(x => x.BookContents).AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
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
            var book = await _context.Books.Include(x => x.Categories).Include(x => x.BookContents).AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
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

        private string GenerateToken(string username, string id)
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
                Expires = DateTime.UtcNow.AddMinutes(2), // token expires in 1 hour
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
            var a = await _context.BookCategories.ToListAsync();
            var books = await _context.Books
                .Include(x => x.Categories)
                .Include(x => x.BookContents)
                .Include(x => x.BookLikes)
                .AsNoTracking()
                .Select(x => new
                {
                    x.Id,
                    x.Title,
                    x.Author,
                    x.PublicationYear,
                    x.Isbn,
                    x.Cover,
                    Content = string.Join(", ", x.BookContents.Select(z => z.Content)),
                    Category = string.Join(", ", x.Categories.Select(z => z.CategoryName)),
                    Likes = x.BookLikes.Count()
                })
                .ToListAsync();

            return Ok(books);
        }

        [Authorize]
        [HttpGet("books/{id:int}/detail")]
        public async Task<IActionResult> BookDetailGet(int id)
        {
            var books = await _context.Books.Include(x => x.Categories).Include(x => x.BookContents).AsNoTracking().Select(x => new
            {
                x.Id,
                x.Title,
                x.Author,
                x.PublicationYear,
                x.Isbn,
                x.Cover,
                Content = string.Join(", ", x.BookContents.Select(z => z.Content)),
                Category = string.Join(", ", x.Categories.Select(z => z.CategoryName)),
                Likes = x.BookLikes.Count()
            }).FirstOrDefaultAsync(x => x.Id == id);

            return Ok(books);
        }

        [Authorize]
        [HttpGet("my-bookmarks")]
        public async Task<IActionResult> BookmarksGet()
        {
            var userId = Convert.ToInt32(User.Claims.FirstOrDefault(c => c.Type == System.Security.Claims.ClaimTypes.NameIdentifier)?.Value);

            var bookmarks = await _context.Bookmarks.AsNoTracking().Where(x => x.UserId == userId).Select(x => x.BookId).ToListAsync();

            var books = await _context.Books.Where(x => bookmarks.Contains(x.Id)).Select(x => new
            {
                x.Id,
                x.Title,
                x.Author,
                x.PublicationYear,
                x.Isbn,
                x.Cover,
                Content = string.Join(", ", x.BookContents.Select(z => z.Content)),
                Category = string.Join(", ", x.Categories.Select(z => z.CategoryName)),
                Likes = x.BookLikes.Count()
            }).AsNoTracking().ToListAsync();

            return Ok(books);
        }

        private class BookTemp
        {
            public int Id { get; set; }
            public int Count { get; set; }
        }

        [Authorize]
        [HttpGet("books-popular")]
        public async Task<IActionResult> BookPopularGet()
        {
            var temp = new List<BookTemp>();

            var books = await _context.Books.Include(x => x.BookLikes).Include(x => x.BookContents).Include(x => x.Categories).AsNoTracking().ToListAsync();
            var bookLikes = await _context.BookLikes.AsNoTracking().ToListAsync();

            foreach (var item in books)
            {
                temp.Add(new BookTemp
                {
                    Id = item.Id,
                    Count = bookLikes.Where(x => x.BookId == item.Id).Count(),
                });
            }

            var temps = temp.OrderByDescending(x => x.Count).Take(3).Select(x => x.Id);

            var q = new List<Book>();
            foreach (var item in temps)
            {
                q.Add(books.FirstOrDefault(x => x.Id == item)!);
            }

            return Ok(q.Select(x => new
            {
                x.Id,
                x.Title,
                x.Author,
                x.PublicationYear,
                x.Isbn,
                x.Cover,
                Content = string.Join(", ", x.BookContents.Select(z => z.Content)),
                Category = string.Join(", ", x.Categories.Select(z => z.CategoryName)),
                Likes = x.BookLikes.Count()
            }));
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

        public string? Motto { get; set; }
        public DateTime? DateOfBirth { get; set; }
    }

    public class LoginDto
    {
        [Required]
        public string Username { get; set; } = string.Empty;

        [Required]
        public string Password { get; set; } = string.Empty;
    }
}