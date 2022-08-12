using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MoveHorizontal : MonoBehaviour
{
    [SerializeField]
    private float distance = -5f;
    [SerializeField]
    private float LoopTime = 1f;

    // Start is called before the first frame update
    void Start()
    {
        transform.DOMoveX(distance, LoopTime).SetEase(Ease.InOutQuad).SetLoops(-1,LoopType.Yoyo)
            .SetLink(gameObject).Play();
    }

}
