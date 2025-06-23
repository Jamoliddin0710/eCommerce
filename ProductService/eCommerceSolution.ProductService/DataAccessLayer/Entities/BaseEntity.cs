using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer.Entities;

public class BaseEntity : AuditEntity
{
    [Key]
    public long Id { get; set; }
}