using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SmsWeb.Data;
using SmsWeb.Models;

namespace SmsWeb.Pages.Student;

[Authorize(Roles = "Student")]
public class ProfileModel : PageModel
{
    private readonly ApplicationDbContext _db;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public ProfileModel(ApplicationDbContext db, IHttpContextAccessor httpContextAccessor)
    {
        _db = db;
        _httpContextAccessor = httpContextAccessor;
    }

    public Models.Student? StudentData { get; set; }
    public IList<Models.Attendance> RecentAttendances { get; set; } = new List<Models.Attendance>();

    public async Task OnGetAsync()
    {
        var userName = User.Identity?.Name;
        var user = await _db.Users
            .Include(u => ((ApplicationUser)u).Student)
            .OfType<ApplicationUser>()
            .FirstOrDefaultAsync(u => u.UserName == userName);

        if (user?.StudentId != null)
        {
            StudentData = await _db.Students.FindAsync(user.StudentId);
            RecentAttendances = await _db.Attendances
                .Where(a => a.StudentId == user.StudentId)
                .OrderByDescending(a => a.Date)
                .Take(10)
                .ToListAsync();
        }
    }
}
