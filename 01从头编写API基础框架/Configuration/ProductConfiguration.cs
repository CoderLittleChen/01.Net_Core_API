using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Net_Core_API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Net_Core_API.Configuration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            //modelBuiler.Emtity<Product>.HasKey(x => x.Id);
            //modelBuilder.Entity<Product>().Property(x => x.Name).IsRequired().HasMaxLength(50);
            //modelBuilder.Entity<Product>().Property(x => x.Price).HasColumnType("decimal(8,2)");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(50);
            //这里的decimal（p,s）  例：123.45  p=5  s=2
            //numeric和decimal数据类型默认最大精度值  是38  即   0<=s<=p<=38
            builder.Property(x => x.Price).HasColumnType("decimal(8,2)");
            builder.Property(x => x.Description).HasMaxLength(200);
        }
    }
}
