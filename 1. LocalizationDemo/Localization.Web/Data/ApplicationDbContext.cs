using Microsoft.EntityFrameworkCore;
using Localization.Web.Model;
using System.Collections.Generic;

namespace Localization.Web.Data
{
    public class ApplicationDbContext: DbContext
    {
        public DbSet<Category> Categories { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

    }
}
