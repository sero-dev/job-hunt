using System;
using MongoDB.Bson.Serialization.Attributes;

namespace Domain.Common
{
    public abstract class Document : IDocument
    {
        [BsonId]
        public Guid Id { get; set; }
    }
}