using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace FlowersMallApi.Models
{
    public partial class Flower_ShopContext : DbContext
    {
        public Flower_ShopContext()
        {
        }

        public Flower_ShopContext(DbContextOptions<Flower_ShopContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AddressTable> AddressTable { get; set; }
        public virtual DbSet<AdminTable> AdminTable { get; set; }
        public virtual DbSet<CommodityTable> CommodityTable { get; set; }
        public virtual DbSet<LoginUserTable> LoginUserTable { get; set; }
        public virtual DbSet<LvmessageTable> LvmessageTable { get; set; }
        public virtual DbSet<OrderTable> OrderTable { get; set; }
        public virtual DbSet<RecommendTable> RecommendTable { get; set; }
        public virtual DbSet<ShippingTable> ShippingTable { get; set; }
        public virtual DbSet<UserTable> UserTable { get; set; }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
//                optionsBuilder.UseSqlServer("server=47.112.230.140,1433;database=Flower_Shop;uid=sa;pwd=123456yu.;");
//            }
//        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AddressTable>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Address_Table");

                entity.Property(e => e.AAddress)
                    .IsRequired()
                    .HasColumnName("a_address")
                    .HasMaxLength(50);

                entity.Property(e => e.AId).HasColumnName("a_id");

                entity.Property(e => e.AIphone)
                    .IsRequired()
                    .HasColumnName("a_iphone")
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.AName)
                    .IsRequired()
                    .HasColumnName("a_name")
                    .HasMaxLength(10);

                entity.Property(e => e.APostcode)
                    .IsRequired()
                    .HasColumnName("a_postcode")
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<AdminTable>(entity =>
            {
                entity.HasKey(e => e.AId)
                    .HasName("PK__Admin_Ta__71AD61D9498C76F5");

                entity.ToTable("Admin_Table");

                entity.Property(e => e.AId)
                    .HasColumnName("A_id")
                    .HasMaxLength(16);

                entity.Property(e => e.APassword)
                    .IsRequired()
                    .HasColumnName("A_password")
                    .HasMaxLength(16);
            });

            modelBuilder.Entity<CommodityTable>(entity =>
            {
                entity.HasKey(e => e.CId)
                    .HasName("PK__Commodit__213EE774387537FD");

                entity.ToTable("Commodity_Table");

                entity.Property(e => e.CId).HasColumnName("c_id");

                entity.Property(e => e.CDetailedPic)
                    .HasColumnName("c_detailed_pic")
                    .HasMaxLength(50);

                entity.Property(e => e.CFlowerLanguage)
                    .IsRequired()
                    .HasColumnName("c_flower_language")
                    .HasMaxLength(100);

                entity.Property(e => e.CFlowerMaterial)
                    .IsRequired()
                    .HasColumnName("c_flower_material")
                    .HasMaxLength(100);

                entity.Property(e => e.CIntroduce)
                    .IsRequired()
                    .HasColumnName("c_introduce")
                    .HasMaxLength(200);

                entity.Property(e => e.CKind)
                    .IsRequired()
                    .HasColumnName("c_kind")
                    .HasMaxLength(10);

                entity.Property(e => e.CName)
                    .IsRequired()
                    .HasColumnName("c_name")
                    .HasMaxLength(50);

                entity.Property(e => e.CPacking)
                    .IsRequired()
                    .HasColumnName("c_packing")
                    .HasMaxLength(50);

                entity.Property(e => e.CPic)
                    .IsRequired()
                    .HasColumnName("c_pic")
                    .HasMaxLength(50);

                entity.Property(e => e.CPrice)
                    .HasColumnName("c_price")
                    .HasColumnType("money");

                entity.Property(e => e.CSale).HasColumnName("c_sale");

                entity.Property(e => e.CSeries)
                    .HasColumnName("c_series")
                    .HasMaxLength(10);

                entity.Property(e => e.CStock).HasColumnName("c_stock");
            });

            modelBuilder.Entity<LoginUserTable>(entity =>
            {
                entity.HasKey(e => new { e.UId, e.URank });

                entity.ToTable("LoginUser_Table");

                entity.Property(e => e.UId).HasColumnName("U_id");

                entity.Property(e => e.URank).HasColumnName("U_rank");

                entity.Property(e => e.UToken)
                    .IsRequired()
                    .HasColumnName("U_token")
                    .HasMaxLength(225);
            });

            modelBuilder.Entity<LvmessageTable>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("lvmessage_Table");

                entity.Property(e => e.UInformation)
                    .IsRequired()
                    .HasColumnName("u_information")
                    .HasMaxLength(400);

                entity.Property(e => e.UName)
                    .IsRequired()
                    .HasColumnName("u_name")
                    .HasMaxLength(10);

                entity.Property(e => e.USuler)
                    .HasColumnName("u_suler")
                    .HasMaxLength(100);

                entity.Property(e => e.UTime)
                    .HasColumnName("u_time")
                    .HasColumnType("date");
            });

            modelBuilder.Entity<OrderTable>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Order_Table");

                entity.Property(e => e.OAAddress)
                    .HasColumnName("o_a_address")
                    .HasMaxLength(50);

                entity.Property(e => e.OAIphone)
                    .IsRequired()
                    .HasColumnName("o_a_iphone")
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.OAName)
                    .IsRequired()
                    .HasColumnName("o_a_name")
                    .HasMaxLength(10);

                entity.Property(e => e.OAPostcode)
                    .IsRequired()
                    .HasColumnName("o_a_postcode")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.OCId).HasColumnName("o_c_id");

                entity.Property(e => e.ODate)
                    .HasColumnName("o_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.ODelivery)
                    .HasColumnName("o_delivery")
                    .HasMaxLength(10);

                entity.Property(e => e.OFlag).HasColumnName("o_flag");

                entity.Property(e => e.OId)
                    .IsRequired()
                    .HasColumnName("o_id")
                    .HasMaxLength(20);

                entity.Property(e => e.OMessage)
                    .IsRequired()
                    .HasColumnName("o_message")
                    .HasMaxLength(200);

                entity.Property(e => e.OSNum).HasColumnName("o_s_num");

                entity.Property(e => e.OUId).HasColumnName("o_u_id");
            });

            modelBuilder.Entity<RecommendTable>(entity =>
            {
                entity.HasKey(e => e.CId)
                    .HasName("PK_Recommend_Table1");

                entity.ToTable("Recommend_Table");

                entity.Property(e => e.CId)
                    .HasColumnName("c_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.CName)
                    .IsRequired()
                    .HasColumnName("c_name")
                    .HasMaxLength(50);

                entity.Property(e => e.CPic)
                    .IsRequired()
                    .HasColumnName("c_pic")
                    .HasMaxLength(50);

                entity.Property(e => e.CPrice)
                    .HasColumnName("c_price")
                    .HasColumnType("money");

                entity.Property(e => e.CPriceAlt)
                    .HasColumnName("c_price_alt")
                    .HasColumnType("money");
            });

            modelBuilder.Entity<ShippingTable>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Shipping_Table");

                entity.Property(e => e.SBuy).HasColumnName("s_buy");

                entity.Property(e => e.SCId).HasColumnName("s_c_id");

                entity.Property(e => e.SCName)
                    .IsRequired()
                    .HasColumnName("s_c_name")
                    .HasMaxLength(50);

                entity.Property(e => e.SNum).HasColumnName("s_num");

                entity.Property(e => e.SPic)
                    .IsRequired()
                    .HasColumnName("s_pic")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SPrice)
                    .HasColumnName("s_price")
                    .HasColumnType("money");

                entity.Property(e => e.SUId).HasColumnName("s_u_id");
            });

            modelBuilder.Entity<UserTable>(entity =>
            {
                entity.HasKey(e => e.UId)
                    .HasName("PK__User_Tab__B51D3DEAFEFEC08F");

                entity.ToTable("User_Table");

                entity.Property(e => e.UId).HasColumnName("U_id");

                entity.Property(e => e.UCard)
                    .HasColumnName("U_card")
                    .HasMaxLength(20);

                entity.Property(e => e.UIphone)
                    .HasColumnName("U_iphone")
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.UMail)
                    .HasColumnName("U_mail")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UName)
                    .IsRequired()
                    .HasColumnName("U_name")
                    .HasMaxLength(10);

                entity.Property(e => e.UPassword)
                    .IsRequired()
                    .HasColumnName("U_password")
                    .HasMaxLength(16);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
