using Newtonsoft.Json;

public class HttpConsume{
    public static readonly HttpClient httpClient = new HttpClient();
    public HttpConsume(){
        httpClient.DefaultRequestHeaders.Add("accept", "application/json");
    }

    public static async Task<float?> GetProduct(string name, int amount){
        HttpResponseMessage httpResponse = await httpClient.GetAsync($"https://products-service-u50t.onrender.com/products/getProduct?name={name}");
        if(httpResponse.IsSuccessStatusCode){
            ProductDto? product = JsonConvert.DeserializeObject<ProductDto>(await httpResponse.Content.ReadAsStringAsync());
            return product.price * amount;
        } else{
            return 0.0f;
        }
    }
}