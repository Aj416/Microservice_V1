using Category.API.Data.Interfaces;
using Category.API.Entities;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace Category.API.Data
{
    public class CategoryContext : ICategoryContext
    {
        public CategoryContext(IConfiguration configuration)
        {
            var client = new MongoClient(configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
            var database = client.GetDatabase(configuration.GetValue<string>("DatabaseSettings:DatabaseName"));

            PaymentCategories = database.GetCollection<PaymentCategory>(configuration.GetValue<string>("DatabaseSettings:CollectionName"));
            CategoryContextSeed.SeedData(PaymentCategories);
        }

        public IMongoCollection<PaymentCategory> PaymentCategories { get; }
    }
}
