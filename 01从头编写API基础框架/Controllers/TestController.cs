using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Net_Core_API.Entities;

namespace Net_Core_API.Controllers
{
    [Route("api/[controller]")]
    public class TestController : Controller
    {
        private MyContext _myContext;
        public TestController(MyContext myContext)
        {
            _myContext = myContext;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok();
        }


        public IActionResult Index()
        {
            return View();
        }
    }
}