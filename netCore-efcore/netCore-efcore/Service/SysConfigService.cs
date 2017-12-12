using netCore_efcore.Models;
using netCore_efcore.Repository.Interfaces;
using netCore_efcore.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace netCore_efcore.Service
{
    public class SysConfigService: ISysConfigService
    {

        private ISysConfigRepository _sysconfig;

        public SysConfigService(ISysConfigRepository sysconfig)
        {
            _sysconfig = sysconfig;
        }

        public IEnumerable<SysConfig> GetSysConfigList()
        {
            return _sysconfig.List();
        }

        public SysConfig GetSysConfig(string id)
        {
            return _sysconfig.GetById(id);
        }
    }
}
