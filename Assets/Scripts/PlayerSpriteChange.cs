using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpriteChange : MonoBehaviour
{
    [Range(0, 1.0f)] public float hue;
    private SpriteRenderer spriteRenderer;
    public Sprite spriteSpeed0;
    public Sprite spriteSpeed1;
    public Sprite spriteSpeed2;

    private Vector3 prevPosition;
    private Vector2 velocityVec2;

    private GameObject parentObj;
    private PlayerControl playerControl;
    private CPUplayerControl cpuPlayerControl;

    
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.material.SetFloat("_Hue", hue);
        parentObj = transform.parent.gameObject;

        if (parentObj.tag == "Player")
        {
            playerControl = parentObj.GetComponent<PlayerControl>();
            StartCoroutine ("ChangeByPlayerSpeed");
        }
        else if(parentObj.tag == "Enemy")
        {
            cpuPlayerControl = parentObj.GetComponent<CPUplayerControl>();
            StartCoroutine ("ChangeByCPUSpeed");
        }

        
    }

    void Update()
    {
        
    }

    IEnumerator ChangeByPlayerSpeed()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            var velocity = playerControl.GetVelocity();
            if(velocity >= 0 && velocity < 100f)
            {
                spriteRenderer.sprite = spriteSpeed0;
            }
            else if (velocity >= 100f && velocity < 200f)
            {
                spriteRenderer.sprite = spriteSpeed1;
            }
            else
            {
                spriteRenderer.sprite = spriteSpeed2;
            }
        }
    }
    
    IEnumerator ChangeByCPUSpeed()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            var velocity = cpuPlayerControl.GetVelocity();
            if(velocity >= 0 && velocity < 100f)
            {
                spriteRenderer.sprite = spriteSpeed0;
            }
            else if (velocity >= 100f && velocity < 200f)
            {
                spriteRenderer.sprite = spriteSpeed1;
            }
            else
            {
                spriteRenderer.sprite = spriteSpeed2;
            }
        }
    }
}
