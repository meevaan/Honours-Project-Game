using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePillarMechanics : MonoBehaviour
{
    public float timeTilDeath;
    public float damageTimer;
    public float damage; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeTilDeath += Time.deltaTime;

        if(timeTilDeath > 3f)
        {
            Destroy(this.gameObject);
        }

        damageTimer += Time.deltaTime;
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy" && damageTimer > 0.5f)
        {
            collision.gameObject.GetComponent<EnemyHealth>().enemyHealth -= damage;
            damageTimer = 0f;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "EnemyProjectile")
        {
            Destroy(collision.gameObject);
        }
    }
}
