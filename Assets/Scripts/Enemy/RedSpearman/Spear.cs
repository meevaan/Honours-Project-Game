using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spear : MonoBehaviour
{
    Collider2D thisCD;
    // Start is called before the first frame update
    void Start()
    {
        thisCD = this.GetComponent<Collider2D>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            thisCD.enabled = false;
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(transform.up * 1250f, ForceMode2D.Impulse);
        }
    }
}
