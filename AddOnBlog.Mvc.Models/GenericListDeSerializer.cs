using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace AddOnBlog.Mvc.Models
{

    public class GenericListDeSerializer<T>
    {
        //Serializers collection stored with type name
        private Dictionary<string, XmlSerializer> serializers;

        public GenericListDeSerializer()
        {
            serializers = new Dictionary<string, XmlSerializer>();
        }


        /// <summary>
        /// Deserializes list 
        /// </summary>
        /// <param name="outputStream">Ouput stream to write the
        /// serialized data </param>
        public void Deserialize(XmlReader inputStream, List<T> interfaceList)
        {
            //Get the base node name of generic list of items of
            // type IProjectMember

            string parentNodeName = inputStream.Name;

            //Move to first child
            inputStream.Read();

            while (parentNodeName != inputStream.Name)
            {
                XmlSerializer slzr = GetSerializerByTypeName(
                                        inputStream.Name);
                interfaceList.Add((T)slzr.Deserialize(inputStream));
            }
        }

        /// <summary>

        /// Gets serializer by type name from internal XML serializers list 
        /// If specific serializers doesn't exists adds it and returns it 
        /// </summary>
        /// <param name="typeName">Class type name</param>
        /// <returns>XmlSerializer</returns> 

        private XmlSerializer GetSerializerByTypeName(string typeName) 
		{ 
			XmlSerializer returnSerializer = null; 
			
			//Check if existing already
			if (serializers.ContainsKey(typeName)) 
			{ 
				returnSerializer = serializers[typeName]; 
			} 
			//If doesn't exist in list create a new one and add it to list 
			if (returnSerializer == null) 
			{ 
				returnSerializer = new XmlSerializer(Type.GetType(this.GetType().Namespace + "." + 
                                         typeName)); 
				serializers.Add(typeName, returnSerializer); 
			} 

			//Return the retrived XmlSerializer

			return returnSerializer; 
		}
    }
}
