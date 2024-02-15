using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
    public PlayerSettings PS;

    public Waves W;
    public int correctInput = 11;

    public TMP_Text tutorialText;
    public CanvasGroup tutAlpha;

    public bool movedLeft;
    public bool movedRight;

    public GameObject player;

    public Image abilityIcon;
    public Image effectIcon;

    public bool qUsed;
    public bool eUsed;
    public bool rcUsed;

    public float timer;

    public Button openEnemies;
    public bool openedIt;

    public SpawningEnemies SE;

    public Button endTutorial;
    public bool endTheTut;

    public float startTut;

    // Start is called before the first frame update
    void Start()
    {
        PS = GameObject.Find("PlayerSettings").GetComponent<PlayerSettings>();

        player = GameObject.Find("Player");

        openEnemies.onClick.AddListener(opened);

        endTutorial.onClick.AddListener(endTut);

        openEnemies.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(PS.tutorialEnabled == true)
        {
            startTut += Time.deltaTime;

            if(W.day == 1 && startTut >= 13f)
            {
                tutAlpha.alpha += Time.deltaTime;

                switch(correctInput)
                {
                    case 11:
                        tutorialText.text = "Press ESC to pause and unpause the game.";
                        if(Input.GetKeyDown(KeyCode.Escape))
                        {
                            correctInput = 10;
                            tutAlpha.alpha = 0f;
                        }
                        break;
                    case 10:
                        tutorialText.text = "Use A and D to move.";
                        if(Input.GetKey(KeyCode.A))
                        {
                            movedLeft = true;
                        }
                        if(Input.GetKey(KeyCode.D))
                        {
                            movedRight = true;
                        }
                        if(movedLeft == true && movedRight == true)
                        {
                            correctInput = 9;
                            tutAlpha.alpha = 0f;
                        }
                        break;
                    case 9:
                        tutorialText.text = "Press SPACE to jump.";
                        if(Input.GetKeyDown(KeyCode.Space))
                        {
                            correctInput = 8;
                            tutAlpha.alpha = 0f;
                        }
                        break;
                    case 8:
                        tutorialText.text = "Press SHIFT in the air to dash.";
                        if(player.GetComponent<PlayerMove>().Jumping == true && Input.GetKeyDown(KeyCode.LeftShift))
                        {
                            correctInput = 7;
                            tutAlpha.alpha = 0f;
                        }
                        break;
                    case 7:
                        tutorialText.text = "Press TAB to open the Abilities Menu.";
                        if(Input.GetKeyDown(KeyCode.Tab))
                        {
                            correctInput = 6;
                            tutAlpha.alpha = 0f;
                        }
                        break;
                    case 6:
                        tutorialText.text = "Select an Ability and an Effect.";
                        tutorialText.color = new Color(0.15f, 0.15f, 0.15f, 1f);
                        if(abilityIcon.sprite != null && effectIcon.sprite != null)
                        {
                            correctInput = 5;
                            tutAlpha.alpha = 0f;
                        }
                        break;
                    case 5:
                        tutorialText.text = "Press TAB to close the menu.";
                        if(Input.GetKeyDown(KeyCode.Tab))
                        {
                            correctInput = 4;
                            tutAlpha.alpha = 0f;
                        }
                        break;
                    case 4:
                        tutorialText.text = "Use Q, E, and RIGHT CLICK to use abilities.";
                        tutorialText.color = new Color(1f, 1f, 1f, 1f);
                        if(Input.GetKeyDown(KeyCode.Q))
                        {
                            qUsed = true;
                        }
                        if(Input.GetKeyDown(KeyCode.E))
                        {
                            eUsed = true;
                        }
                        if(Input.GetMouseButtonDown(1))
                        {
                            rcUsed = true;
                        }
                        if(qUsed == true && eUsed == true && rcUsed == true)
                        {
                            correctInput = 3;
                            tutAlpha.alpha = 0f;
                        }
                        break;
                    case 3:
                        tutorialText.text = "Effects are passive.";
                        timer += Time.deltaTime;
                        if(timer >= 3f)
                        {
                            correctInput = 2;
                            tutAlpha.alpha = 0f;
                        }
                        break;
                    case 2:
                        tutorialText.text = "Press the button to begin the attack.";
                        openEnemies.gameObject.SetActive(true);
                        if(openedIt == true)
                        {
                            correctInput = 1;
                            tutAlpha.alpha = 0f;
                        }
                        break;
                    case 1:
                        tutorialText.text = "Add enemies to meet the points total.";
                        tutorialText.color = new Color(0.15f, 0.15f, 0.15f, 1f);
                        if(SE.sumOfEnemyPoints >= SE.enemyPointsTotal)
                        {
                            correctInput = 0;
                            tutAlpha.alpha = 0f;
                        }
                        break;
                    default:
                        tutorialText.text = "Begin the ATTACK!";
                        if(endTheTut == true)
                        {
                            Destroy(this.gameObject);
                        }
                        break;
                }
            }
        }
        else
        {
            openEnemies.gameObject.SetActive(true);
            
            Destroy(this.gameObject);
        }
    }

    void opened()
    {
        openedIt = true;
    }

    void endTut()
    {
        if(SE.sumOfEnemyPoints >= SE.enemyPointsTotal)
        {
            endTheTut = true;
        }
        else
        {
            endTheTut = false;
        }
    }
}
