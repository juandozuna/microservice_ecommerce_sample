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
        
        [HttpGet]
        [Route("get-by-code/{code}")]
        public ResponseDto<CouponDto?> Get(string code)
        {
            try
            {
                Coupon? obj = db.Coupons.FirstOrDefault(c => c.CouponCode == code);
                var mapped = mapper.Map<CouponDto?>(obj);
                return new ResponseDto<CouponDto?> { Data = mapped };
            }
            catch (Exception e)
            {
                return new ResponseDto<CouponDto?> { IsSuccess = false, Message = e.Message };
            }
        }
        
        [HttpPost]
        public ResponseDto<CouponDto> Post(CouponDto dto)
        {
            try
            {
                Coupon obj = mapper.Map<Coupon>(dto);
                db.Coupons.Add(obj);
                db.SaveChanges();
                var mapped = mapper.Map<CouponDto>(obj);
                return new ResponseDto<CouponDto> { Data = mapped };
            }
            catch (Exception e)
            {
                return new ResponseDto<CouponDto> { IsSuccess = false, Message = e.Message };
            }
        }
        
        [HttpPut]
        public ResponseDto<CouponDto> Put(CouponDto dto)
        {
            try
            {
                Coupon obj = mapper.Map<Coupon>(dto);
                db.Coupons.Update(obj);
                db.SaveChanges();
                var mapped = mapper.Map<CouponDto>(obj);
                return new ResponseDto<CouponDto> { Data = mapped };
            }
            catch (Exception e)
            {
                return new ResponseDto<CouponDto> { IsSuccess = false, Message = e.Message };
            }
        }
        
        [HttpDelete]
        [Route("{id:int}")]
        public ResponseDto<CouponDto?> Delete(int id)
        {
            try
            {
                Coupon? obj = db.Coupons.Find(id);
                db.Coupons.Remove(obj);
                db.SaveChanges();
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
