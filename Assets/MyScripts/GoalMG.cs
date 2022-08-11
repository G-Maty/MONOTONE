using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

/*
 * �S�[������
 * �e�S�[���I�u�W�F�N�g�ɃA�^�b�`
 */

public class GoalMG : MonoBehaviour
{
    [SerializeField] private GameObject goal;
    [SerializeField] private Image clearUI;
    [SerializeField] private GameObject player;
    private GameObject clearEff;
    private Renderer rendererComponent;
    private Renderer childrendererComponent;
    private GameMG gamemg;

    // Start is called before the first frame update
    void Start()
    {
        //���[�h�����O��GameManager�����݂��Ȃ����߃A�E�g���b�g�ڑ��s�\
        gamemg = GameObject.Find("GameManager").GetComponent<GameMG>();
        goal.transform.DOScale(0f, 1.7f).SetLoops(-1).SetLink(gameObject).Play();
        clearUI.fillAmount = 0;
        rendererComponent = player.GetComponent<Renderer>(); //�v���C���[��SpriteRenderer�擾
        clearEff = player.transform.GetChild(0).gameObject; //�v���C���[�̎q�I�u�W�F�N�g���擾
        childrendererComponent = clearEff.GetComponent<Renderer>();
        clearEff.SetActive(false);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        //�S�[����̏���
        clearEff.SetActive(true);
        clearUI.DOFillAmount(1f, 1f).SetEase(Ease.InOutCubic).SetLink(gameObject).SetDelay(1f).Play();
        var sequence = DOTween.Sequence();
        sequence.Append(this.rendererComponent.material.DOFade(0f, 0.2f).SetEase(Ease.Linear));
        sequence.Append(clearEff.transform.DOScale(new Vector3(3f, 3f, 3f), 0.5f));
        sequence.Join(clearEff.transform.DORotate(new Vector3(0f, 0f, 360f), 1f, RotateMode.FastBeyond360));
        sequence.Join(childrendererComponent.material.DOFade(0f, 0.5f).SetEase(Ease.Linear));
        sequence.Play();
        Destroy(player,1.5f);
        gamemg.NextStage();
    }
}
