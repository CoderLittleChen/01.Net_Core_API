using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Net_Core_API.Dto
{
    public class ProductDto
    {
        public ProductDto()
        {
            Materials = new List<MaterialDto>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        public string Description { get; set; }

        //当两个model存在主存关系的时候，会根据主model来查询子model
        public ICollection<MaterialDto> Materials { get; set; }

        //还有这种赋值方式吗？
        public int MaterialCount => Materials.Count;

    }


}
