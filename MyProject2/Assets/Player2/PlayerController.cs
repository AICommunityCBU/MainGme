using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float MovementSpeed;
    public float JumpSpeed;

    public Animator _anim;
    public SpriteRenderer SR;
    public Rigidbody2D _rigid;


    private bool IsGrounded;
    private bool IsMove;
    private bool IsJump;
    private void Awake()
    {
        _rigid = GetComponent<Rigidbody2D>();
        SR = GetComponent<SpriteRenderer>();
        _anim = GetComponent<Animator>();
    }
    private void Start()
    {
        IsGrounded = true;

    }
    private void Update()
    {
        Movement();
        Jump();
    }

    public void Movement()
    {
        float xInput = Input.GetAxisRaw("Horizontal");
        if(xInput > 0.1)
        {
            IsMove = true;
            _anim.SetBool("movement", IsMove);
            SR.flipX = false;

        }

        else if(xInput < -0.1)
        {
            IsMove = true;
            SR.flipX = true;
            _anim.SetBool("movement", IsMove);

        }
        else
        {
            IsMove = false;
            _anim.SetBool("movement", IsMove);

        }
        transform.position += new Vector3(xInput, 0, 0) * MovementSpeed * Time.deltaTime;


    }

    public void Jump()
    {
        if (IsGrounded == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                IsJump = true;
                _rigid.velocity = Vector2.up * JumpSpeed;
                _anim.SetBool("jumping", IsJump);
                IsGrounded = false;
            }
          
           
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            IsGrounded = true;
            IsJump = false;
            _anim.SetBool("jumping", IsJump);

        }

    }
}
