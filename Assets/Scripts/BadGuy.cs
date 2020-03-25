using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadGuy : MonoBehaviour
{
    /*
	public float moveSpeed = .2f;
	Vector3 move = new Vector3(0, .1f, 0);
    */

    //public float x = 0;
    //public float y = 0;

    Animator enemy;

    public float speed;
    public float speedUp;

    public bool moveLeft;
    public bool moveUp;
    public float faceDifX;
    public string collid;

    //public float faceDifY;

    void Start()
    {
        enemy = gameObject.GetComponent<Animator>();

    }

    void Update()
    {
        /*
        Vector3 move = new Vector3(x, y, 0);
        GetComponent<Rigidbody2D>().velocity = move * speed;

        transform.position += Vector3.up * Time.deltaTime;
        */

        if (moveUp)
        {
            enemy.Play("Enemy1RunBack");
            transform.Translate(0, Time.deltaTime * speed, 0);
        }

        if (moveLeft)
        {       
            enemy.Play("Enemy1RunLeft");
            transform.Translate(-1 * Time.deltaTime * speed, 0, 0);
        }
        
        if(transform.position.x > faceDifX)
        {
            moveLeft = true;
        }
        else
        {
            speed += speedUp;
            moveLeft = false;
            moveUp = true;

            if (transform.position.y > 12)
            {
                enemy.Play("Enemy1IdleBack");
                moveUp = false;
                moveLeft = false;
            }
        }


    }

    /*
    void OnCollisionEnter(Collider other)
    {
        Debug.Log("Player Collision");
        if (other.gameObject.name.Equals("Wall"))
        {
            Debug.Log("Collided with the wall");
            moveLeft = false;
        }
        else
        {
            Debug.Log("Collid didn't happen");
        }
    }
    */

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Player Collision");
        if (collision.tag == "Player")
        {
            Debug.Log("Collided with the wall");
            moveLeft = false;
        }
        else
        {
            Debug.Log("Collid didn't happen");
        }
    }
}
