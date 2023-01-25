using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Movies.WebClient.Data;
using Movies.WebClient.Models;

namespace Movies.WebClient.Pages.Customers
{
    public class EditModel : PageModel
    {
        private readonly MyDbContext _myDbContext;

        public EditModel(MyDbContext myDbContext)
        {
            this._myDbContext = myDbContext;
        }

        [BindProperty]
        public Customer? Customer { get; set; }

        public async Task<IActionResult> OnGet(int? id)
        {
            if (id == null)
                return NotFound();

            Customer = await _myDbContext.Customers
                .Where(c => c.Id == id)
                .AsNoTracking()
                .FirstOrDefaultAsync();

            if (Customer == null)
                RedirectToPage("./Index");

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            if (Customer == null)
                RedirectToPage("./Index");

            _myDbContext.Customers.Update(Customer);

            await _myDbContext.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
