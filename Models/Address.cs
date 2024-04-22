using System.ComponentModel.DataAnnotations;

namespace HomeComfort.Models;

public class Address
{
    [Key] public int Id { get; set; }
    public int Entrance { get; set; }
    public int Floor { get; set; }
}