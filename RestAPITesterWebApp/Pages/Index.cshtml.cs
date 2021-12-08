using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using RestAPITesterWebApp.Services;

namespace RestAPITesterWebApp.Pages;

public class IndexModel : PageModel
{
    private readonly HttpGetTestingService _httpGetTestingService;

    public IndexModel(HttpGetTestingService httpGetTestingService)
    {
        _httpGetTestingService = httpGetTestingService;
    }

    public IActionResult OnGet()
    {
        return Page();
    }

    public string Message { get; set; } = string.Empty;

    public bool Failed { get; set; } = false;

    [BindProperty]
    public string Endpoint { get; set; } = string.Empty;

    public async Task<IActionResult> OnPost()
    {
        if (!ModelState.IsValid)
            return Page();

        var (endpointWorks, errorMessage) = await _httpGetTestingService.TestHealthCheck(Endpoint);

        Failed = !endpointWorks;

        Message = Failed ? errorMessage : "Works";

        return Page();
    }
}
