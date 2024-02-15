using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PosAndMoveShockwave : MonoBehaviour
{
    public bool hitGround;
    public bool shockwaveLeft;
    public bool shockwaveRight;

    public float deathTimer;

    Rigidbody2D thisRB;
    
    // Start is called before the first frame update
    void Start()
    {
        if(this.transform.parent.transform.eulerAngles.y == 0f)
        {
            if(hitGround == true)
            {
                this.transform.localPosition = new Vector3(0.2f, 0f, 0f);
            }   
            if(shockwaveLeft == true)
            {
                this.transform.localPosition = new Vector3(0.051f, 0f, 0f);
            }
            if(shockwaveRight == true)
            {
                this.transform.localPosition = new Vector3(0.281f, 0f, 0f);
                this.transform.localEulerAngles = new Vector3(0f, 180f, 0f);
            }
        }
        if(this.transform.parent.transform.eulerAngles.y != 0f)
        {
            if(hitGround == true)
            {
                this.transform.localPosition = new Vector3(0.2f, 0f, 0f);
            }   
            if(shockwaveLeft == true)
            {
                this.transform.localPosition = new Vector3(0.321f, 0f, 0f);
                this.GetComponent<SpriteRenderer>().flipX = true;
            }
            if(shockwaveRight == true)
            {
                this.GetComponent<SpriteRenderer>().flipX = true;
                this.transform.localPosition = new Vector3(0.089f, 0f, 0f);
                this.transform.localEulerAngles = new Vector3(0f, 180f, 0f);
            }
        }

        thisRB = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        deathTimer += Time.deltaTime;

        if(shockwaveLeft == true)
        {
            thisRB.velocity = new Vector3(-2.5f, 0f, 0f);
            
            if(deathTimer >= 2.088)
            {
                Destroy(this.gameObject);
            }
        }
        if(shockwaveRight == true)
        {
            thisRB.velocity = new Vector3(2.5f, 0f, 0f);

            if(deathTimer >= 2.088)
            {
                Destroy(this.gameObject);
            }
        }
        if(hitGround == true && deathTimer >= 1f)
        {
            Destroy(this.gameObject);
        }
    }
}
