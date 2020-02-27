using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player: MonoBehaviour
{
    public enum eMode { idle, move, attack }
    public eMode mode;

    public float speed;

    public float v;
    public float h;

    Animator player;

    private bool faceLeft = false;
    private float facing = 0;
    //2 = up (showing the back)
    //3 = left 
    //0  = down
    //1 = right

    public float attackDuration = 0.25f; // Number of seconds to attack
    public float attackDelay = 0.5f;     // Delay between attacks
    private float timeAtkDone = 0;
    private float timeAtkNext = 0;

    void Start()
    {
        player = gameObject.GetComponent<Animator>();

    }

    void Update()
    {
        v = Input.GetAxisRaw("Vertical");
        h = Input.GetAxisRaw("Horizontal");

        Vector3 move = new Vector3(h,v);

        move = move.normalized * speed;

        GetComponent<Rigidbody2D>().velocity = move;
        
        
        
        //get face
        if ((h > 0 || h < 0) && (v < 0 || v > 0))
        {
            if (v > 0)
            {
                facing = 2;
            }
            else if (v < 0)
            {
                facing = 0;
            }
        }
        else if ((h > 0 || h < 0) && v == 0)
        {
            facing = 1;
            if (h < 0 && !faceLeft)
            {
                Flip();
            }
            else if (h > 0 && faceLeft)
            {
                Flip();
            }
        }
        else if ((v > 0 || v < 0) && h == 0)
        {
            if (v > 0)
            {
                facing = 2;
            }
            else if (v < 0)
            {
                facing = 0;
            }
        }

        //attack
        if (Input.GetKeyDown(KeyCode.Space) && Time.time >= timeAtkNext)
        {
            mode = eMode.attack;
            timeAtkDone = Time.time + attackDuration;
            timeAtkNext = Time.time + attackDelay;
        }

        //attack
        if (Time.time >= timeAtkDone)
        {
            mode = eMode.idle;
        }

        if (mode != eMode.attack)
        {
            if (h == 0 && v == 0)
            {
                mode = eMode.idle;
            }
            else
            {
                mode = eMode.move;
            }

            if (h == 0 && v == 0)
            {
                mode = eMode.idle;
            }
            else
            {
                mode = eMode.move;
            }
        }

        //types of animation
        switch (mode)
        {
            case eMode.attack:
                player.speed = 0;
                if (facing == 2)
                {
                    player.Play("PlayerAtkBack");
                }
                else if (facing == 0)
                {
                    player.Play("PlayerAtkFront");
                }
                else if (facing == 3 || facing == 1)
                {
                    player.Play("PlayerAtkSide");
                }
                break;

            case eMode.move:
                player.speed = 1;
                if (facing == 2)
                {
                    player.Play("PlayerWalkBack");
                }
                else if (facing == 0)
                {
                    player.Play("PlayerWalkFront");
                }
                else if (facing == 3 || facing == 1)
                {
                    player.Play("PlayerWalkSide");
                }
                break;

            case eMode.idle:
                player.speed = 0;
                if (facing == 2)
                {
                    player.Play("PlayerIdleBack");
                }
                else if (facing == 0)
                {
                    player.Play("PlayerIdleFront");
                }
                else if (facing == 3 || facing == 1)
                {
                    player.Play("PlayerIdleSide");
                }
                break;
        }
    }

    void Flip()
    {
        faceLeft = !faceLeft;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
