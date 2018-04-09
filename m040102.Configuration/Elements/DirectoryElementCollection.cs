using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace m040102.Configuration.Elements
{
    [ConfigurationCollection(typeof(DirectoryElement),
        AddItemName = "directory")]
    public class DirectoryElementCollection :
        ConfigurationElementCollection, IEnumerable<DirectoryElement>
    {
        protected override ConfigurationElement CreateNewElement()
            =>
            new DirectoryElement();

        protected override object GetElementKey(ConfigurationElement element)
            =>
            ((DirectoryElement)element).Path;

        public new IEnumerator<DirectoryElement> GetEnumerator()
        {
            return this.BaseGetAllKeys().Select(
                key => (DirectoryElement)BaseGet(key)).GetEnumerator();
        }
    }
}
