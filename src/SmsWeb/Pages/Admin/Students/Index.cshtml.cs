using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SmsWeb.Data;
using StudentEntity = SmsWeb.Models.Student;

namespace SmsWeb.Pages.Admin.Students;

[Authorize(Roles = "Admin")]
public class IndexModel : PageModel
{
    private readonly ApplicationDbContext _db;

    public IndexModel(ApplicationDbContext db) => _db = db;

    public IList<StudentEntity> Students { get; set; } = new List<StudentEntity>();

    public async Task OnGetAsync()
    {
        Students = await _db.Students.OrderBy(s => s.Roll).ToListAsync();
    }

    public async Task<IActionResult> OnPostDeleteAsync(int id)
    {
        var student = await _db.Students.FindAsync(id);
        if (student != null)
        {
            _db.Students.Remove(student);
            await _db.SaveChangesAsync();
        }
        return RedirectToPage();
    }
}
