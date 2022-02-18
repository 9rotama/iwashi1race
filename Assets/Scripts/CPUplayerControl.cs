using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class CPUplayerControl : MonoBehaviour
{
    public Transform target;

    public float speed;
    public float nextWaypointDistance;

    private Path path;
    private int currentWaypoint;

    private bool reachedEndOfPath;

    private Seeker seeker;
    private Rigidbody2D rb;
    
    private float scX, scY;
    public float scatterFac = 0.1f;
    
    void Start()
    {
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();

        seeker.StartPath(rb.position, target.position, OnPathComplete);
        
        scX = Random.value - 0.5f;
        scY = Random.value - 0.5f;
    }

    void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            path = p;
            currentWaypoint = 0;
        }
    }

    void Update()
    {
        if (path == null) return;

        if (currentWaypoint >= path.vectorPath.Count)
        {
            reachedEndOfPath = true;
            return;
        }
        else
        {
            reachedEndOfPath = false;
        }

        Vector2 scatterVec = new Vector2(scX, scY);
        
        Vector2 direction = ((Vector2) path.vectorPath[currentWaypoint] - rb.position + scatterVec * scatterFac).normalized;
        Vector2 force = direction * speed * Time.deltaTime;

        rb.AddForce(force);

        //this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.Euler(0, 0, Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg - 90), Time.deltaTime);
        
        float distance = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);

        if (distance < nextWaypointDistance)
        {
            currentWaypoint++;
            scX = Random.value - 0.5f;
            scY = Random.value - 0.5f;
            Debug.Log(scX);
        }
    }
}
