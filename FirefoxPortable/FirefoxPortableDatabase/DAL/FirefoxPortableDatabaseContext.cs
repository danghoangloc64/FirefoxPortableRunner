using FirefoxPortableDatabase.Models;
using FirefoxPortableDatabase.Models.Infrastructure;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace FirefoxPortableDatabase.DAL
{
    class FirefoxPortableDatabaseContext : DbContext
    {
        protected override void OnModelCreating(DbModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        public FirefoxPortableDatabaseContext() : base("Server=.;Database=FirefoxPortableDB;User Id=sa;Password=123123;")
        {
        }

        public DbSet<TaiKhoan> TaiKhoan { get; set; }
        public DbSet<LinkDownloadProfile> LinkDownloadProfile { get; set; }

        public override int SaveChanges()
        {
            var entries = ChangeTracker.Entries();
            List<DbEntityEntry> modifiedEntries = new List<DbEntityEntry>();

            //Get entries add or update to database
            foreach (var entry in entries)
            {
                if (entry.Entity is IAuditableEntity && entry.State == EntityState.Added || entry.State == EntityState.Modified)
                {
                    modifiedEntries.Add(entry);
                }
            }

            //Set CreatedBy, CreatedDate, UpdatedBy, UpdatedDate for IAuditableEntity

            foreach (var entry in modifiedEntries)
            {
                IAuditableEntity entity = entry.Entity as IAuditableEntity;
                if (entity != null)
                {
                    DateTime now = DateTime.Now;

                    if (entry.State == EntityState.Added)
                    {
                        entity.CreatedBy = string.Empty;
                        entity.CreatedDate = now;
                    }
                    else
                    {
                        base.Entry(entity).Property(x => x.CreatedBy).IsModified = false;
                        base.Entry(entity).Property(x => x.CreatedDate).IsModified = false;
                    }

                    entity.UpdatedBy = string.Empty;
                    entity.UpdatedDate = now;
                }
            }

            return base.SaveChanges();
        }
    }
}
