using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        StartCoroutine(WaitForLoadScene());
    }

    public void TitletoStart()
    {
        currentStageNum += 1;
        FadeManager.Instance.LoadScene(stageName[currentStageNum], 0.5f);
    }

    //�V�[���̓ǂݍ��݂Ƒҋ@���s���R���[�`��
    IEnumerator WaitForLoadScene()
    {
        //3�b�҂�
        yield return new WaitForSeconds(3);
        //�V�[���J��
        FadeManager.Instance.LoadScene(stageName[currentStageNum],0.5f);
    }

    //�Q�[���I�[�o�[����
    public void GameOver()
    {

    }
}
