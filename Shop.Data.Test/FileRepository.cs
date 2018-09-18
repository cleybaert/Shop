using Shop.Data.File;
using Shop.Model.Interfaces;
using Shop.Model.Parameters;
using System;
using Xunit;

namespace Shop.Data.Test
{
    [CollectionDefinition("Repository collection")]
    public class RepositoryCollection : ICollectionFixture<ProductRepository>
    {
        // This class has no code, and is never created. Its purpose is simply
        // to be the place to apply [CollectionDefinition] and all the
        // ICollectionFixture<> interfaces.
    }

    [Collection("Repository collection")]
    public class FileRepository
    {
        private readonly ProductRepository repository;

        public FileRepository(ProductRepository repository)
        {
            this.repository = repository;
        }

        [Theory]
        [InlineData("clothing")]
        [InlineData("girls")]
        [InlineData("sleeping")]
        [InlineData("eat and drink")]
        public void ShouldReturnProducts(string category)
        {
            var products = repository.GetProducts(new ProductParameters() { Category = category });
            Assert.NotNull(products);
            Assert.NotEmpty(products);
        }

        [Theory]
        [InlineData("abcd")]
        public void ShouldNotReturnProducts(string category)
        {
            var products = repository.GetProducts(new ProductParameters() { Category = category });
            Assert.Empty(products);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void ShouldReturnCategory(int id)
        {
            var category = repository.GetCategoryById(id);
            Assert.NotNull(category);
            category = repository.GetFullCategoryById(id);
            Assert.NotNull(category);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(10000)]
        public void ShouldNotReturnCategory(int id)
        {
            var category = repository.GetCategoryById(id);
            Assert.Null(category);
            category = repository.GetFullCategoryById(id);
            Assert.Null(category);
        }
    }
}
