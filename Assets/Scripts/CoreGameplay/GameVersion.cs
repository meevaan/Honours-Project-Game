using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameVersion : MonoBehaviour
{
    public bool gameVersion1or2;
    Waves W;

    public List<GameObject> abilityButtons = new List<GameObject>();
    public List<GameObject> effectButtons = new List<GameObject>();

    public List<GameObject> enemySelectors = new List<GameObject>();

    public PlayerSettings PS;

    // Start is called before the first frame update
    void Start()
    {
        W = this.GetComponent<Waves>();

        for(int i = 0; i < abilityButtons.Count; i++)
        {
            abilityButtons[i].SetActive(false);
            effectButtons[i].SetActive(false);
        }
        for(int i = 0; i < enemySelectors.Count; i++)
        {
            enemySelectors[i].SetActive(false);
        }

        PS = GameObject.Find("PlayerSettings").GetComponent<PlayerSettings>();
    }

    // Update is called once per frame
    void Update()
    {
        gameVersion1or2 = PS.gameVersion1or2;
        
        if(gameVersion1or2 == true)
        {
            switch(W.day)
            {
                case 8:
                    enemySelectors[W.day-1].SetActive(true);
                    break;
                case 7:
                    enemySelectors[W.day-1].SetActive(true);
                    break;
                case 6:
                    enemySelectors[W.day-1].SetActive(true);
                    break;
                case 5:
                    abilityButtons[W.day-1].SetActive(true);
                    effectButtons[W.day-1].SetActive(true);
                    enemySelectors[W.day-1].SetActive(true);
                    break;
                case 4:
                    abilityButtons[W.day-1].SetActive(true);
                    effectButtons[W.day-1].SetActive(true);
                    enemySelectors[W.day-1].SetActive(true);
                    break;
                case 3:
                    abilityButtons[W.day-1].SetActive(true);
                    effectButtons[W.day-1].SetActive(true);
                    enemySelectors[W.day-1].SetActive(true);
                    break;
                case 2:
                    abilityButtons[W.day-1].SetActive(true);
                    effectButtons[W.day-1].SetActive(true);
                    enemySelectors[W.day-1].SetActive(true);
                    break;
                case 1:
                    abilityButtons[W.day-1].SetActive(true);
                    effectButtons[W.day-1].SetActive(true);
                    enemySelectors[W.day-1].SetActive(true);
                    break;
                default:
                    //do nothing
                    break;
            }
        }

        if(gameVersion1or2 == false)
        {
            for(int i = 0; i < abilityButtons.Count; i++)
            {
                abilityButtons[i].SetActive(true);
                effectButtons[i].SetActive(true);

                if(i == abilityButtons.Count)
                {
                    break;
                }
            }
            for(int i = 0; i < enemySelectors.Count; i++)
            {
                enemySelectors[i].SetActive(true);

                if(i == enemySelectors.Count)
                {
                    break;
                }
            }
        }
    }
}
