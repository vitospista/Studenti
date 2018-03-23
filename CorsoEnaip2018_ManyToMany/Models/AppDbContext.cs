using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CorsoEnaip2018_ManyToMany.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Author>()
                .HasIndex(x => x.Name)
                .IsUnique();

            builder.Entity<AuthorBook>()
                .HasKey(x => new { x.BookId, x.AuthorId });

            builder.Entity<AuthorBook>()
                .HasOne(x => x.Author)
                .WithMany(x => x.Books)
                .HasForeignKey(x => x.AuthorId);

            builder.Entity<AuthorBook>()
                .HasOne(x => x.Book)
                .WithMany(x => x.Authors)
                .HasForeignKey(x => x.BookId);
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
    }

    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public List<AuthorBook> Authors { get; set; }
    }

    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<AuthorBook> Books { get; set; }
    }

    public class AuthorBook
    {
        public int BookId { get; set; }
        public Book Book { get; set; }

        public int AuthorId { get; set; }
        public Author Author { get; set; }
    }


    /*
     * Author   Book
     *      1      1
     *      1      2
     *      3      2
     */

}
