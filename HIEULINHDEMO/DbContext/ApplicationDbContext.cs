using HIEULINHDEMO.Models;
using Microsoft.EntityFrameworkCore;

namespace HIEULINHDEMO.DbContext;

public class ApplicationDbContext: Microsoft.EntityFrameworkCore.DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
    
    public DbSet<People> Peoples { get; set; }
    
    public DbSet<Address> Addresses { get; set; }
    

}