using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace m040102.Configuration.Elements
{
    [ConfigurationCollection(typeof(RuleElement),
        AddItemName = "rule")]
    public class RuleElementCollection :
        ConfigurationElementCollection, IEnumerable<RuleElement>
    {
        protected override ConfigurationElement CreateNewElement()
            =>
            new RuleElement();

        protected override object GetElementKey(ConfigurationElement element)
            =>
            ((RuleElement)element).FileNamePattern;

        public new IEnumerator<RuleElement> GetEnumerator()
        {
            return this.BaseGetAllKeys().Select(
                key => (RuleElement)BaseGet(key)).GetEnumerator();
        }
    }
}
