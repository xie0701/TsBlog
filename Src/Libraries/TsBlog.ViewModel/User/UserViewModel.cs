using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TsBlog.ViewModel.User
{
    public class UserViewModel
    {
        public int Id { get; set; }

        public string LoginName { get; set; }

        public string Password { get; set; }

        public string RealName { get; set; }

        public string EmailAddress { get; set; }

        public string Avatar { get; set; }

        public int Status { get; set; }

        public string Telephone { get; set; }

        public string QQ { get; set; }

        public string WebsiteUrl { get; set; }

        public DateTime CreatedOn { get; set; }

        public string CreatedIp { get; set; }

        public int LoginCount { get; set; }

        public DateTime? LastLoginDate { get; set; }

        public string LastLoginIp { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public int Type { get; set; }
    }
}
