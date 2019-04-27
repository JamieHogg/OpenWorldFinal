using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI : MonoBehaviour
{

    Animator anim;
    Rigidbody rb;
    NavMeshAgent agent;
     

    [Header("Movement Stuff")]
    public int walkSpeed;
    public int runSpeed;

    [Header("Path Stuff")]
    public Transform[] pathPoints;
    private Vector3 target;
    private Vector3 desiredMoveDirection;
    public int currentPath = 0;
    private float distance;



    //other stuff
    private GameObject player;
    private bool runningAway = false;

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");

        currentPath = Random.Range(0, pathPoints.Length);

    }

    // Update is called once per frame
    void Update()
    {
        if (player.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("InfiniDab_Loop"))
        {
            runningAway = true;
        }


        if (!runningAway)
        {
            normal();
        }
        else
        {
            running();
        }
        animations();
    }

    void normal()
    {
        target = pathPoints[currentPath].position;
        distance = Vector3.Distance(transform.position, target);
        reset();

        agent.SetDestination(target);
    }

    void running()
    {
        anim.SetBool("Running", true);
        agent.speed = 4;

        float furthestDistanceSoFar = 0;
        Vector3 runPosition = Vector3.zero;

        //Check each point
        foreach (Transform point in pathPoints)
        {
           // print(Vector3.Distance(player.transform.position, point.position));
            float currentCheckDistance = Vector3.Distance(player.transform.position, point.position);
            if (currentCheckDistance > furthestDistanceSoFar)
            {
                furthestDistanceSoFar = currentCheckDistance;
                runPosition = point.position;
            }
        }
        //Set the right destination for the furthest spot
        agent.SetDestination(runPosition);
    }

    void reset()
    {
        if (distance <= agent.stoppingDistance)
        {
            //currentPath++;

            currentPath = Random.Range(0, pathPoints.Length);
        }

        if (currentPath > (pathPoints.Length - 1))
        {
            currentPath = 0;
        }
    }


    void setDirection()
    {
        desiredMoveDirection = transform.TransformDirection(Vector3.forward);

        desiredMoveDirection.y = 0;
        desiredMoveDirection = desiredMoveDirection.normalized;
    }

    void animations()
    {
        anim.SetFloat("Horizontal", agent.velocity.x);
        anim.SetFloat("Vertical", agent.velocity.z);
    }
}