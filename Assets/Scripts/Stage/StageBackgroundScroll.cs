using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageBackgroundScroll : MonoBehaviour
{
    [SerializeField] private float xSpeed;
    [SerializeField] private float ySpeed;
    
    private const float XReducer = 0.0001f;
    private const float YReducer = 0.00002f;
    
    private PlayerController _playerControl;
    private Material _material;
    private Vector2 _offset;

    private void Start()
    {
        var player = GameObject.FindGameObjectWithTag("Player");
        _playerControl = player.GetComponent<PlayerController>();
        _material = GetComponent<Image>().material;
        _offset = new Vector2(0, 0);
    }

    private void Update()
    {
        var x = _offset.x + _playerControl.GetVelocityVec2().x * (xSpeed * XReducer * Time.deltaTime );
        var y = _offset.y + _playerControl.GetVelocityVec2().y * (ySpeed * YReducer * Time.deltaTime);
        _offset = new Vector2(x,y);

        _material.mainTextureOffset = _offset;
    }
}
