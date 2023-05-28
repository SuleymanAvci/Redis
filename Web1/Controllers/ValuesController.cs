using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace Web1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        readonly IMemoryCache _memoryCache;

        public ValuesController(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        [HttpGet("SetName")]
        public void SetName(string name)
        {
            _memoryCache.Set("name", name);
        }


        [HttpGet("GetName")]
        public string GetName()
        {
            //var name =_memoryCache.Get<string>("name");
            //return name.Substring(3);

            if (_memoryCache.TryGetValue<string>("name", out string name))
            {
                return name.Substring(3,2);
            }
            return "";
        }

        //-----------------------------

        [HttpGet("setDate")]
        public void SetDate()
        {
            _memoryCache.Set<DateTime>("date", DateTime.Now, options: new()
            {
                AbsoluteExpiration=DateTimeOffset.Now.AddSeconds(30),
                SlidingExpiration=TimeSpan.FromSeconds(5)
            });
        }

        [HttpGet("getDate")]
        public DateTime GetDate()
        {
            return _memoryCache.Get<DateTime>("date");
        }
    }
}
