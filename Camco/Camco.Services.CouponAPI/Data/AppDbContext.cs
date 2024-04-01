using Camco.Services.CouponAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace Camco.Services.CouponAPI.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Coupon> Coupons { get; set; }
}