using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BackgroundAnim : MonoBehaviour
{
    [SerializeField]
    private float distance = -7f;
    [SerializeField]
    private float Time = 10f;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, 15f); //âΩåÃÇ©è¡Ç¶Ç»Ç¢
        transform.DOMoveY(distance, Time).SetEase(Ease.InOutQuad).SetLink(gameObject).Play();
    }
}
