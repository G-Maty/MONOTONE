using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening; //DOTween
using TMPro; //TMP
using UnityEngine.EventSystems; //イベントシステム
using UnityEngine.UI; //UI

public class ButtonAnim3 : UIBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private Image FillImage;
    [SerializeField] private TextMeshProUGUI TMP;
    [SerializeField] private Color RollOverTextColor;
    private Color BaseTextColor;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        FillImage.fillAmount = 0;
        BaseTextColor = TMP.color;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        FillImage.DOFillAmount(endValue: 1f, duration: 0.25f).SetEase(Ease.OutCubic).SetLink(gameObject).Play();
        TMP.DOColor(endValue: RollOverTextColor,duration: 0.25f).SetLink(gameObject).Play();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        FillImage.DOFillAmount(endValue: 0f,duration: 0.25f).SetEase(Ease.OutCubic).SetLink(gameObject).Play();
        TMP.DOColor(endValue: BaseTextColor,duration: 0.25f).SetLink(gameObject).Play();
    }
}
