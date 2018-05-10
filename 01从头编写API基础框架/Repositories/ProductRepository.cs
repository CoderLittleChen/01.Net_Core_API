using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Net_Core_API.Entities;

namespace Net_Core_API.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly MyContext _myContext;

        public ProductRepository(MyContext myContext)
        {
            _myContext = myContext;
        }

        public IEnumerable<Product> GetProducts()
        {
            return _myContext.Products.OrderBy(x => x.Name).ToList();
        }

        public Product GetProduct(int ProductId, bool includeMaterials)
        {
            if (includeMaterials)
            {
                //这里的  主要问题是  查询出来的Product 对象 其中的Materials属性 是否为Null，这个怎么判断？
                //这样写  为什么Materials 是有值的
                //List<Material> materials = _myContext.Materials.Where(x => x.ProductId == ProductId).ToList();
                //if (materials!=null)
                //{
                //    return _myContext.Products.ToList().Find(x => x.Id == ProductId);
                //}
                return _myContext.Products.ToList().Find(x => x.Id == ProductId);
            }
            return _myContext.Products.Find(ProductId);
        }

        public IEnumerable<Material> GetMaterialsForProduct(int productId)
        {
            //return _myContext.Products.Find(productId).Materials;
            return _myContext.Materials.Where(x => x.ProductId == productId).ToList();
        }

        public Material GetMaterialForProduct(int productId, int materialId)
        {
            return _myContext.Materials.FirstOrDefault(x => x.ProductId == productId && x.Id == materialId);
        }

        //判断Product是否存在
        public bool ProductExist(int productId)
        {
            return _myContext.Products.Any(x => x.Id == productId);
        }

    }
}
