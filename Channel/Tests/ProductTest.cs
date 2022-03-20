using Moq;
using NUnit.Framework;
using Service.Implementation;
using Service.Interfaces;
using Service.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChannelEngineTest
{
    public class ProductTest
    {
        private Mock<IOrderApiAsync> _orderApiAsyncMock;
        [SetUp]
        public void Setup()
        {
            _orderApiAsyncMock = new Mock<IOrderApiAsync>();
            _orderApiAsyncMock.Setup(x => x.GetByFilterAsync(It.IsAny<OrderFilterOption>()))
            .Returns(Task.FromResult(DummyOrderResponse()));
        }

        private static ProductOrderResponse DummyOrderResponse()
        {
            var orderReposne = new ProductOrderResponse();
            orderReposne.Success = true;
            orderReposne.Count = 6;
            orderReposne.Content = new List<MerchantOrderResponse>();
            orderReposne.Content.Add(new MerchantOrderResponse()
            {
                Id = 1,
                Lines = new List<MerchantOrderLineResponse>
                     {
                         new MerchantOrderLineResponse()
                         {
                             Description = "product 1",
                             MerchantProductNo="1234",
                             Gtin = "1212",
                             Quantity = 2
                         }}
            });
            orderReposne.Content.Add(new MerchantOrderResponse()
            {
                Id = 2,
                Lines = new List<MerchantOrderLineResponse>
                        {
                         new MerchantOrderLineResponse()
                         {
                             Description = "product 1",
                             MerchantProductNo="1234",
                             Gtin = "1212",
                             Quantity = 1
                         }}
            });
            orderReposne.Content.Add(new MerchantOrderResponse()
            {
                Id = 1,
                Lines = new List<MerchantOrderLineResponse>
                        {
                            new MerchantOrderLineResponse()
                         {
                             Description = "product 2",
                             MerchantProductNo="321",
                             Gtin = "1212",
                             Quantity = 2
                         }}
            });
            orderReposne.Content.Add(new MerchantOrderResponse()
            {
                Id = 1,
                Lines = new List<MerchantOrderLineResponse>
                        {
                            new MerchantOrderLineResponse()
                         {
                             Description = "product 2",
                             MerchantProductNo="321",
                             Gtin = "1212",
                             Quantity = 2
                         }}
            });
            orderReposne.Content.Add(new MerchantOrderResponse()
            {
                Id = 1,
                Lines = new List<MerchantOrderLineResponse>
                        {
                            new MerchantOrderLineResponse()
                         {
                             Description = "product 3",
                             MerchantProductNo="258",
                             Gtin = "12121",
                             Quantity = 2
                         }}
            });
            orderReposne.Content.Add(new MerchantOrderResponse()
            {
                Id = 1,
                Lines = new List<MerchantOrderLineResponse>
                        {
                            new MerchantOrderLineResponse()
                         {
                             Description = "product 4",
                             MerchantProductNo="159",
                             Gtin = "753",
                             Quantity = 1
                         }}
            });
            return orderReposne;
        }
        [Test]
        public void TestTopNSoldProduct()
        {
            // Arrange
            ProductApiAsync productAsync = new ProductApiAsync(_orderApiAsyncMock.Object);
            List<TopSoldProduct> expectedProduct = new List<TopSoldProduct>();
            expectedProduct.Add(new TopSoldProduct("1212", "product 2", 4));
            expectedProduct.Add(new TopSoldProduct("1212", "product 1", 3));
            expectedProduct.Add(new TopSoldProduct("12121", "product 3", 2));
            expectedProduct.Add(new TopSoldProduct("753", "product 4", 1));
            // Act
            var result = productAsync.GetTopSoldProduct(5).Result;
            // Assert
            Assert.That(result, Is.EqualTo(expectedProduct).Using(new TopSoldProductComparer()));
        }
    }
}