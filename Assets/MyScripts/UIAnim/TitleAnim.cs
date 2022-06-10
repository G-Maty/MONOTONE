using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TitleAnim : MonoBehaviour
{
    [SerializeField] private Transform titletransform;
    // Start is called before the first frame update
    void Start()
    {
        titletransform.DOScale(Vector3.zero, 3f)
             .SetEase(Ease.OutBounce)
             .SetLoops(-1,LoopType.Yoyo)
             .Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
