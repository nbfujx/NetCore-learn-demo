using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;

namespace netCore_redis.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private IDistributedCache _memoryCache;

        public ValuesController(IDistributedCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        // GET api/values
        [HttpGet]
        public string Get()
        {
            string key = System.Guid.NewGuid().ToString("N");
            string value = System.Guid.NewGuid().ToString("N");
            _memoryCache.SetString(key, value);
            return key;
        }

        // GET api/values/5
        [HttpGet("{key}")]
        public string Get(string key)
        {
            return _memoryCache.GetString(key);
        }

    }
}
