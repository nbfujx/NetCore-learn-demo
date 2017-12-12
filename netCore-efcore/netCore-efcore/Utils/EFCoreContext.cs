using Microsoft.EntityFrameworkCore;
using netCore_efcore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace netCore_efcore.Utils
{
    public class EFCoreContext:DbContext
    {

        public EFCoreContext(DbContextOptions<EFCoreContext> options) : base(options){}

        //添加集合
        public DbSet<SysConfig> SysConfig { get; set; }
    }
}
