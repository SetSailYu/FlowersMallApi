using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using FlowersMallApi.Models;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Nancy.Json;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FlowersMallApi.Controllers
{
    [Route("api/[controller]/[action]")]
    public class ApiController : Controller
    {
        /// <summary>
        ///  Flower_Shop数据库服务接口
        /// </summary>
        private readonly Flower_ShopContext _context;
        /// <summary>
        /// 获取或设置www目录路径
        /// </summary>
        private readonly IWebHostEnvironment webHostEnvironment;

        // 使用构造函数注入的方式注入IUserRepository,   
        // 获取或设置www目录路径 --> using Microsoft.AspNetCore.Hosting;
        //      IHostingEnvironment.WebRootPath (已过时)
        //      IWebHostEnvironment.WebRootPath (Core 3.0 之后推荐)
        public ApiController(Flower_ShopContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            this.webHostEnvironment = webHostEnvironment;
        }

        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/<controller>/GetUsers
        [HttpGet]
        public IEnumerable<UserTable> GetUsers()
        {
            return _context.UserTable.ToList();
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        /// <summary>
        /// 轮播图接口
        /// </summary>
        /// <returns></returns>
        // GET: api/<controller>/ImgList
        [HttpGet]
        public JsonResult ImgList()
        {
            var person = new
            {
                imgList = new string[] {
                    "http://47.112.230.140:56000/images/1.jpg",
                    "http://47.112.230.140:56000/images/2.jpg",
                    "http://47.112.230.140:56000/images/3.jpg",
                    "http://47.112.230.140:56000/images/4.jpg",
                    "http://47.112.230.140:56000/images/5.jpg"
                }
            };

            return Json(person);
        }

        /// <summary>
        /// 右侧推荐接口
        /// </summary>
        /// <returns></returns>
        // GET: api/<controller>/Recommend
        [HttpGet]
        public IEnumerable<CommodityTable> Recommend()
        {
            //"select * from Commodity_Table where c_id=196 or c_id=195 or c_id=27"
            return _context.CommodityTable.Where(u => u.CId == 27 || u.CId == 195 || u.CId == 196);
        }

    }
}
