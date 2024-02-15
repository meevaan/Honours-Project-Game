using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightDiskSpin : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.localEulerAngles += new Vector3(0f, 0f, 3f);
        this.transform.GetChild(0).transform.localEulerAngles -= new Vector3(0f, 0f, 6f);
    }
}
