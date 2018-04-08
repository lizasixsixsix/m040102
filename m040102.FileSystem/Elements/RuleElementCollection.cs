using System.Configuration;

namespace m040102.FileSystem.Elements
{
    [ConfigurationCollection(typeof(RuleElement),
        AddItemName = "rule")]
    public class RuleElementCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
            =>
            new RuleElement();

        protected override object GetElementKey(ConfigurationElement element)
            =>
            ((RuleElement)element).FileNamePattern;
    }
}
