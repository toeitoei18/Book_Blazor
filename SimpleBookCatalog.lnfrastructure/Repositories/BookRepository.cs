using Microsoft.EntityFrameworkCore;
using SimpleBookCatalog.Application.lnterfaces;
using SimpleBookCatalog.Domain.Entities;
using SimpleBookCatalog.lnfrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleBookCatalog.lnfrastructure.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly SimpleBookCatalogDbContext context;
        public BookRepository(IDbContextFactory<SimpleBookCatalogDbContext>factory)
        {
            context = factory.CreateDbContext();
        }

        public async Task AddAsync(Book book)
        {
             context.Books.Add(book);
            await context.SaveChangesAsync();
        }
    }
}
