using System.Configuration;

namespace m040102.Configuration.Elements
{
    public class DirectoryElement : ConfigurationElement
    {
        [ConfigurationProperty("path")]
        public string Path => (string)base["path"];
    }
}
