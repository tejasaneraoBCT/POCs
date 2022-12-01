using FormHandling.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FormHandling.Pages
{
    [BindProperties]
    public class RegisterModel : PageModel
    {
        public User User { get; set; }
        public void OnGet()
        {
        }

        public async Task<ActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            return Page();
        }
    }
}
