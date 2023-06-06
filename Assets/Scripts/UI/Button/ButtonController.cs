using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

/// <Summary>
/// UI中のボタンの見た目変更、押下音再生を操作するクラス
/// すべてのボタンに共通でアタッチされる
/// </Summary>
[RequireComponent(typeof(Image))]
[RequireComponent(typeof(Button))]
[RequireComponent(typeof(AudioSource))]
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
    private Image _img;
    private Button _btn;
    private AudioSource _pressedSound;
    
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
        _pressedSound.Play();
    }

    private void Start()
    {
        _img = GetComponent<Image>();
        _img.sprite = mouseExitSprite;
        
        _pressedSound = GetComponent<AudioSource>();

        _btn = GetComponent<Button>();
        _btn.onClick.AddListener(PlayPressedSound);

    }
}
