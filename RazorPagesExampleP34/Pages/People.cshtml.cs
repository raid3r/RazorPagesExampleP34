using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesExampleP34.Models;

namespace RazorPagesExampleP34.Pages;

public class PeopleModel(IPersonDataProvider provider) : PageModel
{
    public List<Person> People => provider.GetAllPeople();

    public void OnGet()
    {

    }

    // Delete
    public IActionResult OnPost(int id)
    {
        provider.DeletePerson(id);
        provider.SaveChanges();

        return RedirectToAction("Page");
    }
}
