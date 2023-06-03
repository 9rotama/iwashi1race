using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageBackgroundScroll : MonoBehaviour
{
    [SerializeField] private float xSpeed = 1.0f;
    [SerializeField] private float ySpeed = 1.0f;
    
    private PlayerControl _playerControl;
    private Material _material;
    private Vector2 _offset;

    private void Start()
    {
        var player = GameObject.FindGameObjectWithTag("Player");
        _playerControl = player.GetComponent<PlayerControl>();
        _material = GetComponent<Image>().material;
        _offset = new Vector2(0, 0);
    }

    private void Update()
    {
        _offset = new Vector2(_offset.x + _playerControl.GetVelocityVec2().x * (xSpeed * Time.deltaTime * 16 * 0.00001f),
            _offset.y + _playerControl.GetVelocityVec2().y * (ySpeed * Time.deltaTime * 16 * 0.000001f));

        _material.mainTextureOffset = _offset;
    }
}
