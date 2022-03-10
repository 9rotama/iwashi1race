using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageBackgroundScroll : MonoBehaviour
{
    [SerializeField] private float xSpeed = 1.0f;
    [SerializeField] private float ySpeed = 1.0f;
    
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
        offset = new Vector2(offset.x + playerControl.GetVelocityVec2().x * (xSpeed * 0.000005f), offset.y + playerControl.GetVelocityVec2().y * (ySpeed * 0.000001f));

        material.mainTextureOffset = offset;
    }
}
