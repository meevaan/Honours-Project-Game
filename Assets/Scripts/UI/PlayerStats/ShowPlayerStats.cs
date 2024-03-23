using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowPlayerStats : MonoBehaviour
{
    public RectTransform statsScreen;
    public int screenShowing;

    public Button showStats;
    // Start is called before the first frame update
    void Start()
    {
        showStats.onClick.AddListener(ShowStats);
    }

    void ShowStats()
    {
        screenShowing += 1;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.O) && Input.GetKeyDown(KeyCode.P))
        {
            screenShowing += 1;
        }
        if(screenShowing == 0)
        {
            statsScreen.localPosition = new Vector3(0f, 1000f, 0f);
        }
        if(screenShowing == 1)
        {
            statsScreen.localPosition = new Vector3(0f, 0f, 0f);
        }
        if(screenShowing >= 2)
        {
            screenShowing = 0;
        }
    }
}
