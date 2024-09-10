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

        public async Task<List<Book>> GetAllAsync()
        {
            var books = await context.Books.ToListAsync();
            return books;
        }

        public async Task<Book?> GetByIdAsync(int id)
        {
            var book = await context.Books.FirstOrDefaultAsync(e => e.Id == id);
            return book;
        }

        public async Task UpdateAsync(Book book)
        {
            context.Entry(book).State = EntityState.Modified;  
            await context.SaveChangesAsync();
        }
    }
}
