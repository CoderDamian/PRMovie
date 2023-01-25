using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Movies.WebClient.Data;
using Movies.WebClient.Models;

namespace Movies.WebClient.Pages.Customers
{
    public class IndexModel : PageModel
    {
        private readonly MyDbContext _myDbContext;

        [BindProperty]
        public IEnumerable<Customer>? Customers { get; set; }

        public IndexModel(MyDbContext myDbContext)
        {
            this._myDbContext = myDbContext;
        }

        public async Task OnGet()
        {
            Customers = await _myDbContext.Customers.ToListAsync();
        }

        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            Customer? customer = await _myDbContext.Customers
                .Where(c => c.Id == id)
                .AsNoTracking()
                .FirstOrDefaultAsync();

            if (customer == null)
                return Page();

            _myDbContext.Customers.Remove(customer);

            await _myDbContext.SaveChangesAsync();

            return RedirectToPage();
        }
    }
}
