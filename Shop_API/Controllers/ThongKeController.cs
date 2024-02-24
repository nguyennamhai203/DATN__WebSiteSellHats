using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shop_API.Repository.IRepository;
using Shop_Models.Entities;

namespace Shop_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ThongKeController : ControllerBase
    {
        private readonly IThongKeRepository _repository;

        public ThongKeController(IThongKeRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("Get")]
        public async Task<IActionResult> Get(int? status, int page = 1)
        {
            var result = await _repository.GetAsync(status, page);
            return Ok(result);
        }


        [HttpPost("CreateAsync")]
        public async Task<IActionResult> CreateAsync(ThongKe obj)
        {
            var respon = await _repository.CreateAsync(obj);
            if (respon.IsSuccess == true)
            {
                return Ok(respon);
            }
            else return BadRequest(respon);
        }


        [HttpPut("UpdateAsync")]
        public async Task<IActionResult> UpdateAsync(ThongKe obj)
        {
            var respon = await _repository.UpdateAsync(obj);
            if (respon.IsSuccess == true)
            {
                return Ok(respon);
            }
            else return BadRequest(respon);
        }

        //[HttpDelete("DeleteAsync")]
        //public async Task<IActionResult> DeleteAsync(Guid Id)
        //{
        //    var respon = await _repository.DeleteAsync(Id);
        //    if (respon.IsSuccess == true)
        //    {
        //        return Ok(respon);
        //    }
        //    else return BadRequest(respon);
        //}
    }
}
