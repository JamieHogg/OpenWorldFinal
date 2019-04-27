using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using UnityEngine;

public class Thing
{
    public ItemDatabase itemDB;

    public void Save(string fileName, GameObject obj)
    {
        string path = Application.dataPath + "/XMLs/" + fileName + "A" + ".xml";

        XmlSerializer xml = new XmlSerializer(typeof(ItemDatabase));
        FileStream stream = new FileStream(path, FileMode.Create);
        xml.Serialize(stream, itemDB);
        stream.Close();
    }

    public void Load(string fileName)
    {
        string path = Application.dataPath + "/XMLs/" + fileName + ".xml";

        XmlSerializer xml = new XmlSerializer(typeof(ItemDatabase));
        FileStream stream = new FileStream(path, FileMode.Open);
        itemDB = xml.Deserialize(stream) as ItemDatabase;
        stream.Close();
    }

    [System.Serializable]
    public class ItemEntry
    {
        public string name { get; set; }
        public float positionX { get; set; }
        public float positionY { get; set; }
        public float positionZ { get; set; }

        public float rotationX { get; set; }
        public float rotationY { get; set; }
        public float rotationZ { get; set; }
    }

    [System.Serializable]
    public class ItemDatabase
    {
        public List<ItemEntry> ItemList = new List<ItemEntry>();
    }
}

