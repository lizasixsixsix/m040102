using System.Configuration;
using System.IO;

namespace m040102.Configuration.Elements
{
    public class DefaultDirectoryElement : ConfigurationElement
    {
        [ConfigurationProperty("path")]
        public DirectoryInfo Path
            =>
            new DirectoryInfo((string)base["path"]);
    }
}
