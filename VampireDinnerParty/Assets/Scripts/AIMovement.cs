using System.Collections;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class AIMovement : MonoBehaviour
{
    public float speed = 2;
    public float directionChangeInterval = 2.0f;
    public float maxHeadingChange = 180;
    public float minWaitTime = 2.0f;
    public float maxWaitTime = 7.0f;
    public float minWalkTime = 3.0f;
    public float maxWalkTime = 10.0f;
    public float lookAhead = 2.0f;
    public float secToWaitAfterWallHit = 2.0f;

    private CharacterController controller;
    private float heading;
    private float walkTime;
    private Quaternion targetRotation;
    private float timePassed = 0.0f;
    private bool nearWall = false;

    public bool isMoving;
    public bool isDead;


    void Awake()
    {
        isMoving = false;
        isDead = false;

        controller = GetComponent<CharacterController>();

        heading = Random.Range(0, 360);
        transform.eulerAngles = new Vector3(0, heading, 0);

        StartCoroutine(NewHeading());
    }

    void Update()
    {
        RaycastHit hit;
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward *lookAhead), Color.red);
        //Debug.DrawRay(transform.position, -Vector3.forward * lookAhead, Color.yellow);
        //Debug.DrawRay(transform.position, Vector3.right * lookAhead, Color.yellow);
        //Debug.DrawRay(transform.position, -Vector3.right * lookAhead, Color.yellow);
        //int layerMask = 1 << 10;
        //layerMask = ~layerMask;


        if (timePassed < walkTime)
        {
            if (!nearWall)
            {
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * directionChangeInterval);
            }
            isMoving = true;
            Vector3 forward = transform.TransformDirection(Vector3.forward);
            controller.SimpleMove(forward * speed);
            timePassed += Time.deltaTime;

            /*if (Physics.Raycast(transform.position, transform.forward, out hit, lookAhead) || Physics.Raycast(transform.position, transform.right, out hit, lookAhead) ||
                Physics.Raycast(transform.position, -transform.right, out hit, lookAhead) || Physics.Raycast(transform.position, -transform.forward, out hit, lookAhead))
            {
                if (hit.collider.tag == "Obstacle")
                {
                    Debug.Log("Did Hit");
                    nearWall = true;
                    transform.eulerAngles = Vector3.Slerp(transform.eulerAngles, targetRotation * 5, Time.deltaTime * directionChangeInterval);
                }
            }
            else
            {
                nearWall = false;
            }*/

            if (Physics.Raycast(transform.position, transform.TransformDirection(transform.forward), out hit, lookAhead))
            {
                if (hit.collider.tag == "Obstacle")
                {
                    
                    nearWall = true;
                    transform.rotation = Quaternion.AngleAxis(Random.Range(90, 180), transform.up) * transform.rotation;
                    targetRotation = transform.rotation;
                    //transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Inverse(transform.rotation), Time.deltaTime * directionChangeInterval);
                    //transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 180, 0), Time.deltaTime * directionChangeInterval);
                    //transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Inverse(transform.rotation), Time.deltaTime * directionChangeInterval);
                    //targetRotation = transform.rotation;
                    //targetRotation = new Vector3(0, Random.Range(100, 300), 0);
                    StartCoroutine(TimeToMoveAway());
                }
            }
        }
        else
        {
            StartCoroutine(Wait());
        }

    }

    IEnumerator NewHeading()
    {
        while (true)
        {
            float min = Mathf.Clamp(heading - maxHeadingChange, 0, 360);
            float max = Mathf.Clamp(heading + maxHeadingChange, 0, 360);
            heading = Random.Range(min, max);
            targetRotation = Quaternion.Euler(0, heading, 0);
            walkTime = Random.Range(minWalkTime, maxWalkTime);
            yield return new WaitForSeconds(directionChangeInterval);
        }
    }

    IEnumerator TimeToMoveAway()
    {
        yield return new WaitForSeconds(secToWaitAfterWallHit);
        nearWall = false;
    }

    IEnumerator Wait()
    {
        isMoving = false;
        yield return new WaitForSeconds(Random.Range(minWaitTime, maxWaitTime));
        timePassed = 0f;
    }

    /*private void OnTriggerEnter(Collider col)
    { 
        if (col.tag == "Wall")
        {
            Vector3 forceRotation = new Vector3(0.0f, 180.0f, 0.0f);
            targetRotation += forceRotation;
            //transform.Rotate(0, 180, 0);
        }

    }*/
}