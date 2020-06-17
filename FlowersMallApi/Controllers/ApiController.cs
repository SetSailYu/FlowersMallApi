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

        // GET api/<controller>/Get/5
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
                indexImgList = new string[] { "1.jpg", "2.jpg", "3.jpg", "4.jpg", "5.jpg" },
                xhImgList = new string[] { "14.jpg", "15.jpg", "16.jpg" },
                hcImgList = new string[] { "14.jpg", "15.jpg", "16.jpg" },
                ysImgList = new string[] { "14.jpg", "15.jpg", "16.jpg" },
                lpImgList = new string[] { "17.jpg", "18.jpg"}
            };

            return Json(person);
        }

        /// <summary>
        /// 推荐接口
        /// </summary>
        /// <returns></returns>
        // GET: api/<controller>/Recommend
        [HttpGet]
        public JsonResult Recommend()
        {
            // 右侧推荐接口
            //"select * from Commodity_Table where c_id=196 or c_id=195 or c_id=27"
            var rightrecommend = _context.CommodityTable.Where(u => u.CId == 27 || u.CId == 195 || u.CId == 196);
            // 限时推荐接口
            //string sql = "SELECT DISTINCT TOP 3 * FROM Recommend_Table ";
            var limitrecommend = _context.RecommendTable.Distinct().Take(3);
            var recommend = new
            {
                rightrecommend,
                limitrecommend
            };
            return Json(recommend);
        }

        /// <summary>
        /// 专区接口
        /// </summary>
        /// <returns></returns>
        // GET: api/<controller>/Recommend
        [HttpGet]
        public JsonResult Division()
        {
            // 爱情专区
            //string sql = "SELECT DISTINCT TOP 8 * FROM [Commodity_Table] WHERE c_kind="鲜花" and c_series="爱情系列" ORDER BY [c_id]";
            var lvoe = _context.CommodityTable.Where(u => u.CKind == "鲜花" && u.CSeries == "爱情系列").OrderBy(a => a.CId)
                .Distinct().Take(8);
            // 送长辈专区
            //string sql = "SELECT DISTINCT TOP 8 * FROM [Commodity_Table] WHERE c_kind="鲜花" and c_series="其它系列" ORDER BY [c_id] DESC";
            var elder = _context.CommodityTable.Where(u => u.CKind == "鲜花" && u.CSeries == "其它系列").OrderByDescending(a => a.CId)
                .Distinct().Take(8);
            // 永生花专区    
            //string sql = "SELECT DISTINCT TOP 8 * FROM [Commodity_Table] WHERE c_kind="永生花"  ORDER BY [c_id]";
            var immortal = _context.CommodityTable.Where(u => u.CKind == "永生花").OrderBy(a => a.CId)
                .Distinct().Take(8);
            // 礼品专区    
            //string sql = "SELECT DISTINCT TOP 8 * FROM [Commodity_Table] WHERE c_kind="礼品"  ORDER BY [c_id]";
            var gift = _context.CommodityTable.Where(u => u.CKind == "礼品").OrderBy(a => a.CId)
                .Distinct().Take(8);

            var division = new object[]
            {
                new {
                    hd = new {
                        more = "更多爱情鲜花 >>",
                        h3 = new
                        {
                            a = "爱情鲜花",
                            span = "送·让你怦然心动的人"
                        }
                    },
                    bd = new {
                        img = "http://47.112.230.140:56000/images/6.jpg",
                        a = "爱情鲜花专区 >>"
                    },
                    kind = "xh",
                    series = 1,
                    name = "爱情 · ",
                    con = lvoe
                },
                new {
                    hd = new
                    {
                        more = "更多送长辈鲜花 >>",
                        h3 = new
                        {
                            a = "送长辈鲜花",
                            span = "赠·父母/恩师/长辈"
                        }
                    },
                    bd = new
                    {
                        img = "http://47.112.230.140:56000/images/7.jpg",
                        a = "送长辈鲜花专区 >>"
                    },
                    kind = "xh",
                    series = 7,
                    name = "送长辈 · ",
                    con = elder
                },
                new {
                    hd = new
                    {
                        more = "更多永生花 >>",
                        h3 = new
                        {
                            a = "永生花",
                            span = "许·她一生承诺"
                        }
                    },
                    bd = new
                    {
                        img = "http://47.112.230.140:56000/images/8.jpg",
                        a = "永生花专区 >>"
                    },
                    kind = "ys",
                    series = 0,
                    name = "永生花 · ",
                    con = immortal
                },
                new {
                    hd = new
                    {
                        more = "更多礼品 >>",
                        h3 = new
                        {
                            a = "礼品",
                            span = "给她·最美好的礼物"
                        }
                    },
                    bd = new
                    {
                        img = "http://47.112.230.140:56000/images/9.jpg",
                        a = "礼品专区 >>"
                    },
                    kind = "lp",
                    series = 0,
                    name = "礼品 · ",
                    con = gift
                }
            };
            return Json(division);
        }


        /// <summary>
        /// 商品详情接口
        /// </summary>
        /// <returns></returns>
        // GET: api/<controller>/Details/5
        [HttpGet("{id}")]
        public JsonResult Details(int id)
        {
            // 右侧推荐接口
            //"select * from Commodity_Table where c_id=196 or c_id=195 or c_id=27"
            var details = _context.CommodityTable.Where(u => u.CId == id);

            var person = new
            {
                details
            };
            return Json(person);
        }

        /// <summary>
        /// 获取分类商品接口
        /// </summary>
        /// <returns></returns>
        // GET: api/<controller>/GetCommodity?kind=xh&series=0
        [HttpGet]
        public JsonResult GetCommodity([FromQuery]string kind, [FromQuery]int series)
        {
            string[] xh = new string[] { "全部", "爱情系列", "生日系列", "婚庆系列", "生活系列", "商务系列", "殡仪系列", "其它系列" };
            string[] hc = new string[] { "全部", "玫瑰", "康乃馨", "百合", "向日葵", "扶郎", "郁金香", "马蹄莲" };
            string[] ys = new string[] { "全部", "经典花盒", "巨型玫瑰", "薰衣草", "永生瓶花", "特色永生花" };
            string[] lp = new string[] { "全部", "音乐盒", "金箔花", "3D水晶内雕", "首饰/美妆", "巧克力", "公仔/睡枕", "摆件/其他" };
            switch (kind)
            {
                case "xh":  // 鲜花
                    if (series == 0)
                    {
                        return Json( QueryCommodity("鲜花") );
                    }
                    else if (0 < series && series < 8)
                    {
                        return Json( QueryCommodity("鲜花",xh[series]) );
                    }
                    break;
                case "hc":  // 花材
                    if (series == 0)
                    {
                        return Json( QueryCommodity("花材") );
                    }
                    else if (0 < series && series < 8)
                    {
                        return Json( QueryCommodity("花材", hc[series]));
                    }
                    break;
                case "ys":  // 永生
                    if (series == 0)
                    {
                        return Json( QueryCommodity("永生花") );
                    }
                    else if (0 < series && series < 6)
                    {
                        return Json( QueryCommodity("永生花", ys[series]) );
                    }
                    break;
                case "lp":  // 礼品
                    if (series == 0)
                    {
                        return Json( QueryCommodity("礼品") );
                    }
                    else if (0 < series && series < 8 )
                    {
                        return Json( QueryCommodity("礼品", lp[series]) );
                    }
                    break;
            }
            return Json(new { err = "错误" });
        }
        private IEnumerable<CommodityTable> QueryCommodity(string kind)
        {
            //string sql = "SELECT DISTINCT  * FROM [Commodity_Table] WHERE c_kind='鲜花' order by c_flower_language asc";
            return _context.CommodityTable.Where(u => u.CKind == kind).OrderBy(a => a.CFlowerLanguage).Distinct();
        }
        private IEnumerable<CommodityTable> QueryCommodity(string kind, string series)
        {
            return _context.CommodityTable.Where(u => u.CKind == kind && u.CSeries == series).OrderBy(a => a.CFlowerLanguage).Distinct();
        }


    }
}
