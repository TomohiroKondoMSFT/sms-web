using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SmsWeb.Data;
using StudentEntity = SmsWeb.Models.Student;

namespace SmsWeb.Pages.Admin.Students;

[Authorize(Roles = "Admin")]
public class CreateModel : PageModel
{
    private readonly ApplicationDbContext _db;

    public CreateModel(ApplicationDbContext db) => _db = db;

    [BindProperty]
    public StudentEntity Student { get; set; } = new();

    public void OnGet() { }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid) return Page();

        _db.Students.Add(Student);
        await _db.SaveChangesAsync();
        return RedirectToPage("Index");
    }
}
