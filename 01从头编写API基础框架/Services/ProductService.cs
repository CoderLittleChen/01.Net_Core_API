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
        public List<ProductDto> Products { get; }
        private ProductService()
        {
            Products = new List<ProductDto>()
            {
                new ProductDto()
                {
                    Id=1,
                    Name="张三",
                    Price=new decimal(2.5),
                    Materials = new List<MaterialDto>
                    {
                        new MaterialDto
                        {
                            Id = 1,
                            Name = "水"
                        },
                        new MaterialDto
                        {
                            Id = 2,
                            Name = "奶粉"
                        }
                    }
                },
                new ProductDto()
                {
                    Id=2,
                    Name="李四",
                    Price=new decimal(4.5),
                    Materials = new List<MaterialDto>
                    {
                        new MaterialDto
                        {
                            Id = 1,
                            Name = "火"
                        },
                        new MaterialDto
                        {
                            Id = 2,
                            Name = "水果"
                        }
                    }
                },
                new ProductDto
                {
                    Id = 3,
                    Name = "王五",
                    Price = new decimal(7.5),
                    Materials = new List<MaterialDto>
                    {
                        new MaterialDto
                        {
                            Id = 1,
                            Name = "风"
                        },
                        new MaterialDto
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
