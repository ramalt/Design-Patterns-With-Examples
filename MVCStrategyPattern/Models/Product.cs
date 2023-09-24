using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace MVCStrategyPattern.Models;

public class Product
{
    [Key]
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; } = null!;
    public string Name { get; set; } = null!;

    [Column(TypeName = " decimal(18,2)")]
    [BsonRepresentation(BsonType.Decimal128)]
    public decimal Price { get; set; }
    public int Stock { get; set; }
    public string UserId { get; set; } = null!;

    [BsonRepresentation(BsonType.DateTime)]
    public DateTime CreatedAt { get; set; }
}
