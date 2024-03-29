using KanKikuchi.AudioManager;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

/// <Summary>
/// UI中のボタンの見た目変更、押下音再生を操作するクラス
/// すべてのボタンに共通でアタッチされる
/// </Summary>
[RequireComponent(typeof(Image))]
[RequireComponent(typeof(Button))]
public class ButtonController : 
    MonoBehaviour, 
    IPointerExitHandler, 
    IPointerEnterHandler, 
    IPointerDownHandler, 
    IPointerUpHandler
{
    [SerializeField] private Sprite mouseExitSprite;
    [SerializeField] private Sprite mouseEnterSprite;
    [SerializeField] private Sprite mouseDownSprite;
    [SerializeField] private ButtonSound pressedSound;
    private Image _img;
    private Button _btn;
    
    public void OnPointerDown(PointerEventData data)
    {
        _img.sprite = mouseDownSprite;
    }

    public void OnPointerEnter(PointerEventData data)
    {
        _img.sprite = mouseEnterSprite;
    }

    public void OnPointerExit(PointerEventData data)
    {
        _img.sprite = mouseExitSprite;
    }
    
    public void OnPointerUp(PointerEventData data)
    {
        _img.sprite = mouseExitSprite;
    }

    private void PlayPressedSound()
    {
        switch (pressedSound)
        {
            case ButtonSound.Normal:
                SEManager.Instance.Play(SEPath.SELECT);
                break;
            case ButtonSound.Return:
                SEManager.Instance.Play(SEPath.BACK);
                break;
            default:
                break;
        }
    }

    private void Start()
    {
        _img = GetComponent<Image>();
        _img.sprite = mouseExitSprite;
        
        _btn = GetComponent<Button>();
        _btn.onClick.AddListener(PlayPressedSound);

    }
}
