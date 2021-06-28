using library_BE.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace library_BE
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Author_Book> Author_Books { get; set; }
        public DbSet<Borrow> Borrows { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Category_Book> Category_Books { get; set; }
        public DbSet<Pay> Pays { get; set; }
        public DbSet<PublishCompany> PublishCompanies { get; set; }

        public DbSet<BorrowDetail> BorrowDetails { get; set; }
      

        public DbSet<Reader> Readers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category_Book>().HasKey(x => new { x.CategoryId, x.BookId });
            modelBuilder.Entity<Author_Book>().HasKey(x => new { x.AuthorId, x.BookId });
            modelBuilder.Entity<BorrowDetail>().HasKey(x => new { x.BorrowId, x.BookId });
        }
    }
}
