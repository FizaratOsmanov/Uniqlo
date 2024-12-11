using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Uniqlo.DAL.Models;

namespace Uniqlo.DAL;

public class UniqloDBContext : IdentityDbContext<AppUser>
{
    public DbSet<SliderItem> SliderItems { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }

    public UniqloDBContext(DbContextOptions options) : base(options)
    {

    }
}
