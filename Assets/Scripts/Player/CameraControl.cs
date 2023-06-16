using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class CameraControl : MonoBehaviour
{
    [SerializeField] private float xOffset = 0f;    //画面内のプレイヤーの水平位置
    
    private Vector3 _newPos;
    private GameObject _player;

    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag(Tag.Player);
        this.transform.rotation = Quaternion.Euler(0, 0, 0);
    }

    private void Update()
    {
        var playerPos = _player.transform.position;
        _newPos = new Vector3(playerPos.x + xOffset, playerPos.y, playerPos.z - 10);
        this.transform.position = _newPos;
    }
}
