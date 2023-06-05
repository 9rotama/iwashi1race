using System.Collections;
using UnityEngine;
/// <summary>
/// マジックオーブのPrefab(大小関係なし)を渡されそれを生成するクラス
/// Spawner一個につき一個生成し回収されたら再度生成
/// </summary>
public class OrbSpawner : MonoBehaviour
{
    [SerializeField] private GameObject prefabOrb;
    [SerializeField] private float spawnSpan = 5.0f;

    /// <summary>
    /// 生成したオーブが回収されたら実行
    /// </summary>
    public void OrbDestroyed()
    {
        StartCoroutine (nameof(OrbSpawn));
    }

    /// <summary>
    /// 指定時間待ちオーブを生成
    /// </summary>
    /// <returns></returns>
    private IEnumerator OrbSpawn()
    {
        yield return new WaitForSeconds (spawnSpan);
        var childObj = Instantiate(prefabOrb, this.transform.position , Quaternion.identity);
        childObj.transform.parent = this.transform;
    }

    private void Start()
    {
        //最初にオーブ生成
        var transform1 = transform;
        Instantiate(prefabOrb, transform1.position, Quaternion.identity, transform1);
    }
    
}
