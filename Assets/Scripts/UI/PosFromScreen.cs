using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PosFromScreen : MonoBehaviour
{
    public RectTransform thisRect;
    public float xChangePos;
    public float yPos;

    // Start is called before the first frame update
    void Start()
    {
        thisRect = this.GetComponent<RectTransform>();//-461 -291

        yPos = thisRect.localPosition.y;
    }

    // Update is called once per frame
    void Update()
    {
        thisRect.localPosition = new Vector3(-(Screen.width/2) + xChangePos, yPos, 0f);
    }
}
