using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorMechanics : MonoBehaviour
{
    Rigidbody2D thisRB;

    public float damage;

    GameObject player;

    public float deathTimer;
    // Start is called before the first frame update
    void Start()
    {
        thisRB = this.GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        deathTimer += Time.deltaTime;

        thisRB.AddForce(transform.right * 5f, ForceMode2D.Force);
        thisRB.AddForce(transform.up * -25f, ForceMode2D.Force);

        if(deathTimer >= 6f)
        {
            Destroy(this.gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            Destroy(this.gameObject);
        }
        
        if(collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<EnemyHealth>().enemyHealth -= damage;
            Destroy(this.gameObject);
        }
    }
}
