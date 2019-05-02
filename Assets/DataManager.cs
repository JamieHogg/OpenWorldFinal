using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DataManager : MonoBehaviour
{
    public void Save(string path, Items item)
    {
        string jsonString = JsonUtility.ToJson(item, true);

        File.WriteAllText(path, jsonString);
    }

    public void Load(string path, Items item)
    {
        string jsonString = File.ReadAllText(path);
        JsonUtility.FromJsonOverwrite(jsonString, item);
    }
}
