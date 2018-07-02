using System.Collections;
using System.Collections.Generic;
using Pathfinding;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Seeker))]
public class DreamchaserAI : MonoBehaviour {

    //waht to chase
    public Transform target;

    //how many times each second we will update the path
    public float updateRate = 2f;

    //cashing
    private Seeker seeker;
    private Rigidbody2D rb;

    //The calculator path
    public Path path;

    //The AI speed per second
    public float Speed = 300f;
    public ForceMode2D fMode;

    [HideInInspector]
    public bool pathIsEnded = false;

    //The Max distance from ai to waypoint for it to continue to the next waypoint
    public float nextWaypointDistance = 3;

    //the waypoint we are currently moving towards
    private int currentWaypoint = 0;

    void Start()
    {
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();

        if (target == null)
        {
            Debug.LogError("No Player Found");
            return;
        }

        //start a new path to the target position and return the result to the OnPathComplete method
        seeker.StartPath(transform.position, target.position, OnPathComplete);

        StartCoroutine(UpdatePath());
    }

    IEnumerator UpdatePath()
    {
        if (target == null)
        {
            yield return false;
        }
        //start a new path to the target position and return the result to the OnPathComplete method
        seeker.StartPath(transform.position, target.position, OnPathComplete);

        yield return new WaitForSeconds(1f / updateRate);
        StartCoroutine(UpdatePath());
    }

        public void OnPathComplete (Path p)
        {
            Debug.Log ("We got a path. Dit it have an error?" + p.error);
            if (!p.error)
        {
            path = p;

            currentWaypoint = 0;
        }
        }

    void FixedUpdate ()
    {
        if (target == null)
        {
            return;
        }

        if (path == null)
            return;

        if (currentWaypoint >= path.vectorPath.Count)
        {
            if (pathIsEnded)
                return;

            Debug.Log("End of path reached.");
            pathIsEnded = true;
            return;
        }

        pathIsEnded = false;

        //direction to next waypoint
        Vector3 dir = (path.vectorPath[currentWaypoint] - transform.position).normalized;
        dir *= Speed * Time.fixedDeltaTime;

        //move the ai
        rb.AddForce(dir, fMode);

        float dist = Vector3.Distance(transform.position, path.vectorPath[currentWaypoint]);
        if (dist < nextWaypointDistance)
        {
            currentWaypoint++;
            return;
        }

    }


}






