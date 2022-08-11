using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

/*
 * �v���C���[�̓����Ɋւ��鏈��
 * �e�v���C���[�ɃA�^�b�`
 */

public class PlayerMoveMG : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 3f;
    [SerializeField] private float jumpForce = 600f;
    private GameObject damageEff;
    private bool isJump = false; //�W�����v�����ǂ���
    private bool isStop = false; //�v���C���[���~�߂邩�ǂ���

    private Rigidbody2D rb;
    private Renderer rendererComponent;
    private Renderer childrendererComponent;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rendererComponent = GetComponent<Renderer>(); //SpriteRenderer�擾
        damageEff = transform.GetChild(0).gameObject; //�q�I�u�W�F�N�g���擾
        childrendererComponent = damageEff.GetComponent<Renderer>();
        damageEff.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(isStop == false)
        {
            Movement(); //����
        }
    }

    void Movement()
    {
        float x = Input.GetAxis("Horizontal");
        //float y = Input.GetAxis("Vertical");
        if (x > 0)
        {
            transform.localScale = new Vector3(-1.3f, 1.3f, 1);
        }
        if (x < 0)
        {
            transform.localScale = new Vector3(1.3f, 1.3f, 1);
        }
        if (Input.GetKeyDown(KeyCode.W) && !isJump) //�󒆂ł̓W�����v�ł��Ȃ�
        {
            rb.AddForce(transform.up * jumpForce); //�͂������ăW�����v
            isJump = true;
        }
        rb.velocity = new Vector2(x * moveSpeed, rb.velocity.y); //�ړ��̎��s
    }

    private void OnCollisionEnter2D(Collision2D collision)�@//�ڒn����
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            isJump = false;
        }
        if(collision.gameObject.CompareTag("Damage"))
        {
            isStop = true;
            damageEff.SetActive(true);
            //For DamageEffect
            var sequence = DOTween.Sequence();
            sequence.Append(this.rendererComponent.material.DOFade(0f, 0.2f).SetEase(Ease.Linear));
            sequence.Append(damageEff.transform.DOScale(new Vector3(1f, 1f, 1f), 0.5f));
            sequence.Join(childrendererComponent.material.DOFade(0f, 0.5f).SetEase(Ease.Linear));
            sequence.Play();
        }
    }
}
