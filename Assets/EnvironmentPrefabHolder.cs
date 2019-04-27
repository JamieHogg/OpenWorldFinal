using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentPrefabHolder : MonoBehaviour {


    public GameObject[] prefabs;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public int getPrefabNumber(string name)
    {
        switch (name)
        {
            case "White_Plane(Clone)":
                return 0;
            case "Black_Plane(Clone)":
                return 1;
        }
        return 0;
    }
}
