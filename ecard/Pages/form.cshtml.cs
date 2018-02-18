using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ecard.Pages
{
    public class FormModel : PageModel
    {
        public string Message { get; set; }

        public void OnGet()
        {
            Message = "Your application description page.";
        }
    }
}
