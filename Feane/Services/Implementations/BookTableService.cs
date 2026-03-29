using Feane.Context;
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

        public Task CreateAsync(BookTableCreateVM vm)
        {
            throw new NotImplementedException();
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

        public async Task GetByIdAsync(int id)
        {
            await _context.BookTables.FindAsync(id);
            return;
        }

        public Task Update(BookTableUpdateVM vm)
        {
            throw new NotImplementedException();
        }

        public Task Update(int id)
        {
            throw new NotImplementedException();
        }
    }
}
