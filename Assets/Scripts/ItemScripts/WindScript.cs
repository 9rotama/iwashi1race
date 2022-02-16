using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 


public class WindScript : MonoBehaviour
{
    Rigidbody2D parentRb;
    float time;
    [SerializeField] float maxV = 10f;
    [SerializeField] float addSp = 10f;
    [SerializeField] float addForceTime = 2.0f;

    [SerializeField] Sprite[] windImage;
    [SerializeField] Image image;
    [SerializeField] float[] imageSp = new float[2];
    
    
    // Start is called before the first frame update
    void Start()
    {
       parentRb = transform.parent.GetComponent<Rigidbody2D>();
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
            image.sprite = windImage[0];
        }
        else if(imageSp[1] > parentRb.velocity.x){
            image.sprite = windImage[1];
        }
        else {
            image.sprite = windImage[2];
        }
    }


}
