using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Net_Core_API.Dto
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }

        public string Description { get; set; }

        //当两个model存在主存关系的时候，会根据主model来查询子model
        public ICollection<MaterialDto> Materials { get; set; }
    }


}
