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
            case "Road_Type_1(Clone)":
                return 2;
            case "Road_Type_2(Clone)":
                return 3;
            case "Road_Type_3(Clone)":
                return 4;
            case "Road_Type_4(Clone)":
                return 5;
            case "Grass(Clone)":
                return 6;
        }
        return 0;
    }
}
