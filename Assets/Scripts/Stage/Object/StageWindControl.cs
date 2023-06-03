using UnityEngine;

/// <summary>
/// プレイヤーと追い風の接触した際の処理を担当するクラス
/// </summary>
public class StageWindControl : MonoBehaviour, IRacerCollisionStayer
{
    [SerializeField] private float strength = 20f;

    /// <summary>
    /// レーサーが風内にいるときレーサー側の風の力を加える関数を実行する
    /// </summary>
    /// <param name="racer">レーサーのクラス</param>
    public void OnTriggerStayRacer(Racer racer)
    {
        racer.AddForce(strength, Vector3.right);
    }

}
