using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Tutorial2 : MonoBehaviour
{
    public TMP_Text childText;
    public CanvasGroup tutAlpha;

    public Waves W;

    public float startTut;

    public int steps;

    PlayerSettings PS;
    public GameVersion GV;

    // Start is called before the first frame update
    void Start()
    {
        PS = GameObject.Find("PlayerSettings").GetComponent<PlayerSettings>();
    }

    // Update is called once per frame
    void Update()
    {
        if(PS.tutorialEnabled == true && GV.gameVersion1or2 == true)
        {
            if(W.day == 2)
            {
                startTut += Time.deltaTime;

                if(startTut >= 13f)
                {
                    tutAlpha.alpha += Time.deltaTime;

                    switch(steps)
                    {
                        case 1:
                            childText.text = "You've unlocked a new Ability and Enemy!";
                            if(startTut >= 18f)
                            {
                                tutAlpha.alpha = 0f;
                                steps = 0;
                            }
                            break;
                        default:
                            childText.text = "You unlock new things every day";
                            if(startTut >= 23f)
                            {
                                tutAlpha.alpha = 0f;
                                Destroy(this.gameObject);
                            }
                            break;
                    }
                }
            }
        }
        else
        {   
            Destroy(this.gameObject);
        }
    }
}
