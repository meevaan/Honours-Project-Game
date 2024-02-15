using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectWaterEffect : MonoBehaviour
{
    public int pressCounter;

    public Button thisButton;

    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        pressCounter = 0;
        thisButton = this.GetComponent<Button>();
        thisButton.onClick.AddListener(TaskOnClick);
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if(pressCounter >= 2)
        {
            // Change this vv to power to be selected
            player.GetComponent<WaterEffect>().enabled = false;
        }
        if(player.GetComponent<WaterEffect>().enabled == false)
        {
            pressCounter = 0;
        }
    }

    void TaskOnClick()
    {
        // And this vv too
        player.GetComponent<WaterEffect>().enabled = true;
        pressCounter += 1;

        // Add all powers here so no bugs   vv
        player.GetComponent<FireEffect>().enabled = false;
        player.GetComponent<EarthEffect>().enabled = false;
        player.GetComponent<LightEffect>().enabled = false;
        player.GetComponent<DarkEffect>().enabled = false;
    }
}
