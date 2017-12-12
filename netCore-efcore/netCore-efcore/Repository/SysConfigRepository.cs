using Microsoft.EntityFrameworkCore;
using netCore_efcore.Models;
using netCore_efcore.Repository.Interfaces;
using netCore_efcore.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace netCore_efcore.Repository
{
    public class SysConfigRepository : Repository<SysConfig>, ISysConfigRepository
    {
        private readonly EFCoreContext _dbContext;

        public SysConfigRepository(EFCoreContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
