using System.ComponentModel.DataAnnotations;

public class Cart{
    public int id {get; set;}
    public int userId {get; set;}
    public float? count {get; set;} = 0.0f;
    public ICollection<ProductDto> listProducts {get; set;} = new List<ProductDto>();
}