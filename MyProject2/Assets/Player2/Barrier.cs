using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrier : MonoBehaviour
{
    Vector3 CurrentPos;
    Vector3 StartPos;
   
    private bool Control;
    private void Awake()
    {
        StartPos = transform.position;
        Control = true;
    }

    private void Update()
    {
        
        if(Control == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(16.5f, 9f), 0.07f);
            CurrentPos = transform.position;
            if(CurrentPos.y > 8.5f)
            {
                Control = false;
            }
            
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, StartPos, 0.07f);
            CurrentPos = transform.position;
            if(CurrentPos.x == StartPos.x)
            {
                Control = true;
            }
        }
    }
}
