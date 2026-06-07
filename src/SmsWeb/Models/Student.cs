using System.ComponentModel.DataAnnotations;

namespace SmsWeb.Models;

public class Student
{
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    [Display(Name = "氏名")]
    public string FullName { get; set; } = string.Empty;

    [Display(Name = "年齢")]
    public short? Age { get; set; }

    [MaxLength(1)]
    [Display(Name = "性別")]
    public string? Gender { get; set; }

    [MaxLength(100)]
    [Display(Name = "住所")]
    public string? Address { get; set; }

    [MaxLength(10)]
    [Display(Name = "電話番号")]
    public string? PhoneNo { get; set; }

    [Required]
    [Display(Name = "クラス")]
    public short Class { get; set; }

    [Required]
    [Display(Name = "学籍番号")]
    public int Roll { get; set; }

    [MaxLength(10)]
    [Display(Name = "学科")]
    public string? Faculty { get; set; }

    public ICollection<Attendance> Attendances { get; set; } = new List<Attendance>();
    public ApplicationUser? User { get; set; }
}
