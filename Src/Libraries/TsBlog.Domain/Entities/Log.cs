using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SqlSugar;

namespace TsBlog.Domain.Entities
{
    [SugarTable("tb_log")]
    public class Log
    {
        public int Id { get; set; }
        public string LogType { get; set; }
        public string UserName { get; set; }
        public string RealName { get; set; }
        public string ModuleName { get; set; }
        public string Description { get; set; }
        public DateTime CreateOn { get; set; }
        public string IPAddress { get; set; }
        public string IPAddressName { get; set; }
        public bool? Status { get; set; }
    }
}
