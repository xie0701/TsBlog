using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SqlSugar;

namespace TsBlog.Domain.Entities
{
    [SqlSugar.SugarTable("tb_menu")]
    public class Menu
    {
        [SqlSugar.SugarColumn(IsPrimaryKey=true,IsIdentity=true)]
        public int Id { get; set; }

        public int ParentId { get; set; }

        public string MenuName { get; set; }

        public string MenuUrl { get; set; }

        public string Icon { get; set; }

        public int OrderNo { get; set; }

        public bool Status { get; set; }

        public DateTime CreateOn { get; set; }

        public DateTime? UpdateOn { get; set; }

        public int? CreateBy { get; set; }

        public int? UpdateBY { get; set; }
    }
}
