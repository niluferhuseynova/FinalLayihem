using Feane.ViewModels.BookTable;

namespace Feane.Services.Interfaces
{
    public interface IBookTableService
    {
        Task<List<BookTableGetVM>> GetAllAsync();
        Task GetByIdAsync(int id);
        Task CreateAsync(BookTableCreateVM vm);
        Task Update(BookTableUpdateVM vm);
        Task Update(int id);
        Task DeleteAsync(int id);
    }
}
