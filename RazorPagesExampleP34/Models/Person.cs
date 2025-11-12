using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace RazorPagesExampleP34.Models;

public class Person
{
    [ValidateNever]
    public int Id { get; set; }

    [Display(Name = "Ім'я")]
    [Required(ErrorMessage = "Введіть ім'я")]
    [MaxLength(50, ErrorMessage = "Не більше 50 символів")]
    public string FirstName { get; set; } = string.Empty;

    [Display(Name = "Прізвище")]
    [Required(ErrorMessage = "Введіть прізвище")]
    [MaxLength(50, ErrorMessage = "Не більше 50 символів")]
    public string LastName { get; set; } = string.Empty;

    [Display(Name = "Професія")]
    [Required(ErrorMessage = "Напишіть свою професію")]
    [MaxLength(500, ErrorMessage = "Не більше 500 символів")]
    public string Profession { get; set; } = string.Empty;

    [Display(Name = "Дата народження")]
    public DateTime BirthDate { get; set; }

    [ValidateNever]
    public List<Skill> Skills { get; set; } = [];
}
