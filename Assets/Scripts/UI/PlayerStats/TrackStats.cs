using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class TrackStats : MonoBehaviour
{
    private static TrackStats instance;

    public GameObject player;

    public int punchCount;


    public float fireDuration;
    public float fireEffectDuration;

    public float waterDuration;
    public float waterEffectDuration;

    public float earthDuration;
    public float earthEffectDuration;
    
    public float lightDuration;
    public float lightEffectDuration;

    public float darkDuration;
    public float darkEffectDuration;


    public int bombersSpawned;
    public int throwersSpawned;
    public int spearmenSpawned;
    public int mastersSpawned;
    public int bolasSpawned;
    public int hammersSpawned;
    public int wizardsSpawned;
    public int rocketsSpawned;

    public List<GameObject> textBoxes = new List<GameObject>();
    public GameObject playerStats;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(playerStats == null)
        {
            playerStats = GameObject.Find("PlayerStats");
            textBoxes.Clear();
        }

        if(playerStats != null)
        {
            if(playerStats.transform.childCount > textBoxes.Count)
            {
                for(int i = 0; i < playerStats.transform.childCount; i++)
                {
                    textBoxes.Add(playerStats.transform.GetChild(i).gameObject);
                }
            }


            if(textBoxes.Count >= 14)
            {
                textBoxes[0].GetComponent<TMP_Text>().text = "Punches: " + punchCount;
                textBoxes[1].GetComponent<TMP_Text>().text = "Fire Ability Duration: " + fireDuration;
                textBoxes[2].GetComponent<TMP_Text>().text = "Fire Effect Duration" + fireEffectDuration;
                textBoxes[3].GetComponent<TMP_Text>().text = "Water Ability Duration: " + waterDuration;
                textBoxes[4].GetComponent<TMP_Text>().text = "Water Effect Duration: " + waterEffectDuration;
                textBoxes[5].GetComponent<TMP_Text>().text = "Earth Ability Duration: " + earthDuration;
                textBoxes[6].GetComponent<TMP_Text>().text = "Earth Effect Duration: " + earthEffectDuration;
                textBoxes[7].GetComponent<TMP_Text>().text = "Light Ability Duration: " + lightDuration;
                textBoxes[8].GetComponent<TMP_Text>().text = "Light Effect Duration: " + lightEffectDuration;
                textBoxes[9].GetComponent<TMP_Text>().text = "Dark Ability Duration: " + darkDuration;
                textBoxes[10].GetComponent<TMP_Text>().text = "Dark Effect Duration: " + darkEffectDuration;

                textBoxes[11].GetComponent<TMP_Text>().text = "Bombers: " + bombersSpawned  + ", Points Used: " + bombersSpawned * 1;
                textBoxes[12].GetComponent<TMP_Text>().text = "Rangers: " + throwersSpawned + ", Points Used: " + throwersSpawned * 3;
                textBoxes[13].GetComponent<TMP_Text>().text = "Spearmen: " + spearmenSpawned + ", Points Used: " + spearmenSpawned * 5;
                textBoxes[14].GetComponent<TMP_Text>().text = "Masters: " + mastersSpawned + ", Points Used: " + mastersSpawned * 10;
                textBoxes[15].GetComponent<TMP_Text>().text = "Bolas: " + bolasSpawned + ", Points Used: " + bolasSpawned * 10;
                textBoxes[16].GetComponent<TMP_Text>().text = "Hammers: " + hammersSpawned + ", Points Used: " + hammersSpawned * 20;
                textBoxes[17].GetComponent<TMP_Text>().text = "Wizards: " + wizardsSpawned + ", Points Used: " + wizardsSpawned * 20;
                textBoxes[18].GetComponent<TMP_Text>().text = "Rockets: " + rocketsSpawned + ", Points Used: " + rocketsSpawned * 30;
            }
        }




        if(SceneManager.GetActiveScene().name == "TestScene")
        {
            if(player == null)
            {
                player = GameObject.Find("Player");
            }

            if(player != null)
            {
                if(player.GetComponent<Fire>().enabled == true)
                {
                    fireDuration += Time.deltaTime;
                }
                if(player.GetComponent<FireEffect>().enabled == true)
                {
                    fireEffectDuration += Time.deltaTime;
                }

                if(player.GetComponent<Water>().enabled == true)
                {
                    waterDuration += Time.deltaTime;
                }
                if(player.GetComponent<WaterEffect>().enabled == true)
                {
                    waterEffectDuration += Time.deltaTime;
                }

                if(player.GetComponent<Earth>().enabled == true)
                {
                    earthDuration += Time.deltaTime;
                }
                if(player.GetComponent<EarthEffect>().enabled == true)
                {
                    earthEffectDuration += Time.deltaTime;
                }

                if(player.GetComponent<LightPower>().enabled == true)
                {
                    lightDuration += Time.deltaTime;
                }
                if(player.GetComponent<LightEffect>().enabled == true)
                {
                    lightEffectDuration += Time.deltaTime;
                }

                if(player.GetComponent<Dark>().enabled == true)
                {
                    darkDuration += Time.deltaTime;
                }
                if(player.GetComponent<DarkEffect>().enabled == true)
                {
                    darkEffectDuration += Time.deltaTime;
                }
            }
        }

        if(SceneManager.GetActiveScene().name != "TestScene")
        {
            player = null;
        }
    }
}
