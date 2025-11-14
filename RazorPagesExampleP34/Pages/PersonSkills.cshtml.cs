using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesExampleP34.Models;

namespace RazorPagesExampleP34.Pages
{
    public class PersonSkillsModel(IPersonDataProvider provider) : PageModel
    {
        public Person Person { get; set; }
        public List<Skill> Skills => Person.Skills;

        public void OnGet(int id)
        {
            var afterDeleteMessage = Request.Cookies["After-Delete-Message"];
            if (!string.IsNullOrEmpty(afterDeleteMessage))
            {
                ViewData["AfterDeleteMessage"] = afterDeleteMessage;
                Response.Cookies.Delete("After-Delete-Message");
            }

            Person = provider.GetPersonById(id);
        }


        // Delete
        public IActionResult OnPost(int id, int personId)
        {
            var person = provider.GetPersonById(personId);
            var skill = person.Skills.FirstOrDefault(s => s.Id == id);
            if (skill != null)
            {
                person.Skills.Remove(skill);
                provider.SaveChanges();

                Response.Cookies.Append(
                    key: "After-Delete-Message",
                    value: $"Skill '{skill.Title}' deleted successfully.",
                    options: new CookieOptions
                    {
                        Expires = DateTimeOffset.UtcNow.AddMinutes(1)
                    });
            }

            return RedirectToPage("/PersonSkills", new { id = personId });
        }
    }
}
