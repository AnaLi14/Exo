using System.ComponentModel.DataAnnotations;

namespace Exo.Models;

public class Exo
{
    public int Id {get; set;}
    public string? Title {get; set;}
    [DataType(DataType.Date)]
    public DateTime ReleaseDate {get; set;}
    public string? Genre {get; set;}
   [Range(1, int.MaxValue, ErrorMessage = "Only positive number allowed")]
    public decimal Price {get;set;}

}