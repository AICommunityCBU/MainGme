using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControl : MonoBehaviour
{
   
    [SerializeField] Transform groundChackPoint;
    [SerializeField] Vector2 groundChackSize;
    [SerializeField] LayerMask groundlayer;
    [SerializeField] LayerMask walllayer;
    [SerializeField] Transform wallChackPoint;
    [SerializeField] Vector2 wallChackSize;
    [SerializeField] float wallslideSPEED;
    [SerializeField] private bool istouchWall;
    [SerializeField] private bool iswallSlide;



    public float walljumpxforce;
    public float walljumpforce = 15f;
    public float walljampDirecion = -1f;
    [SerializeField] Vector2 walljumpAngle;


    public float xDirection;
    public float jumpForce=5;
    public float spead=5;
    private bool saðbakk = true;
    public float walljumptime;

    public bool walljumps;
    public bool grounded;
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
        _rigidbody2D.velocity = new Vector2(spead * xDirection, _rigidbody2D.velocity.y);
    }
    // Update is called once per frame
    void Update()
    {

        chackWorld();
        wallslide();






        xDirection = Input.GetAxis("Horizontal");

        if (Input.GetKey(KeyCode.W) && grounded == true)
        {
            _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, jumpForce);
            Debug.Log("groundJUMP");
            
        }
        if (Input.GetKey(KeyCode.W) && iswallSlide == true||istouchWall==true)
        {
            walljumps = true;
            
        }
        if (walljumps == true&& Input.GetKey(KeyCode.W))
        {
            _rigidbody2D.velocity = new Vector2(100, walljumpforce);
            walljumps = false;
            Debug.Log("girdi");
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

   
    void setwalljumptofalse()
    {
        walljumps = false;
    }
    public void wallslide()
    {
        if (istouchWall && grounded==false && _rigidbody2D.velocity.y < 0)
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

    
    public void chackWorld()
    {
        istouchWall = (Physics2D.OverlapBox(wallChackPoint.position, wallChackSize, 0, walllayer));
        grounded= (Physics2D.OverlapBox(groundChackPoint.position, groundChackSize, 0, groundlayer));


    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawCube(groundChackPoint.position, groundChackSize);
        Gizmos.color = Color.green;
        Gizmos.DrawCube(wallChackPoint.position, wallChackSize);
    }
}
