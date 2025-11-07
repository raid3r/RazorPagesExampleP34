using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorPagesExampleP34.Pages;


//   IndexModel <== Index.cshtml

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;

    public string Message { get; set; } = "Hello from IndexModel";

    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {

    }
}
