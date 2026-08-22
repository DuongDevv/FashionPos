using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FashionPos.Api.Data
{
    public enum MembershipTierEnum
    {
        BRONZE,
        SILVER,
        GOLD,
        BLACK
    }

    public enum EmployeeRoleEnum
    {
        SUPER_MANAGER,
        STORE_MANAGER,
        CASHIER,
        WAREHOUSE_STAFF
    }

    public enum EmployeeStatusEnum
    {
        ACTIVE,
        INACTIVE,
        ON_LEAVE
    }

    public enum PaymentMethodEnum
    {
        CASH,
        VNPAY,
        MOMO,
        BANK_TRANSFER,
        CARD
    }

    public enum DiscountTypeEnum
    {
        PERCENT,
        AMOUNT
    }

    public enum OrderStatusEnum
    {
        PENDING,
        COMPLETED,
        CANCELLED
    }

    public class FashionPosDbContext : DbContext
    {
        public FashionPosDbContext(DbContextOptions<FashionPosDbContext> options) : base(options) { }

        public DbSet<SystemSetting> SystemSettings { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<ProductCategory> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductVariant> ProductVariants { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.HasPostgresEnum<MembershipTierEnum>("membership_tier");
            modelBuilder.HasPostgresEnum<EmployeeRoleEnum>("employee_role");
            modelBuilder.HasPostgresEnum<EmployeeStatusEnum>("employee_status");
            modelBuilder.HasPostgresEnum<PaymentMethodEnum>("payment_method");
            modelBuilder.HasPostgresEnum<DiscountTypeEnum>("discount_type");
            modelBuilder.HasPostgresEnum<OrderStatusEnum>("order_status");

            modelBuilder.Entity<SystemSetting>().ToTable("system_settings");
            modelBuilder.Entity<Employee>().ToTable("employees");
            modelBuilder.Entity<Customer>().ToTable("customers");
            modelBuilder.Entity<ProductCategory>().ToTable("categories");
            modelBuilder.Entity<Product>().ToTable("products");
            modelBuilder.Entity<ProductVariant>().ToTable("product_variants");
            modelBuilder.Entity<Order>().ToTable("orders");
            modelBuilder.Entity<OrderDetail>().ToTable("order_details");
        }
    }

    [Table("system_settings")]
    public class SystemSetting
    {
        [Key]
        [Column("setting_key")]
        public string SettingKey { get; set; } = string.Empty;

        [Column("setting_value")]
        public string? SettingValue { get; set; }

        [Column("description")]
        public string? Description { get; set; }
    }

    [Table("employees")]
    public class Employee
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("full_name")]
        public string FullName { get; set; } = string.Empty;

        [Column("username")]
        public string Username { get; set; } = string.Empty;

        [Column("password_hash")]
        public string PasswordHash { get; set; } = string.Empty;

        [Column("role")]
        public EmployeeRoleEnum Role { get; set; } = EmployeeRoleEnum.CASHIER;

        [Column("status")]
        public EmployeeStatusEnum Status { get; set; } = EmployeeStatusEnum.ACTIVE;
    }

    [Table("customers")]
    public class Customer
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("full_name")]
        public string FullName { get; set; } = string.Empty;

        [Column("phone_number")]
        public string? PhoneNumber { get; set; }

        [Column("total_spent")]
        public decimal TotalSpent { get; set; }

        [Column("loyalty_points")]
        public int LoyaltyPoints { get; set; }

        [Column("membership_tier")]
        public MembershipTierEnum MembershipTier { get; set; } = MembershipTierEnum.BRONZE;
    }

    [Table("categories")]
    public class ProductCategory
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("name")]
        public string Name { get; set; } = string.Empty;

        [Column("slug")]
        public string Slug { get; set; } = string.Empty;
    }

    [Table("products")]
    public class Product
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("category_id")]
        public int CategoryId { get; set; }

        [Column("name")]
        public string Name { get; set; } = string.Empty;

        [Column("slug")]
        public string Slug { get; set; } = string.Empty;

        [Column("base_price")]
        public decimal BasePrice { get; set; }

        [Column("is_active")]
        public bool IsActive { get; set; } = true;
    }

    [Table("product_variants")]
    public class ProductVariant
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("product_id")]
        public int ProductId { get; set; }

        [Column("sku")]
        public string Sku { get; set; } = string.Empty;

        [Column("size")]
        public string Size { get; set; } = string.Empty;

        [Column("color")]
        public string Color { get; set; } = string.Empty;

        [Column("stock_quantity")]
        public int StockQuantity { get; set; }

        [Column("price")]
        public decimal Price { get; set; }

        [Column("version")]
        public int Version { get; set; }
    }

    [Table("orders")]
    public class Order
    {
        [Key]
        [Column("id")]
        public long Id { get; set; }

        [Column("order_code")]
        public string OrderCode { get; set; } = string.Empty;

        [Column("customer_id")]
        public int? CustomerId { get; set; }

        [Column("employee_id")]
        public int EmployeeId { get; set; }

        [Column("total_items_amount")]
        public decimal TotalItemsAmount { get; set; }

        [Column("discount_type")]
        public DiscountTypeEnum DiscountType { get; set; } = DiscountTypeEnum.PERCENT;

        [Column("discount_value")]
        public decimal DiscountValue { get; set; }

        [Column("final_amount")]
        public decimal FinalAmount { get; set; }

        [Column("paid_amount")]
        public decimal PaidAmount { get; set; }

        [Column("payment_method")]
        public PaymentMethodEnum PaymentMethod { get; set; } = PaymentMethodEnum.CASH;

        [Column("status")]
        public OrderStatusEnum Status { get; set; } = OrderStatusEnum.COMPLETED;

        [Column("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }

    [Table("order_details")]
    public class OrderDetail
    {
        [Key]
        [Column("id")]
        public long Id { get; set; }

        [Column("order_id")]
        public long OrderId { get; set; }

        [Column("variant_id")]
        public int VariantId { get; set; }

        [Column("quantity")]
        public int Quantity { get; set; }

        [Column("unit_price")]
        public decimal UnitPrice { get; set; }
    }
}
