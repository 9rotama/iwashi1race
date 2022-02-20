using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireScript : MonoBehaviour
{
    Rigidbody2D rb;
    Vector3 shotForward;
    GameObject otherObj;
    public GameObject creatorObj;
    bool isCollision;
    float time;
    const float sp = 400.0f;

    GameObject itemControl;
    ItemControlScript itemScript;

    AudioSource audioSource;

    [SerializeField] AudioClip fireSe;
    [SerializeField] AudioClip damageSe;


    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        itemControl = GameObject.Find("ItemController");
        itemScript = itemControl.GetComponent<ItemControlScript>();
        rb = transform.GetComponent<Rigidbody2D>();
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        shotForward = Vector3.Scale((mouseWorldPos - transform.parent.position), new Vector3(1, 1, 0)).normalized;
        creatorObj = transform.parent.gameObject;
        if(creatorObj.tag == "Player"){
            shotForward = Vector3.Scale((mouseWorldPos - transform.parent.position), new Vector3(1, 1, 0)).normalized;
            audioSource.PlayOneShot(fireSe);
        }
        else{
            shotForward = new Vector3(Random.Range(-1f,1f), Random.Range(-1f,1f), 0f).normalized;
        }
        transform.parent = null;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.velocity = shotForward * sp;
        if(isCollision){
            time += Time.deltaTime;
            if(time < 1.0f){
                Rigidbody2D rb = otherObj.GetComponent<Rigidbody2D>();
                rb.AddForce(Vector3.right * ((0 - rb.velocity.x) * 30), ForceMode2D.Force);
                rb.AddForce(Vector3.up * ((0 - rb.velocity.y) * 30), ForceMode2D.Force);
                itemScript.isDefence = true;
            }
            else{
                Destroy(this.gameObject);
                itemScript.isDefence = false;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if((other.tag == "Player" || other.tag == "Enemy") && other.gameObject != creatorObj){
            audioSource.PlayOneShot(damageSe);
            isCollision = true;
            otherObj = other.gameObject;
            transform.position = new Vector3(-1000, -1000, 0);
        }
    }
}
