using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening; //DOTween
using UnityEngine.EventSystems; //UI

public class ButtonAnim1 : UIBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private float Rate; 
    private Vector3 BaseScale;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        BaseScale = transform.localScale;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        transform.DOScale(endValue: BaseScale * Rate, 0.25f).SetEase(Ease.OutBounce).Play();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        transform.DOScale(BaseScale, 0.25f).SetEase(Ease.OutBounce).Play();
    }
}
