using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening; //DOTween
using UnityEngine.EventSystems; //UI

public class ButtonAnim2 : UIBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    /*�L�����o�X�O���[�v���g�����R
     * �e�Ǝq�v�f�ǂ�����ꏏ�ɏ������Ă���邩��
     */
    [SerializeField] private CanvasGroup CanvasGroup;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        CanvasGroup.alpha = 1f;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        CanvasGroup.DOFade(endValue:0.5f, 0.25f).SetLink(gameObject).Play();
        /*
         * SetLink
         * �Q�[���I�u�W�F�N�g���j�����ꂽ�Ƃ��ɁATween���ꏏ�ɔj�����Ă����
         * ���̂܂܂��ƃG���[���o�邱�Ƃ�����
         */
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        CanvasGroup.DOFade(endValue:1f, 0.25f).SetLink(gameObject).Play();
    }
}
