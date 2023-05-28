using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WindScript : CollisionStayObject, IItemInitializer
{
    float time;
    [SerializeField] float addSp;
    [SerializeField] float addForceTime;
    [SerializeField] Sprite[] windImage;
    [SerializeField] SpriteRenderer spriteRenderer;
    
    [SerializeField] float[] imageSp = new float[2];

    public void ItemInitializeOfPlayer(int id, Vector3 birtherPos, GameObject racer) {
        transform.SetParent(racer.transform);
        transform.position += new Vector3(-1.3f, 0.3f, 0);
        transform.rotation = transform.parent.rotation;
        Destroy(gameObject, addForceTime);
    }

    public void ItemInitializeOfCPUPlayer(int id, Vector3 birtherPos, GameObject racer) {
        transform.SetParent(racer.transform);
        transform.position += new Vector3(-1.3f, 0.3f, 0);
        transform.rotation = transform.parent.rotation;
        Destroy(gameObject, addForceTime);
    }

    public override void OnTriggerStayCPUPlayer(GameObject cpuPlayer)
    {
        var cpuPlayerControl = cpuPlayer.GetComponent<CPUplayerControl>();
        cpuPlayerControl.WindStay(addSp);
        ImageSwitch(cpuPlayerControl.GetVelocity());
    }

    public override void OnTriggerStayPlayer(GameObject player)
    {
        var cpuPlayerControl = player.GetComponent<CPUplayerControl>();
        cpuPlayerControl.WindStay(addSp);
        ImageSwitch(cpuPlayerControl.GetVelocity());
    }

    void ImageSwitch(float velocityX)
    {
        //速度に応じて画像の切り替え
        if(imageSp[0] > velocityX){
            spriteRenderer.sprite = windImage[0];
        }
        else if(imageSp[1] > velocityX){
            spriteRenderer.sprite = windImage[1];
        }
        else {
            spriteRenderer.sprite = windImage[2];
        }
    }


}
