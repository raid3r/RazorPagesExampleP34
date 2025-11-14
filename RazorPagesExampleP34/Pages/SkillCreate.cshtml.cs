using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesExampleP34.Models;

namespace RazorPagesExampleP34.Pages;

public class SkillCreateModel(IPersonDataProvider provider) : PageModel
{
    public Person Person { get; set; }

    [BindProperty]
    public Skill Skill { get; set; } = new Skill();

    public void OnGet(int personId)
    {
        Person = provider.GetPersonById(personId);
    }

    public IActionResult OnPost(int personId)
    {
        if (Skill.Proficiency < 1 || Skill.Proficiency > 100)
        {
            ModelState.AddModelError("Skill.Proficiency", "Level must be between 1 and 100.");
        }
        if (!ModelState.IsValid)
        {
            Person = provider.GetPersonById(personId);
            return Page();
        }

        var person = provider.GetPersonById(personId);

        // Assign a new Id to the Skill
        Skill.Id = person.Skills.Any() ? person.Skills.Max(s => s.Id) + 1 : 1;
        

        person.Skills.Add(Skill);
        provider.SaveChanges();

      

        return RedirectToPage("PersonSkills", new { id = personId });
    }
}
