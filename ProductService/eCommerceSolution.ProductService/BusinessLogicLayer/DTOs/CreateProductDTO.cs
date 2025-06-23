namespace BusinessLogicLayer.DTOs;

public class CreateProductDTO
{
    public string Name { get; set; }
    public decimal? Price { get; set; }
    public string Category { get; set; }
    public int QuantityInStock {get; set;} 
}

public class EditProductDTO
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public decimal? Price { get; set; }
    public string Category { get; set; }
    public int QuantityInStock {get; set;} 
}