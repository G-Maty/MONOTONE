using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

/*
 * プレイヤーの動きに関する処理
 * 各プレイヤーにアタッチ
 */

public class PlayerMoveMG : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 3f;
    [SerializeField] private float jumpForce = 600f;
    private GameObject damageEff;
    private bool isJump = false; //ジャンプ中かどうか
    private bool isStop = false; //プレイヤーを止めるかどうか

    private Rigidbody2D rb;
    private Renderer rendererComponent;
    private Renderer childrendererComponent;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rendererComponent = GetComponent<Renderer>(); //SpriteRenderer取得
        damageEff = transform.GetChild(0).gameObject; //子オブジェクトを取得
        childrendererComponent = damageEff.GetComponent<Renderer>();
        damageEff.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(isStop == false)
        {
            Movement(); //動く
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
        if (Input.GetKeyDown(KeyCode.W) && !isJump) //空中ではジャンプできない
        {
            rb.AddForce(transform.up * jumpForce); //力を加えてジャンプ
            isJump = true;
        }
        rb.velocity = new Vector2(x * moveSpeed, rb.velocity.y); //移動の実行
    }

    private void OnCollisionEnter2D(Collision2D collision)　//接地判定
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
