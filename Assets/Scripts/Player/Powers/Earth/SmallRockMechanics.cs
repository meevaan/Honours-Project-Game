using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallRockMechanics : MonoBehaviour
{
    GameObject player;

    public float deathTimer;

    public float damage;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        deathTimer += Time.deltaTime;

        if(deathTimer > 1f)
        {
            Destroy(this.gameObject);
        }

        if(player.transform.position.x > this.transform.position.x)
        {
            this.transform.eulerAngles = new Vector3(0f, 0f, -45f);
        }
        if(player.transform.position.x < this.transform.position.x)
        {
            this.transform.eulerAngles = new Vector3(0f, 0f, 45f);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            if(this.transform.position.x < player.transform.position.x)
            {
                player.GetComponent<Rigidbody2D>().AddForce(transform.up * 500f, ForceMode2D.Impulse);
                player.GetComponent<Rigidbody2D>().AddForce(transform.right * 450f, ForceMode2D.Impulse);
            }
            if(this.transform.position.x > player.transform.position.x)
            {
                player.GetComponent<Rigidbody2D>().AddForce(transform.up * 500f, ForceMode2D.Impulse);
                player.GetComponent<Rigidbody2D>().AddForce(transform.right * -450f, ForceMode2D.Impulse);
            }
        }
        if(collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<EnemyHealth>().enemyHealth -= damage;
            
            if(this.transform.position.x < player.transform.position.x)
            {
                collision.gameObject.GetComponent<Rigidbody2D>().AddForce(transform.up * 5f, ForceMode2D.Impulse);
                collision.gameObject.GetComponent<Rigidbody2D>().AddForce(transform.right * 6f, ForceMode2D.Impulse);
            }
            if(this.transform.position.x > player.transform.position.x)
            {
                collision.gameObject.GetComponent<Rigidbody2D>().AddForce(transform.up * 5f, ForceMode2D.Impulse);
                collision.gameObject.GetComponent<Rigidbody2D>().AddForce(transform.right * -6f, ForceMode2D.Impulse);
            }
        }
    }
}
