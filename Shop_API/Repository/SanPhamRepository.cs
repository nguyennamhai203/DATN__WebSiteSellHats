using Microsoft.EntityFrameworkCore;
using Shop_API.AppDbContext;
using Shop_API.Repository.IRepository;
using Shop_Models.Entities;

namespace Shop_API.Repository
{
    public class SanPhamRepository : ISanPhamRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public SanPhamRepository(ApplicationDbContext context) 
        {
            _dbContext = context;
        }
        public async Task<bool> CreateAsync(SanPham model)
        {
            var checkMa = await _dbContext.SanPhams.AnyAsync(x => x.MaSanPham == model.MaSanPham);
            if (model == null || checkMa == true)
            {
                return false;
            }
            try
            {
                await _dbContext.SanPhams.AddAsync(model);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Task<List<SanPham>> GetAsync()
        {
            throw new NotImplementedException();
        }
    }
}
