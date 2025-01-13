using System.Security.Cryptography;
using System.Text.Json;

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
        HttpResponseMessage responseMessage = await httpClient.GetAsync($"https://shopping-cart-l4vk.onrender.com/cart/getCart?userId={userId}");
        if(responseMessage.IsSuccessStatusCode){
            string response = await responseMessage.Content.ReadAsStringAsync();
            Cart cart = JsonSerializer.Deserialize<Cart>(response)!;
            return cart;
        } else{
            return new Cart(0, 0);
        }
    }

    public static async Task<string> AddToCart(int userId, string nameProduct, int amount){
        string url = $"https://shopping-cart-l4vk.onrender.com/cart/updateCartAdd?userId={userId}&product={nameProduct}&amount={amount}";
        HttpResponseMessage responseMessage = await httpClient.PutAsync(url, null);

        if(responseMessage.IsSuccessStatusCode){
            return "product added to shopping cart";
        } else {
            return "didnt added product to shoping cart";
        }
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