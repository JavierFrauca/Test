using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Moq;
using TEST.Controllers;
using TEST.Dtos;
using TEST.Services;
using Xunit;

namespace TEST.Tests.Controllers
{
    public class Tabla1ControllerTest
    {
        [Fact]
        public async Task List_Returns_OkResult()
        {
            // Arrange
            var mockService = new Mock<ICommonService<Tabla1Dto>>();
            var controller = new Tabla1Controller(mockService.Object);
            mockService.Setup(service => service.List()).ReturnsAsync([new() { Id = 1, Campo1 = "alkajsdf", Campo2 = "", Campo3 = "" },
                                                                       new() { Id = 2, Campo1 = "sdfgfgsdfgsdfg", Campo2 = "", Campo3 = "" },
                                                                       new() { Id = 3, Campo1 = "aldfgfgjsdf", Campo2 = "", Campo3 = "" }
                                                                      ]);
            // Act
            var result = await controller.List();
            // Assert
            Assert.IsAssignableFrom<IEnumerable<Tabla1Dto>>(result.Value);
        }
        [Fact]
        public async Task Read_WithValidId_Returns_OkResult()
        {
            // Arrange
            var mockService = new Mock<ICommonService<Tabla1Dto>>();
            var controller = new Tabla1Controller(mockService.Object);
            var id = 1;

            mockService.Setup(service => service.Read(id)).ReturnsAsync((true, new Tabla1Dto(), new List<ValidationFailure>()));

            // Act
            var result = await controller.Read(id);

            // Assert
            Assert.IsType<OkObjectResult>(result.Result);
        }

        [Fact]
        public async Task Read_WithInvalidId_Returns_BadRequest()
        {
            // Arrange
            var mockService = new Mock<ICommonService<Tabla1Dto>>();
            var controller = new Tabla1Controller(mockService.Object);
            var id = -1;
            mockService.Setup(service => service.Read(id)).ReturnsAsync((false, new Tabla1Dto(), new List<ValidationFailure> { new() { ErrorMessage = "Invalid data" } }));

            // Act
            var result = await controller.Read(id);

            // Assert
            Assert.IsType<BadRequestObjectResult>(result.Result);
        }

        [Fact]
        public async Task Delete_WithValidId_Returns_OkResult()
        {
            // Arrange
            var mockService = new Mock<ICommonService<Tabla1Dto>>();
            var controller = new Tabla1Controller(mockService.Object);
            var id = 1;

            mockService.Setup(service => service.Delete(id)).ReturnsAsync((true, new Tabla1Dto(), new List<ValidationFailure>()));

            // Act
            var result = await controller.Delete(id);

            // Assert
            Assert.IsType<OkObjectResult>(result.Result);
        }

        [Fact]
        public async Task Delete_WithInvalidId_Returns_BadRequest()
        {
            // Arrange
            var mockService = new Mock<ICommonService<Tabla1Dto>>();
            var controller = new Tabla1Controller(mockService.Object);
            var id = -1;

            mockService.Setup(service => service.Delete(id)).ReturnsAsync((false, new Tabla1Dto(), new List<ValidationFailure> { new() { ErrorMessage = "Invalid data" } }));

            // Act
            var result = await controller.Delete(id);

            // Assert
            Assert.IsType<BadRequestObjectResult>(result.Result);
        }

        [Fact]
        public async Task Write_Returns_OkResult()
        {
            // Arrange
            var mockService = new Mock<ICommonService<Tabla1Dto>>();
            var controller = new Tabla1Controller(mockService.Object);
            var data = new Tabla1Dto();

            mockService.Setup(service => service.Write(data)).ReturnsAsync((true, new Tabla1Dto(), new List<ValidationFailure>()));

            // Act
            var result = await controller.Write(data);

            // Assert
            Assert.IsType<OkObjectResult>(result.Result);
        }

        [Fact]
        public async Task Write_Returns_BadRequest()
        {
            // Arrange
            var mockService = new Mock<ICommonService<Tabla1Dto>>();
            var controller = new Tabla1Controller(mockService.Object);
            var data = new Tabla1Dto();
            mockService.Setup(service => service.Write(data)).ReturnsAsync((false, data, new List<ValidationFailure> { new() { ErrorMessage = "Invalid data" } }));

            // Act
            var result = await controller.Write(data);

            // Assert
            Assert.IsType<BadRequestObjectResult>(result.Result);
        }

        [Fact]
        public async Task Add_Returns_OkResult()
        {
            // Arrange
            var mockService = new Mock<ICommonService<Tabla1Dto>>();
            var controller = new Tabla1Controller(mockService.Object);
            var data = new Tabla1Dto();

            mockService.Setup(service => service.Add(data)).ReturnsAsync((true, data, new List<ValidationFailure>()));

            // Act
            var result = await controller.Add(data);

            // Assert
            Assert.IsType<OkObjectResult>(result.Result);
        }

        [Fact]
        public async Task Add_Returns_BadRequest()
        {
            // Arrange
            var mockService = new Mock<ICommonService<Tabla1Dto>>();
            var controller = new Tabla1Controller(mockService.Object);
            var data = new Tabla1Dto();

            mockService.Setup(service => service.Add(data)).ReturnsAsync((false, data, new List<ValidationFailure> { new() { ErrorMessage = "Invalid data" } }));

            // Act
            var result = await controller.Add(data);

            // Assert
            Assert.IsType<BadRequestObjectResult>(result.Result);
        }
    }
}
