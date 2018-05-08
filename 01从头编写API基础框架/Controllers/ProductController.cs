using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Net_Core_API.Dto;
using Net_Core_API.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Net_Core_API.Controllers
{
    //本身是没有路由导向的，生成解决方案后，直接在Postman中请求（http://localhost:59850） 会输出Hello World


    //通过Route特性来设置路由  访问路径 localhost:端口/api/product，但是直接访问还是会报错 500（服务器发生错误）
    //必须对其中一个Action进行请求方式限制，否则会找不到对应的action
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        //Routing路由有两种方式：Convention-based（约定） attribute-based（基于路由属性配置的）
        //前者主要用于MVC  （返回View或者Razor Page）   Web Api推荐使用后者

        [Route("GetProducts")]
        [HttpPost]
        public JsonResult GetProducts()
        {
            return new JsonResult(ProductService.Current.Products);
        }

        //[HttpGet]
        //public JsonResult GetProductAndStatus()
        //{
        //    var temp = new JsonResult(ProductService.Current.Products)
        //    {
        //        StatusCode = 200
        //    };
        //    return temp;
        //}

        //[Route("cm/haha/GetName")]
        //[HttpGet]
        //public string GetName()
        //{
        //    return "cm";
        //}

        //这里注意 Route中   [Route("{id}")]   和[Route("id")]  意思是不一样的
        //前者 是api/controller/id的值  {}代表占位符  里面是需要填的参数   而后者是  api/controller/id 表示请求的路径
        [Route("{id}", Name = "GetProduct")]
        //[Route("id")]
        //[HttpPost]
        public IActionResult GetProduct(int id)
        {
            //查询单条数据
            var product = new JsonResult(ProductService.Current.Products.First(x => x.Id == id));
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }


        //[HttpPost("create")]  这样表示action的路由地址为 api/product/create
        //[Route("test")]
        [HttpPost]
        //FromBody  请求的body里面包含着方法需要的实体数据，方法需要把这个数据 Deserialize 成ProductCreation
        public IActionResult Post([FromBody] ProductCreation product)
        {
            if (product == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                //这里的ModelState 是一个Dictionary
                return BadRequest(ModelState);
            }

            if (product.Name == "产品")
            {
                ModelState.AddModelError("Name", "产品的名称不可以是'产品'二字");
                return BadRequest(ModelState);
            }

            var maxId = ProductService.Current.Products.Max(x => x.Id);
            var newProduct = new Product
            {
                Id = ++maxId,
                Name = product.Name,
                Price = product.Price,
                Description = product.Description
            };
            ProductService.Current.Products.Add(newProduct);
            return CreatedAtRoute("GetProduct", new { id = newProduct.Id }, newProduct);
        }


        //全部更新操作 put  注意这里的put操作是 整体修改 不行修改的属性 也会自动进行重置
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] ProductModification product)
        {
            if (product == null)
            {
                return BadRequest();
            }

            if (product.Name == "产品")
            {
                ModelState.AddModelError("Name", "产品的名称不可以是'产品'二字");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var model = ProductService.Current.Products.First(x => x.Id == id);
            if (model == null)
            {
                return NotFound();
            }
            model.Name = product.Name;
            model.Price = product.Price;
            model.Description = product.Description;

            //这里可以 什么都不返回 ，也可以将修改后的model对象返回
            //return NoContent();
            return Ok(model);
        }

        //部分更新 Patch 
        [HttpPatch("{id}")]
        public IActionResult Patch(int id, [FromBody] JsonPatchDocument<ProductModification> patchDoc)
        {
            if (patchDoc == null)
            {
                return BadRequest();
            }
            var model = ProductService.Current.Products.First(x => x.Id == id);
            if (model == null)
            {
                return NotFound();
            }

            //这里是通过查询出来的model   
            var toPatch = new ProductModification
            {
                Name = model.Name,
                Price = model.Price,
                Description = model.Description
            };
            patchDoc.ApplyTo(toPatch, ModelState);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //该函数对model进行手动验证，结果反映在ModelState
            TryValidateModel(toPatch);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            model.Name = toPatch.Name;
            model.Price = toPatch.Price;
            model.Description = toPatch.Description;

            return NoContent();
        }

        //删除Delete s a a 
        [Route("{id}")]
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            //先通过id查询出来 model对象
            var model = ProductService.Current.Products.First(x => x.Id == id);
            if (model == null)
            {
                return NotFound();
            }
            ProductService.Current.Products.Remove(model);
            return NoContent();
        }

    }
}
