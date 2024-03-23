using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuSettings : MonoBehaviour
{
    public PlayerSettings PS;

    public Button toggleTutorial;
    public Image tutYesOrNo;
    public Sprite tutYes;
    public Sprite tutNo;
    public int tutWhat;

    public Button closeSettings;

    public Button toggleVersion;
    public TMP_Text OneOrTwo;
    public int pressCount;
    public bool version1or2;

    // Start is called before the first frame update
    void Start()
    {
        PS = GameObject.Find("PlayerSettings").GetComponent<PlayerSettings>();

        toggleTutorial.onClick.AddListener(ToggleTutorial);

        if(PS.tutorialEnabled == true)
        {
            tutWhat = 0;
        }
        if(PS.tutorialEnabled == false)
        {
            tutWhat = 1;
        }

        if(SceneManager.GetActiveScene().name == "TestScene")
        {
            closeSettings.onClick.AddListener(CloseSettings);
        }
        if(SceneManager.GetActiveScene().name == "MainMenu")
        {
            toggleVersion.onClick.AddListener(WhatVersion);
        }
    }

    void CloseSettings()
    {
        this.GetComponent<RectTransform>().localPosition = new Vector3(0f, 500f, 0f);
    }


    void ToggleTutorial()
    {
        tutWhat += 1;
    }

    void WhatVersion()
    {
        pressCount += 1;
    }

    // Update is called once per frame
    void Update()
    {
        if(tutWhat == 0)
        {
            PS.tutorialEnabled = true;
            tutYesOrNo.sprite = tutYes;
        }
        if(tutWhat == 1)
        {
            PS.tutorialEnabled = false;
            tutYesOrNo.sprite = tutNo;
        }
        if(tutWhat >= 2)
        {
            tutWhat = 0;
        }

        if(SceneManager.GetActiveScene().name == "MainMenu")
        {
            if(pressCount == 0)
            {
                version1or2 = false;
                OneOrTwo.text = "1";
            }
            if(pressCount == 1)
            {
                version1or2 = true;
                OneOrTwo.text = "2";
            }
            if(pressCount >= 2)
            {
                pressCount = 0;
            }

            PS.gameVersion1or2 = version1or2;
        }
        
        if(SceneManager.GetActiveScene().name == "TestScene")
        {
           version1or2 = PS.gameVersion1or2;
        }
    }
}
