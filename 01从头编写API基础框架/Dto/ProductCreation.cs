using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Net_Core_API.Dto
{
    public class ProductCreation
    {
        //这里建议针对 查询 创建  修改 使用单独的model
        //DataAnnotations  用来对model属性做验证

        [Display(Name = "产品名称")]
        [Required(ErrorMessage = "{0}是必填项")]
        [StringLength(10, MinimumLength = 2, ErrorMessage = "{0}的长度应该不小于{2}, 不大于{1}")]
        public string Name { get; set; }

        [Display(Name = "价格")]
        //关于Range中的占位符   {0}  对应的是第一个注解 价格  {1}  对应的是Range第一个参数 表示最小值 111
        [Range(0, double.MaxValue, ErrorMessage = "{0}的值必须大于{1}")]
        public decimal Price { get; set; }

        [Display(Name = "描述")]
        [MaxLength(100, ErrorMessage = "{0}的长度不可以超过{1}")]
        public string Description { get; set; }

    }
}
