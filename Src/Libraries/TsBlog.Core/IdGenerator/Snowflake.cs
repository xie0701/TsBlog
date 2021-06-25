using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TsBlog.Core
{
    public class Snowflake
    {
        private const long TwEpoch = 1609430400000L;

        private const int WorkerIdBits = 5;
        private const int DatacenterIdBits = 5;
        private const int SequenceBits = 12;
        private const long MaxWorkerId = -1L ^ (-1L << WorkerIdBits);
        private const long MaxDatacenterId = -1L ^ (-1L << DatacenterIdBits);

        private const int WorkerIdShift = SequenceBits;
        private const int DatacenterIdShift = SequenceBits + WorkerIdBits;
        private const int TimestampLeftShift = SequenceBits + WorkerIdBits + DatacenterIdBits;
        private const long SequenceMask = -1L ^ (-1L << SequenceBits);

        private long _sequence = 0L;
        private long _lastTimestamp = -1L;

        public long WorkerId { get; protected set; }

        public long DatacenterId { get; protected set; }

        private readonly object _lock = new object();

        public Snowflake(long workerId, long datacenterId, long sequence = 0L)
        {
            WorkerId = workerId;
            DatacenterId = datacenterId;
            _sequence = sequence;
            if (workerId > MaxWorkerId || workerId < 0)
            {
                throw new ArgumentException(string.Format("worker Id can't be greater than {0} or less than 0", MaxWorkerId));
            }

            if (datacenterId > MaxDatacenterId || datacenterId < 0)
            {
                throw new ArgumentException(string.Format("datacenter Id can't be greater than {0} or less than 0", MaxDatacenterId));
            }
        }

        public long CurrentId { get; private set; }

        public long NextId()
        {
            lock (_lock)
            {
                var timestamp = GetUnixTimeStamp();
                if (timestamp < _lastTimestamp)
                {
                    throw new Exception(string.Format("Clock moved backwards or wrapped around. Refusing to generate id for {0} ticks", _lastTimestamp - timestamp));
                }

                if (_lastTimestamp == timestamp)
                {
                    _sequence = (_sequence + 1) & SequenceMask;
                    if (_sequence == 0)
                    {
                        timestamp = TilNextMillis(_lastTimestamp);
                    }
                }
                else
                {
                    _sequence = 0;
                }
                _lastTimestamp = timestamp;
                CurrentId = ((timestamp - TwEpoch) << TimestampLeftShift) | (WorkerId << WorkerIdShift) | _sequence;
                return CurrentId;
            }
        }

        private static long GetUnixTimeStamp()
        {
            return (long)(DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds;
        }

        private long TilNextMillis(long lastTimestamp)
        {
            var timestamp = GetUnixTimeStamp();
            while (timestamp <= lastTimestamp)
            {
                timestamp = GetUnixTimeStamp();
            }
            return timestamp;
        }
    }
}
