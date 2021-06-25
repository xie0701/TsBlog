using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TsBlog.Core
{
    public class IdGeneratorHelper
    {
        private int SnowFlakeWorkerId = 1;

        private Snowflake snowflake;

        private static readonly IdGeneratorHelper instance = new IdGeneratorHelper();

        private IdGeneratorHelper()
        {
            snowflake = new Snowflake(SnowFlakeWorkerId, 0, 0);
        }

        public static IdGeneratorHelper Instance
        {
            get
            {
                return instance;
            }
        }

        public long GetId()
        {
            return snowflake.NextId();
        }
    }
}
