using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Movies.WebClient.Data;
using Movies.WebClient.Models;

namespace Movies.WebClient.Pages.Customers
{
    public class CreateModel : PageModel
    {
        private readonly MyDbContext _myDbContext;

        [BindProperty]
        public Customer Customer { get; set; }

        public CreateModel(MyDbContext myDbContext)
        {
            this._myDbContext = myDbContext;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            if (Customer == null)
                return Page();

            await _myDbContext.Customers.AddAsync(Customer);

            await _myDbContext.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
