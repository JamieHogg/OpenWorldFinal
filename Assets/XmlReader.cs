using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using UnityEngine;

public class XmlReader : MonoBehaviour
{
    Items item = new Items();

    private Transform playerPosition;
    private int size = 20;
    private GameObject[] obj;

    public string fileName;

    public string prefabName;
    public int prefabNumber;
    public Vector3 positionObj;
    public Vector3 rotationObj;

    private int actualLength = 1;

    // Use this for initialization
    void Start()
    {
        fileName = this.name;
        obj = new GameObject[4];

        //load();

    }

    // Update is called once per frame
    void Update()
    {
        playerPosition = GameObject.FindGameObjectWithTag("Player").transform;

        if ((distance() < size) && (this.transform.childCount < actualLength))
        {
            for (int n = 0; n < actualLength; n++)
            {
                load();

                // Instantiate object
                GameObject inst = Instantiate(obj[n], this.transform);

                // set new position & rotation
                inst.transform.localPosition = positionObj;
                inst.transform.localEulerAngles = rotationObj;
                inst.transform.localEulerAngles = rotationObj;
            }
        }
        else if ((distance() > size) && (this.transform.childCount > 0))
        {
            Destroy(this.transform.GetChild(0).gameObject, 0);
        }

        if (this.transform.childCount > 0)
        {
        }
        //save();
    }

    private float distance()
    {
        float length = Vector3.Distance(this.transform.position, playerPosition.position);
        return length;
    }

    private void save()
    {
        string path = Application.dataPath + "/XMLs/" + fileName + ".json";
        GameObject current = this.transform.GetChild(0).gameObject;

        item.name = current.transform.name;

        item.position = current.transform.localPosition;
        item.rotation = current.transform.localEulerAngles;

        GameObject.FindGameObjectWithTag("DataManager").GetComponent<DataManager>().Save(path, item);
    }

    private void load()
    {
        string path = Application.dataPath + "/XMLs/" + fileName + ".json";
        GameObject current = obj[0];

        GameObject.FindGameObjectWithTag("DataManager").GetComponent<DataManager>().Load(path, item);

        prefabName = item.name;
        positionObj = item.position;
        rotationObj = item.rotation;

        loadPrefab();
    }

    private void loadPrefab()
    {
        prefabNumber = transform.parent.GetComponent<EnvironmentPrefabHolder>().getPrefabNumber(prefabName);
        obj[0] = transform.parent.GetComponent<EnvironmentPrefabHolder>().prefabs[prefabNumber];
    }
}

