using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace netCore_efcore.Models
{
    [Table("sys_config")]
    public class SysConfig : BaseModel
    {
        public string key { get; set; }
        public string value { get; set; }
        public int status { get; set; }
        public string remark { get; set; }
    }
}
