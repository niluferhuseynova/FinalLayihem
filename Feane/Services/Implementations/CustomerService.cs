using Feane.Context;
using Feane.Services.Interfaces;
using Feane.ViewModels.Customers;
using Microsoft.EntityFrameworkCore;

namespace Feane.Services.Implementations
{
    public class CustomerService : ICustomersService
    {
        private readonly AppDbContext context;
        private readonly IWebHostEnvironment _env;
        private readonly string _FolderPath;

        public CustomerService(AppDbContext context, IWebHostEnvironment env = null)
        {
            this.context = context;
            _env = env;
            _FolderPath = Path.Combine(_env.WebRootPath, "images");
        }

        public Task CreateAsync(CustomersCreateVM vm)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteAsync(int id)
        {
            var CustomersService = await _context.CustomersService.FindAsync(id);
            if (CustomersService == null) return;
            _context.CustomersService.Remove(customersService);
            await _context.SaveChangesAsync();

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
