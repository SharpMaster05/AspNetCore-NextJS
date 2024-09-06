using BookStore.DAL.Context;
using BookStore.DAL.Models;
using BookStore.Domain.Abstractions;
using BookStore.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace BookStore.DAL.Repositories;

public class BooksRepositories : IBooksRepositories
{
    private readonly BookStoreDbContext _dbContext;

    public BooksRepositories(BookStoreDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<Book>> GetAll()
    {
        var bookEntities = await _dbContext.Books.AsNoTracking().ToListAsync();

        var books = bookEntities
            .Select(b => Book.Create(b.Id, b.Title, b.Description, b.Price).book)
                .ToList();

        return books;
    }

    public async Task<Guid> Add(Book book)
    {
        var bookEntity = new BookModel
        {
            Id = book.Id,
            Title = book.Title,
            Description = book.Description,
            Price = book.Price,
        };

        await _dbContext.Books.AddAsync(bookEntity);
        await _dbContext.SaveChangesAsync();

        return bookEntity.Id;
    }

    public async Task<Guid> Update(Guid id, string title, string description, decimal price)
    {
        await
            _dbContext.Books
                .Where(x => x.Id == id)
                .ExecuteUpdateAsync(s => s
                    .SetProperty(b => b.Title, b => title)
                    .SetProperty(b => b.Description, b => description)
                    .SetProperty(b => b.Price, b => price));

        return id;
    }

    public async Task<Guid> Delete(Guid id)
    {
        await _dbContext.Books
                .Where(x => x.Id == id)
                .ExecuteDeleteAsync();

        return id;
    }
}
