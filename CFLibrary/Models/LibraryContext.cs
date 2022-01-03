using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CFLibrary.Models
{
    public class LibraryContext : DbContext
    {
        public LibraryContext(DbContextOptions<LibraryContext> options) : base(options){ }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BookBorrow>()
                .HasKey(c => new { c.UserId, c.BookId });

            modelBuilder.Entity<LibraryBooks>()
                .HasKey(c => new { c.LibraryId, c.BookId });
        }




        public virtual DbSet<Library> Library { get; set; }
        public virtual DbSet<LibraryBooks> LibraryBooks { get; set; }
        public virtual DbSet<Book> Book { get; set; }
        public virtual DbSet<Author> Author { get; set; }
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<BookBorrow> BookBorrow { get; set; }







    }
}
