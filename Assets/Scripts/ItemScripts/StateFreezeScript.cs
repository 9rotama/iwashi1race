using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateFreezeScript : MonoBehaviour
{
    Vector2 fixedSp;
    Rigidbody2D tarRb;
    int clickedCnt;
    [SerializeField] Sprite[] sprites;

    //音声
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip crackSE;
    [SerializeField] AudioClip brokenSE;

    // Start is called before the first frame update
    void Start()
    {
        tarRb = transform.parent.GetComponent<Rigidbody2D>();
        fixedSp = tarRb.velocity;
    }

    // Update is called once per frame
    void Update()
    {
        //タグで処理変化
        if(transform.parent.tag == "Player"){
            PlayerUpdate();
        }
        else{
            EnemyUpdate();
        }

         //スプライト変更
        if(GetComponent<SpriteRenderer>().sprite != sprites[sprites.Length-1]) {
            GetComponent<SpriteRenderer>().sprite = sprites[clickedCnt/2%sprites.Length];
        }
        else{
            if(transform.parent.tag == "Player") {
                Vector3 cameraPos = Camera.main.gameObject.transform.position;
                AudioSource.PlayClipAtPoint(brokenSE, cameraPos - Vector3.back*5f);
            }
            Destroy(this.gameObject);
        }

    }

    void FixedUpdate()
    {
        //動きを制限
        fixedSp *= 0.95f;
        tarRb.AddForce(Vector2.one * ((fixedSp - tarRb.velocity) * 30), ForceMode2D.Force);
    }

    //Playerの処理
    void PlayerUpdate()
    {
        //ボタン、クリックの回数加算
        if(Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || 
            Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D) ||
            Input.GetMouseButtonDown(0)){
            audioSource.PlayOneShot(crackSE);
            clickedCnt++;
        }
    }

    //Enemyの処理
    float crackTime;
    void EnemyUpdate()
    {
        crackTime += Time.deltaTime;
        if(crackTime > 0.1f){
            crackTime = Random.Range(-0.1f,0.1f);
            clickedCnt++;
        }
    }
}
