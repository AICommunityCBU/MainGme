using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerL : MonoBehaviour
{
    private CharacterControl chcont;
    [SerializeField] LayerMask walllayer;
    [SerializeField] Transform wallChackPoint;
    [SerializeField] Vector2 wallChackSize;
    [SerializeField] float wallslideSPEED;
    [SerializeField] private bool istouchWall;
    [SerializeField] private bool iswallSlide;




    [SerializeField] public float walljumpforce=15f;
     public float walljampDirecion=-1f;
    [SerializeField] Vector2  walljumpAngle;
    void Start()
    {
        chcont = GetComponent<CharacterControl>();
    }

    // Update is called once per frame
    void Update()
    {
        chackWall();
        wallslide();
        walljumpss();

    }
    
    public void chackWall()
    {
        istouchWall = (Physics2D.OverlapBox(wallChackPoint.position, wallChackSize, 0, walllayer));
       

    }
    public void wallslide()
    {
       if(istouchWall && chcont.grounded &&chcont._rigidbody2D.velocity.y<0)
        {
            iswallSlide = true;
        }
        else
        {
            iswallSlide = false;
        }
        if (istouchWall)
        {
            chcont._rigidbody2D.velocity = new Vector2(chcont._rigidbody2D.velocity.x, wallslideSPEED);

        }

    }
    public void walljumpss()
    {
        if((iswallSlide||istouchWall)&& chcont.grounded)
        {
          //  chcont._rigidbody2D.AddForce(new Vector2(walljumpforce * walljampDirecion * walljumpAngle.x, walljumpforce * walljumpAngle.y), ForceMode2D.Impulse);
           // chcont.jumps = false;
        }

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawCube(wallChackPoint.position, wallChackSize); 
    }


}
