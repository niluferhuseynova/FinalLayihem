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
            BookTable bookTable = new()
            {
                Date = vm.Date,
                Email = vm.Email,
                Name = vm.Name,
                PersonNumber = vm.PersonNumber,
                PhoneNumber = vm.PhoneNumber
            };
            await _context.BookTables.AddAsync(bookTable);
            await _context.SaveChangesAsync();

        }

        public async Task DeleteAsync(int id)
        {
            var bookTable = await _context.BookTables.FindAsync(id);
            if (bookTable == null) return;
            _context.BookTables.Remove(bookTable);
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

        public async Task <BookTableUpdateVM> GetByIdAsync(int id)
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
            var bookTable = await _context.BookTables.FindAsync(vm.Id);
            if (bookTable is null) return;

            bookTable.Name = vm.Name;
            bookTable.Email = vm.Email;
            bookTable.Date = vm.Date;
            bookTable.PhoneNumber = vm.PhoneNumber;
            bookTable.PersonNumber = vm.PersonNumber;

            _context.BookTables.Update(bookTable);
            await _context.SaveChangesAsync();

           
        }

        
    }
}
