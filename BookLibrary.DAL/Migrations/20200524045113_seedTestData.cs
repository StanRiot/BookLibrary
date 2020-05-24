using Microsoft.EntityFrameworkCore.Migrations;

namespace BookLibrary.DAL.Migrations
{
    public partial class seedTestData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Author",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "George R.R. Martin" },
                    { 2, "J.K. Rowling" },
                    { 3, "John Ronald Reuel Tolkien" }
                });

            migrationBuilder.InsertData(
                table: "Book",
                columns: new[] { "Id", "Name", "Year" },
                values: new object[,]
                {
                    { 16, "The Lord of the Rings. The Return of the King", 1955 },
                    { 15, "The Lord of the Rings. The Two Towers", 1954 },
                    { 14, "The Lord of the Rings. The Fellowship of the Ring", 1954 },
                    { 13, "The Hobbit or There and Back Again", 1937 },
                    { 12, "The Deathly Hallows", 2007 },
                    { 11, "The Half-Blood Prince", 2005 },
                    { 10, "The Order of the Phoenix", 2003 },
                    { 9, "The Goblet of Fire", 2000 },
                    { 8, "The Prisoner of Azkaban", 1999 },
                    { 7, "The Chamber of Secrets", 1998 },
                    { 6, "The Philosopher's Stone", 1997 },
                    { 5, "A Dance with Dragons", 2011 },
                    { 4, "A Feast for Crows", 2005 },
                    { 3, "A Storm of Swords", 2000 },
                    { 2, "A Clash of Kings", 1998 },
                    { 1, "A Game of Thrones", 1996 }
                });

            migrationBuilder.InsertData(
                table: "Genre",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Fantasy" },
                    { 2, "Adventure" },
                    { 3, "Romance" }
                });

            migrationBuilder.InsertData(
                table: "BooksAuthors",
                columns: new[] {"BookId", "AuthorId"},
                values: new object[,]
                {
                    {1, 1},
                    {2, 1},
                    {3, 1},
                    {4, 1},
                    {5, 1},
                    {6, 2},
                    {7, 2},
                    {8, 2},
                    {9, 2},
                    {10, 2},
                    {11, 2},
                    {12, 2},
                    {13, 3},
                    {14, 3},
                    {15, 3},
                    {16, 3}
                });

            migrationBuilder.InsertData(
                table: "BooksGenres",
                columns: new[] { "BookId", "GenreId" },
                values: new object[,]
                {
                    { 12, 3 },
                    { 10, 3 },
                    { 9, 3 },
                    { 1, 3 },
                    { 13, 2 },
                    { 7, 2 },
                    { 8, 1 },
                    { 2, 2 },
                    { 11, 1 },
                    { 6, 1 },
                    { 5, 1 },
                    { 4, 1 },
                    { 14, 3 },
                    { 3, 2 },
                    { 15, 3 },
                    {16 , 1}
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "BooksAuthors",
                keyColumns: new[] { "BookId", "AuthorId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "BooksAuthors",
                keyColumns: new[] { "BookId", "AuthorId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "BooksAuthors",
                keyColumns: new[] { "BookId", "AuthorId" },
                keyValues: new object[] { 1, 3 });

            migrationBuilder.DeleteData(
                table: "BooksAuthors",
                keyColumns: new[] { "BookId", "AuthorId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "BooksAuthors",
                keyColumns: new[] { "BookId", "AuthorId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "BooksAuthors",
                keyColumns: new[] { "BookId", "AuthorId" },
                keyValues: new object[] { 2, 3 });

            migrationBuilder.DeleteData(
                table: "BooksAuthors",
                keyColumns: new[] { "BookId", "AuthorId" },
                keyValues: new object[] { 3, 1 });

            migrationBuilder.DeleteData(
                table: "BooksAuthors",
                keyColumns: new[] { "BookId", "AuthorId" },
                keyValues: new object[] { 3, 2 });

            migrationBuilder.DeleteData(
                table: "BooksAuthors",
                keyColumns: new[] { "BookId", "AuthorId" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.DeleteData(
                table: "BooksAuthors",
                keyColumns: new[] { "BookId", "AuthorId" },
                keyValues: new object[] { 4, 1 });

            migrationBuilder.DeleteData(
                table: "BooksAuthors",
                keyColumns: new[] { "BookId", "AuthorId" },
                keyValues: new object[] { 4, 2 });

            migrationBuilder.DeleteData(
                table: "BooksAuthors",
                keyColumns: new[] { "BookId", "AuthorId" },
                keyValues: new object[] { 4, 3 });

            migrationBuilder.DeleteData(
                table: "BooksAuthors",
                keyColumns: new[] { "BookId", "AuthorId" },
                keyValues: new object[] { 5, 1 });

            migrationBuilder.DeleteData(
                table: "BooksAuthors",
                keyColumns: new[] { "BookId", "AuthorId" },
                keyValues: new object[] { 5, 2 });

            migrationBuilder.DeleteData(
                table: "BooksAuthors",
                keyColumns: new[] { "BookId", "AuthorId" },
                keyValues: new object[] { 5, 3 });

            migrationBuilder.DeleteData(
                table: "BooksGenres",
                keyColumns: new[] { "BookId", "GenreId" },
                keyValues: new object[] { 1, 3 });

            migrationBuilder.DeleteData(
                table: "BooksGenres",
                keyColumns: new[] { "BookId", "GenreId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "BooksGenres",
                keyColumns: new[] { "BookId", "GenreId" },
                keyValues: new object[] { 3, 2 });

            migrationBuilder.DeleteData(
                table: "BooksGenres",
                keyColumns: new[] { "BookId", "GenreId" },
                keyValues: new object[] { 4, 1 });

            migrationBuilder.DeleteData(
                table: "BooksGenres",
                keyColumns: new[] { "BookId", "GenreId" },
                keyValues: new object[] { 5, 1 });

            migrationBuilder.DeleteData(
                table: "BooksGenres",
                keyColumns: new[] { "BookId", "GenreId" },
                keyValues: new object[] { 6, 1 });

            migrationBuilder.DeleteData(
                table: "BooksGenres",
                keyColumns: new[] { "BookId", "GenreId" },
                keyValues: new object[] { 7, 2 });

            migrationBuilder.DeleteData(
                table: "BooksGenres",
                keyColumns: new[] { "BookId", "GenreId" },
                keyValues: new object[] { 8, 1 });

            migrationBuilder.DeleteData(
                table: "BooksGenres",
                keyColumns: new[] { "BookId", "GenreId" },
                keyValues: new object[] { 9, 3 });

            migrationBuilder.DeleteData(
                table: "BooksGenres",
                keyColumns: new[] { "BookId", "GenreId" },
                keyValues: new object[] { 10, 3 });

            migrationBuilder.DeleteData(
                table: "BooksGenres",
                keyColumns: new[] { "BookId", "GenreId" },
                keyValues: new object[] { 11, 1 });

            migrationBuilder.DeleteData(
                table: "BooksGenres",
                keyColumns: new[] { "BookId", "GenreId" },
                keyValues: new object[] { 12, 3 });

            migrationBuilder.DeleteData(
                table: "BooksGenres",
                keyColumns: new[] { "BookId", "GenreId" },
                keyValues: new object[] { 13, 2 });

            migrationBuilder.DeleteData(
                table: "BooksGenres",
                keyColumns: new[] { "BookId", "GenreId" },
                keyValues: new object[] { 14, 3 });

            migrationBuilder.DeleteData(
                table: "BooksGenres",
                keyColumns: new[] { "BookId", "GenreId" },
                keyValues: new object[] { 15, 3 });

            migrationBuilder.DeleteData(
                table: "Author",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Author",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Author",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Genre",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Genre",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Genre",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
