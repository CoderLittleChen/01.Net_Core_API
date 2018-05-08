using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Net_Core_API.Services;

namespace Net_Core_API.Controllers
{
    [Route("api/product")]
    public class MaterialController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        //这样定义   两种路径 都可以请求
        [Route("m")]
        [HttpGet("{productId}/materials")]
        public IActionResult GetMaterials(int productId)
        {
            var product = ProductService.Current.Products.First(x => x.Id == productId);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product.Materials);
        }

    }
}