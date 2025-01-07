using System.ComponentModel.DataAnnotations;

public class Users{

    [Key]
    public int id {get; set;}
    [StringLength(maximumLength:150)]
    public string? name {get; set;}
    [StringLength(maximumLength:150)]
    public string? address {get; set;}
    [StringLength(maximumLength:150)]
    public string? email {get; set;}
    public string? password {get; set;}
}