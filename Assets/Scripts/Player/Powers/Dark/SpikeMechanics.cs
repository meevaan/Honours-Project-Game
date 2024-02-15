using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeMechanics : MonoBehaviour
{
    public bool spike;
    public float deathTimer;

    public bool killPool;
    public float poolDeathTimer;

    public float damage;

    public float playerRot;

    // Start is called before the first frame update
    void Start()
    {
        playerRot = GameObject.Find("Player").transform.eulerAngles.y;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.eulerAngles = new Vector3(0f, playerRot, 0f);
        
        deathTimer += Time.deltaTime;

        if(spike == false && Input.GetKeyUp(KeyCode.Q))
        {
            killPool = true;
        }
        if(killPool == true)
        {
            poolDeathTimer += Time.deltaTime;
        }
        if(spike == false && poolDeathTimer >= 3f)
        {
            Destroy(this.gameObject);
        }

        if(spike == true && deathTimer >= 3f)
        {
            Destroy(this.gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy" && spike == true)
        {
            collision.gameObject.GetComponent<EnemyHealth>().enemyHealth -= damage;
            Destroy(this.gameObject);
        }
    }
}
