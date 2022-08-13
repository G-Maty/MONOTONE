using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerColorSetting : MonoBehaviour
{
    [SerializeField]
    private GameObject blueWall; //親の空オブジェクト
    [SerializeField]
    private GameObject greenWall; //親の空オブジェクト
    private SpriteRenderer nowObjColor; //アタッチされたオブジェクトのsprite情報
    private bool blueFlag = true, greenFlag = false;

    // Start is called before the first frame update
    void Start()
    {
        nowObjColor = GetComponent<SpriteRenderer>();
        GetChildren_ColliderNonActive(blueWall);
        GetChildren_ColliderActive(greenWall);
        //Debug.Log(nowObjColor);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            if(blueFlag == true && greenFlag == false) //Greenへ
            {
                greenFlag = true;
                nowObjColor.DOColor(Color.green, 0.5f);
                GetChildren_ColliderNonActive(greenWall);
                GetChildren_ColliderActive(blueWall);
                blueFlag = false;
            }else if (blueFlag == false && greenFlag == true) //Blueへ
            {
                blueFlag = true;
                nowObjColor.DOColor(Color.blue, 0.5f);
                GetChildren_ColliderNonActive(blueWall);
                GetChildren_ColliderActive(greenWall);
                greenFlag = false;
            }
        }
    }

    private void GetChildren_ColliderNonActive(GameObject obj) //子のColliderをすべて非アクティブに
    {
        Transform children = obj.GetComponentInChildren<Transform>(); //Transform型でなければ.childCountが使用不可
        //子要素がいなければ終了
        if (children.childCount == 0)
        {
            return;
        }
        foreach (Transform ob in children)
        {
            ob.gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }
    }

    private void GetChildren_ColliderActive(GameObject obj) //子のColliderをすべてアクティブに
    {
        Transform children = obj.GetComponentInChildren<Transform>(); //Transform型でなければ.childCountが使用不可
        //子要素がいなければ終了
        if (children.childCount == 0)
        {
            return;
        }
        foreach (Transform ob in children)
        {
            ob.gameObject.GetComponent<BoxCollider2D>().enabled = true;
        }
    }
}
