using Homework6._7_3.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Homework6._7_3.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DanDealController : ControllerBase
    {
        [HttpGet]
        [Route("getitems")]
        public List<DanDealItem> GetItems()
        {
            return DanDealScraper.Scrape();
        }
    }
}
