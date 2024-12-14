using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Luna : MonoBehaviour
{

    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float jumpSpeed = 300f;
    private Rigidbody2D rb;
    private bool isGrounded = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // 移動邏輯
        float move = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(move * moveSpeed, rb.velocity.y);

        // 翻轉角色
        if (move > 0) GetComponent<SpriteRenderer>().flipX = false;
        if (move < 0) GetComponent<SpriteRenderer>().flipX = true;

        // 跳躍邏輯
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector2.up * jumpSpeed); // 向上施加跳躍力
            isGrounded = false;
            GetComponent<Animator>().SetBool("Jump", true);
        }
        else
        {
            GetComponent<Animator>().SetBool("Jump", false);
        }

        // 更新動畫
        if (Mathf.Abs(move) > 0.1f)
        {
            GetComponent<Animator>().SetBool("Walk", true);
        }
        else
        {
            GetComponent<Animator>().SetBool("Walk", false);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            GetComponent<Animator>().SetBool("Jump", false);
        }
    }
/*
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float jumpSpeed = 300f;
    private Rigidbody2D rb;
    //private bool isGrounded = true;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<SpriteRenderer>();
        GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // 移動邏輯
        float move = Input.GetAxis("Horizontal") * moveSpeed;
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(move * moveSpeed, rb.velocity.y);
        //rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);

        // 翻轉角色
        if (move > 0) GetComponent<SpriteRenderer>().flipX = false;
        if (move < 0) GetComponent<SpriteRenderer>().flipX = true;

        if(Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(moveSpeed*Time.deltaTime, 0, 0);
            GetComponent<SpriteRenderer>().flipX = false;
            GetComponent<Animator>().SetBool("Walk", true);
        }
        else if(Input.GetKey(KeyCode.D))
        {
            transform.Translate(moveSpeed*Time.deltaTime, 0, 0);
            GetComponent<SpriteRenderer>().flipX = false;
            GetComponent<Animator>().SetBool("Walk", true);
        }
        else if(Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(-moveSpeed*Time.deltaTime, 0, 0);
            GetComponent<SpriteRenderer>().flipX = true;
            GetComponent<Animator>().SetBool("Walk", true);
        }
        else if(Input.GetKey(KeyCode.A))
        {
            transform.Translate(-moveSpeed*Time.deltaTime, 0, 0);
            GetComponent<SpriteRenderer>().flipX = true;
            GetComponent<Animator>().SetBool("Walk", true);
        }
        else if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            rb.AddForce(Vector2.up * jumpSpeed);
            //isGrounded = false;
            GetComponent<Animator>().SetBool("Jump", true);
        }
        else if(Input.GetKey(KeyCode.W))
        {
            
            GetComponent<Animator>().SetBool("Jump", true);
        }
        else
        {
            GetComponent<Animator>().SetBool("Walk", false);
            GetComponent<Animator>().SetBool("Jump", false);
        }
    }
    //void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.CompareTag("Ground"))
    //    {
    //        isGrounded = true;
    //    }
    //}

*/
}
