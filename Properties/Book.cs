using System.ComponentModel.DataAnnotations.Schema;

namespace PatikaOdev1;

public class Book
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int BookId { get; set; }
    
    public string Title { get; set; }
    public int GenreId { get; set; }
    public int PageCount { get; set; }
    public DateTime PublishTime {get; set;}
}