using BarTenderJoe.Application.Commands;
using BarTenderJoe.Application.Interfaces;
using BarTenderJoe.Domain.Entities;
using BarTenderJoe.Domain.Services;
using FluentAssertions;
using Moq;
using Xunit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarTenderJoe.Test.TestCases
{
    public class MixDrinkHandlerTests
    {
        [Fact]
        public void Handle_ValidProduct_ReturnsDrink()
        {
            // Arrange
            var mockRepo = new Mock<IProductRepository>();
            mockRepo.Setup(r => r.GetById(1)).Returns(new Product(1, "Milk"));

            var mockStrategy = new Mock<IDrinkMixerStrategy>();
            mockStrategy.Setup(s => s.Mix(It.IsAny<Product>())).Returns("Milkshake is ready!");

            var handler = new MixDrinkHandler(mockRepo.Object, new List<IDrinkMixerStrategy> { mockStrategy.Object });

            // Act
            var result = handler.Handle(new MixDrinkCommand { ProductId = 1 });

            // Assert
            result.Should().Be("Milkshake is ready!");
        }

        [Fact]
        public void Handle_InvalidProduct_ThrowsException()
        {
            var mockRepo = new Mock<IProductRepository>();
            mockRepo.Setup(r => r.GetById(99)).Returns((Product)null);

            var handler = new MixDrinkHandler(mockRepo.Object, new List<IDrinkMixerStrategy>());

            Assert.Throws<ArgumentException>(() => handler.Handle(new MixDrinkCommand { ProductId = 99 }));
        }
    }
}
