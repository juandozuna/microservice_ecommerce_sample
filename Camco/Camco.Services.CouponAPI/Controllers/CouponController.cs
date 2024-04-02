using Camco.Services.CouponAPI.Data;
using Camco.Services.CouponAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace Camco.Services.CouponAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CouponController(AppDbContext db) : ControllerBase
    {
        private readonly AppDbContext _db = db;
        
        [HttpGet]
        public object Get()
        {
            try
            {
                IEnumerable<Coupon> objList = _db.Coupons.ToList();
                return objList;
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}
