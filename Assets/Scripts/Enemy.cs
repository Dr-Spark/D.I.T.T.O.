using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    /*
	public float moveSpeed = .2f;
	Vector3 move = new Vector3(0, .1f, 0);
    */

    private float x = 0;
    private float y = 0;
    public float speed;

    void Update()
    {
        /*
		while(transform.position.y < 5){
			transform.Translate(move * moveSpeed * Time.deltaTime);
		}
		while(transform.position.y > 3.8){
			transform.Translate(move * -moveSpeed * Time.deltaTime);
		}
        */

        Vector3 move = new Vector3(x, y);

        move = move.normalized;

        GetComponent<Rigidbody2D>().velocity = move * speed;

        x--;

    }
}
