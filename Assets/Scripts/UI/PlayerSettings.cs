using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSettings : MonoBehaviour
{
    public bool tutorialEnabled;
    //Add other settings here

    private static PlayerSettings instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
