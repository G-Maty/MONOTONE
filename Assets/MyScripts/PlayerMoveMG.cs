using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveMG : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 3f;
    [SerializeField] private float jumpForce = 600f;
    private bool isJump = false; //�W�����v�����ǂ���

    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement(); //����
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
    }
}
