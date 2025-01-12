using System.Security.Cryptography;

public class Cart{
    public int id {get; set;}
    public int userId {get; set;}
    public float? count {get; set;} = 0.0f;
    public ICollection<ProductsDto> listProducts {get; set;} = new List<ProductsDto>();
    private static readonly HttpClient httpClient = new HttpClient();
    public Cart(int id, int userId){
        this.id = id;
        this.userId = userId;
    }

    public static async Task<Cart> GetCart(int userId){
        
    }
}

public class ProductsDto{
    public int id {get; set;}
    public string? name {get; set;}
    public string? description {get; set;}
    public float? price {get; set;}
    public int? amount {get; set;}
    public float? count {get; set;}
    public int idCart {get; set;}
    public Cart? cart {get; set;}
}