using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveChunks : MonoBehaviour {

    private GameObject playerPosition;

    // Use this for initialization
    void Start () {
        playerPosition = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update () {
        Debug.Log(checkZ());

        if (checkX() > 20)
        {
            this.transform.position += new Vector3(50, 0, 0);
        }
        else if (checkX() < -20)
        {
            this.transform.position -= new Vector3(50, 0, 0);
        }

        if (checkZ() > 20)
        {
            this.transform.position -= new Vector3(0, 0, 50);
        }
        else if (checkZ() < -20)
        {
            this.transform.position += new Vector3(0, 0, 50);
        }
    }

    float checkX()
    {
        return playerPosition.transform.position.x - this.transform.position.x;
    }
    float checkZ()
    {
        return  this.transform.position.z - playerPosition.transform.position.z;
    }
}
