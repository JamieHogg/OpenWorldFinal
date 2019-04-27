using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chunks : MonoBehaviour {
    private GameObject[] points;
    public int size;

	// Use this for initialization
	void Start ()
    {
        if (points == null)
        {
            points = GameObject.FindGameObjectsWithTag("Chunk");
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
        loadChunks();

    }

    float distance(int n)
    {
        float length = Vector3.Distance(this.transform.position, points[n].transform.position);
        return length;
    }

    void loadChunks()
    {
        for (int n = 0; n < points.Length; n++)
        {
            if (distance(n) > size)
            {
                points[n].SetActive(false);
            }
            else
            {
                points[n].SetActive(true);
            }
        }
    }
}
