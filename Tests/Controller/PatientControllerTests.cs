using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using PatientManagement.Controllers;
using PatientManagement.Data;
using PatientManagement.Models;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace PatientManagement.Tests.Controllers
{
    public class PatientControllerTests
    {
        [Fact]
        public async void Create_ReturnsViewResult_WithDiseasesInViewBag()
        {
            // Arrange
            var mockContext = new Mock<ApplicationDbContext>();
            var diseases = new List<DiseaseInformation>
            {
                new DiseaseInformation { Id = 1, Name = "Disease 1" },
                new DiseaseInformation { Id = 2, Name = "Disease 2" },
                new DiseaseInformation { Id = 3, Name = "Disease 3" }
            }.AsQueryable();

            var mockDiseasesDbSet = new Mock<DbSet<DiseaseInformation>>();
            mockDiseasesDbSet.As<IQueryable<DiseaseInformation>>().Setup(m => m.Provider).Returns(diseases.Provider);
            mockDiseasesDbSet.As<IQueryable<DiseaseInformation>>().Setup(m => m.Expression).Returns(diseases.Expression);
            mockDiseasesDbSet.As<IQueryable<DiseaseInformation>>().Setup(m => m.ElementType).Returns(diseases.ElementType);
            mockDiseasesDbSet.As<IQueryable<DiseaseInformation>>().Setup(m => m.GetEnumerator()).Returns(diseases.GetEnumerator());

            mockContext.Setup(c => c.Diseases).Returns(mockDiseasesDbSet.Object);

            var controller = new PatientController(mockContext.Object);
       
            var result = await controller.Create();

            var viewResult = Assert.IsType<ViewResult>(result);
            var viewData = Assert.IsAssignableFrom<IDictionary<string, object>>(viewResult.ViewData);
            Assert.True(viewData.ContainsKey("Diseases"));

            var diseasesInViewBag = viewData["Diseases"] as List<DiseaseInformation>;
            Assert.Equal(diseases.Count(), diseasesInViewBag.Count);
            Assert.Equal(diseases.First().Name, diseasesInViewBag.First().Name);
            Assert.Equal(diseases.Last().Name, diseasesInViewBag.Last().Name);
        }
    }
}
