using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnderEffect : MonoBehaviour
{
    public GameObject parentObj;
    public GameObject emptyObj;

    public int childNum;

    /////// Put icons here ////////
    public Sprite fireIcon;
    public bool fireShowing;
    public Sprite waterIcon;
    public bool waterShowing;
    public Sprite earthIcon;
    public bool earthShowing;
    public Sprite lightIcon;
    public bool lightShowing;
    public Sprite darkIcon;
    public bool darkShowing;

    public Sprite damageBuffIcon;
    public bool damageShowing;

    // Start is called before the first frame update
    void Start()
    {
        parentObj = this.transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    { 
        if(this.transform.GetChild(childNum) != null)
        {
            if(this.transform.GetChild(childNum).GetComponent<SpriteRenderer>().sprite != null)
            {
                Instantiate(emptyObj, this.transform);
                childNum += 1;
            }

            //list all negative and positive effects here
            if(this.transform.GetChild(childNum).GetComponent<SpriteRenderer>().sprite == null)
            {
                if(parentObj.GetComponent<FireEffect>() != null && fireShowing == false)
                {
                    this.transform.GetChild(childNum).GetComponent<SpriteRenderer>().sprite = fireIcon;
                    fireShowing = true;
                }
                if(parentObj.GetComponent<WaterEffect>() != null && waterShowing == false)
                {
                    this.transform.GetChild(childNum).GetComponent<SpriteRenderer>().sprite = waterIcon;
                    waterShowing = true;
                }
                if(parentObj.GetComponent<EarthEffect>() != null && earthShowing == false)
                {
                    this.transform.GetChild(childNum).GetComponent<SpriteRenderer>().sprite = earthIcon;
                    earthShowing = true;
                }
                if(parentObj.GetComponent<LightEffect>() != null && lightShowing == false)
                {
                    this.transform.GetChild(childNum).GetComponent<SpriteRenderer>().sprite = lightIcon;
                    lightShowing = true;
                }
                if(parentObj.GetComponent<DarkEffect>() != null && darkShowing == false)
                {
                    this.transform.GetChild(childNum).GetComponent<SpriteRenderer>().sprite = darkIcon;
                    darkShowing = true;
                }


                if(parentObj.GetComponent<DamageBuff>() != null && damageShowing == false)
                {
                    this.transform.GetChild(childNum).GetComponent<SpriteRenderer>().sprite = damageBuffIcon;
                    damageShowing = true;
                }
            }
        }

        if(parentObj.GetComponent<FireEffect>() == null)
        {
            fireShowing = false;
        }
        if(parentObj.GetComponent<WaterEffect>() == null)
        {
            waterShowing = false;
        }
        if(parentObj.GetComponent<EarthEffect>() == null)
        {
            earthShowing = false;
        }
        if(parentObj.GetComponent<LightEffect>() == null)
        {
            lightShowing = false;
        }
        if(parentObj.GetComponent<DarkEffect>() == null)
        {
            darkShowing = false;
        }

        if(parentObj.GetComponent<DamageBuff>() == null)
        {
            damageShowing = false;
        }


        if(fireShowing == false && parentObj.GetComponent<FireEffect>() == null)
        {
            for(int i = 0; i < this.transform.childCount; i++)
            {
                if(this.transform.GetChild(i).GetComponent<SpriteRenderer>().sprite == fireIcon)
                {
                    Destroy(this.transform.GetChild(i).gameObject);
                    childNum -= 1;
                }
            }
        }
        if(waterShowing == false && parentObj.GetComponent<WaterEffect>() == null)
        {
            for(int i = 0; i < this.transform.childCount; i++)
            {
                if(this.transform.GetChild(i).GetComponent<SpriteRenderer>().sprite == waterIcon)
                {
                    Destroy(this.transform.GetChild(i).gameObject);
                    childNum -= 1;
                }
            }
        }
        if(earthShowing == false && parentObj.GetComponent<EarthEffect>() == null)
        {
            for(int i = 0; i < this.transform.childCount; i++)
            {
                if(this.transform.GetChild(i).GetComponent<SpriteRenderer>().sprite == earthIcon)
                {
                    Destroy(this.transform.GetChild(i).gameObject);
                    childNum -= 1;
                }
            }
        }
        if(lightShowing == false && parentObj.GetComponent<LightEffect>() == null)
        {
            for(int i = 0; i < this.transform.childCount; i++)
            {
                if(this.transform.GetChild(i).GetComponent<SpriteRenderer>().sprite == lightIcon)
                {
                    Destroy(this.transform.GetChild(i).gameObject);
                    childNum -= 1;
                }
            }
        }
        if(darkShowing == false && parentObj.GetComponent<DarkEffect>() == null)
        {
            for(int i = 0; i < this.transform.childCount; i++)
            {
                if(this.transform.GetChild(i).GetComponent<SpriteRenderer>().sprite == darkIcon)
                {
                    Destroy(this.transform.GetChild(i).gameObject);
                    childNum -= 1;
                }
            }
        }


        if(damageShowing == false && parentObj.GetComponent<DamageBuff>() == null)
        {
            for(int i = 0; i < this.transform.childCount; i++)
            {
                if(this.transform.GetChild(i).GetComponent<SpriteRenderer>().sprite == damageBuffIcon)
                {
                    Destroy(this.transform.GetChild(i).gameObject);
                    childNum -= 1;
                }
            }
        }



        if(this.transform.childCount > 1)
        {
            for(int i = 0; i < this.transform.childCount; i++)
            {
                this.transform.GetChild(i).transform.localPosition = new Vector3(-0.1f + (0.9f * i), 0.244f, 0f);
            }
        }
        else
        {
            this.transform.GetChild(0).transform.localPosition = new Vector3(0f, 0f, 0f);
        }
    }
}
