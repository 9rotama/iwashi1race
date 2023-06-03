using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// レース中のプレイヤーの順位表示の画像を操作するクラス
/// </summary>
public class RankingControl : MonoBehaviour
{
    [SerializeField] private Sprite[] rankSprites;
    [SerializeField] private Sprite[] suffixSprites; //"〇〇th", "〇〇st"...
    
    private Image _rankImageUI;
    private Image _suffixImageUI;
    private GameObject _player;
    private GameObject[] _cpuPlayer;


    private void Awake()
    {
        _rankImageUI = this.GetComponent<Image>();
        _suffixImageUI = this.transform.GetChild(0).GetComponent<Image>();

        _player = GameObject.FindGameObjectWithTag("Player");
        _cpuPlayer = GameObject.FindGameObjectsWithTag("Enemy");
    }

    private void Update()
    {
        var rank = RankManager.Instance.GetRank(0);
        
        if (rank <= 8)
        {
            _rankImageUI.sprite = rankSprites[rank - 1];
        }
 

        if (rank <= 3)
        {
            _suffixImageUI.sprite = suffixSprites[rank - 1];
        }
        else
        {
            _suffixImageUI.sprite = suffixSprites[3];
        }
    }
}
