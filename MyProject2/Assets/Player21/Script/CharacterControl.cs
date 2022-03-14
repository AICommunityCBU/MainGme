using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControl : MonoBehaviour
{

    [SerializeField] LayerMask walllayer;
    [SerializeField] Transform wallChackPoint;
    [SerializeField] Vector2 wallChackSize;
    [SerializeField] float wallslideSPEED;
    [SerializeField] private bool istouchWall;
    [SerializeField] private bool iswallSlide;




    public float walljumpforce = 15f;
    public float walljampDirecion = -1f;
    [SerializeField] Vector2 walljumpAngle;


    public float xDirection;
    public float jumpForce=5;
    public float spead=5;
    private bool saðbakk = true;

    public bool jumps;
    public bool grounded=true;
    private bool movings;
    public Rigidbody2D _rigidbody2D;
    private Animator anim;
    private float movepoint;


    private void Awake()
    {
        anim = GetComponent<Animator>();

    }
    void Start()

    {
        walljumpAngle.Normalize();
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        if(_rigidbody2D.velocity!=Vector2.zero)
        {
            movings = true;
        }
        else
        {
            movings = false;
        }
        _rigidbody2D.velocity = new Vector2(spead * movepoint, _rigidbody2D.velocity.y);
        if (jumps == true)
        {
            _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, jumpForce);
            jumps = false;
        }
    }
    // Update is called once per frame
    void Update()
    {

        chackWall();
        wallslide();
        walljumpss();



        xDirection = Input.GetAxis("Horizontal");
            if (Input.GetKey(KeyCode.A))
            {
                movepoint = -1.0f;
            }
            else if (Input.GetKey(KeyCode.D))
            {
                movepoint = 1.0f;
            }
            else if (grounded == true)
            {
                movepoint = 0.0f;
            

        }if(grounded==true && (Input.GetKey(KeyCode.W)))
        {
            jumps = true;
            grounded = false;
        }
        if (xDirection < 0 && saðbakk)
        {
            flip();
        }
        else if(xDirection>0&& !saðbakk)
        {
            flip();
        }
    }

    public void flip()
    {
        walljampDirecion *= -1;
        saðbakk = !saðbakk;
        transform.Rotate(0, 180, 0);

    }

    public void walljumpss()
    {
        if ((iswallSlide || istouchWall) && !grounded)
          
        {
            grounded = true;
            _rigidbody2D.AddForce(new Vector2(walljumpforce * walljampDirecion * walljumpAngle.x, walljumpforce * walljumpAngle.y), ForceMode2D.Impulse);
            jumps = false;
           

        }

    }

    public void wallslide()
    {
        if (istouchWall && !grounded && _rigidbody2D.velocity.y < 0)
        {
            iswallSlide = true;
        }
        else
        {
            iswallSlide = false;
        }
        if (istouchWall)
        {
            _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, wallslideSPEED);

        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("zemin"))
        {
            grounded = true;
        }
    }
    public void chackWall()
    {
        istouchWall = (Physics2D.OverlapBox(wallChackPoint.position, wallChackSize, 0, walllayer));


    }
}
