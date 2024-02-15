using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EscMenu : MonoBehaviour
{
    public PlayerMenuOpen PMO;

    public Button settingsOpen;
    public Button loadMainMenu;
    public Button closeMenu;

    public RectTransform settingsScreen;

    // Start is called before the first frame update
    void Start()
    {
        PMO = this.GetComponent<PlayerMenuOpen>();

        closeMenu.onClick.AddListener(CloseMenu);
        loadMainMenu.onClick.AddListener(LoadMainMenu);
        settingsOpen.onClick.AddListener(OpenSettings);
    }

    void CloseMenu()
    {
        PMO.moveScreen += 1;
    }
    void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    void OpenSettings()
    {
        settingsScreen.localPosition = new Vector3(0f, 0f, 0f);
    }
}
