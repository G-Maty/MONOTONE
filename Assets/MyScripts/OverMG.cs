using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

/*
 * ゲームオーバー処理
 * GameOverZoneオブジェクトにアタッチ
 */

public class OverMG : MonoBehaviour
{
    [SerializeField] private GameObject overzone;
    [SerializeField] private Image overUI;
    private GameMG gamemg;

    // Start is called before the first frame update
    void Start()
    {
        gamemg = GameObject.Find("GameManager").GetComponent<GameMG>();
        overUI.color = new Color(255f,255f,255f,0f);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        overUI.DOFade(1f, 0.5f).SetEase(Ease.Linear).SetLink(gameObject).Play();
        //Destroy(collision.gameObject);
        gamemg.RetryStage();
    }
}
