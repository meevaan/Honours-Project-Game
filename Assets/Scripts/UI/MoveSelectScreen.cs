using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSelectScreen : MonoBehaviour
{
    public RectTransform thisRect;

    public int openAbilities;

    // Start is called before the first frame update
    void Start()
    {
        thisRect = this.GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            openAbilities += 1;
        }

        if(openAbilities == 1)
        {
            thisRect.localPosition = new Vector3(0f, 0f, 0f);
            this.transform.GetChild(0).gameObject.SetActive(true);
            this.transform.GetChild(1).gameObject.SetActive(true);
        }
        if(openAbilities == 0)
        {
            thisRect.localPosition = new Vector3(0f, 500f, 0f);
            this.transform.GetChild(0).gameObject.SetActive(false);
            this.transform.GetChild(1).gameObject.SetActive(false);
        }

        if(openAbilities >= 2)
        {
            openAbilities = 0;
        }
    }
}
