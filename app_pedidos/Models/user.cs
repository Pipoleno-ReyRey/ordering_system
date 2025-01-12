using System.Net.Http.Json;
using System.Text;
using System.Text.Json;

public class User{
    public int id {get; set;}
    public string? name {get; set;}
    public string? address {get; set;}
    public string? email {get; set;}
    public string? password {get; set;}
    private static readonly HttpClient httpClient = new HttpClient();
    public User(int id, string name, string address, string email, string password){
        this.id = id;
        this.name = name;
        this.address = address;
        this.email = email;
        this.password = password;

        httpClient.DefaultRequestHeaders.Add("accept", "application/json");
    }

    public static async Task<User> GetUser(string email, string password){
        HttpResponseMessage responseMessage = await httpClient.GetAsync($"https://users-image.onrender.com/users/getUser?email={email}&password={password}");
        var responseJson = await responseMessage.Content.ReadAsStringAsync();
        if(responseMessage.IsSuccessStatusCode){
            User? user = JsonSerializer.Deserialize<User>(responseJson);
            return user!;
        } else{
            return new User(0, "", "", "", "");
        }
    }

    public static async Task<User> CreateUser(string name, string address, string email, string password){
        User user = new User(0, name, address, email, password);
        string json = JsonSerializer.Serialize(user);
        string url = "https://users-image.onrender.com/users/postUser";
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        var httpResponseMessage = await httpClient.PostAsync(url, content);
        
        if(httpResponseMessage.IsSuccessStatusCode){
            var response = await httpResponseMessage.Content.ReadAsStringAsync();
            User? userCreated = JsonSerializer.Deserialize<User>(response);
            return userCreated!;
        } else{
            return new User(0, "nada", "nada", "nada", "nada");
        }
    }
}