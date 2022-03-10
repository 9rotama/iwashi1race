using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeScript : MonoBehaviour
{
    Rigidbody2D rb;
    Vector3 shotForward;
    const float sp = 500.0f;
    GameObject creatorObj;
    [SerializeField] GameObject stateFreeze;
    static GameObject rank;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        creatorObj = transform.parent.gameObject;

        if(creatorObj.tag == "Player"){
            //発射音
            GetComponent<AudioSource>().Play();

            //発射方向指定
            Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            shotForward = Vector3.Scale((mouseWorldPos - transform.parent.position), new Vector3(1, 1, 0)).normalized;
        }
        else{
            if(rank == null) {
                rank = GameObject.Find("Rank");
            }
            GameObject tar = rank.GetComponent<RankSort>().GetOneRankUpObj(creatorObj);
            shotForward = Vector3.Scale((tar.transform.position - transform.parent.position), new Vector3(1, 1, 0)).normalized;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.velocity = shotForward * sp;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if((other.tag == "Player" || other.tag == "Enemy") && other.gameObject != creatorObj){

            GameObject obj = (GameObject)Instantiate(stateFreeze, other.transform.position, Quaternion.identity);
            obj.transform.SetParent(other.transform);
        
            transform.position = new Vector3(-1000, -1000, 0);
            Invoke("DestroyGameObject",1);
        }
    }

    void DestroyGameObject()
    {
        Destroy(this.gameObject);
    }
}
