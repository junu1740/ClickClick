using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{

    Animator anim;

    public void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I)) 
        {
            anim.CrossFade("New Animation", 0, 0);
            
        } 

        else if (Input.GetKeyDown(KeyCode.A))
        {
            anim.CrossFade("Attack", 0, 0);
        }

        else if (Input.GetKeyDown(KeyCode.D))
        {
            anim.CrossFade("Death", 0, 0, 0);
        }

        else if (Input.GetKeyDown(KeyCode.W))
        {
            anim.CrossFade("Walk", 0, 0);
            
        }

        
        
    }
}
