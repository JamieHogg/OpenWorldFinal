using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabLoader : MonoBehaviour {

    public int ChunkNumber;
    private Transform playerPosition;
    private int size = 15;
    private GameObject obj;

    // Use this for initialization
    void Start ()
    {
        obj = transform.parent.GetComponent<EnvironmentPrefabHolder>().prefabs[ChunkNumber];
    }
	
	// Update is called once per frame
	void Update ()
    {
        playerPosition = GameObject.FindGameObjectWithTag("Player").transform;

        if ((distance() < size) && (this.transform.childCount < 1))
        {
            Instantiate(obj, this.transform);
        }
        else if ((distance() > size) && (this.transform.childCount > 0))
        {
            Destroy(this.transform.GetChild(0).gameObject, 0);
        }
    }

    float distance()
    {
        float length = Vector3.Distance(this.transform.position, playerPosition.position);
        return length;
    }

}
