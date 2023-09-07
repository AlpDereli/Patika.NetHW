using Microsoft.AspNetCore.Mvc;
using PatikaOdev1.DBOperations;

namespace PatikaOdev1.BookOperations.CreateBook{
    public class CreateBookCommand{
        public CreateBookModel Model { get; set; }
        private readonly BookStoreDBContext _context;
        public CreateBookCommand(BookStoreDBContext context){
            _context=context;
        }
        public void handle(){
            var book = _context.Books.Where(x=>x.Title==Model.Title).SingleOrDefault();
            if (book != null){
                throw new InvalidOperationException("The book already in the database");
            }
            book = new Book();
            book.Title = Model.Title;
            book.PublishTime= Model.PublishDate;
            book.PageCount=Model.PageCount;
            book.GenreId=Model.GenreId;

            _context.Books.Add(book);
            _context.SaveChanges();
        }

        public class CreateBookModel
        {
            public string Title { get; set; }
            public int GenreId { get; set; }
            public int PageCount { get; set; }
            public DateTime PublishDate { get; set; }
        }

        public void dodo(){}
    }
}