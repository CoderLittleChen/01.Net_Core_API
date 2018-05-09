using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Net_Core_API.Entities
{
    public class Product
    {
        //在这个实体中， Id和productId默认会作为表的主键 如果不想用这两个名字的话，可以用Data Annotation注解和FluentApi
        public int Id { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public string Description { get; set; }
    }
}
