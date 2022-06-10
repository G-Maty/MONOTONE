using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class TitleAnim3 : MonoBehaviour
{
    [SerializeField] private Image image;

    // Start is called before the first frame update
    void Start()
    {
        image.DOFillAmount(endValue: 0f, duration: 1f)
            .SetEase(Ease.InQuad)
            .SetLoops(-1,LoopType.Yoyo)
            .Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
