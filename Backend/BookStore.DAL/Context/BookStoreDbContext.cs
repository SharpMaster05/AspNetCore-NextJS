using BookStore.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace BookStore.DAL.Context;

public class BookStoreDbContext(DbContextOptions<BookStoreDbContext> options) : DbContext(options)
{
    public DbSet<BookModel> Books { get; set; }
}
