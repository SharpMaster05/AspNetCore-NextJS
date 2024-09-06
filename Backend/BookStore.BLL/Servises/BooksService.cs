using BookStore.Domain.Abstractions;
using BookStore.Domain.Models;

namespace BookStore.BLL.Servises;

public class BooksService : IBooksService
{
    private readonly IBooksRepositories _booksRepositories;
    public BooksService(IBooksRepositories booksRepositories)
    {
        _booksRepositories = booksRepositories;
    }

    public async Task<List<Book>> GetAllBooks() => await _booksRepositories.GetAll();
    public async Task<Guid> AddBook(Book book) => await _booksRepositories.Add(book);
    public async Task<Guid> UpdateBook(Guid id, string title, string description, decimal price) => await _booksRepositories.Update(id, title, description, price);
    public async Task<Guid> DeleteBook(Guid id) => await _booksRepositories.Delete(id);


}
