using BookStore.Domain.Models;

namespace BookStore.Domain.Abstractions;

public interface IBooksRepositories
{
    Task<Guid> Add(Book book);
    Task<List<Book>> GetAll();
    Task<Guid> Delete(Guid id);
    Task<Guid> Update(Guid id, string title, string description, decimal price);
}