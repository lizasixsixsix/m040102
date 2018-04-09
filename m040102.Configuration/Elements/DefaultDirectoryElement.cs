using System.Configuration;

namespace m040102.Configuration.Elements
{
    public class DefaultDirectoryElement : ConfigurationElement
    {
        [ConfigurationProperty("path")]
        public string Path
            =>
            (string)base["path"];
    }
}
