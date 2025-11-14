using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesExampleP34.Models;

namespace RazorPagesExampleP34.Pages;

public class SkillEditModel(IPersonDataProvider provider) : PageModel
{
    public Person Person { get; set; }
    [BindProperty]
    public Skill Skill { get; set; }

    public void OnGet(int personId, int id)
    {
        Person = provider.GetPersonById(personId);
        Skill = Person.Skills.First(s => s.Id == id);
    }

    public IActionResult OnPost(int personId, int id)
    {
        // Validate Proficiency between 1 and 100
        if (Skill.Proficiency < 1 || Skill.Proficiency > 100)
        {
            ModelState.AddModelError("Skill.Proficiency", "Level must be between 1 and 100.");
        }
        // If validation fails, reload the person and return the page
        if (!ModelState.IsValid)
        {
            Person = provider.GetPersonById(personId);
            return Page();
        }

        // Update the skill
        var person = provider.GetPersonById(personId);
        var skill = person.Skills.First(s => s.Id == id);
        skill.Title = Skill.Title;
        skill.Proficiency = Skill.Proficiency;
        provider.SaveChanges();

        return RedirectToPage("/PersonSkills", new { id = personId });
    }
}
