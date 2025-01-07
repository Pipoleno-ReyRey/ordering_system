using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("products")]
public class ProductsController: ControllerBase{

    private readonly ProductsDb productsDb;

    public ProductsController(ProductsDb productsDb)
    {
        this.productsDb = productsDb;
    }

    [HttpGet("getProducts")]
    public async Task<IEnumerable<Products>> GetProducts(){
        return await productsDb.products.ToListAsync();
    }

    [HttpPost("postProduct")]
    public async Task<Products> PostProducts([FromBody] Products product){
        productsDb.Add(product);
        await productsDb.SaveChangesAsync();
        return product;
    }

    [HttpGet("getProduct")]
    public async Task<Products?> GetProducts([FromQuery] string name){
        return await productsDb.products.SingleOrDefaultAsync(p => p.name.ToLower().Contains(name.ToLower()));
    }

    [HttpPut("updateProduct")]
    public async Task<string> UpdateProducts([FromQuery] int serieNum, [FromBody] Products product){
        var productOld = await productsDb.products.SingleOrDefaultAsync(p => p.seriesNum == serieNum);

        productOld.name = product.name;
        productOld.description = product.description;
        productOld.price = product.price;
        productOld.amount = product.amount;

        await productsDb.SaveChangesAsync();

        return "actualizado";
    }
}