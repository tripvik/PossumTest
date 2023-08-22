using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PossumTest.Models
{
    public partial class PossumContext : DbContext
    {
        public PossumContext()
        {
        }

        public PossumContext(DbContextOptions<PossumContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AppConfig> AppConfigs { get; set; } = null!;
        public virtual DbSet<Customer> Customers { get; set; } = null!;
        public virtual DbSet<CustomersPackage> CustomersPackages { get; set; } = null!;
        public virtual DbSet<CustomersPoint> CustomersPoints { get; set; } = null!;
        public virtual DbSet<DinnerTable> DinnerTables { get; set; } = null!;
        public virtual DbSet<Employee> Employees { get; set; } = null!;
        public virtual DbSet<Giftcard> Giftcards { get; set; } = null!;
        public virtual DbSet<Grant> Grants { get; set; } = null!;
        public virtual DbSet<Inventory> Inventories { get; set; } = null!;
        public virtual DbSet<Item> Items { get; set; } = null!;
        public virtual DbSet<ItemKit> ItemKits { get; set; } = null!;
        public virtual DbSet<ItemKitItem> ItemKitItems { get; set; } = null!;
        public virtual DbSet<ItemQuantity> ItemQuantities { get; set; } = null!;
        public virtual DbSet<ItemsTaxis> ItemsTaxes { get; set; } = null!;
        public virtual DbSet<Module> Modules { get; set; } = null!;
        public virtual DbSet<Permission> Permissions { get; set; } = null!;
        public virtual DbSet<Person> People { get; set; } = null!;
        public virtual DbSet<Receiving> Receivings { get; set; } = null!;
        public virtual DbSet<ReceivingsItem> ReceivingsItems { get; set; } = null!;
        public virtual DbSet<Sale> Sales { get; set; } = null!;
        public virtual DbSet<SalesItem> SalesItems { get; set; } = null!;
        public virtual DbSet<SalesItemsTaxis> SalesItemsTaxes { get; set; } = null!;
        public virtual DbSet<SalesPayment> SalesPayments { get; set; } = null!;
        public virtual DbSet<SalesRewardPoint> SalesRewardPoints { get; set; } = null!;
        public virtual DbSet<SalesTaxis> SalesTaxes { get; set; } = null!;
        public virtual DbSet<Session> Sessions { get; set; } = null!;
        public virtual DbSet<StockLocation> StockLocations { get; set; } = null!;
        public virtual DbSet<Supplier> Suppliers { get; set; } = null!;
        public virtual DbSet<TaxCategory> TaxCategories { get; set; } = null!;
        public virtual DbSet<TaxCode> TaxCodes { get; set; } = null!;
        public virtual DbSet<TaxCodeRate> TaxCodeRates { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=Possum;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AppConfig>(entity =>
            {
                entity.HasKey(e => e.Key)
                    .HasName("PK_app_config_key");

                entity.ToTable("app_config");

                entity.Property(e => e.Key)
                    .HasMaxLength(50)
                    .HasColumnName("key");

                entity.Property(e => e.Value)
                    .HasMaxLength(500)
                    .HasColumnName("value");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("customers");

                entity.HasIndex(e => e.AccountNumber, "customers$account_number")
                    .IsUnique();

                entity.Property(e => e.AccountNumber)
                    .HasMaxLength(255)
                    .HasColumnName("account_number");

                entity.Property(e => e.CompanyName)
                    .HasMaxLength(255)
                    .HasColumnName("company_name");

                entity.Property(e => e.Deleted).HasColumnName("deleted");

                entity.Property(e => e.DiscountPercent)
                    .HasColumnType("decimal(15, 2)")
                    .HasColumnName("discount_percent")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.PackageId).HasColumnName("package_id");

                entity.Property(e => e.PersonId).HasColumnName("person_id");

                entity.Property(e => e.Points).HasColumnName("points");

                entity.Property(e => e.SalesTaxCode)
                    .HasMaxLength(32)
                    .HasColumnName("sales_tax_code")
                    .HasDefaultValueSql("(N'1')");

                entity.Property(e => e.Taxable)
                    .HasColumnName("taxable")
                    .HasDefaultValueSql("((1))");

                entity.HasOne(d => d.Package)
                    .WithMany()
                    .HasForeignKey(d => d.PackageId)
                    .HasConstraintName("customers$customers_ibfk_2");

                entity.HasOne(d => d.Person)
                    .WithMany()
                    .HasForeignKey(d => d.PersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("customers$customers_ibfk_1");
            });

            modelBuilder.Entity<CustomersPackage>(entity =>
            {
                entity.HasKey(e => e.PackageId)
                    .HasName("PK_customers_packages_package_id");

                entity.ToTable("customers_packages");

                entity.Property(e => e.PackageId).HasColumnName("package_id");

                entity.Property(e => e.Deleted).HasColumnName("deleted");

                entity.Property(e => e.PackageName)
                    .HasMaxLength(255)
                    .HasColumnName("package_name");

                entity.Property(e => e.PointsPercent).HasColumnName("points_percent");
            });

            modelBuilder.Entity<CustomersPoint>(entity =>
            {
                entity.ToTable("customers_points");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.PackageId).HasColumnName("package_id");

                entity.Property(e => e.PersonId).HasColumnName("person_id");

                entity.Property(e => e.PointsEarned).HasColumnName("points_earned");

                entity.Property(e => e.SaleId).HasColumnName("sale_id");

                entity.HasOne(d => d.Package)
                    .WithMany(p => p.CustomersPoints)
                    .HasForeignKey(d => d.PackageId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("customers_points$customers_points_ibfk_2");

                entity.HasOne(d => d.Sale)
                    .WithMany(p => p.CustomersPoints)
                    .HasForeignKey(d => d.SaleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("customers_points$customers_points_ibfk_3");
            });

            modelBuilder.Entity<DinnerTable>(entity =>
            {
                entity.ToTable("dinner_tables");

                entity.Property(e => e.DinnerTableId).HasColumnName("dinner_table_id");

                entity.Property(e => e.Deleted).HasColumnName("deleted");

                entity.Property(e => e.Name)
                    .HasMaxLength(30)
                    .HasColumnName("name");

                entity.Property(e => e.Status).HasColumnName("status");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("employees");

                entity.HasIndex(e => e.Username, "employees$username")
                    .IsUnique()
                    .IsClustered();

                entity.Property(e => e.Deleted).HasColumnName("deleted");

                entity.Property(e => e.HashVersion)
                    .HasColumnName("hash_version")
                    .HasDefaultValueSql("((2))");

                entity.Property(e => e.Language)
                    .HasMaxLength(48)
                    .HasColumnName("language");

                entity.Property(e => e.LanguageCode)
                    .HasMaxLength(8)
                    .HasColumnName("language_code");

                entity.Property(e => e.Password)
                    .HasMaxLength(255)
                    .HasColumnName("password");

                entity.Property(e => e.PersonId).HasColumnName("person_id");

                entity.Property(e => e.Username)
                    .HasMaxLength(255)
                    .HasColumnName("username");

                entity.HasOne(d => d.Person)
                    .WithMany()
                    .HasForeignKey(d => d.PersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("employees$employees_ibfk_1");
            });

            modelBuilder.Entity<Giftcard>(entity =>
            {
                entity.ToTable("giftcards");

                entity.HasIndex(e => e.GiftcardNumber, "giftcards$giftcard_number")
                    .IsUnique();

                entity.Property(e => e.GiftcardId).HasColumnName("giftcard_id");

                entity.Property(e => e.Deleted).HasColumnName("deleted");

                entity.Property(e => e.GiftcardNumber)
                    .HasMaxLength(255)
                    .HasColumnName("giftcard_number");

                entity.Property(e => e.PersonId).HasColumnName("person_id");

                entity.Property(e => e.RecordTime)
                    .HasColumnType("datetime")
                    .HasColumnName("record_time")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Value)
                    .HasColumnType("decimal(15, 2)")
                    .HasColumnName("value");

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.Giftcards)
                    .HasForeignKey(d => d.PersonId)
                    .HasConstraintName("giftcards$giftcards_ibfk_1");
            });

            modelBuilder.Entity<Grant>(entity =>
            {
                entity.HasKey(e => new { e.PermissionId, e.PersonId })
                    .HasName("PK_grants_permission_id");

                entity.ToTable("grants");

                entity.Property(e => e.PermissionId)
                    .HasMaxLength(255)
                    .HasColumnName("permission_id");

                entity.Property(e => e.PersonId).HasColumnName("person_id");

                entity.Property(e => e.MenuGroup)
                    .HasMaxLength(32)
                    .HasColumnName("menu_group")
                    .HasDefaultValueSql("(N'home')");

                entity.HasOne(d => d.Permission)
                    .WithMany(p => p.Grants)
                    .HasForeignKey(d => d.PermissionId)
                    .HasConstraintName("grants$grants_ibfk_1");
            });

            modelBuilder.Entity<Inventory>(entity =>
            {
                entity.HasKey(e => e.TransId)
                    .HasName("PK_inventory_trans_id");

                entity.ToTable("inventory");

                entity.Property(e => e.TransId).HasColumnName("trans_id");

                entity.Property(e => e.TransComment).HasColumnName("trans_comment");

                entity.Property(e => e.TransDate)
                    .HasColumnType("datetime")
                    .HasColumnName("trans_date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TransInventory)
                    .HasColumnType("decimal(15, 3)")
                    .HasColumnName("trans_inventory")
                    .HasDefaultValueSql("((0.000))");

                entity.Property(e => e.TransItems).HasColumnName("trans_items");

                entity.Property(e => e.TransLocation).HasColumnName("trans_location");

                entity.Property(e => e.TransUser).HasColumnName("trans_user");

                entity.HasOne(d => d.TransItemsNavigation)
                    .WithMany(p => p.Inventories)
                    .HasForeignKey(d => d.TransItems)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("inventory$inventory_ibfk_1");

                entity.HasOne(d => d.TransLocationNavigation)
                    .WithMany(p => p.Inventories)
                    .HasForeignKey(d => d.TransLocation)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("inventory$inventory_ibfk_3");
            });

            modelBuilder.Entity<Item>(entity =>
            {
                entity.ToTable("items");

                entity.Property(e => e.ItemId).HasColumnName("item_id");

                entity.Property(e => e.AllowAltDescription).HasColumnName("allow_alt_description");

                entity.Property(e => e.Category)
                    .HasMaxLength(255)
                    .HasColumnName("category");

                entity.Property(e => e.CostPrice)
                    .HasColumnType("decimal(15, 2)")
                    .HasColumnName("cost_price");

                entity.Property(e => e.Custom1)
                    .HasMaxLength(255)
                    .HasColumnName("custom1");

                entity.Property(e => e.Custom10)
                    .HasMaxLength(255)
                    .HasColumnName("custom10");

                entity.Property(e => e.Custom2)
                    .HasMaxLength(255)
                    .HasColumnName("custom2");

                entity.Property(e => e.Custom3)
                    .HasMaxLength(255)
                    .HasColumnName("custom3");

                entity.Property(e => e.Custom4)
                    .HasMaxLength(255)
                    .HasColumnName("custom4");

                entity.Property(e => e.Custom5)
                    .HasMaxLength(255)
                    .HasColumnName("custom5");

                entity.Property(e => e.Custom6)
                    .HasMaxLength(255)
                    .HasColumnName("custom6");

                entity.Property(e => e.Custom7)
                    .HasMaxLength(255)
                    .HasColumnName("custom7");

                entity.Property(e => e.Custom8)
                    .HasMaxLength(255)
                    .HasColumnName("custom8");

                entity.Property(e => e.Custom9)
                    .HasMaxLength(255)
                    .HasColumnName("custom9");

                entity.Property(e => e.Deleted).HasColumnName("deleted");

                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .HasColumnName("description");

                entity.Property(e => e.IsSerialized).HasColumnName("is_serialized");

                entity.Property(e => e.ItemNumber)
                    .HasMaxLength(255)
                    .HasColumnName("item_number");

                entity.Property(e => e.ItemType).HasColumnName("item_type");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .HasColumnName("name");

                entity.Property(e => e.PicFilename)
                    .HasMaxLength(255)
                    .HasColumnName("pic_filename");

                entity.Property(e => e.ReceivingQuantity)
                    .HasColumnType("decimal(15, 3)")
                    .HasColumnName("receiving_quantity")
                    .HasDefaultValueSql("((1.000))");

                entity.Property(e => e.ReorderLevel)
                    .HasColumnType("decimal(15, 3)")
                    .HasColumnName("reorder_level")
                    .HasDefaultValueSql("((0.000))");

                entity.Property(e => e.StockType).HasColumnName("stock_type");

                entity.Property(e => e.SupplierId).HasColumnName("supplier_id");

                entity.Property(e => e.UnitPrice)
                    .HasColumnType("decimal(15, 2)")
                    .HasColumnName("unit_price");
            });

            modelBuilder.Entity<ItemKit>(entity =>
            {
                entity.ToTable("item_kits");

                entity.Property(e => e.ItemKitId).HasColumnName("item_kit_id");

                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .HasColumnName("description");

                entity.Property(e => e.ItemId).HasColumnName("item_id");

                entity.Property(e => e.KitDiscountPercent)
                    .HasColumnType("decimal(15, 2)")
                    .HasColumnName("kit_discount_percent")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .HasColumnName("name");

                entity.Property(e => e.PriceOption).HasColumnName("price_option");

                entity.Property(e => e.PrintOption).HasColumnName("print_option");
            });

            modelBuilder.Entity<ItemKitItem>(entity =>
            {
                entity.HasKey(e => new { e.ItemKitId, e.ItemId, e.Quantity })
                    .HasName("PK_item_kit_items_item_kit_id");

                entity.ToTable("item_kit_items");

                entity.Property(e => e.ItemKitId).HasColumnName("item_kit_id");

                entity.Property(e => e.ItemId).HasColumnName("item_id");

                entity.Property(e => e.Quantity)
                    .HasColumnType("decimal(15, 3)")
                    .HasColumnName("quantity");

                entity.Property(e => e.KitSequence).HasColumnName("kit_sequence");

                entity.HasOne(d => d.Item)
                    .WithMany(p => p.ItemKitItems)
                    .HasForeignKey(d => d.ItemId)
                    .HasConstraintName("item_kit_items$item_kit_items_ibfk_2");

                entity.HasOne(d => d.ItemKit)
                    .WithMany(p => p.ItemKitItems)
                    .HasForeignKey(d => d.ItemKitId)
                    .HasConstraintName("item_kit_items$item_kit_items_ibfk_1");
            });

            modelBuilder.Entity<ItemQuantity>(entity =>
            {
                entity.HasKey(e => new { e.ItemId, e.LocationId })
                    .HasName("PK_item_quantities_item_id");

                entity.ToTable("item_quantities");

                entity.Property(e => e.ItemId).HasColumnName("item_id");

                entity.Property(e => e.LocationId).HasColumnName("location_id");

                entity.Property(e => e.Quantity)
                    .HasColumnType("decimal(15, 3)")
                    .HasColumnName("quantity")
                    .HasDefaultValueSql("((0.000))");

                entity.HasOne(d => d.Item)
                    .WithMany(p => p.ItemQuantities)
                    .HasForeignKey(d => d.ItemId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("item_quantities$item_quantities_ibfk_1");

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.ItemQuantities)
                    .HasForeignKey(d => d.LocationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("item_quantities$item_quantities_ibfk_2");
            });

            modelBuilder.Entity<ItemsTaxis>(entity =>
            {
                entity.HasKey(e => new { e.ItemId, e.Name, e.Percent })
                    .HasName("PK_items_taxes_item_id");

                entity.ToTable("items_taxes");

                entity.Property(e => e.ItemId).HasColumnName("item_id");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .HasColumnName("name");

                entity.Property(e => e.Percent)
                    .HasColumnType("decimal(15, 3)")
                    .HasColumnName("percent");

                entity.HasOne(d => d.Item)
                    .WithMany(p => p.ItemsTaxes)
                    .HasForeignKey(d => d.ItemId)
                    .HasConstraintName("items_taxes$items_taxes_ibfk_1");
            });

            modelBuilder.Entity<Module>(entity =>
            {
                entity.ToTable("modules");

                entity.HasIndex(e => e.DescLangKey, "modules$desc_lang_key")
                    .IsUnique();

                entity.HasIndex(e => e.NameLangKey, "modules$name_lang_key")
                    .IsUnique();

                entity.Property(e => e.ModuleId)
                    .HasMaxLength(255)
                    .HasColumnName("module_id");

                entity.Property(e => e.DescLangKey)
                    .HasMaxLength(255)
                    .HasColumnName("desc_lang_key");

                entity.Property(e => e.NameLangKey)
                    .HasMaxLength(255)
                    .HasColumnName("name_lang_key");

                entity.Property(e => e.Sort).HasColumnName("sort");
            });

            modelBuilder.Entity<Permission>(entity =>
            {
                entity.ToTable("permissions");

                entity.Property(e => e.PermissionId)
                    .HasMaxLength(255)
                    .HasColumnName("permission_id");

                entity.Property(e => e.LocationId).HasColumnName("location_id");

                entity.Property(e => e.ModuleId)
                    .HasMaxLength(255)
                    .HasColumnName("module_id");

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.Permissions)
                    .HasForeignKey(d => d.LocationId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("permissions$permissions_ibfk_2");

                entity.HasOne(d => d.Module)
                    .WithMany(p => p.Permissions)
                    .HasForeignKey(d => d.ModuleId)
                    .HasConstraintName("permissions$permissions_ibfk_1");
            });

            modelBuilder.Entity<Person>(entity =>
            {
                entity.ToTable("people");

                entity.Property(e => e.PersonId).HasColumnName("person_id");

                entity.Property(e => e.Address1)
                    .HasMaxLength(255)
                    .HasColumnName("address_1");

                entity.Property(e => e.Address2)
                    .HasMaxLength(255)
                    .HasColumnName("address_2");

                entity.Property(e => e.City)
                    .HasMaxLength(255)
                    .HasColumnName("city");

                entity.Property(e => e.Comments).HasColumnName("comments");

                entity.Property(e => e.Country)
                    .HasMaxLength(255)
                    .HasColumnName("country");

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .HasColumnName("email");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(255)
                    .HasColumnName("first_name");

                entity.Property(e => e.Gender).HasColumnName("gender");

                entity.Property(e => e.LastName)
                    .HasMaxLength(255)
                    .HasColumnName("last_name");

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(255)
                    .HasColumnName("phone_number");

                entity.Property(e => e.State)
                    .HasMaxLength(255)
                    .HasColumnName("state");

                entity.Property(e => e.Zip)
                    .HasMaxLength(255)
                    .HasColumnName("zip");
            });

            modelBuilder.Entity<Receiving>(entity =>
            {
                entity.ToTable("receivings");

                entity.Property(e => e.ReceivingId).HasColumnName("receiving_id");

                entity.Property(e => e.Comment).HasColumnName("comment");

                entity.Property(e => e.EmployeeId).HasColumnName("employee_id");

                entity.Property(e => e.PaymentType)
                    .HasMaxLength(20)
                    .HasColumnName("payment_type");

                entity.Property(e => e.ReceivingTime)
                    .HasColumnType("datetime")
                    .HasColumnName("receiving_time")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Reference)
                    .HasMaxLength(32)
                    .HasColumnName("reference");

                entity.Property(e => e.SupplierId).HasColumnName("supplier_id");
            });

            modelBuilder.Entity<ReceivingsItem>(entity =>
            {
                entity.HasKey(e => new { e.ReceivingId, e.ItemId, e.Line })
                    .HasName("PK_receivings_items_receiving_id");

                entity.ToTable("receivings_items");

                entity.Property(e => e.ReceivingId).HasColumnName("receiving_id");

                entity.Property(e => e.ItemId).HasColumnName("item_id");

                entity.Property(e => e.Line).HasColumnName("line");

                entity.Property(e => e.Description)
                    .HasMaxLength(30)
                    .HasColumnName("description");

                entity.Property(e => e.DiscountPercent)
                    .HasColumnType("decimal(15, 2)")
                    .HasColumnName("discount_percent")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.ItemCostPrice)
                    .HasColumnType("decimal(15, 2)")
                    .HasColumnName("item_cost_price");

                entity.Property(e => e.ItemLocation).HasColumnName("item_location");

                entity.Property(e => e.ItemUnitPrice)
                    .HasColumnType("decimal(15, 2)")
                    .HasColumnName("item_unit_price");

                entity.Property(e => e.QuantityPurchased)
                    .HasColumnType("decimal(15, 3)")
                    .HasColumnName("quantity_purchased")
                    .HasDefaultValueSql("((0.000))");

                entity.Property(e => e.ReceivingQuantity)
                    .HasColumnType("decimal(15, 3)")
                    .HasColumnName("receiving_quantity")
                    .HasDefaultValueSql("((1.000))");

                entity.Property(e => e.Serialnumber)
                    .HasMaxLength(30)
                    .HasColumnName("serialnumber");

                entity.HasOne(d => d.Item)
                    .WithMany(p => p.ReceivingsItems)
                    .HasForeignKey(d => d.ItemId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("receivings_items$receivings_items_ibfk_1");

                entity.HasOne(d => d.Receiving)
                    .WithMany(p => p.ReceivingsItems)
                    .HasForeignKey(d => d.ReceivingId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("receivings_items$receivings_items_ibfk_2");
            });

            modelBuilder.Entity<Sale>(entity =>
            {
                entity.ToTable("sales");

                entity.HasIndex(e => e.InvoiceNumber, "sales$invoice_number")
                    .IsUnique();

                entity.Property(e => e.SaleId).HasColumnName("sale_id");

                entity.Property(e => e.Comment).HasColumnName("comment");

                entity.Property(e => e.CustomerId).HasColumnName("customer_id");

                entity.Property(e => e.DinnerTableId).HasColumnName("dinner_table_id");

                entity.Property(e => e.EmployeeId).HasColumnName("employee_id");

                entity.Property(e => e.InvoiceNumber)
                    .HasMaxLength(32)
                    .HasColumnName("invoice_number");

                entity.Property(e => e.QuoteNumber)
                    .HasMaxLength(32)
                    .HasColumnName("quote_number");

                entity.Property(e => e.SaleStatus).HasColumnName("sale_status");

                entity.Property(e => e.SaleTime)
                    .HasColumnType("datetime")
                    .HasColumnName("sale_time")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.SaleType).HasColumnName("sale_type");

                entity.Property(e => e.WorkOrderNumber)
                    .HasMaxLength(32)
                    .HasColumnName("work_order_number");

                entity.HasOne(d => d.DinnerTable)
                    .WithMany(p => p.Sales)
                    .HasForeignKey(d => d.DinnerTableId)
                    .HasConstraintName("sales$sales_ibfk_3");
            });

            modelBuilder.Entity<SalesItem>(entity =>
            {
                entity.HasKey(e => new { e.SaleId, e.ItemId, e.Line })
                    .HasName("PK_sales_items_sale_id");

                entity.ToTable("sales_items");

                entity.Property(e => e.SaleId).HasColumnName("sale_id");

                entity.Property(e => e.ItemId).HasColumnName("item_id");

                entity.Property(e => e.Line).HasColumnName("line");

                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .HasColumnName("description");

                entity.Property(e => e.DiscountPercent)
                    .HasColumnType("decimal(15, 2)")
                    .HasColumnName("discount_percent")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.ItemCostPrice)
                    .HasColumnType("decimal(15, 2)")
                    .HasColumnName("item_cost_price");

                entity.Property(e => e.ItemLocation).HasColumnName("item_location");

                entity.Property(e => e.ItemUnitPrice)
                    .HasColumnType("decimal(15, 2)")
                    .HasColumnName("item_unit_price");

                entity.Property(e => e.PrintOption).HasColumnName("print_option");

                entity.Property(e => e.QuantityPurchased)
                    .HasColumnType("decimal(15, 3)")
                    .HasColumnName("quantity_purchased")
                    .HasDefaultValueSql("((0.000))");

                entity.Property(e => e.Serialnumber)
                    .HasMaxLength(30)
                    .HasColumnName("serialnumber");

                entity.HasOne(d => d.Item)
                    .WithMany(p => p.SalesItems)
                    .HasForeignKey(d => d.ItemId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("sales_items$sales_items_ibfk_1");

                entity.HasOne(d => d.ItemLocationNavigation)
                    .WithMany(p => p.SalesItems)
                    .HasForeignKey(d => d.ItemLocation)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("sales_items$sales_items_ibfk_3");

                entity.HasOne(d => d.Sale)
                    .WithMany(p => p.SalesItems)
                    .HasForeignKey(d => d.SaleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("sales_items$sales_items_ibfk_2");
            });

            modelBuilder.Entity<SalesItemsTaxis>(entity =>
            {
                entity.HasKey(e => new { e.SaleId, e.ItemId, e.Line, e.Name, e.Percent })
                    .HasName("PK_sales_items_taxes_sale_id");

                entity.ToTable("sales_items_taxes");

                entity.Property(e => e.SaleId).HasColumnName("sale_id");

                entity.Property(e => e.ItemId).HasColumnName("item_id");

                entity.Property(e => e.Line).HasColumnName("line");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .HasColumnName("name");

                entity.Property(e => e.Percent)
                    .HasColumnType("decimal(15, 4)")
                    .HasColumnName("percent")
                    .HasDefaultValueSql("((0.0000))");

                entity.Property(e => e.CascadeSequence).HasColumnName("cascade_sequence");

                entity.Property(e => e.CascadeTax).HasColumnName("cascade_tax");

                entity.Property(e => e.ItemTaxAmount)
                    .HasColumnType("decimal(15, 4)")
                    .HasColumnName("item_tax_amount")
                    .HasDefaultValueSql("((0.0000))");

                entity.Property(e => e.RoundingCode).HasColumnName("rounding_code");

                entity.Property(e => e.TaxType).HasColumnName("tax_type");

                entity.HasOne(d => d.Item)
                    .WithMany(p => p.SalesItemsTaxes)
                    .HasForeignKey(d => d.ItemId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("sales_items_taxes$sales_items_taxes_ibfk_2");
            });

            modelBuilder.Entity<SalesPayment>(entity =>
            {
                entity.HasKey(e => new { e.SaleId, e.PaymentType })
                    .HasName("PK_sales_payments_sale_id");

                entity.ToTable("sales_payments");

                entity.Property(e => e.SaleId).HasColumnName("sale_id");

                entity.Property(e => e.PaymentType)
                    .HasMaxLength(40)
                    .HasColumnName("payment_type");

                entity.Property(e => e.PaymentAmount)
                    .HasColumnType("decimal(15, 2)")
                    .HasColumnName("payment_amount");

                entity.HasOne(d => d.Sale)
                    .WithMany(p => p.SalesPayments)
                    .HasForeignKey(d => d.SaleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("sales_payments$sales_payments_ibfk_1");
            });

            modelBuilder.Entity<SalesRewardPoint>(entity =>
            {
                entity.ToTable("sales_reward_points");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Earned).HasColumnName("earned");

                entity.Property(e => e.SaleId).HasColumnName("sale_id");

                entity.Property(e => e.Used).HasColumnName("used");

                entity.HasOne(d => d.Sale)
                    .WithMany(p => p.SalesRewardPoints)
                    .HasForeignKey(d => d.SaleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("sales_reward_points$sales_reward_points_ibfk_1");
            });

            modelBuilder.Entity<SalesTaxis>(entity =>
            {
                entity.HasKey(e => new { e.SaleId, e.TaxType, e.TaxGroup })
                    .HasName("PK_sales_taxes_sale_id");

                entity.ToTable("sales_taxes");

                entity.Property(e => e.SaleId).HasColumnName("sale_id");

                entity.Property(e => e.TaxType).HasColumnName("tax_type");

                entity.Property(e => e.TaxGroup)
                    .HasMaxLength(32)
                    .HasColumnName("tax_group");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .HasColumnName("name");

                entity.Property(e => e.PrintSequence).HasColumnName("print_sequence");

                entity.Property(e => e.RoundingCode).HasColumnName("rounding_code");

                entity.Property(e => e.SaleTaxAmount)
                    .HasColumnType("decimal(15, 4)")
                    .HasColumnName("sale_tax_amount");

                entity.Property(e => e.SaleTaxBasis)
                    .HasColumnType("decimal(15, 4)")
                    .HasColumnName("sale_tax_basis");

                entity.Property(e => e.SalesTaxCode)
                    .HasMaxLength(32)
                    .HasColumnName("sales_tax_code")
                    .HasDefaultValueSql("(N'')");

                entity.Property(e => e.TaxRate)
                    .HasColumnType("decimal(15, 4)")
                    .HasColumnName("tax_rate");
            });

            modelBuilder.Entity<Session>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("sessions");

                entity.Property(e => e.Data).HasColumnName("data");

                entity.Property(e => e.Id)
                    .HasMaxLength(40)
                    .HasColumnName("id");

                entity.Property(e => e.IpAddress)
                    .HasMaxLength(45)
                    .HasColumnName("ip_address");

                entity.Property(e => e.Timestamp).HasColumnName("timestamp");
            });

            modelBuilder.Entity<StockLocation>(entity =>
            {
                entity.HasKey(e => e.LocationId)
                    .HasName("PK_stock_locations_location_id");

                entity.ToTable("stock_locations");

                entity.Property(e => e.LocationId).HasColumnName("location_id");

                entity.Property(e => e.Deleted).HasColumnName("deleted");

                entity.Property(e => e.LocationName)
                    .HasMaxLength(255)
                    .HasColumnName("location_name");
            });

            modelBuilder.Entity<Supplier>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("suppliers");

                entity.HasIndex(e => e.AccountNumber, "suppliers$account_number")
                    .IsUnique();

                entity.Property(e => e.AccountNumber)
                    .HasMaxLength(255)
                    .HasColumnName("account_number");

                entity.Property(e => e.AgencyName)
                    .HasMaxLength(255)
                    .HasColumnName("agency_name");

                entity.Property(e => e.CompanyName)
                    .HasMaxLength(255)
                    .HasColumnName("company_name");

                entity.Property(e => e.Deleted).HasColumnName("deleted");

                entity.Property(e => e.PersonId).HasColumnName("person_id");

                entity.HasOne(d => d.Person)
                    .WithMany()
                    .HasForeignKey(d => d.PersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("suppliers$suppliers_ibfk_1");
            });

            modelBuilder.Entity<TaxCategory>(entity =>
            {
                entity.ToTable("tax_categories");

                entity.Property(e => e.TaxCategoryId).HasColumnName("tax_category_id");

                entity.Property(e => e.TaxCategory1)
                    .HasMaxLength(32)
                    .HasColumnName("tax_category");

                entity.Property(e => e.TaxGroupSequence).HasColumnName("tax_group_sequence");
            });

            modelBuilder.Entity<TaxCode>(entity =>
            {
                entity.HasKey(e => e.TaxCode1)
                    .HasName("PK_tax_codes_tax_code");

                entity.ToTable("tax_codes");

                entity.Property(e => e.TaxCode1)
                    .HasMaxLength(32)
                    .HasColumnName("tax_code");

                entity.Property(e => e.City)
                    .HasMaxLength(255)
                    .HasColumnName("city")
                    .HasDefaultValueSql("(N'')");

                entity.Property(e => e.State)
                    .HasMaxLength(255)
                    .HasColumnName("state")
                    .HasDefaultValueSql("(N'')");

                entity.Property(e => e.TaxCodeName)
                    .HasMaxLength(255)
                    .HasColumnName("tax_code_name")
                    .HasDefaultValueSql("(N'')");

                entity.Property(e => e.TaxCodeType).HasColumnName("tax_code_type");
            });

            modelBuilder.Entity<TaxCodeRate>(entity =>
            {
                entity.HasKey(e => new { e.RateTaxCode, e.RateTaxCategoryId })
                    .HasName("PK_tax_code_rates_rate_tax_code");

                entity.ToTable("tax_code_rates");

                entity.Property(e => e.RateTaxCode)
                    .HasMaxLength(32)
                    .HasColumnName("rate_tax_code");

                entity.Property(e => e.RateTaxCategoryId).HasColumnName("rate_tax_category_id");

                entity.Property(e => e.RoundingCode).HasColumnName("rounding_code");

                entity.Property(e => e.TaxRate)
                    .HasColumnType("decimal(15, 4)")
                    .HasColumnName("tax_rate")
                    .HasDefaultValueSql("((0.0000))");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
