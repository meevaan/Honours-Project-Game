using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthEffect : MonoBehaviour
{
    public GameObject[] weps;

    public SpriteRenderer thisRenderer;

    public GameObject player;

    public float removeTimer;
    public float oldEnemySpeed;
    public float newEnemySpeed;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");

        thisRenderer = this.GetComponent<SpriteRenderer>();

        if(this.gameObject.tag == "PlayerWeapon" && player.GetComponent<Earth>().enabled == false)
        {
            thisRenderer.color = new Color(0.5f, 0.3f, 0.1f, thisRenderer.color.a);
        }

        if(this.gameObject.tag == "Enemy")
        {
            newEnemySpeed = this.GetComponent<EnemyHealth>().enemySpeed;
            oldEnemySpeed = this.GetComponent<EnemyHealth>().enemySpeed;
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
                        if(weps[i].GetComponent<EarthEffect>() == null)
                        {
                            weps[i].AddComponent<EarthEffect>();
                        }
                    }
                }
            }
        }

        if(this.gameObject.tag == "Enemy")
        {
            removeTimer += Time.deltaTime;

            if(removeTimer < 4.5f)
            {
                this.GetComponent<EnemyHealth>().enemySpeed = newEnemySpeed/2;
            }
            if(removeTimer > 4.5f)
            {
                this.GetComponent<EnemyHealth>().enemySpeed = oldEnemySpeed;
            }
            if(removeTimer > 5f)
            {
                Destroy(this.GetComponent<EarthEffect>());
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(this.gameObject.tag == "PlayerWeapon" && collision.gameObject.tag == "Enemy" && collision.gameObject.GetComponent<EarthEffect>() == null)
        {
            collision.gameObject.AddComponent<EarthEffect>();
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(this.gameObject.tag == "PlayerWeapon" && collision.gameObject.tag == "Enemy" && collision.gameObject.GetComponent<EarthEffect>() == null)
        {
            collision.gameObject.AddComponent<EarthEffect>();
        }
    }
}
