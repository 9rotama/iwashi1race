/// <summary>
/// レーサーに物理ダメージを与えるクラスが持つインターフェース
/// </summary>
public interface IPhysicalDamageable {

    /// <summary>
    /// レーサーに物理ダメージを与えられるかをbool値で返す
    /// </summary>
    /// <param name="birtherId">オブジェクトを生んだ親レーサーID</param>
    /// <returns>ダメージを与えられるなら真、与えられないなら偽</returns>
    protected static bool IsPhysicalDamageable(Racer racer)
    {   

        // レーサー停止が停止状態か
        if(racer.isStopped) {
            return false;
        }

        // レーサーが無敵状態か
        if(racer.isInvincible) {
            racer.isInvincible = false;
            return false;
        }

        return true;
    }
}
