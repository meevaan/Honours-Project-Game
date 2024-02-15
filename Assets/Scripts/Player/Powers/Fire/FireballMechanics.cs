using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballMechanics : MonoBehaviour
{
    public float timeTilDeath;
    Rigidbody2D rb;
    GameObject Player;

    public float damage;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        Player = GameObject.Find("Player");

        if(Player.transform.eulerAngles.y == 0f)
        {
            this.transform.eulerAngles = new Vector3(0f, 0f, 0f);
            rb.velocity = new Vector3(15f, 0f, 0f);
        }
        else
        {
            this.transform.eulerAngles = new Vector3(0f, 180f, 0f);
            rb.velocity = new Vector3(-15f, 0f, 0f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        timeTilDeath += Time.deltaTime;

        if(timeTilDeath > 5f)
        {
            Destroy(this.gameObject);
        }

        if(rb.velocity.x < 0f && this.transform.eulerAngles.y == 0f)
        {
            Destroy(this.gameObject);
        }
        if(rb.velocity.x > 0f && this.transform.eulerAngles.y == 180f)
        {
            Destroy(this.gameObject);
        }

        rb.AddForce(transform.right * -1f, ForceMode2D.Force);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<EnemyHealth>().enemyHealth -= damage;
        }
        if(collision.gameObject.tag != "Player")
        {
            Destroy(this.gameObject);
        }
    }
}
