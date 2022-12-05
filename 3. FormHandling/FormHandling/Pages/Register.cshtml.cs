using FormHandling.Model;
using Microsoft.AspNetCore.Components.Forms;
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
            TempData["Success"] = true;
            TempData["User"] = new
            {
                FirstName = User.FirstName, LastName = User.LastName, Email = User.Email
            };
            ModelState.Clear();
            EmptyFields();
            return Page();
        }

        public void EmptyFields()
        {
            User.Email = string.Empty;
            User.FirstName = string.Empty;
            User.LastName = string.Empty;
            User.State= string.Empty;
            User.City = string.Empty;
            User.ZipCode = string.Empty;
            User.Gender = string.Empty;
            User.DateOfBirth = new DateTime(2000,01,01);
        }
    }
}
