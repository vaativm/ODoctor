using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ODoctor.Core.Entities
{
    public abstract class BaseEntity<T>
    {
        private IList<BusinessRule> _brokenRules = new List<BusinessRule>();
        public T Id { get; set; }
        [Timestamp]
        public byte[] Timestamp { get; set; }
        public abstract void Validate();
        protected void AddBrokenRule(BusinessRule businessRule)
        {
            _brokenRules.Add(businessRule);
        }
        protected IEnumerable<BusinessRule> GetBrokenBusinessRules()
        {
            _brokenRules.Clear();
            Validate();

            return _brokenRules;
        }
    }
}
