using Feane.ViewModels.Customers;

namespace Feane.Services.Interfaces
{
    public interface ICustomersService
    {
        Task<List<CustomersGetVM>> GetAllAsync();
        Task GetByIdAsync(int id);
        Task CreateAsync(CustomersCreateVM vm);
        Task Update(CustomersUpdateVM vm);
        Task Update(int id);
        Task DeleteAsync(int id);
    }
}
