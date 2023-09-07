using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace PatikaOdev1.DBOperations{
    public class DataGenerator{
        public static void Initialize(IServiceProvider serviceProvider){
            using(var context =new BookStoreDBContext(serviceProvider.GetRequiredService<DbContextOptions<BookStoreDBContext>>())){
                if(context.Books.Any()){
                    return;
                }
                context.Books.AddRange
                (
                    new Book{
                        //BookId = 1,
                        Title = "Lean Startup",
                        GenreId=1, //Personal Growth
                        PageCount=200,
                        PublishTime = new DateTime(2001,01,12)
                    },
                    new Book{
                        //BookId = 2,
                        Title = "Herland",
                        GenreId=2, //Sci-Fi
                        PageCount=250,
                        PublishTime = new DateTime(2010,05,23)
                    },
                    new Book{
                        //BookId = 3,
                        Title = "Dune",
                        GenreId=2, 
                        PageCount=540,
                        PublishTime = new DateTime(2002,12,21)
                    }
                );
                context.SaveChanges();
            }
        }
    }
}