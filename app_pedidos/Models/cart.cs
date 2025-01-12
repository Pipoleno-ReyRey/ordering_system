public class Cart{
    public int id {get; set;}
    public int userId {get; set;}
    public float? count {get; set;} = 0.0f;
    public ICollection<ProductDto> listProducts {get; set;} = new List<ProductDto>();
}

public class ProductDto{
    public int id {get; set;}
    public string? name {get; set;}
    public string? description {get; set;}
    public float? price {get; set;}
    public int? amount {get; set;}
    public float? count {get; set;}
    public int idCart {get; set;}
    public Cart? cart {get; set;}
}