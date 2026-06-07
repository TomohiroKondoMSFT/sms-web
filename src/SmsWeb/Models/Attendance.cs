namespace SmsWeb.Models;

public class Attendance
{
    public int Id { get; set; }
    public int StudentId { get; set; }
    public Student Student { get; set; } = null!;
    public DateOnly Date { get; set; }
    public bool IsPresent { get; set; }
}
