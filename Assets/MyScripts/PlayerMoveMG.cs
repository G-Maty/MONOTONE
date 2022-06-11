using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveMG : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 3f;
    [SerializeField] private float jumpForce = 600f;
    private bool isJump = false; //ジャンプ中かどうか

    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement(); //動く
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
    }
}
