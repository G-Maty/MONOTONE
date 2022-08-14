using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixedMyGame : MonoBehaviour
{
    private GameMG MGscript;
    // Start is called before the first frame update
    void Start()
    {
        MGscript = GameObject.Find("GameManager").GetComponent<GameMG>();
        MGscript.currentStageNum = 0;
    }

    public void GameStart()
    {
        MGscript.TitletoStart();
    }

    public void BackToTitle()
    {
        MGscript.BackToTitle();
    }
}
