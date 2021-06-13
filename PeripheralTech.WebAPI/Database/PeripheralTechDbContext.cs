using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PeripheralTech.WebAPI.Database
{
    public class PeripheralTechDbContext : DbContext
    {
        public PeripheralTechDbContext()
        {

        }
        public PeripheralTechDbContext(DbContextOptions<PeripheralTechDbContext> options) : base(options)
        {

        }

        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<ProductType> ProductType { get; set; }
        public virtual DbSet<ProductImage> ProductImage { get; set; }
        public virtual DbSet<ProductVideo> ProductVideo { get; set; }
        public virtual DbSet<City> City { get; set; }
        public virtual DbSet<Country> Country { get; set; }
        public virtual DbSet<Company> Company { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<OrderStatus> OrderStatus { get; set; }
        public virtual DbSet<OrderProduct> OrderProduct { get; set; }
        public virtual DbSet<Discount> Discount { get; set; }
        public virtual DbSet<Bill> Bill { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<UserRole> UserRole { get; set; }
        public virtual DbSet<UserFavoriteProduct> UserFavoriteProduct { get; set; }
        public virtual DbSet<UserReview> UserReview{ get; set; }
        public virtual DbSet<StaffReview> StaffReview { get; set; }
        public virtual DbSet<News> News { get; set; }
    }
}
