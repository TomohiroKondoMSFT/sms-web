using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SmsWeb.Models;

namespace SmsWeb.Data;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Student> Students => Set<Student>();
    public DbSet<Attendance> Attendances => Set<Attendance>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<Student>()
            .Property(s => s.Id)
            .UseIdentityColumn(seed: 1001, increment: 1);

        builder.Entity<Attendance>()
            .HasIndex(a => new { a.StudentId, a.Date })
            .IsUnique();

        builder.Entity<ApplicationUser>()
            .HasOne(u => u.Student)
            .WithOne(s => s.User)
            .HasForeignKey<ApplicationUser>(u => u.StudentId)
            .OnDelete(DeleteBehavior.SetNull);
    }
}
