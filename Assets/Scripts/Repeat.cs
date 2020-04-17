using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Repeat : MonoBehaviour
{
	Animator time;
    public string animationName;

    // Start is called before the first frame update
    void Start()
    {
		time = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
            time.Play(animationName);
    }
}
