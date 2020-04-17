using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class TextManager : MonoBehaviour
{
    public GameObject textBox;

    public Text theText;

    public TextAsset textFile;
    public string[] textLines;

    public int currentLine;
    public int endLine;

    public Player player;

    public bool wantNextScene;
    public string nextScene;

    //other classes can trigger this on so that a before textbox action can occur
    public bool textOnOff = false;

    void Start()
    {
        player = FindObjectOfType<Player>();
        if (textFile != null)
        {
            textLines = (textFile.text.Split('\n'));
        }

        if (endLine == 0)
        {
            endLine = textLines.Length - 1;
        }
    }

    void Update()
    {
        textBox.SetActive(false);

        if(textOnOff == true)
        {
            textBox.SetActive(true);

            if (currentLine < textLines.Length)
            {
                theText.text = textLines[currentLine];
            }


            if (Input.GetKeyDown(KeyCode.Return))
            {
                currentLine += 1;
            }

            if (currentLine > endLine)
            {
                textBox.SetActive(false);
                
                if(wantNextScene == true)
                {
                    SceneManager.LoadScene(nextScene);
                }  
            }
        }

    }

}
