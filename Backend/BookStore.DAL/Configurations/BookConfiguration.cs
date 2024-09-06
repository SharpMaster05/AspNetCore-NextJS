using BookStore.DAL.Models;
using BookStore.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookStore.DAL.Configurations;

internal class BookConfiguration : IEntityTypeConfiguration<BookModel>
{
    public void Configure(EntityTypeBuilder<BookModel> builder)
    {
        builder.HasKey(x => x.Id);

        builder
            .Property(book => book.Title)
                .HasMaxLength(Book.MAX_TIATLE_LENGTH)
                    .IsRequired();

        builder
            .Property(book => book.Description)
                .IsRequired();
        
        builder
            .Property(book => book.Price)
                .IsRequired();
    }
}
