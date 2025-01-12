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

        cartDb.Add(cart);
        await cartDb.SaveChangesAsync();

        return await cartDb.cart.SingleOrDefaultAsync(c => c.userId == userId);
    }

    [HttpPut("updateCartAdd")]
    public async Task<Cart?> UpdateCartAdd([FromQuery] int userId, [FromQuery] string product, [FromQuery] int amount){
        var cart = await cartDb.cart.SingleOrDefaultAsync(c => c.userId == userId);
        var contain = false;
        foreach(ProductDto _product in cart.listProducts){
            if (_product.name.Contains(product, StringComparison.OrdinalIgnoreCase)){
                _product.amount += amount;
                contain = true;
            }
        }

        if(contain == false){
            cart.listProducts.Add(await HttpConsume.GetProduct(product, amount));
        }

        foreach (var _product in cart.listProducts)
        {
            cart.count += _product.price * _product.amount;
        }

        await cartDb.SaveChangesAsync();
        return cart;
    }

    [HttpPut("updateCartRemove")]
    public async Task<Cart?> UpdateCartRemove([FromQuery] int userId, [FromQuery] string product, [FromQuery] int amount){
        var cart = await cartDb.cart.Include(p => p.listProducts).SingleOrDefaultAsync(c => c.userId == userId);
        var count = await HttpConsume.GetProduct(product, amount);

        var productCart = cart.listProducts.FirstOrDefault(p => p.name.Equals(product, StringComparison.OrdinalIgnoreCase));

        if (productCart != null)
        {
            if (productCart.amount > amount)
            {
                productCart.amount -= amount;
                productCart.count = productCart.amount * productCart.price;
            }
            else{
                cart.listProducts.Remove(productCart);
            }
            
        }

        cart.count = 0;

        foreach (var _product in cart.listProducts)
        {
            cart.count += _product.price * _product.amount;
        }

        await cartDb.SaveChangesAsync();
        return cart;
    }

    [HttpGet("getCart")]
    public async Task<Cart?> GetCart([FromQuery] int userId){
        var cart = await cartDb.cart.Include(c => c.listProducts).SingleOrDefaultAsync(c => c.userId == userId); 
        cart.count = 0;

        foreach (var product in cart.listProducts)
        {
            cart.count += product.price * product.amount;
        }
        return cart;
    }

}