using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireScript : MonoBehaviour
{
    Rigidbody2D rb;
    Vector3 shotForward;

    const float sp = 30.0f;


    // Start is called before the first frame update
    void Start()
    {
        rb = transform.GetComponent<Rigidbody2D>();
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        shotForward = Vector3.Scale((mouseWorldPos - transform.parent.position), new Vector3(1, 1, 0)).normalized;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.velocity = shotForward * sp;
    }
}
