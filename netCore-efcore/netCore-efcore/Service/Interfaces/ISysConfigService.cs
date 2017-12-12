using netCore_efcore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace netCore_efcore.Service.Interfaces
{
    public interface ISysConfigService
    {
         IEnumerable<SysConfig> GetSysConfigList();
         SysConfig GetSysConfig(string id);
    }
}
