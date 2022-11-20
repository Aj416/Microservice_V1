using Category.API.Entities;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace Category.API.Data
{
    public class CategoryContextSeed
    {
        public static void SeedData(IMongoCollection<PaymentCategory> categoryCollecttion)
        {
            bool existProduct = categoryCollecttion.Find(p => true).Any();
            if (!existProduct)
            {
                categoryCollecttion.InsertManyAsync(GetPreconfiguredProducts());
            }
        }

        private static IEnumerable<PaymentCategory> GetPreconfiguredProducts()
        {
            return new List<PaymentCategory>()
            {
                new PaymentCategory()
                {
                    Id = ObjectId.GenerateNewId().ToString(),
                    Name = "Other Expenses",
                    Description = "Miscellaneous Expenses"
                }
            };
        }
    }
}
