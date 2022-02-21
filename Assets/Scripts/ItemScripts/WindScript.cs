using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WindScript : MonoBehaviour
{
    Rigidbody2D parentRb;
    float time;
    [SerializeField] float maxV;
    [SerializeField] float addSp;
    [SerializeField] float addForceTime;

    [SerializeField] Sprite[] windImage;
    SpriteRenderer MainSpriteRenderer;
    
    [SerializeField] float[] imageSp = new float[2];
    
    
    // Start is called before the first frame update
    void Start()
    {
       parentRb = transform.parent.GetComponent<Rigidbody2D>();
       MainSpriteRenderer = gameObject.GetComponent<SpriteRenderer>();
       transform.position += new Vector3(-1.3f, 0.3f, 0);
       transform.rotation = transform.parent.rotation;
       time = 0;
       ImageSwitch();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //時間内かつmaxV以下の速度のとき力を加える
        time += Time.deltaTime;

        if(time >= addForceTime) {
            Destroy(this.gameObject);
        }
        else if(parentRb.velocity.x < maxV){
            parentRb.AddForce(transform.right * addSp, ForceMode2D.Impulse);
        }

        ImageSwitch();
        
    }

    void ImageSwitch()
    {
        //速度に応じて画像の切り替え
        if(imageSp[0] > parentRb.velocity.x){
            MainSpriteRenderer.sprite = windImage[0];
        }
        else if(imageSp[1] > parentRb.velocity.x){
            MainSpriteRenderer.sprite = windImage[1];
        }
        else {
            MainSpriteRenderer.sprite = windImage[2];
        }
    }


}
