using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesExampleP34.Models;

namespace RazorPagesExampleP34.Pages
{
    public class PersonEditModel(IPersonDataProvider provider) : PageModel
    {
        [BindProperty]
        public Person Person { get; set; }

        // Person.FirstName=John
        // &Person.LastName=Doe
        // &Person.BirthDate=1990-01-01
        // &__Invariant=Person.BirthDate
        // &Person.Profession=Software+Developer
        // &__RequestVerificationToken=CfDJ8B5UZNjyrtRLpuNtrttTLCfIOy6132MuiKQmSxGk07HacmNWU1N6_zhvddRQ1kapuIGhEMy_sljuPSs4CoC2zw8Z7gGdQW8rL-_eTS4qQy7HI1rGD


        // GET /PersonEdit?id=1
        // Відображення сторінки редагування особи
        public void OnGet(int id)
        {
            Person = provider.GetPersonById(id);
        }

        // Обробка відправки форми редагування особи
        public IActionResult OnPost(int id)
        {
            var person = provider.GetPersonById(id);
            
            person.FirstName = Person.FirstName;
            person.LastName = Person.LastName;
            person.Profession = Person.Profession;
            person.BirthDate = Person.BirthDate;

            provider.SaveChanges();

            // Переадресація на сторінку перегляду особи після збереження змін
            // 302 Redirect location: /PersonView?id=1
            return RedirectToPage("PersonView", new { id = person.Id } ); // /PersonView?id=1
        }
    }
}
