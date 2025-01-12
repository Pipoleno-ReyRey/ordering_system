using System.Text.Json;

public class Products{
    public int seriesNum {get; set;}
    public string? name {get; set;}
    public string? description {get; set;}
    public float price {get; set;}
    public int amount {get; set;}
    private static readonly HttpClient httpClient = new HttpClient();

    public Products(int seriesNum, string name, string description, float price, int amount){
        this.seriesNum = seriesNum;
        this.name = name;
        this.description = description;
        this.price = price;
        this.amount = amount;
        httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
    }

    public static async Task<List<Products>> GetProducts(){
        HttpResponseMessage responseMessage = await httpClient.GetAsync("https://products-service-u50t.onrender.com/products/getProducts");
        if(responseMessage.IsSuccessStatusCode){
            var products = await responseMessage.Content.ReadAsStringAsync();
            List<Products> productsList = JsonSerializer.Deserialize<List<Products>>(products)!;
            return productsList!;
        } else{
            return new List<Products>();
        }
    }
}