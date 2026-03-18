using Microsoft.AspNetCore.Mvc;

namespace User_Management_API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private static readonly List<User> Users = new()
    {
        new User
        {
            Id = 1,
            FirstName = "Jan",
            LastName = "Kowalski",
            Email = "jan.kowalski@example.com",
        },
        new User
        {
            Id = 2,
            FirstName = "Anna",
            LastName = "Nowak",
            Email = "anna.nowak@example.com",
        },
    };

    [HttpGet]
    public ActionResult<IEnumerable<UserResponseDto>> GetAll()
    {
        var result = Users.Select(MapToResponse).ToList();
        return Ok(result);
    }

    [HttpGet("{id:int}")]
    public ActionResult<UserResponseDto> GetById(int id)
    {
        var user = Users.FirstOrDefault(u => u.Id == id);
        if (user is null)
        {
            return NotFound($"User with id {id} not found.");
        }
        return Ok(MapToResponse(user));
    }

    [HttpPost]
    public ActionResult<UserResponseDto> Create(UserCreateDto request)
    {
        int userId = Users.Count == 0 ? 1 : Users.Max(u => u.Id) + 1;
        var user = new User
        {
            Id = userId,
            FirstName = request.FirstName,
            LastName = request.LastName,
            Email = request.Email,
        };

        Users.Add(user);

        var response = MapToResponse(user);
        return CreatedAtAction(nameof(GetById), new { id = user.Id }, response);
    }

    [HttpPut("{id:int}")]
    public ActionResult<UserResponseDto> Update(int id, UserUpdateDto request)
    {
        var user = Users.FirstOrDefault(u => u.Id == id);
        if (user is null)
        {
            return NotFound($"User not found with id {id}.");
        }

        user.FirstName = request.FirstName;
        user.LastName = request.LastName;
        user.Email = request.Email;

        return Ok(MapToResponse(user));
    }

    [HttpDelete("{id:int}")]
    public IActionResult Delete(int id)
    {
        var user = Users.FirstOrDefault(u => u.Id == id);
        if (user is null)
        {
            return NotFound($"User with id {id} not found.");
        }

        Users.Remove(user);
        return NoContent();
    }

    private static UserResponseDto MapToResponse(User user)
    {
        return new UserResponseDto(user.Id, user.FirstName, user.LastName, user.Email);
    }
}

public sealed class User
{
    public int Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
}

public record UserCreateDto(string FirstName, string LastName, string Email);

public record UserUpdateDto(string FirstName, string LastName, string Email);

public record UserResponseDto(int Id, string FirstName, string LastName, string Email);
