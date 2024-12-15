using EntityLayer.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete {
    public class Context : IdentityDbContext<AppUser,AppRole,int> {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            optionsBuilder.UseSqlServer("Server=DESKTOP-RHMNBG1\\SQLEXPRESS;initial Catalog=MDSCafe;integrated Security=true");
        }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<About> Abouts{ get; set; }
        public DbSet<Category> Categories{ get; set; }
        public DbSet<ContactMe> ContactMes{ get; set; }
        public DbSet<Discount> Discounts{ get; set; }
        public DbSet<Feature> Features{ get; set; }
        public DbSet<Product> Products{ get; set; }
        public DbSet<SocialMedia> SocialMedias{ get; set; }
        public DbSet<Testimonial> Testimonials{ get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<MoneyCase> MoneyCases { get; set; }
        public DbSet<CafeTable> CafeTables { get; set; }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<Basket> Baskets { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Message> Messages { get; set; }
    }
}
