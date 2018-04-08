using System.Configuration;

using m040102.FileSystem.Elements;

namespace m040102.Configuration
{
    public class FileMoverConfigSection : ConfigurationSection
    {
        [ConfigurationProperty("culture")]
        public CultureElement Culture =>
            (CultureElement)this["culture"];

        [ConfigurationProperty("directories")]
        public DirectoryElementCollection ListenDirectories =>
            (DirectoryElementCollection)base["directories"];

        [ConfigurationProperty("defaultDirectory")]
        public DefaultDirectoryElement DefaultDirectory =>
            (DefaultDirectoryElement)this["defaultDirectory"];

        [ConfigurationProperty("rules")]
        public RuleElementCollection Rules =>
            (RuleElementCollection)base["rules"];
    }
}
