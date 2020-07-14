using AspNetShop.Server.Domain.Entities;
using AspNetShop.Shared.ModelView;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AspNetShop.Server.Domain

{
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}
        public DbSet<ProductEntity> Product { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Stock> Stock { get; set; }
        public DbSet<OrderEntity> Order { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=.\SQLEXPRESS; Database=AspNetShopDb; Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = "7B0F0974-3D3F-46A5-9746-BDB67BC1A02C",
                Name = "admin",
                NormalizedName = "ADMIN"
            });

            builder.Entity<IdentityUser>().HasData(new IdentityUser
            {
                Id = "ECA95B36-8412-4966-83B4-54BACEB31A35",
                UserName = "admin",
                NormalizedUserName = "ADMIN",
                Email = "admin@gmail.com",
                NormalizedEmail = "ADMIN@GMAIL.COM",
                EmailConfirmed = true,
                PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, "password")
            });

            builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = "7B0F0974-3D3F-46A5-9746-BDB67BC1A02C",
                UserId = "ECA95B36-8412-4966-83B4-54BACEB31A35"
            });

            builder.Entity<OrderProductEntity>()
                .HasKey(t => new { t.OrderId, t.ProductId });

            builder.Entity<OrderProductEntity>()
                .HasOne(op => op.Order)
                .WithMany(o => o.OrderProduct)
                .HasForeignKey(op => op.OrderId);

            builder.Entity<OrderProductEntity>()
                .HasOne(op => op.Product)
                .WithMany(p => p.OrderProduct)
                .HasForeignKey(op => op.ProductId);

            builder.Entity<OrderEntity>()
                .Property(p => p.Id)
                .ValueGeneratedOnAdd();
        }
    }
}
