using System.Configuration;

namespace m040102.FileSystem.Elements
{
    public class DirectoryElement : ConfigurationElement
    {
        [ConfigurationProperty("path")]
        public string Path => (string)base["path"];
    }
}
