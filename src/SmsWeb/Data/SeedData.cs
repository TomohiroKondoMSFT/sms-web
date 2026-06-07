using Microsoft.AspNetCore.Identity;
using SmsWeb.Models;

namespace SmsWeb.Data;

public static class SeedData
{
    public static async Task InitializeAsync(IServiceProvider services)
    {
        var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
        var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
        var db = services.GetRequiredService<ApplicationDbContext>();

        // ロール作成
        foreach (var role in new[] { "Admin", "Teacher", "Student" })
        {
            if (!await roleManager.RoleExistsAsync(role))
                await roleManager.CreateAsync(new IdentityRole(role));
        }

        // Admin アカウント
        var adminPw = Environment.GetEnvironmentVariable("SEED_ADMIN_PASSWORD") ?? "Admin1234!";
        await CreateUserAsync(userManager, "admin@sms.demo", adminPw, "Admin", null, db);

        // Teacher アカウント
        var teacherPw = Environment.GetEnvironmentVariable("SEED_TEACHER_PASSWORD") ?? "Teacher1234!";
        await CreateUserAsync(userManager, "teacher@sms.demo", teacherPw, "Teacher", null, db);

        // Student アカウント（Student レコードとリンク）
        var studentPw = Environment.GetEnvironmentVariable("SEED_STUDENT_PASSWORD") ?? "Student1234!";
        var demoStudent = db.Students.FirstOrDefault(s => s.Roll == 1001);
        if (demoStudent == null)
        {
            demoStudent = new Student
            {
                FullName = "Demo Student",
                Class = 1,
                Roll = 1001,
                Faculty = "Science",
                Age = 16,
                Gender = "M"
            };
            db.Students.Add(demoStudent);
            await db.SaveChangesAsync();
        }
        await CreateUserAsync(userManager, "student@sms.demo", studentPw, "Student", demoStudent.Id, db);
    }

    private static async Task CreateUserAsync(
        UserManager<ApplicationUser> userManager,
        string email, string password, string role,
        int? studentId, ApplicationDbContext db)
    {
        if (await userManager.FindByEmailAsync(email) != null) return;

        var user = new ApplicationUser
        {
            UserName = email,
            Email = email,
            EmailConfirmed = true,
            StudentId = studentId
        };
        var result = await userManager.CreateAsync(user, password);
        if (result.Succeeded)
            await userManager.AddToRoleAsync(user, role);
    }
}
