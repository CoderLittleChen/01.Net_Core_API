using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Net_Core_API.Dto;
using Net_Core_API.Repositories;
using Net_Core_API.Services;

namespace Net_Core_API.Controllers
{
    [Route("api/product")]
    public class MaterialController : Controller
    {
        private readonly IProductRepository _productRepository;
        public MaterialController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("{productId}/materials")]
        public IActionResult GetMaterials(int productId)
        {
            var exist = _productRepository.ProductExist(productId);
            if (!exist)
            {
                return NotFound();
            }

            var materials = _productRepository.GetMaterialsForProduct(productId);
            //执行映射操作  注意这里是集合映射，下面是单个对象 映射
            var result = Mapper.Map<IEnumerable<MaterialDto>>(materials);
            //var result = materials.Select(a => new MaterialDto
            //{
            //    Id = a.Id,
            //    Name = a.Name
            //}).ToList();
            return Ok(result);
        }


        [HttpGet("{productId}/materials/{id}")]
        public IActionResult GetMaerial(int productId, int id)
        {
            var product = _productRepository.ProductExist(productId);
            if (!product)
            {
                return NotFound();
            }
            var material = _productRepository.GetMaterialForProduct(productId, id);
            if (material == null)
            {
                return NotFound();
            }

            var result = Mapper.Map<MaterialDto>(material);
            //var result = new MaterialDto
            //{
            //    Id = material.Id,
            //    Name = material.Name
            //};
            return Ok(result);
        }




        //这样定义   两种路径 都可以请求
        //[Route("m")]
        //[HttpGet("{productId}/materials")]
        //public IActionResult GetMaterials(int productId)
        //{
        //    var product = ProductService.Current.Products.First(x => x.Id == productId);
        //    if (product == null)
        //    {
        //        return NotFound();
        //    }
        //    return Ok(product.Materials);
        //}

    }
}