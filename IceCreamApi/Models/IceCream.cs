using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class IceCream
{
    public int Id { get; set; }
    public string? Flavor { get; set; } 
    public int Stock { get; set; }
}
