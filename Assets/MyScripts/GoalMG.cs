using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class GoalMG : MonoBehaviour
{
    [SerializeField] private GameObject goal;
    [SerializeField] private Image clearUI;
    [SerializeField] private GameObject player;
    private GameMG gamemg;

    // Start is called before the first frame update
    void Start()
    {
        //ロードされる前はGameManagerが存在しないためアウトレット接続不可能
        gamemg = GameObject.Find("GameManager").GetComponent<GameMG>();
        goal.transform.DOScale(0f, 1.7f).SetLoops(-1).SetLink(gameObject).Play();
        clearUI.fillAmount = 0;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        clearUI.DOFillAmount(1f, 1f).SetEase(Ease.InOutCubic).SetLink(gameObject).SetDelay(1f).Play();
        player.transform.DOScale(0f, 1f).SetEase(Ease.InBack,6f).SetLink(gameObject).Play();
        Destroy(player,2f);
        gamemg.NextStage();
    }
}
