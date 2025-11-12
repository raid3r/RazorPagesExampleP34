using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesExampleP34.Models;

namespace RazorPagesExampleP34.Pages
{
    public class PersonCreateModel(IPersonDataProvider provider) : PageModel
    {
        [BindProperty]
        public Person Person { get; set; }

        public void OnGet()
        {
            Person = new Person();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            provider.Add(Person);
            provider.SaveChanges();
            // Переадресація на сторінку перегляду особи після створення
            return RedirectToPage("PersonView", new { id = Person.Id } ); // /PersonView?id=1
        }
    }
}
