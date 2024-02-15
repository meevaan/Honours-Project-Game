using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuControls : MonoBehaviour
{
    public Button startGame;
    public Button settings;
    public Button closeSettings;
    public Button closeGame;

    public RectTransform settingsScreen;

    public int settingsScreenMove;

    // Start is called before the first frame update
    void Start()
    {
        startGame.onClick.AddListener(loadGame);
        settings.onClick.AddListener(openSettings);
        closeSettings.onClick.AddListener(CloseSettings);
        closeGame.onClick.AddListener(exitGame);
    }

    void loadGame()
    {
        SceneManager.LoadScene("TestScene");
    }
    void openSettings()
    {
        settingsScreenMove += 1;
    }
    void CloseSettings()
    {
        settingsScreenMove += 1;
    }
    void exitGame()
    {
        Application.Quit();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            settingsScreenMove += 1;
        }
        if(settingsScreenMove >= 2)
        {
            settingsScreenMove = 0;
        }

        if(settingsScreenMove <= 0)
        {
            settingsScreen.transform.localPosition = new Vector3(0f, 500f, 0f);
        }
        if(settingsScreenMove >= 1)
        {
            settingsScreen.transform.localPosition = new Vector3(0f, 0f, 0f);
        }
    }
}
