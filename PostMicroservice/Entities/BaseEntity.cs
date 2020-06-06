using System;
using MongoDB.Bson.Serialization.Attributes;

namespace PostMicroservice.Entities
{
    public abstract class BaseEntity
    {
        [BsonId] public Guid Id { get; set; }
    }
}
