using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleToScene : MonoBehaviour
{
	//public GameObject other;
	public string nextScene;
	
    void Start()
    {
        
    }

    
    void Update()
    {
        float change = .71f;
        if (transform.position.y > -1.87)
        {
            transform.position = new Vector3(transform.position.x, -3.3f, transform.position.z);
        }
        if (transform.position.y < -3.31)
        {
            transform.position = new Vector3(transform.position.x, -1.88f, transform.position.z);
        }
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            transform.Translate(0, change, 0);
        }
        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            transform.Translate(0, -change, 0);
        }
        if (Input.GetKeyDown(KeyCode.Return) && transform.position.y > -1.9){
			SceneManager.LoadScene(nextScene);
		}
    }
}
