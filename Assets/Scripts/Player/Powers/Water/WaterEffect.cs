using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterEffect : MonoBehaviour
{
    public GameObject[] weps;
    public float damage;

    public bool knockbackEnemy;

    public SpriteRenderer thisRenderer;

    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");

        thisRenderer = this.GetComponent<SpriteRenderer>();

        if(this.gameObject.tag == "PlayerWeapon" && player.GetComponent<Water>().enabled == false)
        {
            thisRenderer.color = new Color(0.15f, 0.15f, 1f, thisRenderer.color.a);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //////// Stuff for player goes here vv ///////////////////////////////
        if(this.gameObject.tag == "Player")
        {
            weps = GameObject.FindGameObjectsWithTag("PlayerWeapon");

            if(weps.Length > 0)
            {
                if(weps[0] != null)
                {
                    for(int i = 0; i < weps.Length; i++)
                    {
                        if(weps[i].GetComponent<WaterEffect>() == null)
                        {
                            weps[i].AddComponent<WaterEffect>();
                        }
                    }
                }
            }
        }

        //////// Stuff for enemies goes here vv ///////////////////////////////
        if(this.gameObject.tag == "Enemy" && knockbackEnemy == false)
        {
            this.gameObject.GetComponent<Rigidbody2D>().AddForce(transform.up * ((player.transform.position.y-this.gameObject.transform.position.y)* 15f), ForceMode2D.Impulse);
            if(player.transform.position.x < this.gameObject.transform.position.x)
            {
                this.gameObject.GetComponent<Rigidbody2D>().AddForce(transform.right * ((player.transform.position.x-this.gameObject.transform.position.x)*20f), ForceMode2D.Impulse);
            }
            if(player.transform.position.x > this.gameObject.transform.position.x)
            {
                this.gameObject.GetComponent<Rigidbody2D>().AddForce(transform.right * ((player.transform.position.x-this.gameObject.transform.position.x)*-20f), ForceMode2D.Impulse);
            }
            knockbackEnemy = true;
            Destroy(this.GetComponent<WaterEffect>());
        }

        if(this.gameObject.tag == "PlayerWeapon" && player.GetComponent<WaterEffect>().enabled == false)
        {
            Destroy(this.GetComponent<WaterEffect>());
        }
    }

    ////////////// adds the debuff to whatever enemy it touches ///////////////////////////////////////////////////////////////////////////////
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(this.gameObject.tag == "PlayerWeapon" && collision.gameObject.tag == "Enemy" && collision.gameObject.GetComponent<WaterEffect>() == null)
        {
            collision.gameObject.AddComponent<WaterEffect>();
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(this.gameObject.tag == "PlayerWeapon" && collision.gameObject.tag == "Enemy" && collision.gameObject.GetComponent<WaterEffect>() == null)
        {
            collision.gameObject.AddComponent<WaterEffect>();
        }
    }
}