using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SmsWeb.Data;
using SmsWeb.Models;

namespace SmsWeb.Pages.Teacher.Attendance;

[Authorize(Roles = "Teacher")]
public class IndexModel : PageModel
{
    private readonly ApplicationDbContext _db;

    public IndexModel(ApplicationDbContext db) => _db = db;

    public DateOnly SelectedDate { get; set; } = DateOnly.FromDateTime(DateTime.Today);
    public List<AttendanceItem> Items { get; set; } = new();

    public class AttendanceItem
    {
        public int StudentId { get; set; }
        public string FullName { get; set; } = string.Empty;
        public int Roll { get; set; }
        public bool IsPresent { get; set; }
    }

    public async Task OnGetAsync(string? date)
    {
        if (DateOnly.TryParse(date, out var parsed)) SelectedDate = parsed;

        var students = await _db.Students.OrderBy(s => s.Roll).ToListAsync();
        var existing = await _db.Attendances
            .Where(a => a.Date == SelectedDate)
            .ToDictionaryAsync(a => a.StudentId, a => a.IsPresent);

        Items = students.Select(s => new AttendanceItem
        {
            StudentId = s.Id,
            FullName = s.FullName,
            Roll = s.Roll,
            IsPresent = existing.GetValueOrDefault(s.Id, false)
        }).ToList();
    }

    public async Task<IActionResult> OnPostAsync(string date, List<AttendanceItem> inputs)
    {
        if (!DateOnly.TryParse(date, out var targetDate)) return RedirectToPage();

        foreach (var input in inputs)
        {
            var record = await _db.Attendances
                .FirstOrDefaultAsync(a => a.StudentId == input.StudentId && a.Date == targetDate);

            if (record == null)
            {
                _db.Attendances.Add(new Models.Attendance
                {
                    StudentId = input.StudentId,
                    Date = targetDate,
                    IsPresent = input.IsPresent
                });
            }
            else
            {
                record.IsPresent = input.IsPresent;
            }
        }

        await _db.SaveChangesAsync();
        return RedirectToPage(new { date });
    }
}
