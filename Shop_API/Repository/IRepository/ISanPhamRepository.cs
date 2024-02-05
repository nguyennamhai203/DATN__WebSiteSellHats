using Shop_Models.Entities;

namespace Shop_API.Repository.IRepository
{
    public interface ISanPhamRepository
    {
        public Task<bool> CreateAsync(SanPham model);
        public Task<List<SanPham>> GetAsync();
    }
}
