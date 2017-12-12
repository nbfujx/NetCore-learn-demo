using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using netCore_efcore.Models;
using netCore_efcore.Service.Interfaces;

namespace netCore_efcore.Controllers
{
    [Produces("application/json")]
    [Route("api/SysConfig")]
    public class SysConfigController : Controller
    {
        private readonly ISysConfigService _sysconfig;

        public SysConfigController(ISysConfigService sysconfig)
        {
            _sysconfig = sysconfig;
        }

        // GET: api/SysConfig
        [HttpGet]
        public IEnumerable<SysConfig> GetSysConfig()
        {
            return _sysconfig.GetSysConfigList();
        }

        // GET: api/SysConfig/5
        [HttpGet("{id}")]
        public IActionResult GetSysConfig([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var sysConfig = _sysconfig.GetSysConfig(id);

            if (sysConfig == null)
            {
                return NotFound();
            }

            return Ok(sysConfig);
        }

    }
}