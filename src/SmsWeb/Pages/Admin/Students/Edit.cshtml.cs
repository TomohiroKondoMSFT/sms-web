using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SmsWeb.Data;
using StudentEntity = SmsWeb.Models.Student;

namespace SmsWeb.Pages.Admin.Students;

[Authorize(Roles = "Admin")]
public class EditModel : PageModel
{
    private readonly ApplicationDbContext _db;

    public EditModel(ApplicationDbContext db) => _db = db;

    [BindProperty]
    public StudentEntity Student { get; set; } = new();

    public async Task<IActionResult> OnGetAsync(int id)
    {
        var student = await _db.Students.FindAsync(id);
        if (student == null) return NotFound();
        Student = student;
        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid) return Page();

        var student = await _db.Students.FindAsync(Student.Id);
        if (student == null) return NotFound();

        student.FullName = Student.FullName;
        student.Age = Student.Age;
        student.Gender = Student.Gender;
        student.Address = Student.Address;
        student.PhoneNo = Student.PhoneNo;
        student.Class = Student.Class;
        student.Roll = Student.Roll;
        student.Faculty = Student.Faculty;

        await _db.SaveChangesAsync();
        return RedirectToPage("Index");
    }
}
