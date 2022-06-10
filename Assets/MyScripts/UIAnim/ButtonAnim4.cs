using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening; //DOTween
using TMPro; //TMP
using UnityEngine.EventSystems; //イベントシステム
using UnityEngine.UI; //UI

public class ButtonAnim4 : UIBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private Image FillImage;
    [SerializeField] private TextMeshProUGUI TMP;
    [SerializeField] private Color RollOverTextColor;
    private Color BaseTextColor;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        //sizeDeltaはRectTransformの幅と高さのこと
        FillImage.rectTransform.sizeDelta = Vector2.zero;
        BaseTextColor = TMP.color;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        FillImage.rectTransform.DOSizeDelta(Vector2.one * 400f, 0.25f)
            .SetEase(Ease.OutCubic)
            .SetLink(gameObject)
            .Play();
        TMP.DOColor(RollOverTextColor, 0.25f)
            .SetLink(gameObject)
            .Play();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        FillImage.rectTransform.DOSizeDelta(Vector2.zero, 0.25f)
            .SetEase(Ease.OutCubic)
            .SetLink(gameObject)
            .Play();
        TMP.DOColor(BaseTextColor, 0.25f)
            .SetLink(gameObject)
            .Play();
    }
}
