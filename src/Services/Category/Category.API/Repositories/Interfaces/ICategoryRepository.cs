using Category.API.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Category.API.Repositories.Interfaces
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<PaymentCategory>> GetPaymentCategories();
        Task<PaymentCategory> GetPaymentCategory(string id);
        Task<PaymentCategory> GetPaymentCategoryByName(string name);

        Task CreatePaymentCategory(PaymentCategory category);
        Task<bool> UpdatePaymentCategory(PaymentCategory category);
        Task<bool> DeletePaymentCategory(string id);
    }
}
