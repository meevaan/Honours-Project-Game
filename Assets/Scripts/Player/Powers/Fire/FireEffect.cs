using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireEffect : MonoBehaviour
{
    public GameObject[] weps;
    public float damage;
    public float ticksOfDamage;
    public float damageTimer;

    public SpriteRenderer thisRenderer;

    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        damage = 1f;

        player = GameObject.Find("Player");

        thisRenderer = this.GetComponent<SpriteRenderer>();

        if(this.gameObject.tag == "PlayerWeapon" && player.GetComponent<Fire>().enabled == false)
        {
            thisRenderer.color = new Color(1f, 0.3f, 0.3f, thisRenderer.color.a);
        }
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
                        if(weps[i].GetComponent<FireEffect>() == null)
                        {
                            weps[i].AddComponent<FireEffect>();
                        }
                    }
                }
            }
        }

        if(this.gameObject.tag == "Enemy")
        {
            damageTimer += Time.deltaTime;

            if(ticksOfDamage < 5f && damageTimer >= 0.25f)
            {
                this.GetComponent<EnemyHealth>().enemyHealth -= damage;
                ticksOfDamage += 1f;
                damageTimer = 0f;
            }
            if(ticksOfDamage >= 5f)
            {
                Destroy(this.GetComponent<FireEffect>());
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(this.gameObject.tag == "PlayerWeapon" && collision.gameObject.tag == "Enemy" && collision.gameObject.GetComponent<FireEffect>() == null)
        {
            collision.gameObject.AddComponent<FireEffect>();
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(this.gameObject.tag == "PlayerWeapon" && collision.gameObject.tag == "Enemy" && collision.gameObject.GetComponent<FireEffect>() == null)
        {
            collision.gameObject.AddComponent<FireEffect>();
        }
    }
}
