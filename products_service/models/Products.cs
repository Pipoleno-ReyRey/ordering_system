using System.ComponentModel.DataAnnotations;

public class Products{
    [Key]
    public int seriesNum {get; set;}
    [StringLength(maximumLength:150)]
    public string? name {get; set;}
    [StringLength(maximumLength:300)]
    public string? description {get; set;}
    public float price {get; set;}
    public int amount {get; set;}
}