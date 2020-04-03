﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GuiPanel : MonoBehaviour
{
    [Header("Set in Inspector")]
    public Player Hero;
    public Sprite healthEmpty;
    public Sprite healthHalf;
    public Sprite healthFull;

    public Text keyCountText;

    //    Text keyCountText;
    List<Image> healthImages;

    void Start()
    {
        // Key Count
              Transform trans = transform.Find("Key Count");
              keyCountText = trans.GetComponent<Text>();

        //Health Icons
        Transform healthPanel = transform.Find("Health Panel");
        healthImages = new List<Image>();
        if (healthPanel != null)
        {
            for (int i = 0; i < 20; i++)
            {
                trans = healthPanel.Find("H_" + i);
                if (trans == null) break;
                healthImages.Add(trans.GetComponent<Image>());
            }
        }
    }
    void Update()
    {
        // Show Keys
        //        keyCountText.text = Hero.numKeys.ToString();

        //Show health
        //dont't have Hero.health so I changed it into a number for now
        //Kelly
        int health = 3;
        for (int i = 0; i < healthImages.Count; i++)
        {
            if (health > 1)
            {
                healthImages[i].sprite = healthFull;
            }
            else if (health == 1)
            {
                healthImages[i].sprite = healthHalf;
            }
            else
            {
                healthImages[i].sprite = healthEmpty;
            }
            health -= 2;
        }
    }
}
