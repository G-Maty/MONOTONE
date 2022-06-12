using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class TitleAnim2 : MonoBehaviour
{
    [SerializeField] private Image image;

    // Start is called before the first frame update
    void Start()
    {
        image.DOFade(endValue: 0f, duration: 3f)
            .SetEase(Ease.InQuart)
            .SetLoops(-1,LoopType.Yoyo)
            .SetLink(gameObject)
            .Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
