using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening; //DOTween
using UnityEngine.EventSystems; //UI

public class ButtonAnim2 : UIBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    /*キャンバスグループを使う理由
     * 親と子要素どちらも一緒に処理してくれるから
     */
    [SerializeField] private CanvasGroup CanvasGroup;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        CanvasGroup.alpha = 1f;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        CanvasGroup.DOFade(endValue:0.5f, 0.25f).SetLink(gameObject).Play();
        /*
         * SetLink
         * ゲームオブジェクトが破棄されたときに、Tweenも一緒に破棄してくれる
         * そのままだとエラーが出ることがある
         */
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        CanvasGroup.DOFade(endValue:1f, 0.25f).SetLink(gameObject).Play();
    }
}
