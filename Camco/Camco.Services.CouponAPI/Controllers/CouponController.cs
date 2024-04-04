using AutoMapper;
using Camco.Services.CouponAPI.Data;
using Camco.Services.CouponAPI.Models;
using Camco.Services.CouponAPI.Models.Dto;
using Microsoft.AspNetCore.Mvc;

namespace Camco.Services.CouponAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CouponController(AppDbContext db, IMapper mapper) : ControllerBase
    {
        [HttpGet]
        public ResponseDto<IEnumerable<CouponDto>> Get()
        {
            try
            {
                IEnumerable<Coupon> objList = db.Coupons.ToList();
                var mapped = mapper.Map<IEnumerable<CouponDto>>(objList);
                return new ResponseDto<IEnumerable<CouponDto>> { Data = mapped };
            }
            catch (Exception e)
            {
                return new ResponseDto<IEnumerable<CouponDto>> { IsSuccess = false, Message = e.Message };
            }
        }
        
        [HttpGet]
        [Route("{id:int}")]
        public ResponseDto<CouponDto?> Get(int id)
        {
            try
            {
                Coupon? obj = db.Coupons.Find(id);
                var mapped = mapper.Map<CouponDto?>(obj);
                return new ResponseDto<CouponDto?> { Data = mapped };
            }
            catch (Exception e)
            {
                return new ResponseDto<CouponDto?> { IsSuccess = false, Message = e.Message };
            }
        }
    }
}
