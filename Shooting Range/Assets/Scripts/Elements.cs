using UnityEngine;
using System.Collections;
using System.Xml.Serialization;
using System.IO;

[XmlRoot("elements")]
public class Elements
{
    [XmlElement("element")]
    public Element[] element;

    public static Elements Load(TextAsset _xml)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(Elements));
        StringReader reader = new StringReader(_xml.text);
        Elements elements = serializer.Deserialize(reader) as Elements;
        return elements;
    }
}
[System.Serializable]
public class Element
{
    [XmlElement("name")]
    public string name;
    [XmlElement("reward")]
    public int reward;
}
