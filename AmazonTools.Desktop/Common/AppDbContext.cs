using System;
using AmazonTools.Model._Admin;
using Microsoft.EntityFrameworkCore;

namespace AmazonTools.Desktop.Common
{
    public class AppDbContext : DbContext
    {
        public DbSet<AmazonUserInfo> AmazonUserInfos { get; set; }
        public DbSet<AmazonSiteInfo> AmazonSiteInfos { get; set; }
        public DbSet<MailManage> MailManages { get; set; }
        public DbSet<CreditCardManage> CreditCardManages { get; set; }
        public DbSet<DicDef> DicDefs { get; set; }
        public DbSet<DicField> DicFields { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // 配置 SQL Server 连接字符串
            optionsBuilder.UseSqlServer("Server=175.178.159.66;Database=AmazonTools_db;User ID=sa;Password=Hezf5201314.;TrustServerCertificate=True;");
            //optionsBuilder.UseSqlServer("Server=192.168.1.213;Database=AmazonTools_db;User ID=sa;Password=Hezf5201314.;TrustServerCertificate=True;");

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AmazonSiteInfo>()
                .Navigation(s => s.AmazonUser)
                .AutoInclude();  // 自动包含AmazonUser
                                 // 配置 AmazonUserInfo 实体的导航属性自动包含
            modelBuilder.Entity<AmazonUserInfo>()
                .Navigation(u => u.BelongingName)   // 第二层导航属性
                .AutoInclude();

            modelBuilder.Entity<AmazonSiteInfo>()
                .Navigation(s => s.SiteName)
                .AutoInclude();  // 自动包含SiteName

            modelBuilder.Entity<AmazonSiteInfo>()
               .Navigation(s => s.AmazonState)
               .AutoInclude();  // 自动包含SiteName

        }

        public AmazonSiteInfo RefreshAmazonSiteInfo(Guid id)
        {
            var entity = AmazonSiteInfos.Find(id);
            if (entity == null)
                return null;

            // 重新加载所有导航属性
            Entry(entity).Reference(x => x.AmazonUser).Load();
            Entry(entity).Reference(x => x.SiteName).Load();
            Entry(entity).Reference(x => x.AmazonState).Load();

            return entity;
        }
    }
}
