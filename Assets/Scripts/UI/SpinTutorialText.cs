using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinTutorialText : MonoBehaviour
{
    public Transform childObj;

    public bool moveLeft;
    public bool moveRight;

    public float startX;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(this.transform.childCount > 0)
        {
            childObj = this.transform.GetChild(0).GetComponent<Transform>();
            childObj.gameObject.SetActive(true);

            this.transform.eulerAngles += new Vector3(0f, 0f, Time.deltaTime * 20f);

            childObj.transform.localEulerAngles = new Vector3(0f, 0f, this.transform.eulerAngles.z * -1f);

            if(moveLeft == true)
            {
                childObj.localPosition -= new Vector3(0.01f, 0f, 0f);
            }
            if(moveRight == true)
            {
                childObj.localPosition += new Vector3(0.01f, 0f, 0f);
            }

            if(childObj.localPosition.x >= 3f)
            {
                moveLeft = true;
                moveRight = false;
            }
            if(childObj.localPosition.x <= -3f)
            {
                moveRight = true;
                moveLeft = false;
            }
        }
        if(this.transform.childCount <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
