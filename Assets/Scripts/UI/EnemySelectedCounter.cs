using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EnemySelectedCounter : MonoBehaviour
{
    public Button plus;
    public Button minus;
    public TMP_Text numOfEnemies;
    public int enemyCount;

    SpawningEnemies SE;

    // Start is called before the first frame update
    void Start()
    {
        plus.onClick.AddListener(addOne);
        minus.onClick.AddListener(minusOne);

        SE = GameObject.Find("GameStateManager").GetComponent<SpawningEnemies>();
    }

    void addOne()
    {
        enemyCount += 1;
    }

    void minusOne()
    {
        enemyCount -= 1;
    }

    // Update is called once per frame
    void Update()
    {
        if(enemyCount <= 0)
        {
            enemyCount = 0;
            numOfEnemies.enabled = false;
        }
        if(enemyCount > 0)
        {
            numOfEnemies.enabled = true;
            numOfEnemies.text = "x"+enemyCount;
        }

        if(SE.enemiesForSpawning.Count <= 0)
        {
            enemyCount = 0;
        }
    }
}
