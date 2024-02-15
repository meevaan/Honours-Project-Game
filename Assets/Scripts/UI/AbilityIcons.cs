using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilityIcons : MonoBehaviour
{
    public bool AbilityOrEffect;
    public GameObject player;
    Image thisSR;

    public Sprite fireIcon;
    public Sprite waterIcon;
    public Sprite earthIcon;
    public Sprite lightIcon;
    public Sprite darkIcon;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        thisSR = this.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        thisSR.SetNativeSize();
        
        if(AbilityOrEffect == false)
        {
            if(player.GetComponent<Fire>().enabled == true)
            {
                thisSR.sprite = fireIcon;
                thisSR.color = new Color(thisSR.color.r, thisSR.color.g, thisSR.color.b, 1f);
            }
            if(player.GetComponent<Water>().enabled == true)
            {
                thisSR.sprite = waterIcon;
                thisSR.color = new Color(thisSR.color.r, thisSR.color.g, thisSR.color.b, 1f);
            }
            if(player.GetComponent<Earth>().enabled == true)
            {
                thisSR.sprite = earthIcon;
                thisSR.color = new Color(thisSR.color.r, thisSR.color.g, thisSR.color.b, 1f);
            }
            if(player.GetComponent<LightPower>().enabled == true)
            {
                thisSR.sprite = lightIcon;
                thisSR.color = new Color(thisSR.color.r, thisSR.color.g, thisSR.color.b, 1f);
            }
            if(player.GetComponent<Dark>().enabled == true)
            {
                thisSR.sprite = darkIcon;
                thisSR.color = new Color(thisSR.color.r, thisSR.color.g, thisSR.color.b, 1f);
            }

            if(player.GetComponent<Fire>().enabled == false &&
            player.GetComponent<Water>().enabled == false &&
            player.GetComponent<Earth>().enabled == false &&
            player.GetComponent<LightPower>().enabled == false &&
            player.GetComponent<Dark>().enabled == false)
            {
                thisSR.sprite = null;
                thisSR.color = new Color(thisSR.color.r, thisSR.color.g, thisSR.color.b, 0f);
            }
        }


        if(AbilityOrEffect == true)
        {
            if(player.GetComponent<FireEffect>().enabled == true)
            {
                thisSR.sprite = fireIcon;
                thisSR.color = new Color(thisSR.color.r, thisSR.color.g, thisSR.color.b, 1f);
            }
            if(player.GetComponent<WaterEffect>().enabled == true)
            {
                thisSR.sprite = waterIcon;
                thisSR.color = new Color(thisSR.color.r, thisSR.color.g, thisSR.color.b, 1f);
            }
            if(player.GetComponent<EarthEffect>().enabled == true)
            {
                thisSR.sprite = earthIcon;
                thisSR.color = new Color(thisSR.color.r, thisSR.color.g, thisSR.color.b, 1f);
            }
            if(player.GetComponent<LightEffect>().enabled == true)
            {
                thisSR.sprite = lightIcon;
                thisSR.color = new Color(thisSR.color.r, thisSR.color.g, thisSR.color.b, 1f);
            }
            if(player.GetComponent<DarkEffect>().enabled == true)
            {
                thisSR.sprite = darkIcon;
                thisSR.color = new Color(thisSR.color.r, thisSR.color.g, thisSR.color.b, 1f);
            }

            if(player.GetComponent<FireEffect>().enabled == false &&
            player.GetComponent<WaterEffect>().enabled == false &&
            player.GetComponent<EarthEffect>().enabled == false &&
            player.GetComponent<LightEffect>().enabled == false &&
            player.GetComponent<DarkEffect>().enabled == false)
            {
                thisSR.sprite = null;
                thisSR.color = new Color(thisSR.color.r, thisSR.color.g, thisSR.color.b, 0f);
            }
        }
    }
}
