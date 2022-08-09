using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * �X�e�[�W�Ǘ�
 * �X�e�[�W�Ԃ̑J��
 * GameManager�I�u�W�F�N�g�ɃA�^�b�`
 */

public class GameMG : SingletonMonoBehaviour<GameMG>
{
    [System.NonSerialized]
    public int currentStageNum = 0; //���݂̃X�e�[�W�ԍ��i0�n�܂�j
    [SerializeField]
    string[] stageName; //�X�e�[�W��

    public void Awake()
    {
        //�V���O���g���̏���
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
        //�V�[����؂�ւ��Ă����̃Q�[���I�u�W�F�N�g���폜���Ȃ��悤�ɂ���
        DontDestroyOnLoad(gameObject);
    }

    //���̃X�e�[�W�ɐi�ޏ���
    public void NextStage()
    {
        currentStageNum += 1;
        //�R���[�`�������s
        StartCoroutine(Wait3ForLoadScene());
    }

    //���݂̃X�e�[�W�ɖ߂�����
    public void RetryStage()
    {
        StartCoroutine(Wait2ForLoadScene());
    }

    public void TitletoStart()
    {
        currentStageNum += 1;
        FadeManager.Instance.LoadScene(stageName[currentStageNum], 0.5f);
    }

    //�V�[���̓ǂݍ��݂Ƒҋ@���s���R���[�`��
    IEnumerator Wait3ForLoadScene()
    {
        //3�b�҂�
        yield return new WaitForSeconds(3);
        //�V�[���J��
        FadeManager.Instance.LoadScene(stageName[currentStageNum],0.5f);
    }

    IEnumerator Wait2ForLoadScene()
    {
        //2�b�҂�
        yield return new WaitForSeconds(2);
        //�V�[���J��
        FadeManager.Instance.LoadScene(stageName[currentStageNum], 0.5f);
    }
}
