using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Domain.Contracts
{
    public interface IDocument
    {
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        ObjectId Id { get; set; }

        DateTime CreatedAt { get; }
    }
}