using System;
using MongoDB.Bson;

namespace Domain.Contracts
{
    public abstract class Document : IDocument
    {
        public ObjectId Id { get; set; }

        public DateTime CreatedAt => Id.CreationTime;
    }
}