using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

/*
 * �����A�j���[�V��������
 * �e�e�L�X�g�ɃA�^�b�`
 */

public class TexitAnim : MonoBehaviour
{
    //�����ł�TMP�p�̊g�����\�b�h���g���Ȃ�
    [SerializeField] private�@Text TutText1;
    
    private void Start()
    {
        var sequence = DOTween.Sequence();

        string newText = TutText1.text; //�����ɓ����Ă���e�L�X�g��ϐ�text�Ɋi�[
        TutText1.text = ""; //��U�󔒂�
        sequence.Append(TutText1.DOText(newText, 1.5f).SetEase(Ease.Linear).SetDelay(1f));
        sequence.Append(TutText1.DOFade(endValue: 0f, duration: 0.5f).SetDelay(2f));

        sequence.SetLoops(-1).SetLink(gameObject).Play();

    }
}
