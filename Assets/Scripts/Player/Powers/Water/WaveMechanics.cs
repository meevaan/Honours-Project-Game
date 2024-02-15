using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveMechanics : MonoBehaviour
{
    public float damage;
    Rigidbody2D rb;
    Collider2D col;
    public float colOff;

    GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        col = this.GetComponent<Collider2D>();

        Player = GameObject.Find("Player");

        if(Player.transform.eulerAngles.y == 0f)
        {
            this.transform.eulerAngles = new Vector3(0f, 0f, 0f);
            rb.velocity = new Vector3(3f, 0f, 0f);
        }
        else
        {
            this.transform.eulerAngles = new Vector3(0f, 180f, 0f);
            rb.velocity = new Vector3(-3f, 0f, 0f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        colOff += Time.deltaTime;

        if(colOff > 5f)
        {
            col.enabled = false;
        }
        if(colOff > 7f)
        {
            Destroy(this.gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<EnemyHealth>().enemyHealth -= damage;
        }
        if(collision.gameObject.tag == "EnemyProjectile")
        {
            Destroy(collision.gameObject);
        }
    }
}
