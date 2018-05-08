using Net_Core_API.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Net_Core_API.Services
{
    public class ProductService
    {
        public static ProductService Current { get; } = new ProductService();
        public List<Product> Products { get; }
        private ProductService()
        {
            Products = new List<Product>()
            {
                new Product()
                {
                    Id=1,
                    Name="张三",
                    Price=1.1f,
                    Materials = new List<Material>
                    {
                        new Material
                        {
                            Id = 1,
                            Name = "水"
                        },
                        new Material
                        {
                            Id = 2,
                            Name = "奶粉"
                        }
                    }
                },
                new Product()
                {
                    Id=2,
                    Name="李四",
                    Price=2.2f,
                    Materials = new List<Material>
                    {
                        new Material
                        {
                            Id = 1,
                            Name = "火"
                        },
                        new Material
                        {
                            Id = 2,
                            Name = "水果"
                        }
                    }
                },
                new Product
                {
                    Id = 3,
                    Name = "王五",
                    Price = 7.5f,
                    Materials = new List<Material>
                    {
                        new Material
                        {
                            Id = 1,
                            Name = "风"
                        },
                        new Material
                        {
                            Id = 2,
                            Name = "酸奶"
                        }
                    }
                }
            };
        }
    }
}
