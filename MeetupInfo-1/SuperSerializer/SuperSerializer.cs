using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace SuperSerializer
{
  public class SuperSerializer<T> where T : class
  {
    public T DeserializeAndValidate(Stream xmlContent, Stream xsdContent)
    {
      using (var xmlReader = XmlReader.Create(xmlContent))
      {
        var xml = new XmlDocument();
        xml.Load(xmlReader);
        xmlContent.Position = 0;

        using (var xsdReader = XmlReader.Create(xsdContent))
        {
          xml.Schemas.Add(null, xsdReader);
          xml.Validate(null);
        }
      }
      XmlSerializer serializer = new XmlSerializer(typeof(T));
      return (T)serializer.Deserialize(xmlContent);
    }
  }
}
