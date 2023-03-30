using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class codigo : MonoBehaviour
{
   public int velocidad = 4;
    Rigidbody2D rb;
    SpriteRenderer sr;
    Animator animator;

    const int IDLE = 0;
    const int correr = 1;
    const int ataque = 2;
    const int Throw = 3;
    const int muerta = 4;
    const int Deslisar = 5;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.RightArrow)){
            sr.flipX = false;
            rb.velocity = new Vector2( velocidad, rb.velocity.y);

            ChangeAnimation(correr);
        }

        else if(Input.GetKey(KeyCode.LeftArrow)){
            sr.flipX = true;
            rb.velocity = new Vector2(-velocidad, rb.velocity.y);
            ChangeAnimation(correr);
        }
        else if(Input.GetKey(KeyCode.Z)){
                ChangeAnimation(ataque);
        }
        else if(Input.GetKey(KeyCode.A)){
                ChangeAnimation(Deslisar);
        }
        else if(Input.GetKey(KeyCode.S)){
                ChangeAnimation(Throw);
        }
        else if(Input.GetKey(KeyCode.M)){
                ChangeAnimation(muerta);
        }
        
        else{
            rb.velocity = new Vector2(0, rb.velocity.y);
            ChangeAnimation(IDLE);
        }
        
    }


    private void ChangeAnimation (int a){
        animator.SetInteger("Correr", a);
    }
}