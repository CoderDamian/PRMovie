using Microsoft.EntityFrameworkCore;
using Movies.WebClient.Data;

namespace Movies.WebClient.Extensions
{
    public static class MyServices
    {
        public static void AddMyDataBase(this IServiceCollection services)
        {
            services.AddDbContext<MyDbContext>(opt => opt.UseInMemoryDatabase("MyDB"));
        }
    }
}
