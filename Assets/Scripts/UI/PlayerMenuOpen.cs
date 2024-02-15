using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMenuOpen : MonoBehaviour
{
    public RectTransform escMenu;
    public int moveScreen;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            moveScreen += 1;
        }

        if(moveScreen == 0)
        {
            escMenu.localPosition = new Vector3(0f, 1000f, 0f);
            Time.timeScale = 1f;
        }
        if(moveScreen == 1)
        {
            escMenu.localPosition = new Vector3(0f, 0f, 0f);
            Time.timeScale = 0f;
        }
        if(moveScreen >= 2)
        {
            moveScreen = 0;
        }
    }
}
