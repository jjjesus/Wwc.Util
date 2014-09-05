using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Wwc.Util
{
    public static class XmlEx
    {
        /// <summary>
        /// If an XML element ("Name") is missing, then, doing something 
        /// like this will throw an exception:
        /// 
        ///     xmlElement.Element("Name").Value
        /// 
        /// Instead of throwing an exception, this method returns a null string:
        /// 
        ///     xmlElement.SafeGetElementValue("Name")
        /// 
        /// </summary>
        /// <param name="parent"></param>
        /// <param name="element"></param>
        /// <returns></returns>
        public static string SafeGetElementValue(this XElement parent, string element)
        {
            return
                (parent != null) ?
                    (parent.Element(element) != null) ?
                            parent.Element(element).Value
                            : null
                    : null;
        }
    }
}
