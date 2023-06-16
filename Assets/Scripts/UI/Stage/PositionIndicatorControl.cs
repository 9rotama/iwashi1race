using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionIndicatorControl : MonoBehaviour
{
    private GameObject _player,_start,_goal;

    private const int LineSize = 82;

    // Start is called before the first frame update
    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag(Tag.Player);
        _start = GameObject.FindGameObjectWithTag(Tag.Start);
        _goal = GameObject.FindGameObjectWithTag(Tag.Goal);
    }

    // Update is called once per frame
    private void Update()
    {
        var playerPos = _player.transform.position.x;
        var startPos = _start.transform.position.x;
        var goalPos = _goal.transform.position.x;

        
        var stageDis = goalPos - startPos;
        var playerMoveDis = playerPos - startPos;
        var moveRate = playerMoveDis / stageDis;

        transform.localPosition = new Vector3(moveRate * LineSize - (LineSize / 2.0f), transform.localPosition.y,
            transform.localPosition.z);
    }
}
