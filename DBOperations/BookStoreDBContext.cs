using Microsoft.EntityFrameworkCore;

namespace PatikaOdev1.DBOperations{
    public class BookStoreDBContext : DbContext{
        public BookStoreDBContext(DbContextOptions<BookStoreDBContext> options) : base(options){}
        public DbSet<Book> Books {get; set;}
        
    } 
}