using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesExampleP34.Models;

namespace RazorPagesExampleP34.Pages;

public class AboutMeModel : PageModel
{
    private  readonly IPersonDataProvider _provider;

    public AboutMeModel(IPersonDataProvider provider)
    {
        _provider = provider;
        Person = _provider.GetPerson();
    }

    public Person Person { get; set; }

    public void OnGet()
    {
    }
}
