using DLL.Configurations;
using DLL.Entity;
using DLL.Extention;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Security.Claims;
using DLL.LogEntity;

namespace DLL
{
    public class DataContext:DbContext
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public DataContext(DbContextOptions<DataContext> options,IHttpContextAccessor httpContextAccessor) : base(options)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Unit> Units { get; set; }
        public DbSet<Mechandise> Mechandises { get; set; }
        public DbSet<ImportInvoice> ImportInvoices { get; set; }
        public DbSet<ImportInvoiceDetail> ImportInvoiceDetails { get; set; }
        public DbSet<ExportInvoice> ExportInvoices { get; set; }
        public DbSet<ExportInvoiceDetail> ExportInvoiceDetails { get; set; }
        public DbSet<StockDetail> StockDetails { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.AddConfiguration(new StockConfigurations());
            modelBuilder.AddConfiguration(new ExportInvoiceConfigurations());
            modelBuilder.AddConfiguration(new ExportInvoiceDetailConfigurations());
            modelBuilder.AddConfiguration(new ImportInvoiceConfigurations());
            modelBuilder.AddConfiguration(new ImportInvoiceDetailConfigurations());
            modelBuilder.AddConfiguration(new StockDetailConfigurations());
            modelBuilder.AddConfiguration(new UnitConfigurations());
            modelBuilder.AddConfiguration(new UserConfigurations());
            modelBuilder.AddConfiguration(new MechandiseConfigurations());
        }
        public override int SaveChanges()
        {
            UpdateAudiEntity();
            return base.SaveChanges();
        }
        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            UpdateAudiEntity();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }
        public override Task<int> SaveChangesAsync(bool acceptAllChangeOnSuccess, CancellationToken cancellationToken = default)
        {
            UpdateAudiEntity();
            return base.SaveChangesAsync(acceptAllChangeOnSuccess, cancellationToken);
        }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            UpdateAudiEntity();
            return base.SaveChangesAsync(cancellationToken);
        }
        private void UpdateAudiEntity()
        {
            IEnumerable<EntityEntry> entities = ChangeTracker.Entries().Where(x => x.State == EntityState.Added ||
                                                                                    x.State == EntityState.Modified);
            string nameIdentifier = _httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            string currentId = null;
            if (!string.IsNullOrEmpty(nameIdentifier))
            {
                currentId = nameIdentifier;
            }
            foreach (EntityEntry item in entities)
            {
                IAuditableEntity changeOrAddedItem = item.Entity as IAuditableEntity;
                DateTime now = DateTime.Now;
                if(changeOrAddedItem!= null)
                {
                    if(item.State == EntityState.Added)
                    {
                        if(changeOrAddedItem.CreatedBy == null && currentId != null)
                        {
                            changeOrAddedItem.CreatedBy = currentId;
                        }
                        changeOrAddedItem.CreatedDate = now;
                    }
                    if(changeOrAddedItem.ModifiedBy == null && currentId != null)
                    {
                        changeOrAddedItem.ModifiedBy = currentId;
                    }
                    changeOrAddedItem.ModifiedDate = now;
                }
            }
        }

    }
    
}
