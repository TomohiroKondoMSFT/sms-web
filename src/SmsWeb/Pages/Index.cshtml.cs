using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SmsWeb.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;

    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }

    public IActionResult OnGet()
    {
        if (User.Identity?.IsAuthenticated == true)
        {
            if (User.IsInRole("Admin"))
                return RedirectToPage("/Admin/Students/Index");
            if (User.IsInRole("Teacher"))
                return RedirectToPage("/Teacher/Students/Index");
            if (User.IsInRole("Student"))
                return RedirectToPage("/Student/Profile");
        }
        return Page();
    }
}
