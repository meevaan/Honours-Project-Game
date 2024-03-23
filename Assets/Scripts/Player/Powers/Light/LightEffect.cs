using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightEffect : MonoBehaviour
{
    public GameObject[] weps;

    public SpriteRenderer thisRenderer;

    public GameObject player;

    public float explodeCount;

    public GameObject smite;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");

        thisRenderer = this.GetComponent<SpriteRenderer>();

        if(this.gameObject.tag == "PlayerWeapon" && player.GetComponent<LightPower>().enabled == false)
        {
            thisRenderer.color = new Color(1f, 1f, 0.4f, thisRenderer.color.a);
        }

        smite = player.GetComponent<LightEffect>().smite;
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
                        if(weps[i].GetComponent<LightEffect>() == null)
                        {
                            weps[i].AddComponent<LightEffect>();
                        }
                    }
                }
            }
        }

        //////// Stuff for enemies goes here vv ///////////////////////////////
        if(this.gameObject.tag == "Enemy")
        {
            if(explodeCount >= 10 && this.transform.Find("Smite(Clone)") == null)
            {
                Instantiate(smite, new Vector3(this.transform.position.x, 5.6f, 0f), Quaternion.identity, this.transform);
                Destroy(this.GetComponent<LightEffect>());
            }
            //Destroy(this.GetComponent<LightEffect>());
        }

        if(this.gameObject.tag == "PlayerWeapon" && player.GetComponent<LightEffect>().enabled == false)
        {
            Destroy(this.GetComponent<LightEffect>());
        }
    }

    ////////////// adds the debuff to whatever enemy it touches ///////////////////////////////////////////////////////////////////////////////
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(this.gameObject.tag == "PlayerWeapon" && collision.gameObject.tag == "Enemy" && collision.gameObject.GetComponent<LightEffect>() == null)
        {
            collision.gameObject.AddComponent<LightEffect>();
        }

        if(this.gameObject.tag == "Enemy" && collision.gameObject.tag == "PlayerWeapon" && collision.gameObject.GetComponent<LightEffect>() != null)
        {
            explodeCount += 1;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(this.gameObject.tag == "PlayerWeapon" && collision.gameObject.tag == "Enemy" && collision.gameObject.GetComponent<LightEffect>() == null)
        {
            collision.gameObject.AddComponent<LightEffect>();
        }

        if(this.gameObject.tag == "Enemy" && collision.gameObject.tag == "PlayerWeapon" && collision.gameObject.GetComponent<LightEffect>() != null)
        {
            explodeCount += 1;
        }
    }
}
