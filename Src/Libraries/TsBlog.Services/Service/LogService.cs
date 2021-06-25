using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TsBlog.Domain.Entities;
using TsBlog.Repositories;

namespace TsBlog.Services
{
    public class LogService : GenericService<Log>, ILogService
    {
        private readonly ILogRepository _repository;
        public LogService(ILogRepository repository)
            : base(repository)
        {
            _repository = repository;
        }
        public bool WriteDbLog(Log log)
        {
            log.Status = true;
            log.CreateOn = DateTime.Now;
            log.IPAddress = "";
            log.IPAddressName = "";
            return _repository.Insert(log) > 0;
        }
    }
}
