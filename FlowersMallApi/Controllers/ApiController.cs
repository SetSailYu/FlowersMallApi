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


        // GET: api/<controller>/Index
        [HttpGet]
        public JsonResult Index()
        {
            var person = new
            {
                classify = new {
                    flower = new object[]{
                        new{
                            name = "鲜花系列",
                            id = "xh",
                            list = new string[]{ "爱情系列", "生日系列", "婚庆系列", "生活系列", "商务系列", "殡仪系列", "其它系列" }
                        },
                        new{
                            name = "鲜花花材",
                            id = "hc",
                            list = new string[] { "玫瑰", "康乃馨", "百合", "向日葵", "扶郎", "郁金香", "马蹄莲" }
                        }
                    },
                    immortal = new object[]{
                        new{
                            name = "永生花",
                            id = "ys",
                            cla = new string[] { "stature1", "M-baffle1", "rm1", "height:62px;width:96px;" },
                            list = new object[] {
                                new { name = "经典花盒", url = "//img02.hua.com/pc/pimg/ysh_brand_menu_01.jpg"},
                                new { name = "巨型玫瑰", url = "//img02.hua.com/pc/pimg/ysh_brand_menu_02.jpg"},
                                new { name = "薰衣草", url = "//img02.hua.com/pc/pimg/ysh_brand_menu_03.jpg"},
                                new { name = "永生瓶花", url = "//img02.hua.com/pc/pimg/ysh_brand_menu_04.jpg"},
                                new { name = "特色永生花", url = "//img02.hua.com/pc/pimg/ysh_brand_menu_05.jpg"}
                            }
                        },
                        new{
                            name = "礼品",
                            id = "lp",
                            cla = new string[] { "stature2", "M-baffle2", "rm2", "height:62px;width:58px;" },
                            list = new object[] {
                                new { name = "音乐盒", url = "//img02.hua.com/pc/assets/img/gifts/gifts-musicbox.png"},
                                new { name = "金箔花", url = "//img02.hua.com/pc/assets/img/gifts/gifts-goldenflower.png"},
                                new { name = "3D水晶内雕", url = "//img02.hua.com/pc/assets/img/gifts/gifts-crystallaser.png"},
                                new { name = "首饰/美妆", url = "//img02.hua.com/pc/assets/img/gifts/gifts-shoushi.png"},
                                new { name = "巧克力", url = "//img02.hua.com/pc/assets/img/gifts/gifts-chocolates.pngg"},
                                new { name = "公仔/睡枕", url = "//img02.hua.com/pc/assets/img/gifts/gifts-toys.png"},
                                new { name = "摆件/其他", url = "//img02.hua.com/pc/assets/img/gifts/gifts-dengshi.png"}
                            }
                        }
                    }
                },
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

    }
}
