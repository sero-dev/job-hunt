using System.Collections.Generic;
using Application.DTOs;
using Xunit;

namespace Application.UnitTests.DTOs
{
    public class ListResponseTests
    {
        [Fact]
        public void GetValuesShouldReturnSetValues()
        {
            // Arrange
            int count = 5;
            List<int> data = new List<int>() {1, 2, 3, 4, 5};
            
            // Act
            ListResponse<int> sut = new ListResponse<int>()
            {
                Count = count,
                Data = data
            };
            
            // Assert
            Assert.Equal(count, sut.Count);
            Assert.Equal(data, sut.Data);
        }
    }
}