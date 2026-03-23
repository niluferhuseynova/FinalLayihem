using Feane.Services.Interfaces;
using Feane.ViewModels.Customers;

namespace Feane.Services.Implementations
{
    public class CustomersService : ICustomersService
    {
        public Task CreateAsync(CustomersCreateVM vm)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<CustomersGetVM>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task Update(CustomersUpdateVM vm)
        {
            throw new NotImplementedException();
        }

        public Task Update(int id)
        {
            throw new NotImplementedException();
        }
    }
}
