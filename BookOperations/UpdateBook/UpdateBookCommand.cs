using PatikaOdev1.DBOperations;

namespace PatikaOdev1.BookOperations.UpdateBook{
    public class UpdateBookCommand{
        private readonly BookStoreDBContext _context;

        public int bookId { get; set; }
        public UpdateBookModel Model { get; set; }
        public UpdateBookCommand(BookStoreDBContext context){
            _context=context;
        }
        public void handle(){
            var book = _context.Books.SingleOrDefault(x=>x.BookId==bookId);
            if (book == null){
                throw new InvalidOperationException("Book is not in the database");
            }
            book.GenreId = Model.GenreId != default ? Model.GenreId : book.GenreId;
            book.Title= Model.Title!= default? Model.Title: book.Title;
            _context.SaveChanges();
        }
        public class UpdateBookModel{
            public string Title { get; set; }
            public int GenreId { get; set; }
        }
    }
}