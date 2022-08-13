using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerColorSetting : MonoBehaviour
{
    [SerializeField]
    private GameObject blueWall; //�e�̋�I�u�W�F�N�g
    [SerializeField]
    private GameObject greenWall; //�e�̋�I�u�W�F�N�g
    private SpriteRenderer nowObjColor; //�A�^�b�`���ꂽ�I�u�W�F�N�g��sprite���
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
            if(blueFlag == true && greenFlag == false) //Green��
            {
                greenFlag = true;
                nowObjColor.DOColor(Color.green, 0.5f);
                GetChildren_ColliderNonActive(greenWall);
                GetChildren_ColliderActive(blueWall);
                blueFlag = false;
            }else if (blueFlag == false && greenFlag == true) //Blue��
            {
                blueFlag = true;
                nowObjColor.DOColor(Color.blue, 0.5f);
                GetChildren_ColliderNonActive(blueWall);
                GetChildren_ColliderActive(greenWall);
                greenFlag = false;
            }
        }
    }

    private void GetChildren_ColliderNonActive(GameObject obj) //�q��Collider�����ׂĔ�A�N�e�B�u��
    {
        Transform children = obj.GetComponentInChildren<Transform>(); //Transform�^�łȂ����.childCount���g�p�s��
        //�q�v�f�����Ȃ���ΏI��
        if (children.childCount == 0)
        {
            return;
        }
        foreach (Transform ob in children)
        {
            ob.gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }
    }

    private void GetChildren_ColliderActive(GameObject obj) //�q��Collider�����ׂăA�N�e�B�u��
    {
        Transform children = obj.GetComponentInChildren<Transform>(); //Transform�^�łȂ����.childCount���g�p�s��
        //�q�v�f�����Ȃ���ΏI��
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
