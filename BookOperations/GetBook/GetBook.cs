using PatikaOdev1.Common;
using PatikaOdev1.DBOperations;

namespace PatikaOdev1.BookOperations.GetBook{
    public class GetBook{
        private readonly BookStoreDBContext _context;
        public int bookId { get; set; }
        public GetBook(BookStoreDBContext context){
            _context=context;
        }

        public VievModel handle(){
            var book = _context.Books.Where(x=>x.BookId==bookId).SingleOrDefault();
            if (book == null){
                throw new InvalidOperationException("Book cannot found in the database");
            }
            VievModel Model = new VievModel();
            Model.Title=book.Title;
            Model.PageCount=book.PageCount;
            Model.Genre=((Genum)book.GenreId).ToString();
            Model.PublishTime=book.PublishTime;
            return Model;
        }



        public class VievModel{
            public string Title { get; set; }
            public int PageCount { get; set; }
            public DateTime PublishTime { get; set; }
            public string Genre { get; set; }
        }
    }
}