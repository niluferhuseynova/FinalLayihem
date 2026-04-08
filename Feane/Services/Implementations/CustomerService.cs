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

        public async Task CreateAsync(CustomersCreateVM vm)
        {
            string uniqueFileName = await vm.ImageName.FileUploadAsync(_folderPath);
            Customers customers = new()
            {
                Comment = vm.Comment,
                ImageName = uniqueFileName,
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
            return await _context.Customers.Select(p => new CustomersGetVM()
            {
                Name = p.Name,
                ImageName = p.ImageName,
                Comment = p.Comment,
                Id = p.Id
            }).ToListAsync();
        }

        public async Task<CustomersUpdateVM> GetByIdAsync(int id)
        {
            var product = await _context.Customers.FindAsync(id);
            if (product is null) return null;

            return new CustomersUpdateVM
            {
                Comment = product.Comment,
                Id = product.Id,
                Name = product.Name,
            };

        }

        public async Task Update(CustomersUpdateVM vm)
        {
            var product = await _context.Customers.FindAsync(vm.Id);
            if (product is null) return;

            if (vm.Name != null)
            {
                string newImage = await vm.Image.FileUploadAsync(_FolderPath);
                string oldImage = Path.Combine(_FolderPath, newImage);
                ExtensionMethod.DeleteFile(oldImage);
                product.ImageName = oldImage;

            }
            product.Name = vm.Name;
            product.Comment = vm.Comment;

            _context.Customers.Update(product);
            await _context.SaveChangesAsync();
        }
    
