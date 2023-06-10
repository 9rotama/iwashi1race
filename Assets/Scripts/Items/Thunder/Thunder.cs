using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// レーサーを一定時間スタンさせるサンダーのクラス
/// </summary>
[RequireComponent(typeof(ThunderDraw))]
public class Thunder : MonoBehaviour, IPhysicalDamageable
{

    [SerializeField] private AudioSource audioSource;

    private Racer _target;

    // 雷が落ちるまでの時間
    [SerializeField] private float requiredStrikeTime = 10;

    private float _strikeTimer = 0;

    // 雲が完全に見えるまでの時間
    [SerializeField] private float requiredCloudTime = 10;

    private float _cloudTimer = 0;

    // 雷に打たれたときにスタンする時間
    private float _stanTime;

    public void Initialize(Racer racer) {
        _target = racer;
        transform.SetParent(racer.transform);
        _stanTime = 2.5f / Mathf.Sqrt(RankManager.Instance.GetRank(racer.id));
        StartCoroutine(StrikeThunder());
    }


    private void Update() {
        _cloudTimer += Time.deltaTime;

        if(GetCloudTimeRatio() < 1) return;

        _strikeTimer += Time.deltaTime;
        
    }


    IEnumerator StrikeThunder() {
        yield return new WaitUntil(() => GetStrikeTimeRatio() > 1);

        if(!IPhysicalDamageable.IsPhysicalDamageable(_target)) {
            Destroy(gameObject);
            yield break;
        }

        _target.StopperEnter(_stanTime, 10);

        // 雷に打たれたレーサー子プレハブをアクティブにして、レーサーの前で描画する
        transform.GetChild(0).gameObject.SetActive(true);

        yield return new WaitForSeconds(_stanTime);

        Destroy(gameObject);
    }

    public float GetStrikeTimeRatio() {
        return _strikeTimer / requiredStrikeTime;
    }

    public float GetCloudTimeRatio() {
        return _cloudTimer / requiredCloudTime;
    }

}
