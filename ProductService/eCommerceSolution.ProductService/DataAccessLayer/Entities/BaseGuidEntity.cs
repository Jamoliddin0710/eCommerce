using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer.Entities;

public class BaseGuidEntity : AuditEntity
{
    [Key]
    public Guid Id { get; set; }
}