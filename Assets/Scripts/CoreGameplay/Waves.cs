using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Waves : MonoBehaviour
{
    public Button startAttack;
    public Image fadeInOrOut;
    public float fadeTimer;
    public float timerTimer;

    public int day;
    public bool waveStarted;
    public bool newDay;
    public bool fadeOut;

    SpawningEnemies SE;

    GameObject player;

    public TMP_Text currentDay;
    public bool fadeDay;

    public CanvasGroup fadeAlpha;

    public List<GameObject> detectedEnemies = new List<GameObject>();


    public PlayerHealth PH;

    void Start()
    {
        startAttack.onClick.AddListener(beginAttack);

        SE = this.GetComponent<SpawningEnemies>();

        day = 1;

        fadeInOrOut.GetComponent<RectTransform>().sizeDelta = new Vector2(Screen.width + 10f, Screen.height + 10f);

        player = GameObject.Find("Player");

        fadeAlpha = fadeInOrOut.GetComponent<CanvasGroup>();

        PH = GameObject.Find("Player").GetComponent<PlayerHealth>();
    }

    void beginAttack()
    {
        SE.screenUpOrDown += 1;
        startAttack.GetComponent<RectTransform>().localPosition = new Vector3(0f, 500f, 0f);
    }

    void Update()
    {
        SE.enemyPointsTotal = day + (day - 1);

        if(detectedEnemies.Count > SE.enemiesForSpawning.Count)
        {
            waveStarted = true;
        }

        if(waveStarted == true && detectedEnemies.Count <= 0)
        {
            fadeOut = true;
        }

        if(fadeOut == true)
        {
            fadeInOrOut.GetComponent<RectTransform>().localPosition = new Vector3(0f, 0f, 0f);
            fadeAlpha.alpha += (fadeTimer + (fadeTimer*5));

            if(fadeAlpha.alpha >= 1)
            {
                waveStarted = false;
                newDay = true;
                fadeOut = false;
            }
        }

        if(newDay == true)
        {
            day += 1;
            startAttack.GetComponent<RectTransform>().localPosition = new Vector3(0f, 216f, 0f);
            SE.enemiesForSpawning = new List<GameObject>();
            SE.sumOfEnemyPoints = 0;
            fadeAlpha.alpha = 1f;
            player.transform.position = new Vector3(19.87f, -3.21f, 0f);
            //PH.playerHealth = PH.playerMaxHealth;
            fadeDay = true;
            newDay = false;
        }


        if(fadeAlpha.alpha > 0f && timerTimer < 3f && fadeOut == false)
        {
            timerTimer += Time.deltaTime;
        }
        if(fadeAlpha.alpha > 0f && timerTimer > 3f)
        {
            fadeAlpha.alpha -= (fadeTimer + (fadeTimer*5));
        }
        if(fadeAlpha.alpha <= 0f)
        {
            fadeInOrOut.GetComponent<RectTransform>().localPosition = new Vector3(0f, Screen.height, 0f);
            timerTimer = 0f;
        }

        //currentDay.GetComponent<CanvasGroup>().alpha = fadeInOrOut.GetComponent<CanvasGroup>().alpha;

        if(fadeDay == true && timerTimer > 2.5f)
        {
            currentDay.text = "Day " + day;
            currentDay.GetComponent<CanvasGroup>().alpha += (fadeTimer + (fadeTimer*5));
        }
        if(fadeDay == false)
        {
            currentDay.GetComponent<CanvasGroup>().alpha -= (fadeTimer + (fadeTimer*5));
        }
        if(currentDay.GetComponent<CanvasGroup>().alpha >= 1)
        {
            fadeDay = false;
        }


        if(PH.playerHealth <= 0f)
        {
            fadeOut = true;

            if(fadeAlpha.alpha >= 1)
            {
                SceneManager.LoadScene("MainMenu");
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            detectedEnemies.Add(collision.gameObject);
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            detectedEnemies.Remove(collision.gameObject);
        }
    }
}
