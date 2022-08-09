using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

/*
 * 文字アニメーション処理
 * 各テキストにアタッチ
 */

public class TexitAnim : MonoBehaviour
{
    //無料版でTMP用の拡張メソッドが使えない
    [SerializeField] private　Text TutText1;
    
    private void Start()
    {
        var sequence = DOTween.Sequence();

        string newText = TutText1.text; //初期に入っているテキストを変数textに格納
        TutText1.text = ""; //一旦空白に
        sequence.Append(TutText1.DOText(newText, 1.5f).SetEase(Ease.Linear).SetDelay(1f));
        sequence.Append(TutText1.DOFade(endValue: 0f, duration: 0.5f).SetDelay(2f));

        sequence.SetLoops(-1).SetLink(gameObject).Play();

    }
}
