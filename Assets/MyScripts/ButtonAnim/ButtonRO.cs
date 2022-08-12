using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening; //DOTween
using TMPro; //TMP
using UnityEngine.EventSystems; //イベントシステム
using UnityEngine.UI; //UI

public class ButtonRO : UIBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private Image FillImage;
    [SerializeField] private TextMeshProUGUI TMP;
    [SerializeField] private Color RollOverTextColor;
    private Color BaseTextColor;
    [SerializeField]
    private AudioClip clickSE;
    private AudioSource audioSource;

    // Start is called before the first frame update
    protected override void Start() //継承元の関数にオーバーライド
    {
        base.Start(); //for override
        FillImage.fillAmount = 0;
        BaseTextColor = TMP.color;

        Button button = GetComponent<Button>();
        button.onClick.AddListener(Onclick);

        audioSource = GetComponent<AudioSource>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        FillImage.DOFillAmount(endValue: 1f, duration: 0.25f).SetEase(Ease.OutCubic).SetLink(gameObject).Play();
        TMP.DOColor(endValue: RollOverTextColor ,duration: 0.25f).SetLink(gameObject).Play();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        FillImage.DOFillAmount(endValue: 0f,duration: 0.25f).SetEase(Ease.OutCubic).SetLink(gameObject).Play();
        TMP.DOColor(endValue: BaseTextColor,duration: 0.25f).SetLink(gameObject).Play();
    }

    public void Onclick()
    {
        audioSource.PlayOneShot(clickSE);
        transform.DOScale(1.1f, 0.5f).SetEase(Ease.OutElastic);
    }
}
