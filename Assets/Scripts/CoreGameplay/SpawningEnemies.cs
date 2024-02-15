using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SpawningEnemies : MonoBehaviour
{
    public int screenUpOrDown;
    public RectTransform thisScreen;

    public Button confirmSelection;

    public TMP_Text enemyCounterDisplay;

    public TrackStats TS;

//////////// Junk for spawning enemies ///////////////////

    public int sumOfEnemyPoints;
    public int enemyPointsTotal;
    public TMP_Text errorMessage;

    public int spawnRedBomber;
    public GameObject redBomber;
    public Button addRedBomberButton;
    public Button removeRedBomberButton;

    public int spawnRedRanger;
    public GameObject redRanger;
    public Button addRedRangerButton;
    public Button removeRedRangerButton;

    public int spawnRedSpearman;
    public GameObject redSpearman;
    public Button addRedSpearmanButton;
    public Button removeRedSpearmanButton;

    public int spawnRedMaster;
    public GameObject redMaster;
    public Button addRedMaster;
    public Button removeRedMaster;

    public int spawnBlueBola;
    public GameObject blueBola;
    public Button addBlueBola;
    public Button removeBlueBola;

    public int spawnBlueHammer;
    public GameObject blueHammer;
    public Button addBlueHammer;
    public Button removeBlueHammer;

    public int spawnBlueWizard;
    public GameObject blueWizard;
    public Button addBlueWizard;
    public Button removeBlueWizard;

    public int spawnBlueRocket;
    public GameObject blueRocket;
    public Button addBlueRocket;
    public Button removeBlueRocket;
    
/////////////////////////////////////////////////////////

    public List<GameObject> enemiesForSpawning = new List<GameObject>();

    public float spawnArea;


    void Start()
    {
        confirmSelection.onClick.AddListener(spawnAllInList);

        TS = GameObject.Find("StatTracker").GetComponent<TrackStats>();


        addRedBomberButton.onClick.AddListener(AddRedBomber);
        removeRedBomberButton.onClick.AddListener(RemoveRedBomber);

        addRedRangerButton.onClick.AddListener(AddRedRanger);
        removeRedRangerButton.onClick.AddListener(RemoveRedRanger);

        addRedSpearmanButton.onClick.AddListener(AddRedSpearman);
        removeRedSpearmanButton.onClick.AddListener(RemoveRedSpearman);

        addRedMaster.onClick.AddListener(AddRedMaster);
        removeRedMaster.onClick.AddListener(RemoveRedMaster);

        addBlueBola.onClick.AddListener(AddBlueBola);
        removeBlueBola.onClick.AddListener(RemoveBlueBola);

        addBlueHammer.onClick.AddListener(AddBlueHammer);
        removeBlueHammer.onClick.AddListener(RemoveBlueHammer);

        addBlueWizard.onClick.AddListener(AddBlueWizard);
        removeBlueWizard.onClick.AddListener(RemoveBlueWizard);

        addBlueRocket.onClick.AddListener(AddBlueRocket);
        removeBlueRocket.onClick.AddListener(RemoveBlueRocket);
    }

///////////////////////////////////////// Button that spawns enemies /////////////////////////////////////////////////////////////////////////////////////////

    void spawnAllInList()
    {
        if(sumOfEnemyPoints < enemyPointsTotal)
        {
            //put error message here
            errorMessage.enabled = true;
        }
        if(sumOfEnemyPoints >= enemyPointsTotal)
        {
            screenUpOrDown += 1;

            for(int i = 0; i < enemiesForSpawning.Count; i++)
            {
                spawnArea = Random.Range(0f, 2f);

                if(spawnArea <= 1f)
                {
                    Instantiate(enemiesForSpawning[i], new Vector3(Random.Range(-24.29f, -5.76f), -2.86f, 0f), Quaternion.identity);
                }
                if(spawnArea > 1f)
                {
                    Instantiate(enemiesForSpawning[i], new Vector3(Random.Range(66.77f, 97.68f), -2.86f, 0f), Quaternion.identity);
                } 
            }   
        }
    }

///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

////////////////////////////////////////////// Add and Remove Enemies from spawning ///////////////////////////////////////////////////////////////////////////

    void AddRedBomber()
    {
        enemiesForSpawning.Add(redBomber);
        sumOfEnemyPoints += 1;
        TS.bombersSpawned += 1;
    }
    void RemoveRedBomber()
    {
        if(enemiesForSpawning.Contains(redBomber) == true)
        {
            enemiesForSpawning.Remove(redBomber);
            sumOfEnemyPoints -= 1;
            TS.bombersSpawned -= 1;
        }
    }
    void AddRedRanger()
    {
        enemiesForSpawning.Add(redRanger);
        sumOfEnemyPoints += 3;
        TS.throwersSpawned += 1;
    }
    void RemoveRedRanger()
    {
        if(enemiesForSpawning.Contains(redRanger) == true)
        {
            enemiesForSpawning.Remove(redRanger);
            sumOfEnemyPoints -= 3;
            TS.throwersSpawned -= 1;
        }
    }
    void AddRedSpearman()
    {
        enemiesForSpawning.Add(redSpearman);
        sumOfEnemyPoints += 5;
        TS.spearmenSpawned += 1;
    }
    void RemoveRedSpearman()
    {
        if(enemiesForSpawning.Contains(redSpearman) == true)
        {
            enemiesForSpawning.Remove(redSpearman);
            sumOfEnemyPoints -= 5;
            TS.spearmenSpawned -= 1;
        }
    }
    void AddRedMaster()
    {
        enemiesForSpawning.Add(redMaster);
        sumOfEnemyPoints += 10;
        TS.mastersSpawned += 1;
    }
    void RemoveRedMaster()
    {
        if(enemiesForSpawning.Contains(redMaster) == true)
        {
            enemiesForSpawning.Remove(redMaster);
            sumOfEnemyPoints -= 10;
            TS.mastersSpawned -= 1;
        }
    }
    void AddBlueBola()
    {
        enemiesForSpawning.Add(blueBola);
        sumOfEnemyPoints += 10;
        TS.bolasSpawned += 1;
    }
    void RemoveBlueBola()
    {
        if(enemiesForSpawning.Contains(blueBola) == true)
        {
            enemiesForSpawning.Remove(blueBola);
            sumOfEnemyPoints -= 10;
            TS.bolasSpawned -= 1;
        }
    }
    void AddBlueHammer()
    {
        enemiesForSpawning.Add(blueHammer);
        sumOfEnemyPoints += 20;
        TS.hammersSpawned += 1;
    }
    void RemoveBlueHammer()
    {
        if(enemiesForSpawning.Contains(blueHammer) == true)
        {
            enemiesForSpawning.Remove(blueHammer);
            sumOfEnemyPoints -= 20;
            TS.hammersSpawned -= 1;
        }
    }
    void AddBlueWizard()
    {
        enemiesForSpawning.Add(blueWizard);
        sumOfEnemyPoints += 20;
        TS.wizardsSpawned += 1;
    }
    void RemoveBlueWizard()
    {
        if(enemiesForSpawning.Contains(blueWizard) == true)
        {
            enemiesForSpawning.Remove(blueWizard);
            sumOfEnemyPoints -= 20;
            TS.wizardsSpawned -= 1;
        }
    }
    void AddBlueRocket()
    {
        enemiesForSpawning.Add(blueRocket);
        sumOfEnemyPoints += 30;
        TS.rocketsSpawned += 1;
    }
    void RemoveBlueRocket()
    {
        if(enemiesForSpawning.Contains(blueRocket) == true)
        {
            enemiesForSpawning.Remove(blueRocket);
            sumOfEnemyPoints -= 30;
            TS.rocketsSpawned -= 1;
        }
    }

/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    void Update()
    {
        if(screenUpOrDown == 1)
        {
            thisScreen.localPosition = new Vector3(0f, 0f, 0f);
        }
        if(screenUpOrDown == 0)
        {
            thisScreen.localPosition = new Vector3(0f, 500f, 0f);
        }
        if(screenUpOrDown >= 2)
        {
            screenUpOrDown = 0;
        }

        enemyCounterDisplay.text = "Points Used: "+sumOfEnemyPoints+"/"+enemyPointsTotal;


        if(sumOfEnemyPoints >= enemyPointsTotal)
        {
            errorMessage.enabled = false;
        }
    }
}
