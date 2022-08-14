using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MoveVertical : MonoBehaviour
{
    [SerializeField]
    private float distance = 0f;
    [SerializeField]
    private float Time = 1f;
    [SerializeField]
    private int LoopTimes = -1;

    // Start is called before the first frame update
    void Start()
    {
        transform.DOMoveY(distance, Time).SetRelative(true).SetEase(Ease.InOutQuad).SetLoops(LoopTimes, LoopType.Yoyo)
            .SetLink(gameObject).Play();
    }
}
