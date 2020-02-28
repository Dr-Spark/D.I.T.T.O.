using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadGuy : MonoBehaviour
{
    /*
	public float moveSpeed = .2f;
	Vector3 move = new Vector3(0, .1f, 0);
    */

    public float x = 0;
    public float y = 0;

    private Vector2 velocity;
    private Rigidbody2D move;

    public float speed;
    public float faceDifferent;

    void Update()
    {
    

       //Vector3 move = transform.position;

       // move = move.normalized;

        //GetComponent<Rigidbody2D>().velocity = move * speed;

        

        /*
       if (transform.position.x >= faceDifferent) {
            move += Vector3.left;
        }

        if (transform.position.x == faceDifferent)
        {
            move.y += 1;
        }
        */
    }

    void Awake()
    {
        move = gameObject.AddComponent<Rigidbody2D>();
    }

    void Start()
    {
        velocity = new Vector2(speed, speed);
        transform.position = new Vector3(x, y, 0);
    }

    void FixedUpdate()
    {
        move.MovePosition(move.position + speed * Time.deltaTime);
    }
}
