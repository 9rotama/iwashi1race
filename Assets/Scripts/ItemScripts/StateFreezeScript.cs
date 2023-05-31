using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class StateFreezeScript : MonoBehaviour, IRacerCollisionStayer
{
    Vector2 fixedSp;
    Rigidbody2D tarRb;
    int clickedCnt;
    [SerializeField] private Sprite[] sprites;

    [SerializeField] private SpriteRenderer spriteRenderer;

    //音声
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip crackSE;
    [SerializeField] private AudioClip brokenSE;

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
        if(transform.parent.CompareTag("Player")){

            //ボタン、クリックの回数加算
            if(Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || 
                Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D))
            {
                audioSource.PlayOneShot(crackSE);
                clickedCnt++;
            }
        }
        else if(transform.parent.CompareTag("Enemy")){
            clickedCnt += Mathf.CeilToInt(Random.Range(-0.5f,1.0f));       
        }
        else {
            // 何もしない
        }



        //スプライト変更、最後のスプライトになったとき破棄する
        if(spriteRenderer.sprite != sprites.Last()) {

            spriteRenderer.sprite = sprites[clickedCnt / 2 % sprites.Length];
        }
        else {

            Vector3 cameraPos = Camera.main.gameObject.transform.position;
            AudioSource.PlayClipAtPoint(brokenSE, cameraPos - Vector3.back*5f);
            Destroy(this.gameObject);
        }

    }
    public void OnTriggerStayRacer(Racer racer)
    {
        
        racer.AddForce(1000, Vector2.one);
       
    }


}
