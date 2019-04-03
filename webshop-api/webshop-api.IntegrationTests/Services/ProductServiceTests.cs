using System;
using NUnit.Framework;
using webshop_api.Models;
using webshop_api.Repositories;
using webshop_api.Services;
using FluentAssertions;
using System.Transactions;
using System.Linq;

namespace webshop_api.IntegrationTests.Services
{
    public class ProductServiceTests
    {
        private ProductsService productsService;

        [SetUp]
        public void SetUp()
        {
            this.productsService = new ProductsService(new ProductsRepository(
                "Server=localhost;Port=8889;Database=webshop;Uid=root;Pwd=root;"));
        }

        [Test]
        public void Get_ReturnsResultsFromDatabase()
        {
            // Act
            var result = productsService.Get().Count;

            // Assert
            Assert.That(result, Is.EqualTo(3));
        }

        [Test]
        public void Get_GivenId_ReturnsResultFromDatabase()
        {
            // Arrange
            var id = 1;

            var productItem = new Product
            {
                Id = id,
                Name = "Black T-Shirt",
                Description = "100% Cotton T-Shirt Unisex",
                Price = 10,
                Image = "https://lp.weekday.com/app003prod?set=source[01_0410605_001_001],type[ECOMLOOK],device[hdpi],quality[80],ImageVersion[2018084]&call=url[file:/product/main]"
            };

            // Act
            var result = productsService.Get(id);

            // Assert
            result.Should().BeEquivalentTo(productItem);

        }

        [Test]
        public void Add_GivenValidNewsItem_SavesIt()
        {
            // Arrange
            const string ExpectedName = "Black T-Shirt";
            const string ExpectedDescription = "100% Cotton T-Shirt Unisex";
            const float ExpectedPrice = 10;
            const string ExpectedImage = "https://lp.weekday.com/app003prod?set=source[01_0410605_001_001],type[ECOMLOOK],device[hdpi],quality[80],ImageVersion[2018084]&call=url[file:/product/main]";
            var product = new Product
            {
                Name = ExpectedName,
                Description = ExpectedDescription,
                Price = ExpectedPrice,
                Image = ExpectedImage
            };

            // Act
            Product addedItem;
            using (new TransactionScope())
            {
                this.productsService.Add(product);

                addedItem = this.productsService.Get().Last();
            }

            // Assert

            Assert.That(addedItem, Is.Not.Null);
            Assert.That(addedItem.Id, Is.AtLeast(1));
            Assert.That(addedItem.Name, Is.EqualTo(ExpectedName));
            Assert.That(addedItem.Description, Is.EqualTo(ExpectedDescription));
        }
    }
}
