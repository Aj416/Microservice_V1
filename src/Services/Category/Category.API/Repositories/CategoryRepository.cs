using Category.API.Data.Interfaces;
using Category.API.Entities;
using Category.API.Repositories.Interfaces;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Category.API.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ICategoryContext _context;

        public CategoryRepository(ICategoryContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task CreatePaymentCategory(PaymentCategory category)
        {
            await _context.PaymentCategories.InsertOneAsync(category);
        }

        public async Task<bool> DeletePaymentCategory(string id)
        {
            FilterDefinition<PaymentCategory> filter = Builders<PaymentCategory>.Filter.Eq(p => p.Id, id);

            DeleteResult deleteResult = await _context
                                                .PaymentCategories
                                                .DeleteOneAsync(filter);

            return deleteResult.IsAcknowledged
                && deleteResult.DeletedCount > 0;
        }

        public async Task<IEnumerable<PaymentCategory>> GetPaymentCategories()
        {
            return await _context
                            .PaymentCategories
                            .Find(p => true)
                            .ToListAsync();
        }

        public async Task<PaymentCategory> GetPaymentCategory(string id)
        {
            return await _context
                           .PaymentCategories
                           .Find(p => p.Id == id)
                           .FirstOrDefaultAsync();
        }

        public async Task<PaymentCategory> GetPaymentCategoryByName(string name)
        {
            return await _context
                          .PaymentCategories
                          .Find(p => p.Name == name)
                          .FirstOrDefaultAsync();
        }

        public async Task<bool> UpdatePaymentCategory(PaymentCategory category)
        {
            var updateResult = await _context
                                        .PaymentCategories
                                        .ReplaceOneAsync(filter: g => g.Id == category.Id, replacement: category);

            return updateResult.IsAcknowledged
                    && updateResult.ModifiedCount > 0;
        }
    }
}
