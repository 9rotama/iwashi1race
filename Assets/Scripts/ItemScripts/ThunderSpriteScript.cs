using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThunderSpriteScript : MonoBehaviour
{
    SpriteRenderer MainSpriteRenderer;
    [SerializeField] Sprite[] sprites;
    [SerializeField] GameObject[] shockPlayer;
    SpriteRenderer render;
    public GameObject targetObj;
    [SerializeField] GameObject bullet;
    int spriteNum = 0;
    bool once = false;
    bool isShocked = false;
    float time;
    public int rank;

    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        render = gameObject.GetComponent<SpriteRenderer>();
        render.color -= new Color(0, 0, 0, 1);
        MainSpriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        targetObj = transform.parent.gameObject;
        transform.parent = null;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        time += Time.deltaTime;
        transform.position = new Vector3(targetObj.transform.position.x, targetObj.transform.position.y + 25f, 0);
        render.color += new Color(0,0,0,0.01f);
        if(render.color.a >= 1f && !once){
            for(int i=0; i< sprites.Length; i++){
                Invoke("ChangeSprite",0.05f*i);
            }
            once = true;
        }
        if(isShocked){
            StopPlayer();
            float shockedTime;
            switch(rank){
                case 1: shockedTime = 6f; break;
                case 2: shockedTime = 5.5f; break;
                case 3: shockedTime = 5f; break;
                case 4: shockedTime = 4.5f; break;
                case 5: shockedTime = 4f; break;
                case 6: shockedTime = 3.5f; break;
                case 7: shockedTime = 3f; break;
                case 8: shockedTime = 2.5f; break;
                default: shockedTime = 2f; break;
            }
            if(time > shockedTime){
                Destroy(this.gameObject);
            }
        }
    }

    void ChangeSprite()
    {
        MainSpriteRenderer.sprite = sprites[spriteNum++];
        if(spriteNum == sprites.Length){
            CreateBullet();
        }
    }

    void CreateBullet()
    {
        GameObject itemCon = targetObj.transform.Find("ItemController").gameObject;
        ItemControlScript itemScript = itemCon.GetComponent<ItemControlScript>();
         
        if(itemScript.isDefence){
            Destroy(itemCon.transform.GetChild(0).gameObject);
            itemScript.isDefence = false;
            Destroy(this.gameObject);
        } 
        else{
            if(targetObj.tag == "Player") { audioSource.Play();}
            isShocked = true;
            CreateShockPlayer();
        }
    }

    public void CreateShockPlayer()
    {  
        for(int i=0; i<shockPlayer.Length; i++){
            GameObject obj = (GameObject)Instantiate(
                shockPlayer[i], 
                targetObj.transform.position,  
                Quaternion.identity
            );
            if(i==2){
                obj.transform.position -= Vector3.left*1.35f;
            }
            obj.transform.parent = gameObject.transform;
        }



    }

    void StopPlayer()
    {
        Rigidbody2D rb = targetObj.GetComponent<Rigidbody2D>();
        const float targetVelocity = 0;
        const float power =  30;
        rb.AddForce(Vector3.right * ((targetVelocity - rb.velocity.x) * power), ForceMode2D.Force);
        rb.AddForce(Vector3.up * ((targetVelocity - rb.velocity.y) * power), ForceMode2D.Force);
    }

}
