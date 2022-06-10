using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class StrongButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        StartStrongButtonAnim();
    }

    void StartStrongButtonAnim()
    {
        transform.DOScale(0.2f, 1f)
        .SetRelative(true)
        .SetEase(Ease.OutQuart)
        .SetLoops(-1, LoopType.Restart);
    }
}
