using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkEffect : MonoBehaviour
{
    public GameObject[] weps;

    public SpriteRenderer thisRenderer;

    public GameObject player;

    public GameObject healBall;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");

        thisRenderer = this.GetComponent<SpriteRenderer>();

        if(this.gameObject.tag == "PlayerWeapon" && player.GetComponent<Dark>().enabled == false)
        {
            thisRenderer.color = new Color(0.25f, 0f, 0.35f, thisRenderer.color.a);
        }

        healBall = player.GetComponent<DarkEffect>().healBall;
    }

    // Update is called once per frame
    void Update()
    {
        if(this.gameObject.tag == "Player")
        {
            weps = GameObject.FindGameObjectsWithTag("PlayerWeapon");

            if(weps.Length > 0)
            {
                if(weps[0] != null)
                {
                    for(int i = 0; i < weps.Length; i++)
                    {
                        if(weps[i].GetComponent<DarkEffect>() == null)
                        {
                            weps[i].AddComponent<DarkEffect>();
                        }
                    }
                }
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(this.gameObject.tag == "PlayerWeapon" && collision.gameObject.tag == "Enemy" && collision.gameObject.GetComponent<DarkEffect>() == null)
        {
            collision.gameObject.AddComponent<DarkEffect>();
            Instantiate(healBall, collision.transform.position, Quaternion.identity);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(this.gameObject.tag == "PlayerWeapon" && collision.gameObject.tag == "Enemy" && collision.gameObject.GetComponent<DarkEffect>() == null)
        {
            collision.gameObject.AddComponent<DarkEffect>();
            Instantiate(healBall, collision.transform.position, Quaternion.identity);
        }
    }
}
