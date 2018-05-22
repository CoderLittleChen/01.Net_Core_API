using Net_Core_API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Net_Core_API.Repositories
{
    public interface IProductRepository
    {
        //查询Products
        IEnumerable<Product> GetProducts();
        //查询单个Product
        Product GetProduct(int ProductId, bool includeMaterials);
        //查询单个Product下的Materials
        IEnumerable<Material> GetMaterialsForProduct(int productId);
        //查询单个Product下的某个Materials
        Material GetMaterialForProduct(int productId, int materialId);
        bool ProductExist(int productId);

        void AddProduct(Product product);
        bool Save();
    }
}
