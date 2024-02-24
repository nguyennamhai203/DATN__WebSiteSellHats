using Microsoft.EntityFrameworkCore;
using Shop_API.AppDbContext;
using Shop_API.Repository.IRepository;
using Shop_Models.Dto;
using Shop_Models.Entities;

namespace Shop_API.Repository
{
    public class ChatLieuRepository : IChatLieuRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public static int PAGE_SIZE { get; set; } = 2;
        public ChatLieuRepository(ApplicationDbContext context)
        {
            _dbContext = context;
        }

        public async Task<ResponseDto> CreateAsync(ChatLieu model)
        {
            var checkMa = await _dbContext.ChatLieus.AnyAsync(x => x.MaChatLieu == model.MaChatLieu);
            if (model == null || checkMa == true)
            {
                return new ResponseDto
                {
                    Result = null,
                    IsSuccess = false,
                    Code = 400,
                    Message = "Trùng Mã",
                };
            }
            try
            {
                await _dbContext.ChatLieus.AddAsync(model);
                await _dbContext.SaveChangesAsync();
                return new ResponseDto
                {
                    Result = null,
                    IsSuccess = true,
                    Code = 200,
                    Message = "Thành Công",
                };
            }
            catch (Exception)
            {
                return new ResponseDto
                {
                    Result = null,
                    IsSuccess = false,
                    Code = 500,
                    Message = "Lỗi Hệ Thống",
                };
            }
        }

        public async Task<ResponseDto> UpdateAsync(ChatLieu model)
        {
            var chatLieu = await _dbContext.ChatLieus.FindAsync(model.Guid);
            if (chatLieu == null)
            {
                return new ResponseDto
                {
                    Result = null,
                    IsSuccess = false,
                    Code = 404,
                    Message = "Không Tim Thấy Bản Ghi",
                };
            }
            try
            {
                chatLieu.MaChatLieu = model.MaChatLieu;
                chatLieu.TenChatLieu = model.TenChatLieu;
                chatLieu.TrangThai = model.TrangThai;
                _dbContext.ChatLieus.Update(chatLieu);
                await _dbContext.SaveChangesAsync();
                return new ResponseDto
                {
                    Result = null,
                    IsSuccess = true,
                    Code = 200,
                    Message = "Thành Công",
                };
            }
            catch (Exception)
            {
                return new ResponseDto
                {
                    Result = null,
                    IsSuccess = false,
                    Code = 500,
                    Message = "Lỗi Hệ Thống",
                };
            }
        }

        public async Task<ResponseDto> DeleteAsync(Guid Id)
        {
            var chatLieu = await _dbContext.ChatLieus.FindAsync(Id);
            if (chatLieu == null)
            {
                return new ResponseDto
                {
                    Result = null,
                    IsSuccess = false,
                    Code = 404,
                    Message = "Không Tim Thấy Bản Ghi",
                };
            }
            try
            {
                chatLieu.TrangThai = 2;
                _dbContext.ChatLieus.Update(chatLieu);
                await _dbContext.SaveChangesAsync();
                return new ResponseDto
                {
                    Result = null,
                    IsSuccess = true,
                    Code = 200,
                    Message = "Xóa Thành Công",
                };
            }
            catch (Exception)
            {
                return new ResponseDto
                {
                    Result = null,
                    IsSuccess = false,
                    Code = 500,
                    Message = "Lỗi Hệ Thống",
                };
            }
        }

        public async Task<List<ChatLieu>> GetAsync()
        {
            var list = await _dbContext.ChatLieus.ToListAsync();
            return list;
        }

        public async Task<List<ChatLieu>> GetAsync(int? status, int page = 1)
        {
            var list = _dbContext.ChatLieus.AsQueryable();
            if (status.HasValue)
            {
                list = list.Where(x => x.TrangThai == status);
            }

            #region Paging
            list = list.Skip((page - 1) * PAGE_SIZE).Take(PAGE_SIZE);

            #endregion

            var result = list.Select(sp => new ChatLieu
            {
                MaChatLieu = sp.MaChatLieu,
                TenChatLieu = sp.TenChatLieu,
                TrangThai = sp.TrangThai
            });
            return result.ToList();
        }
    }
}
