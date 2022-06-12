using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMG : SingletonMonoBehaviour<GameMG>
{
    [System.NonSerialized]
    public int currentStageNum = 0; //現在のステージ番号（0始まり）
    [SerializeField]
    string[] stageName; //ステージ名

    public void Awake()
    {
        //シングルトンの処理
        if (this != Instance)
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        //シーンを切り替えてもこのゲームオブジェクトを削除しないようにする
        DontDestroyOnLoad(gameObject);
    }

    //次のステージに進む処理
    public void NextStage()
    {
        currentStageNum += 1;
        //コルーチンを実行
        StartCoroutine(WaitForLoadScene());
    }

    public void TitletoStart()
    {
        currentStageNum += 1;
        FadeManager.Instance.LoadScene(stageName[currentStageNum], 0.5f);
    }

    //シーンの読み込みと待機を行うコルーチン
    IEnumerator WaitForLoadScene()
    {
        //3秒待つ
        yield return new WaitForSeconds(3);
        //シーン遷移
        FadeManager.Instance.LoadScene(stageName[currentStageNum],0.5f);
    }

    //ゲームオーバー処理
    public void GameOver()
    {

    }
}
