using System.Collections.Generic;

namespace Application.DTOs
{
    public class ListResponse<T>
    {
        public int Count { get; set; }
        public List<T> Data { get; set; }
    }
}