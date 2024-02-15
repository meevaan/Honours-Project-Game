using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimController : MonoBehaviour
{
    Animator spriteAnimator;
    PlayerMove PM;

    public bool punching;

    Collider2D punch;

    public TrackStats TS;

    // Start is called before the first frame update
    void Start()
    {
        spriteAnimator = this.GetComponent<Animator>();
        PM = this.GetComponent<PlayerMove>();

        punch = this.transform.GetChild(0).GetComponent<Collider2D>();
        punch.enabled = false;

        TS = GameObject.Find("StatTracker").GetComponent<TrackStats>();
    }

    // Update is called once per frame
    void Update()
    {
        if((Input.GetKey(KeyCode.D) && PM.Jumping == false) || (Input.GetKey(KeyCode.A) && PM.Jumping == false))
        {
            spriteAnimator.SetBool("Walking", true);
        }
        else
        {
            spriteAnimator.SetBool("Walking", false);
        }

        if(PM.Jumping == true)
        {
            spriteAnimator.SetBool("Jumping", true);
        }
        if(PM.Jumping == false)
        {
            spriteAnimator.SetBool("Jumping", false);
        }

        if(Input.GetMouseButtonDown(0) && punching == false)
        {
            StartCoroutine(Punch());
            punching = true;
        }
        /*else 
        {
            spriteAnimator.SetBool("Punching", false);
        }*/
    }

    IEnumerator Punch()
    {
        spriteAnimator.Play("PunchAnim");
        punch.enabled = true;
        yield return new WaitForSeconds(0.167f);
        TS.punchCount += 1;
        spriteAnimator.Play("IdleAnim");
        punch.enabled = false;
        punching = false;
    }
}
