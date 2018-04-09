using System.Configuration;

namespace m040102.Configuration.Elements
{
    public class RuleElement : ConfigurationElement
    {
        [ConfigurationProperty("fileNamePattern")]
        public string FileNamePattern
            =>
            (string)base["fileNamePattern"];

        [ConfigurationProperty("destinationPath")]
        public string DestinationPath
            =>
            (string)base["destinationPath"];
    }
}
