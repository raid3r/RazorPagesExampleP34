using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesExampleP34.Models;

namespace RazorPagesExampleP34.Pages;

//      /PersonView?id=1
public class PersonViewModel(IPersonDataProvider provider) : PageModel
{
    // Методи запиту (GET, POST, PUT, PATCH, DELETE)
 
    public Person Person { get; set; }

    public void OnGet(int id)
    {
        Person = provider.GetPersonById(id);
    }
}
