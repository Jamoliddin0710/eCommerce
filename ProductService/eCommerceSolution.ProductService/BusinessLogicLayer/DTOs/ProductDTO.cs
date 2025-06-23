namespace BusinessLogicLayer.DTOs;

public class ProductDTO
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public decimal? Price { get; set; }
    public string Category { get; set; }
    public int QuantityInStock {get; set;} 
}