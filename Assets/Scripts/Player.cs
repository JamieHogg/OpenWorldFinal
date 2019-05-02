using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Animator anim;

    [Header("Movement Stuff")]
    public int walkSpeed;
    public int runSpeed;
    private int speed;
    public float boostSpeedModifier = 2f;

    public int rotateSpeed;

    public bool MovingForward = false;
    public bool MovingBackwards = false;

    private Rigidbody rb;
    private Vector3 move;

    private Camera mainCam;
    private Vector3 camF;
    private Vector3 camR;
    private Vector3 desiredMoveDirection;

    private float joystick_deadzone = 0.3f;
    private bool running = false;


    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>() as Camera;
    }

    // Update is called once per frame
    void Update()
    {
        float v = Input.GetAxis("Vertical");
        float h = Input.GetAxis("Horizontal");

        anim.SetFloat("Vertical", v);
        anim.SetFloat("Horizontal", h);

        Movement(h, v);
        setDirection(h, v);
        emotes(h, v);
    }

    //Does the movement
    void Movement(float h, float v)
    {
        if (Input.GetButton("Run"))
        {
            speed = runSpeed;
            anim.SetBool("Running", true);
            running = true;
        }
        else
        {
            speed = walkSpeed;
            anim.SetBool("Running", false);
            running = false;
        }

        if (v > joystick_deadzone || v < -joystick_deadzone || h > joystick_deadzone || h < -joystick_deadzone)
        {

            desiredMoveDirection = Vector3.RotateTowards(desiredMoveDirection, desiredMoveDirection, 10 * Time.deltaTime, 1000);
            desiredMoveDirection = desiredMoveDirection.normalized;
            transform.rotation = Quaternion.LookRotation(desiredMoveDirection);

            Vector3 move = desiredMoveDirection * speed;

            move.y = rb.velocity.y;
            rb.velocity = move;

            transform.position += move * Time.deltaTime;


        }
    }

    void setDirection(float h, float v)
    {
        Transform cameraTransform = mainCam.transform;
        Vector3 forward = cameraTransform.TransformDirection(Vector3.forward);

        forward.y = 0;
        forward = forward.normalized;

        Vector3 right = new Vector3(forward.z, 0, -forward.x);
        right.y = 0;

        desiredMoveDirection = (forward * v + right * h);
        desiredMoveDirection.y = 0;

    }

    void emotes(float h, float v)
    {
        if (v == 0 && h == 0)
        {
            if (Input.GetButton("Dance"))
            {
                anim.SetBool("Dance", true);
            }
            else
            {
                anim.SetBool("Dance", false);

            }
        }
    }
}