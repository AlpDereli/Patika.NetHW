using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using PatikaOdev1.BookOperations.CreateBook;
using PatikaOdev1.BookOperations.GetBook;
using PatikaOdev1.BookOperations.UpdateBook;
using PatikaOdev1.DBOperations;
using static PatikaOdev1.BookOperations.UpdateBook.UpdateBookCommand;
using static PatikaOdev1.BookOperations.CreateBook.CreateBookCommand;
using PatikaOdev1.BookOperations.DeleteBook;


namespace PatikaOdev1.Controllers;

[ApiController]
[Route("[controller]")]
public class BookController : ControllerBase
{
    private readonly BookStoreDBContext context;
    public BookController (BookStoreDBContext Context){
        context = Context;
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id){
        GetBook getBook = new GetBook(context);
        try{
            getBook.bookId=id;
            getBook.handle();
        }
        catch(Exception ex){
            return BadRequest(ex.Message);
        }
        return Ok();
    }
    [HttpPost]
    public IActionResult AddBook([FromBody] CreateBookModel newBook){
        CreateBookCommand command = new CreateBookCommand(context);
        try{
            command.Model = newBook;
            command.handle(); 
        }
        catch(Exception ex){
            return BadRequest(ex.Message);
        }
        return Ok();
    }
    [HttpPut("{id}")]
    public IActionResult UpdateBook(int id, UpdateBookModel updatedBook){
        try{
            UpdateBookCommand command = new UpdateBookCommand(context);
        command.bookId = id;
        command.Model=updatedBook;
        command.handle();
        }
        catch(Exception ex){
            return BadRequest(ex.Message);
        }
        return  Ok();

    }
    [HttpDelete("{id}")]
    public IActionResult deleteBook(int id){
        DeleteBookCommand command = new DeleteBookCommand(context);

        try{
            command.bookId=id;
            command.handle();
        }
        catch(Exception ex){
            return BadRequest(ex.Message);
        }
        return Ok();    
        }
}