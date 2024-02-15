using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBat : MonoBehaviour
{
    public Image healthCube;
    PlayerHealth PH;
    public bool noHealthChange;

    // Start is called before the first frame update
    void Start()
    {
        PH = GameObject.Find("Player").GetComponent<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        //if(PH.playerHealth > 0)
         
        if(this.transform.childCount < PH.playerHealth)
        {
            for(int i = 0; i < PH.playerHealth; i++)
            {
                Instantiate(healthCube, this.transform);
            }
        }
        if(this.transform.childCount > PH.playerHealth && PH.playerHealth >= 1f)
        {
            Destroy(this.transform.GetChild(0).gameObject);
        }
        if(PH.playerHealth <= 0f)
        {
            for(int i = 0; i < this.transform.childCount; i++)
            {
                Destroy(this.transform.GetChild(i).gameObject);
            }
        }
    }
}
