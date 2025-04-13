

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PersonDirectory.Core.DTO;
using PersonDirectory.Core.Models;
using PersonDirectory.Core.RepositoryContract;
using PersonDirectory.Core.Service;
using System;

namespace PersonDirectory.Tests.UnitTests;
[TestClass]
public class PersonServiceTests
{
    [TestMethod]
    public async Task GetPersonsAsync_MergesResultsFromAllRepositories()
    {
        // Arrange
        var mockRepo1 = new Mock<IPersonRepository>();
        mockRepo1.Setup(x => x.GetPersonsAsync(It.IsAny<string>()))
        .ReturnsAsync(new List<ResponseDto> { new ResponseDto { FirstName = "test" } });

        var mockRepo2 = new Mock<IPersonRepository>();
        mockRepo2.Setup(x => x.GetPersonsAsync(It.IsAny<string>()))
        .ReturnsAsync(new List<ResponseDto> { new ResponseDto { FirstName = "test" } });

        var service = new PersonService(new[] { mockRepo1.Object, mockRepo2.Object });

        // Act
        var result = await service.GetPersonsAsync(null);

        // Assert
        Assert.AreEqual(2, result.Count());
    }
}
