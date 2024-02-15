using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireExplosionMechanics : MonoBehaviour
{
    public float damage;

    public float deathTimer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        deathTimer += Time.deltaTime;

        if(deathTimer > 1f)
        {
            Destroy(this.gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<EnemyHealth>().enemyHealth -= damage;
            
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(transform.up * ((this.transform.position.y-collision.gameObject.transform.position.y)*-7f), ForceMode2D.Impulse);
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(transform.right * ((this.transform.position.x-collision.gameObject.transform.position.x)*-7f), ForceMode2D.Impulse);
        }
    }
}
