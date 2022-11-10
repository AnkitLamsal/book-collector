using book_collector.Areas.Identity.Data;
using book_collector.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace book_collector.Data;

public class book_collectorContext : IdentityDbContext<book_collectorUser>
{

    public book_collectorContext(DbContextOptions<book_collectorContext> options)
        : base(options)
    {
    }
    public DbSet<Book> Books { get; set; }
    public DbSet<BookCollection> BookCollections{get;set;}
    public DbSet<Collection> Collections { get; set; }


    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.Entity<BookCollection>().HasKey(c => new { c.bookId, c.collectionId });
        builder.Entity<BookCollection>().
            HasOne(c => c.Book).WithMany(c=>c.bookCollections).HasForeignKey(c => c.bookId);
        builder.Entity<BookCollection>().
            HasOne(c => c.Collection).WithMany(c => c.bookCollections).HasForeignKey(c => c.collectionId);

    }
}
