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
        IEnumerable<Material> GetMaterials(int productId);
        //查询单个Product下的某个Materials
        Material GetMaterial(int productId, int materialId);
    }
}
