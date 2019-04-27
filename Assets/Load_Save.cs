using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using UnityEngine;

public class Load_Save
{

    public string name { get; set; }

    public float positionX { get; set; }
    public float positionY { get; set; }
    public float positionZ { get; set; }

    public float rotationX { get; set; }
    public float rotationY { get; set; }
    public float rotationZ { get; set; }

    public void Save(string fileName)
    {
        var xml = new XmlSerializer(typeof(Load_Save));
        using (var stream = new FileStream(fileName, FileMode.Create))
        {
            xml.Serialize(stream, this);
        }
    }

    /*
    public Load_Save Load(string fileName)
    {
        using (var stream = new FileStream(fileName, FileMode.Open))
        {
            var xml = new XmlSerializer(typeof(Load_Save));
            return (Load_Save)xml.Deserialize(stream);
        }
    }
    */
}