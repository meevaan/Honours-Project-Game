using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BolaMechanics : MonoBehaviour
{
    public GameObject bolaSpin;
    Rigidbody2D thisRB;
    public Sprite atFeet;

    public float releaseTimer;
    public bool playerHit;
    public float deathTimer;

    public BolaThrowerMechanics BTM;

    public GameObject frozenPly;

    // Start is called before the first frame update
    void Start()
    {
        bolaSpin = this.transform.GetChild(0).gameObject;
        thisRB = this.GetComponent<Rigidbody2D>();
        this.transform.localEulerAngles += new Vector3(0f, this.transform.parent.gameObject.transform.eulerAngles.y, 0f);
        thisRB.AddForce(transform.right * 15f, ForceMode2D.Impulse);
        thisRB.AddForce(transform.up * 3f, ForceMode2D.Impulse);
        BTM = this.transform.parent.gameObject.GetComponent<BolaThrowerMechanics>();
    }

    // Update is called once per frame
    void Update()
    {
        deathTimer += Time.deltaTime;

        if(playerHit == false)
        {
            bolaSpin.transform.localEulerAngles -= new Vector3(0f, 0f, 10f);
        }

        if(playerHit == true)
        {
            BTM.playerFrozen = true;
            releaseTimer += Time.deltaTime;

            if(releaseTimer > 5f)
            {
                frozenPly.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
                frozenPly.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
                BTM.playerFrozen = false;
                playerHit = false;
                Destroy(this.gameObject);
            }
        }

        if(deathTimer > 10f)
        {
            Destroy(this.gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            frozenPly = collision.gameObject;
            frozenPly.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
            playerHit = true;
            //code here to put bola at feet, stop it spinning etc
            this.GetComponent<Collider2D>().enabled = false;
            bolaSpin.GetComponent<SpriteRenderer>().sprite = atFeet;
            this.transform.position = new Vector3(collision.gameObject.transform.position.x + 0.09f, 
            collision.gameObject.transform.position.y - 0.83f, collision.gameObject.transform.position.z);
            bolaSpin.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
            thisRB.constraints = RigidbodyConstraints2D.FreezeAll;
        }
        if(collision.gameObject.tag != "Player")
        {
            Destroy(this.gameObject);
        }
    }
}
