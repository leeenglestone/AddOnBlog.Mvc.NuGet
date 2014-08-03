using AddOnBlog.Mvc.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace AddOnBlog.Mvc.Models
{
    public class Comments : List<IComment>, IXmlSerializable
    {
        public System.Xml.Schema.XmlSchema GetSchema()
        {
            throw new NotImplementedException();
        }

        public void ReadXml(System.Xml.XmlReader reader)
        {
            GenericListDeSerializer<IComment> dslzr =
                               new GenericListDeSerializer<IComment>();
            dslzr.Deserialize(reader, this); 
        }

        public void WriteXml(System.Xml.XmlWriter writer)
        {
            throw new NotImplementedException();
        }
    }
}
