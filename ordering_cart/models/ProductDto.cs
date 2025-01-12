using System.Text.Json.Serialization;

public class ProductDto{
    public int id {get; set;}
    public string? name {get; set;}
    public string? description {get; set;}
    public float? price {get; set;}
    public int? amount {get; set;}
    public float? count {get; set;}
    [JsonIgnore]
    public int idCart {get; set;}
    [JsonIgnore]
    public Cart? cart {get; set;}
}