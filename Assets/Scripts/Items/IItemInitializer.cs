/// <summary>
/// アイテムクリエーター経由で初期化するアイテムにつけるインターフェース
/// </summary>
public interface IItemInitializer {
    
    /// <summary>
    /// アイテムの初期化
    /// </summary>
    public abstract void ItemInitialize(Racer racer);
}
