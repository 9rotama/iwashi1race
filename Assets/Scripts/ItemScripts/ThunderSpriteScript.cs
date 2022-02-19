using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThunderSpriteScript : MonoBehaviour
{
    SpriteRenderer MainSpriteRenderer;
    [SerializeField] Sprite[] sprites;
    [SerializeField] GameObject[] shockPlayer;
    SpriteRenderer renderer;
    public GameObject targetObj;
    [SerializeField] GameObject bullet;
    int spriteNum = 0;
    bool once = false;

    // Start is called before the first frame update
    void Start()
    {
        renderer = gameObject.GetComponent<SpriteRenderer>();
        renderer.color -= new Color(0, 0, 0, 1);
        MainSpriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        targetObj = transform.parent.gameObject;
        transform.parent = null;
        // for(int i=0; i< sprites.Length; i++){
        //     Invoke("SpriteChange",0.1f*i);
        // }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = new Vector3(targetObj.transform.position.x, targetObj.transform.position.y + 25f, 0);
        renderer.color += new Color(0,0,0,0.01f);
        if(renderer.color.a >= 1f && !once){
            for(int i=0; i< sprites.Length; i++){
                Invoke("ChangeSprite",0.05f*i);
            }
            once = true;
        }
        //ChangePlayerSprite();
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
        GameObject obj = (GameObject)Instantiate(
            bullet, 
            targetObj.transform.position,  
            Quaternion.identity
        );
        obj.transform.parent = gameObject.transform;
    }

    public void CreateShockPlayer()
    {  
        for(int i=0; i<shockPlayer.Length; i++){
            GameObject obj = (GameObject)Instantiate(
                shockPlayer[i], 
                targetObj.transform.position,  
                Quaternion.identity
            );
            obj.transform.parent = gameObject.transform;
        }

    }

}
