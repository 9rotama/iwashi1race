using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// レーサーを一定時間スタンさせるサンダーのクラス
/// </summary>
public class Thunder : MonoBehaviour, IPhysicalDamageable
{
    [SerializeField] private float baseStanTime = 2.5f;
    [SerializeField] private int lostMagicOrbNum = 10;
    private Racer _target;
    

    public void Initialize(Racer racer, int racerRank, float timeUntilStrike) 
    {
        _target = racer;
        transform.SetParent(racer.transform);

        float stanTime = baseStanTime / Mathf.Sqrt(racerRank);

        StartCoroutine(TryStrikeThunder(timeUntilStrike, stanTime));
    }

    /// <summary>
    /// レーサーに落雷のダメージを与えようとする
    /// </summary>
    /// <param name="timeUntilStrike">落雷までの時間</param>
    /// <param name="stanTime">レーサーがとどまる時間</param>
    private IEnumerator TryStrikeThunder(float timeUntilStrike, float stanTime) 
    {
        // 落雷までの時間が経ったら、レーサーにダメージを与えられるか確認する
        yield return new WaitForSeconds(timeUntilStrike);

        if(!IPhysicalDamageable.IsPhysicalDamageable(_target)) {
            Destroy(gameObject);
            yield break;
        }

        _target.StopperEnter(stanTime, lostMagicOrbNum);

        // 雷に打たれたレーサー子プレハブをアクティブにして、レーサーの前でスタン時間中描画する
        transform.GetChild(0).gameObject.SetActive(true);

        yield return new WaitForSeconds(stanTime);

        Destroy(gameObject);
    }


}
