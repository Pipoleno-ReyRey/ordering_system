using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("cart")]
public class CartController: ControllerBase{

    private readonly CartDb cartDb;
    public CartController(CartDb cartDb){
        this.cartDb = cartDb;
    }

    [HttpPost("postCart")]
    public async Task<Cart?> PostCart([FromQuery] int userId){
        var cart = new Cart();
        cart.userId = userId;
        cart.products = "";
        cart.count = 0.0f;

        cartDb.Add(cart);
        await cartDb.SaveChangesAsync();

        return await cartDb.cart.SingleOrDefaultAsync(c => c.userId == userId);
    }

    [HttpPut("updateCartAdd")]
    public async Task<Cart?> UpdateCartAdd([FromQuery] int userId, [FromQuery] string product, [FromQuery] int amount){
        var cart = await cartDb.cart.SingleOrDefaultAsync(c => c.userId == userId);
        var count = await HttpConsume.GetProduct(product, amount);
        cart.products += $" {product},";
        cart.count += count;

        await cartDb.SaveChangesAsync();
        return cart;
    }

    [HttpPut("updateCartRemove")]
    public async Task<Cart?> UpdateCartRemove([FromQuery] int userId, [FromQuery] string product, [FromQuery] int amount){
        var cart = await cartDb.cart.SingleOrDefaultAsync(c => c.userId == userId);
        var count = await HttpConsume.GetProduct(product, amount);
        string products = cart.products.Replace($" {product},", "", StringComparison.OrdinalIgnoreCase);
        cart.products = products;
        cart.count -= count;

        await cartDb.SaveChangesAsync();
        return cart;
    }

    [HttpGet("getCart")]
    public async Task<Cart?> GetCart([FromQuery] int userId){
        return await cartDb.cart.SingleOrDefaultAsync(c => c.userId == userId);
    }

}