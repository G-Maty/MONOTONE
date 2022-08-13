using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraManager : MonoBehaviour
{

    private const int stageMax = 100;
    private const float cameraWidth = 8.5f, cameraHeight = 4.5f;


    public int nowStage;

    private Vector2[] stageSizes;
    private float edgeRight, edgeLeft, edgeUp, edgeDown;
    private int tmp;

    private GameObject[] rawStages, stages;
    private GameObject chara;

    void Start()
    {
        rawStages = GameObject.FindGameObjectsWithTag("Stage");
        chara = GameObject.Find("PlayerCircle");

        stages = new GameObject[stageMax];
        stageSizes = new Vector2[stageMax];

        for (int i = 0; i < rawStages.Length; i++)
        {

            tmp = rawStages[i].GetComponent<StageManager>().stageNum;

            if (tmp >= stageMax)
            {
                Debug.Log("Error! Please set stageNum below stageMax!");
                continue;
            }

            stages[tmp] = rawStages[i];
            stageSizes[tmp] = rawStages[i].GetComponent<BoxCollider2D>().size;
        }
    }

    void Update()
    {
        edgeLeft = stages[nowStage].transform.position.x - (stageSizes[nowStage].x / 2) + cameraWidth;
        edgeRight = stages[nowStage].transform.position.x + (stageSizes[nowStage].x / 2) - cameraWidth;
        edgeDown = stages[nowStage].transform.position.y - (stageSizes[nowStage].y / 2) + cameraHeight;
        edgeUp = stages[nowStage].transform.position.y + (stageSizes[nowStage].y / 2) - cameraHeight;

        // �J�����̉��������[�v�ړ�
        if (edgeLeft >= transform.position.x)
        {
            //transform.position += (edgeLeft - transform.position.x) * Vector3.right;
            transform.DOMoveX(transform.position.x + (edgeLeft - transform.position.x) * 1, 0.5f).SetLink(gameObject).Play();
        }
        else if (edgeRight <= transform.position.x)
        {
            //transform.position += (edgeRight - transform.position.x) * Vector3.right;
            transform.DOMoveX(transform.position.x + (edgeRight - transform.position.x) * 1, 0.5f).SetLink(gameObject).Play();
        }

        // �J�����̏c�������[�v�ړ�
        if (edgeDown >= transform.position.y)
        {
            //transform.position += (edgeDown - transform.position.y) * Vector3.up;
            transform.DOMoveY(transform.position.y + (edgeDown - transform.position.y) * 1, 0.5f).SetLink(gameObject).Play();
        }
        else if (edgeUp <= transform.position.y)
        {
            //transform.position += (edgeUp - transform.position.y) * Vector3.up;
            transform.DOMoveY(transform.position.y + (edgeUp - transform.position.y) * 1, 0.5f).SetLink(gameObject).Play();
        }

        /*
        // �J�����̃L�����Ǐ]�ړ�
        if (chara.transform.position.x > edgeLeft && chara.transform.position.x < edgeRight)
        {
            transform.position = new Vector3(chara.transform.position.x, transform.position.y, transform.position.z);
        }
        if (chara.transform.position.y > edgeDown && chara.transform.position.y < edgeUp)
        {
            transform.position = new Vector3(transform.position.x, chara.transform.position.y, transform.position.z);
        }
        */
    }
}
