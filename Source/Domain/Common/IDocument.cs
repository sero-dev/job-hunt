using System;
using MongoDB.Bson.Serialization.Attributes;

namespace Domain.Common
{
    public interface IDocument
    {
        [BsonId]
        public Guid Id { get; set; }
    }
}