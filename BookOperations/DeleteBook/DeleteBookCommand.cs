using PatikaOdev1.DBOperations;

namespace PatikaOdev1.BookOperations.DeleteBook{
    public class DeleteBookCommand{
        private readonly BookStoreDBContext _context;
        public int bookId { get; set; }
        public DeleteBookCommand(BookStoreDBContext context){
            _context=context;
        }   

        public void handle(){
            var book = _context.Books.SingleOrDefault(x=>x.BookId==bookId);
            if (book == null){
               throw new InvalidOperationException("Cannot found in the database");
            }

            _context.Books.Remove(book);
            _context.SaveChanges();
            }
    }
}