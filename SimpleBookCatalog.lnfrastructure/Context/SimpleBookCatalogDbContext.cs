using Microsoft.EntityFrameworkCore;
using SimpleBookCatalog.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleBookCatalog.lnfrastructure.Context
{
    public class SimpleBookCatalogDbContext : DbContext
    {
        public SimpleBookCatalogDbContext(DbContextOptions<SimpleBookCatalogDbContext> options) : base(options)
        {
            
        }
        public DbSet<Book> Books { get; set; }
    }
}
