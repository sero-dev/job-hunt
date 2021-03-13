using System.Collections.Generic;
using Application.DTOs;
using Application.Mappings;
using AutoMapper;
using Domain;
using Xunit;

namespace Application.UnitTests.Mappings
{
    public class JobProfileTests
    {
        private readonly IMapper _mapper;
        private readonly IConfigurationProvider _configuration;
        
        public JobProfileTests()
        {
            _configuration = new MapperConfiguration(c => c.AddProfile<JobProfile>());
            _mapper = new Mapper(_configuration);
        }
        
        [Fact]
        public void ShouldHaveValidConfiguration()
        {
            _configuration.AssertConfigurationIsValid();
        }

        [Fact]
        public void ShouldMapCreateJobRequestToJob()
        {
            // Arrange
            CreateJobRequest jobRequest = new CreateJobRequest();
            
            // Act
            Job job = _mapper.Map<Job>(jobRequest);
            
            // Assert
            Assert.NotNull(job);
            Assert.IsType<Job>(job);
        }

        [Fact]
        public void ShouldMapJobListToJobListResponse()
        {
            // Arrange
            List<Job> jobs = new List<Job>();
            
            // Act
            ListResponse<Job> response = _mapper.Map<ListResponse<Job>>(jobs);
            
            // Assert
            Assert.NotNull(response);
            Assert.NotNull(response.Data);
            Assert.Equal(0, response.Count);
        }
    }
}