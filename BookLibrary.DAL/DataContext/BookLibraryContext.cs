using System;
using System.Collections.Generic;
using System.Text;
using BookLibrary.CORE.Models;
using Microsoft.EntityFrameworkCore;

namespace BookLibrary.DAL.DataContext
{
    public class BookLibraryContext: DbContext
    {
        public BookLibraryContext()
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>()
                .HasKey(B => B.Id);
            modelBuilder.Entity<Author>()
                .HasKey(A => A.Id);
            modelBuilder.Entity<Genre>()
                .HasKey(G => G.Id);

            modelBuilder.Entity<BooksAuthors>()
                .HasKey(BA => BA.Id);
            modelBuilder.Entity<BooksGenres>()
                .HasKey(BG => BG.Id);



            modelBuilder.Entity<BooksGenres>()
                .HasKey(BG => new { BG.BookId, BG.GenreId });
            modelBuilder.Entity<BooksGenres>()
                .HasOne(BG => BG.Book)
                .WithMany(BG => BG.Genres)
                .HasForeignKey(BG => BG.BookId);
            modelBuilder.Entity<BooksGenres>()
                .HasOne(BG => BG.Genre)
                .WithMany(G => G.BooksGenres)
                .HasForeignKey(BG => BG.GenreId);


            modelBuilder.Entity<BooksAuthors>()
                .HasKey(BA => new {BA.BookId, BA.AuthorId});
            modelBuilder.Entity<BooksAuthors>()
                .HasOne(BA => BA.Book)
                .WithMany(B => B.Authors)
                .HasForeignKey(BA => BA.BookId);
            modelBuilder.Entity<BooksAuthors>()
                .HasOne(BA => BA.Author)
                .WithMany(A => A.BooksAuthors)
                .HasForeignKey(BA => BA.AuthorId);


            base.OnModelCreating(modelBuilder);
        }
    }
}
