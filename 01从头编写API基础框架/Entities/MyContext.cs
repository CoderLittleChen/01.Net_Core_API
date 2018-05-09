using Microsoft.EntityFrameworkCore;
using Net_Core_API.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Net_Core_API.Entities
{
    public class MyContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        //这里添加数据库连接字符串 的一种方式就是 重写 OnConfiguring函数 来实现
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Connection String");
        //    base.OnConfiguring(optionsBuilder);
        //}

        public MyContext(DbContextOptions options)
            : base(options)
        {
            //如果数据库存在 则不进行操作  不存在，则创建数据库  

            //这里有个问题是为什么  不生成数据库？
            Database.EnsureCreated();
            //Database.Migrate();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
        }
    }
}
