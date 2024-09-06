using BookStore.Domain.Models;

namespace BookStore.Domain.Abstractions;

public interface IBooksService
{
    Task<Guid> AddBook(Book book);
    Task<Guid> DeleteBook(Guid id);
    Task<List<Book>> GetAllBooks();
    Task<Guid> UpdateBook(Guid id, string title, string description, decimal price);
}