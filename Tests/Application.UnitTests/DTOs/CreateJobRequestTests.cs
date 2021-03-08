using System;
using Application.DTOs;
using Domain.Entities;
using Xunit;

namespace Application.UnitTests.DTOs
{
    public class CreateJobRequestTests
    {
        [Fact]
        public void GetValuesShouldReturnSetValues()
        {
            // Arrange
            string jobTitle = "JobTitle";
            string employer = "Employer";
            string city = "City";
            string state = "State";
            string status = "Status";
            decimal minimumSalary = decimal.MinValue;
            decimal maximumSalary = decimal.MaxValue;
            DateTime dateSubmitted = DateTime.MinValue;
            DateTime dateLastUpdated = DateTime.MaxValue;

            Amenity amenity = new Amenity();
            TechnologyStack technologyStack = new TechnologyStack();

            CreateJobRequest sut = new CreateJobRequest();
            
            // Act
            sut.JobTitle = jobTitle;
            sut.Employer = employer;
            sut.City = city;
            sut.State = state;
            sut.Status = status;
            sut.MinimumSalary = minimumSalary;
            sut.MaximumSalary = maximumSalary;
            sut.DateSubmitted = dateSubmitted;
            sut.DateLastUpdated = dateLastUpdated;
            sut.Amenities = amenity;
            sut.TechnologyStack = technologyStack;

            // Assert
            Assert.Equal(jobTitle, sut.JobTitle);
            Assert.Equal(employer, sut.Employer);
            Assert.Equal(city, sut.City);
            Assert.Equal(state, sut.State);
            Assert.Equal(status, sut.Status);
            Assert.Equal(minimumSalary, sut.MinimumSalary);
            Assert.Equal(maximumSalary, sut.MaximumSalary);
            Assert.Equal(dateSubmitted, sut.DateSubmitted);
            Assert.Equal(dateLastUpdated, sut.DateLastUpdated);
            Assert.Equal(amenity, sut.Amenities);
            Assert.Equal(technologyStack, sut.TechnologyStack);
        }
    }
}