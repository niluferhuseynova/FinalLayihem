using Feane.Context;
using Feane.Models;
using Feane.Services.Interfaces;
using Feane.ViewModels.BookTable;
using Microsoft.EntityFrameworkCore;

namespace Feane.Services.Implementations
{
    public class BookTableService : IBookTableService
    {
        private readonly AppDbContext _context;

        public BookTableService(AppDbContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(BookTableCreateVM vm)
        {
            string uniqueFileName = await vm.ImageName.FileUploadAsync(_folderPath);
            BookTable bookTable = new();      

        }

        public async Task DeleteAsync(int id)
        {
            var BookTable = await _context.BookTables.FindAsync(id);
            if (BookTable == null) return;
            _context.BookTables.Remove(BookTable);
            await _context.SaveChangesAsync();
        }

        public async Task<List<BookTableGetVM>> GetAllAsync()
        {
           return await _context.BookTables.Select(p => new BookTableGetVM ()
           {
               Id = p.Id,
               Name = p.Name,
               Email = p.Email,
               Date = DateTime.Now,
               PersonNumber = p.PersonNumber,
               PhoneNumber = p.PhoneNumber
           }).ToListAsync();
        }

        public async Task <BookTableUpdateVM> GetByIdAsync()
        {
           var product = await _context.BookTables.FindAsync(id);
            if (product is null) return null;

            return new BookTableUpdateVM
            {
              Id = product.Id,
              Date = DateTime.Now,
              Name = product.Name,
              Email = product.Email,
              PersonNumber= product.PersonNumber,
              PhoneNumber = product.PhoneNumber
              
            };
           
        }

        public async Task Update(BookTableUpdateVM vm)
        {
            var product = await _context.BookTable.FindAsync(vm.Id);
            if (product is null) return;

            if(vm.Name is not null)
            {
                string.newImage = await vm.Image
            }


        }

        
    }
}
