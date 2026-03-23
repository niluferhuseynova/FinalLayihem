using Feane.Services.Interfaces;
using Feane.ViewModels.BookTable;

namespace Feane.Services.Implementations
{
    public class BookTableService : IBookTableService
    {
        public Task CreateAsync(BookTableCreateVM vm)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
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
