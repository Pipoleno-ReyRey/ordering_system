using System.ComponentModel.DataAnnotations;

public class Cart{
    public int id {get; set;}
    public int userId {get; set;}
    public string? products {get; set;}
    public float? count {get; set;}
}