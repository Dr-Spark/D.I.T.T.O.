using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour { 
    public enum eMode { idle, move, attack }
    public eMode mode;

    [Header("Set in Inspector")]
    public float speed = 3;
    public float attackDuration = 0.25f; // Number of seconds to attack
    public float attackDelay = 0.5f;     // Delay between attacks
    public int maxHealth = 10;

    //[Header("Set Dynamically")]
    private float v;
    private float h;

    Animator player;

    public float facing;
    //down = 0
    //left = 1
    //up = 2
    //right = 3

    
    

    [SerializeField]
    private int _health;

    public int health
    {
        get { return _health; }
        set { _health = value; }
    }
    
    private float timeAtkDone = 0;
    private float timeAtkNext = 0;

    void Start()
    {
        player = gameObject.GetComponent<Animator>();
    }
    void Awake()
    {
        health = maxHealth;    
    }

    void Update()
    {
        v = Input.GetAxisRaw("Vertical");
        h = Input.GetAxisRaw("Horizontal");

        GetComponent<Rigidbody2D>().velocity = new Vector2(h, v) * speed;

        //get face
        if ((h > 0 || h < 0) && (v < 0 || v > 0)) //diagonally
        {
            if (v > 0) //up
            {
                facing = 2;
            }
            else if (v < 0) //down
            {
                facing = 0;
            }
        }
        else if ((v > 0 || v < 0) && h == 0) //up and down
        {
            if (v > 0)//up
            {
                facing = 2;
            }
            else if (v < 0)//down
            {
                facing = 0;
            }
        }
        else if ((h > 0 || h < 0) && v == 0) // left and right
        {
            if (h > 0)//right
            {
                facing = 3;
            }
            else if (h < 0)//left
            {
                facing = 1;
            }
        }

        //attack
        if (Input.GetKeyDown(KeyCode.Space) && Time.time >= timeAtkNext)
        {
            mode = eMode.attack;
            timeAtkDone = Time.time + attackDuration;
            timeAtkNext = Time.time + attackDelay;
        }

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
                player.speed = 1;
                if (facing == 2)
                {
                    player.Play("PlayerAtkBack");
                }
                else if (facing == 0)
                {
                    player.Play("PlayerAtkFront");
                }
                else if (facing == 3)
                {
                    player.Play("PlayerAtkSide");
                }
                else if (facing == 1)
                {
                    player.Play("PlayerAtkSideL");
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
                else if (facing == 3)
                {
                    player.Play("PlayerWalkSide");
                }
                else if (facing == 1)
                {
                    player.Play("PlayerWalkSideL");
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
                else if (facing == 3)
                {
                    player.Play("PlayerIdleSide");
                }
                else if (facing == 1)
                {
                    player.Play("PlayerIdleSideL");
                }
                break;
        }
    }
}
