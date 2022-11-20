using MongoDB.Driver;
using Category.API.Entities;

namespace Category.API.Data.Interfaces
{
    public interface ICategoryContext
    {
        IMongoCollection<PaymentCategory> PaymentCategories { get; }
    }
}
