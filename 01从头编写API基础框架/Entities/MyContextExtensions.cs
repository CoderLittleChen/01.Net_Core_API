using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Net_Core_API.Entities
{
    public static class MyContextExtensions
    {
        //这里是一个Extension  Method    如果数据库没有数据，则就弄点种子数据
        public static void EnsureSeedDataForContext(this MyContext myContext)
        {
            if (myContext.Products.Any())
            {
                return;
            }
            var products = new List<Product>
            {
                new Product
                {
                    Name = "牛奶",
                    Price = 2.5f,
                    Description = "这是牛奶啊"
                },
                new Product
                {
                    Name = "面包",
                    Price = 4.5f,
                    Description = "这是面包啊"
                },
                new Product
                {
                    Name = "啤酒",
                    Price = 7.5f,
                    Description = "这是啤酒啊"
                }
            };
            myContext.Products.AddRange(products);
            myContext.SaveChanges();

        }
    }
}
