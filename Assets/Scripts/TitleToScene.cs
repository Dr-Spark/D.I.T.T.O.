using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleToScene : MonoBehaviour
{
	public GameObject other;
	public string nextScene;
	
    void Start()
    {
        
    }

    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return) && other.transform.position.y > -1.9){
			SceneManager.LoadScene(nextScene);
		}
    }
}
