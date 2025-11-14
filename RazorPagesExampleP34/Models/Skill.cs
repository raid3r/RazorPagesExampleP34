using System.ComponentModel.DataAnnotations;

namespace RazorPagesExampleP34.Models;

public class Skill
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Required")]
    [Display(Name = "Skill title")]
    [MaxLength(100, ErrorMessage = "Max 100 chars")]
    public string Title { get; set; } = string.Empty;

    [Display(Name = "Level (0-100)")]
    [Required(ErrorMessage = "Required")]
    public int Proficiency { get; set; }
}
