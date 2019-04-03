using System;
using System.Collections.Generic;
using System.Linq;
using FakeItEasy;
using NUnit.Framework;
using webshop_api.Services;
using webshop_api.Models;
using webshop_api.Repositories;

namespace webshop_api.UnitTests.Services
{
    public class ProductsServiceTests
    {

        private IProductsRepository productsRepository;
        private ProductsService productsService;

        [SetUp] // This attribute is what tells NUnit to use this method as a SetUp method.
        public void SetUp()
        {
            this.productsRepository = A.Fake<IProductsRepository>();
            this.productsService = new ProductsService(this.productsRepository);
            // Here you can add code that will run before each test. It will set it up :) (ti's no a trap bossmang!)
        }

        [Test]
        public void Get_ReturnsResultFromRepository()
        {
            // ARRANGE
            var productItem = new Product
            {
                Id = 13,
                Name = "White Tshirt",
                Description = "This is a white t-shirt",
                Price = 25,
                Image = "image-url"
            };

            var productItems = new List<Product> {productItem};

            A.CallTo(() => this.productsRepository.Get()).Returns(productItems);

            // ACT
            var result = this.productsService.Get().Single();

            // ASSERT
            Assert.That(result, Is.EqualTo(productItem));
        }

        [Test]
        public void Get_GivenId_ReturnsResultFromRepository()
        {
            // Arrange

            var Id = 13;

            var productItem = new Product
            {
                Id = Id,
                Name = "White Tshirt",
                Description = "This is a white t-shirt",
                Price = 25,
                Image = "image-url"
            };

            A.CallTo(() => this.productsRepository.Get(Id)).Returns(productItem);

            // Act
            var result = this.productsService.Get(Id);

            // Assert
            Assert.That(result, Is.EqualTo(productItem));

        }
    }
}
