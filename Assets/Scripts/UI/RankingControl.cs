using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RankingControl : MonoBehaviour
{
    [SerializeField] private Sprite[] rankSprites;
    [SerializeField] private Sprite[] suffixSprites;
    
    private Image _rankImageUI;
    private Image _suffixImageUI;
    private GameObject _player;
    private GameObject[] _cpuPlayer;
    private int _ranking;
    
    public int GetRanking()
    {
        return _ranking;
    }

    void Awake()
    {
        _rankImageUI = this.GetComponent<Image>();
        _suffixImageUI = this.transform.GetChild(0).GetComponent<Image>();

        _player = GameObject.FindGameObjectWithTag("Player");
        _cpuPlayer = GameObject.FindGameObjectsWithTag("Enemy");
    }
    
    void Update()
    {
        _ranking = 1;
        foreach (var t in _cpuPlayer)
        {
            if (_player.transform.position.x < t.transform.position.x)
            {
                _ranking++;
            }
        }

        if (_ranking <= 8)
        {
            _rankImageUI.sprite = rankSprites[_ranking - 1];
        }

        if (_ranking <= 3)
        {
            _suffixImageUI.sprite = suffixSprites[_ranking - 1];
        }
        else
        {
            _suffixImageUI.sprite = suffixSprites[3];
        }

        

        
    }
}
