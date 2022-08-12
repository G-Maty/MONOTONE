using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class Setting : MonoBehaviour
{
    [SerializeField]
    private GameObject window;
    private GameMG gamemg;

    // Start is called before the first frame update
    void Start()
    {
        window.transform.localScale = new Vector3(0f,0f,0f);
        gamemg = GameObject.Find("GameManager").GetComponent<GameMG>();
    }

    public void OpenWindow()
    {
        window.transform.DOScale(1f, 0.2f).SetEase(Ease.Linear).SetLink(gameObject).Play();
    }

    public void CloseWindow()
    {
        window.transform.DOScale(0f, 0.2f).SetEase(Ease.Linear).SetLink(gameObject).Play();
    }

    public void Retry()
    {
        gamemg.RetryStage_NoCol();
    }

    public void Exit()
    {
        gamemg.BackToTitle();
    }
}
