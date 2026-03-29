using Feane.Context;
using Feane.Helper;
using Feane.Models;
using Feane.Services.Interfaces;
using Feane.ViewModels.Customers;
using Microsoft.EntityFrameworkCore;

namespace Feane.Services.Implementations
{
    public class CustomerService : ICustomersService
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;
        private readonly string _FolderPath;

        public CustomerService(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
            _FolderPath = Path.Combine(_env.WebRootPath, "images");
        }

        Task ICustomersService.CreateAsync(CustomersCreateVM vm)
        {
            string uniqueFileName = await vm.ImageName.FileUploadAsync(_folderPath);
            Customers customers = new()
            {
                Comment = vm.Comment,
                ImageName = uniqueFileName,
                ImageUrl = uniqueFileName,
                Name = uniqueFileName
            };
            await _context.Customers.AddAsync(customers);
            await _context.SaveChangesAsync();

        public async Task DeleteAsync(int id)
        {
            var customers = await _context.Customers.FindAsync(id);
            if (customers == null) return;
            _context.Customers.Remove(customers);
            await _context.SaveChangesAsync();

        }

        public async Task<List<CustomersGetVM>> GetAllAsync()
        {
           return await _context.Customers.Select( p=> new CustomersGetVM()
           {
               Name = p.Name,
               ImageName= p.ImageName,
               Comment = p.Comment,
               Id = p.Id
           }).ToListAsync();
        }

        public async Task GetByIdAsync(int id)
        {
            await _context.Customers.FindAsync( id );
            return;
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
