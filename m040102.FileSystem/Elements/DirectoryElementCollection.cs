using System.Configuration;

namespace m040102.FileSystem.Elements
{
    [ConfigurationCollection(typeof(DirectoryElement),
        AddItemName = "directory")]
    public class DirectoryElementCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
            =>
            new DirectoryElement();

        protected override object GetElementKey(ConfigurationElement element)
            =>
            ((DirectoryElement)element).Path;
    }
}
