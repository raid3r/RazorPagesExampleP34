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
            //if (Person.FirstName == "Vasyl")
            //{
            //    ModelState.AddModelError("Person.FirstName", "Таке ім'я використовувати не можна!");
            //}

            if (!ModelState.IsValid)
            {
                return Page(); // html
            }

            var person = provider.GetPersonById(id);

            person.FirstName = Person.FirstName;
            person.LastName = Person.LastName;
            person.Profession = Person.Profession;
            person.BirthDate = Person.BirthDate;

            provider.SaveChanges();

            // Переадресація на сторінку перегляду особи після збереження змін
            // 302 Redirect location: /PersonView?id=1
            return RedirectToPage("PersonView", new { id = person.Id }); // /PersonView?id=1

            //Response.StatusCode = 400;
            //return new JsonResult(new
            //{
            //    Error = "Validation Failed",
            //});
            //return new JsonResult(ModelState);



            //  уся сторінка перезавантажується - html на  сервері

            //  частина сторінки оновлюється через AJAX - html на  сервері

            //  відправка даних на сервер через API - JSON відповідь - JSON 
            //  html на клієнті оновлюється через JavaScript

            // HTML - Page() - повна сторінка - PageResult
            // JSON - new JsonResult() - JsonResult
            // Redirect - RedirectToPage() - RedirectResult
            // File - FileResult



        }
    }
}
