using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VisualCooldowns : MonoBehaviour
{
    //public int QorEorRC;
    public bool QAbility;
    public bool EAbility;
    public bool RCAbility;

    public Image abIcon;

    public GameObject player;

    public float fireQ;
    public bool fireQLaunched;
    public float fireE;
    public bool pillarLaunched;

    public float waterQ;
    public bool waveLaunched;

    // Start is called before the first frame update
    void Start()
    {
        this.transform.localScale = new Vector3(1f, 0f, 1f);

        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if(abIcon.sprite != null)
        {
            if(RCAbility == true)
            {
                if(player.GetComponent<Fire>().enabled == true)
                {
                    this.transform.localScale = new Vector3(1f, 1 * (player.GetComponent<Fire>().RCCooldown)/10, 1f);
                }
                if(player.GetComponent<Water>().enabled == true)
                {
                    this.transform.localScale = new Vector3(1f, 1 * (player.GetComponent<Water>().cooldown)/20, 1f);
                }
                if(player.GetComponent<Earth>().enabled == true)
                {
                    this.transform.localScale = new Vector3(1f, 1 * (player.GetComponent<Earth>().clickCooldown/15f), 1f);
                }
                if(player.GetComponent<LightPower>().enabled == true)
                {
                    this.transform.localScale = new Vector3(1f, 1 * (player.GetComponent<LightPower>().manCooldown/5f), 1f);
                }
                if(player.GetComponent<Dark>().enabled == true)
                {
                    this.transform.localScale = new Vector3(1f, 1 * (player.GetComponent<Dark>().holeCD/8f), 1f);
                }
            }
            
            if(EAbility == true)
            {
                if(player.GetComponent<Fire>().enabled == true)
                {
                    fireE += Time.deltaTime;
                    if(Input.GetKeyDown(KeyCode.E) && pillarLaunched == false && fireE >= 3.9375f)
                    {
                        fireE = 0f;
                        pillarLaunched = true;
                    }
                    if(fireE <= 3.9375f)
                    {
                        this.transform.localScale = new Vector3(1f, 1 * (fireE/3.9375f), 1f);
                    }
                    else
                    {
                        this.transform.localScale = new Vector3(1f, 1f, 1f);
                        pillarLaunched = false;
                    }
                }

                if(player.GetComponent<Water>().enabled == true)
                {
                    this.transform.localScale = new Vector3(1f, 1f, 1f);
                }
                if(player.GetComponent<Earth>().enabled == true)
                {
                    this.transform.localScale = new Vector3(1f, 1 * (player.GetComponent<Earth>().cooldown/4f), 1f);
                }
                if(player.GetComponent<LightPower>().enabled == true)
                {
                    this.transform.localScale = new Vector3(1f, 1 * (player.GetComponent<LightPower>().circleCooldown/10f), 1f);
                }
                if(player.GetComponent<Dark>().enabled == true)
                {
                    this.transform.localScale = new Vector3(1f, 1 * (player.GetComponent<Dark>().pushCD/12.5f), 1f);
                }
            }
            
            if(QAbility == true)
            {
                if(player.GetComponent<Fire>().enabled == true)
                {
                    if(Input.GetKeyUp(KeyCode.Q) && fireQ <= 0f)
                    {
                        fireQLaunched = true;
                        this.transform.localScale = new Vector3(1f, 0f, 1f);
                    }
                    if(fireQLaunched == true)
                    {
                        fireQ += Time.deltaTime;
                        this.transform.localScale += new Vector3(0f, Time.deltaTime*2.5f, 0f);
                    }
                    if(fireQ >= 0.4f)
                    {
                        fireQLaunched = false;
                        this.transform.localScale = new Vector3(1f, 1f, 1f);
                        fireQ = 0f;
                    }
                }
                if(player.GetComponent<Water>().enabled == true)
                {
                    if(Input.GetKeyDown(KeyCode.Q) && waveLaunched == false)
                    {
                        waveLaunched = true;
                        this.transform.localScale = new Vector3(1f, 0f, 1f);
                    }
                    if(waveLaunched == true)
                    {
                        waterQ += Time.deltaTime;
                        this.transform.localScale = new Vector3(1f, 1 * (waterQ/7.5f), 1f);
                    }
                    if(waterQ >= 7.5f)
                    {
                        waveLaunched = false;
                        this.transform.localScale = new Vector3(1f, 1f, 1f);
                        waterQ = 0f;
                    }
                }
                if(player.GetComponent<Earth>().enabled == true)
                {
                    this.transform.localScale = new Vector3(1f, 1 * (player.GetComponent<Earth>().rockTimer), 1f);
                }
                if(player.GetComponent<LightPower>().enabled == true)
                {
                    this.transform.localScale = new Vector3(1f, 1 * (player.GetComponent<LightPower>().spawnTime/0.25f), 1f);
                }
                if(player.GetComponent<Dark>().enabled == true)
                {
                    this.transform.localScale = new Vector3(1f, 1 * (player.GetComponent<Dark>().cooldown/3f), 1f);
                }
            }
        }
        if(abIcon.sprite == null)
        {
            this.transform.localScale = new Vector3(1f, 0f, 1f);
        }

        if(this.transform.localScale.y < 0)
        {
            this.transform.localScale = new Vector3(1f, 0f, 1f);
        }

        if(this.transform.localScale.y >= 1)
        {
            this.transform.localScale = new Vector3(1f, 1f, 1f);
        }
    }
}
