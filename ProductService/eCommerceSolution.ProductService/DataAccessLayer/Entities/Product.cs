namespace DataAccessLayer.Entities;

public class Product : BaseGuidEntity
{
    public string Name { get; set; }
    public decimal? Price { get; set; }
    public string Category { get; set; }
    public int QuantityInStock {get; set;} 
}