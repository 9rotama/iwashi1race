using System.Collections;
using System.Collections.Generic;
using KanKikuchi.AudioManager;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// アイテムUIの表示を管理するクラス
/// </summary>
public class ItemRandomDisplay : MonoBehaviour
{
    [SerializeField] private Sprite[] itemSprites;
    [SerializeField] private Image image;
    [SerializeField] private Sprite nothing;

    // アイテムをゲットした時に流れるSEの音が鳴り終わる時間
    private const float AudioItemOrbLength = 2.4f;

    // アイテムのスプライトを変化させる回数
    private const int ChangeSpriteNum = 25;

    // アイテムのスプライトを変化させた回数を保持するカウンター
    private int change_sprite_cnt = 0;

    public Items playerHavingItem;

    public bool isItemUsable { get; private set;}

    private void OnEnable()
    {
        SEManager.Instance.Play(SEPath.ITEM_ORB);

        isItemUsable = false;

        //アイテムのUIを切り替える
        for(int i=0; i<ChangeSpriteNum; i++){
            float change_time = AudioItemOrbLength / ChangeSpriteNum * i;

            if(i == ChangeSpriteNum-1){
                Invoke(nameof(SetPlayerHavingItemSprite), change_time);
            }
            else{
                Invoke(nameof(ChangeSprite), change_time);
            }
        }
    }
    
    private void OnDisable() 
    {
        image.sprite = nothing;
    }

    /// <summary>
    /// アイテムのスプライト順番にを変化させる
    /// </summary>
    private void ChangeSprite()
    {
        image.sprite = itemSprites[change_sprite_cnt++ % itemSprites.Length];
    }

    /// <summary>
    /// アイテムのスプライトをプレイヤーが保持しているものにする
    /// </summary>
    private void SetPlayerHavingItemSprite()
    {
        image.sprite = itemSprites[(int)playerHavingItem];
        isItemUsable = true;
    }
}
