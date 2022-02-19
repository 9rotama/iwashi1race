using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundScroll : MonoBehaviour
{
    [SerializeField] private float speed = 1.0f;
    
    private GameObject player;
    private PlayerControl playerControl;
    
    private Rigidbody2D rb2D;
    private Material material;

    private Vector2 offset;
    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        playerControl = player.GetComponent<PlayerControl>();
        material = GetComponent<Image>().material;
        offset = new Vector2(0, 0);
    }

    void Update()
    {
        offset = new Vector2(offset.x + playerControl.GetVelocityVec2().x * (speed * 0.000005f), offset.y + playerControl.GetVelocityVec2().y * (speed * 0.000001f));

        material.mainTextureOffset = offset;
    }
}
