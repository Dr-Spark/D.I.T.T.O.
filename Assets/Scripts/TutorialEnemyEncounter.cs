using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialEnemyEncounter : MonoBehaviour
{
    public TextManager dialouge;

    Animator player;
    void Start()
    {
        player = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
