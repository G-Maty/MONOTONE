using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * �J�������[�N�ɕK�v
 * ����V�[���𕡐��̃X�e�[�W�ɕ����ĊǗ�
 */

public class StageManager : MonoBehaviour
{
    [SerializeField] public int stageNum;
    private CameraManager cameraScript;

    // Start is called before the first frame update
    void Start()
    {
        cameraScript = GameObject.Find("Camera").GetComponent<CameraManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            cameraScript.nowStage = stageNum;
        }
    }
}
