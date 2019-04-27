using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayerImproved : MonoBehaviour {

    public float cameraMovementSpeed = 120.0f;
    public GameObject cameraTarget;
    public GameObject player;

    Vector3 followPos;
    public float clampAngle = 80.0f;
    public float inputSensitivity = 150.0f;
    public float camDistanceXToPlayer;
    public float camDistanceYToPlayer;
    public float camDistanceZToPlayer;
    public float mouseX;
    public float mouseY;
    public float finalInputX;
    public float finalInputY;

    private float rotX = 0.0f;
    private float rotY = 0.0f;


    // Use this for initialization
    void Start ()
    {
        Vector3 rot = transform.localRotation.eulerAngles;
        rotY = rot.y;
        rotX = rot.x;	
	}
	
	// Update is called once per frame
	void Update ()
    {
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");
        finalInputX = inputX + mouseX;
        finalInputY = inputY + mouseY;

        rotX += finalInputX + inputSensitivity * Time.deltaTime;
        rotY += finalInputY + inputSensitivity * Time.deltaTime;

        rotX = Mathf.Clamp(rotX, -clampAngle, clampAngle);

        Quaternion localRotation = Quaternion.Euler(rotX, rotY, 0.0f);
        transform.rotation = localRotation;
    }

    void LateUpdate ()
    {
        CameraUpdater();
    }

    void CameraUpdater()
    {
        Transform target = cameraTarget.transform;

        float step = cameraMovementSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target.position, step);
    }
}
