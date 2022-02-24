using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    [SerializeField] private GameObject Player;
    [SerializeField] private float speed = 10.0f;
    [SerializeField] private float xOffset = 0f;
    private Vector3 setPos;
    
    void Start()
    {
        this.transform.rotation = Quaternion.Euler(0, 0, 0);
    }

    void Update()
    {
        setPos = new Vector3(Player.transform.position.x + xOffset, Player.transform.position.y,
            Player.transform.position.z - 10);
        this.transform.position = Vector3.Slerp(this.transform.position, setPos, Time.deltaTime * speed);
    }
}
