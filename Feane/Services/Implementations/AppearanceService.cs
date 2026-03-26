

using Feane.Context;
using Feane.Services.Interfaces;
using Feane.ViewModels.Appaeareance.cs;
using Microsoft.EntityFrameworkCore;

namespace Feane.Services.Implementations
{
    public class AppearanceService : IAppearanceService
        
    {
        private readonly AppDbContext _Context;
        private readonly IWebHostEnvironment _env;
        private readonly string _FolderPath;
        public AppearanceService(IServiceProvider serviceProvider, AppDbContext context);
       
        public AppearanceService(AppDbContext context, IWebHostEnvironment env, string folderPath)
        {
            _Context = context;
            _env = env;
            _FolderPath = folderPath;
        }

        public Task CreateAsync(AppaereanceCreateVM vm)

        {
            throw new NotImplementedException();
        }

        public async Task DeleteAsync(int id)
        {
            var AppearanceService = await GetAppearanceService().FindAsync(id);
            if (AppearanceService == null) return;
            _Context.AppearanceService.Remove(AppearanceService);
            await _Context.SaveChangesAsync();
        }

        private static object GetAppearanceService()
        {
            return _Context.AppearanceService;
        }

        public Task<List<AppaeareanceGetVM>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task Update(AppaeareanceUpdateVM vm)
        {
            throw new NotImplementedException();
        }

        public Task Update(int id)
        {
            throw new NotImplementedException();
        }
    }
}
