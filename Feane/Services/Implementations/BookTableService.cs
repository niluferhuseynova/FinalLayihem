using Feane.Services.Interfaces;
using Feane.ViewModels.BookTable;
using Microsoft.EntityFrameworkCore;

namespace Feane.Services.Implementations
{
    public class BookTableService : IBookTableService
    {
        {
        public Task CreateAsync(BookTableCreateVM vm)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteAsync(int id)
        {
            var BookTableService = await _context.BookTableService.FindAsync(id);
            if (BookTableService == null) return;
            _context.BookTableServices.Remove(BookTableService);
            await _context.SaveChangesAsync();
        }

        public Task<List<BookTableGetVM>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task GetByIdAsync(int id)
        {
            throw new NotImplementedException();
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
