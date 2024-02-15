using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinDisk : MonoBehaviour
{
    public float spinTime;
    Animator thisAnim;  

    public GameObject childObj;
    public SpriteRenderer childRenderer;

    // Start is called before the first frame update
    void Start()
    {
        thisAnim = this.GetComponent<Animator>();

        childObj = this.transform.GetChild(0).gameObject;
        childRenderer = childObj.GetComponent<SpriteRenderer>();

        childRenderer.color = new Color(1f, 1f, 1f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.localEulerAngles += new Vector3(0f, 0f, 3f);
        childObj.transform.localEulerAngles -= new Vector3(0f, 0f, 6f);

        spinTime += Time.deltaTime;

        if(spinTime >= 7f)
        {
            thisAnim.Play("IceDiskBreak");

            if(spinTime > 7.42f)
            {
                Destroy(this.gameObject);
            }
        }

        childRenderer.color += new Color(0f, 0f, 0f, 0.025f);
    }
}
