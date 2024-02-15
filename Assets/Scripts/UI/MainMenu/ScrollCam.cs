using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollCam : MonoBehaviour
{
    public Vector3 startPos;
    public float moveSpeed;
    public Vector3 maxPos;

    public CanvasGroup fadeInOrOut;
    public bool fade;
    public float fadeAmount;

    public float timer;

    // Start is called before the first frame update
    void Start()
    {
        //Vector3(35.3800011,-3.48000002,-10) OG pos.
        startPos = this.transform.position;
        fadeInOrOut.alpha = 1;
        fade = true;

        fadeAmount = 0.0005f;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position += new Vector3(moveSpeed, 0f, 0f);

        if(fadeInOrOut.alpha > 0 && fade == true)
        {
            fadeInOrOut.alpha -= fadeAmount + (fadeAmount * 5f);
        }

        if(this.transform.position.x > maxPos.x)
        {
            fade = false;
            timer += Time.deltaTime;
            fadeInOrOut.alpha += 0.0025f;

            if(timer > 10f || fadeInOrOut.alpha >= 1)
            {
                this.transform.position = startPos;
                fadeInOrOut.alpha = 1;
                fade = true;
                timer = 0f;
            }
        }
    }
}
