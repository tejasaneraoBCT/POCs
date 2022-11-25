using Microsoft.EntityFrameworkCore;
using ReadLine2.Web.Model;
using System.Collections.Generic;

namespace ReadLine2.Web.Data
{
    public class ApplicationDbContext: DbContext
    {
        public DbSet<Category> Categories { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

    }
}
