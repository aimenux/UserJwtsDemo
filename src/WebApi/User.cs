using System.Security.Claims;

namespace WebApi;

public sealed class User
{
    public string? Name { get; init; }
    public string? Role { get; init; }

    public static User Create(HttpContext context)
    {
        var user = context.User;
        var name = user.Identity?.Name ?? "Anonymous";
        var role = user.FindFirstValue(ClaimTypes.Role) ?? "None";
        return new User { Name = name, Role = role };
    }
}