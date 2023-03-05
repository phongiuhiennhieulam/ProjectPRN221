using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

#nullable disable

namespace ProjectPRN221.Models
{
    public partial class Project_SU23Context : DbContext
    {
        public Project_SU23Context()
        {
        }

        public Project_SU23Context(DbContextOptions<Project_SU23Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<Blog> Blogs { get; set; }
        public virtual DbSet<Cart> Carts { get; set; }
        public virtual DbSet<CartDetail> CartDetails { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Color> Colors { get; set; }
        public virtual DbSet<Conversation> Conversations { get; set; }
        public virtual DbSet<Function> Functions { get; set; }
        public virtual DbSet<Message> Messages { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderDetail> OrderDetails { get; set; }
        public virtual DbSet<OrderStatus> OrderStatuses { get; set; }
        public virtual DbSet<Participate> Participates { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Productsize> Productsizes { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<RoleFunction> RoleFunctions { get; set; }
        public virtual DbSet<Shipping> Shippings { get; set; }
        public virtual DbSet<Size> Sizes { get; set; }
        public virtual DbSet<Slide> Slides { get; set; }
        public virtual DbSet<StatusProduct> StatusProducts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder()
                           .SetBasePath(Directory.GetCurrentDirectory())
                           .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            IConfigurationRoot configuration = builder.Build();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("ShopDB"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Account>(entity =>
            {
                entity.ToTable("Account");

                entity.Property(e => e.AccountId).HasColumnName("account_id");

                entity.Property(e => e.AccountAddress)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("account_address");

                entity.Property(e => e.AccountCreatedate)
                    .HasColumnType("date")
                    .HasColumnName("account_createdate");

                entity.Property(e => e.AccountDob)
                    .HasColumnType("date")
                    .HasColumnName("account_DOB");

                entity.Property(e => e.AccountEmail)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("account_email");

                entity.Property(e => e.AccountGender).HasColumnName("account_gender");

                entity.Property(e => e.AccountImage)
                    .HasMaxLength(200)
                    .HasColumnName("account_image");

                entity.Property(e => e.AccountName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("account_name");

                entity.Property(e => e.AccountPassword)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("account_password");

                entity.Property(e => e.AccountPhone)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("account_phone");

                entity.Property(e => e.AccountRoleId).HasColumnName("account_role_id");

                entity.Property(e => e.AccountStatus).HasColumnName("account_status");

                entity.Property(e => e.AccountUsername)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("account_username");

                entity.HasOne(d => d.AccountRole)
                    .WithMany(p => p.Accounts)
                    .HasForeignKey(d => d.AccountRoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Account__account__5BE2A6F2");
            });

            modelBuilder.Entity<Blog>(entity =>
            {
                entity.ToTable("Blog");

                entity.Property(e => e.BlogId).HasColumnName("blog_id");

                entity.Property(e => e.BlogAuthor)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("blog_author");

                entity.Property(e => e.BlogBackLink)
                    .HasMaxLength(1000)
                    .HasColumnName("blog_back_link");

                entity.Property(e => e.BlogCreateby)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("blog_createby");

                entity.Property(e => e.BlogCreatedate)
                    .HasColumnType("datetime")
                    .HasColumnName("blog_createdate");

                entity.Property(e => e.BlogDescriptions)
                    .HasMaxLength(500)
                    .HasColumnName("blog_descriptions");

                entity.Property(e => e.BlogDetail)
                    .IsRequired()
                    .HasColumnName("blog_detail");

                entity.Property(e => e.BlogImages)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("blog_images");

                entity.Property(e => e.BlogModifyby)
                    .HasMaxLength(100)
                    .HasColumnName("blog_modifyby");

                entity.Property(e => e.BlogModifydate)
                    .HasColumnType("datetime")
                    .HasColumnName("blog_modifydate");

                entity.Property(e => e.BlogTitle)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasColumnName("blog_title");
            });

            modelBuilder.Entity<Cart>(entity =>
            {
                entity.ToTable("Cart");

                entity.Property(e => e.CartId)
                    .ValueGeneratedNever()
                    .HasColumnName("cart_id");

                entity.Property(e => e.AccountId).HasColumnName("account_id");

                entity.Property(e => e.CartTotol)
                    .HasColumnType("money")
                    .HasColumnName("cart_totol");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.Carts)
                    .HasForeignKey(d => d.AccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Cart_Account");
            });

            modelBuilder.Entity<CartDetail>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("CartDetail");

                entity.Property(e => e.CartId).HasColumnName("cart_id");

                entity.Property(e => e.CartdetailId).HasColumnName("cartdetail_id");

                entity.Property(e => e.Price)
                    .HasColumnType("money")
                    .HasColumnName("price");

                entity.Property(e => e.ProductId).HasColumnName("product_id");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.HasOne(d => d.Cart)
                    .WithMany()
                    .HasForeignKey(d => d.CartId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CartDetail_Cart");

                entity.HasOne(d => d.Product)
                    .WithMany()
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CartDetail_product");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("Category");

                entity.Property(e => e.CategoryId).HasColumnName("category_id");

                entity.Property(e => e.CategoryName)
                    .HasMaxLength(30)
                    .HasColumnName("category_name");
            });

            modelBuilder.Entity<Color>(entity =>
            {
                entity.ToTable("Color");

                entity.Property(e => e.ColorId).HasColumnName("color_id");

                entity.Property(e => e.ColorName)
                    .HasMaxLength(30)
                    .HasColumnName("color_name");
            });

            modelBuilder.Entity<Conversation>(entity =>
            {
                entity.HasKey(e => e.CId);

                entity.ToTable("Conversation");

                entity.Property(e => e.CId)
                    .ValueGeneratedNever()
                    .HasColumnName("c_id");

                entity.Property(e => e.AccountId).HasColumnName("account_id");

                entity.Property(e => e.Cname)
                    .IsRequired()
                    .HasMaxLength(250)
                    .HasColumnName("cname");

                entity.Property(e => e.CreateAt)
                    .HasColumnType("datetime")
                    .HasColumnName("create_at");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.Conversations)
                    .HasForeignKey(d => d.AccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Conversation_Account");
            });

            modelBuilder.Entity<Function>(entity =>
            {
                entity.ToTable("Function");

                entity.Property(e => e.FunctionId)
                    .ValueGeneratedNever()
                    .HasColumnName("function_id");

                entity.Property(e => e.FunctionCreateday)
                    .HasColumnType("date")
                    .HasColumnName("function_createday");

                entity.Property(e => e.FunctionDescription)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasColumnName("function_description");

                entity.Property(e => e.FunctionName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("function_name");

                entity.Property(e => e.FunctionOrdernumber).HasColumnName("function_ordernumber");
            });

            modelBuilder.Entity<Message>(entity =>
            {
                entity.HasKey(e => e.MId);

                entity.ToTable("Message");

                entity.Property(e => e.MId)
                    .ValueGeneratedNever()
                    .HasColumnName("m_id");

                entity.Property(e => e.AccountId).HasColumnName("account_id");

                entity.Property(e => e.CId).HasColumnName("c_id");

                entity.Property(e => e.CreateAt)
                    .HasColumnType("datetime")
                    .HasColumnName("create_at");

                entity.Property(e => e.Message1)
                    .IsRequired()
                    .HasMaxLength(1000)
                    .HasColumnName("message");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.Messages)
                    .HasForeignKey(d => d.AccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Message_Account");

                entity.HasOne(d => d.CIdNavigation)
                    .WithMany(p => p.Messages)
                    .HasForeignKey(d => d.CId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Message_Conversation");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("Order");

                entity.Property(e => e.OrderId).HasColumnName("Order_id");

                entity.Property(e => e.AccountId).HasColumnName("account_id");

                entity.Property(e => e.OrderDate)
                    .HasColumnType("date")
                    .HasColumnName("Order_Date");

                entity.Property(e => e.OrderNote)
                    .HasMaxLength(50)
                    .HasColumnName("Order_note");

                entity.Property(e => e.OrderStatusId).HasColumnName("Order_status_id");

                entity.Property(e => e.OrderTotalMoney).HasColumnName("Order_total_money");

                entity.Property(e => e.ShippingId).HasColumnName("shipping_id");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.AccountId)
                    .HasConstraintName("FK__Order__account_i__628FA481");

                entity.HasOne(d => d.OrderStatus)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.OrderStatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Order__Order_sta__6383C8BA");

                entity.HasOne(d => d.Shipping)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.ShippingId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Order__shipping___6477ECF3");
            });

            modelBuilder.Entity<OrderDetail>(entity =>
            {
                entity.HasKey(e => e.OrderDetailsId)
                    .HasName("PK__Order_De__F68B9B8A50993982");

                entity.ToTable("Order_Details");

                entity.Property(e => e.OrderDetailsId).HasColumnName("Order_Details_id");

                entity.Property(e => e.OrderDetailsNum).HasColumnName("Order_Details_num");

                entity.Property(e => e.OrderDetailsPrice)
                    .HasColumnType("money")
                    .HasColumnName("Order_Details_price");

                entity.Property(e => e.OrderDetailsTotalNumber).HasColumnName("Order_Details_total_number");

                entity.Property(e => e.OrderId).HasColumnName("Order_id");

                entity.Property(e => e.ProductId).HasColumnName("product_id");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK__Order_Det__Order__656C112C");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK__Order_Det__produ__59FA5E80");
            });

            modelBuilder.Entity<OrderStatus>(entity =>
            {
                entity.ToTable("Order_status");

                entity.Property(e => e.OrderStatusId).HasColumnName("Order_status_id");

                entity.Property(e => e.OrderStatusStatus)
                    .HasMaxLength(100)
                    .HasColumnName("Order_status_status");
            });

            modelBuilder.Entity<Participate>(entity =>
            {
                entity.HasKey(e => e.PId);

                entity.ToTable("Participate");

                entity.Property(e => e.PId)
                    .ValueGeneratedNever()
                    .HasColumnName("p_id");

                entity.Property(e => e.AccountId).HasColumnName("account_id");

                entity.Property(e => e.CId).HasColumnName("c_id");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.Participates)
                    .HasForeignKey(d => d.AccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Participate_Account");

                entity.HasOne(d => d.CIdNavigation)
                    .WithMany(p => p.Participates)
                    .HasForeignKey(d => d.CId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Participate_Conversation");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("product");

                entity.Property(e => e.ProductId).HasColumnName("product_id");

                entity.Property(e => e.CategoryId).HasColumnName("category_id");

                entity.Property(e => e.ColorId).HasColumnName("color_id");

                entity.Property(e => e.ProductBacklink)
                    .HasMaxLength(1000)
                    .HasColumnName("product_backlink");

                entity.Property(e => e.ProductCode)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("product_code");

                entity.Property(e => e.ProductCreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("product_create_date");

                entity.Property(e => e.ProductDescription)
                    .HasMaxLength(2000)
                    .HasColumnName("product_description");

                entity.Property(e => e.ProductImage)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("product_image");

                entity.Property(e => e.ProductName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("product_name");

                entity.Property(e => e.ProductPrice)
                    .HasColumnType("money")
                    .HasColumnName("product_price");

                entity.Property(e => e.ProductQuantity).HasColumnName("product_quantity");

                entity.Property(e => e.StatusProductId).HasColumnName("status_product_id");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK__product__categor__45F365D3");

                entity.HasOne(d => d.Color)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.ColorId)
                    .HasConstraintName("FK__product__color_i__44FF419A");

                entity.HasOne(d => d.StatusProduct)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.StatusProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__product__status___4D94879B");
            });

            modelBuilder.Entity<Productsize>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("productsize");

                entity.Property(e => e.ProductId).HasColumnName("product_id");

                entity.Property(e => e.ProductQuantity).HasColumnName("product_quantity");

                entity.Property(e => e.SizeId).HasColumnName("size_id");

                entity.HasOne(d => d.Product)
                    .WithMany()
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK__productsi__produ__49C3F6B7");

                entity.HasOne(d => d.Size)
                    .WithMany()
                    .HasForeignKey(d => d.SizeId)
                    .HasConstraintName("FK__productsi__size___6D0D32F4");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("Role");

                entity.Property(e => e.RoleId).HasColumnName("Role_id");

                entity.Property(e => e.RoleName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("Role_name");
            });

            modelBuilder.Entity<RoleFunction>(entity =>
            {
                entity.ToTable("Role_function");

                entity.Property(e => e.RoleFunctionId)
                    .ValueGeneratedNever()
                    .HasColumnName("Role_function_id");

                entity.Property(e => e.FunctionId).HasColumnName("function_id");

                entity.Property(e => e.RoleFunctionDelete).HasColumnName("Role_function_delete");

                entity.Property(e => e.RoleFunctionInsert).HasColumnName("Role_function_insert");

                entity.Property(e => e.RoleFunctionUpdate).HasColumnName("Role_function_update");

                entity.Property(e => e.RoleFunctionView).HasColumnName("Role_function_view");

                entity.Property(e => e.RoleId).HasColumnName("role_id");

                entity.HasOne(d => d.Function)
                    .WithMany(p => p.RoleFunctions)
                    .HasForeignKey(d => d.FunctionId)
                    .HasConstraintName("FK__Role_func__funct__6E01572D");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.RoleFunctions)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK__Role_func__role___6EF57B66");
            });

            modelBuilder.Entity<Shipping>(entity =>
            {
                entity.ToTable("shipping");

                entity.Property(e => e.ShippingId).HasColumnName("shipping_id");

                entity.Property(e => e.ShippingEmail)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("shipping_email");

                entity.Property(e => e.ShippingName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("shipping_name");

                entity.Property(e => e.ShippingPhone)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("shipping_phone");
            });

            modelBuilder.Entity<Size>(entity =>
            {
                entity.ToTable("size");

                entity.Property(e => e.SizeId).HasColumnName("size_id");

                entity.Property(e => e.SizeNames).HasColumnName("size_names");
            });

            modelBuilder.Entity<Slide>(entity =>
            {
                entity.ToTable("Slide");

                entity.Property(e => e.SlideId).HasColumnName("slide_id");

                entity.Property(e => e.SlideCreateby)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("slide_createby");

                entity.Property(e => e.SlideCreatedate)
                    .HasColumnType("date")
                    .HasColumnName("slide_createdate");

                entity.Property(e => e.SlideDescriptions)
                    .HasMaxLength(500)
                    .HasColumnName("slide_descriptions");

                entity.Property(e => e.SlideImageslide)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("slide_imageslide");

                entity.Property(e => e.SlideModifyby)
                    .HasMaxLength(50)
                    .HasColumnName("slide_modifyby");

                entity.Property(e => e.SlideModifydate)
                    .HasColumnType("date")
                    .HasColumnName("slide_modifydate");

                entity.Property(e => e.SlideStatusId).HasColumnName("slide_status_id");

                entity.Property(e => e.SlideTitle)
                    .IsRequired()
                    .HasMaxLength(500)
                    .HasColumnName("slide_title");
            });

            modelBuilder.Entity<StatusProduct>(entity =>
            {
                entity.ToTable("status_product");

                entity.Property(e => e.StatusProductId).HasColumnName("status_product_id");

                entity.Property(e => e.StatusProductStatus)
                    .HasMaxLength(100)
                    .HasColumnName("status_product_status");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
