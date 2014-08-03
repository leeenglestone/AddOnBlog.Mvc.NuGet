using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace AddOnBlog.Mvc.Library
{
    public class GenericListSerializer<T>
    {
        //To retain the serializer list that the T contains

        private List<T> _interfaceList;

        //Serializers collection stored with type name
        private Dictionary<string, XmlSerializer> serializers;

        /// <summary/>

        /// Creates a new instance of generic list serializer 
        /// </summary/>
        /// <param name="interfaceList">Generic list of interface type</param>
        public GenericListSerializer(List<T> interfaceList)
        {
            _interfaceList = interfaceList;
            InitializeSerializers();
        }


        /// <summary>
        /// Initializes all the type of XML serializers the
        /// generic list requires 
        /// </summary>
        private void InitializeSerializers()
        {
            serializers = new Dictionary<string, XmlSerializer>();
            for (int index = 0; index < _interfaceList.Count; index++)
            {

                //Add new serializer to the serializers list by
                //passing the class name 
                //Ignore if already added
                GetSerializerByTypeName(
                                        _interfaceList[index].GetType().FullName);
            }
        }

        /// <summary>
        /// Serializes list 
        /// </summary>
        /// <param name="outputStream">Ouput stream to write the
        /// serialized data</param>

        public void Serialize(XmlWriter outputStream)
        {
            for (int index = 0; index < _interfaceList.Count; index++)
            {
                //Get appropriate serializer

                GetSerializerByTypeName(
                                       _interfaceList[index].GetType().FullName).Serialize
                (outputStream, _interfaceList[index]);
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
                returnSerializer = new XmlSerializer(
                                         Type.GetType(typeName));
                serializers.Add(typeName, returnSerializer);
            }

            //Return the retrived XmlSerializer

            return returnSerializer;
        }
    } 
}
