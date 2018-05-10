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
                    Price = new decimal(2.5),
                    Description = "这是牛奶啊",
                    Materials=new List<Material>
                    {
                        new Material
                        {
                            Name="水"
                        },
                        new Material
                        {
                            Name="奶粉"
                        }
                    }
                },
                new Product
                {
                    Name = "面包",
                    Price = new decimal(4.5),
                    Description = "这是面包啊",
                    Materials=new List<Material>
                    {
                        new Material
                        {
                            Name="面粉",
                        },
                        new Material
                        {
                            Name="糖"
                        }
                    }
                },
                new Product
                {
                    Name = "啤酒",
                    Price = new decimal(7.5),
                    Description = "这是啤酒啊",
                    Materials=new List<Material>
                    {
                        new Material
                        {
                            Name="麦芽"
                        },
                        new Material
                        {
                            Name="地下水"
                        }
                    }
                }
            };
            myContext.Products.AddRange(products);
            myContext.SaveChanges();

        }
    }
}
