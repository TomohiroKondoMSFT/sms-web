using Microsoft.AspNetCore.Identity;

namespace SmsWeb.Models;

public class ApplicationUser : IdentityUser
{
    public int? StudentId { get; set; }
    public Student? Student { get; set; }
    public int? TeacherId { get; set; }
}
