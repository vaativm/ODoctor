using System;
using System.Collections.Generic;
using System.Text;

namespace ODoctor.Core.Entities
{
    public enum TokenStatus : short
    {
        Active,
        Expired
    }
    public class Token : BaseEntity<int>
    {
        public Token() { }
        public Token(int timeslotId, int serviceId)
        {
            TimeslotId = timeslotId;
            ServiceId = serviceId;
        }
        public int TimeslotId { get; set; }
        public int ServiceId { get; set; }
        public TokenStatus Status { get; set; }
        public string GenerateNumber()
        {
            return $"TK-{DateTimeOffset.Now}-{TimeslotId}-{ServiceId}-{Id}";
        }
        public override void Validate()
        {
            throw new System.NotImplementedException();
        }
    }
}
