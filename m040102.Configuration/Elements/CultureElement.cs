using System.Configuration;

namespace m040102.Configuration.Elements
{
    public class CultureElement : ConfigurationElement
    {
        [ConfigurationProperty("name")]
        public string Name
            =>
            (string)base["name"];
    }
}
